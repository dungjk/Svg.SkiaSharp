using SkiaSharp;
using Svg.Skia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    internal static class SvgConverter
    {
        public static void ConvertSvg(Stream outputStream, Stream svgStream, float scale)
        {

            using (var svg = new SKSvg())
            {
                if (svg.Load(svgStream) is { })
                {
                    svg.Save(outputStream, SKColors.White, SKEncodedImageFormat.Png, 100, scale, scale);
                }
            }
        }
    }
}
