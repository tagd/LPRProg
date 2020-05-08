#ifndef MY_MAIN         // used MY_MAIN for this include guard rather than MAIN just in case some compilers or environments #define MAIN already
#define MY_MAIN

///////////External librarys to include///////////////

//used in char training and correction training
#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/ml/ml.hpp>
#include <iostream>
#include <vector>

//used in main and correctionTraining and Recognition
#include <fstream>
#include <sstream>

///////////////////////////////////////////////////////////

using namespace std;//means "" is not needed for strings user in and out


//someType methodName(type name);
int training(bool u);
int recognition();

string getLine(int i);
string getImgPath();
string getFontPath();


void updateState(string s);


# endif