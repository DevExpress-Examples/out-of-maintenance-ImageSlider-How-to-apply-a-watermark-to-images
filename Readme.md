<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/147413168/17.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830526)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# ImageSlider - How to apply a watermark to images
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/147413168/)**
<!-- run online end -->

*Files to look at:*
* [HomeController.cs](./CS/ImageSliderWithWatermark/Controllers/HomeController.cs) ([VB](./VB/ImageSliderWatermark/Controllers/HomeController.vb))
* [Views/Home/Index.cshtml](./CS/ImageSliderWithWatermark/Views/Home/Index.cshtml) ([VB](./VB/ImageSliderWatermark/Views/Home/Index.vbhtml))
* [Code/ImageHelper.cs](./CS/ImageSliderWithWatermark/Code/ImageHelper.cs) ([VB](./VB/ImageSliderWatermark/Code/ImageHelper.vb))
* [Code/PhotoUtils.cs](./CS/ImageSliderWithWatermark/Code/PhotoUtils.cs) ([VB](./VB/ImageSliderWatermark/Code/PhotoUtils.vb))

This example illustrates how to apply a watermark to images displayed in **ImageSlider**. Although ImageSlider does not provide the functionality to apply watermarks out of the box, this task can be done by creating an item template that contains the BinaryImage extension. The main idea is to create [**System.Drawing.Image**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image?view=netframework-4.7.2) and [**System.Drawing.Graphics**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics?view=netframework-4.7.2) instances from images, apply a watermark to the Graphics instance, and then convert the resulting image to an array of bytes. The **PhotoUtils** and **ImageHelper** classes are used for this.
```csharp
Html.DevExpress().BinaryImage(bi =>
{
    byte[] image = ImageSliderWithWatermark.Code.ImageHelper.GetImageWithWatermark(
        t.EvalDataItem("ImageUrl").ToString(),
        "ImageSlider",
        "Arial"
        );
    bi.ContentBytes = image;
}).Render();
```
```vbnet
Html.DevExpress().BinaryImage(Sub(bi)
	Dim image As Byte() = ImageSliderWatermark.ImageHelper.GetImageWithWatermark(
		t.EvalDataItem("ImageUrl").ToString(),
		"ImageSlider",
		"Arial")
bi.ContentBytes = image
End Sub).Render()
```
