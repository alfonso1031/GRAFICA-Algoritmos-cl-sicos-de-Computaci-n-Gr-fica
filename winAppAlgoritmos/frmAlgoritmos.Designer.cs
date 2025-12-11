namespace winAppAlgoritmos
{
    partial class frmAlgoritmos
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlControles = new System.Windows.Forms.Panel();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.lblCoordenadas = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.lblVariante = new System.Windows.Forms.Label();
            this.cmbVariante = new System.Windows.Forms.ComboBox();
            this.lblAlgoritmo = new System.Windows.Forms.Label();
            this.cmbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.picLienzo = new System.Windows.Forms.PictureBox();
            this.pnlControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLienzo)).BeginInit();
            this.SuspendLayout();

            // pnlControles
            this.pnlControles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlControles.Controls.Add(this.lblInstruccion);
            this.pnlControles.Controls.Add(this.lblCoordenadas);
            this.pnlControles.Controls.Add(this.btnColor);
            this.pnlControles.Controls.Add(this.lblVariante);
            this.pnlControles.Controls.Add(this.cmbVariante);
            this.pnlControles.Controls.Add(this.lblAlgoritmo);
            this.pnlControles.Controls.Add(this.cmbAlgoritmo);
            this.pnlControles.Controls.Add(this.btnLimpiar);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControles.Location = new System.Drawing.Point(834, 0);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(250, 661);
            this.pnlControles.TabIndex = 0;

            // lblInstruccion
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblInstruccion.ForeColor = System.Drawing.Color.DimGray;
            this.lblInstruccion.Location = new System.Drawing.Point(14, 130);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(220, 60);
            this.lblInstruccion.TabIndex = 10;
            this.lblInstruccion.Text = "Instrucciones...";

            // lblCoordenadas
            this.lblCoordenadas.AutoSize = true;
            this.lblCoordenadas.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblCoordenadas.Location = new System.Drawing.Point(14, 630);
            this.lblCoordenadas.Name = "lblCoordenadas";
            this.lblCoordenadas.Size = new System.Drawing.Size(56, 14);
            this.lblCoordenadas.TabIndex = 9;
            this.lblCoordenadas.Text = "X:0 Y:0";

            // btnColor
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Location = new System.Drawing.Point(14, 210);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(220, 30);
            this.btnColor.TabIndex = 7;
            this.btnColor.Text = "Color: Negro";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);

            // lblVariante
            this.lblVariante.AutoSize = true;
            this.lblVariante.Location = new System.Drawing.Point(14, 70);
            this.lblVariante.Name = "lblVariante";
            this.lblVariante.Size = new System.Drawing.Size(52, 15);
            this.lblVariante.TabIndex = 5;
            this.lblVariante.Text = "Variante:";

            // cmbVariante
            this.cmbVariante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVariante.FormattingEnabled = true;
            this.cmbVariante.Location = new System.Drawing.Point(14, 88);
            this.cmbVariante.Name = "cmbVariante";
            this.cmbVariante.Size = new System.Drawing.Size(220, 23);
            this.cmbVariante.TabIndex = 4;

            // lblAlgoritmo
            // 
            this.lblAlgoritmo.AutoSize = true;
            this.lblAlgoritmo.Location = new System.Drawing.Point(14, 18);
            this.lblAlgoritmo.Name = "lblAlgoritmo";
            this.lblAlgoritmo.Size = new System.Drawing.Size(64, 15);
            this.lblAlgoritmo.TabIndex = 3;
            this.lblAlgoritmo.Text = "Categoría:";

            // cmbAlgoritmo
            this.cmbAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgoritmo.FormattingEnabled = true;
            this.cmbAlgoritmo.Location = new System.Drawing.Point(14, 36);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(220, 23);
            this.cmbAlgoritmo.TabIndex = 2;
            this.cmbAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.cmbAlgoritmo_SelectedIndexChanged);

            // btnLimpiar
            this.btnLimpiar.Location = new System.Drawing.Point(14, 250);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(220, 35);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar Todo";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // picLienzo
            this.picLienzo.BackColor = System.Drawing.Color.White;
            this.picLienzo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLienzo.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picLienzo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLienzo.Location = new System.Drawing.Point(0, 0);
            this.picLienzo.Name = "picLienzo";
            this.picLienzo.Size = new System.Drawing.Size(834, 661);
            this.picLienzo.TabIndex = 1;
            this.picLienzo.TabStop = false;
            this.picLienzo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picLienzo_MouseClick);
            this.picLienzo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLienzo_MouseDown);
            this.picLienzo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picLienzo_MouseMove);
            this.picLienzo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picLienzo_MouseUp);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.picLienzo);
            this.Controls.Add(this.pnlControles);
            this.DoubleBuffered = true;
            this.Name = "frmAlgoritmos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint Algoritmos - Computación Gráfica";
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLienzo)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.PictureBox picLienzo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblAlgoritmo;
        private System.Windows.Forms.ComboBox cmbAlgoritmo;
        private System.Windows.Forms.Label lblVariante;
        private System.Windows.Forms.ComboBox cmbVariante;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label lblCoordenadas;
        private System.Windows.Forms.Label lblInstruccion;
    }
}