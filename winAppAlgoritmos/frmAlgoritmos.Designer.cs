namespace winAppAlgoritmos
{
    partial class frmAlgoritmos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlControles = new System.Windows.Forms.Panel();
            this.lblCoordenadas = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.groupBoxCoords = new System.Windows.Forms.GroupBox();
            this.txtY2 = new System.Windows.Forms.TextBox();
            this.lblY2 = new System.Windows.Forms.Label();
            this.txtX2 = new System.Windows.Forms.TextBox();
            this.lblX2 = new System.Windows.Forms.Label();
            this.txtY1 = new System.Windows.Forms.TextBox();
            this.lblY1 = new System.Windows.Forms.Label();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.lblX1 = new System.Windows.Forms.Label();
            this.lblVariante = new System.Windows.Forms.Label();
            this.cmbVariante = new System.Windows.Forms.ComboBox();
            this.lblAlgoritmo = new System.Windows.Forms.Label();
            this.cmbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.picLienzo = new System.Windows.Forms.PictureBox();
            this.pnlControles.SuspendLayout();
            this.groupBoxCoords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLienzo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControles
            // 
            this.pnlControles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlControles.Controls.Add(this.lblCoordenadas);
            this.pnlControles.Controls.Add(this.lblTiempo);
            this.pnlControles.Controls.Add(this.btnColor);
            this.pnlControles.Controls.Add(this.groupBoxCoords);
            this.pnlControles.Controls.Add(this.lblVariante);
            this.pnlControles.Controls.Add(this.cmbVariante);
            this.pnlControles.Controls.Add(this.lblAlgoritmo);
            this.pnlControles.Controls.Add(this.cmbAlgoritmo);
            this.pnlControles.Controls.Add(this.btnLimpiar);
            this.pnlControles.Controls.Add(this.btnEjecutar);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControles.Location = new System.Drawing.Point(800, 0);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(200, 600);
            this.pnlControles.TabIndex = 0;
            // 
            // lblCoordenadas
            // 
            this.lblCoordenadas.AutoSize = true;
            this.lblCoordenadas.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCoordenadas.Location = new System.Drawing.Point(14, 570);
            this.lblCoordenadas.Name = "lblCoordenadas";
            this.lblCoordenadas.Size = new System.Drawing.Size(49, 14);
            this.lblCoordenadas.TabIndex = 9;
            this.lblCoordenadas.Text = "X:0 Y:0";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTiempo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTiempo.Location = new System.Drawing.Point(14, 335);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(58, 13);
            this.lblTiempo.TabIndex = 8;
            this.lblTiempo.Text = "Tiempo: --";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Location = new System.Drawing.Point(14, 360);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(174, 30);
            this.btnColor.TabIndex = 7;
            this.btnColor.Text = "Seleccionar Color";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // groupBoxCoords
            // 
            this.groupBoxCoords.Controls.Add(this.txtY2);
            this.groupBoxCoords.Controls.Add(this.lblY2);
            this.groupBoxCoords.Controls.Add(this.txtX2);
            this.groupBoxCoords.Controls.Add(this.lblX2);
            this.groupBoxCoords.Controls.Add(this.txtY1);
            this.groupBoxCoords.Controls.Add(this.lblY1);
            this.groupBoxCoords.Controls.Add(this.txtX1);
            this.groupBoxCoords.Controls.Add(this.lblX1);
            this.groupBoxCoords.Location = new System.Drawing.Point(14, 130);
            this.groupBoxCoords.Name = "groupBoxCoords";
            this.groupBoxCoords.Size = new System.Drawing.Size(174, 150);
            this.groupBoxCoords.TabIndex = 6;
            this.groupBoxCoords.TabStop = false;
            this.groupBoxCoords.Text = "Coordenadas / Params";
            // 
            // txtY2
            // 
            this.txtY2.Location = new System.Drawing.Point(40, 110);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(100, 23);
            this.txtY2.TabIndex = 7;
            this.txtY2.Text = "200";
            // 
            // lblY2
            // 
            this.lblY2.AutoSize = true;
            this.lblY2.Location = new System.Drawing.Point(10, 113);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(22, 15);
            this.lblY2.TabIndex = 6;
            this.lblY2.Text = "Y2:";
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(40, 81);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(100, 23);
            this.txtX2.TabIndex = 5;
            this.txtX2.Text = "200";
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(10, 84);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(22, 15);
            this.lblX2.TabIndex = 4;
            this.lblX2.Text = "X2:";
            // 
            // txtY1
            // 
            this.txtY1.Location = new System.Drawing.Point(40, 52);
            this.txtY1.Name = "txtY1";
            this.txtY1.Size = new System.Drawing.Size(100, 23);
            this.txtY1.TabIndex = 3;
            this.txtY1.Text = "50";
            // 
            // lblY1
            // 
            this.lblY1.AutoSize = true;
            this.lblY1.Location = new System.Drawing.Point(10, 55);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(22, 15);
            this.lblY1.TabIndex = 2;
            this.lblY1.Text = "Y1:";
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(40, 23);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(100, 23);
            this.txtX1.TabIndex = 1;
            this.txtX1.Text = "50";
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Location = new System.Drawing.Point(10, 26);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(22, 15);
            this.lblX1.TabIndex = 0;
            this.lblX1.Text = "X1:";
            // 
            // lblVariante
            // 
            this.lblVariante.AutoSize = true;
            this.lblVariante.Location = new System.Drawing.Point(14, 70);
            this.lblVariante.Name = "lblVariante";
            this.lblVariante.Size = new System.Drawing.Size(52, 15);
            this.lblVariante.TabIndex = 5;
            this.lblVariante.Text = "Variante:";
            // 
            // cmbVariante
            // 
            this.cmbVariante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVariante.FormattingEnabled = true;
            this.cmbVariante.Location = new System.Drawing.Point(14, 88);
            this.cmbVariante.Name = "cmbVariante";
            this.cmbVariante.Size = new System.Drawing.Size(174, 23);
            this.cmbVariante.TabIndex = 4;
            // 
            // lblAlgoritmo
            // 
            this.lblAlgoritmo.AutoSize = true;
            this.lblAlgoritmo.Location = new System.Drawing.Point(14, 18);
            this.lblAlgoritmo.Name = "lblAlgoritmo";
            this.lblAlgoritmo.Size = new System.Drawing.Size(64, 15);
            this.lblAlgoritmo.TabIndex = 3;
            this.lblAlgoritmo.Text = "Algoritmo:";
            // 
            // cmbAlgoritmo
            // 
            this.cmbAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgoritmo.FormattingEnabled = true;
            this.cmbAlgoritmo.Location = new System.Drawing.Point(14, 36);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(174, 23);
            this.cmbAlgoritmo.TabIndex = 2;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(14, 400);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(174, 35);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar Lienzo";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEjecutar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEjecutar.Location = new System.Drawing.Point(14, 290);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(174, 40);
            this.btnEjecutar.TabIndex = 0;
            this.btnEjecutar.Text = "EJECUTAR";
            this.btnEjecutar.UseVisualStyleBackColor = false;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // picLienzo
            // 
            this.picLienzo.BackColor = System.Drawing.Color.White;
            this.picLienzo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLienzo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLienzo.Location = new System.Drawing.Point(0, 0);
            this.picLienzo.Name = "picLienzo";
            this.picLienzo.Size = new System.Drawing.Size(800, 600);
            this.picLienzo.TabIndex = 1;
            this.picLienzo.TabStop = false;
            this.picLienzo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picLienzo_MouseClick);
            this.picLienzo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picLienzo_MouseMove);
            // 
            // frmAlgoritmos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.picLienzo);
            this.Controls.Add(this.pnlControles);
            this.Name = "frmAlgoritmos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinAppAlgoritmos - Computación Gráfica";
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.groupBoxCoords.ResumeLayout(false);
            this.groupBoxCoords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLienzo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.PictureBox picLienzo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.Label lblAlgoritmo;
        private System.Windows.Forms.ComboBox cmbAlgoritmo;
        private System.Windows.Forms.Label lblVariante;
        private System.Windows.Forms.ComboBox cmbVariante;
        private System.Windows.Forms.GroupBox groupBoxCoords;
        private System.Windows.Forms.TextBox txtY2;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.TextBox txtY1;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblCoordenadas;
    }
}