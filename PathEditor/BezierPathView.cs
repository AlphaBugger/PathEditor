using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace PathEditor
{
    public class BezierPathView : GraphicsView
    {
        public BezierPathView()
        {
            Drawable = new BezierPathDrawable();
        }
    }

    public class BezierPathDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            // Clear the background
            canvas.FillColor = Colors.White;
            canvas.FillRectangle(dirtyRect);

            // Draw a cubic Bezier curve
            //DrawCircle(canvas);

            // Uncomment to test other paths
            DrawQuadraticBezierCurve(canvas);
            //DrawRoundedRect(canvas);
        }

        private void DrawCircle(ICanvas canvas)
        {
            canvas.StrokeColor = Colors.Green;
            canvas.StrokeSize = 2;

            var center = new PointF(275, 250);
            var radius = 100;

            // Create and configure the path for the circle
            using (var path = new PathF())
            {
                path.AppendCircle(center, radius);

                canvas.DrawPath(path);
            }
        }


        private void DrawQuadraticBezierCurve(ICanvas canvas)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 2;

            var startPoint1 = new PointF(325, 200);
            var endPoint1 = new PointF(475, 375);
            var controlPoint1 = new PointF(375, 200);
            var controlPoint1_2 = new PointF(325, 375);


            var startPoint2 = new PointF(475, 375);
            var endpoint2 = new PointF(625,200);
            var controlPoint2 = new PointF(625, 375);
            var controlPoint2_2 = new PointF(575, 200);

            var navPointTopRight = new PointF(1000, 200);
            var navPointBotRight = new PointF(1000, 600);
            var navPointTopLeft = new PointF(100, 200);
            var navPointBotLeft = new PointF(100, 600);


            var center = new PointF(475, 250);
            var radius = 100;

            // Create and configure the path for the circle
            using (var path = new PathF())
            {
                path.AppendCircle(center, radius);

                canvas.DrawPath(path);
            }

            // Create and configure the path for the quadratic Bezier curve
            using (var path = new PathF())
            {
                path.MoveTo(navPointTopLeft);
                path.LineTo(startPoint1);
                path.MoveTo(startPoint1);
                path.CurveTo(controlPoint1, controlPoint1_2, endPoint1);
                path.MoveTo(startPoint2);
                path.CurveTo(controlPoint2, controlPoint2_2, endpoint2);
                path.MoveTo(endpoint2);
                path.LineTo(navPointTopRight);
                path.LineTo(navPointBotRight);
                path.LineTo(navPointBotLeft);
                path.LineTo(navPointTopLeft);

                canvas.DrawPath(path);
            }
        }

        private void DrawRoundedRect(ICanvas canvas)
        {
            canvas.StrokeColor = Colors.Blue;
            canvas.StrokeSize = 2;

            var rect = new RectF(50, 50, 200, 100);
            var cornerRadius = 20;

            // Create and configure the path for the rounded rectangle
            using (var path = new PathF())
            {
                path.AppendRoundedRectangle(rect, cornerRadius); // Correct method for rounded rectangle

                canvas.DrawPath(path);
            }
        }
    }
}
