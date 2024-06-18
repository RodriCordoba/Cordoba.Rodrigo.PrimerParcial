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
            button1 = new Button();
            txtCodigo = new TextBox();
            lblCodigo = new Label();
            textBoxCantidad = new TextBox();
            Cantidad = new Label();
            btnCancelar = new Button();
            radioButton1 = new RadioButton();
            cmbMaterial = new ComboBox();
            rdbCampera = new RadioButton();
            rdbRemera = new RadioButton();
            lblMaterial = new Label();
            rdbBermuda = new RadioButton();
            rdbEstampado = new RadioButton();
            rdbCapucha = new RadioButton();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Prenda
            // 
            Prenda.AutoSize = true;
            Prenda.Location = new Point(38, 72);
            Prenda.Name = "Prenda";
            Prenda.Size = new Size(44, 15);
            Prenda.TabIndex = 0;
            Prenda.Text = "Prenda";
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
            // txtCodigo
            // 
            txtCodigo.Location = new Point(450, 110);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 4;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(450, 72);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(46, 15);
            lblCodigo.TabIndex = 3;
            lblCodigo.Text = "Codigo";
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.Location = new Point(594, 110);
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(100, 23);
            textBoxCantidad.TabIndex = 6;
            // 
            // Cantidad
            // 
            Cantidad.AutoSize = true;
            Cantidad.Location = new Point(594, 72);
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
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(38, 110);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(72, 19);
            radioButton1.TabIndex = 8;
            radioButton1.TabStop = true;
            radioButton1.Text = "Pantalon";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // cmbMaterial
            // 
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(284, 110);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(121, 23);
            cmbMaterial.TabIndex = 9;
            // 
            // rdbCampera
            // 
            rdbCampera.AutoSize = true;
            rdbCampera.Location = new Point(38, 160);
            rdbCampera.Name = "rdbCampera";
            rdbCampera.Size = new Size(73, 19);
            rdbCampera.TabIndex = 10;
            rdbCampera.TabStop = true;
            rdbCampera.Text = "Campera";
            rdbCampera.UseVisualStyleBackColor = true;
            // 
            // rdbRemera
            // 
            rdbRemera.AutoSize = true;
            rdbRemera.Location = new Point(38, 135);
            rdbRemera.Name = "rdbRemera";
            rdbRemera.Size = new Size(65, 19);
            rdbRemera.TabIndex = 11;
            rdbRemera.TabStop = true;
            rdbRemera.Text = "Remera";
            rdbRemera.UseVisualStyleBackColor = true;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Location = new Point(284, 72);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(50, 15);
            lblMaterial.TabIndex = 12;
            lblMaterial.Text = "Material";
            // 
            // rdbBermuda
            // 
            rdbBermuda.AutoSize = true;
            rdbBermuda.Location = new Point(5, 22);
            rdbBermuda.Name = "rdbBermuda";
            rdbBermuda.Size = new Size(73, 19);
            rdbBermuda.TabIndex = 13;
            rdbBermuda.TabStop = true;
            rdbBermuda.Text = "Bermuda";
            rdbBermuda.UseVisualStyleBackColor = true;
            // 
            // rdbEstampado
            // 
            rdbEstampado.AutoSize = true;
            rdbEstampado.Location = new Point(6, 47);
            rdbEstampado.Name = "rdbEstampado";
            rdbEstampado.Size = new Size(109, 19);
            rdbEstampado.TabIndex = 14;
            rdbEstampado.TabStop = true;
            rdbEstampado.Text = "Con estampado";
            rdbEstampado.UseVisualStyleBackColor = true;
            // 
            // rdbCapucha
            // 
            rdbCapucha.AutoSize = true;
            rdbCapucha.Location = new Point(6, 72);
            rdbCapucha.Name = "rdbCapucha";
            rdbCapucha.Size = new Size(95, 19);
            rdbCapucha.TabIndex = 15;
            rdbCapucha.TabStop = true;
            rdbCapucha.Text = "Con capucha";
            rdbCapucha.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbBermuda);
            groupBox1.Controls.Add(rdbCapucha);
            groupBox1.Controls.Add(rdbEstampado);
            groupBox1.Location = new Point(131, 88);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(147, 97);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // FrmAgregar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(734, 361);
            Controls.Add(groupBox1);
            Controls.Add(lblMaterial);
            Controls.Add(rdbRemera);
            Controls.Add(rdbCampera);
            Controls.Add(cmbMaterial);
            Controls.Add(radioButton1);
            Controls.Add(btnCancelar);
            Controls.Add(textBoxCantidad);
            Controls.Add(Cantidad);
            Controls.Add(txtCodigo);
            Controls.Add(lblCodigo);
            Controls.Add(button1);
            Controls.Add(Prenda);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FrmAgregar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            Load += FrmAgregar_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Prenda;
        private Button button1;
        private TextBox txtCodigo;
        private Label lblCodigo;
        private TextBox textBoxCantidad;
        private Label Cantidad;
        private Button btnCancelar;
        private RadioButton radioButton1;
        private ComboBox cmbMaterial;
        private RadioButton rdbCampera;
        private RadioButton rdbRemera;
        private Label lblMaterial;
        private RadioButton rdbBermuda;
        private RadioButton rdbEstampado;
        private RadioButton rdbCapucha;
        private GroupBox groupBox1;
    }
}