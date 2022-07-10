using Svg.Skia;
using SkiaSharp;

var scale = 5f;

using (var svg = new SKSvg())
{
    if (svg.Load("./test-svg/text-01.svg") is { })
    {
        using (var stream = System.IO.File.OpenWrite("./png/text-01.png"))
        {
            svg.Save(stream, SKColors.White, SKEncodedImageFormat.Png, 100, scale, scale);
        }
    }
}

Console.WriteLine("Converted!");
