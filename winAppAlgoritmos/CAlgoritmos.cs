using System;
using System.Collections.Generic;
using System.Drawing;

namespace winAppAlgoritmos
{
    public class CAlgoritmos
    {
        private Bitmap lienzo;
        private Color colorActual;

        public CAlgoritmos(Bitmap bmp, Color color)
        {
            this.lienzo = bmp;
            this.colorActual = color;
        }

        private void PutPixel(int x, int y)
        {
            if (x >= 0 && x < lienzo.Width && y >= 0 && y < lienzo.Height)
                lienzo.SetPixel(x, y, colorActual);
        }

        // --- 1. LÍNEAS ---
        public void LineaDDA(int x0, int y0, int x1, int y1)
        {
            int dx = x1 - x0, dy = y1 - y0, steps;
            float xInc, yInc, x = x0, y = y0;
            steps = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);
            xInc = dx / (float)steps;
            yInc = dy / (float)steps;
            for (int k = 0; k < steps; k++)
            {
                PutPixel((int)Math.Round(x), (int)Math.Round(y));
                x += xInc; y += yInc;
            }
        }
        public void LineaBresenham(int x0, int y0, int x1, int y1)
        {
            int dx = Math.Abs(x1 - x0), dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1, sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;
            while (true)
            {
                PutPixel(x0, y0);
                if (x0 == x1 && y0 == y1) break;
                int e2 = 2 * err;
                if (e2 > -dy) { err -= dy; x0 += sx; }
                if (e2 < dx) { err += dx; y0 += sy; }
            }
        }
        public void LineaPuntoMedio(int x0, int y0, int x1, int y1)
        {
            int dx = Math.Abs(x1 - x0), dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1, sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;
            while (true)
            {
                PutPixel(x0, y0);
                if (x0 == x1 && y0 == y1) break;
                int e2 = 2 * err;
                if (e2 > -dy) { err -= dy; x0 += sx; }
                if (e2 < dx) { err += dx; y0 += sy; }
            }
        }

        // --- 2. CÍRCULOS ---
        public void CirculoPolar(int xc, int yc, int r)
        {
            for (double theta = 0; theta < 2 * Math.PI; theta += 0.01)
                PutPixel((int)(xc + r * Math.Cos(theta)), (int)(yc + r * Math.Sin(theta)));
        }
        public void CirculoBresenham(int xc, int yc, int r)
        {
            int x = 0, y = r, d = 3 - 2 * r;
            DibujarSimetria8(xc, yc, x, y);
            while (y >= x)
            {
                x++;
                if (d > 0) { y--; d = d + 4 * (x - y) + 10; }
                else d = d + 4 * x + 6;
                DibujarSimetria8(xc, yc, x, y);
            }
        }
        public void CirculoPuntoMedio(int xc, int yc, int r)
        {
            int x = 0, y = r, P = 1 - r;
            DibujarSimetria8(xc, yc, x, y);
            while (x < y)
            {
                x++;
                if (P < 0) P += 2 * x + 1;
                else { y--; P += 2 * (x - y) + 1; }
                DibujarSimetria8(xc, yc, x, y);
            }
        }
        private void DibujarSimetria8(int xc, int yc, int x, int y)
        {
            PutPixel(xc + x, yc + y); PutPixel(xc - x, yc + y);
            PutPixel(xc + x, yc - y); PutPixel(xc - x, yc - y);
            PutPixel(xc + y, yc + x); PutPixel(xc - y, yc + x);
            PutPixel(xc + y, yc - x); PutPixel(xc - y, yc - x);
        }

        // --- 3. RELLENO ---
        public void RellenoFloodFill(int x, int y)
        {
            if (x < 0 || x >= lienzo.Width || y < 0 || y >= lienzo.Height) return;
            Color target = lienzo.GetPixel(x, y);
            if (target.ToArgb() == colorActual.ToArgb()) return;
            Stack<Point> pila = new Stack<Point>();
            pila.Push(new Point(x, y));
            while (pila.Count > 0)
            {
                Point p = pila.Pop();
                if (p.X < 0 || p.X >= lienzo.Width || p.Y < 0 || p.Y >= lienzo.Height) continue;
                if (lienzo.GetPixel(p.X, p.Y).ToArgb() == target.ToArgb())
                {
                    lienzo.SetPixel(p.X, p.Y, colorActual);
                    pila.Push(new Point(p.X + 1, p.Y)); pila.Push(new Point(p.X - 1, p.Y));
                    pila.Push(new Point(p.X, p.Y + 1)); pila.Push(new Point(p.X, p.Y - 1));
                }
            }
        }
        public void RellenoBoundaryFill(int x, int y, Color borde)
        {
            if (x < 0 || x >= lienzo.Width || y < 0 || y >= lienzo.Height) return;
            Color actual = lienzo.GetPixel(x, y);
            if (actual.ToArgb() == borde.ToArgb() || actual.ToArgb() == colorActual.ToArgb()) return;
            Stack<Point> pila = new Stack<Point>();
            pila.Push(new Point(x, y));
            while (pila.Count > 0)
            {
                Point p = pila.Pop();
                if (p.X < 0 || p.X >= lienzo.Width || p.Y < 0 || p.Y >= lienzo.Height) continue;
                Color c = lienzo.GetPixel(p.X, p.Y);
                if (c.ToArgb() != borde.ToArgb() && c.ToArgb() != colorActual.ToArgb())
                {
                    lienzo.SetPixel(p.X, p.Y, colorActual);
                    pila.Push(new Point(p.X + 1, p.Y)); pila.Push(new Point(p.X - 1, p.Y));
                    pila.Push(new Point(p.X, p.Y + 1)); pila.Push(new Point(p.X, p.Y - 1));
                }
            }
        }
        public void RellenoScanLine(int xMin, int yMin, int xMax, int yMax)
        {
            int xs = Math.Min(xMin, xMax), xe = Math.Max(xMin, xMax);
            int ys = Math.Min(yMin, yMax), ye = Math.Max(yMin, yMax);
            for (int j = ys; j <= ye; j++)
                for (int i = xs; i <= xe; i++) PutPixel(i, j);
        }

        // --- 4. RECORTE LÍNEAS ---
        const int INSIDE = 0, LEFT = 1, RIGHT = 2, BOTTOM = 4, TOP = 8;
        private int ComputeOutCode(double x, double y, Rectangle r)
        {
            int code = INSIDE;
            if (x < r.Left) code |= LEFT; else if (x > r.Right) code |= RIGHT;
            if (y < r.Top) code |= BOTTOM; else if (y > r.Bottom) code |= TOP;
            return code;
        }
        public void RecorteCohenSutherland(int x0, int y0, int x1, int y1, Rectangle clip)
        {
            int outcode0 = ComputeOutCode(x0, y0, clip);
            int outcode1 = ComputeOutCode(x1, y1, clip);
            bool accept = false;
            while (true)
            {
                if ((outcode0 | outcode1) == 0) { accept = true; break; }
                else if ((outcode0 & outcode1) != 0) break;
                else
                {
                    double x = 0, y = 0;
                    int outcodeOut = (outcode0 != 0) ? outcode0 : outcode1;
                    if ((outcodeOut & TOP) != 0) { x = x0 + (x1 - x0) * (clip.Bottom - y0) / (double)(y1 - y0); y = clip.Bottom; }
                    else if ((outcodeOut & BOTTOM) != 0) { x = x0 + (x1 - x0) * (clip.Top - y0) / (double)(y1 - y0); y = clip.Top; }
                    else if ((outcodeOut & RIGHT) != 0) { y = y0 + (y1 - y0) * (clip.Right - x0) / (double)(x1 - x0); x = clip.Right; }
                    else if ((outcodeOut & LEFT) != 0) { y = y0 + (y1 - y0) * (clip.Left - x0) / (double)(x1 - x0); x = clip.Left; }
                    if (outcodeOut == outcode0) { x0 = (int)x; y0 = (int)y; outcode0 = ComputeOutCode(x0, y0, clip); }
                    else { x1 = (int)x; y1 = (int)y; outcode1 = ComputeOutCode(x1, y1, clip); }
                }
            }
            if (accept) LineaDDA(x0, y0, x1, y1);
        }
        public void RecorteLiangBarsky(int x0, int y0, int x1, int y1, Rectangle clip)
        {
            float u1 = 0, u2 = 1;
            int dx = x1 - x0, dy = y1 - y0;
            if (ClipTest(-dx, x0 - clip.Left, ref u1, ref u2) && ClipTest(dx, clip.Right - x0, ref u1, ref u2) &&
                ClipTest(-dy, y0 - clip.Top, ref u1, ref u2) && ClipTest(dy, clip.Bottom - y0, ref u1, ref u2))
                LineaDDA(x0 + (int)(u1 * dx), y0 + (int)(u1 * dy), x0 + (int)(u2 * dx), y0 + (int)(u2 * dy));
        }
        private bool ClipTest(float p, float q, ref float u1, ref float u2)
        {
            if (p < 0) { float r = q / p; if (r > u2) return false; if (r > u1) u1 = r; }
            else if (p > 0) { float r = q / p; if (r < u1) return false; if (r < u2) u2 = r; }
            else if (q < 0) return false;
            return true;
        }

        // --- 5. RECORTE POLÍGONO ---
        public void RecortePoligonoSutherlandHodgman(List<Point> poly, Rectangle clip)
        {
            List<Point> output = new List<Point>(poly);
            output = ClipEdge(output, clip, 1);
            output = ClipEdge(output, clip, 2);
            output = ClipEdge(output, clip, 3);
            output = ClipEdge(output, clip, 4);
            if (output.Count > 1)
            {
                for (int i = 0; i < output.Count - 1; i++) LineaDDA(output[i].X, output[i].Y, output[i + 1].X, output[i + 1].Y);
                LineaDDA(output[output.Count - 1].X, output[output.Count - 1].Y, output[0].X, output[0].Y);
            }
        }
        private List<Point> ClipEdge(List<Point> input, Rectangle clip, int edge)
        {
            List<Point> newPoly = new List<Point>();
            if (input.Count == 0) return newPoly;
            Point S = input[input.Count - 1];
            foreach (Point E in input)
            {
                if (IsInside(E, edge, clip))
                {
                    if (!IsInside(S, edge, clip)) newPoly.Add(Intersection(S, E, edge, clip));
                    newPoly.Add(E);
                }
                else if (IsInside(S, edge, clip)) newPoly.Add(Intersection(S, E, edge, clip));
                S = E;
            }
            return newPoly;
        }
        private bool IsInside(Point p, int edge, Rectangle r)
        {
            switch (edge) { case 1: return p.X >= r.Left; case 2: return p.X <= r.Right; case 3: return p.Y >= r.Top; case 4: return p.Y <= r.Bottom; }
            return false;
        }
        private Point Intersection(Point s, Point e, int edge, Rectangle r)
        {
            float m = (e.X != s.X) ? (float)(e.Y - s.Y) / (e.X - s.X) : 0;
            int x = 0, y = 0;
            switch (edge)
            {
                case 1: x = r.Left; y = s.Y + (int)((r.Left - s.X) * m); break;
                case 2: x = r.Right; y = s.Y + (int)((r.Right - s.X) * m); break;
                case 3: y = r.Top; x = (m != 0) ? s.X + (int)((r.Top - s.Y) / m) : s.X; break;
                case 4: y = r.Bottom; x = (m != 0) ? s.X + (int)((r.Bottom - s.Y) / m) : s.X; break;
            }
            return new Point(x, y);
        }

        // --- 6. CURVAS BEZIER ---
        public void BezierCuadratica(Point p0, Point p1, Point p2)
        {
            for (double t = 0; t <= 1; t += 0.001)
            {
                double u = 1 - t;
                double x = (u * u * p0.X) + (2 * u * t * p1.X) + (t * t * p2.X);
                double y = (u * u * p0.Y) + (2 * u * t * p1.Y) + (t * t * p2.Y);
                PutPixel((int)x, (int)y);
            }
        }
        public void BezierCubica(Point p0, Point p1, Point p2, Point p3)
        {
            for (double t = 0; t <= 1; t += 0.001)
            {
                double u = 1 - t;
                double x = (u * u * u * p0.X) + (3 * u * u * t * p1.X) + (3 * u * t * t * p2.X) + (t * t * t * p3.X);
                double y = (u * u * u * p0.Y) + (3 * u * u * t * p1.Y) + (3 * u * t * t * p2.Y) + (t * t * t * p3.Y);
                PutPixel((int)x, (int)y);
            }
        }
    }
}