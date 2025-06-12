using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TubesCLO2_Kelompok5_GUI.Controllers;
using TubesCLO2_Kelompok5_GUI.Models;
using TubesCLO2_Kelompok5_GUI.Services;

namespace TubesCLO2_Kelompok5_GUI.Views
{
    public partial class MainMenuForm : Form
    {
        private MainController mainController;
        private ConfigurationService _configService;
        public MainMenuForm(MainController controller)
        {
            InitializeComponent();
            mainController = controller;
            _configService = mainController.ConfigService;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {

        }
    }
}
