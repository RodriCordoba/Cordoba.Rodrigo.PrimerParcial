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
            btnModificar = new Button();
            textBox2 = new TextBox();
            lblCantidad = new Label();
            btnCancelar = new Button();
            textBoxCodigo = new TextBox();
            label1 = new Label();
            cmbMaterial = new ComboBox();
            lblMaterial = new Label();
            SuspendLayout();
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.Gold;
            btnModificar.Location = new Point(120, 250);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(150, 70);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(494, 112);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(494, 74);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 3;
            lblCantidad.Text = "Cantidad";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.InactiveCaption;
            btnCancelar.Location = new Point(444, 250);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 70);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.Location = new Point(321, 112);
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.Size = new Size(100, 23);
            textBoxCodigo.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(321, 74);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 6;
            label1.Text = "Codigo";
            // 
            // cmbMaterial
            // 
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(120, 112);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(121, 23);
            cmbMaterial.TabIndex = 8;
            cmbMaterial.SelectedIndexChanged += cmbMaterial_SelectedIndexChanged;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Location = new Point(120, 74);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(50, 15);
            lblMaterial.TabIndex = 12;
            lblMaterial.Text = "Material";
            // 
            // FrmModificar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(734, 361);
            Controls.Add(lblMaterial);
            Controls.Add(cmbMaterial);
            Controls.Add(textBoxCodigo);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(textBox2);
            Controls.Add(lblCantidad);
            Controls.Add(btnModificar);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FrmModificar";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnModificar;
        private TextBox textBox2;
        private Label lblCantidad;
        private Button btnCancelar;
        private TextBox textBoxCodigo;
        private Label label1;
        private ComboBox cmbMaterial;
        private Label lblMaterial;
    }
}