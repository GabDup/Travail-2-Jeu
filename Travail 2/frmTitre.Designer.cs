
namespace Travail_2
{
    partial class frmTitre
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
            this.btnJouer = new System.Windows.Forms.Button();
            this.btnParametre = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.lstInformation = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnJouer
            // 
            this.btnJouer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnJouer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJouer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJouer.Location = new System.Drawing.Point(12, 12);
            this.btnJouer.Name = "btnJouer";
            this.btnJouer.Size = new System.Drawing.Size(203, 69);
            this.btnJouer.TabIndex = 0;
            this.btnJouer.Text = "Jouer";
            this.btnJouer.UseVisualStyleBackColor = false;
            this.btnJouer.Click += new System.EventHandler(this.btnJouer_Click);
            // 
            // btnParametre
            // 
            this.btnParametre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParametre.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParametre.Location = new System.Drawing.Point(12, 125);
            this.btnParametre.Name = "btnParametre";
            this.btnParametre.Size = new System.Drawing.Size(203, 53);
            this.btnParametre.TabIndex = 1;
            this.btnParametre.Text = "Paramètres";
            this.btnParametre.UseVisualStyleBackColor = true;
            this.btnParametre.Click += new System.EventHandler(this.btnParametre_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.Location = new System.Drawing.Point(12, 184);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(203, 53);
            this.btnQuitter.TabIndex = 2;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // lstInformation
            // 
            this.lstInformation.FormattingEnabled = true;
            this.lstInformation.Location = new System.Drawing.Point(221, 12);
            this.lstInformation.Name = "lstInformation";
            this.lstInformation.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstInformation.Size = new System.Drawing.Size(395, 225);
            this.lstInformation.TabIndex = 3;
            // 
            // frmTitre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 250);
            this.Controls.Add(this.lstInformation);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnParametre);
            this.Controls.Add(this.btnJouer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTitre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Titre";
            this.Load += new System.EventHandler(this.frmTitre_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJouer;
        private System.Windows.Forms.Button btnParametre;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.ListBox lstInformation;
    }
}