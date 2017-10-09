#include <iostream>
#include "TPoint.h"

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;

#ifndef TLINE_H
#define TLINE_H
ref class TLine {
	public:
		TLine();
		TLine(TPoint^, TPoint^, int, TLine^);
		void setLineNodeNum(int);
		void setFirstPointLine(TPoint^, int);
		void setHead(TPoint^);
		void setTail(TPoint^);
		void setNext(TLine^);
		int getLineNodeNum();
		~TLine();
	private:
		int lineNodeNum;
		TPoint ^head, ^tail;
		TLine ^nextLine;
};
#endif