using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;

namespace GAG.Drawing
{
    public class TimeSeriesPage : Control
    {
        public TimeSeriesPage()
        {
            ClipToBounds = true;
        }

        public override void Render(DrawingContext context)
        {
            var noSkia = new FormattedText()
            {
                Text = "Current rendering API is not Skia"
            };
            context.Custom(new CustomDrawOp(new Rect(0, 0, Bounds.Width, Bounds.Height), noSkia));
            Dispatcher.UIThread.InvokeAsync(InvalidateVisual, DispatcherPriority.Background);
        }
    }
}
