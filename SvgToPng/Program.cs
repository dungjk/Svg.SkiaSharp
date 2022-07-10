using Svg.Skia;
using SkiaSharp;

var scale = 5f;

using (var svg = new SKSvg())
{
  if (svg.Load("./test-svg/sample01.svg") is { })
  {
    using (var stream = System.IO.File.OpenWrite("./png/sample01.png"))
    {
      svg.Save(stream, SKColors.White, SKEncodedImageFormat.Png, 100, scale, scale);
    }
  }
}

using (var svg = new SKSvg())
{
  if (svg.Load("./test-svg/sample01.svg") is { })
  {
    svg.Picture?.ToPdf("./sample01.pdf", SKColors.White, 5f, 5f);
  }
}

Console.WriteLine("Converted!");
