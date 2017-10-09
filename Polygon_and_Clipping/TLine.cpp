#include "TLine.h"

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

TLine::TLine() { // Constructor for Line
	head = nullptr;
	tail = nullptr;
	lineNodeNum = 0;
	nextLine = nullptr;
}

TLine::TLine(TPoint ^forPointHead, TPoint ^forPointTail, int forLineNodeNum, TLine ^forLineNext) {
	head = forPointHead;
	tail = forPointTail;
	lineNodeNum = forLineNodeNum;
	nextLine = forLineNext;
}

void TLine::setLineNodeNum(int forLineNodeNum) {
	lineNodeNum = forLineNodeNum;
}

void TLine::setHead(TPoint^ forHead) {
	head = forHead;
}

void TLine::setTail(TPoint^ forTail) {
	tail = forTail;
}

void TLine::setNext(TLine^ forLineNext) {
	nextLine = forLineNext;
}

void TLine::setFirstPointLine(TPoint ^forPoint, int forLineNodeNum) {
	head = forPoint;
	lineNodeNum = forLineNodeNum;
}

int TLine::getLineNodeNum() {
	return lineNodeNum;
}

TLine::~TLine() { // Destructor
	
}