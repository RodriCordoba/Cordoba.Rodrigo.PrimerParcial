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
            textBox2 = new TextBox();
            lblCantidad = new Label();
            textBoxCodigo = new TextBox();
            label1 = new Label();
            cmbMaterial = new ComboBox();
            lblMaterial = new Label();
            grp = new GroupBox();
            rdbBermuda = new RadioButton();
            rdbCapucha = new RadioButton();
            rdbEstampado = new RadioButton();
            grp.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ActiveCaption;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.Gold;
            btnAceptar.Location = new Point(117, 250);
            btnAceptar.Text = "Modificar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(617, 112);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(617, 74);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 3;
            lblCantidad.Text = "Cantidad";
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.Location = new Point(444, 112);
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.Size = new Size(100, 23);
            textBoxCodigo.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(444, 74);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 6;
            label1.Text = "Codigo";
            // 
            // cmbMaterial
            // 
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(253, 112);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(121, 23);
            cmbMaterial.TabIndex = 8;
            cmbMaterial.SelectedIndexChanged += cmbMaterial_SelectedIndexChanged;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Location = new Point(253, 74);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(50, 15);
            lblMaterial.TabIndex = 12;
            lblMaterial.Text = "Material";
            // 
            // grp
            // 
            grp.Controls.Add(rdbBermuda);
            grp.Controls.Add(rdbCapucha);
            grp.Controls.Add(rdbEstampado);
            grp.Location = new Point(51, 38);
            grp.Name = "grp";
            grp.Size = new Size(147, 97);
            grp.TabIndex = 13;
            grp.TabStop = false;
            // 
            // rdbBermuda
            // 
            rdbBermuda.AutoSize = true;
            rdbBermuda.Location = new Point(6, 22);
            rdbBermuda.Name = "rdbBermuda";
            rdbBermuda.Size = new Size(73, 19);
            rdbBermuda.TabIndex = 13;
            rdbBermuda.TabStop = true;
            rdbBermuda.Text = "Bermuda";
            rdbBermuda.UseVisualStyleBackColor = true;
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
            // FrmModificar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(734, 361);
            Controls.Add(grp);
            Controls.Add(lblMaterial);
            Controls.Add(cmbMaterial);
            Controls.Add(textBoxCodigo);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(lblCantidad);
            Name = "FrmModificar";
            Controls.SetChildIndex(lblCantidad, 0);
            Controls.SetChildIndex(textBox2, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(textBoxCodigo, 0);
            Controls.SetChildIndex(cmbMaterial, 0);
            Controls.SetChildIndex(lblMaterial, 0);
            Controls.SetChildIndex(grp, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            grp.ResumeLayout(false);
            grp.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox2;
        private Label lblCantidad;
        private TextBox textBoxCodigo;
        private Label label1;
        private ComboBox cmbMaterial;
        private Label lblMaterial;
        private GroupBox grp;
        private RadioButton rdbBermuda;
        private RadioButton rdbCapucha;
        private RadioButton rdbEstampado;
    }
}