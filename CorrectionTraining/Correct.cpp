// Correct.cpp

#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/imgproc/imgproc.hpp>
#include<opencv2/ml/ml.hpp>
#include <fstream>
#include <sstream>
#include<iostream>
#include<vector>

using namespace std;

// global variables ///////////////////////////////////////////////////////////////////////////////
const int MIN_CONTOUR_AREA = 100;

const int RESIZED_IMAGE_WIDTH = 20;
const int RESIZED_IMAGE_HEIGHT = 30;

///////////////////////////////////////////////////////////////////////////////////////////////////
static string getPath(string file) {
	string path;
	ifstream inFile;
	inFile.open("D:\\A-ComSci\\coursework\\LPRProg\\V5\\Recognition\\"+file);//static filepath
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

int main() {

	cv::Mat imgTrainingNumbers;         // input image
	cv::Mat imgGrayscale;               // 
	cv::Mat imgBlurred;                 // declare various images
	cv::Mat imgThresh;                  //
	cv::Mat imgThreshCopy;              //

	std::vector<std::vector<cv::Point> > ptContours;        // declare contours vector
	std::vector<cv::Vec4i> v4iHierarchy;                    // declare contours hierarchy

	cv::Mat matClassificationInts;      // these are our training classifications, note we will have to perform some conversions before writing to file later
		//important								// these are our training images, due to the data types that the KNN object KNearest requires, we have to declare a single Mat,
										// then append to it as though it's a vector, also we will have to perform some conversions before writing to file later
	cv::Mat matTrainingImagesAsFlattenedFloats;
////////////////////////////////////////////////////////////////////////Toby
	string classPath = getPath("classPath.txt");
	cv::FileStorage fsClassificationsRead(classPath+"\\classifications.xml", cv::FileStorage::READ);        // open the classifications file

	if (fsClassificationsRead.isOpened() == false) {                                                        // if the file was not opened successfully
		std::cout << "error, unable to open training classifications file, exiting program\n\n";        // show error message
		return(false);                                                                                  // and exit program
	}

	fsClassificationsRead["classifications"] >> matClassificationInts;          // read classifications section into Mat classifications variable
	fsClassificationsRead.release();                                            // close the classifications file

																			// read in training images ////////////////////////////////////////////////////////////

	cv::FileStorage fsTrainingImagesRead(classPath+"\\images.xml", cv::FileStorage::READ);              // open the training images file

	if (fsTrainingImagesRead.isOpened() == false) {                                                 // if the file was not opened successfully
		std::cout << "error, unable to open training images file, exiting program\n\n";         // show error message
		return(false);                                                                          // and exit program
	}

	fsTrainingImagesRead["images"] >> matTrainingImagesAsFlattenedFloats;           // read images section into Mat training images variable
	fsTrainingImagesRead.release();                                                 // close the traning images file
	//////////////////////////////////////////////////////////////////

	// possible chars we are interested in are digits 0 through 9 and capital letters A through Z, put these in vector intValidChars
	std::vector<int> intValidChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
		'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
		'U', 'V', 'W', 'X', 'Y', 'Z'};
	string path = getPath("path.txt");
	imgTrainingNumbers = cv::imread(path);          // read in training numbers image

	if (imgTrainingNumbers.empty()) {                               // if unable to open image
		std::cout << "error: image not read from file\n\n"; system("pause");         // show error message on command line
		return(0);                                                  // and exit program
	}

	cv::cvtColor(imgTrainingNumbers, imgGrayscale, CV_BGR2GRAY);        // convert to grayscale

	cv::GaussianBlur(imgGrayscale,              // input image
		imgBlurred,                             // output image
		cv::Size(5, 5),                         // smoothing window width and height in pixels
		0);                                     // sigma value, determines how much the image will be blurred, zero makes function choose the sigma value

												// filter image from grayscale to black and white
	cv::adaptiveThreshold(imgBlurred,           // input image
		imgThresh,                              // output image
		255,                                    // make pixels that pass the threshold full white
		cv::ADAPTIVE_THRESH_GAUSSIAN_C,         // use GAUSSIAN rather than MEAN, seems to give better results
		cv::THRESH_BINARY_INV,                  // invert so foreground will be white, background will be black
		11,                                     // size of a pixel neighborhood used to calculate threshold value
		2);                                     // constant subtracted from the mean or weighted mean

	imgThreshCopy = imgThresh.clone();          // make a copy of the thresh image, this in necessary b/c findContours modifies the image

	cv::findContours(imgThreshCopy,             // input image, make sure to use a copy since the function will modify this image in the course of finding contours
		ptContours,                             // output contours
		v4iHierarchy,                           // output hierarchy
		cv::RETR_EXTERNAL,                      // retrieve the outermost contours only
		cv::CHAIN_APPROX_SIMPLE);               // compress horizontal, vertical, and diagonal segments and leave only their end points

	for (int i = 0; i < ptContours.size(); i++) {                           // for each contour
		if (cv::contourArea(ptContours[i]) > MIN_CONTOUR_AREA) {                // if contour is big enough to consider
			cv::Rect boundingRect = cv::boundingRect(ptContours[i]);                // get the bounding rect

			cv::rectangle(imgTrainingNumbers, boundingRect, cv::Scalar(0, 0, 255), 2);      // draw red rectangle around each contour as we ask user for input

			cv::Mat matROI = imgThresh(boundingRect);           // get ROI image of bounding rect

			cv::Mat matROIResized;
			cv::resize(matROI, matROIResized, cv::Size(RESIZED_IMAGE_WIDTH, RESIZED_IMAGE_HEIGHT));     // resize image, this will be more consistent for recognition and storage
			cv::imshow("Current Character", matROIResized);                 // show resized ROI image for reference
			cv::imshow("imgTrainingNumbers", imgTrainingNumbers);       // show training numbers image, this will now have red rectangles drawn on it

			int intChar = cv::waitKey(0);          // get key press
			
			if (intChar == 27) {        // if esc key was pressed
				return(0);              // exit program
			}

			if ((intChar >= 97) && (intChar <= 122)) {        // if intchar is lowercase
				intChar = intChar - 32;//Convert char to uppercase
			}

			else if (std::find(intValidChars.begin(), intValidChars.end(), intChar) != intValidChars.end()) {     // else if the char is in the list of chars we are looking for . . .

				matClassificationInts.push_back(intChar);       // append classification char to integer list of chars

				cv::Mat matImageFloat;                          // now add the training image (some conversion is necessary first) . . .
				matROIResized.convertTo(matImageFloat, CV_32FC1);       // convert Mat to float

				cv::Mat matImageFlattenedFloat = matImageFloat.reshape(1, 1);       // flatten

				matTrainingImagesAsFlattenedFloats.push_back(matImageFlattenedFloat);       // add to Mat as though it was a vector, this is necessary due to the
																							// data types that KNearest.train accepts
			}   // end if
		}   // end if
	}   // end for

	std::cout << "training complete\n\n";

	// save classifications to file ///////////////////////////////////////////////////////
	

	cv::FileStorage fsClassificationsWrite(classPath+"/classifications.xml", cv::FileStorage::WRITE);           // open the classifications file//edit this

	if (fsClassificationsWrite.isOpened() == false) {                                                        // if the file was not opened successfully
		std::cout << "error, unable to open training classifications file, exiting program\n\n"; system("pause");        // show error message
		return(0);                                                                           // and exit program
	}

	fsClassificationsWrite << "classifications" << matClassificationInts;        // write classifications into classifications section of classifications file
	fsClassificationsWrite.release();                                            // close the classifications file

																			// save training images to file ///////////////////////////////////////////////////////

	cv::FileStorage fsTrainingImagesWrite(classPath+"/images.xml", cv::FileStorage::WRITE);         // open the training images file

	if (fsTrainingImagesWrite.isOpened() == false) {                                                 // if the file was not opened successfully
		std::cout << "error, unable to open training images file, exiting program\n\n"; system("pause");        // show error message
		return(0);
		// and exit program
	}

	fsTrainingImagesWrite << "images" << matTrainingImagesAsFlattenedFloats;         // write training images into images section of images file
	fsTrainingImagesWrite.release();                                                 // close the training images file
	return(0);
}