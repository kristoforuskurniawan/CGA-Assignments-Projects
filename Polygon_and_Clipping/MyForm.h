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
	private: System::Windows::Forms::Label^  CoordinatesLabel;
	private: System::Windows::Forms::Label^  CoordinatesTitleLabel;
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
			this->CoordinatesLabel = (gcnew System::Windows::Forms::Label());
			this->CoordinatesTitleLabel = (gcnew System::Windows::Forms::Label());
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
			this->mainCanvas->Click += gcnew System::EventHandler(this, &MyForm::mainCanvas_Click);
			this->mainCanvas->Image = bitmapCanvas;
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
			// 
			// CoordinatesLabel
			// 
			this->CoordinatesLabel->AutoSize = true;
			this->CoordinatesLabel->Location = System::Drawing::Point(689, 42);
			this->CoordinatesLabel->MinimumSize = System::Drawing::Size(100, 20);
			this->CoordinatesLabel->Name = L"CoordinatesLabel";
			this->CoordinatesLabel->Size = System::Drawing::Size(100, 20);
			this->CoordinatesLabel->TabIndex = 4;
			this->CoordinatesLabel->Text = L"0, 0";
			this->CoordinatesLabel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// CoordinatesTitleLabel
			// 
			this->CoordinatesTitleLabel->AutoSize = true;
			this->CoordinatesTitleLabel->Location = System::Drawing::Point(707, 29);
			this->CoordinatesTitleLabel->Name = L"CoordinatesTitleLabel";
			this->CoordinatesTitleLabel->Size = System::Drawing::Size(69, 13);
			this->CoordinatesTitleLabel->TabIndex = 5;
			this->CoordinatesTitleLabel->Text = L"Coordinates :";
			this->CoordinatesTitleLabel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(941, 531);
			this->Controls->Add(this->CoordinatesTitleLabel);
			this->Controls->Add(this->CoordinatesLabel);
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

	
private: System::Void mainCanvas_Click(System::Object^  sender, System::EventArgs^  e) {
	System::Windows::Forms::MouseEventArgs ^a = nullptr;
	if (a->Button == System::Windows::Forms::MouseButtons::Left) { // EXCEPTION HERE FUCK IT, FIND WHY!!!
		MessageBox::Show("Left");
	}
	else if (a->Button == System::Windows::Forms::MouseButtons::Right) {
		MessageBox::Show("Right");
	}
}
};
}
