Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        ViewData("isWatermarkApplied") = True
        Return View()
    End Function

    <HttpPost>
    Public Function Index(ByVal applyWatermarkCheckBox As Boolean?) As ActionResult
        ViewData("isWatermarkApplied") = applyWatermarkCheckBox
        Return View()
    End Function
End Class