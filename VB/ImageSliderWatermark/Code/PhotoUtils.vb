Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO

Public Class PhotoUtils
    Public Shared Function Inscribe(ByVal image As Image, ByVal size As Integer) As Image
        Return Inscribe(image, size, size)
    End Function
    Public Shared Function Inscribe(ByVal image As Image, ByVal width As Integer, ByVal height As Integer) As Image
        Dim result As New Bitmap(width, height)
        Using graphics As Graphics = Graphics.FromImage(result)
            Dim factor As Double = 1.0 * width / image.Width
            If image.Height * factor < height Then
                factor = 1.0 * height / image.Height
            End If
            Dim size As New Size(CInt(Fix(width / factor)), CInt(Fix(height / factor)))
            Dim sourceLocation As New Point((image.Width - size.Width) / 2, (image.Height - size.Height) / 2)

            SmoothGraphics(graphics)
            graphics.DrawImage(image, New Rectangle(0, 0, width, height), New Rectangle(sourceLocation, size), GraphicsUnit.Pixel)
        End Using
        Return result
    End Function
    Public Shared Function GetReducedImage(ByVal image As Image, ByVal extremeWidth As Integer, ByVal extremeHeight As Integer) As Image
        Dim ratio As Double = CDbl(image.Width) / CDbl(image.Height)
        Dim size As New Size(extremeWidth, CInt(Fix(extremeWidth / ratio)))
        If size.Height > extremeHeight Then
            size = New Size(CInt(Fix(extremeHeight * ratio)), extremeHeight)
        End If
        Return New Bitmap(image, size)
    End Function
    Public Shared Sub DrawWatermarkText(ByVal image As Image, ByVal text As String)
        DrawWatermarkText(image, text, "Arial")
    End Sub
    Public Shared Sub DrawWatermarkText(ByVal image As Image, ByVal text As String, ByVal fontName As String)
        Using graphics As Graphics = CreateGraphics(image)
            DrawWatermarkText(graphics, text, fontName)
        End Using
    End Sub
    Public Shared Sub DrawWatermarkText(ByVal graphics As Graphics, ByVal text As String, ByVal fontName As String)
        Dim imageHeight As Integer = CInt(Fix(graphics.VisibleClipBounds.Height))
        Dim imageWidth As Integer = CInt(Fix(graphics.VisibleClipBounds.Width))
        Dim maxTextWidth As Integer = CInt(Fix(imageHeight * 0.4))
        Dim fontSizes() As Integer = {72, 48, 36, 24, 18, 18, 14, 12, 10}
        Dim font As Font = Nothing
        For Each fontSize As Integer In fontSizes
            font = New Font(fontName, fontSize, GraphicsUnit.Pixel)
            If graphics.MeasureString(text, font).Width <= maxTextWidth Then
                Exit For
            End If
        Next fontSize
        Dim state As GraphicsState = graphics.Save()
        SmoothGraphics(graphics)
        graphics.RotateTransform(-90)
        Dim padding As Single = font.Size / 2
        graphics.TranslateTransform(-imageHeight + padding, imageWidth - font.GetHeight() - padding)
        graphics.TextContrast = 12
        graphics.PageUnit = font.Unit
        graphics.DrawString(text, font, New SolidBrush(Color.FromArgb(120, Color.Black)), 1, 1)
        graphics.DrawString(text, font, New SolidBrush(Color.FromArgb(120, Color.White)), 0, 0)
        graphics.Restore(state)
    End Sub
    Private Shared Sub SmoothGraphics(ByVal g As Graphics)
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
    End Sub
    Private Shared Function CreateGraphics(ByVal image As Image) As Graphics
        image = If(IsIndexedPixelFormat(image.PixelFormat), ConvertIndexedBitmapToARGB(image), image)
        Dim graphics As Graphics = Graphics.FromImage(image)
        SmoothGraphics(graphics)
        Return graphics
    End Function
    Private Shared Function IsIndexedPixelFormat(ByVal pixelFormat As PixelFormat) As Boolean
        Select Case pixelFormat
            Case PixelFormat.Format1bppIndexed
                Return True
            Case PixelFormat.Format4bppIndexed
                Return True
            Case PixelFormat.Format8bppIndexed
                Return True
            Case PixelFormat.Indexed
                Return True
            Case Else
                Return False
        End Select
    End Function
    Private Shared Function ConvertIndexedBitmapToARGB(ByVal image As Image) As Bitmap
        Dim result As New Bitmap(image.Width, image.Height)
        Using g As Graphics = Graphics.FromImage(result)
            g.DrawImage(image, New Rectangle(0, 0, result.Width, result.Height), 0, 0, result.Width, result.Height, GraphicsUnit.Pixel)
            Return result
        End Using
    End Function
    Public Shared Sub SaveToJpeg(ByVal image As Image, ByVal output As Stream)
        image.Save(output, ImageFormat.Jpeg)
    End Sub
    Public Shared Sub SaveToJpeg(ByVal image As Image, ByVal fileName As String)
        image.Save(fileName, ImageFormat.Jpeg)
    End Sub
End Class
