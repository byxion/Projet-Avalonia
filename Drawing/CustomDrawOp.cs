using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Rendering.SceneGraph;
using Avalonia.Skia;
using SkiaSharp;

namespace GAG.Drawing
{
    class CustomDrawOp : ICustomDrawOperation
    {
        private readonly FormattedText _noSkia;

        public CustomDrawOp(Rect bounds, FormattedText noSkia)
        {
            _noSkia = noSkia;
            Bounds = bounds;
        }

        public void Dispose()
        {
            // No-op
        }

        public Rect Bounds { get; }
        public bool HitTest(Point p) => false;
        public bool Equals(ICustomDrawOperation other) => false;
        public void Render(IDrawingContextImpl context)
        {
            var canvas = (context as ISkiaDrawingContextImpl)?.SkCanvas;
            if (canvas == null)
                context.DrawText(Brushes.Black, new Point(), _noSkia.PlatformImpl);
            else
            {
                canvas.Save();

                SKPaint solidForeground = new SKPaint
                {
                    Color = new SKColor(0, 0, 0),
                    //TextSize = 25.0f,
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 1,
                    IsAntialias = true
                };

                float canvasWidth = canvas.LocalClipBounds.Width;
                float canvasHeight = canvas.LocalClipBounds.Height;

                CustomPoint initPoint = new CustomPoint(50, 110);

                int w = 50;

                int h = 40;

                //CustomPoint initPoint = new CustomPoint(70, 130);

                //int w = 70;

                //int h = 60;

                // Etape
                canvas.DrawRect(initPoint.X, initPoint.Y, w, h, solidForeground);

                // Contenu Etatpe
                CustomPoint stepTextPoint = new CustomPoint(initPoint.X + (w / 2) - 4, initPoint.Y + (h / 2) + 4);
                canvas.DrawText("1", stepTextPoint.X, stepTextPoint.Y, solidForeground);

                // Lien vers action
                CustomPoint actionLinePoint1 = new CustomPoint(initPoint.X + w, initPoint.Y + (h / 2));
                CustomPoint actionLinePoint2 = new CustomPoint(actionLinePoint1.X + 6 * w, actionLinePoint1.Y);
                canvas.DrawLine(actionLinePoint1.X, actionLinePoint1.Y, actionLinePoint2.X, actionLinePoint2.Y, solidForeground);

                // Lien vers transition
                CustomPoint transitionLinePoint1 = new CustomPoint(stepTextPoint.X, initPoint.Y + h);
                CustomPoint transitionLinePoint2 = new CustomPoint(transitionLinePoint1.X, 7 * h);
                canvas.DrawLine(transitionLinePoint1.X, transitionLinePoint1.Y, transitionLinePoint2.X, transitionLinePoint2.Y, solidForeground);

                // Lien vers condition
                CustomPoint conditionLinePoint1 = new CustomPoint(transitionLinePoint2.X, transitionLinePoint2.Y);
                CustomPoint conditionLinePoint2 = new CustomPoint(4 * w, conditionLinePoint1.Y);
                canvas.DrawLine(conditionLinePoint1.X, conditionLinePoint1.Y, conditionLinePoint2.X, conditionLinePoint2.Y, solidForeground);

                // Lien vers autre étape
                CustomPoint nextStepLinePoint1 = transitionLinePoint2;
                CustomPoint nextStepLinePoint2 = new CustomPoint(nextStepLinePoint1.X, 7 * h);
                canvas.DrawLine(nextStepLinePoint1.X, nextStepLinePoint1.Y, nextStepLinePoint2.X, nextStepLinePoint2.Y, solidForeground);

                canvas.Restore();
            }
        }
    }
}
