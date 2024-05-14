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
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelOperador, labelFecha });
            statusStrip1.Location = new Point(0, 428);
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
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Name = "FrmInicio";
            Text = "FrmInicio";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labelOperador;
        private ToolStripStatusLabel labelFecha;
    }
}