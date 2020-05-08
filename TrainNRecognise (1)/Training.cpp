#include "Main.h"

// global variables ///////////////////////////////////////////////////////////////////////////////
const int MIN_CONTOUR_AREA = 100;//todo why these global and how to edit for better recognition
const int RESIZED_IMAGE_WIDTH = 50;//uk chars are 50mm W by 79mm T, except I and 1
const int RESIZED_IMAGE_HEIGHT = 79;
cv::Mat imgTrainingChars;//image used for training

///////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat retrieveData(string filename) {//(filename =classifications.xml or images.xml)
	cv::FileStorage fsRead(getFontPath() + "\\" + filename + ".xml", cv::FileStorage::READ);//open the file
	cv::Mat file;
	if (fsRead.isOpened() == false) {
		updateState("error, unable to retrieve " + filename + ".xml , exiting program");
		exit(1);//not sure if this is needed//todoexit?
	}
	fsRead[filename] >> file;//read data for file to file var
	fsRead.release();//close the filestream
	return file;
}

int toUpperCase(int intChar) {
	if ((97 <= intChar) && (intChar <= 122)) {// if intchar is lowercase askii
		intChar = intChar - 32;//Convert char to uppercase
	}
	return intChar;
}

int getValidChar() {
	std::vector<int> intValidChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
				'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J','K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
				9, 11, 27};//horizontal and vertical tabs and esc
	int enteredChar;
	do {
		enteredChar = cv::waitKey(0);//Wait for input
		enteredChar = toUpperCase(enteredChar);
	} while (!(std::find(intValidChars.begin(), intValidChars.end(), enteredChar) != intValidChars.end()));//while char is not valid
	return enteredChar;
}

cv::Mat reThreshOneOrI(cv::Mat curThresh) {
	//todo
	return curThresh;
}

void saveFile(cv::Mat toSave, string filename, string savePath) {
	cv::FileStorage fsFileWrite(savePath + "/" + filename + ".xml", cv::FileStorage::WRITE);

	if (fsFileWrite.isOpened() == false) {
		updateState("error, unable to open " + filename + ".xml for saving");
		exit(1);
	}

	fsFileWrite << filename << toSave;        // write 'toSave' into 'filename' section of 'filename' file
	fsFileWrite.release();// close the file
}

void saveResults(cv::Mat matClassificationInts, cv::Mat matTrainingImagesAsFlattenedFloats) {
	string classPath = getFontPath();
	saveFile(matClassificationInts, "classifications", classPath);
	saveFile(matTrainingImagesAsFlattenedFloats, "images", classPath);
}

cv::Mat processImage() {

	cv::Mat imgGrayscale;

	cv::cvtColor(imgTrainingChars, imgGrayscale, cv::COLOR_BGR2GRAY);        // convert to grayscale

	cv::Mat imgBlurred;

	cv::GaussianBlur(imgGrayscale,              // filter image from grayscale to black and white
		imgBlurred,
		cv::Size(5, 5),                         // smoothing window width and height in pixels
		0);                                     // sigma value, determines how much the image will be blurred, zero makes function choose the sigma value

	cv::Mat imgThresh;

	cv::adaptiveThreshold(imgBlurred,           // input image
		imgThresh,                              // output image
		255,                                    // make pixels that pass the threshold full white
		cv::ADAPTIVE_THRESH_GAUSSIAN_C,         // use GAUSSIAN rather than MEAN, seems to give better results
		cv::THRESH_BINARY_INV,                  // invert so foreground will be white, background will be black
		11,                                     // size of a pixel neighborhood used to calculate threshold value
		2);                                     // constant subtracted from the mean or weighted mean

	return imgThresh;
}

std::vector<std::vector<cv::Point> > getContours(cv::Mat imgThresh) {//finds potential character in image

	std::vector<std::vector<cv::Point> > ptContours;
	std::vector<cv::Vec4i> v4iHierarchy;

	cv::findContours(imgThresh,					// input image, make sure to use a copy since the function will modify this image in the course of finding contours
		ptContours,                             // output contours
		v4iHierarchy,                           // output hierarchy
		cv::RETR_EXTERNAL,                      // retrieve the outermost contours only
		cv::CHAIN_APPROX_SIMPLE);               // compress horizontal, vertical, and diagonal segments and leave only their end points
	return ptContours;
}

int processContours(bool updateTraining, cv::Mat imgThresh, std::vector<std::vector<cv::Point> > ptContours) {//todo backspace undoes last entry
	////////////////////////////////Declare vars to store the recognised characters, and retrieve pre-existing character sets;

	cv::Mat matClassificationInts;               // these are our training classifications, note we will have to perform some conversions before writing to file later
	cv::Mat matTrainingImagesAsFlattenedFloats;  // these are our training images, due to the data types that the KNN object KNearest requires, we have to declare a single Mat,
												 // then append to it as though it's a vector, also we will have to perform some conversions before writing to file later

	if (updateTraining) {
		matClassificationInts = retrieveData("classifications");
		matTrainingImagesAsFlattenedFloats = retrieveData("images");
	}

	////////////////////////////Anaylise the contours///////////////////////////

	for (int i = 0; i < ptContours.size(); i++) {// for each contour/possible character
		if (cv::contourArea(ptContours[i]) > MIN_CONTOUR_AREA) {// if contour is big enough to consider
			
			/////////////////select the chacter contours with a box and store the boxed region//////////////
			cv::Rect boundingRect = cv::boundingRect(ptContours[i]);// get the bounding rect
			cv::rectangle(imgTrainingChars, boundingRect, cv::Scalar(0, 0, 255), 2);// draw red rectangle around current contour
			cv::Mat matROI = imgThresh(boundingRect);// get Region of interest(ROI) image of bounding rect
			cv::Mat matROIResized;
			cv::resize(matROI, matROIResized, cv::Size(RESIZED_IMAGE_WIDTH, RESIZED_IMAGE_HEIGHT));     // resize boxed region to consistant size

			///////////////////Show the user the current character as seen by the algorithm and as a boxed character in the image
			cv::imshow("Current Character", matROIResized);                 // show resized ROI image for reference
			cv::imshow("imgTrainingChars", imgTrainingChars);       // show training numbers image, this will now have red rectangles drawn on it

			
			//////////////////Get input for boxed character from the user and use this to decided next steps
			int intChar = getValidChar();
			
			if (intChar == 27) {// if esc key was pressed
				updateState("Premature exit, character set may be incomplete");
				exit(0);
			}
			else if (intChar == 9 || intChar == 11) {//if tab was pressed
				//rectangle cannot be removed when draw onto an image so we draw over in black
				cv::rectangle(imgTrainingChars, boundingRect, cv::Scalar(0, 0, 0), 2);//Draw a black rectangle over red rectangle
			} 
			else {//if the char is given a valid value by user

				matClassificationInts.push_back(intChar);       // add the user input to the list of characters

				////convert the image into a format in which it can be stored
				if (intChar == 'I' || intChar == '1') {
					matROIResized = reThreshOneOrI(matROIResized);
				}

				cv::Mat matImageFloat;
				matROIResized.convertTo(matImageFloat, CV_32FC1);// convert Mat to float
				cv::Mat matImageFlattenedFloat = matImageFloat.reshape(1, 1);// flatten
				matTrainingImagesAsFlattenedFloats.push_back(matImageFlattenedFloat);       // add to Mat as though it was a vector, this is necessary due to the
																							// data types that KNearest.train accepts

				cv::rectangle(imgTrainingChars, boundingRect, cv::Scalar(0, 255, 0), 2);//Draw a green rectangle over red rectangle
			}
		}
	}

	saveResults(matClassificationInts, matTrainingImagesAsFlattenedFloats);

	exit(0);
}

int training(bool updateTraining) {

	imgTrainingChars = cv::imread(getImgPath());// read in training image to a matrix

	if (imgTrainingChars.empty()) {
		updateState("error: Training image could not be read from file");
		return(0);
	}

	cv::Mat imgThresh = processImage();//blur the image an turn it black and white

	std::vector<std::vector<cv::Point> > ptContours = getContours(imgThresh.clone());//find contours in the image

	processContours(updateTraining, imgThresh, ptContours);//get the users input for contours and save to file
	return(1);
}