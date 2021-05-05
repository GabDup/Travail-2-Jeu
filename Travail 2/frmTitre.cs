using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travail_2
{
    public partial class frmTitre : Form
    {
        public frmTitre()
        {
            InitializeComponent();
        }

        private void frmTitre_Load(object sender, EventArgs e)
        {
            lstInformation.Items.Add("Travail #2");
            lstInformation.Items.Add("Par Antoine L'Archer et Gabriel Duperré");
            lstInformation.Items.Add("Mai 2021");
            lstInformation.Items.Add("F : Tirer / Flèches : Bouger / Esc : Quitter");
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnParametre_Click(object sender, EventArgs e)
        {
            frmParametre frm = new frmParametre();
            frm.ShowDialog();
        }

        private void btnJouer_Click(object sender, EventArgs e)
        {
            frmJeu frm = new frmJeu();
            frm.ShowDialog();
        }
    }
}
