# Svg.SkiaSharp

Svg.SkiaSharp ia an [SVG](https://en.wikipedia.org/wiki/Scalable_Vector_Graphics) rendering library.
The code is port of awesome library [Svg.Skia](https://github.com/wieslawsoltes/Svg.Skia) with some addition fixs, focus on using [SkiaSharp](https://github.com/mono/SkiaSharp) without using ShimSkiaSharp as original version.  

# Usage

#### Draw on Canvas

```C#
using SkiaSharp;
using Svg.Skia;

var svg = new SKSvg();

svg.Load("image.svg");

SKCanvas canvas = ...
canvas.DrawPicture(svg.Picture);
```

#### Save as Png

```C#
using SkiaSharp;
using Svg.Skia;

using (var svg = new SKSvg())
{
    if (svg.Load("image.svg") is { })
    {
        svg.Save("image.png", SKEncodedImageFormat.Png, 100, 1f, 1f);
    }
}
```

```C#
using System.IO;
using SkiaSharp;
using Svg.Skia;

using (var svg = new SKSvg())
{
    if (svg.Load("image.svg") is { })
    {
        using (var stream = File.OpenWrite("image.png"))
        {
            svg.Picture.ToImage(stream, SKColors.Empty, SKEncodedImageFormat.Png, 100, 1f, 1f);
        }
    }
}
```

```C#
using SkiaSharp;
using Svg.Skia;

using (var svg = new SKSvg())
{
    if (svg.Load("image.svgz") is { })
    {
        svg.Save("image.png", SKEncodedImageFormat.Png, 100, 1f, 1f);
    }
}
```

```C#
using System.IO;
using SkiaSharp;
using Svg.Skia;

using (var svg = new SKSvg())
{
    if (svg.Load("image.svgz") is { })
    {
        using (var stream = File.OpenWrite("image.png"))
        {
            svg.Picture.ToImage(stream, SKColors.Empty, SKEncodedImageFormat.Png, 100, 1f, 1f);
        }
    }
}
```

#### Save as Pdf

```C#
using SkiaSharp;
using Svg.Skia;

using (var svg = new SKSvg())
{
    if (svg.Load("image.svg") is { })
    {
        svg.Picture.ToPdf("image.pdf", SKColors.Empty, 1f, 1f);
    }
}
```

#### Save as Xps

```C#
using SkiaSharp;
using Svg.Skia;

using (var svg = new SKSvg())
{
    if (svg.Load("image.svg") is { })
    {
        svg.Picture.ToXps("image.xps", SKColors.Empty, 1f, 1f);
    }
}
```