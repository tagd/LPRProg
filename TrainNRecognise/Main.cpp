#include "Main.h"

const string path = "G:\\LPRProg\\v1.2\\vars.txt";//todo change me

int main(void) 
{
	//getStartupVars(path);
	string startupType = getLine(1);//file not being read
	cout << startupType;
	//todo startup program chosen by startup type
	if (startupType == "rec") 
	{
		recognition();
	}
	else if (startupType == "coT") 
	{
		correctionTraining();
	}
	else if (startupType == "chT") 
	{
		charTraining();
	}
	else 
	{
		updateState("Error importing variables");
		cout << "Error";
		system("pause");
		exit(0);
	}
	return 0;
}

string getLine(int lineNum)//counts from line 1
{
	string returnedLn;
	ifstream file(path);
	try 
	{
		for (int i = 0; i < lineNum; i++)
		{
			getline(file, returnedLn);
		}
	}
	catch (...) 
	{
		updateState("Error variables could not be imported please check path variables");//write success/fail at end of file
	}
	file.close();
	return returnedLn;
}

string getImgPath() 
{
	return getLine(2);
}

string getFontPath() 
{
	return getLine(3);
}


void writeLn(int lineNum, string text) {
	//todo
}

/*			ofstream textfile;
            textfile.open("vars.txt");
            textfile << launchType << endl;
            textfile << Properties.Settings.Default.CPPImgPath << endl;
            textfile << Properties.Settings.Default.CPPFontPath << endl;
            textfile.close();*/

void updateState(string message)
{
	writeLn(4, message);
}

/*
static void getStartupVars(string path)
{//could do any number of ways so method for later improvement
	ifstream file(path);
	try {
		getline(file, startupType);
		getline(file, imgPath);
		getline(file, fontPath);
	}
	catch (...) {
		updateState(path,"Error variables could not be imported please check path variables");//write success/fail at end of file
	}
	file.close();
}
*/

