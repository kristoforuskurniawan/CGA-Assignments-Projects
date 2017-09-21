#include "MyForm.h"

using namespace System;
using namespace System::Windows::Forms;

[STAThread]

int main() {
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	Assignment_2_Draw_Line::MyForm form;
	Application::Run(%form);
	return 0;
}
