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
    
    public partial class frmParametre : Form
    {
        private ManagerJeu managerJeu;

        public frmParametre(ManagerJeu managerJeu)
        {
            InitializeComponent();
            this.managerJeu = managerJeu;
        }

        private void btnFacile_Click(object sender, EventArgs e)
        {
            managerJeu.SetDifficulte(1);
            MessageBox.Show("Difficulté Facile selectionnée");
            this.Close();
        }

        private void btnMoyen_Click(object sender, EventArgs e)
        {
            managerJeu.SetDifficulte(2);
            MessageBox.Show("Difficulté Moyen selectionnée");
            this.Close();
        }

        private void btnDifficile_Click(object sender, EventArgs e)
        {
            managerJeu.SetDifficulte(3);
            MessageBox.Show("Difficulté Difficile selectionnée");
            this.Close();
        }
    }
}
