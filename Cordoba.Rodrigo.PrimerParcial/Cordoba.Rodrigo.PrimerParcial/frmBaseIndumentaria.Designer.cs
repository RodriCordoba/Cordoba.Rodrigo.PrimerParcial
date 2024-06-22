namespace Cordoba.Rodrigo.PrimerParcial
{
    partial class frmBaseIndumentaria
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
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(120, 250);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(150, 70);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "button1";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(450, 250);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 70);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "button2";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmBaseIndumentaria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 361);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "frmBaseIndumentaria";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        #endregion
        public Button btnCancelar;
        protected Button btnAceptar;
    }
}