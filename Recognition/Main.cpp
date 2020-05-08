// Main.cpp

#include "Main.h"

///////////////////////////////////////////////////////////////////////////////////////////////////
int main(void) {
	std::cout << std::endl << "How many plates would you like to check" << std::endl;///asks user how many number plates they would like to check
	int length;
	std::cin >> length;
	for (int i = 1; i < length; i++)
	{
		std::string imNum = std::to_string(i);///

		std::string imageName = "UKImage";//Toby; image type png

		bool blnKNNTrainingSuccessful = loadKNNDataAndTrainKNN();           // attempt KNN training

		if (blnKNNTrainingSuccessful == false) {                            // if KNN training was not successful
																			// show error message
			std::cout << std::endl << std::endl << "error: error: KNN traning was not successful" << std::endl << std::endl;
			return(0);                                                      // and exit program
		}

		cv::Mat imgOriginalScene;           // input image

		imgOriginalScene = cv::imread(imageName + imNum + ".png");         // open image /replaced image name with var

		if (imgOriginalScene.empty()) {                             // if unable to open image
			std::cout << "error: image not read from file\n\n";     // show error message on command line
			_getch();                                               // may have to modify this line if not using Windows
			return(0);                                              // and exit program
		}

		std::vector<PossiblePlate> vectorOfPossiblePlates = detectPlatesInScene(imgOriginalScene);          // detect plates

		vectorOfPossiblePlates = detectCharsInPlates(vectorOfPossiblePlates);                               // detect chars in plates

		if (vectorOfPossiblePlates.empty()) {                                               // if no plates were found
			std::cout << std::endl << "no license plates were detected" << std::endl;       // inform user no plates were found
		}
		else {                                                                            // else
																						  // if we get in here vector of possible plates has at leat one plate

																						  // sort the vector of possible plates in DESCENDING order (most number of chars to least number of chars)
			std::sort(vectorOfPossiblePlates.begin(), vectorOfPossiblePlates.end(), PossiblePlate::sortDescendingByNumberOfChars);

			// suppose the plate with the most recognized chars (the first plate in sorted by string length descending order) is the actual plate
			PossiblePlate licPlate = vectorOfPossiblePlates.front();

			if (licPlate.strChars.length() == 0) {                                                      // if no chars were found in the plate
				std::cout << std::endl << "no characters were detected" << std::endl << std::endl;      // show message
				return(0);                                                                              // and exit program
			}

			std::cout << std::endl << "license plate read from image = " << licPlate.strChars << std::endl;     // write license plate text to std out
			std::cout << std::endl << "-----------------------------------------" << std::endl;

			cv::imwrite(imageName + "(Plate)" + ".png", licPlate.imgPlate);                  //Toby; write image of plate to file
																							 //cv::imwrite(imageName + "(Thresh)" + ".png", licPlate.imgThresh);                  //Toby; write image of thresh to file
			system("pause");//Toby; Pauses to read output
		}
	}
	return(0);
}

///////////////////////////////////////////////////////////////////////////////////////////////////


