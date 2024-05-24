namespace Cordoba.Rodrigo.PrimerParcial
{
    partial class FrmAgregar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Prenda = new Label();
            textBoxPrenda = new TextBox();
            button1 = new Button();
            textBoxTipoMaterial = new TextBox();
            lblCodigo = new Label();
            textBoxCantidad = new TextBox();
            Cantidad = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // Prenda
            // 
            Prenda.AutoSize = true;
            Prenda.Location = new Point(90, 112);
            Prenda.Name = "Prenda";
            Prenda.Size = new Size(44, 15);
            Prenda.TabIndex = 0;
            Prenda.Text = "Prenda";
            // 
            // textBoxPrenda
            // 
            textBoxPrenda.Location = new Point(90, 150);
            textBoxPrenda.Name = "textBoxPrenda";
            textBoxPrenda.Size = new Size(100, 23);
            textBoxPrenda.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(120, 250);
            button1.Name = "button1";
            button1.Size = new Size(150, 70);
            button1.TabIndex = 2;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBoxTipoMaterial
            // 
            textBoxTipoMaterial.Location = new Point(315, 150);
            textBoxTipoMaterial.Name = "textBoxTipoMaterial";
            textBoxTipoMaterial.Size = new Size(100, 23);
            textBoxTipoMaterial.TabIndex = 4;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(315, 112);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(46, 15);
            lblCodigo.TabIndex = 3;
            lblCodigo.Text = "Codigo";
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.Location = new Point(540, 150);
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(100, 23);
            textBoxCantidad.TabIndex = 6;
            // 
            // Cantidad
            // 
            Cantidad.AutoSize = true;
            Cantidad.Location = new Point(540, 112);
            Cantidad.Name = "Cantidad";
            Cantidad.Size = new Size(55, 15);
            Cantidad.TabIndex = 5;
            Cantidad.Text = "Cantidad";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.InactiveCaption;
            btnCancelar.Location = new Point(450, 250);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 70);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmAgregar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(734, 361);
            Controls.Add(btnCancelar);
            Controls.Add(textBoxCantidad);
            Controls.Add(Cantidad);
            Controls.Add(textBoxTipoMaterial);
            Controls.Add(lblCodigo);
            Controls.Add(button1);
            Controls.Add(textBoxPrenda);
            Controls.Add(Prenda);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FrmAgregar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Indumentaria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Prenda;
        private TextBox textBoxPrenda;
        private Button button1;
        private TextBox textBoxTipoMaterial;
        private Label lblCodigo;
        private TextBox textBoxCantidad;
        private Label Cantidad;
        private Button btnCancelar;
    }
}