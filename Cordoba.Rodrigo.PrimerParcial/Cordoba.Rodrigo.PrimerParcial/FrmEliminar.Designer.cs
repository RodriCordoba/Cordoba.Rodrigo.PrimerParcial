namespace Cordoba.Rodrigo.PrimerParcial
{
    partial class FrmEliminar
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
            btnEliminar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Location = new Point(120, 250);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 70);
            btnEliminar.TabIndex = 0;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.InactiveCaption;
            btnCancelar.Location = new Point(450, 250);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 70);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmEliminar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(734, 361);
            Controls.Add(btnCancelar);
            Controls.Add(btnEliminar);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FrmEliminar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eliminar indumentaria";
            ResumeLayout(false);
        }

        #endregion

        private Button btnEliminar;
        private Button btnCancelar;
    }
}