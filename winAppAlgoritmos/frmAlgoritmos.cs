using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace winAppAlgoritmos
{
    public partial class frmAlgoritmos : Form
    {
        private Bitmap mapaPrincipal;
        private Bitmap mapaTemporal; // Para animación (Double buffering manual)
        private Color colorSeleccionado = Color.Black;

        private bool dibujando = false;
        private Point pInicio;
        private List<Point> puntosControl = new List<Point>();

        // Ventana de Recorte Fija
        private Rectangle rectClip = new Rectangle(150, 150, 400, 300);

        // Control de Grupos para la persistencia
        private string grupoActual = "";

        public frmAlgoritmos()
        {
            InitializeComponent();
            mapaPrincipal = new Bitmap(picLienzo.Width, picLienzo.Height);
            using (Graphics g = Graphics.FromImage(mapaPrincipal)) g.Clear(Color.White);
            picLienzo.Image = mapaPrincipal;

            // Nombres específicos con el algoritmo entre paréntesis si aplica
            cmbAlgoritmo.Items.Add("Trazado Líneas");
            cmbAlgoritmo.Items.Add("Trazado Círculos");
            cmbAlgoritmo.Items.Add("Relleno");
            cmbAlgoritmo.Items.Add("Recorte Línea");
            cmbAlgoritmo.Items.Add("Recorte Polígono");
            cmbAlgoritmo.Items.Add("Curvas (Bezier)");
            cmbAlgoritmo.SelectedIndex = 0;
        }

        // Método auxiliar para determinar a qué grupo pertenece la categoría
        private string ObtenerGrupo(string categoria)
        {
            if (categoria == "Trazado Líneas" || categoria == "Trazado Círculos" || categoria == "Relleno")
                return "DIBUJO";
            if (categoria == "Recorte Línea" || categoria == "Recorte Polígono")
                return "RECORTE";
            return "CURVAS"; // Bezier siempre limpia
        }

        private void cmbAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbVariante.Items.Clear();
            string cat = cmbAlgoritmo.SelectedItem.ToString();
            string nuevoGrupo = ObtenerGrupo(cat);

            puntosControl.Clear();

            // LÓGICA DE PERSISTENCIA
            // 1. Si cambiamos a CURVAS, siempre limpiamos.
            if (nuevoGrupo == "CURVAS")
            {
                DibujarLienzoBase(); // Limpia todo
            }
            // 2. Si cambiamos de grupo (ej: de DIBUJO a RECORTE), limpiamos.
            else if (nuevoGrupo != grupoActual)
            {
                DibujarLienzoBase();
                // Si entramos al grupo RECORTE, dibujamos el marco rojo.
                if (nuevoGrupo == "RECORTE") DibujarRectanguloClip();
            }
            // 3. Si el grupo es el mismo (ej: Línea a Círculo), NO HACEMOS NADA (se mantiene el dibujo).

            grupoActual = nuevoGrupo;

            // Configurar variantes según categoría
            switch (cat)
            {
                case "Trazado Líneas":
                    cmbVariante.Items.AddRange(new string[] { "DDA", "Bresenham", "Punto Medio" });
                    lblInstruccion.Text = "Arrastra el mouse para dibujar la línea.";
                    break;
                case "Trazado Círculos":
                    cmbVariante.Items.AddRange(new string[] { "Polar", "Bresenham", "Punto Medio" });
                    lblInstruccion.Text = "Arrastra para definir el radio del círculo.";
                    break;
                case "Relleno":
                    cmbVariante.Items.AddRange(new string[] { "FloodFill (Bote Pintura)", "BoundaryFill", "ScanLine (Rectángulo)" });
                    lblInstruccion.Text = "FloodFill: Clic en área cerrada.\nBoundary: Clic en área con borde.\nScanLine: Arrastra área.";
                    break;
                case "Recorte Línea":
                    cmbVariante.Items.AddRange(new string[] { "Cohen-Sutherland", "Liang-Barsky" });
                    lblInstruccion.Text = "Dibuja una línea que cruce el RECTÁNGULO ROJO.";
                    break;
                case "Recorte Polígono":
                    cmbVariante.Items.AddRange(new string[] { "Sutherland-Hodgman" });
                    lblInstruccion.Text = "Clic izq: añadir vértice.\nClic der: cerrar y recortar.";
                    break;
                case "Curvas (Bezier)":
                    cmbVariante.Items.AddRange(new string[] { "Cuadrática (3 ptos)", "Cúbica (4 ptos)" });
                    lblInstruccion.Text = "Haz clic en el lienzo para marcar los puntos de control.";
                    break;
            }
            if (cmbVariante.Items.Count > 0) cmbVariante.SelectedIndex = 0;
        }

        private void picLienzo_MouseDown(object sender, MouseEventArgs e)
        {
            string cat = cmbAlgoritmo.SelectedItem.ToString();

            // Rellenos de clic (FloodFill y Boundary) no usan arrastre
            if (cat == "Relleno" && !cmbVariante.SelectedItem.ToString().Contains("ScanLine")) return;
            // Poligonos y Curvas usan clicks puntuales
            if (cat == "Recorte Polígono" || cat.Contains("Curvas")) return;

            // Iniciar arrastre
            dibujando = true;
            pInicio = e.Location;
            mapaTemporal = (Bitmap)mapaPrincipal.Clone(); // Clonamos el estado actual para no perder dibujos previos
        }

        private void picLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            lblCoordenadas.Text = $"X:{e.X} Y:{e.Y}";

            if (dibujando)
            {
                // Restauramos el temporal para el efecto de animación
                Bitmap buffer = (Bitmap)mapaTemporal.Clone();
                CAlgoritmos algTemp = new CAlgoritmos(buffer, colorSeleccionado);
                string cat = cmbAlgoritmo.SelectedItem.ToString();

                if (cat == "Trazado Líneas" || cat == "Recorte Línea")
                {
                    algTemp.LineaDDA(pInicio.X, pInicio.Y, e.X, e.Y);
                }
                else if (cat == "Trazado Círculos")
                {
                    int r = (int)Math.Sqrt(Math.Pow(e.X - pInicio.X, 2) + Math.Pow(e.Y - pInicio.Y, 2));
                    algTemp.CirculoBresenham(pInicio.X, pInicio.Y, r);
                }
                else if (cat == "Relleno" && cmbVariante.SelectedItem.ToString().Contains("ScanLine"))
                {
                    using (Graphics g = Graphics.FromImage(buffer))
                    {
                        int x = Math.Min(pInicio.X, e.X);
                        int y = Math.Min(pInicio.Y, e.Y);
                        g.DrawRectangle(Pens.Gray, x, y, Math.Abs(e.X - pInicio.X), Math.Abs(e.Y - pInicio.Y));
                    }
                }

                picLienzo.Image = buffer;
            }
        }

        private void picLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            if (dibujando)
            {
                dibujando = false;
                // Dibujamos definitivamente en mapaPrincipal
                CAlgoritmos algFinal = new CAlgoritmos(mapaPrincipal, colorSeleccionado);
                string cat = cmbAlgoritmo.SelectedItem.ToString();
                string var = cmbVariante.SelectedItem.ToString();

                if (cat == "Trazado Líneas")
                {
                    if (var == "DDA") algFinal.LineaDDA(pInicio.X, pInicio.Y, e.X, e.Y);
                    else if (var == "Bresenham") algFinal.LineaBresenham(pInicio.X, pInicio.Y, e.X, e.Y);
                    else algFinal.LineaPuntoMedio(pInicio.X, pInicio.Y, e.X, e.Y);
                }
                else if (cat == "Trazado Círculos")
                {
                    int r = (int)Math.Sqrt(Math.Pow(e.X - pInicio.X, 2) + Math.Pow(e.Y - pInicio.Y, 2));
                    if (var == "Polar") algFinal.CirculoPolar(pInicio.X, pInicio.Y, r);
                    else if (var == "Bresenham") algFinal.CirculoBresenham(pInicio.X, pInicio.Y, r);
                    else algFinal.CirculoPuntoMedio(pInicio.X, pInicio.Y, r);
                }
                else if (cat == "Recorte Línea")
                {
                    // Al soltar, aplicamos el recorte
                    if (var == "Cohen-Sutherland") algFinal.RecorteCohenSutherland(pInicio.X, pInicio.Y, e.X, e.Y, rectClip);
                    else algFinal.RecorteLiangBarsky(pInicio.X, pInicio.Y, e.X, e.Y, rectClip);
                }
                else if (cat == "Relleno" && var.Contains("ScanLine"))
                {
                    algFinal.RellenoScanLine(pInicio.X, pInicio.Y, e.X, e.Y);
                }

                picLienzo.Image = mapaPrincipal;
                picLienzo.Refresh();
            }
        }

        private void picLienzo_MouseClick(object sender, MouseEventArgs e)
        {
            string cat = cmbAlgoritmo.SelectedItem.ToString();
            CAlgoritmos alg = new CAlgoritmos(mapaPrincipal, colorSeleccionado);

            if (cat == "Relleno")
            {
                if (cmbVariante.SelectedItem.ToString().Contains("FloodFill"))
                    alg.RellenoFloodFill(e.X, e.Y);
                else if (cmbVariante.SelectedItem.ToString().Contains("BoundaryFill"))
                    alg.RellenoBoundaryFill(e.X, e.Y, Color.Black);

                picLienzo.Refresh();
            }
            else if (cat.Contains("Curvas"))
            {
                puntosControl.Add(e.Location);
                using (Graphics g = Graphics.FromImage(mapaPrincipal))
                    g.FillRectangle(Brushes.Red, e.X - 2, e.Y - 2, 4, 4);
                picLienzo.Refresh();

                int necesarios = cmbVariante.SelectedItem.ToString().Contains("Cuadrática") ? 3 : 4;

                if (puntosControl.Count == necesarios)
                {
                    if (necesarios == 3) alg.BezierCuadratica(puntosControl[0], puntosControl[1], puntosControl[2]);
                    else alg.BezierCubica(puntosControl[0], puntosControl[1], puntosControl[2], puntosControl[3]);

                    puntosControl.Clear();
                    picLienzo.Refresh();
                }
            }
            else if (cat == "Recorte Polígono")
            {
                if (e.Button == MouseButtons.Left)
                {
                    puntosControl.Add(e.Location);
                    using (Graphics g = Graphics.FromImage(mapaPrincipal))
                    {
                        g.FillRectangle(Brushes.Blue, e.X - 2, e.Y - 2, 4, 4);
                        if (puntosControl.Count > 1)
                            g.DrawLine(Pens.LightGray, puntosControl[puntosControl.Count - 2], e.Location);
                    }
                    picLienzo.Refresh();
                }
                else if (e.Button == MouseButtons.Right && puntosControl.Count > 2)
                {
                    alg.RecortePoligonoSutherlandHodgman(puntosControl, rectClip);
                    puntosControl.Clear();
                    picLienzo.Refresh();
                }
            }
        }

        private void DibujarLienzoBase()
        {
            using (Graphics g = Graphics.FromImage(mapaPrincipal)) g.Clear(Color.White);
            picLienzo.Image = mapaPrincipal;
        }

        private void DibujarRectanguloClip()
        {
            using (Graphics g = Graphics.FromImage(mapaPrincipal))
            {
                Pen pen = new Pen(Color.Red, 2);
                g.DrawRectangle(pen, rectClip);
                g.DrawString("Área de Recorte", this.Font, Brushes.Red, rectClip.X, rectClip.Y - 20);
            }
            picLienzo.Refresh();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DibujarLienzoBase();
            puntosControl.Clear();
            if (grupoActual == "RECORTE") DibujarRectanguloClip();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                colorSeleccionado = cd.Color;
                btnColor.BackColor = cd.Color;
                btnColor.Text = "Color Seleccionado";
                btnColor.ForeColor = (cd.Color.R < 100 && cd.Color.G < 100) ? Color.White : Color.Black;
            }
        }
    }
}