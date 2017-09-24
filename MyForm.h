#include <cmath>
#pragma once

namespace Assignment_2_Draw_Line {

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
		MyForm() // Constructor
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
		~MyForm() // Destructor
		{
			if (components)
			{
				delete components;
			}
		}

	protected:

	private: System::Windows::Forms::Button^  DrawLineButton;
	private: System::Windows::Forms::Button^  RectangleButton;
	private: System::Windows::Forms::Button^  ClearButton;
	private: System::Windows::Forms::TextBox^  X1_textBox;
	private: System::Windows::Forms::Label^  X1_Label;
	private: System::Windows::Forms::Label^  Y1_Label;



	private: System::Windows::Forms::TextBox^  Y1_textBox;
	private: System::Windows::Forms::Label^  X2_Label;
	private: System::Windows::Forms::TextBox^  X2_textBox;
	private: System::Windows::Forms::Label^  Y2_Label;
	private: System::Windows::Forms::TextBox^  Y2_textBox;
	public: System::Windows::Forms::PictureBox^  mainCanvas;
	private:

	private: System::Windows::Forms::Label^  algorithmLabel;

	private: System::Drawing::Bitmap^ bitmapCanvas;
	private: System::Drawing::Graphics^ myGraphics;
	private: System::Windows::Forms::ComboBox^  algorithmChoices;
	private: System::Windows::Forms::Button^  exitButton;
	private: System::Windows::Forms::Button^  circleButton;
	private: System::Windows::Forms::Label^  circleAlgorithmLabel;
	private: System::Windows::Forms::ComboBox^  circleAlgorithmChoices;
	private: System::Windows::Forms::Label^  InputDetailLabel_2;
	private: System::Windows::Forms::Label^  InputDetailLabel_1;
	private: System::Windows::Forms::Label^  xCenterLabel;
	private: System::Windows::Forms::Label^  yCenterLabel;
	private: System::Windows::Forms::TextBox^  xC_textBox;
	private: System::Windows::Forms::TextBox^  yC_TextBox;
	private: System::Windows::Forms::Label^  RadiusLabel;
	private: System::Windows::Forms::TextBox^  Radius_textBox;

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
		void InitializeComponent()
		{	
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(MyForm::typeid));
			this->DrawLineButton = (gcnew System::Windows::Forms::Button());
			this->RectangleButton = (gcnew System::Windows::Forms::Button());
			this->ClearButton = (gcnew System::Windows::Forms::Button());
			this->X1_textBox = (gcnew System::Windows::Forms::TextBox());
			this->X1_Label = (gcnew System::Windows::Forms::Label());
			this->Y1_Label = (gcnew System::Windows::Forms::Label());
			this->Y1_textBox = (gcnew System::Windows::Forms::TextBox());
			this->X2_Label = (gcnew System::Windows::Forms::Label());
			this->X2_textBox = (gcnew System::Windows::Forms::TextBox());
			this->Y2_Label = (gcnew System::Windows::Forms::Label());
			this->Y2_textBox = (gcnew System::Windows::Forms::TextBox());
			this->bitmapCanvas = (gcnew System::Drawing::Bitmap("E:\\CGA\\Assignments\\Assignment 2 - Drawing Line Algorigthm (C++)\\White_Background.jpg"));
			this->mainCanvas = (gcnew System::Windows::Forms::PictureBox());
			this->algorithmLabel = (gcnew System::Windows::Forms::Label());
			this->algorithmChoices = (gcnew System::Windows::Forms::ComboBox());
			this->exitButton = (gcnew System::Windows::Forms::Button());
			this->circleButton = (gcnew System::Windows::Forms::Button());
			this->circleAlgorithmLabel = (gcnew System::Windows::Forms::Label());
			this->circleAlgorithmChoices = (gcnew System::Windows::Forms::ComboBox());
			this->InputDetailLabel_2 = (gcnew System::Windows::Forms::Label());
			this->InputDetailLabel_1 = (gcnew System::Windows::Forms::Label());
			this->xCenterLabel = (gcnew System::Windows::Forms::Label());
			this->yCenterLabel = (gcnew System::Windows::Forms::Label());
			this->xC_textBox = (gcnew System::Windows::Forms::TextBox());
			this->yC_TextBox = (gcnew System::Windows::Forms::TextBox());
			this->RadiusLabel = (gcnew System::Windows::Forms::Label());
			this->Radius_textBox = (gcnew System::Windows::Forms::TextBox());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->mainCanvas))->BeginInit();
			this->SuspendLayout();
			// 
			// DrawLineButton
			// 
			this->DrawLineButton->Location = System::Drawing::Point(12, 375);
			this->DrawLineButton->Name = L"DrawLineButton";
			this->DrawLineButton->Size = System::Drawing::Size(75, 23);
			this->DrawLineButton->TabIndex = 1;
			this->DrawLineButton->Text = L"Draw Line";
			this->DrawLineButton->UseVisualStyleBackColor = true;
			this->DrawLineButton->Click += gcnew System::EventHandler(this, &MyForm::DrawLineButton_Click);
			// 
			// RectangleButton
			// 
			this->RectangleButton->Location = System::Drawing::Point(103, 375);
			this->RectangleButton->Name = L"RectangleButton";
			this->RectangleButton->Size = System::Drawing::Size(75, 23);
			this->RectangleButton->TabIndex = 2;
			this->RectangleButton->Text = L"Rectangle";
			this->RectangleButton->UseVisualStyleBackColor = true;
			this->RectangleButton->Click += gcnew System::EventHandler(this, &MyForm::RectangleButton_Click);
			// 
			// ClearButton
			// 
			this->ClearButton->Location = System::Drawing::Point(287, 375);
			this->ClearButton->Name = L"ClearButton";
			this->ClearButton->Size = System::Drawing::Size(75, 23);
			this->ClearButton->TabIndex = 3;
			this->ClearButton->Text = L"Clear";
			this->ClearButton->UseVisualStyleBackColor = true;
			this->ClearButton->Click += gcnew System::EventHandler(this, &MyForm::ClearButton_Click);
			// 
			// X1_textBox
			// 
			this->X1_textBox->Location = System::Drawing::Point(464, 42);
			this->X1_textBox->Name = L"X1_textBox";
			this->X1_textBox->Size = System::Drawing::Size(148, 20);
			this->X1_textBox->TabIndex = 4;
			this->X1_textBox->TextAlign = System::Windows::Forms::HorizontalAlignment::Center;
			// 
			// X1_Label
			// 
			this->X1_Label->AutoSize = true;
			this->X1_Label->Location = System::Drawing::Point(384, 45);
			this->X1_Label->Name = L"X1_Label";
			this->X1_Label->Size = System::Drawing::Size(74, 13);
			this->X1_Label->TabIndex = 5;
			this->X1_Label->Text = L"X1 Coordinate";
			this->X1_Label->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// Y1_Label
			// 
			this->Y1_Label->AutoSize = true;
			this->Y1_Label->Location = System::Drawing::Point(384, 78);
			this->Y1_Label->Name = L"Y1_Label";
			this->Y1_Label->Size = System::Drawing::Size(74, 13);
			this->Y1_Label->TabIndex = 6;
			this->Y1_Label->Text = L"Y1 Coordinate";
			this->Y1_Label->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// Y1_textBox
			// 
			this->Y1_textBox->Location = System::Drawing::Point(464, 75);
			this->Y1_textBox->Name = L"Y1_textBox";
			this->Y1_textBox->Size = System::Drawing::Size(148, 20);
			this->Y1_textBox->TabIndex = 7;
			this->Y1_textBox->TextAlign = System::Windows::Forms::HorizontalAlignment::Center;
			// 
			// X2_Label
			// 
			this->X2_Label->AutoSize = true;
			this->X2_Label->Location = System::Drawing::Point(384, 112);
			this->X2_Label->Name = L"X2_Label";
			this->X2_Label->Size = System::Drawing::Size(74, 13);
			this->X2_Label->TabIndex = 8;
			this->X2_Label->Text = L"X2 Coordinate";
			this->X2_Label->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// X2_textBox
			// 
			this->X2_textBox->Location = System::Drawing::Point(464, 109);
			this->X2_textBox->Name = L"X2_textBox";
			this->X2_textBox->Size = System::Drawing::Size(148, 20);
			this->X2_textBox->TabIndex = 9;
			this->X2_textBox->TextAlign = System::Windows::Forms::HorizontalAlignment::Center;
			// 
			// Y2_Label
			// 
			this->Y2_Label->AutoSize = true;
			this->Y2_Label->Location = System::Drawing::Point(384, 145);
			this->Y2_Label->Name = L"Y2_Label";
			this->Y2_Label->Size = System::Drawing::Size(74, 13);
			this->Y2_Label->TabIndex = 10;
			this->Y2_Label->Text = L"Y2 Coordinate";
			this->Y2_Label->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// Y2_textBox
			// 
			this->Y2_textBox->Location = System::Drawing::Point(464, 142);
			this->Y2_textBox->Name = L"Y2_textBox";
			this->Y2_textBox->Size = System::Drawing::Size(148, 20);
			this->Y2_textBox->TabIndex = 11;
			this->Y2_textBox->TextAlign = System::Windows::Forms::HorizontalAlignment::Center;
			// 
			// mainCanvas
			// 
			this->mainCanvas->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"mainCanvas.Image")));
			this->mainCanvas->Location = System::Drawing::Point(12, 12);
			this->mainCanvas->Name = L"mainCanvas";
			this->mainCanvas->Size = System::Drawing::Size(350, 350);
			this->mainCanvas->TabIndex = 12;
			this->mainCanvas->TabStop = false;
			// 
			// algorithmLabel
			// 
			this->algorithmLabel->AutoSize = true;
			this->algorithmLabel->Location = System::Drawing::Point(384, 185);
			this->algorithmLabel->Name = L"algorithmLabel";
			this->algorithmLabel->Size = System::Drawing::Size(73, 13);
			this->algorithmLabel->TabIndex = 13;
			this->algorithmLabel->Text = L"Line Algorithm";
			this->algorithmLabel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// algorithmChoices
			// 
			this->algorithmChoices->FormattingEnabled = true;
			this->algorithmChoices->Items->AddRange(gcnew cli::array< System::Object^  >(4) { L"----", L"Line Drawing", L"DDA", L"Mid Point" });
			this->algorithmChoices->Location = System::Drawing::Point(464, 182);
			this->algorithmChoices->Name = L"algorithmChoices";
			this->algorithmChoices->Size = System::Drawing::Size(148, 21);
			this->algorithmChoices->TabIndex = 14;
			this->algorithmChoices->SelectedIndex = 0;
			// 
			// exitButton
			// 
			this->exitButton->Location = System::Drawing::Point(536, 375);
			this->exitButton->Name = L"exitButton";
			this->exitButton->Size = System::Drawing::Size(75, 23);
			this->exitButton->TabIndex = 15;
			this->exitButton->Text = L"Exit";
			this->exitButton->UseVisualStyleBackColor = true;
			this->exitButton->Click += gcnew System::EventHandler(this, &MyForm::exitButton_Click);
			// 
			// circleButton
			// 
			this->circleButton->Location = System::Drawing::Point(195, 375);
			this->circleButton->Name = L"circleButton";
			this->circleButton->Size = System::Drawing::Size(75, 23);
			this->circleButton->TabIndex = 16;
			this->circleButton->Text = L"Circle";
			this->circleButton->UseVisualStyleBackColor = true;
			this->circleButton->Click += gcnew System::EventHandler(this, &MyForm::circleButton_Click);
			// 
			// circleAlgorithmLabel
			// 
			this->circleAlgorithmLabel->AutoSize = true;
			this->circleAlgorithmLabel->Location = System::Drawing::Point(384, 256);
			this->circleAlgorithmLabel->Name = L"circleAlgorithmLabel";
			this->circleAlgorithmLabel->Size = System::Drawing::Size(50, 13);
			this->circleAlgorithmLabel->TabIndex = 17;
			this->circleAlgorithmLabel->Text = L"Algorithm";
			this->circleAlgorithmLabel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// circleAlgorithmChoices
			// 
			this->circleAlgorithmChoices->FormattingEnabled = true;
			this->circleAlgorithmChoices->Items->AddRange(gcnew cli::array< System::Object^  >(3) { L"----", L"Midpoint Circle", L"Second Order" });
			this->circleAlgorithmChoices->Location = System::Drawing::Point(463, 253);
			this->circleAlgorithmChoices->Name = L"circleAlgorithmChoices";
			this->circleAlgorithmChoices->Size = System::Drawing::Size(148, 21);
			this->circleAlgorithmChoices->TabIndex = 18;
			this->circleAlgorithmChoices->SelectedIndex = 0;
			// 
			// InputDetailLabel_2
			// 
			this->InputDetailLabel_2->AutoSize = true;
			this->InputDetailLabel_2->Location = System::Drawing::Point(431, 226);
			this->InputDetailLabel_2->Name = L"InputDetailLabel_2";
			this->InputDetailLabel_2->Size = System::Drawing::Size(113, 13);
			this->InputDetailLabel_2->TabIndex = 19;
			this->InputDetailLabel_2->Text = L"Special Input for Circle";
			this->InputDetailLabel_2->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// InputDetailLabel_1
			// 
			this->InputDetailLabel_1->AutoSize = true;
			this->InputDetailLabel_1->Location = System::Drawing::Point(416, 12);
			this->InputDetailLabel_1->Name = L"InputDetailLabel_1";
			this->InputDetailLabel_1->Size = System::Drawing::Size(142, 13);
			this->InputDetailLabel_1->TabIndex = 20;
			this->InputDetailLabel_1->Text = L"Input for Line and Rectangle";
			this->InputDetailLabel_1->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// xCenterLabel
			// 
			this->xCenterLabel->AutoSize = true;
			this->xCenterLabel->Location = System::Drawing::Point(384, 289);
			this->xCenterLabel->Name = L"xCenterLabel";
			this->xCenterLabel->Size = System::Drawing::Size(48, 13);
			this->xCenterLabel->TabIndex = 21;
			this->xCenterLabel->Text = L"X Center";
			// 
			// yCenterLabel
			// 
			this->yCenterLabel->AutoSize = true;
			this->yCenterLabel->Location = System::Drawing::Point(384, 320);
			this->yCenterLabel->Name = L"yCenterLabel";
			this->yCenterLabel->Size = System::Drawing::Size(48, 13);
			this->yCenterLabel->TabIndex = 22;
			this->yCenterLabel->Text = L"Y Center";
			// 
			// xC_textBox
			// 
			this->xC_textBox->Location = System::Drawing::Point(463, 286);
			this->xC_textBox->Name = L"xC_textBox";
			this->xC_textBox->Size = System::Drawing::Size(148, 20);
			this->xC_textBox->TabIndex = 23;
			// 
			// yC_TextBox
			// 
			this->yC_TextBox->Location = System::Drawing::Point(463, 317);
			this->yC_TextBox->Name = L"yC_TextBox";
			this->yC_TextBox->Size = System::Drawing::Size(148, 20);
			this->yC_TextBox->TabIndex = 24;
			// 
			// RadiusLabel
			// 
			this->RadiusLabel->AutoSize = true;
			this->RadiusLabel->Location = System::Drawing::Point(384, 349);
			this->RadiusLabel->Name = L"RadiusLabel";
			this->RadiusLabel->Size = System::Drawing::Size(40, 13);
			this->RadiusLabel->TabIndex = 25;
			this->RadiusLabel->Text = L"Radius";
			this->RadiusLabel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// Radius_textBox
			// 
			this->Radius_textBox->Location = System::Drawing::Point(462, 346);
			this->Radius_textBox->Name = L"Radius_textBox";
			this->Radius_textBox->Size = System::Drawing::Size(149, 20);
			this->Radius_textBox->TabIndex = 26;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(624, 416);
			this->Controls->Add(this->Radius_textBox);
			this->Controls->Add(this->RadiusLabel);
			this->Controls->Add(this->yC_TextBox);
			this->Controls->Add(this->xC_textBox);
			this->Controls->Add(this->yCenterLabel);
			this->Controls->Add(this->xCenterLabel);
			this->Controls->Add(this->InputDetailLabel_1);
			this->Controls->Add(this->InputDetailLabel_2);
			this->Controls->Add(this->circleAlgorithmChoices);
			this->Controls->Add(this->circleAlgorithmLabel);
			this->Controls->Add(this->circleButton);
			this->Controls->Add(this->exitButton);
			this->Controls->Add(this->algorithmChoices);
			this->Controls->Add(this->algorithmLabel);
			this->Controls->Add(this->mainCanvas);
			this->Controls->Add(this->Y2_textBox);
			this->Controls->Add(this->Y2_Label);
			this->Controls->Add(this->X2_textBox);
			this->Controls->Add(this->X2_Label);
			this->Controls->Add(this->Y1_textBox);
			this->Controls->Add(this->Y1_Label);
			this->Controls->Add(this->X1_Label);
			this->Controls->Add(this->X1_textBox);
			this->Controls->Add(this->ClearButton);
			this->Controls->Add(this->RectangleButton);
			this->Controls->Add(this->DrawLineButton);
			this->Name = L"MyForm";
			this->Text = L"Drawing on Pixels with Various Algorithms";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->mainCanvas))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}

#pragma endregion

private: System::Void DrawLineButton_Click(System::Object^  sender, System::EventArgs^  e) { // What happens when you click DrawLneButton
	if (this->X1_textBox->Text != "" && this->Y1_textBox->Text != "" && this->X2_textBox->Text != "" && this->Y2_textBox->Text != "")  // No empty input
	{
		__int16 x1 = System::Int16::Parse(this->X1_textBox->Text); // Convert the String ^fromTextBox object into a 16 bits int (I use 16 bits due to input size)
		__int16 y1 = System::Int16::Parse(this->Y1_textBox->Text);
		__int16 x2 = System::Int16::Parse(this->X2_textBox->Text);
		__int16 y2 = System::Int16::Parse(this->Y2_textBox->Text);

		switch (this->algorithmChoices->SelectedIndex) // Make sure the algorithm choice is correct
		{
		case 1:
			//Line Drawing Algorithm goes here;
			if (x2 <= 346 && y2 <= 346) 
			{
				if (x2 >= x1 && y2 >= y1) // Correct
				{
					float m = (y2 - y1) / (x2 - x1), C = y1 - m * x1, y;
					for (x1; x1 <= x2; x1++) 
					{
						y = m * x1 + C;
						this->bitmapCanvas->SetPixel(x1, Math::Round(y), System::Drawing::Color::Black);
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				else if (x2 <= x1 && y2 >= y1) // Correct
				{
					float m = (y2 - y1) / (x2 - x1), C = y1 - m * x1, y;
					for (x1; x1 >= x2; x1--) 
					{
						y = m * x1 + C;
						this->bitmapCanvas->SetPixel(x1, Math::Round(y), System::Drawing::Color::Black);
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				else if (x2 >= x1 && y2 <= y1) // Correct
				{
					float m = (y2 - y1) / (x2 - x1), C = y2 - m * x1, y;
					for (x1; x1 <= x2; x1++)
					{
						y = m * x1 + C;
						this->bitmapCanvas->SetPixel(x1, Math::Round(y), System::Drawing::Color::Black);
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				else if (x2 <= x1 && y2 <= y1) // Correct
				{
					float m = (y2 - y1) / (x2 - x1), C = y2 - m * x1, y;
					for (x1; x1 >= x2; x1--)
					{
						y = m * x1 + C;
						this->bitmapCanvas->SetPixel(x1, Math::Round(y), System::Drawing::Color::Black);
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				else 
				{
					MessageBox::Show("Please insert the proper value for each coordinate!");
				}
			}
			else
			{
				MessageBox::Show("The maximum x2 and y2 coordinates point is 346px!");
			}
			break;
		case 2:
			//DDA goes here;
			if (x2 <= 346 && y2 <= 346) 
			{
				if (x2 >= x1 && y2 >= y1) // Correct
				{
					float m = (y2 - y1) / (x2 - x1);
					while(x1 <= x2) 
					{
						this->bitmapCanvas->SetPixel(x1, Math::Round(y1), System::Drawing::Color::Black);
						x1++;
						y1 += m;
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				else if (x2 <= x1 && y2 >= y1) // Correct
				{
					float m = (y2 - y1) / (x1 - x2);
					while (x1 >= x2)
					{
						this->bitmapCanvas->SetPixel(x1, Math::Round(y1), System::Drawing::Color::Black);
						x1--;
						y1 += m;
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				else if (x2 >= x1 && y2 <= y1) // Correct
				{
					float m = (y2 - y1) / (x2 - x1);
					while (x1 <= x2)
					{
						this->bitmapCanvas->SetPixel(x1, Math::Round(y1), System::Drawing::Color::Black);
						x1++;
						y1 += m;
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				else if (x2 <= x1 && y2 <= y1) // Correct
				{
					float m = (y2 - y1) / (x2 - x1);
					while (x1 >= x2)
					{
						this->bitmapCanvas->SetPixel(x1, Math::Round(y1), System::Drawing::Color::Black);
						x1--;
						y1 -= m;
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				else 
				{
					MessageBox::Show("Line Drawing Algorithm only accepts x2 >= x1 AND y2 >= y1");
				}
			}
			else 
			{
				MessageBox::Show("The maximum x2 and y2 coordinates point is 346px!");
			}
			break;
		case 3:
			//Midpoint goes here;
			if (x2 <= 346 && y2 <= 346) 
			{
				if (x2 >= x1 && y2 >= y1) // Correct
				{
					int dx = x2 - x1, dy = y2 - y1, dR = 2 * dy, dUR = 2 * (dy - dx), d = 2 * dy - dx;
					while (x1 < x2)
					{
						this->bitmapCanvas->SetPixel(x1, y1, System::Drawing::Color::Black);
						x1++;
						if (d < 0) 
						{
							d += dR;
						}
						else 
						{
							d += dUR;
							y1++;
						}
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				else if (x2 <= x1 && y2 >= y1) // Correct
				{
					int dx = x2 - x1, dy = y2 - y1, dR = 2 * dy, dUR = 2 * (dy - dx), d = 2 * dy - dx;
					while (x1 >= x2) 
					{
						this->bitmapCanvas->SetPixel(x1, y1, System::Drawing::Color::Black);
						x1--;
						if (d <= 0)
						{
							d += dR;
						}
						else
						{
							d += dUR;
							y1++;
						}
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				else if (x2 >= x1 && y2 <= y1) // Check this and other 2 algorithms...
				{
					int dx = x2 - x1, dy = y2 - y1, dR = 2 * dy, dUR = 2 * (dy - dx), d = 2 * dy - dx;
					while (x1 <= x2) 
					{
						this->bitmapCanvas->SetPixel(x1, y1, System::Drawing::Color::Black);
						x1++;
						if (d <= 0)
						{
							d += dR;
							y1--;
						}
						else
						{
							d += dUR;
							//y1++;
						}
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				else if (x2 <= x1 && y2 <= y1) // Correct
				{
					int dx = x2 - x1, dy = y2 - y1, dR = 2 * dy, dUR = 2 * (dy - dx), d = 2 * dy - dx;
					while (x1 >= x2)
					{
						this->bitmapCanvas->SetPixel(x1, y1, System::Drawing::Color::Black);
						x1--;
						if (d <= 0)
						{
							d += dR;
							y1--;
						}
						else
						{
							d += dUR;
							//y1++;
						}
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				else 
				{
					MessageBox::Show("Line Drawing Algorithm only accepts x2 >= x1 AND y2 >= y1");
				}
			}
			else 
			{
				MessageBox::Show("The maximum x2 and y2 coordinates point is 346px!");
			}
			break;
		default:
			MessageBox::Show("Please select the corect algorithm method!");
			break;
		}
	}
	else 
	{
		MessageBox::Show("Please give a proper value for all input!");
	}
}
private: System::Void circleButton_Click(System::Object^  sender, System::EventArgs^  e)
{
	if (this->xC_textBox->Text != "" && this->yC_TextBox->Text != "" && this->circleAlgorithmChoices->SelectedIndex != 0 && this->Radius_textBox->Text != "") {
		__int16 xC = System::Int16::Parse(this->xC_textBox->Text);
		__int16 yC = System::Int16::Parse(this->yC_TextBox->Text);
		__int16 r = System::Int16::Parse(this->Radius_textBox->Text);

		switch (this->circleAlgorithmChoices->SelectedIndex)
		{
		case 0:
			MessageBox::Show("Please select the proper algorithm.");
		case 1:
			// Midpoint goes here
			if ((xC == 0 && yC == 0) || xC == 0 || yC == 0) 
			{
				MessageBox::Show("The X Center or Y Center are zero, cannot draw a full circle!");
			}
			else 
			{
				int d = 1 - r, x = 0, y = r;
				try {
					while(x < y)
					{
						this->bitmapCanvas->SetPixel(x + xC, y + yC, System::Drawing::Color::Black);
						this->bitmapCanvas->SetPixel(y + yC, x + xC, System::Drawing::Color::Black);
						this->bitmapCanvas->SetPixel(y+yC, xC-x, System::Drawing::Color::Black);
						this->bitmapCanvas->SetPixel(x+xC, yC-y, System::Drawing::Color::Black);
						this->bitmapCanvas->SetPixel(xC-x, yC-y, System::Drawing::Color::Black);
						this->bitmapCanvas->SetPixel(yC-y, xC-x, System::Drawing::Color::Black);
						this->bitmapCanvas->SetPixel(yC-y, x+xC, System::Drawing::Color::Black);
						this->bitmapCanvas->SetPixel(xC-x, y+yC, System::Drawing::Color::Black);
						if (d < 0) {
							d = d + 2 * x + 3;
						}
						else
						{
							d = d + 2 * (x - y) + 5;
							y--;
						}
						x++;
					}
					this->mainCanvas->Image = bitmapCanvas;
				}
				catch (Exception ^e) // Exception handling, prevents the program from crashing.
				{
					MessageBox::Show("Please check the input value not to exeed the resolution of 344x344");
				}
			}
			break;
		case 2:
			// CHECK HERE, LAST POSITION IS HERE!
			if ((xC == 0 && yC == 0) || xC == 0 || yC == 0)
			{
				MessageBox::Show("The X Center or Y Center are zero, cannot draw a full circle!");
			}
			else
			{
				int x = 0, y = r, d = 1 - r, dR = 3, dDR = -2 * r + 5;
				try {
					while(x < y)
					{
						this->bitmapCanvas->SetPixel(x+xC, y+xC, System::Drawing::Color::Black);
					}
				}
				catch (Exception ^e) 
				{
					MessageBox::Show("Please check the input value not to exeed the resolution of 344x344");
				}
			}
			// Second order goes here
			break;
		default:
			break;
		}
	}
	else {
		MessageBox::Show("Please give the x center, y center, radius and circle algorithm!");
	}
}

private: System::Void RectangleButton_Click(System::Object^  sender, System::EventArgs^  e) 
{
	// Soon after circle is complete. Will draw full black rectangle since I don't know to draw it line by line :p
	if (this->X1_textBox->Text != "" && this->Y1_textBox->Text != "" && this->X2_textBox->Text != "" && this->Y2_textBox->Text != "") { // No empty input
	
	}
	else {
		MessageBox::Show("Please give a proper value for all input!");
	}
}
private: System::Void ClearButton_Click(System::Object^  sender, System::EventArgs^  e) 
{
	this->X1_textBox->Text = "";
	this->Y1_textBox->Text = "";
	this->X2_textBox->Text = "";
	this->Y2_textBox->Text = "";
	this->xC_textBox->Text = "";
	this->yC_TextBox->Text = "";
	this->Radius_textBox->Text = "";
	this->algorithmChoices->SelectedIndex = 0;
	this->circleAlgorithmChoices->SelectedIndex = 0;

	for (int i = 0; i < this->bitmapCanvas->Width; i++) 
	{
		for (int j = 0; j < this->bitmapCanvas->Height; j++) 
		{
			if (this->bitmapCanvas->GetPixel(i, j) != System::Drawing::Color::White) {
				this->bitmapCanvas->SetPixel(i, j, System::Drawing::Color::White);
			}
			else continue;
		}
	}
	this->mainCanvas->Image = bitmapCanvas;
}
private: System::Void exitButton_Click(System::Object^  sender, System::EventArgs^  e) 
{
	this->~MyForm();
	this->Close();
}
};
}
