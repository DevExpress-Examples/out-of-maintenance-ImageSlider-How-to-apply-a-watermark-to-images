
# ImageSlider - How to apply a watermark to images

*Files to look at:*
* [HomeController.cs](https://github.com/DevExpress-Examples/ImageSlider-How-to-apply-a-watermark-to-images/blob/17.1.2%2B/CS/ImageSliderWithWatermark/Controllers/HomeController.cs) ([VB](https://github.com/DevExpress-Examples/ImageSlider-How-to-apply-a-watermark-to-images/blob/17.1.2%2B/VB/ImageSliderWatermark/Controllers/HomeController.vb))
* [Views/Home/Index.cshtml](https://github.com/DevExpress-Examples/ImageSlider-How-to-apply-a-watermark-to-images/blob/17.1.2%2B/CS/ImageSliderWithWatermark/Views/Home/Index.cshtml) ([VB](https://github.com/DevExpress-Examples/ImageSlider-How-to-apply-a-watermark-to-images/blob/17.1.2%2B/VB/ImageSliderWatermark/Views/Home/Index.vbhtml))
* [Code/ImageHelper.cs](https://github.com/DevExpress-Examples/ImageSlider-How-to-apply-a-watermark-to-images/blob/17.1.2%2B/CS/ImageSliderWithWatermark/Code/ImageHelper.cs) ([VB](https://github.com/DevExpress-Examples/ImageSlider-How-to-apply-a-watermark-to-images/blob/17.1.2%2B/VB/ImageSliderWatermark/Code/ImageHelper.vb))
* [Code/PhotoUtils.cs](https://github.com/DevExpress-Examples/ImageSlider-How-to-apply-a-watermark-to-images/blob/17.1.2%2B/CS/ImageSliderWithWatermark/Code/PhotoUtils.cs) ([VB](https://github.com/DevExpress-Examples/ImageSlider-How-to-apply-a-watermark-to-images/blob/17.1.2%2B/VB/ImageSliderWatermark/Code/PhotoUtils.vb))

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