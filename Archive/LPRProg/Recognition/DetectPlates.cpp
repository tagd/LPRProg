// DetectPlates.cpp

#include "DetectPlates.h"

///////////////////////////////////////////////////////////////////////////////////////////////////
std::vector<PossiblePlate> detectPlatesInScene(cv::Mat &imgOriginalScene) {
	std::vector<PossiblePlate> vectorOfPossiblePlates;			// this will be the return value

	cv::Mat imgGrayscaleScene;
	cv::Mat imgThreshScene;
	cv::Mat imgContours(imgOriginalScene.size(), CV_8UC3, SCALAR_BLACK);

	cv::RNG rng;

	cv::destroyAllWindows();


	preprocess(imgOriginalScene, imgGrayscaleScene, imgThreshScene);        // preprocess to get grayscale and threshold images

																			// find all possible chars in the scene,
																			// this function first finds all contours, then only includes contours that could be chars (without comparison to other chars yet)
	std::vector<PossibleChar> vectorOfPossibleCharsInScene = findPossibleCharsInScene(imgThreshScene);

	// given a vector of all possible chars, find groups of matching chars
	// in the next steps each group of matching chars will attempt to be recognized as a plate
	std::vector<std::vector<PossibleChar> > vectorOfVectorsOfMatchingCharsInScene = findVectorOfVectorsOfMatchingChars(vectorOfPossibleCharsInScene);

	for (auto &vectorOfMatchingChars : vectorOfVectorsOfMatchingCharsInScene) {                     // for each group of matching chars
		PossiblePlate possiblePlate = extractPlate(imgOriginalScene, vectorOfMatchingChars);        // attempt to extract plate

		if (possiblePlate.imgPlate.empty() == false) {                                              // if plate was found
			vectorOfPossiblePlates.push_back(possiblePlate);                                        // add to vector of possible plates
		}
	}

	std::cout << std::endl << vectorOfPossiblePlates.size() << " possible plates found" << std::endl;       // 13 with MCLRNF1 image

	return vectorOfPossiblePlates;
}

///////////////////////////////////////////////////////////////////////////////////////////////////
std::vector<PossibleChar> findPossibleCharsInScene(cv::Mat &imgThresh) {
	std::vector<PossibleChar> vectorOfPossibleChars;            // this will be the return value

	cv::Mat imgContours(imgThresh.size(), CV_8UC3, SCALAR_BLACK);
	int intCountOfPossibleChars = 0;

	cv::Mat imgThreshCopy = imgThresh.clone();

	std::vector<std::vector<cv::Point> > contours;

	cv::findContours(imgThreshCopy, contours, CV_RETR_LIST, CV_CHAIN_APPROX_SIMPLE);        // find all contours

	for (unsigned int i = 0; i < contours.size(); i++) {                // for each contour

		PossibleChar possibleChar(contours[i]);

		if (checkIfPossibleChar(possibleChar)) {                // if contour is a possible char, note this does not compare to other chars (yet) . . .
			intCountOfPossibleChars++;                          // increment count of possible chars
			vectorOfPossibleChars.push_back(possibleChar);      // and add to vector of possible chars
		}
	}

	return(vectorOfPossibleChars);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
PossiblePlate extractPlate(cv::Mat &imgOriginal, std::vector<PossibleChar> &vectorOfMatchingChars) {
	PossiblePlate possiblePlate;            // this will be the return value

											// sort chars from left to right based on x position
	std::sort(vectorOfMatchingChars.begin(), vectorOfMatchingChars.end(), PossibleChar::sortCharsLeftToRight);

	// calculate the center point of the plate
	double dblPlateCenterX = (double)(vectorOfMatchingChars[0].intCenterX + vectorOfMatchingChars[vectorOfMatchingChars.size() - 1].intCenterX) / 2.0;
	double dblPlateCenterY = (double)(vectorOfMatchingChars[0].intCenterY + vectorOfMatchingChars[vectorOfMatchingChars.size() - 1].intCenterY) / 2.0;
	cv::Point2d p2dPlateCenter(dblPlateCenterX, dblPlateCenterY);

	// calculate plate width and height
	int intPlateWidth = (int)((vectorOfMatchingChars[vectorOfMatchingChars.size() - 1].boundingRect.x + vectorOfMatchingChars[vectorOfMatchingChars.size() - 1].boundingRect.width - vectorOfMatchingChars[0].boundingRect.x) * PLATE_WIDTH_PADDING_FACTOR);

	double intTotalOfCharHeights = 0;

	for (auto &matchingChar : vectorOfMatchingChars) {
		intTotalOfCharHeights = intTotalOfCharHeights + matchingChar.boundingRect.height;
	}

	double dblAverageCharHeight = (double)intTotalOfCharHeights / vectorOfMatchingChars.size();

	int intPlateHeight = (int)(dblAverageCharHeight * PLATE_HEIGHT_PADDING_FACTOR);

	// calculate correction angle of plate region
	double dblOpposite = vectorOfMatchingChars[vectorOfMatchingChars.size() - 1].intCenterY - vectorOfMatchingChars[0].intCenterY;
	double dblHypotenuse = distanceBetweenChars(vectorOfMatchingChars[0], vectorOfMatchingChars[vectorOfMatchingChars.size() - 1]);
	double dblCorrectionAngleInRad = asin(dblOpposite / dblHypotenuse);
	double dblCorrectionAngleInDeg = dblCorrectionAngleInRad * (180.0 / CV_PI);

	// assign rotated rect member variable of possible plate
	possiblePlate.rrLocationOfPlateInScene = cv::RotatedRect(p2dPlateCenter, cv::Size2f((float)intPlateWidth, (float)intPlateHeight), (float)dblCorrectionAngleInDeg);

	cv::Mat rotationMatrix;             // final steps are to perform the actual rotation
	cv::Mat imgRotated;
	cv::Mat imgCropped;

	rotationMatrix = cv::getRotationMatrix2D(p2dPlateCenter, dblCorrectionAngleInDeg, 1.0);         // get the rotation matrix for our calculated correction angle

	cv::warpAffine(imgOriginal, imgRotated, rotationMatrix, imgOriginal.size());            // rotate the entire image

																							// crop out the actual plate portion of the rotated image
	cv::getRectSubPix(imgRotated, possiblePlate.rrLocationOfPlateInScene.size, possiblePlate.rrLocationOfPlateInScene.center, imgCropped);

	possiblePlate.imgPlate = imgCropped;            // copy the cropped plate image into the applicable member variable of the possible plate

	return(possiblePlate);
}

