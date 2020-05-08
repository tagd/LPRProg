#include "Main.h"

//file selects startup mode and reads and writes files to communicate with c#
const string path = "G:\\Projects\\LPRProg\\v1.3\\vars.txt";//todo-setup change me

int main(void) //chooses mode of operation for the program
{
	string startupType = getLine(1);
	if (startupType == "rec") 
	{
		recognition();//using training data to find matches
	}
	else if (startupType == "coT") 
	{
		training(true);//updating current classifications file
	}
	else if (startupType == "chT") 
	{
		training(false);//Training with a new font
	}
	else 
	{
		updateState("Error importing variables");
		exit(1);
	}
	return 0;
}

string getLine(int lineNum)// used to get vars from a file written to by c#
						   //counts from line 1
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
		if (lineNum != 4) {//status line may be blank
			updateState("Error variables could not be imported please check path variables");//write success/fail at end of file
		}
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


void replaceLn(int lineNum, string text) {
	//can't overwrite a specific line in c++ so must re-write the whole file
	//reads in file
	string file[4];
	for (int i = 0; i < 4; i++) {
		file[i] = getLine(i);
	}

	//updates choosen line
	file[lineNum - 1] = text;

	//writes back to the file
	ofstream textfile;
	textfile.open(path);
	for (int i = 0; i < 4; i++) {
		textfile << file[i] << endl;
	}
	textfile.close();
}

void updateState(string message)
{
	replaceLn(4, message);
}