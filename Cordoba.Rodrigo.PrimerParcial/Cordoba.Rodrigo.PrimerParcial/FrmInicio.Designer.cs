namespace Cordoba.Rodrigo.PrimerParcial
{
    partial class FrmInicio
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
            statusStrip1 = new StatusStrip();
            labelOperador = new ToolStripStatusLabel();
            labelFecha = new ToolStripStatusLabel();
            button1 = new Button();
            button2 = new Button();
            btnEliminar = new Button();
            menuStrip1 = new MenuStrip();
            salirToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            cerrarProgramaToolStripMenuItem = new ToolStripMenuItem();
            listInd = new ListBox();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = SystemColors.InactiveCaption;
            statusStrip1.Dock = DockStyle.Top;
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelOperador, labelFecha });
            statusStrip1.Location = new Point(0, 24);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked;
            // 
            // labelOperador
            // 
            labelOperador.ActiveLinkColor = Color.Yellow;
            labelOperador.Name = "labelOperador";
            labelOperador.Size = new Size(162, 17);
            labelOperador.Text = "toolStripStatusLabelOperador";
            labelOperador.Click += labelOperador_Click;
            // 
            // labelFecha
            // 
            labelFecha.ActiveLinkColor = Color.Yellow;
            labelFecha.Name = "labelFecha";
            labelFecha.RightToLeftAutoMirrorImage = true;
            labelFecha.Size = new Size(143, 17);
            labelFecha.Text = "toolStripStatusLabelFecha";
            labelFecha.Click += labelFecha_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.Location = new Point(12, 347);
            button1.Name = "button1";
            button1.Size = new Size(156, 76);
            button1.TabIndex = 1;
            button1.Text = "AGREGAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Gold;
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(322, 347);
            button2.Name = "button2";
            button2.Size = new Size(156, 76);
            button2.TabIndex = 2;
            button2.Text = "MODIFICAR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Location = new Point(632, 347);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(156, 76);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            salirToolStripMenuItem.BackColor = SystemColors.ControlLight;
            salirToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesionToolStripMenuItem, cerrarProgramaToolStripMenuItem });
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(41, 20);
            salirToolStripMenuItem.Text = "Salir";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(161, 22);
            cerrarSesionToolStripMenuItem.Text = "Cerrar sesion";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // cerrarProgramaToolStripMenuItem
            // 
            cerrarProgramaToolStripMenuItem.Name = "cerrarProgramaToolStripMenuItem";
            cerrarProgramaToolStripMenuItem.Size = new Size(161, 22);
            cerrarProgramaToolStripMenuItem.Text = "Cerrar programa";
            cerrarProgramaToolStripMenuItem.Click += cerrarProgramaToolStripMenuItem_Click;
            // 
            // listInd
            // 
            listInd.FormattingEnabled = true;
            listInd.ItemHeight = 15;
            listInd.Location = new Point(12, 57);
            listInd.Name = "listInd";
            listInd.Size = new Size(776, 259);
            listInd.TabIndex = 5;
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(listInd);
            Controls.Add(btnEliminar);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MainMenuStrip = menuStrip1;
            Name = "FrmInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "INDUMENTARIA";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labelOperador;
        private ToolStripStatusLabel labelFecha;
        private Button button1;
        private Button button2;
        private Button btnEliminar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem cerrarProgramaToolStripMenuItem;
        private ListBox listInd;
    }
}