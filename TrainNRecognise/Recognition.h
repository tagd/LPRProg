#ifndef REC
#define REC

#include <boost/filesystem.hpp>
#include <string> 
#include <conio.h>  
#include <iomanip>
#include <Windows.h>

#include "Main.h"//imports everything else

using namespace std;
namespace fs = ::boost::filesystem;
using namespace cv;

// global constants ///////////////////////////////////////////////////////////////////////////////
const Scalar RGB_Black = Scalar(0.0, 0.0, 0.0);
const Scalar RGB_Green = Scalar(0.0, 255.0, 0.0);

const int minWidth = 2;
const int minHeight = 8;

const double minAspectRatio = 0.25;
const double maxAspectRatio = 1.0;

const int minArea = 80;

// constants for comparing two chars
const double MIN_DIAG_SIZE_MULTIPLE_AWAY = 0.3;
const double MAX_DIAG_SIZE_MULTIPLE_AWAY = 5.0;

const double MAX_CHANGE_IN_AREA = 0.5;

const double MAX_CHANGE_IN_WIDTH = 0.8;
const double MAX_CHANGE_IN_HEIGHT = 0.2;

const double MAX_ANGLE_BETWEEN_CHARS = 12.0;

// other constants
const int MIN_NUMBER_OF_MATCHING_CHARS = 3;

const int RESIZED_CHAR_IMAGE_WIDTH = 20;
const int RESIZED_CHAR_IMAGE_HEIGHT = 30;

const double PLATE_WIDTH_PADDING_FACTOR = 1.3;
const double PLATE_HEIGHT_PADDING_FACTOR = 1.5;

const int ADAPTIVE_THRESH_BLOCK_SIZE = 19;
const int ADAPTIVE_THRESH_WEIGHT = 9;


// external global variables //////////////////////////////////////////////////////////////////////
extern Ptr<ml::KNearest>  kNearest;
Ptr<ml::KNearest> kNearest = ml::KNearest::create();

//classes////////////////////////////////////////////
class PossibleChar {
public:
	// member variables ///////////////////////////////////////////////////////////////////////////
	vector<Point> contour;

	Rect boundingRect;

	int intCenterX;
	int intCenterY;

	double dblDiagonalSize;
	double dblAspectRatio;

	///////////////////////////////////////////////////////////////////////////////////////////////
	static bool sortCharsLeftToRight(const PossibleChar &pcLeft, const PossibleChar & pcRight) {
		return(pcLeft.intCenterX < pcRight.intCenterX);
	}

	///////////////////////////////////////////////////////////////////////////////////////////////
	bool operator == (const PossibleChar& otherPossibleChar) const {
		if (this->contour == otherPossibleChar.contour) return true;
		else return false;
	}

	///////////////////////////////////////////////////////////////////////////////////////////////
	bool operator != (const PossibleChar& otherPossibleChar) const {
		if (this->contour != otherPossibleChar.contour) return true;
		else return false;
	}

	// function prototypes ////////////////////////////////////////////////////////////////////////
	PossibleChar(vector<Point> _contour);



};

class PossiblePlate {
public:
	// member variables ///////////////////////////////////////////////////////////////////////////
	Mat imgPlate;
	Mat imgGrayscale;
	Mat imgThresh;

	RotatedRect rrLocationOfPlateInScene;

	string strChars;

	///////////////////////////////////////////////////////////////////////////////////////////////
	static bool sortDescendingByNumberOfChars(const PossiblePlate &ppLeft, const PossiblePlate &ppRight) {
		return(ppLeft.strChars.length() > ppRight.strChars.length());
	}

};

// Method declarations ////////////////////////////////////////////////////////////////////////////
//Declaring the methods allows them to be called
int recognition();

vector<vector<string>> getFilename(const fs::path& root);

void preprocess(Mat &imgOriginal, Mat &imgGrayscale, Mat &imgThresh);

Mat extractValue(Mat &imgOriginal);

Mat maximizeContrast(Mat &imgGrayscale);

bool loadKNNDataAndTrainKNN(void);

//Methods requiring the PossibleChar Class///////////////////////////////////////////////////////////////////////////////////////////////

vector<PossibleChar> findPossibleCharsInPlate(Mat &imgGrayscale, Mat &imgThresh);

bool checkCharSize(PossibleChar &possibleChar);

vector<vector<PossibleChar> > findVectorOfVectorsOfMatchingChars(const vector<PossibleChar> &vectorOfPossibleChars);

vector<PossibleChar> findVectorOfMatchingChars(const PossibleChar &possibleChar, const vector<PossibleChar> &vectorOfChars);

double distanceBetweenChars(const PossibleChar &firstChar, const PossibleChar &secondChar);

double angleBetweenChars(const PossibleChar &firstChar, const PossibleChar &secondChar);

vector<PossibleChar> removeInnerOverlappingChars(vector<PossibleChar> &vectorOfMatchingChars);

string recognizeCharsInPlate(Mat &imgThresh, vector<PossibleChar> &vectorOfMatchingChars);

vector<PossibleChar> findPossibleCharsInScene(Mat &imgThresh);


//Methods requiring the PossiblePlate Class////////////////////////////////////////////////////////////
vector<PossiblePlate> detectPlatesInScene(Mat &imgOriginalScene);

vector<PossiblePlate> detectCharsInPlates(vector<PossiblePlate> &vectorOfPossiblePlates);

PossiblePlate extractPlate(Mat &imgOriginal, vector<PossibleChar> &vectorOfMatchingChars);

# endif