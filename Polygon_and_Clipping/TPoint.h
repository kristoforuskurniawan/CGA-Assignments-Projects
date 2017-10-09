#include <iostream>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;

#ifndef TPOINT_H
#define TPOINT_H
ref class TPoint{
	public:
		TPoint(); // Constructor 1
		TPoint(int, int, int, TPoint^, Color); // Overload constructor
		~TPoint();
		void setPoint(int, int, Color);
		void setNodeNum(int);
		void setColor(Color);
		int getX();
		int getY();
		int getNodeNum();
		Color getColor();
	private:
		int x, y, pointNodeNum;
		TPoint ^nextPoint;
		Color pointColor;
};
#endif
