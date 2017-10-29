Public Class MainForm

    'Private points As TPoint
    'Private headPolygon, tailPolygon As TPolygon 'For the head and tail of Polygon list
    'Private headPolyElement, tailPolyElement As TElementPolygon 'For the head and tail of Element of Polygon List
    'Private polygonIndexNum As Integer
    'Private polyElementIndexNum As Integer
    Dim pressedButton As Boolean 'Last Edited here On 27 October 2017 at 2:49 PM

    'First initialize all components
    Private ListOfPoints As TPoint 'Represents the Linked List of points
    Private ListOfPolyElements As TElementPolygon 'Represents the Linked List of polygon's element
    Private HeadPolygon As TPolygon
    Dim PointNum As Integer = 1 'Number of points that have been inserted into the list
    Dim PolyElmtNum As Integer = 1
    Dim X1, Y1, X2, Y2 As Integer 'To store captured coordinates and leaving coordinates
    'mainCanvas resolution is 480x480

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Executed as soon as the form is loaded
        ' Set all local variables's default value
        ListOfPoints = Nothing
        ListOfPolyElements = Nothing
        HeadPolygon = Nothing
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        For i = 0 To MainCanvas.Width - 1
            For j = 0 To MainCanvas.Height - 1
                If (bitmapCanvas.GetPixel(i, j) <> Color.White) Then '<> is the same with !=
                    bitmapCanvas.SetPixel(i, j, Color.White)
                End If
            Next
        Next
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Function GetAbsolute(ByVal value As Integer) As Integer
        If (value < 0) Then
            value = value * -1
        End If
        Return value
    End Function

    Private Sub DrawLine(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) 'LAST EDITEDHERE - 27 October 2017 at 6:26 PM. YES I don't know the way to draw line if not using manual bitmap
        ' Let's use MidPoint Line Algorithm (try) -> Kinda buggy and ultra pixelated, I need to redefine it... ._. LAST EDITED HERE - Wednesday, 18 October 2017 @7:34 PM

        ' There are sixteen total cases in midpoint line algorithm -> Example using cartesian coordinates
        '   1. To the right                            ---                      deltaY = 0, x1 < x2 -> SetPixel(x1, y1, Color)
        '   2. To the left                             ---                      deltaY = 0, x1 > x2 -> SetPixel(-x1, y1, Color)
        '   3. To the top                              ---                      deltaX = 0, y1 < y2  -> SetPixel(x1, y1, Color)
        '   4. To the bottom                           ---                      deltaX = 0, y1 > y2 -> SetPixel(x1, -y1, Color)
        '   5. 45 degree to top right                  ---                      deltaX = deltaY, x1 < x2, y1 < y2 -> SetPixel(x1, y1, Color)
        '   6. 45 degree to bottom right               ---                      ABS(deltaX) = ABS(deltaY), x1 > x2, y1 > y2 -> SetPixel(x1, -y1, Color)
        '   7. 45 degree to bottom left                ---                      ABS(deltaX) =  ABS(deltaY), Mirrored X axis plot -> SetPixel(-x1, -y1, Color)
        '   8. 45 degree to top left                   ---                      deltaX = deltaY, Mirrored X axis plot -> SetPixel(-x1, y1, Color) --- LAST EDITED HERE, 29 October 2017 at 5:46 PM
        '   9. Somewhere between 1 - 44 degree right y-axis above x-axis   ---  deltaX > deltaY -> SetPixel(x1, y1, Color) -> Traverse x-axis
        '   10. Somewhere between 46 - 89 degree right y-axis above x-axis ---  deltaY > deltaX -> SetPixel(x1, y1, Color) -> Traverse y-axis
        '   11. Somewhere between 46 - 89 degree left y-axis above x-axis  ---  deltaY > deltaX -> SetPixel(-x1, y1, Color) -> Traverse y-axis
        '   12. Somewhere between 1 - 44 degree left y-axis above x-axis   ---  deltaX > deltaY -> SetPixel(-x1, y1, Color)-> Traverse x-axis
        '   13. Somewhere between 1 - 44 degree left y-axis below x-axis   ---  deltaX > deltaY -> SetPixel(-x1, -y1, Color) -> Traverse x-axis
        '   14. Somewhere between 46 - 89 degree left y-axis below x-axis  ---  deltaY > deltaX -> SetPixel(-x1, -y1, Color) -> Traverse y-axis
        '   15. Somewhere between 1 - 44 degree right y-axis below x-axis  ---  deltaY > deltaX -> SetPixel(x1, -y1, Color) -> Traverse y-axis
        '   16. Somewhere between 46 - 89 degree right y-axis below x-axis ---  deltaX > deltaY -> SetPixel(x1, -y1, Color) -> Traverse x-axis

        Dim deltaX As Integer = x2 - x1 'Differences between x1 and x2
        Dim deltaY As Integer = y2 - y1 'Differences between y1 and y2
        'Dim deltaRight As Integer = 2 * deltaY ' LAST EDITED HERE, 28 October 2017 at 5:27 PM   --- deltaRight is the interval 
        'Dim deltaUpperRight = 2 * (deltaY - deltaX) 'deltaUpperRight
        'MessageBox.Show(deltaX.ToString() & ", " & deltaY.ToString())

        If (deltaX <> 0 And deltaY = 0) Then 'Left and right
            If (x1 < x2) Then
                While x1 <= x2
                    bitmapCanvas.SetPixel(x1, y1, Color.Black)
                    x1 = x1 + 1
                End While
            Else
                While x1 >= x2
                    bitmapCanvas.SetPixel(x1, y1, Color.Black)
                    x1 = x1 - 1
                End While
            End If
        ElseIf (deltaX = 0 And deltaY <> 0) Then 'Up and down
            If (y1 < y2) Then
                While y1 <= y2
                    bitmapCanvas.SetPixel(x1, y1, Color.Black)
                    y1 = y1 + 1
                End While
            Else
                While y1 >= y2
                    bitmapCanvas.SetPixel(x1, y1, Color.Black)
                    y1 = y1 - 1
                End While
            End If
        ElseIf (GetAbsolute(deltaX) = GetAbsolute(deltaY)) Then '45 degree line
            If (x1 < x2 And y1 < y2) Then
                While x1 <= x2 And y1 <= y2
                    bitmapCanvas.SetPixel(x1, y1, Color.Black)
                    x1 = x1 + 1
                    y1 = y1 + 1
                End While
            Else
                While x1 >= x2 And y1 >= y2
                    bitmapCanvas.SetPixel(x1, y1, Color.Black)
                    x1 = x1 - 1
                    y1 = y1 - 1
                End While
            End If
        ElseIf (deltaX > deltaY) Then 'Diagonal not 45 degree (Case 9, 12, 13, 16)

        ElseIf (deltaY > deltaX) Then 'Diagonal not 45 degree (Case 10, 11, 14, 15)

        End If
        MainCanvas.Image = bitmapCanvas
    End Sub

    'Private Sub DrawRect(ByRef PolyElement As TElementPolygon, ByRef NextPolyElement As TElementPolygon) 'Draw clipping window
    '    Dim x1 As Integer = PolyElement.points.x 'Taken from the PolyElement
    '    Dim x2 As Integer = NextPolyElement.points.x 'Taken from the PolyElement.nextPoint
    '    Dim y1 As Integer = PolyElement.points.y
    '    Dim y2 As Integer = NextPolyElement.points.y

    '    If (x1 > x2) Then
    '        While (x1 >= x2)
    '            bitmapCanvas.SetPixel(x1, y1, Color.Black)
    '            x1 = x1 - 1
    '        End While
    '    End If
    '    MainCanvas.Image = bitmapCanvas
    'End Sub

    Private Function InsertPointNode(ByRef pointNode As TPoint, ByVal pointNum As Integer, ByVal x As Integer, ByVal y As Integer) As TPoint
        If (pointNode Is Nothing) Then 'Newly allocated
            pointNode = New TPoint
            pointNode.setCoordinates(x, y)
            pointNode.pointNum = pointNum
        Else 'Already allocated
            pointNode.nextPoint = InsertPointNode(pointNode.nextPoint, pointNode.pointNum + 1, x, y)
        End If
        Return pointNode
    End Function

    Private Sub InsertPolyElementNode(ByRef polyElement_Param As TElementPolygon, ByRef forHead As TElementPolygon, ByRef forTail As TElementPolygon, ByRef pointElement_Param As TPoint, ByVal x As Integer, ByVal y As Integer)
        'If (polyElement_Param Is Nothing) Then 'First node of poly element
        '    polyElement_Param = New TElementPolygon
        '    polyElement_Param.numOfPoints = 1
        '    polyElement_Param.points = InsertPointNode(polyElement_Param.points, x, y)
        '    polyElement_Param.nextPoint = Nothing
        '    forHead = polyElement_Param
        '    forTail = polyElement_Param
        'ElseIf (forTail IsNot Nothing And forTail.nextPoint Is Nothing) Then 'Last Node of poly element
        '    Dim temp As TElementPolygon
        '    temp = New TElementPolygon
        '    forTail.nextPoint = temp
        '    forTail = temp
        '    polyElement_Param.numOfPoints = polyElement_Param.numOfPoints + 1 'Number of points increased
        'End If
    End Sub

    'Private Function MakePolygon(ByRef Polygon_Param As TPolygon, ByRef PolygonElement_Param As TElementPolygon) As TPolygon 'Make a new polygon Last edited here on 27 October 2017 at 10:52 AM
    '    Return Polygon_Param
    'End Function

    'Private _Previous As System.Nullable(Of Point) = Nothing
    Private Sub MainCanvas_MouseDown(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseDown ' Mouse down, get the x, y coordinates
        X1 = e.X
        Y1 = e.Y
        ListOfPoints = InsertPointNode(ListOfPoints, PointNum, X1, Y1)
        pressedButton = True
        'points = InsertPointNode(points, e.X, e.Y)
        ' _Previous = e.Location
        'MainCanvas_MouseMove(sender, e)
    End Sub

    Private Sub AboutMeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutMeToolStripMenuItem.Click 'When you click the about me
        MessageBox.Show(
            "Sutherland and Hodgman Clipping demo ver. 0.1a" & vbNewLine & vbNewLine &
            "User Inteface" & vbTab & "1 Jonathan Surya" & vbNewLine & vbNewLine &
            "Coding" & vbTab & vbTab & "1 Kristoforus Kurniawan" & vbNewLine & vbTab & vbTab & "2 Ardy Wijaya", "About Me", MessageBoxButtons.OK)
    End Sub

    Private Sub SaveCtrlSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveCtrlSToolStripMenuItem.Click 'When you click save

    End Sub

    Private Sub OpenCtrlOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenCtrlOToolStripMenuItem.Click 'When you click open

    End Sub

    Private Sub MainCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinateLabel.Text = "X = " & e.X.ToString() & ", Y = " & e.Y.ToString()
        If (pressedButton) Then
            Dim tempX2 As Integer = e.X 'If the button is still pressed, store temporary X2
            Dim tempY2 As Integer = e.Y 'and y2 as current mouse position
            'Dim tempPoint As TPoint = Nothing
            'Dim PointF1, PointF2 As Point
            'tempPoint = InsertPointNode(tempPoint, ListOfPoints.pointNum + 1, tempX2, tempY2)
            'PointF1 = New Point
            'PointF2 = New Point
            'PointF1.X = ListOfPoints.x
            'PointF1.Y = ListOfPoints.y
            'PointF2.X = tempPoint.x
            'PointF2.Y = tempPoint.y

            '    Dim temporaryPoint2 As TPoint = Nothing
            '    temporaryPoint2 = InsertPointNode(temporaryPoint2, e.X, e.Y) 'Temporary point while mouse is moving
            '    Dim PointF1, PointF2 As Point
            '    PointF1 = New Point
            '    PointF2 = New Point
            '    PointF1.X = headPolyElement.points.x
            '    PointF1.Y = headPolyElement.points.y
            '    PointF2.X = temporaryPoint2.x
            '    PointF2.Y = temporaryPoint2.y
            '    Using myGraphics As Graphics = Graphics.FromImage(MainCanvas.Image)
            '        myGraphics.DrawLine(myPen, PointF1, PointF2)
            '        MainCanvas.Invalidate()
            '        PointF1 = PointF2
            '    End Using
        End If
        'If _Previous IsNot Nothing Then
        '    If MainCanvas.Image Is Nothing Then
        '        Dim bmp As New Bitmap(MainCanvas.Width, MainCanvas.Height)
        '        Using g As Graphics = Graphics.FromImage(bmp)
        '            g.Clear(Color.White)
        '        End Using
        '        MainCanvas.Image = bmp
        '    End If
        '    Using g As Graphics = Graphics.FromImage(MainCanvas.Image)
        '        g.DrawLine(Pens.Black, _Previous.Value, e.Location)
        '    End Using
        '    MainCanvas.Invalidate()
        '    _Previous = e.Location
        'End If
    End Sub

    Private Sub MainCanvas_MouseUp(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseUp 'Get the final position from mouse, draw on bitmapCanvas
        X2 = e.X 'Store second
        Y2 = e.Y
        PointNum = PointNum + 1
        ListOfPoints = InsertPointNode(ListOfPoints, PointNum, X2, Y2)
        pressedButton = False
        'MessageBox.Show(X1.ToString() & ", " & Y1.ToString() & ", " & X2.ToString() & ", " & Y2.ToString())
        DrawLine(X1, Y1, X2, Y2)
        'Dim PointF1, PointF2 As Point

        'Using myGraphics As Graphics = Graphics.FromImage(bitmapCanvas)
        '    While (ListOfPoints IsNot Nothing)
        '        PointF1.X = ListOfPoints.x
        '        PointF1.Y = ListOfPoints.y
        '        PointF2.X = X2
        '        PointF2.Y = Y2
        '        myGraphics.DrawLine(myPen, PointF1, PointF2)
        '        MainCanvas.Invalidate()
        '        ListOfPoints = ListOfPoints.nextPoint
        '        'ListOfPoints.nextPoint = ListOfPoints.nextPoint.nextPoint
        '    End While
        'End Using
        'If (ListOfPoints IsNot Nothing) Then
        '    MessageBox.Show("PointList is not nothing")
        'Else
        '    MessageBox.Show("PointList is still nothing")
        'End If
        'headPolyElement.nextPoint = InsertPolyElementNode(headPolyElement.nextPoint, points, e.X, e.Y) 'Last edited here on 26 October 2017 at 10:53 PM  --- Insert end point of the line into poly element
        '_Previous = Nothing
    End Sub

    Private Sub ButtonFinishPolygon_Click(sender As Object, e As EventArgs) Handles ButtonFinishPolygon.Click 'When this button is clicked, Traverse through all polygon points and make one new polygon
        While ListOfPoints IsNot Nothing
            MessageBox.Show("Point " & ListOfPoints.pointNum.ToString() & " X = " & ListOfPoints.x.ToString() & ", Y = " & ListOfPoints.y.ToString())
            ListOfPoints = ListOfPoints.nextPoint
        End While
        'If (headPolyElement IsNot Nothing) Then
        '    MessageBox.Show("Not Nothing")
        'Else
        '    MessageBox.Show("Still Nothing")
        'End If
    End Sub

End Class
