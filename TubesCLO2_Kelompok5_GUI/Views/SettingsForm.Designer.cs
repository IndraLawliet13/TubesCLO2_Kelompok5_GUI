using TubesCLO2_Kelompok5_GUI.Controllers;

namespace TubesCLO2_Kelompok5_GUI.Views
{
    public partial class SettingsForm : Form
    {
        private readonly SettingsController _controller;
        public SettingsForm()
        {
            InitializeComponent();
            _controller = new SettingsController();
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            string currentLang = _controller.GetCurrentLanguage();
            if (currentLang.ToLower() == "en")
            {
                rbEnglish.Checked = true;
            }
            else
            {
                rbIndonesia.Checked = true;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            string selectedLang = rbIndonesia.Checked ? "id" : "en";
            _controller.SaveLanguage(selectedLang);
            MessageBox.Show("Pengaturan bahasa disimpan. Aplikasi mungkin perlu di-restart untuk menerapkan sepenuhnya.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnBackSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private GroupBox groupBox1;
        private RadioButton rbEnglish;
        private RadioButton rbIndonesia;
        private Button btnSaveSettings;
        private Button btnBackSettings;
    }
}