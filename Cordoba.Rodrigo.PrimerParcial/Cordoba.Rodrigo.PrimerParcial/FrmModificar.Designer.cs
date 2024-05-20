namespace Cordoba.Rodrigo.PrimerParcial
{
    partial class FrmModificar
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
            lblPrenda = new Label();
            textBoxPrenda = new TextBox();
            btnModificar = new Button();
            textBox2 = new TextBox();
            lblCantidad = new Label();
            btnCancelar = new Button();
            textBoxCodigo = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblPrenda
            // 
            lblPrenda.AutoSize = true;
            lblPrenda.Location = new Point(90, 112);
            lblPrenda.Name = "lblPrenda";
            lblPrenda.Size = new Size(44, 15);
            lblPrenda.TabIndex = 0;
            lblPrenda.Text = "Prenda";
            // 
            // textBoxPrenda
            // 
            textBoxPrenda.Location = new Point(90, 150);
            textBoxPrenda.Name = "textBoxPrenda";
            textBoxPrenda.Size = new Size(100, 23);
            textBoxPrenda.TabIndex = 1;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.InactiveCaption;
            btnModificar.Location = new Point(120, 250);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(150, 70);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(540, 150);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(540, 112);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 3;
            lblCantidad.Text = "Cantidad";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.InactiveCaption;
            btnCancelar.Location = new Point(450, 250);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 70);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.Location = new Point(315, 150);
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.Size = new Size(100, 23);
            textBoxCodigo.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(315, 112);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 6;
            label1.Text = "Codigo";
            // 
            // FrmModificar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(734, 361);
            Controls.Add(textBoxCodigo);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(textBox2);
            Controls.Add(lblCantidad);
            Controls.Add(btnModificar);
            Controls.Add(textBoxPrenda);
            Controls.Add(lblPrenda);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FrmModificar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Indumentaria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPrenda;
        private TextBox textBoxPrenda;
        private Button btnModificar;
        private TextBox textBox2;
        private Label lblCantidad;
        private Button btnCancelar;
        private TextBox textBoxCodigo;
        private Label label1;
    }
}