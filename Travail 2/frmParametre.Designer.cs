
namespace Travail_2
{
    partial class frmParametre
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
            this.btnFacile = new System.Windows.Forms.Button();
            this.btnDifficile = new System.Windows.Forms.Button();
            this.btnMoyen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFacile
            // 
            this.btnFacile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacile.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacile.Location = new System.Drawing.Point(12, 12);
            this.btnFacile.Name = "btnFacile";
            this.btnFacile.Size = new System.Drawing.Size(160, 58);
            this.btnFacile.TabIndex = 0;
            this.btnFacile.Text = "Facile";
            this.btnFacile.UseVisualStyleBackColor = true;
            this.btnFacile.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDifficile
            // 
            this.btnDifficile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDifficile.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDifficile.Location = new System.Drawing.Point(12, 140);
            this.btnDifficile.Name = "btnDifficile";
            this.btnDifficile.Size = new System.Drawing.Size(160, 58);
            this.btnDifficile.TabIndex = 1;
            this.btnDifficile.Text = "Difficile";
            this.btnDifficile.UseVisualStyleBackColor = true;
            this.btnDifficile.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnMoyen
            // 
            this.btnMoyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoyen.Location = new System.Drawing.Point(12, 76);
            this.btnMoyen.Name = "btnMoyen";
            this.btnMoyen.Size = new System.Drawing.Size(160, 58);
            this.btnMoyen.TabIndex = 2;
            this.btnMoyen.Text = "Moyen";
            this.btnMoyen.UseVisualStyleBackColor = true;
            this.btnMoyen.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmParametre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 211);
            this.Controls.Add(this.btnMoyen);
            this.Controls.Add(this.btnDifficile);
            this.Controls.Add(this.btnFacile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmParametre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametre";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFacile;
        private System.Windows.Forms.Button btnDifficile;
        private System.Windows.Forms.Button btnMoyen;
    }
}