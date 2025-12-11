using System;
using System.Collections.Generic;
using System.Diagnostics; // Importante para el cronómetro
using System.Drawing;
using System.Windows.Forms;

namespace winAppAlgoritmos
{
    public partial class frmAlgoritmos : Form
    {
        private Bitmap mapaBits;
        private Color colorSeleccionado = Color.Black;
        private List<Point> puntosPoligono = new List<Point>();
        private int clickCount = 0;

        public frmAlgoritmos()
        {
            InitializeComponent();
            mapaBits = new Bitmap(picLienzo.Width, picLienzo.Height);
            picLienzo.Image = mapaBits;

            // Inicializar combos
            cmbAlgoritmo.Items.AddRange(new string[] { "Líneas", "Círculos", "Relleno", "Recorte Línea", "Recorte Polígono" });
            cmbVariante.Items.AddRange(new string[] { "Variante A", "Variante B", "Variante C" });
            cmbAlgoritmo.SelectedIndex = 0;
            cmbVariante.SelectedIndex = 0;

            // Inicializar botón de color
            btnColor.BackColor = colorSeleccionado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(mapaBits))
            {
                g.Clear(Color.White);
            }
            picLienzo.Refresh();
            puntosPoligono.Clear();
            clickCount = 0;
            lblTiempo.Text = "Tiempo: --";
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                colorSeleccionado = cd.Color;
                btnColor.BackColor = colorSeleccionado;

                // Texto legible si el color es muy oscuro
                if (colorSeleccionado.R < 100 && colorSeleccionado.G < 100 && colorSeleccionado.B < 100)
                    btnColor.ForeColor = Color.White;
                else
                    btnColor.ForeColor = Color.Black;
            }
        }

        private void picLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            lblCoordenadas.Text = $"X:{e.X} Y:{e.Y}";
        }

        private void picLienzo_MouseClick(object sender, MouseEventArgs e)
        {
            if (clickCount == 0)
            {
                txtX1.Text = e.X.ToString();
                txtY1.Text = e.Y.ToString();
                clickCount++;
            }
            else
            {
                txtX2.Text = e.X.ToString();
                txtY2.Text = e.Y.ToString();
                clickCount = 0;
            }

            if (cmbAlgoritmo.SelectedItem != null && cmbAlgoritmo.SelectedItem.ToString() == "Recorte Polígono")
            {
                puntosPoligono.Add(e.Location);
                using (Graphics g = Graphics.FromImage(mapaBits))
                    g.FillRectangle(Brushes.Red, e.X, e.Y, 3, 3);
                picLienzo.Refresh();
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                // Instanciamos CAlgoritmos con el color actualizado
                CAlgoritmos algoritmos = new CAlgoritmos(mapaBits, colorSeleccionado);

                string categoria = cmbAlgoritmo.SelectedItem.ToString();
                string variante = cmbVariante.SelectedItem.ToString();

                int x1 = int.Parse(txtX1.Text);
                int y1 = int.Parse(txtY1.Text);
                int x2 = int.TryParse(txtX2.Text, out int ox2) ? ox2 : 0;
                int y2 = int.TryParse(txtY2.Text, out int oy2) ? oy2 : 0;

                // INICIO MEDICIÓN DE TIEMPO
                Stopwatch sw = Stopwatch.StartNew();

                switch (categoria)
                {
                    case "Líneas":
                        if (variante == "Variante A") algoritmos.LineaDDA(x1, y1, x2, y2);
                        else if (variante == "Variante B") algoritmos.LineaBresenham(x1, y1, x2, y2);
                        else algoritmos.LineaPuntoMedio(x1, y1, x2, y2);
                        break;

                    case "Círculos":
                        int radio = Math.Abs(x2 - x1);
                        if (variante == "Variante A") algoritmos.CirculoPolar(x1, y1, radio);
                        else if (variante == "Variante B") algoritmos.CirculoBresenham(x1, y1, radio);
                        else algoritmos.CirculoPuntoMedio(x1, y1, radio);
                        break;

                    case "Relleno":
                        if (variante == "Variante A") algoritmos.RellenoFloodFill(x1, y1, Color.Red);
                        else if (variante == "Variante B") algoritmos.RellenoBoundaryFill(x1, y1, Color.Black);
                        else algoritmos.RellenoScanLine(x1, y1, x2, y2);
                        break;

                    case "Recorte Línea":
                        using (Graphics g = Graphics.FromImage(mapaBits)) g.DrawRectangle(Pens.Blue, 100, 100, 200, 200);

                        if (variante == "Variante A") algoritmos.RecorteCohenSutherland(x1, y1, x2, y2, 100, 100, 300, 300);
                        else if (variante == "Variante B") algoritmos.RecorteLiangBarsky(x1, y1, x2, y2, 100, 100, 300, 300);
                        else algoritmos.RecorteSimpleTrivial(x1, y1, x2, y2, 100, 100, 300, 300);
                        break;

                    case "Recorte Polígono":
                        using (Graphics g = Graphics.FromImage(mapaBits)) g.DrawRectangle(Pens.Blue, 100, 100, 200, 200);

                        if (puntosPoligono.Count < 3) { MessageBox.Show("Defina al menos 3 puntos."); return; }

                        if (variante == "Variante A") algoritmos.RecortePoligonoSutherlandHodgman(puntosPoligono, 100, 100, 300, 300);
                        else if (variante == "Variante B") algoritmos.RecortePoligonoCaja(puntosPoligono, 100, 100, 300, 300);
                        else
                        {
                            using (Graphics g = Graphics.FromImage(mapaBits))
                                algoritmos.RecortePoligonoGDI(puntosPoligono, 100, 100, 300, 300, g);
                        }
                        puntosPoligono.Clear();
                        break;
                }

                // FIN MEDICIÓN
                sw.Stop();
                picLienzo.Refresh();

                // Mostrar tiempo
                double ticks = sw.ElapsedTicks;
                double ms = sw.Elapsed.TotalMilliseconds;
                lblTiempo.Text = $"Tiempo: {ms:F4} ms ({ticks} ticks)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en los parámetros: " + ex.Message);
            }
        }
    }
}