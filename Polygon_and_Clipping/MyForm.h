#include "TPoint.h"
#include "TLine.h"
#define WM_LBUTTONDOWN 0x0201
#define WM_LBUTTONUP 0x0202
#define WM_RBUTTONDOWN 0x0204
#define WM_RBUTTONUP 0x0205
#define WM_MBUTTONDOWN 0x0207
#define WM_MBUTTONUP 0x0208
#define WM_XBUTTONDOWN 0x020B
#define WM_XBUTTONUP 0x020C

#pragma once

namespace Polygond_And_Clipping {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();

			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::PictureBox^  mainCanvas;
	private: System::Drawing::Bitmap^ bitmapCanvas;
	private: System::Windows::Forms::Button^  PasteButton;
	private: System::Windows::Forms::Button^  CutButton;
	private: System::Windows::Forms::Button^  CopyButton;
	private: System::Windows::Forms::Label^  X_CoordinatesLabel;


	private: System::Windows::Forms::Label^  CoordinatesTitleLabel;
	private: System::Drawing::Pen^ myPen;
	private: System::Drawing::Graphics^ myGraphics;
	private: System::Windows::Forms::Label^  Y_CoordinatesLabel;

	protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(MyForm::typeid));
			this->mainCanvas = (gcnew System::Windows::Forms::PictureBox());
			this->bitmapCanvas = (gcnew System::Drawing::Bitmap("E:\\CGA\\Assignments\\Polygond_And_Clipping\\White_Background_2.jpg"));
			this->PasteButton = (gcnew System::Windows::Forms::Button());
			this->CutButton = (gcnew System::Windows::Forms::Button());
			this->CopyButton = (gcnew System::Windows::Forms::Button());
			this->X_CoordinatesLabel = (gcnew System::Windows::Forms::Label());
			this->CoordinatesTitleLabel = (gcnew System::Windows::Forms::Label());
			this->Y_CoordinatesLabel = (gcnew System::Windows::Forms::Label());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->mainCanvas))->BeginInit();
			this->SuspendLayout();
			// 
			// mainCanvas
			// 
			this->mainCanvas->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"mainCanvas.Image")));
			this->mainCanvas->Location = System::Drawing::Point(13, 13);
			this->mainCanvas->Name = L"mainCanvas";
			this->mainCanvas->Size = System::Drawing::Size(652, 511);
			this->mainCanvas->TabIndex = 0;
			this->mainCanvas->TabStop = false;
			this->mainCanvas->Image = bitmapCanvas;
			this->mainCanvas->MouseMove += gcnew System::Windows::Forms::MouseEventHandler(this, &MyForm::OnMouseMove);
			// 
			// PasteButton
			// 
			this->PasteButton->Location = System::Drawing::Point(854, 496);
			this->PasteButton->Name = L"PasteButton";
			this->PasteButton->Size = System::Drawing::Size(75, 23);
			this->PasteButton->TabIndex = 1;
			this->PasteButton->Text = L"Paste";
			this->PasteButton->UseVisualStyleBackColor = true;
			// 
			// CutButton
			// 
			this->CutButton->Location = System::Drawing::Point(773, 496);
			this->CutButton->Name = L"CutButton";
			this->CutButton->Size = System::Drawing::Size(75, 23);
			this->CutButton->TabIndex = 2;
			this->CutButton->Text = L"Cut";
			this->CutButton->UseVisualStyleBackColor = true;
			// 
			// CopyButton
			// 
			this->CopyButton->Location = System::Drawing::Point(692, 496);
			this->CopyButton->Name = L"CopyButton";
			this->CopyButton->Size = System::Drawing::Size(75, 23);
			this->CopyButton->TabIndex = 3;
			this->CopyButton->Text = L"Copy";
			this->CopyButton->UseVisualStyleBackColor = true;
			this->CopyButton->Click += gcnew System::EventHandler(this, &MyForm::CopyButton_Click);
			// 
			// X_CoordinatesLabel
			// 
			this->X_CoordinatesLabel->AutoSize = true;
			this->X_CoordinatesLabel->Location = System::Drawing::Point(689, 42);
			this->X_CoordinatesLabel->MinimumSize = System::Drawing::Size(100, 20);
			this->X_CoordinatesLabel->Name = L"X_CoordinatesLabel";
			this->X_CoordinatesLabel->Size = System::Drawing::Size(100, 20);
			this->X_CoordinatesLabel->TabIndex = 4;
			this->X_CoordinatesLabel->Text = L"0.0";
			this->X_CoordinatesLabel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// CoordinatesTitleLabel
			// 
			this->CoordinatesTitleLabel->AutoSize = true;
			this->CoordinatesTitleLabel->Location = System::Drawing::Point(707, 29);
			this->CoordinatesTitleLabel->Name = L"CoordinatesTitleLabel";
			this->CoordinatesTitleLabel->Size = System::Drawing::Size(91, 13);
			this->CoordinatesTitleLabel->TabIndex = 5;
			this->CoordinatesTitleLabel->Text = L"Coordinates (x, y):";
			this->CoordinatesTitleLabel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// Y_CoordinatesLabel
			// 
			this->Y_CoordinatesLabel->AutoSize = true;
			this->Y_CoordinatesLabel->Location = System::Drawing::Point(689, 62);
			this->Y_CoordinatesLabel->MinimumSize = System::Drawing::Size(100, 20);
			this->Y_CoordinatesLabel->Name = L"Y_CoordinatesLabel";
			this->Y_CoordinatesLabel->Size = System::Drawing::Size(100, 20);
			this->Y_CoordinatesLabel->TabIndex = 6;
			this->Y_CoordinatesLabel->Text = L"0.0";
			this->Y_CoordinatesLabel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(941, 531);
			this->Controls->Add(this->Y_CoordinatesLabel);
			this->Controls->Add(this->CoordinatesTitleLabel);
			this->Controls->Add(this->X_CoordinatesLabel);
			this->Controls->Add(this->CopyButton);
			this->Controls->Add(this->CutButton);
			this->Controls->Add(this->PasteButton);
			this->Controls->Add(this->mainCanvas);
			this->Name = L"MyForm";
			this->Text = L"CGA Project Prototype";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->mainCanvas))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion	 
		
private: System::Void OnMouseMove(System::Object^ sender, MouseEventArgs^ e) { // Capture the mouse when inside the canvas
	//MessageBox::Show("Test Mouse Hover");
	/*int x, y, delta, clicks;
	System::Windows::Forms::MouseButtons mouseButtonLeft = System::Windows::Forms::MouseButtons::Left;
	System::Windows::Forms::MouseButtons mouseButtonRight = System::Windows::Forms::MouseButtons::Right;*/

	//MouseEventArgs ^ms = (MouseEventArgs^)e;
	//int x = ms->X, y = ms->Y;

	//if (WM_LBUTTONDOWN) {
	//	MessageBox::Show("Left mouse button is clicked");
	//}
	//else if (WM_RBUTTONDOWN) {
	//	MessageBox::Show("Right mouse button is clicked");
	//}

	/*MouseEventArgs^ mouseEventLeft = (gcnew System::Windows::Forms::MouseEventArgs(mouseButtonLeft, clicks, x, y, delta));
	MouseEventArgs^ mouseEventRight = (gcnew System::Windows::Forms::MouseEventArgs(mouseButtonRight, clicks, x, y, delta));
	if (mouseButtonLeft) {
		MessageBox::Show("Left mouse button is clicked");
	}
	else if(mouseButtonRight.ToBoolean()){
		MessageBox::Show("Right mouse button is clicked");
	}*/
	//System::Drawing::Point^ points = System::Windows::Forms::Control::MousePosition;
	TPoint^ points = gcnew TPoint;
	TLine^ lines = gcnew TLine;
	points->setPoint(e->X, e->Y, System::Drawing::Color::Black);
	this->X_CoordinatesLabel->Text = points->getX().ToString();
	this->Y_CoordinatesLabel->Text = points->getY().ToString();
	if (e->Button == System::Windows::Forms::MouseButtons::Left) {
		MessageBox::Show("Left mouse button is clicked once");
	}
	else if (e->Button == System::Windows::Forms::MouseButtons::Right) {
		MessageBox::Show("Right mouse button is clicked once");
	}
}

private: System::Void CopyButton_Click(System::Object^  sender, System::EventArgs^  e) {
	MessageBox::Show("Copy button");
}
};
}
