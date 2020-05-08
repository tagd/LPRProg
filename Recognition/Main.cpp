// Main.cpp
using namespace std;

#include "Main.h"
using namespace cv;
using namespace fs;
//Methods made by me ///////////////////////////////////////////////////////////////////////////////////////////////////

int main(void) {
	cout << "Please do not close this window";
	std::ofstream dataOut;
	dataOut.open("comingsAndGoings.csv");
	string path = getPath("path.txt");
	vector<vector<string>> fileNames = getFilename(path);
	vector<string> fullFile;
	for (int x = 0; x != (fileNames.size()); ++x) {
		fullFile.push_back(path + "/" + fileNames.at(x).at(0));
	} 
	
	for (int x = 0; x != fullFile.size(); ++x) {

		string fullPath = fullFile[x];
		bool blnKNNTrainingSuccessful = loadKNNDataAndTrainKNN();           // attempt KNN training

		if (blnKNNTrainingSuccessful == false) {                            // if KNN training was not successful
																			// show error message
			cout << endl << endl << "error: error: KNN traning was not successful, Please restart the program" << endl << endl;
			return(0);                                                      // and exit program
		}

		Mat imgOriginalScene = imread(fullPath);         // open image /replaced image name with var//

		if (imgOriginalScene.empty()) {                             // if unable to open image
			dataOut << "ImageNotFound," + fullPath + ",Error404\n";//writes erronious data to database to be delt with by user
			_getch();                                               // may have to modify this line if not using Windows
			
																	//return(0);                                              // and exit program
		}else {

			vector<PossiblePlate> vectorOfPossiblePlates = detectPlatesInScene(imgOriginalScene);          // detect plates

			vectorOfPossiblePlates = detectCharsInPlates(vectorOfPossiblePlates);                               // detect chars in plates

			if (vectorOfPossiblePlates.empty()) {                                               // if no plates were found
				//cout << endl << "no license plates were detected" << endl;       // inform user no plates were found
				dataOut << "PlateNotFound," + fullPath + ",Error404\n";
			}
			else {                                                                            // else
																							  // if we get in here vector of possible plates has at leat one plate
																							  // sort the vector of possible plates in DESCENDING order (most number of chars to least number of chars)
				sort(vectorOfPossiblePlates.begin(), vectorOfPossiblePlates.end(), PossiblePlate::sortDescendingByNumberOfChars);

				// suppose the plate with the most recognized chars (the first plate in sorted by string length descending order) is the actual plate
				PossiblePlate licPlate = vectorOfPossiblePlates.front();

				if (licPlate.strChars.length() == 0) {                                                      // if no chars were found in the plate
					dataOut << "CharNotFound," + fullPath + ",Error404\n";
				}
				else {

					string pltPath = path + "(plates)" + "/" + fileNames.at(x).at(0);

					boost::filesystem::path path_target(pltPath);
					boost::filesystem::path path_folder = path_target.parent_path();//extract   folder
					if (!boost::filesystem::exists(path_folder)) //create folder if it doesn't exist
					{
						boost::filesystem::create_directory(path_folder);
					}
					imwrite(pltPath, licPlate.imgPlate);
					dataOut << pltPath + "," + fullPath + "," + licPlate.strChars + "\n";
				}
			}

		}
	}
	dataOut.close();
	return(0);
}

static string getPath(string file) {
	string path;
	std::ifstream inFile;
	inFile.open("D:\\A-ComSci\\coursework\\LPRProg\\V5\\Recognition\\" + file);//static filepath
	if (!inFile) {
		cout << "Error please restart the program";
		exit(1);   // call system to stop
	}
	string x;
	while (inFile >> x) {//loops for every string seperated by a space
		if (path != "") { path = path + " "; };//manually re-adds spaces
		path = path + x;
	}
	inFile.close();
	return path;
};

static vector<vector<string>> getFilename(const fs::path& root) {//2084 avoid the compiler error 2084 because the string class has a getFilename function
	vector<string> extensions{ ".bmp", ".dib", ".jpeg", ".jpg", ".jpe", ".jp2", ".pbm", ".png", ".pgm", ".ppm", ".sr", ".ras", ".tiff", ".tif" };//'strcasecmp': is not a member of 'boost::filesystem::path' Hence all formats are needed
	vector<fs::path> files;
	vector<fs::path> files2;
	vector<vector<string>> fileNames;
	for (int x = 0; x != extensions.size(); ++x) {
		string ext = extensions[x];
		if (!fs::exists(root) || !fs::is_directory(root)) return(fileNames);

		fs::recursive_directory_iterator it(root);
		fs::recursive_directory_iterator endit;
		while (it != endit)
		{
			if (fs::is_regular_file(*it) && it->path().extension() == ext) {
				files.push_back(it->path().filename());
				files2.push_back(it->path().stem());
			}//Endif
			++it;
		}
	}
	for (int x = 0; x != files.size(); ++x) {
		vector <string> newColumn;
		fileNames.push_back(newColumn);
		fileNames.at(x).push_back(files.at(x).string());
		fileNames.at(x).push_back(files2.at(x).string());
	}
	return(fileNames);
}

//Methods by Chris/////////////////////////////////////////////////////////////////////////////////////////////////

PossibleChar::PossibleChar(vector<Point> _contour) {
	contour = _contour;

	boundingRect = cv::boundingRect(contour);

	intCenterX = (boundingRect.x + boundingRect.x + boundingRect.width) / 2;
	intCenterY = (boundingRect.y + boundingRect.y + boundingRect.height) / 2;

	dblDiagonalSize = sqrt(pow(boundingRect.width, 2) + pow(boundingRect.height, 2));

	dblAspectRatio = (float)boundingRect.width / (float)boundingRect.height;
}

bool loadKNNDataAndTrainKNN(void) {
	string classPath = getPath("classPath.txt");

	// read in training classifications ///////////////////////////////////////////////////

	Mat matClassificationInts;              // we will read the classification numbers into this variable as though it is a vector

	FileStorage fsClassifications(classPath + "/classifications.xml", FileStorage::READ);        // open the classifications file

	if (fsClassifications.isOpened() == false) {                                                        // if the file was not opened successfully
		cout << "error, unable to open training classifications file, exiting program\n\n";        // show error message
		return(false);                                                                                  // and exit program
	}

	fsClassifications["classifications"] >> matClassificationInts;          // read classifications section into Mat classifications variable
	fsClassifications.release();                                            // close the classifications file

																			// read in training images ////////////////////////////////////////////////////////////

	Mat matTrainingImagesAsFlattenedFloats;         // we will read multiple images into this single image variable as though it is a vector

	FileStorage fsTrainingImages(classPath + "/images.xml", FileStorage::READ);              // open the training images file

	if (fsTrainingImages.isOpened() == false) {                                                 // if the file was not opened successfully
		cout << "error, unable to open training images file, exiting program\n\n";         // show error message
		return(false);                                                                          // and exit program
	}

	fsTrainingImages["images"] >> matTrainingImagesAsFlattenedFloats;           // read images section into Mat training images variable
	fsTrainingImages.release();                                                 // close the traning images file

																				// train //////////////////////////////////////////////////////////////////////////////

																				// finally we get to the call to train, note that both parameters have to be of type Mat (a single Mat)
																				// even though in reality they are multiple images / numbers
	kNearest->setDefaultK(1);

	kNearest->train(matTrainingImagesAsFlattenedFloats, ml::ROW_SAMPLE, matClassificationInts);

	return true;
}

///////////////////////////////////////////////////////////////////////////////////////////////////
vector<PossiblePlate> detectCharsInPlates(vector<PossiblePlate> &vectorOfPossiblePlates) {
	int intPlateCounter = 0;				// this is only for showing steps
	Mat imgContours;
	vector<vector<Point> > contours;
	RNG rng;

	if (vectorOfPossiblePlates.empty()) {               // if vector of possible plates is empty
		return(vectorOfPossiblePlates);                 // return
	}
	// at this point we can be sure vector of possible plates has at least one plate

	for (auto &possiblePlate : vectorOfPossiblePlates) {            // for each possible plate, this is a big for loop that takes up most of the function

		preprocess(possiblePlate.imgPlate, possiblePlate.imgGrayscale, possiblePlate.imgThresh);        // preprocess to get grayscale and threshold images

																										// upscale size by 60% for better viewing and character recognition
		resize(possiblePlate.imgThresh, possiblePlate.imgThresh, Size(), 1.6, 1.6);

		// threshold again to eliminate any gray areas
		threshold(possiblePlate.imgThresh, possiblePlate.imgThresh, 0.0, 255.0, CV_THRESH_BINARY | CV_THRESH_OTSU);

		// find all possible chars in the plate,
		// this function first finds all contours, then only includes contours that could be chars (without comparison to other chars yet)
		vector<PossibleChar> vectorOfPossibleCharsInPlate = findPossibleCharsInPlate(possiblePlate.imgGrayscale, possiblePlate.imgThresh);

		// given a vector of all possible chars, find groups of matching chars within the plate
		vector<vector<PossibleChar> > vectorOfVectorsOfMatchingCharsInPlate = findVectorOfVectorsOfMatchingChars(vectorOfPossibleCharsInPlate);


		if (vectorOfVectorsOfMatchingCharsInPlate.size() == 0) {                // if no groups of matching chars were found in the plate

			possiblePlate.strChars = "";            // set plate string member variable to empty string
			continue;                               // go back to top of for loop
		}

		for (auto &vectorOfMatchingChars : vectorOfVectorsOfMatchingCharsInPlate) {                                         // for each vector of matching chars in the current plate
			sort(vectorOfMatchingChars.begin(), vectorOfMatchingChars.end(), PossibleChar::sortCharsLeftToRight);      // sort the chars left to right
			vectorOfMatchingChars = removeInnerOverlappingChars(vectorOfMatchingChars);                                     // and eliminate any overlapping chars
		}

		// within each possible plate, suppose the longest vector of potential matching chars is the actual vector of chars
		unsigned int intLenOfLongestVectorOfChars = 0;
		unsigned int intIndexOfLongestVectorOfChars = 0;
		// loop through all the vectors of matching chars, get the index of the one with the most chars
		for (unsigned int i = 0; i < vectorOfVectorsOfMatchingCharsInPlate.size(); i++) {
			if (vectorOfVectorsOfMatchingCharsInPlate[i].size() > intLenOfLongestVectorOfChars) {
				intLenOfLongestVectorOfChars = vectorOfVectorsOfMatchingCharsInPlate[i].size();
				intIndexOfLongestVectorOfChars = i;
			}
		}
		// suppose that the longest vector of matching chars within the plate is the actual vector of chars
		vector<PossibleChar> longestVectorOfMatchingCharsInPlate = vectorOfVectorsOfMatchingCharsInPlate[intIndexOfLongestVectorOfChars];

		// perform char recognition on the longest vector of matching chars in the plate
		possiblePlate.strChars = recognizeCharsInPlate(possiblePlate.imgThresh, longestVectorOfMatchingCharsInPlate);

	}   // end for each possible plate big for loop that takes up most of the function

	return(vectorOfPossiblePlates);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
vector<PossibleChar> findPossibleCharsInPlate(Mat &imgGrayscale, Mat &imgThresh) {
	vector<PossibleChar> vectorOfPossibleChars;                            // this will be the return value

	Mat imgThreshCopy;

	vector<vector<Point> > contours;

	imgThreshCopy = imgThresh.clone();				// make a copy of the thresh image, this in necessary b/c findContours modifies the image

	findContours(imgThreshCopy, contours, CV_RETR_LIST, CV_CHAIN_APPROX_SIMPLE);        // find all contours in plate

	for (auto &contour : contours) {                            // for each contour
		PossibleChar possibleChar(contour);

		if (checkCharSize(possibleChar)) {                // if contour is a possible char, note this does not compare to other chars (yet) . . .
			vectorOfPossibleChars.push_back(possibleChar);      // add to vector of possible chars
		}
	}

	return(vectorOfPossibleChars);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
bool checkCharSize(PossibleChar &possibleChar) {
	// this function is a 'first pass' that does a rough check on a contour to see if it could be a char,
	// note that we are not (yet) comparing the char to other chars to look for a group
	if (possibleChar.boundingRect.area() > minArea &&
		possibleChar.boundingRect.width > minWidth && possibleChar.boundingRect.height > minHeight &&
		minAspectRatio < possibleChar.dblAspectRatio && possibleChar.dblAspectRatio < maxAspectRatio) {
		return(true);
	}
	else {
		return(false);
	}
}

///////////////////////////////////////////////////////////////////////////////////////////////////
vector<vector<PossibleChar> > findVectorOfVectorsOfMatchingChars(const vector<PossibleChar> &vectorOfPossibleChars) {
	// with this function, we start off with all the possible chars in one big vector
	// the purpose of this function is to re-arrange the one big vector of chars into a vector of vectors of matching chars,
	// note that chars that are not found to be in a group of matches do not need to be considered further
	vector<vector<PossibleChar> > vectorOfVectorsOfMatchingChars;             // this will be the return value

	for (auto &possibleChar : vectorOfPossibleChars) {                  // for each possible char in the one big vector of chars

																		// find all chars in the big vector that match the current char
		vector<PossibleChar> vectorOfMatchingChars = findVectorOfMatchingChars(possibleChar, vectorOfPossibleChars);

		vectorOfMatchingChars.push_back(possibleChar);          // also add the current char to current possible vector of matching chars

																// if current possible vector of matching chars is not long enough to constitute a possible plate
		if (vectorOfMatchingChars.size() < MIN_NUMBER_OF_MATCHING_CHARS) {
			continue;                       // jump back to the top of the for loop and try again with next char, note that it's not necessary
											// to save the vector in any way since it did not have enough chars to be a possible plate
		}
		// if we get here, the current vector passed test as a "group" or "cluster" of matching chars
		vectorOfVectorsOfMatchingChars.push_back(vectorOfMatchingChars);            // so add to our vector of vectors of matching chars

																					// remove the current vector of matching chars from the big vector so we don't use those same chars twice,
																					// make sure to make a new big vector for this since we don't want to change the original big vector
		vector<PossibleChar> vectorOfPossibleCharsWithCurrentMatchesRemoved;

		for (auto &possChar : vectorOfPossibleChars) {
			if (find(vectorOfMatchingChars.begin(), vectorOfMatchingChars.end(), possChar) == vectorOfMatchingChars.end()) {
				vectorOfPossibleCharsWithCurrentMatchesRemoved.push_back(possChar);
			}
		}
		// declare new vector of vectors of chars to get result from recursive call
		vector<vector<PossibleChar> > recursiveVectorOfVectorsOfMatchingChars;

		// recursive call
		recursiveVectorOfVectorsOfMatchingChars = findVectorOfVectorsOfMatchingChars(vectorOfPossibleCharsWithCurrentMatchesRemoved);	// recursive call !!

		for (auto &recursiveVectorOfMatchingChars : recursiveVectorOfVectorsOfMatchingChars) {      // for each vector of matching chars found by recursive call
			vectorOfVectorsOfMatchingChars.push_back(recursiveVectorOfMatchingChars);               // add to our original vector of vectors of matching chars
		}

		break;		// exit for loop
	}

	return(vectorOfVectorsOfMatchingChars);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
vector<PossibleChar> findVectorOfMatchingChars(const PossibleChar &possibleChar, const vector<PossibleChar> &vectorOfChars) {
	// the purpose of this function is, given a possible char and a big vector of possible chars,
	// find all chars in the big vector that are a match for the single possible char, and return those matching chars as a vector
	vector<PossibleChar> vectorOfMatchingChars;                // this will be the return value

	for (auto &possibleMatchingChar : vectorOfChars) {              // for each char in big vector

																	// if the char we attempting to find matches for is the exact same char as the char in the big vector we are currently checking
		if (possibleMatchingChar == possibleChar) {
			// then we should not include it in the vector of matches b/c that would end up double including the current char
			continue;           // so do not add to vector of matches and jump back to top of for loop
		}
		// compute stuff to see if chars are a match
		double dblDistanceBetweenChars = distanceBetweenChars(possibleChar, possibleMatchingChar);
		double dblAngleBetweenChars = angleBetweenChars(possibleChar, possibleMatchingChar);
		double dblChangeInArea = (double)abs(possibleMatchingChar.boundingRect.area() - possibleChar.boundingRect.area()) / (double)possibleChar.boundingRect.area();
		double dblChangeInWidth = (double)abs(possibleMatchingChar.boundingRect.width - possibleChar.boundingRect.width) / (double)possibleChar.boundingRect.width;
		double dblChangeInHeight = (double)abs(possibleMatchingChar.boundingRect.height - possibleChar.boundingRect.height) / (double)possibleChar.boundingRect.height;

		// check if chars match
		if (dblDistanceBetweenChars < (possibleChar.dblDiagonalSize * MAX_DIAG_SIZE_MULTIPLE_AWAY) &&
			dblAngleBetweenChars < MAX_ANGLE_BETWEEN_CHARS &&
			dblChangeInArea < MAX_CHANGE_IN_AREA &&
			dblChangeInWidth < MAX_CHANGE_IN_WIDTH &&
			dblChangeInHeight < MAX_CHANGE_IN_HEIGHT) {
			vectorOfMatchingChars.push_back(possibleMatchingChar);      // if the chars are a match, add the current char to vector of matching chars
		}
	}

	return(vectorOfMatchingChars);          // return result
}

///////////////////////////////////////////////////////////////////////////////////////////////////
// use Pythagorean theorem to calculate distance between two chars
double distanceBetweenChars(const PossibleChar &firstChar, const PossibleChar &secondChar) {
	int intX = abs(firstChar.intCenterX - secondChar.intCenterX);
	int intY = abs(firstChar.intCenterY - secondChar.intCenterY);

	return(sqrt(pow(intX, 2) + pow(intY, 2)));
}

///////////////////////////////////////////////////////////////////////////////////////////////////
// use basic trigonometry(SOH CAH TOA) to calculate angle between chars
double angleBetweenChars(const PossibleChar &firstChar, const PossibleChar &secondChar) {
	double dblAdj = abs(firstChar.intCenterX - secondChar.intCenterX);
	double dblOpp = abs(firstChar.intCenterY - secondChar.intCenterY);

	double dblAngleInRad = atan(dblOpp / dblAdj);

	double dblAngleInDeg = dblAngleInRad * (180.0 / CV_PI);

	return(dblAngleInDeg);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
// if we have two chars overlapping or to close to each other to possibly be separate chars, remove the inner (smaller) char,
// this is to prevent including the same char twice if two contours are found for the same char,
// for example for the letter 'O' both the inner ring and the outer ring may be found as contours, but we should only include the char once
vector<PossibleChar> removeInnerOverlappingChars(vector<PossibleChar> &vectorOfMatchingChars) {
	vector<PossibleChar> vectorOfMatchingCharsWithInnerCharRemoved(vectorOfMatchingChars);

	for (auto &currentChar : vectorOfMatchingChars) {
		for (auto &otherChar : vectorOfMatchingChars) {
			if (currentChar != otherChar) {                         // if current char and other char are not the same char . . .
																	// if current char and other char have center points at almost the same location . . .
				if (distanceBetweenChars(currentChar, otherChar) < (currentChar.dblDiagonalSize * MIN_DIAG_SIZE_MULTIPLE_AWAY)) {
					// if we get in here we have found overlapping chars
					// next we identify which char is smaller, then if that char was not already removed on a previous pass, remove it

					// if current char is smaller than other char
					if (currentChar.boundingRect.area() < otherChar.boundingRect.area()) {
						// look for char in vector with an iterator
						vector<PossibleChar>::iterator currentCharIterator = find(vectorOfMatchingCharsWithInnerCharRemoved.begin(), vectorOfMatchingCharsWithInnerCharRemoved.end(), currentChar);
						// if iterator did not get to end, then the char was found in the vector
						if (currentCharIterator != vectorOfMatchingCharsWithInnerCharRemoved.end()) {
							vectorOfMatchingCharsWithInnerCharRemoved.erase(currentCharIterator);       // so remove the char
						}
					}
					else {        // else if other char is smaller than current char
								  // look for char in vector with an iterator
						vector<PossibleChar>::iterator otherCharIterator = find(vectorOfMatchingCharsWithInnerCharRemoved.begin(), vectorOfMatchingCharsWithInnerCharRemoved.end(), otherChar);
						// if iterator did not get to end, then the char was found in the vector
						if (otherCharIterator != vectorOfMatchingCharsWithInnerCharRemoved.end()) {
							vectorOfMatchingCharsWithInnerCharRemoved.erase(otherCharIterator);         // so remove the char
						}
					}
				}
			}
		}
	}

	return(vectorOfMatchingCharsWithInnerCharRemoved);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
// this is where we apply the actual char recognition
string recognizeCharsInPlate(Mat &imgThresh, vector<PossibleChar> &vectorOfMatchingChars) {
	string strChars;               // this will be the return value, the chars in the lic plate

	Mat imgThreshColor;

	// sort chars from left to right
	sort(vectorOfMatchingChars.begin(), vectorOfMatchingChars.end(), PossibleChar::sortCharsLeftToRight);

	cvtColor(imgThresh, imgThreshColor, CV_GRAY2BGR);       // make color version of threshold image so we can draw contours in color on it

	for (auto &currentChar : vectorOfMatchingChars) {           // for each char in plate
		rectangle(imgThreshColor, currentChar.boundingRect, RGB_Green, 2);       // draw green box around the char

		Mat imgROItoBeCloned = imgThresh(currentChar.boundingRect);                 // get ROI image of bounding rect

		Mat imgROI = imgROItoBeCloned.clone();      // clone ROI image so we don't change original when we resize

		Mat imgROIResized;
		// resize image, this is necessary for char recognition
		resize(imgROI, imgROIResized, Size(RESIZED_CHAR_IMAGE_WIDTH, RESIZED_CHAR_IMAGE_HEIGHT));

		Mat matROIFloat;

		imgROIResized.convertTo(matROIFloat, CV_32FC1);         // convert Mat to float, necessary for call to findNearest

		Mat matROIFlattenedFloat = matROIFloat.reshape(1, 1);       // flatten Matrix into one row

		Mat matCurrentChar(0, 0, CV_32F);                   // declare Mat to read current char into, this is necessary b/c findNearest requires a Mat

		kNearest->findNearest(matROIFlattenedFloat, 1, matCurrentChar);     // finally we can call find_nearest !!!

		float fltCurrentChar = (float)matCurrentChar.at<float>(0, 0);       // convert current char from Mat to float

		strChars = strChars + char(int(fltCurrentChar));        // append current char to full string
	}

	return(strChars);               // return result
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

vector<PossiblePlate> detectPlatesInScene(Mat &imgOriginalScene) {
	vector<PossiblePlate> vectorOfPossiblePlates;			// this will be the return value

	Mat imgGrayscaleScene;
	Mat imgThreshScene;
	Mat imgContours(imgOriginalScene.size(), CV_8UC3, RGB_Black);

	RNG rng;

	destroyAllWindows();


	preprocess(imgOriginalScene, imgGrayscaleScene, imgThreshScene);        // preprocess to get grayscale and threshold images

																			// find all possible chars in the scene,
																			// this function first finds all contours, then only includes contours that could be chars (without comparison to other chars yet)
	vector<PossibleChar> vectorOfPossibleCharsInScene = findPossibleCharsInScene(imgThreshScene);

	// given a vector of all possible chars, find groups of matching chars
	// in the next steps each group of matching chars will attempt to be recognized as a plate
	vector<vector<PossibleChar> > vectorOfVectorsOfMatchingCharsInScene = findVectorOfVectorsOfMatchingChars(vectorOfPossibleCharsInScene);

	for (auto &vectorOfMatchingChars : vectorOfVectorsOfMatchingCharsInScene) {                     // for each group of matching chars
		PossiblePlate possiblePlate = extractPlate(imgOriginalScene, vectorOfMatchingChars);        // attempt to extract plate

		if (possiblePlate.imgPlate.empty() == false) {                                              // if plate was found
			vectorOfPossiblePlates.push_back(possiblePlate);                                        // add to vector of possible plates
		}
	}

	//cout << endl << vectorOfPossiblePlates.size() << " possible plates found" << endl;       // 13 with MCLRNF1 image

	return vectorOfPossiblePlates;
}

///////////////////////////////////////////////////////////////////////////////////////////////////
vector<PossibleChar> findPossibleCharsInScene(Mat &imgThresh) {
	vector<PossibleChar> vectorOfPossibleChars;            // this will be the return value

	Mat imgContours(imgThresh.size(), CV_8UC3, RGB_Black);
	int numPossibleChars = 0;

	Mat imgThreshCopy = imgThresh.clone();

	vector<vector<Point> > contours;

	findContours(imgThreshCopy, contours, CV_RETR_LIST, CV_CHAIN_APPROX_SIMPLE);        // find all contours

	for (unsigned int i = 0; i < contours.size(); i++) {                // for each contour

		PossibleChar possibleChar(contours[i]);

		if (checkCharSize(possibleChar)) {                // if contour is a possible char, note this does not compare to other chars (yet) . . .
			numPossibleChars++;                          // increment count of possible chars
			vectorOfPossibleChars.push_back(possibleChar);      // and add to vector of possible chars
		}
	}

	return(vectorOfPossibleChars);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
PossiblePlate extractPlate(Mat &imgOriginal, vector<PossibleChar> &vectorOfMatchingChars) {
	PossiblePlate possiblePlate;            // this will be the return value

											// sort chars from left to right based on x position
	sort(vectorOfMatchingChars.begin(), vectorOfMatchingChars.end(), PossibleChar::sortCharsLeftToRight);

	// calculate the center point of the plate
	double dblPlateCenterX = (double)(vectorOfMatchingChars[0].intCenterX + vectorOfMatchingChars[vectorOfMatchingChars.size() - 1].intCenterX) / 2.0;
	double dblPlateCenterY = (double)(vectorOfMatchingChars[0].intCenterY + vectorOfMatchingChars[vectorOfMatchingChars.size() - 1].intCenterY) / 2.0;
	Point2d p2dPlateCenter(dblPlateCenterX, dblPlateCenterY);

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
	possiblePlate.rrLocationOfPlateInScene = RotatedRect(p2dPlateCenter, Size2f((float)intPlateWidth, (float)intPlateHeight), (float)dblCorrectionAngleInDeg);

	Mat rotationMatrix;             // final steps are to perform the actual rotation
	Mat imgRotated;
	Mat imgCropped;

	rotationMatrix = getRotationMatrix2D(p2dPlateCenter, dblCorrectionAngleInDeg, 1.0);         // get the rotation matrix for our calculated correction angle

	warpAffine(imgOriginal, imgRotated, rotationMatrix, imgOriginal.size());            // rotate the entire image

																							// crop out the actual plate portion of the rotated image
	getRectSubPix(imgRotated, possiblePlate.rrLocationOfPlateInScene.size, possiblePlate.rrLocationOfPlateInScene.center, imgCropped);

	possiblePlate.imgPlate = imgCropped;            // copy the cropped plate image into the applicable member variable of the possible plate

	return(possiblePlate);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
void preprocess(Mat &imgOriginal, Mat &imgGrayscale, Mat &imgThresh) {
	imgGrayscale = extractValue(imgOriginal);                           // extract value channel only from original image to get imgGrayscale

	Mat imgMaxContrastGrayscale = maximizeContrast(imgGrayscale);       // maximizes contrast making the image only two colours

	Mat imgBlurred;

GaussianBlur(imgMaxContrastGrayscale, imgBlurred, Size(5, 5), 0);          // gaussian blur reduces smooths image to reduce detail
	//Size is the amount of pixels the blur will work on at once, higher numbers= more blurring
																									// call adaptive threshold to get imgThresh
	adaptiveThreshold(imgBlurred, imgThresh, 255.0, CV_ADAPTIVE_THRESH_GAUSSIAN_C, CV_THRESH_BINARY_INV, ADAPTIVE_THRESH_BLOCK_SIZE, ADAPTIVE_THRESH_WEIGHT);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
Mat maximizeContrast(Mat &imgGrayscale) {
	Mat imgTopHat;
	Mat imgBlackHat;
	Mat imgGrayscalePlusTopHat;
	Mat imgGrayscalePlusTopHatMinusBlackHat;

	Mat structuringElement = getStructuringElement(CV_SHAPE_RECT, Size(3, 3));

	morphologyEx(imgGrayscale, imgTopHat, CV_MOP_TOPHAT, structuringElement);
	morphologyEx(imgGrayscale, imgBlackHat, CV_MOP_BLACKHAT, structuringElement);

	imgGrayscalePlusTopHat = imgGrayscale + imgTopHat;
	imgGrayscalePlusTopHatMinusBlackHat = imgGrayscalePlusTopHat - imgBlackHat;

	return(imgGrayscalePlusTopHatMinusBlackHat);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
Mat extractValue(Mat &imgOriginal) {
	Mat imgHSV;
	vector<Mat> vectorOfHSVImages;
	Mat imgValue;

	cvtColor(imgOriginal, imgHSV, CV_BGR2HSV);

	split(imgHSV, vectorOfHSVImages);

	imgValue = vectorOfHSVImages[2];

	return(imgValue);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////