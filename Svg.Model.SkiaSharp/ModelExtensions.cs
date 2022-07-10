using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalSkiaSharp = SkiaSharp;

namespace Svg.Model;

internal static class ModelExtensions
{
    public static GlobalSkiaSharp.SKPath? ToSKPath(this ClipPath clipPath)
    {
        if (clipPath.Clips is null) return null;

        var skPathResult = default(GlobalSkiaSharp.SKPath);

        foreach (var clip in clipPath.Clips)
        {
            if (clip.Path is null) return null;

            var skPath = clip.Path;
            var skPathClip = clip.Clip?.ToSKPath();
            if (skPathClip is { }) skPath = skPath.Op(skPathClip, GlobalSkiaSharp.SKPathOp.Intersect);

            if (clip.Transform is { })
            {
                var skMatrix = clip.Transform.Value;
                skPath.Transform(skMatrix);
            }

            if (skPathResult is null)
            {
                skPathResult = skPath;
            }
            else
            {
                var result = skPathResult.Op(skPath, GlobalSkiaSharp.SKPathOp.Union);
                skPathResult = result;
            }
        }

        if (skPathResult is { })
        {
            if (clipPath.Clip?.Clips is { })
            {
                var skPathClip = clipPath.Clip.ToSKPath();
                if (skPathClip is { }) skPathResult = skPathResult.Op(skPathClip, GlobalSkiaSharp.SKPathOp.Intersect);
            }

            if (clipPath.Transform is { })
            {
                var skMatrix = clipPath.Transform.Value;
                skPathResult.Transform(skMatrix);
            }
        }

        return skPathResult;
    }

    public static void Draw(this GlobalSkiaSharp.SKCanvas canvas, ClipPath clipPath, SKClipOperation clipOperation, bool isAntialias)
    {
        var path = clipPath.ToSKPath();
        if (path == null) return;
        canvas.ClipPath(path, clipOperation, isAntialias);
    }
}
