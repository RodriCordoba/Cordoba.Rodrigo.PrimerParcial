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
            lblConfirmar = new Label();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.Red;
            btnAceptar.Location = new Point(105, 200);
            btnAceptar.Size = new Size(100, 50);
            btnAceptar.Text = "Eliminar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ActiveCaption;
            btnCancelar.Location = new Point(329, 200);
            btnCancelar.Size = new Size(100, 50);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // lblConfirmar
            // 
            lblConfirmar.AutoSize = true;
            lblConfirmar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblConfirmar.Location = new Point(46, 40);
            lblConfirmar.Name = "lblConfirmar";
            lblConfirmar.Size = new Size(0, 15);
            lblConfirmar.TabIndex = 2;
            // 
            // FrmEliminar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(533, 262);
            Controls.Add(lblConfirmar);
            Name = "FrmEliminar";
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(lblConfirmar, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblConfirmar;
    }
}