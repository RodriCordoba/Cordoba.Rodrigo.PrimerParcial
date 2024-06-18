namespace Cordoba.Rodrigo.PrimerParcial
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUsuario = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtContraseña = new TextBox();
            btnIniciarSesion_click = new Button();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = SystemColors.InactiveCaption;
            txtUsuario.Location = new Point(58, 73);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(170, 23);
            txtUsuario.TabIndex = 0;
            txtUsuario.Text = "admin@admin.com";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 55);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 2;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 136);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 4;
            label2.Text = "Contraseña";
            // 
            // txtContraseña
            // 
            txtContraseña.BackColor = SystemColors.InactiveCaption;
            txtContraseña.Location = new Point(58, 154);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(170, 23);
            txtContraseña.TabIndex = 3;
            txtContraseña.Text = "12345678";
            // 
            // btnIniciarSesion_click
            // 
            btnIniciarSesion_click.BackColor = SystemColors.InactiveCaption;
            btnIniciarSesion_click.Location = new Point(135, 265);
            btnIniciarSesion_click.Name = "btnIniciarSesion_click";
            btnIniciarSesion_click.Size = new Size(93, 23);
            btnIniciarSesion_click.TabIndex = 5;
            btnIniciarSesion_click.Text = "Iniciar Sesion";
            btnIniciarSesion_click.UseVisualStyleBackColor = false;
            btnIniciarSesion_click.Click += button1_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(288, 332);
            Controls.Add(btnIniciarSesion_click);
            Controls.Add(label2);
            Controls.Add(txtContraseña);
            Controls.Add(label1);
            Controls.Add(txtUsuario);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private Label label1;
        private Label label2;
        private TextBox txtContraseña;
        private Button btnIniciarSesion_click;
    }
}