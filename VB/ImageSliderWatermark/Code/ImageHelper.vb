Imports System.IO
Imports System.Drawing

Public Class ImageHelper
    Private Shared Function GetImageFromUrl(ByVal url As String) As Image
        Dim image = Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(url))
        Return image
    End Function

    Private Shared Function ImageToByteArray(ByVal image As Image) As Byte()
        Using ms = New MemoryStream()
            image.Save(ms, image.RawFormat)
            Return ms.ToArray()
        End Using
    End Function

    Public Shared Function GetImageWithWatermark(ByVal url As String, ByVal text As String, ByVal fontName As String) As Byte()
        Dim image = GetImageFromUrl(url)
        PhotoUtils.DrawWatermarkText(image, text, fontName)
        Return ImageToByteArray(image)
    End Function
End Class
