using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;

namespace Benchmark
{
    [MemoryDiagnoser]
    [NativeMemoryProfiler]
    [ThreadingDiagnoser]
    [SimpleJob(launchCount: 5, warmupCount: 5, targetCount: 30)]
    [RPlotExporter]
    public class SVGToPNGBenchmark
    {
        [Benchmark]
        public void SvgSkia()
        {
            using (var stream = new MemoryStream())
            using (var svgStream = System.IO.File.OpenRead("E:/Svg.SkiaSharp/Benchmark/test-svg/sample01.svg"))
            {

                SvgConverter.ConvertSvg(stream, svgStream, 5f);
            }
        }
    }
}
