@Code
    ViewData("Title") = "Watermark sample"
End Code

<script type="text/javascript">
    function onValueChanged(s, e) {
        $("#submitForm").submit();
    }
</script>

<div id="submitDiv">
    @Using Ajax.BeginForm("Index", "Home", New AjaxOptions With {
        .HttpMethod = "Post",
        .UpdateTargetId = "submitDiv",
        .InsertionMode = InsertionMode.Replace},
        New With {.id = "submitForm"})
@Html.DevExpress().CheckBox(Sub(settings)
                                     settings.Name = "ApplyWatermarkCheckBox"
                                     settings.Text = "Apply watermark:"
                                     settings.Properties.ClientSideEvents.ValueChanged = "onValueChanged"
                                     settings.Checked = CType(ViewData("isWatermarkApplied"), Boolean)
                                 End Sub).GetHtml()

@Html.DevExpress().ImageSlider(Sub(settings)
                                        settings.Name = "ImageSlider"
                                        settings.ShowNavigationBar = True
                                        settings.SetItemTemplateContent(Sub(t)
                                                                            If (CType(ViewData("isWatermarkApplied"), Boolean)) Then
                                                                                Html.DevExpress().BinaryImage(Sub(bi)
                                                                                                                  Dim image As Byte() = ImageSliderWatermark.ImageHelper.GetImageWithWatermark(
                                                                                      t.EvalDataItem("ImageUrl").ToString(),
                                                                                      "ImageSlider",
                                                                                      "Arial"
                                                                                      )
                                                                                                                  bi.ContentBytes = image
                                                                                                              End Sub).Render()
                                                                            Else
                                                                                Html.DevExpress().Image(Sub(i)
                                                                                                            i.ImageUrl = t.EvalDataItem("ImageUrl").ToString()
                                                                                                        End Sub).Render()
                                                                            End If
                                                                        End Sub)
                                    End Sub).BindToXML(Server.MapPath("~/App_Data/landscapes.xml"), "//items/*").GetHtml()
    End Using
</div>