﻿using System;
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
            this.Close();
        }

        private void btnMoyen_Click(object sender, EventArgs e)
        {
            managerJeu.SetDifficulte(2);
            this.Close();
        }

        private void btnDifficile_Click(object sender, EventArgs e)
        {
            managerJeu.SetDifficulte(3);
            this.Close();
        }
    }
}
