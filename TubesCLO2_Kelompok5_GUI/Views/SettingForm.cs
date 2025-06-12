using System;
using System.Windows.Forms;
using TubesCLO2_Kelompok5_GUI.Services; // For ConfigurationService
// Assuming MainMenuForm might be needed if direct refresh call was used, but we'll use DialogResult approach.
// using TubesCLO2_Kelompok5_GUI.Views; 

namespace TubesCLO2_Kelompok5_GUI.Views
{
    public partial class SettingForm : Form
    {
        private readonly ConfigurationService _configService;

        public SettingForm(ConfigurationService configService)
        {
            InitializeComponent();
            _configService = configService;

            // Connect event handlers
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);

            ApplyLocalization(); // Apply texts based on current language
            LoadCurrentLanguage(); // Set radio button based on current language
        }

        // Constructor for design time (optional)
        // public SettingForm()
        // {
        //     InitializeComponent();
        //     // Mock _configService or use default texts if needed for design view
        //     if (DesignMode)
        //     {
        //         lblPilihBahasa.Text = "Pilih Bahasa (Design):";
        //         rbIndonesia.Text = "Indonesia (Design)";
        //         rbEnglish.Text = "English (Design)";
        //         btnSimpan.Text = "Simpan (Design)";
        //         btnKembali.Text = "Kembali (Design)";
        //         this.Text = "Pengaturan (Design)";
        //     }
        // }


        private void ApplyLocalization()
        {
            this.Text = _configService.GetMessage("SettingFormTitle") ?? "Pengaturan";
            lblPilihBahasa.Text = _configService.GetMessage("ChooseLanguageLabel") ?? "Pilih Bahasa:";
            rbIndonesia.Text = _configService.GetMessage("IndonesianLanguage") ?? "Indonesia";
            rbEnglish.Text = _configService.GetMessage("EnglishLanguage") ?? "English";
            btnSimpan.Text = _configService.GetMessage("SaveButton") ?? "Simpan";
            btnKembali.Text = _configService.GetMessage("BackButton") ?? "Kembali";
        }

        private void LoadCurrentLanguage()
        {
            string currentLang = _configService.GetCurrentLanguage();
            if (currentLang == "id")
            {
                rbIndonesia.Checked = true;
            }
            else if (currentLang == "en")
            {
                rbEnglish.Checked = true;
            }
            else
            {
                rbIndonesia.Checked = true; // Default to Indonesian if language is not set or unknown
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string selectedLanguageCode = rbIndonesia.Checked ? "id" : "en";

            string oldLanguage = _configService.GetCurrentLanguage();
            _configService.SetLanguage(selectedLanguageCode);

            // Re-apply localization to this form immediately with the new language
            ApplyLocalization();

            // Show confirmation message in the new language
            MessageBox.Show(
                _configService.GetMessage("LanguageChangedMessage") ?? "Bahasa telah diubah.",
                _configService.GetMessage("SuccessTitle") ?? "Sukses", // Assuming a generic success title key
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK; // Signal to calling form that changes were made
            this.Close();
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
