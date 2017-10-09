#include "TPoint.h"

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;

/** 
	Flaws:
		1. Insertion and deletion are not yet implemented
		2. Point and List can't be used inside myForm.h, the reason is still unknown
*/

TPoint::TPoint() { // Constructor
	x = 0;
	y = 0;
	pointNodeNum = -1;
	nextPoint = nullptr;
	pointColor = Color::Black;
}

TPoint::TPoint(int forX, int forY, int nodeNum, TPoint ^forNext, Color forColor) { // Overload Constructor
	x = x;
	y = y;
	pointNodeNum = nodeNum;
	nextPoint = forNext;
	pointColor = forColor;
}

void TPoint::setPoint(int a, int b, Color color) {
	x = a;
	y = b;
	pointColor = color;
}

void TPoint::setNodeNum(int a) { // Increased everytime the mouse is clicked
	pointNodeNum = a;
}

void TPoint::setColor(Color forColor) {
	pointColor = forColor;
}

int TPoint::getX() {
	return x;
}

int TPoint::getY() {
	return y;
}

int TPoint::getNodeNum() {
	return pointNodeNum;
}

Color TPoint::getColor() {
	return pointColor;
}

TPoint::~TPoint() { // Destructor. WHAT SHOULD BE WRITTEN HERE?????
	
}