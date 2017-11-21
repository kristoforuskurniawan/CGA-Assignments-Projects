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
        'ListOfClippedPoly = New List(Of List(Of Point)) 'Handle multiple polygon
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
                While (i < PolyPoint_TextBox.Text.Count - 1 And PolyPoint_TextBox.Text(i) <> ",") 'Keeps reading until ',' is found
                    forX += PolyPoint_TextBox.Text(i)
                    i = i + 1
                End While

                i = i + 2 'Start after white space

                While i < PolyPoint_TextBox.Text.Count
                    forY += PolyPoint_TextBox.Text(i)
                    i = i + 1
                End While

                newX = newX + Integer.Parse(forX)
                newY = newY + Integer.Parse(forY)

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
                    For p As Integer = 1 To ListOfPolygon(polyIndex).Count - 1
                        If p = ListOfPolygon(polyIndex).Count - 1 Then
                            graphics.DrawLine(Pens.Black, ListOfPolygon(polyIndex)(0), ListOfPolygon(polyIndex)(p))
                        End If
                        graphics.DrawLine(Pens.Black, ListOfPolygon(polyIndex)(p - 1), ListOfPolygon(polyIndex)(p))
                    Next
                Next
                MainCanvas.Image = bitmapCanvas
            Else
                MessageBox.Show("Please draw polygon first!")
            End If
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click 'Saving polygon as a text file
        Dim saveFileDialog1 As New SaveFileDialog()
        Dim pointPoly As String = ""
        If ListOfPolygon IsNot Nothing Then
            For i = 0 To ListOfPolygon.Count - 1
                pointPoly += "Polygon " & (i + 1).ToString() + vbNewLine
                For j = 1 To ListOfPolygon(i).Count  '3
                    Dim PointPoly1 As Point = ListOfPolygon(i)(j - 1) '0 0 0 1 0 2
                    Dim PointPoly2 As Point = ListOfPolygon(i)(j Mod ListOfPolygon(i).Count) '0 1 0 2
                    pointPoly += "X = " & ListOfPolygon(i)(j - 1).X.ToString() & ", Y = " & ListOfPolygon(i)(j - 1).Y.ToString() + vbNewLine
                Next
            Next
        End If
        saveFileDialog1.Filter = "txt files (*.txt)|*.txt"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            System.IO.File.WriteAllText(saveFileDialog1.FileName, pointPoly)
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

    End Sub

    Private Sub MainCanvas_MouseDown(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseDown
        isMouseDown = True
        If isClipping And Not isMultipleMode Then
            graphics.Clear(Color.White)
            PolyOut.Clear()
            insertPolygon()
            x = e.X
            y = e.Y
        ElseIf isMultipleMode And Not isClipping Then
            insertPointPolygon(e)
        ElseIf Not isClipping And Not isMultipleMode Then
            If ListOfPolygon.Count = 0 Then
                insertPointPolygon(e)
            Else
                For i = 0 To ListOfPolygon.Count - 1
                    Dim FirstPoint As Point = ListOfPolygon(i)(0)
                    Dim LastPoint As Point = ListOfPolygon(i)(ListOfPolygon(i).Count - 1)
                    For j = 1 To ListOfPolygon(i).Count - 1
                        Dim PointPoly1 As Point = ListOfPolygon(i)(j - 1) '0 0 0 1
                        Dim PointPoly2 As Point = ListOfPolygon(i)(j) '0 1 0 2
                        graphics.DrawLine(Pens.White, PointPoly1, PointPoly2)
                    Next
                    graphics.DrawLine(Pens.White, FirstPoint, LastPoint)
                Next
                ListOfPolygon.Clear()
                polygonListBox.Items.Clear()
                coordinatesListBox.Items.Clear()
                Polygon = New List(Of Point)
                StartPoint = e.Location
                Polygon.Add(e.Location)
            End If
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
        If isClipping = True Then
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

    Private Sub DeletePointButton_Click(sender As Object, e As EventArgs) Handles DeletePointButton.Click
        Dim SpecialPen As Pen = Nothing

        If SelectedPolyIndex < 0 Or SelectedPolyPointIndex < 0 Then
            MessageBox.Show("Please select the polygon and point to be edited!")
        End If

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

        Else 'Less than 3 points
            MessageBox.Show("Cannot delete any point from this polygon since the mininum is 3 points!")
        End If
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub polygonListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles polygonListBox.SelectedIndexChanged
        Dim testPen As Pen = Nothing
        If SelectedPolyIndex = polygonListBox.SelectedIndex Then 'When we click the same item twice, unselect it.
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
        If e.X >= 0 And e.X < mRect.X Then
            mRect.Width = mRect.X - e.X
            mRect.X = e.X
        ElseIf e.X < 0 And e.X < mRect.X Then
            mRect.X = 0
        ElseIf e.X < MainCanvas.Width Then
            mRect.Width = e.X - mRect.X
        End If
        If e.Y > 0 And e.Y < mRect.Y Then
            mRect.Height = mRect.Y - e.Y
            mRect.Y = e.Y
        ElseIf e.Y < 0 And e.Y < mRect.Y Then
            mRect.Y = 0
        ElseIf e.Y < MainCanvas.Height Then
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