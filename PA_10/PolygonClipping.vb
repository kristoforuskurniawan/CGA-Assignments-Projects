Public Class PolygonClipping
    Dim bitmapCanvas, clippingWindowAnimation As Bitmap
    Dim graphics, Animation As Graphics
    Dim StartPoint As Point 'For the starter point
    Dim ListOfPolygon As List(Of List(Of Point))
    Dim isClipping, isMultipleMode, isMouseDown, isClippingDone, PolyListIndexReady As Boolean
    Dim mRect As Rectangle
    Dim Polygon, PolyOut, ClippedPoly, clippingWindowPoint As List(Of Point)
    Dim x, y, SelectedPolyIndex, SelectedPolyPointIndex As Integer

    Private Sub PolygonClipping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClippedPoly = New List(Of Point)
        PolyListIndexReady = False 'Tells the program that I have selected a specific polygon from a listbox to be processed with Sutherland-Hodgman
        SelectedPolyPointIndex = -1
        graphics = CreateGraphics()
        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height) 'Create bitmap for the form
        Polygon = Nothing
        graphics = Graphics.FromImage(bitmapCanvas)
        graphics.Clear(Color.White)
        MainCanvas.Image = bitmapCanvas
        PolyOut = New List(Of Point)
        ListOfPolygon = New List(Of List(Of Point))
        'ListOfClippedPolygon = New List(Of List(Of Point)) 'Handle multiple polygon
        clippingWindowPoint = New List(Of Point) 'Clipping window points
        isMultipleMode = True
        isClipping = False
        multipleLbl.Text += " On"
        modeLbl.Text += " Off"
    End Sub

    Private Sub PolyPoint_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles PolyPoint_TextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim forX, forY As String
            Dim i As Integer = 0
            Dim newX, newY As Integer
            newX = 0
            newY = 0
            forX = ""
            forY = ""
            If SelectedPolyIndex <> -1 And SelectedPolyPointIndex <> -1 Then
                If PolyPoint_TextBox.Text <> "" Then

                    While (i < PolyPoint_TextBox.Text.Count - 1 And PolyPoint_TextBox.Text(i) <> ",") 'Keeps reading until ',' is found
                        forX += PolyPoint_TextBox.Text(i)
                        i = i + 1
                    End While

                    If Not System.Text.RegularExpressions.Regex.IsMatch(forX, "^[0-9 ]+$") Then
                        MessageBox.Show("x should be numeric only!")
                    End If

                    i = i + 1

                    While i < PolyPoint_TextBox.Text.Count
                        forY += PolyPoint_TextBox.Text(i)
                        i = i + 1
                    End While
                    If Not System.Text.RegularExpressions.Regex.IsMatch(forY, "^[0-9 ]+$") Then
                        MessageBox.Show("y should be numerical only!")
                    End If

                Else
                    MessageBox.Show("Please type the new vertex")
                End If

                If (IsNumeric(forX) And IsNumeric(forY)) Then 'Make sure all inputs are just numbers
                    newX = newX + Integer.Parse(forX) 'Integer.Parse prevents whitespace. This is magic...
                    newY = newY + Integer.Parse(forY)

                    '610 x 340
                    If (newX >= 0 And newX <= 610 And newY >= 0 And newY <= 340) Then 'Limit so that new point won't exceed the canvas resolution
                        For B As Integer = 0 To ListOfPolygon(SelectedPolyIndex).Count - 1
                            If B = SelectedPolyPointIndex Then
                                ListOfPolygon(SelectedPolyIndex).RemoveAt(B)
                                ListOfPolygon(SelectedPolyIndex).Insert(B, New Point(newX, newY))
                            End If
                        Next

                        coordinatesListBox.Items.Clear()
                        Dim PolyCoordinates As String = ""
                        For j = 0 To ListOfPolygon(SelectedPolyIndex).Count - 1 'Write back the inside of polygon coordinate listbox
                            PolyCoordinates = "X = " & ListOfPolygon(SelectedPolyIndex)(j).X.ToString() & ", Y = " & ListOfPolygon(SelectedPolyIndex)(j).Y.ToString() + vbNewLine
                            coordinatesListBox.Items.Add(PolyCoordinates)
                        Next

                        ' Then redraw the selected polygon
                        graphics.Clear(Color.White)
                        For polyIndex As Integer = 0 To ListOfPolygon.Count - 1
                            ReDrawPolygon(Pens.Black, Color.Black, 1, ListOfPolygon(polyIndex))
                        Next
                        MainCanvas.Image = bitmapCanvas
                    Else
                        MessageBox.Show("New X or New Y whether below 0 or exceed canvas resolution")
                    End If
                End If
            Else
                MessageBox.Show("Please draw polygon first and select the polygon vertex!")
            End If
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click 'Saving polygon as a text file
        Dim saveFileDialog1 As New SaveFileDialog()
        Dim pointPoly As String = ""
        If ListOfPolygon IsNot Nothing Then
            For i = 0 To ListOfPolygon.Count - 1
                pointPoly += "Polygon " & i + 1.ToString() & vbNewLine
                For j = 1 To ListOfPolygon(i).Count  '3
                    Dim PointPoly1 As Point = ListOfPolygon(i)(j - 1) '0 0 0 1 0 2
                    Dim PointPoly2 As Point = ListOfPolygon(i)(j Mod ListOfPolygon(i).Count) '0 1 0 2
                    pointPoly += "|" & ListOfPolygon(i)(j - 1).X.ToString() & ", " & ListOfPolygon(i)(j - 1).Y.ToString()
                Next
                pointPoly += vbNewLine
            Next
        End If
        saveFileDialog1.Filter = "*.txt|*.txt"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            System.IO.File.WriteAllText(saveFileDialog1.FileName, pointPoly)
        End If
    End Sub

    'The only feature left is open... Still buggy tho :(
    'Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click 'Open from a text file containing polygon(s) list and its points
    '    'MessageBox.Show("We are sorry, this feature is under maintenance and cannot be used yet.", "Attention")
    '    Dim fileReader, currentString, PolyObjStr, tempChar As String
    '    Polygon = New List(Of Point)
    '    Dim i As Integer = 0
    '    tempChar = ""
    '    fileReader = ""
    '    currentString = ""
    '    PolyObjStr = ""
    '    Dim openFileDialog As New OpenFileDialog()
    '    Dim currentLine As Integer = 1
    '    Dim sr As System.IO.StreamReader
    '    openFileDialog.Filter = "*.txt|*.txt"
    '    openFileDialog.FilterIndex = 2
    '    openFileDialog.RestoreDirectory = True
    '    If openFileDialog.ShowDialog() = DialogResult.OK Then 'If the open file is success

    '        If polygonListBox.Items.Count > 0 Then
    '            polygonListBox.Items.Clear()
    '        End If

    '        If coordinatesListBox.Items.Count > 0 Then
    '            coordinatesListBox.Items.Clear()
    '        End If

    '        sr = My.Computer.FileSystem.OpenTextFileReader(openFileDialog.FileName)
    '        Do Until sr.EndOfStream And i < fileReader.Count 'Loop until end of file
    '            currentLine = currentLine + 1
    '            fileReader = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName, System.Text.Encoding.UTF8)
    '            fileReader = sr.ReadLine 'Read per line
    '            If currentLine Mod 2 = 0 Then 'Polygon insertion
    '                'MessageBox.Show(fileReader)
    '                PolyObjStr = fileReader
    '                ListOfPolygon.Add(Polygon)
    '                polygonListBox.Items.Add(PolyObjStr)
    '                PolyObjStr = ""
    '            ElseIf currentLine Mod 2 <> 0 Then 'Point insertion
    '                For j As Integer = 0 To fileReader.Count - 1
    '                    'If fileReader(j) = "|" Then
    '                    '    Continue For
    '                    'Else

    '                    'End If
    '                    tempChar += fileReader(j)
    '                Next
    '                MessageBox.Show(currentLine.ToString())
    '                'MessageBox.Show(polygonListBox.Items(currentLine - 1) & vbNewLine & tempChar)
    '                tempChar = ""
    '            End If
    '        Loop
    '        MessageBox.Show("Number of polygon(s) : " & ListOfPolygon.Count.ToString())
    '    Else
    '        MessageBox.Show("No such file!")
    '    End If
    'End Sub

    'Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
    '    Dim fileReader, split_1(), split_2() As String
    '    Dim lineNum As Integer = 0
    '    Dim PolyObjStr As String = ""
    '    Dim PolyCoordinates As String = ""
    '    Dim openFileDialog As New OpenFileDialog()
    '    Dim sr As System.IO.StreamReader
    '    Polygon = New List(Of Point)
    '    graphics.Clear(Color.White)
    '    ListOfPolygon.Clear()
    '    Polygon.Clear()
    '    polygonListBox.Items.Clear()
    '    openFileDialog.Filter = "txt files (*.txt)|*.txt"
    '    openFileDialog.FilterIndex = 2
    '    openFileDialog.RestoreDirectory = True
    '    If openFileDialog.ShowDialog() = DialogResult.OK Then
    '        sr = My.Computer.FileSystem.OpenTextFileReader(openFileDialog.FileName)
    '        Do While sr.Peek() >= 0
    '            fileReader = sr.ReadLine()
    '            split_1 = fileReader.Split("|")
    '            If split_1(0) = "Polygon" Then
    '                Dim i As Integer = 1
    '                While i < split_1.Length
    '                    split_2 = split_1(i).Split(",")
    '                    'PolyObjStr += split_2(i)
    '                    Polygon.Add(New Point(split_2(0), split_2(1)))
    '                    i += 1
    '                End While
    '                ListOfPolygon.Add(Polygon)
    '                'polygonListBox.Items.Add("Polygon " & ListOfPolygon.Count.ToString())
    '                'MessageBox.Show("Polygon " & ListOfPolygon.Count & " has " & Polygon.Count & " points.")
    '                For numOfPoly As Integer = 0 To ListOfPolygon.Count - 1
    '                    'For numOfPolyPoint As Integer = 0 To ListOfPolygon(numOfPoly).Count - 1
    '                    '    ListOfPolygon(numOfPoly).Add(New Point(split_2(0))
    '                    'Next
    '                    'MessageBox.Show(ListOfPolygon(0)(0).X.ToString())
    '                    ReDrawPolygon(Pens.Black, Color.Black, 1, ListOfPolygon(numOfPoly))
    '                    polygonListBox.Items.Add("Polygon " & ListOfPolygon.Count.ToString())
    '                Next
    '                MainCanvas.Image = bitmapCanvas
    '                'MessageBox.Show("Number of Polygon = " & Polygon.Count)
    '                'MessageBox.Show(PolyObjStr)
    '                Polygon.Clear()
    '            End If
    '        Loop
    '    End If
    'End Sub

    Private Sub MainCanvas_MouseDown(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseDown
        isMouseDown = True
        If isClipping And Not isMultipleMode Then
            graphics.Clear(Color.White)
            PolyOut.Clear()
            For i = 0 To ListOfPolygon.Count - 1
                ReDrawPolygon(Pens.Black, Color.Black, 1, ListOfPolygon(i))
            Next
            MainCanvas.Image = bitmapCanvas
            clippingWindowPoint.Clear()

            x = e.X
            y = e.Y
        ElseIf isMultipleMode And Not isClipping Then
            insertPointPolygon(e)
        End If
    End Sub

    Private Sub MainCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        If e.X >= 0 And e.Y >= 0 And e.X <= MainCanvas.Width And e.Y <= MainCanvas.Height Then
            coorLbl.Text = "X = " & e.X.ToString() & ", Y = " & e.Y.ToString()
        ElseIf e.X < 0 And e.Y < 0 Then
            coorLbl.Text = "X = 0, Y = 0"
        ElseIf e.X < 0 Then
            coorLbl.Text = "X = 0" & ", Y = " & e.Y.ToString()
        ElseIf e.Y < 0 Then
            coorLbl.Text = "X = " & e.X.ToString() & ", Y = 0"
        ElseIf e.X > MainCanvas.Width Then
            coorLbl.Text = "X = " & MainCanvas.Width.ToString() & ", Y = " & e.Y.ToString()
        ElseIf e.Y > MainCanvas.Height Then
            coorLbl.Text = "X = " & e.X.ToString() & ", Y = " & MainCanvas.Height.ToString()
        ElseIf e.Y > MainCanvas.Height And e.X > MainCanvas.Width Then
            coorLbl.Text = "X = " & MainCanvas.Width.ToString() & ", Y = " & MainCanvas.Height.ToString()
        End If
        clippingWindowAnimation = bitmapCanvas.Clone()
        Animation = Graphics.FromImage(clippingWindowAnimation)
        If isMouseDown = True Then
            If isClipping And Not isMultipleMode Then
                ClipWindow(e)
                Animation.DrawRectangle(New Pen(Color.Black, 1), mRect)
            End If
        End If
        MainCanvas.Image = clippingWindowAnimation 'put bitmap on the picture box
        MainCanvas.Invalidate()
    End Sub

    Private Sub MainCanvas_MouseUp(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseUp 'Get the final position from mouse, draw on bitmapCanvas

        If ClippedPoly IsNot Nothing Then 'Empty the clipped polygon list after mouse up
            ClippedPoly.Clear()
        End If

        If isClipping Then
            ClipWindow(e)
            clippingWindowPoint.Add(New Point(mRect.X, mRect.Y))
            clippingWindowPoint.Add(New Point(mRect.X + mRect.Width, mRect.Y))
            clippingWindowPoint.Add(New Point(mRect.X + mRect.Width, mRect.Y + mRect.Height))
            clippingWindowPoint.Add(New Point(mRect.X, mRect.Y + mRect.Height))
            graphics.DrawRectangle(New Pen(Color.Black, 1), mRect)
            findNormal(ListOfPolygon, clippingWindowPoint)
        ElseIf isMultipleMode And Not isClipping Then
            drawPolygon(Polygon)
        ElseIf isClipping And Not isMultipleMode Then
            drawPolygon(Polygon)
        End If
        isMouseDown = False
    End Sub

    Private Sub drawPolygon(ByRef polygonPoints As List(Of Point))
        Dim FirstPoint As Point = New Point()
        Dim SecondPoint As Point = New Point()
        If Polygon IsNot Nothing Then
            For i = 1 To Polygon.Count - 1
                FirstPoint = Polygon(i - 1)
                SecondPoint = Polygon(i)
                graphics = Graphics.FromImage(bitmapCanvas)
                graphics.DrawLine(Pens.Black, FirstPoint, SecondPoint)
            Next
        End If
    End Sub

    Private Sub clippingBtn_Click(sender As Object, e As EventArgs) Handles clippingBtn.Click
        If isClipping Then
            isClipping = False
            modeLbl.Text = "Clipping Mode: Off"
        Else
            isClipping = True
            isMultipleMode = False
            modeLbl.Text = "Clipping Mode: On"
            multipleLbl.Text = "Multiple Mode: Off"
        End If
    End Sub

    Private Sub coordinatesListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles coordinatesListBox.SelectedIndexChanged
        If coordinatesListBox.SelectedIndex >= 0 Then
            SelectedPolyPointIndex = coordinatesListBox.SelectedIndex
            PolyPoint_TextBox.Text = ListOfPolygon(SelectedPolyIndex)(SelectedPolyPointIndex).X.ToString() & ", " & ListOfPolygon(SelectedPolyIndex)(SelectedPolyPointIndex).Y.ToString()
        Else
            SelectedPolyPointIndex = -1
        End If
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
        MessageBox.Show(
            "Sutherland and Hodgman Clipping demo ver. 0.1a" & vbNewLine & vbNewLine &
            "User Inteface :" & vbNewLine & vbTab &
                "1. Jonathan Surya" & vbNewLine & vbTab &
                "2. Ardy Wijaya" & vbNewLine & vbTab &
                "3. Kristoforus Kurniawan" & vbNewLine & vbNewLine &
            "Coding :" & vbNewLine & vbTab &
                "1. Kristoforus Kurniawan" & vbNewLine & vbTab &
                "2. Ardy Wijaya" & vbNewLine & vbTab &
                "3. Jonathan Surya", "About Me", MessageBoxButtons.OK)
    End Sub

    Private Sub DeletePointButton_Click(sender As Object, e As EventArgs) Handles DeletePointButton.Click
        Dim SpecialPen As Pen = Nothing

        If SelectedPolyIndex < 0 Or SelectedPolyPointIndex < 0 Then
            MessageBox.Show("Please select the polygon and point to be edited!")
        Else
            If ListOfPolygon(SelectedPolyIndex).Count > 3 Then 'At least 3 points inside polygon
                ListOfPolygon(SelectedPolyIndex).RemoveAt(SelectedPolyPointIndex)
                graphics.Clear(Color.White)
                For polyIndex As Integer = 0 To ListOfPolygon.Count - 1
                    ReDrawPolygon(SpecialPen, Color.Black, 1, ListOfPolygon(polyIndex))
                Next

                coordinatesListBox.Items.Clear()
                Dim PolyCoordinates As String = ""
                For j = 0 To ListOfPolygon(SelectedPolyIndex).Count - 1 'Write back the inside of polygon coordinate listbox
                    PolyCoordinates = "X = " & ListOfPolygon(SelectedPolyIndex)(j).X.ToString() & ", Y = " & ListOfPolygon(SelectedPolyIndex)(j).Y.ToString() + vbNewLine
                    coordinatesListBox.Items.Add(PolyCoordinates)
                Next
                PolyPoint_TextBox.Text = ""
                SelectedPolyPointIndex = -1 'Reset the value of selected point index to prevent continuous clicking
            Else 'Less than 3 points
                MessageBox.Show("Cannot delete any point from this polygon since the mininum is 3 points!")
            End If
        End If
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub polygonListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles polygonListBox.SelectedIndexChanged
        Dim testPen As Pen = Nothing

        If PolyListIndexReady And SelectedPolyIndex = polygonListBox.SelectedIndex Then 'When we click the same item twice, unselect it.
            SelectedPolyIndex = -1
            polygonListBox.ClearSelected()
            PolyListIndexReady = False
            For i As Integer = 0 To ListOfPolygon.Count - 1
                ReDrawPolygon(testPen, Color.Black, 1, ListOfPolygon(i))
            Next
        End If

        coordinatesListBox.Items.Clear()
        clippingWindowPoint.Clear()
        Dim PolyCoordinates As String = ""
        graphics = Graphics.FromImage(bitmapCanvas)
        SelectedPolyIndex = polygonListBox.SelectedIndex

        If (SelectedPolyIndex >= 0) Then
            PolyListIndexReady = True
            For numOfPolygon As Integer = 0 To ListOfPolygon.Count - 1 'TEMPORARILY COMMENTED. I am looking For a way To handle multiple polygon without Using singlemode Or multiple mode
                If numOfPolygon <> SelectedPolyIndex Then
                    ReDrawPolygon(testPen, Color.Black, 1, ListOfPolygon(numOfPolygon))
                Else
                    ReDrawPolygon(testPen, Color.Blue, 1, ListOfPolygon(numOfPolygon))
                End If
            Next
            For j = 0 To ListOfPolygon(SelectedPolyIndex).Count - 1 '5->2>0,1,2
                PolyCoordinates = "X = " & ListOfPolygon(SelectedPolyIndex)(j).X.ToString() & ", Y = " & ListOfPolygon(SelectedPolyIndex)(j).Y.ToString() + vbNewLine
                coordinatesListBox.Items.Add(PolyCoordinates)
            Next
        Else
            PolyListIndexReady = False
        End If
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub ClipWindow(e As MouseEventArgs)
        mRect.X = x
        mRect.Y = y
        If e.X >= 0 And e.X < mRect.X Then  'Drawing diagonal top right to left bottom
            mRect.Width = mRect.X - e.X
            mRect.X = e.X
        ElseIf e.X < 0 And e.X < mRect.X Then 'Drawing from bottom right to top left
            mRect.X = 0
        ElseIf e.X < MainCanvas.Width Then 'Bottom left to  top right
            mRect.Width = e.X - mRect.X
        End If
        If e.Y > 0 And e.Y < mRect.Y Then 'Bottom left to top right
            mRect.Height = mRect.Y - e.Y
            mRect.Y = e.Y
        ElseIf e.Y < 0 And e.Y < mRect.Y Then 'Drawing from bottom right to top left
            mRect.Y = 0
        ElseIf e.Y < MainCanvas.Height Then 'Top left to bottom right
            mRect.Height = e.Y - mRect.Y
        End If
    End Sub

    Private Sub insertPolygon()
        graphics = Graphics.FromImage(bitmapCanvas)
        For i = 0 To ListOfPolygon.Count - 1
            Dim FirstPoint As Point = ListOfPolygon(i)(0)
            Dim LastPoint As Point = ListOfPolygon(i)(ListOfPolygon(i).Count - 1)
            For j = 1 To ListOfPolygon(i).Count - 1
                Dim PointPoly1 As Point = ListOfPolygon(i)(j - 1) '0 0 0 1
                Dim PointPoly2 As Point = ListOfPolygon(i)(j) '0 1 0 2
                graphics.DrawLine(Pens.Black, PointPoly1, PointPoly2)
            Next
            graphics.DrawLine(Pens.Black, FirstPoint, LastPoint)
        Next
        clippingWindowPoint.Clear()
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub refreshBtn_Click(sender As Object, e As EventArgs) Handles refreshBtn.Click
        If clippingWindowPoint IsNot Nothing And clippingWindowPoint.Count > 0 Then 'Make all clipping window edges to white (delete these)
            graphics.Clear(Color.White)
            insertPolygon()
        Else
            MessageBox.Show("There is no clipping window")
        End If
        isMultipleMode = True
        isClipping = False
        ClippedPoly.Clear()
        multipleLbl.Text = "Multiple Mode: On"
        modeLbl.Text = "Clipping Mode: Off"
    End Sub

    Private Sub insertPointPolygon(e As MouseEventArgs)
        Dim PolyObjStr As String = ""
        If Polygon IsNot Nothing Then
            If (e.Button = MouseButtons.Right) Then
                ' Finish this polygon.
                graphics.DrawLine(Pens.Black, Polygon(Polygon.Count - 1), Polygon(0))
                If (Polygon.Count > 2) Then
                    ListOfPolygon.Add(Polygon)
                    For PolyListLoop = 0 To ListOfPolygon.Count - 1
                        PolyObjStr = "Polygon " & PolyListLoop + 1.ToString() & vbNewLine
                    Next
                    polygonListBox.Items.Add(PolyObjStr)
                    Polygon = Nothing
                End If
            Else
                If (Polygon(Polygon.Count - 1) <> e.Location) Then
                    Polygon.Add(e.Location)
                End If
            End If
        Else
            Polygon = New List(Of Point)
            StartPoint = e.Location
            Polygon.Add(e.Location)
        End If
    End Sub

    Private Sub findNormal(ByRef Polygon As List(Of List(Of Point)), ByRef ClippingWindowPointList As List(Of Point))
        Dim NormalRight As New List(Of System.Windows.Vector) 'Store the normal right of clipping window edge
        Dim ClipWinEdge As New List(Of System.Windows.Vector) 'LAST EDITED HERE On 3 November 2017 at 8:05 PM
        Dim i As Integer = 0
        Dim j As Integer = 1
        While (i < ClippingWindowPointList.Count And j <= ClippingWindowPointList.Count) 'Insert clipping window edge into a list of vector -> vector of clipping window vector
            If j = ClippingWindowPointList.Count Then
                j = 0
            End If
            ClipWinEdge.Add(New System.Windows.Vector(ClippingWindowPointList(j).X - ClippingWindowPointList(i).X, ClippingWindowPointList(i).Y - ClippingWindowPointList(j).Y))
            i = i + 1
            j = j + 1
        End While
        ' Salah di hitungan edge. Coba dibuat supaya masuk point clipping window edge  SALAH DI HITUNGAN INI
        For edgeIndex As Integer = 0 To ClipWinEdge.Count - 1 'Insert the normal vector into a list
            NormalRight.Add(New System.Windows.Vector(ClipWinEdge(edgeIndex).Y, -ClipWinEdge(edgeIndex).X))  'NormalRight is y, -x of edge vector
        Next
        SutherlandHodgman(NormalRight, PolyOut, Polygon, ClippingWindowPointList, SelectedPolyIndex)
        isClipping = True
        isMultipleMode = False
    End Sub

    Private Sub SutherlandHodgman(ByRef NormalRight As List(Of System.Windows.Vector), ByRef outputList As List(Of Point), ByRef Polygon As List(Of List(Of Point)), ByRef ClippingWindowPointList As List(Of Point), ByVal selectedPolyIndex As Integer)
        Dim SpecialPen As Pen = Nothing
        If PolyListIndexReady Then 'One polygon only
            For i As Integer = 0 To Polygon(selectedPolyIndex).Count - 1
                Dim polyPoint As Point = New Point(Polygon(selectedPolyIndex)(i).X, Polygon(selectedPolyIndex)(i).Y)
                ClippedPoly.Add(polyPoint)
            Next

            For forClip As Integer = 0 To ClippingWindowPointList.Count - 1 'Trying to calculate the dot product SALAH DI SINI!!
                outputList = Clip(ClippedPoly, ClippingWindowPointList, outputList, NormalRight, forClip)
                ClippedPoly.Clear()
                For i As Integer = 0 To outputList.Count - 1
                    Dim outPoint As Point = New Point(outputList(i).X, outputList(i).Y)
                    ClippedPoly.Add(outPoint)
                Next
                outputList.Clear()
            Next
            ReDrawPolygon(SpecialPen, Color.Coral, 2, ClippedPoly)
        Else 'Process multiple polygon
            For currentPoly As Integer = 0 To Polygon.Count - 1
                For i As Integer = 0 To Polygon(currentPoly).Count - 1
                    Dim polyPoint As Point = New Point(Polygon(currentPoly)(i).X, Polygon(currentPoly)(i).Y)
                    ClippedPoly.Add(polyPoint)
                Next

                For forClip As Integer = 0 To ClippingWindowPointList.Count - 1 'Trying to calculate the dot product SALAH DI SINI!!
                    outputList = Clip(ClippedPoly, ClippingWindowPointList, outputList, NormalRight, forClip)
                    ClippedPoly.Clear()
                    For i As Integer = 0 To outputList.Count - 1
                        Dim outPoint As Point = New Point(outputList(i).X, outputList(i).Y)
                        ClippedPoly.Add(outPoint)
                    Next
                    outputList.Clear()
                Next
                ReDrawPolygon(SpecialPen, Color.Coral, 2, ClippedPoly)
                ClippedPoly.Clear()
            Next
        End If
    End Sub

    Private Function Clip(ByRef ClippedPoly As List(Of Point), ByRef ClippingWindowPointList As List(Of Point), ByRef outputList As List(Of Point), ByRef NormalRight As List(Of System.Windows.Vector), ByVal forClip As Integer)
        Dim t, x_intersect, y_intersect As Double
        Dim x As Integer = 0
        ' Dim z As Integer = 1
        Dim startPointList As List(Of Integer) = New List(Of Integer)
        Dim endPointList As List(Of Integer) = New List(Of Integer)
        Dim newPoint As Point

        For forPoly As Integer = 0 To ClippedPoly.Count - 1
            Dim s1 As Integer
            Dim s2 As Integer
            If forPoly < ClippedPoly.Count - 1 Then
                '   MessageBox.Show("X = " & NormalRight(forClip).X & "Y= " & NormalRight(forClip).Y)
                s1 = (ClippedPoly(forPoly).X - ClippingWindowPointList(forClip).X) * NormalRight(forClip).X + (ClippingWindowPointList(forClip).Y - ClippedPoly(forPoly).Y) * NormalRight(forClip).Y
                s2 = (ClippedPoly((forPoly Mod (ClippedPoly.Count - 1)) + 1).X - ClippingWindowPointList(forClip).X) * NormalRight(forClip).X + (ClippingWindowPointList(forClip).Y - ClippedPoly((forPoly Mod (ClippedPoly.Count - 1)) + 1).Y) * NormalRight(forClip).Y
                startPointList.Add(s1)
                endPointList.Add(s2)
            ElseIf forPoly = ClippedPoly.Count - 1 Then 'last and first
                s1 = (ClippedPoly(ClippedPoly.Count - 1).X - ClippingWindowPointList(forClip).X) * NormalRight(forClip).X + (ClippingWindowPointList(forClip).Y - ClippedPoly(ClippedPoly.Count - 1).Y) * NormalRight(forClip).Y
                s2 = (ClippedPoly(0).X - ClippingWindowPointList(forClip).X) * NormalRight(forClip).X + (ClippingWindowPointList(forClip).Y - ClippedPoly(0).Y) * NormalRight(forClip).Y
                startPointList.Add(s1)
                endPointList.Add(s2)
            End If
        Next

        'for sutherland-hodgman cases
        While x < startPointList.Count And x < endPointList.Count And x + 1 <= ClippedPoly.Count
            If startPointList(x) < 0 And endPointList(x) < 0 Then
            ElseIf startPointList(x) < 0 And endPointList(x) >= 0 Then
                t = findIntersection(ClippingWindowPointList(forClip), ClippedPoly((x + 1) - 1), ClippedPoly((x + 1) Mod ClippedPoly.Count), NormalRight, forClip)
                x_intersect = findXIntersection(ClippedPoly((x + 1) - 1), ClippedPoly((x + 1) Mod ClippedPoly.Count), t) '0 0 01 01 02 etc
                y_intersect = findYIntersection(ClippedPoly((x + 1) - 1), ClippedPoly((x + 1) Mod ClippedPoly.Count), t)
                newPoint = New Point(x_intersect, y_intersect)
                outputList.Add(newPoint)
                outputList.Add(ClippedPoly((x + 1) Mod ClippedPoly.Count))
            ElseIf startPointList(x) >= 0 And endPointList(x) >= 0 Then
                outputList.Add(ClippedPoly((x + 1) Mod ClippedPoly.Count))
            ElseIf startPointList(x) >= 0 And endPointList(x) < 0 Then
                t = findIntersection(ClippingWindowPointList(forClip), ClippedPoly((x + 1) - 1), ClippedPoly((x + 1) Mod ClippedPoly.Count), NormalRight, forClip)
                x_intersect = findXIntersection(ClippedPoly((x + 1) - 1), ClippedPoly((x + 1) Mod ClippedPoly.Count), t)
                y_intersect = findYIntersection(ClippedPoly((x + 1) - 1), ClippedPoly((x + 1) Mod ClippedPoly.Count), t)
                newPoint = New Point(x_intersect, y_intersect)
                outputList.Add(newPoint)
            End If
            x = x + 1
        End While
        Return outputList
    End Function

    Private Function findIntersection(ByRef clipPoint As Point, ByRef polyPoint1 As Point, ByRef polyPoint2 As Point, ByRef rightNormal As List(Of System.Windows.Vector), ByVal forClip As Integer)
        Dim t As Double
        t = (((clipPoint.X - polyPoint1.X) * rightNormal(forClip).X) + ((clipPoint.Y - polyPoint1.Y) * rightNormal(forClip).Y)) / (((polyPoint2.X - polyPoint1.X) * rightNormal(forClip).X) + ((polyPoint2.Y - polyPoint1.Y) * rightNormal(forClip).Y))
        Return t
    End Function

    Private Function findXIntersection(ByRef polyPoint1 As Point, ByRef polyPoint2 As Point, ByVal t As Double)
        Dim Xc As Double
        Xc = polyPoint1.X + t * (polyPoint2.X - polyPoint1.X)
        Return Xc
    End Function

    Private Function findYIntersection(ByRef polyPoint1 As Point, ByRef polyPoint2 As Point, ByVal t As Double)
        Dim Yc As Double
        Yc = polyPoint1.Y + t * (polyPoint2.Y - polyPoint1.Y)
        Return Yc
    End Function

    Private Sub ReDrawPolygon(ByRef pen As Pen, ByRef penColor As Color, ByVal penWidth As Integer, ByRef DrawnPolygon As List(Of Point))
        pen = New Pen(penColor)
        pen.Width = penWidth
        For i As Integer = 1 To DrawnPolygon.Count - 1
            If i = DrawnPolygon.Count - 1 Then
                graphics.DrawLine(pen, DrawnPolygon(0), DrawnPolygon(i))
            End If
            graphics.DrawLine(pen, DrawnPolygon(i - 1), DrawnPolygon(i))
        Next
    End Sub

End Class