<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MainCanvas = New System.Windows.Forms.PictureBox()
        Me.ButtonCopy = New System.Windows.Forms.Button()
        Me.ButtonCut = New System.Windows.Forms.Button()
        Me.ButtonPaste = New System.Windows.Forms.Button()
        Me.CoordinateLabel = New System.Windows.Forms.Label()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.ButtonFinishPolygon = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveCtrlSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenCtrlOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyCtrCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutCtrlXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteCtrlVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutMeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PolygonList_Label = New System.Windows.Forms.Label()
        Me.CoordinateList_Label = New System.Windows.Forms.Label()
        Me.PolygonList_ListBox = New System.Windows.Forms.ListBox()
        Me.PolyCoord_ListBox = New System.Windows.Forms.ListBox()
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainCanvas
        '
        Me.MainCanvas.Image = Global.Polygon_Clipping_PA_10.My.Resources.Resources.White_Background_2
        Me.MainCanvas.Location = New System.Drawing.Point(12, 24)
        Me.MainCanvas.Name = "MainCanvas"
        Me.MainCanvas.Size = New System.Drawing.Size(480, 480)
        Me.MainCanvas.TabIndex = 0
        Me.MainCanvas.TabStop = False
        '
        'ButtonCopy
        '
        Me.ButtonCopy.Location = New System.Drawing.Point(103, 510)
        Me.ButtonCopy.Name = "ButtonCopy"
        Me.ButtonCopy.Size = New System.Drawing.Size(85, 40)
        Me.ButtonCopy.TabIndex = 1
        Me.ButtonCopy.Text = "Copy"
        Me.ButtonCopy.UseVisualStyleBackColor = True
        '
        'ButtonCut
        '
        Me.ButtonCut.Location = New System.Drawing.Point(203, 510)
        Me.ButtonCut.Name = "ButtonCut"
        Me.ButtonCut.Size = New System.Drawing.Size(85, 40)
        Me.ButtonCut.TabIndex = 2
        Me.ButtonCut.Text = "Cut"
        Me.ButtonCut.UseVisualStyleBackColor = True
        '
        'ButtonPaste
        '
        Me.ButtonPaste.Location = New System.Drawing.Point(306, 510)
        Me.ButtonPaste.Name = "ButtonPaste"
        Me.ButtonPaste.Size = New System.Drawing.Size(85, 40)
        Me.ButtonPaste.TabIndex = 3
        Me.ButtonPaste.Text = "Paste"
        Me.ButtonPaste.UseVisualStyleBackColor = True
        '
        'CoordinateLabel
        '
        Me.CoordinateLabel.AutoSize = True
        Me.CoordinateLabel.Location = New System.Drawing.Point(387, 8)
        Me.CoordinateLabel.Name = "CoordinateLabel"
        Me.CoordinateLabel.Size = New System.Drawing.Size(63, 13)
        Me.CoordinateLabel.TabIndex = 4
        Me.CoordinateLabel.Text = "X = 0, Y = 0"
        Me.CoordinateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonClear
        '
        Me.ButtonClear.Location = New System.Drawing.Point(407, 510)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(85, 40)
        Me.ButtonClear.TabIndex = 5
        Me.ButtonClear.Text = "Clear"
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'ButtonFinishPolygon
        '
        Me.ButtonFinishPolygon.Location = New System.Drawing.Point(12, 510)
        Me.ButtonFinishPolygon.Name = "ButtonFinishPolygon"
        Me.ButtonFinishPolygon.Size = New System.Drawing.Size(85, 40)
        Me.ButtonFinishPolygon.TabIndex = 6
        Me.ButtonFinishPolygon.Text = "Finish Polygon"
        Me.ButtonFinishPolygon.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(663, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveCtrlSToolStripMenuItem, Me.OpenCtrlOToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveCtrlSToolStripMenuItem
        '
        Me.SaveCtrlSToolStripMenuItem.Name = "SaveCtrlSToolStripMenuItem"
        Me.SaveCtrlSToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.SaveCtrlSToolStripMenuItem.Text = "Save"
        '
        'OpenCtrlOToolStripMenuItem
        '
        Me.OpenCtrlOToolStripMenuItem.Name = "OpenCtrlOToolStripMenuItem"
        Me.OpenCtrlOToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenCtrlOToolStripMenuItem.Text = "Open"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(100, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyCtrCToolStripMenuItem, Me.CutCtrlXToolStripMenuItem, Me.PasteCtrlVToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CopyCtrCToolStripMenuItem
        '
        Me.CopyCtrCToolStripMenuItem.Name = "CopyCtrCToolStripMenuItem"
        Me.CopyCtrCToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.CopyCtrCToolStripMenuItem.Text = "Copy (Ctr;+C)"
        '
        'CutCtrlXToolStripMenuItem
        '
        Me.CutCtrlXToolStripMenuItem.Name = "CutCtrlXToolStripMenuItem"
        Me.CutCtrlXToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.CutCtrlXToolStripMenuItem.Text = "Cut (Ctrl+X)"
        '
        'PasteCtrlVToolStripMenuItem
        '
        Me.PasteCtrlVToolStripMenuItem.Name = "PasteCtrlVToolStripMenuItem"
        Me.PasteCtrlVToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.PasteCtrlVToolStripMenuItem.Text = "Paste (Ctrl+V)"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutMeToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutMeToolStripMenuItem
        '
        Me.AboutMeToolStripMenuItem.Name = "AboutMeToolStripMenuItem"
        Me.AboutMeToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.AboutMeToolStripMenuItem.Text = "About Me"
        '
        'PolygonList_Label
        '
        Me.PolygonList_Label.AutoSize = True
        Me.PolygonList_Label.Location = New System.Drawing.Point(531, 24)
        Me.PolygonList_Label.Name = "PolygonList_Label"
        Me.PolygonList_Label.Size = New System.Drawing.Size(64, 13)
        Me.PolygonList_Label.TabIndex = 9
        Me.PolygonList_Label.Text = "Polygon List"
        '
        'CoordinateList_Label
        '
        Me.CoordinateList_Label.AutoSize = True
        Me.CoordinateList_Label.Location = New System.Drawing.Point(531, 238)
        Me.CoordinateList_Label.Name = "CoordinateList_Label"
        Me.CoordinateList_Label.Size = New System.Drawing.Size(77, 13)
        Me.CoordinateList_Label.TabIndex = 12
        Me.CoordinateList_Label.Text = "Coordinate List"
        '
        'PolygonList_ListBox
        '
        Me.PolygonList_ListBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PolygonList_ListBox.FormattingEnabled = True
        Me.PolygonList_ListBox.Location = New System.Drawing.Point(507, 40)
        Me.PolygonList_ListBox.Name = "PolygonList_ListBox"
        Me.PolygonList_ListBox.Size = New System.Drawing.Size(133, 182)
        Me.PolygonList_ListBox.TabIndex = 13
        '
        'PolyCoord_ListBox
        '
        Me.PolyCoord_ListBox.FormattingEnabled = True
        Me.PolyCoord_ListBox.Location = New System.Drawing.Point(507, 254)
        Me.PolyCoord_ListBox.Name = "PolyCoord_ListBox"
        Me.PolyCoord_ListBox.Size = New System.Drawing.Size(133, 238)
        Me.PolyCoord_ListBox.TabIndex = 14
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 563)
        Me.Controls.Add(Me.PolyCoord_ListBox)
        Me.Controls.Add(Me.PolygonList_ListBox)
        Me.Controls.Add(Me.CoordinateList_Label)
        Me.Controls.Add(Me.PolygonList_Label)
        Me.Controls.Add(Me.ButtonFinishPolygon)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.CoordinateLabel)
        Me.Controls.Add(Me.ButtonPaste)
        Me.Controls.Add(Me.ButtonCut)
        Me.Controls.Add(Me.ButtonCopy)
        Me.Controls.Add(Me.MainCanvas)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "Polygon Clipping - Sutherland and Hodgman"
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainCanvas As PictureBox
    Friend WithEvents ButtonCopy As Button
    Friend WithEvents ButtonCut As Button
    Friend WithEvents ButtonPaste As Button
    Friend WithEvents bitmapCanvas As Bitmap = Bitmap.FromFile("C:\\Users\\Kristoforus\\Documents\\CGA-Assignments-Projects\\PA_10\\Polygon_Clipping_PA_10\\White_Background_2.jpg")
    Friend WithEvents myGraphics As Graphics = Graphics.FromImage(bitmapCanvas) 'Graphic from bitmap canvas to be drawn with pen
    Friend WithEvents myPen As Pen = Pens.Black 'Pen for drawing on bitmap canvas
    Friend WithEvents CoordinateLabel As Label
    Friend WithEvents ButtonClear As Button
    Friend WithEvents ButtonFinishPolygon As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveCtrlSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenCtrlOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutMeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PolygonList_Label As Label
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyCtrCToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutCtrlXToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteCtrlVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CoordinateList_Label As Label
    Friend WithEvents PolygonList_ListBox As ListBox
    Friend WithEvents PolyCoord_ListBox As ListBox
End Class