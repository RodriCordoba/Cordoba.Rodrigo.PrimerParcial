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
            lblConfirmar = new Label();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Location = new Point(103, 200);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 50);
            btnEliminar.TabIndex = 0;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.InactiveCaption;
            btnCancelar.Location = new Point(328, 200);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 50);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
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
            Controls.Add(btnCancelar);
            Controls.Add(btnEliminar);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FrmEliminar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eliminar indumentaria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnCancelar;
        private Label lblConfirmar;
    }
}