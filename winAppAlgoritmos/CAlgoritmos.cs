using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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

        // Método auxiliar para pintar píxel (con validación de límites)
        private void PutPixel(int x, int y)
        {
            if (x >= 0 && x < lienzo.Width && y >= 0 && y < lienzo.Height)
            {
                lienzo.SetPixel(x, y, colorActual);
            }
        }

        #region 1. Trazado de Líneas (3 Variantes)

        // Variante A: DDA (Digital Differential Analyzer)
        public void LineaDDA(int x0, int y0, int x1, int y1)
        {
            int dx = x1 - x0, dy = y1 - y0, steps;
            float xInc, yInc, x = x0, y = y0;

            if (Math.Abs(dx) > Math.Abs(dy)) steps = Math.Abs(dx);
            else steps = Math.Abs(dy);

            xInc = dx / (float)steps;
            yInc = dy / (float)steps;

            for (int k = 0; k < steps; k++)
            {
                PutPixel((int)Math.Round(x), (int)Math.Round(y));
                x += xInc;
                y += yInc;
            }
        }

        // Variante B: Bresenham
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

        // Variante C: Algoritmo de Punto Medio
        public void LineaPuntoMedio(int x0, int y0, int x1, int y1)
        {
            // Implementación simplificada para octantes básicos
            int dx = x1 - x0;
            int dy = y1 - y0;
            int d = 2 * dy - dx;
            int incE = 2 * dy;
            int incNE = 2 * (dy - dx);
            int x = x0, y = y0;

            PutPixel(x, y);
            while (x < x1)
            {
                if (d <= 0) { d += incE; x++; }
                else { d += incNE; x++; y++; }
                PutPixel(x, y);
            }
        }
        #endregion

        #region 2. Trazado de Círculos (3 Variantes)

        // Variante A: Ecuación Polar (Trigonométrica básica)
        public void CirculoPolar(int xc, int yc, int r)
        {
            for (double theta = 0; theta < 2 * Math.PI; theta += 0.01)
            {
                int x = (int)(xc + r * Math.Cos(theta));
                int y = (int)(yc + r * Math.Sin(theta));
                PutPixel(x, y);
            }
        }

        // Variante B: Bresenham
        public void CirculoBresenham(int xc, int yc, int r)
        {
            int x = 0, y = r;
            int d = 3 - 2 * r;
            DibujarSimetria8(xc, yc, x, y);
            while (y >= x)
            {
                x++;
                if (d > 0) { y--; d = d + 4 * (x - y) + 10; }
                else d = d + 4 * x + 6;
                DibujarSimetria8(xc, yc, x, y);
            }
        }

        // Variante C: Punto Medio
        public void CirculoPuntoMedio(int xc, int yc, int r)
        {
            int x = 0, y = r;
            int P = 1 - r;
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
        #endregion

        #region 3. Algoritmos de Relleno (3 Variantes)

        // Variante A: FloodFill (Inundación - Recursivo/Pila)
        public void RellenoFloodFill(int x, int y, Color targetColor)
        {
            if (x < 0 || x >= lienzo.Width || y < 0 || y >= lienzo.Height) return;
            if (lienzo.GetPixel(x, y).ToArgb() != targetColor.ToArgb()) return;
            if (lienzo.GetPixel(x, y).ToArgb() == colorActual.ToArgb()) return;

            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(new Point(x, y));

            while (pixels.Count > 0)
            {
                Point p = pixels.Pop();
                if (p.X < 0 || p.X >= lienzo.Width || p.Y < 0 || p.Y >= lienzo.Height) continue;
                if (lienzo.GetPixel(p.X, p.Y).ToArgb() == targetColor.ToArgb())
                {
                    lienzo.SetPixel(p.X, p.Y, colorActual);
                    pixels.Push(new Point(p.X + 1, p.Y));
                    pixels.Push(new Point(p.X - 1, p.Y));
                    pixels.Push(new Point(p.X, p.Y + 1));
                    pixels.Push(new Point(p.X, p.Y - 1));
                }
            }
        }

        // Variante B: BoundaryFill (Relleno de frontera)
        // Nota: Asume que hay un borde de un color específico
        public void RellenoBoundaryFill(int x, int y, Color borderColor)
        {
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x, y));

            while (stack.Count > 0)
            {
                Point p = stack.Pop();
                if (p.X < 0 || p.X >= lienzo.Width || p.Y < 0 || p.Y >= lienzo.Height) continue;

                Color current = lienzo.GetPixel(p.X, p.Y);
                if (current.ToArgb() != borderColor.ToArgb() && current.ToArgb() != colorActual.ToArgb())
                {
                    lienzo.SetPixel(p.X, p.Y, colorActual);
                    stack.Push(new Point(p.X + 1, p.Y));
                    stack.Push(new Point(p.X - 1, p.Y));
                    stack.Push(new Point(p.X, p.Y + 1));
                    stack.Push(new Point(p.X, p.Y - 1));
                }
            }
        }

        // Variante C: Scanline (Línea de barrido simple para rectángulo)
        // Simulamos scanline llenando línea por línea entre límites
        public void RellenoScanLine(int xMin, int yMin, int xMax, int yMax)
        {
            for (int y = yMin; y <= yMax; y++)
            {
                for (int x = xMin; x <= xMax; x++)
                {
                    PutPixel(x, y);
                }
            }
        }
        #endregion

        #region 4. Recorte de Líneas (3 Variantes)

        // Definiciones para Cohen-Sutherland
        const int INSIDE = 0; // 0000
        const int LEFT = 1;   // 0001
        const int RIGHT = 2;  // 0010
        const int BOTTOM = 4; // 0100
        const int TOP = 8;    // 1000

        // Variante A: Cohen-Sutherland
        private int ComputeOutCode(double x, double y, int xMin, int yMin, int xMax, int yMax)
        {
            int code = INSIDE;
            if (x < xMin) code |= LEFT;
            else if (x > xMax) code |= RIGHT;
            if (y < yMin) code |= BOTTOM;
            else if (y > yMax) code |= TOP;
            return code;
        }

        public void RecorteCohenSutherland(int x0, int y0, int x1, int y1, int xMin, int yMin, int xMax, int yMax)
        {
            int outcode0 = ComputeOutCode(x0, y0, xMin, yMin, xMax, yMax);
            int outcode1 = ComputeOutCode(x1, y1, xMin, yMin, xMax, yMax);
            bool accept = false;

            while (true)
            {
                if ((outcode0 | outcode1) == 0) { accept = true; break; }
                else if ((outcode0 & outcode1) != 0) { break; }
                else
                {
                    double x = 0, y = 0;
                    int outcodeOut = (outcode0 != 0) ? outcode0 : outcode1;

                    if ((outcodeOut & TOP) != 0)
                    { x = x0 + (x1 - x0) * (yMax - y0) / (double)(y1 - y0); y = yMax; }
                    else if ((outcodeOut & BOTTOM) != 0)
                    { x = x0 + (x1 - x0) * (yMin - y0) / (double)(y1 - y0); y = yMin; }
                    else if ((outcodeOut & RIGHT) != 0)
                    { y = y0 + (y1 - y0) * (xMax - x0) / (double)(x1 - x0); x = xMax; }
                    else if ((outcodeOut & LEFT) != 0)
                    { y = y0 + (y1 - y0) * (xMin - x0) / (double)(x1 - x0); x = xMin; }

                    if (outcodeOut == outcode0) { x0 = (int)x; y0 = (int)y; outcode0 = ComputeOutCode(x0, y0, xMin, yMin, xMax, yMax); }
                    else { x1 = (int)x; y1 = (int)y; outcode1 = ComputeOutCode(x1, y1, xMin, yMin, xMax, yMax); }
                }
            }
            if (accept) LineaDDA(x0, y0, x1, y1);
        }

        // Variante B: Liang-Barsky (Paramétrico)
        public void RecorteLiangBarsky(int x0, int y0, int x1, int y1, int xMin, int yMin, int xMax, int yMax)
        {
            float u1 = 0, u2 = 1;
            int dx = x1 - x0, dy = y1 - y0;

            if (ClipTest(-dx, x0 - xMin, ref u1, ref u2) && ClipTest(dx, xMax - x0, ref u1, ref u2) &&
                ClipTest(-dy, y0 - yMin, ref u1, ref u2) && ClipTest(dy, yMax - y0, ref u1, ref u2))
            {
                LineaDDA(x0 + (int)(u1 * dx), y0 + (int)(u1 * dy),
                         x0 + (int)(u2 * dx), y0 + (int)(u2 * dy));
            }
        }
        private bool ClipTest(float p, float q, ref float u1, ref float u2)
        {
            if (p < 0)
            {
                float r = q / p;
                if (r > u2) return false;
                if (r > u1) u1 = r;
            }
            else if (p > 0)
            {
                float r = q / p;
                if (r < u1) return false;
                if (r < u2) u2 = r;
            }
            else if (q < 0) return false;
            return true;
        }

        // Variante C: Recorte simple (Bounding Box Check)
        // Solo dibuja si está completamente dentro
        public void RecorteSimpleTrivial(int x0, int y0, int x1, int y1, int xMin, int yMin, int xMax, int yMax)
        {
            if (x0 >= xMin && x0 <= xMax && y0 >= yMin && y0 <= yMax &&
                x1 >= xMin && x1 <= xMax && y1 >= yMin && y1 <= yMax)
            {
                LineaDDA(x0, y0, x1, y1);
            }
            // Si no está completamente dentro, no dibuja nada (rechazo trivial)
        }
        #endregion

        #region 5. Recorte de Polígonos (3 Variantes)

        // Variante A: Sutherland-Hodgman (Ventana Rectangular)
        public void RecortePoligonoSutherlandHodgman(List<Point> poly, int xMin, int yMin, int xMax, int yMax)
        {
            List<Point> output = new List<Point>(poly);

            output = ClipEdge(output, xMin, yMin, xMax, yMax, 1); // Izquierda
            output = ClipEdge(output, xMin, yMin, xMax, yMax, 2); // Derecha
            output = ClipEdge(output, xMin, yMin, xMax, yMax, 3); // Abajo
            output = ClipEdge(output, xMin, yMin, xMax, yMax, 4); // Arriba

            // Dibujar resultado
            if (output.Count > 1)
            {
                for (int i = 0; i < output.Count - 1; i++)
                    LineaDDA(output[i].X, output[i].Y, output[i + 1].X, output[i + 1].Y);
                LineaDDA(output[output.Count - 1].X, output[output.Count - 1].Y, output[0].X, output[0].Y);
            }
        }

        private List<Point> ClipEdge(List<Point> input, int xMin, int yMin, int xMax, int yMax, int edge)
        {
            List<Point> newPoly = new List<Point>();
            if (input.Count == 0) return newPoly;

            Point S = input[input.Count - 1];
            foreach (Point E in input)
            {
                if (IsInside(E, edge, xMin, yMin, xMax, yMax))
                {
                    if (!IsInside(S, edge, xMin, yMin, xMax, yMax))
                        newPoly.Add(Intersection(S, E, edge, xMin, yMin, xMax, yMax));
                    newPoly.Add(E);
                }
                else if (IsInside(S, edge, xMin, yMin, xMax, yMax))
                {
                    newPoly.Add(Intersection(S, E, edge, xMin, yMin, xMax, yMax));
                }
                S = E;
            }
            return newPoly;
        }
        private bool IsInside(Point p, int edge, int xMin, int yMin, int xMax, int yMax)
        {
            switch (edge)
            {
                case 1: return p.X >= xMin; // Left
                case 2: return p.X <= xMax; // Right
                case 3: return p.Y >= yMin; // Bottom
                case 4: return p.Y <= yMax; // Top
            }
            return false;
        }
        private Point Intersection(Point s, Point e, int edge, int xMin, int yMin, int xMax, int yMax)
        {
            // Lógica simplificada de intersección
            int x = 0, y = 0;
            float m = (e.X != s.X) ? (float)(e.Y - s.Y) / (e.X - s.X) : 0;
            switch (edge)
            {
                case 1: x = xMin; y = s.Y + (int)((xMin - s.X) * m); break;
                case 2: x = xMax; y = s.Y + (int)((xMax - s.X) * m); break;
                case 3: y = yMin; x = (m != 0) ? s.X + (int)((yMin - s.Y) / m) : s.X; break;
                case 4: y = yMax; x = (m != 0) ? s.X + (int)((yMax - s.Y) / m) : s.X; break;
            }
            return new Point(x, y);
        }

        // Variante B: Rechazo por Caja (Min-Max Box)
        // Dibuja el polígono SOLO si todos sus puntos están dentro de la ventana
        public void RecortePoligonoCaja(List<Point> poly, int xMin, int yMin, int xMax, int yMax)
        {
            bool todosDentro = true;
            foreach (var p in poly)
            {
                if (p.X < xMin || p.X > xMax || p.Y < yMin || p.Y > yMax)
                {
                    todosDentro = false;
                    break;
                }
            }
            if (todosDentro && poly.Count > 1)
            {
                for (int i = 0; i < poly.Count - 1; i++)
                    LineaDDA(poly[i].X, poly[i].Y, poly[i + 1].X, poly[i + 1].Y);
                LineaDDA(poly[poly.Count - 1].X, poly[poly.Count - 1].Y, poly[0].X, poly[0].Y);
            }
        }

        // Variante C: Recorte Gráfico de Sistema (GDI+)
        // Usa la capacidad nativa de .NET para comparar
        public void RecortePoligonoGDI(List<Point> poly, int xMin, int yMin, int xMax, int yMax, Graphics g)
        {
            Rectangle rect = new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin);
            g.SetClip(rect);
            if (poly.Count > 2)
            {
                g.DrawPolygon(new Pen(colorActual), poly.ToArray());
            }
            g.ResetClip();
        }
        #endregion
    }
}