Public Class MainForm

    Private myPen As Pen
    Private myGraphics As Graphics
    Private points As TPoint = New TPoint
    Private polygon As TPolygon = Nothing
    Private headPolygon As TPolygon = Nothing
    Private tailPolygon As TPolygon = Nothing
    Private polyElement As TElementPolygon = Nothing
    Private xPos, yPos, i, j As Double
    Private polyIndexNum As Integer
    

    'mainCanvas resolution is 480x480

    Private Sub ButtonCopy_Click(sender As Object, e As EventArgs) Handles ButtonCopy.Click

    End Sub

    Private Sub ButtonCut_Click(sender As Object, e As EventArgs) Handles ButtonCut.Click

    End Sub

    Private Sub ButtonPaste_Click(sender As Object, e As EventArgs) Handles ButtonPaste.Click

    End Sub

    Private Sub DrawDot(ByVal x As Integer, ByVal y As Integer)
        bitmapCanvas.SetPixel(x, y, Color.Black)
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub DrawLine(ByRef PolyElement As TElementPolygon, ByRef NextPolyElement As TElementPolygon)
        'MessageBox.Show("X1 = " & PolyElement.points.x.ToString() & ", Y1 = " & PolyElement.points.y.ToString() & ", X2 = " & PolyElement.nextPoint.points.x.ToString() & ", Y2 = " & PolyElement.nextPoint.points.y.ToString())
        Dim x1 As Integer = PolyElement.points.x 'Taken from the PolyElement
        Dim x2 As Integer = NextPolyElement.points.x 'Taken from the PolyElement.nextPoint
        Dim y1 As Integer = PolyElement.points.y
        Dim y2 As Integer = NextPolyElement.points.y

        CoordinateLabel.Text = "X1 = " & x1.ToString() & ", Y1 = " & y1.ToString()
        CoordinateLabel2.Text = "X2 = " & x2.ToString() & ", Y2 = " & y2.ToString()

        ' Let's use DDA (try) -> Kinda buggy and ultra pixelated ._. LAST EDITED HERE - Wednesday, 18 October 2017 @7:34 PM

        If (x1 = x2 And y1 < y2) Then ' Vertical Line Down
            For y1 = y1 To y2
                bitmapCanvas.SetPixel(x1, y1, Color.Black)
            Next
        ElseIf (x1 = x2 And y1 > y2) Then ' Vertical Line Up
            For y1 = y1 To y2 Step -1
                bitmapCanvas.SetPixel(x1, y1, Color.Black)
            Next
        ElseIf (x1 < x2 And y1 = y2) Then ' Horizontal left to right
            For x1 = x1 To x2
                bitmapCanvas.SetPixel(x1, y1, Color.Black)
            Next
        ElseIf (x1 > x2 And y1 = y2) Then ' Horizontal right to left
            For x1 = x1 To x2 Step -1
                bitmapCanvas.SetPixel(x1, y1, Color.Black)
            Next
        ElseIf (x1 < x2 And y1 < y2) Then ' Diagonal top left to bottom right
            Dim m As Decimal = (y2 - y1) / (x2 - x1)
            For x1 = x1 To x2
                bitmapCanvas.SetPixel(x1, Math.Round(y1), Color.Black)
                y1 = y1 + m
            Next
        ElseIf (x1 > x2 And y1 < y2) Then 'Diagonal top right to bottom left
            Dim m As Decimal = (y2 - y1) / (x2 - x1)
            For x1 = x1 To x2 Step -1
                bitmapCanvas.SetPixel(x1, Math.Round(y1), Color.Black)
                y1 = y1 - m
            Next
        ElseIf (x1 < x2 And y1 > y2) Then 'Diagonal middle lower left area to middle upper right area
            Dim m As Decimal = (y2 - y1) / (x2 - x1)
            For x1 = x1 To x2
                bitmapCanvas.SetPixel(x1, Math.Round(y1), Color.Black)
                y1 = y1 + m
            Next
        ElseIf (x1 > x2 And y1 > y2) Then 'Diagonal from bottom right to top left
            Dim m As Decimal = (y2 - y1) / (x2 - x1)
            For x1 = x1 To x2 Step -1
                bitmapCanvas.SetPixel(x1, Math.Round(y1), Color.Black)
                y1 = y1 - m
            Next
        End If

        'MessageBox.Show("x1 = " & x1.ToString() & ", y1 = " & y1.ToString() & ", x2 = " & x2.ToString() & ", y2 = " & y2.ToString())
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub DrawRect(ByRef PolyElement As TElementPolygon, ByRef NextPolyElement As TElementPolygon) 'Draw clipping window
        Dim x1 As Integer = PolyElement.points.x 'Taken from the PolyElement
        Dim x2 As Integer = NextPolyElement.points.x 'Taken from the PolyElement.nextPoint
        Dim y1 As Integer = PolyElement.points.y
        Dim y2 As Integer = NextPolyElement.points.y

        If (x1 > x2) Then
            While (x1 >= x2)
                bitmapCanvas.SetPixel(x1, y1, Color.Black)
                x1 = x1 - 1
            End While
        End If
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Function PolygonInsertion(ByRef point As TPolygon, ByRef PolyElements As TElementPolygon) As TPolygon 'Insert poly elements to polygon
        If (point Is Nothing) Then
            point = New TPolygon
            point.PolyLine = PolyElements
            point.nextPolygon = Nothing
            'point.PolyIndex = indexNum + 1 'Last edited here today 7:02 AM
        Else
            point.nextPolygon = PolygonInsertion(point.nextPolygon, PolyElements)
            'Insertion(point, x, y)
        End If
        Return point
    End Function

    Dim i1 As Integer = 0
    Dim j1 As Integer = 0

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        While (i1 < MainCanvas.Width)
            While (j1 < MainCanvas.Height)
                If (Not bitmapCanvas.GetPixel(i1, j1) = Color.White) Then
                    bitmapCanvas.SetPixel(i1, j1, Color.White)
                End If
                j1 = j1 + 1
            End While
            i1 = i1 + 1
        End While
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Function PolyElementInsertion(ByRef Elements As TElementPolygon, ByRef points As TPoint, ByVal forX As Integer, ByVal forY As Integer) As TElementPolygon 'Insertion method for poly element
        If (Elements Is Nothing) Then
            Elements = New TElementPolygon
            Elements.points = New TPoint
            Elements.numOfPoints = Elements.numOfPoints + 1
            Elements.points.setCoordinates(forX, forY)
            Elements.nextPoint = Nothing
        Else
            Elements.numOfPoints = Elements.numOfPoints + 1
            Elements.nextPoint = PolyElementInsertion(Elements.nextPoint, points, forX, forY)
        End If
        Return Elements
    End Function

    Private Sub MainCanvas_Click(sender As Object, e As MouseEventArgs) Handles MainCanvas.Click 'Last edited here.
        'MessageBox.Show(e.X.ToString() & ", " & e.Y.ToString())
        'points.setCoordinates(e.X, e.Y) 'Create points (TPoint) from the mouse position
        polyElement = PolyElementInsertion(polyElement, points, e.X, e.Y) 'Create PolyElement (TElementPolygon)
        If (polyElement.numOfPoints > 1) Then ' Triggerred when we have two or more points
            DrawLine(polyElement, polyElement.nextPoint)
            polyElement = polyElement.nextPoint
        End If
        'polygon = PolygonInsertion(polygon, polyElement)        
        'MessageBox.Show("x1 = " & x1.ToString() & ", y1 = " & y1.ToString() & ", x2 = " & x2.ToString() & ", y2 = " & y2.ToString())
    End Sub
End Class
