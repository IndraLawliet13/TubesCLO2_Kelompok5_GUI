using System;
using System.Globalization;
using System.Windows.Forms;
using TubesCLO2_Kelompok5_GUI.Controllers;
using TubesCLO2_Kelompok5_GUI.Models;
using TubesCLO2_Kelompok5_GUI.Services;
using TubesCLO2_Kelompok5_GUI.Utils;
// Assuming InputValidator might be in a different namespace, e.g., TubesCLO2_Kelompok5_GUI.Utils;
// For now, we'll assume its methods are static or part of a service if used.

namespace TubesCLO2_Kelompok5_GUI.Views
{
    public partial class TambahMahasiswaForm : Form
    {
        private readonly MainController _mainController;
        private readonly ConfigurationService _configService;

        public TambahMahasiswaForm(MainController controller)
        {
            InitializeComponent();
            _mainController = controller;
            _configService = controller.ConfigService; // Assuming ConfigService is a public property of MainController

            // Connect event handlers
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);

            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            this.Text = _configService.GetMessage("TambahMahasiswaFormTitle") ?? "Tambah Mahasiswa";

            // Labels
            lblNIM.Text = _configService.GetMessage("LabelNIM") ?? "NIM:";
            lblNama.Text = _configService.GetMessage("LabelNama") ?? "Nama:";
            lblJurusan.Text = _configService.GetMessage("LabelJurusan") ?? "Jurusan:";
            lblIPK.Text = _configService.GetMessage("LabelIPK") ?? "IPK:";

            // Buttons
            btnSimpan.Text = _configService.GetMessage("ButtonSimpan") ?? "Simpan";
            btnKembali.Text = _configService.GetMessage("ButtonKembali") ?? "Kembali";
        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            string nim = txtNIM.Text.Trim();
            string nama = txtNama.Text.Trim();
            string jurusan = txtJurusan.Text.Trim();
            string ipkString = txtIPK.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(nim))
            {
                MessageBox.Show(_configService.GetMessage("ValidationNIMEmpty") ?? "NIM tidak boleh kosong.",
                                _configService.GetMessage("ValidationErrorTitle") ?? "Validasi Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNIM.Focus();
                return;
            }

            // Example of using InputValidator if it exists and has a static method
            if (!InputValidator.IsValidNIM(nim)) // Assuming IsValidNIM is a static method
            {
                MessageBox.Show(_configService.GetMessage("ValidationNIMInvalid") ?? "Format NIM tidak valid.",
                                _configService.GetMessage("ValidationErrorTitle") ?? "Validasi Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNIM.Focus();
                return;
            }


            if (string.IsNullOrEmpty(nama))
            {
                MessageBox.Show(_configService.GetMessage("ValidationNamaEmpty") ?? "Nama tidak boleh kosong.",
                                _configService.GetMessage("ValidationErrorTitle") ?? "Validasi Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNama.Focus();
                return;
            }

            double ipk;
            // Use CultureInfo.InvariantCulture for parsing to handle '.' as decimal separator consistently
            if (!double.TryParse(ipkString, NumberStyles.Any, CultureInfo.InvariantCulture, out ipk))
            {
                MessageBox.Show(_configService.GetMessage("ValidationIPKInvalid") ?? "IPK harus berupa angka yang valid (gunakan titik '.' sebagai pemisah desimal).",
                                _configService.GetMessage("ValidationErrorTitle") ?? "Validasi Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIPK.Focus();
                return;
            }

            if (ipk < 0 || ipk > 4)
            {
                MessageBox.Show(_configService.GetMessage("ValidationIPKOutOfRange") ?? "IPK harus antara 0 dan 4.",
                                _configService.GetMessage("ValidationErrorTitle") ?? "Validasi Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIPK.Focus();
                return;
            }


            Mahasiswa newMahasiswa = new Mahasiswa
            {
                NIM = nim,
                Nama = nama,
                Jurusan = jurusan,
                IPK = ipk
            };

            try
            {
                // Assuming AddMahasiswaAsync returns an ApiResponse or similar structure
                // For now, let's assume it might throw an exception on failure or return a boolean/status.
                // If AddMahasiswaAsync is designed to return a more complex object (like ApiResponse),
                // the handling below should be adjusted.

                // For this example, let's assume AddMahasiswaAsync returns void and throws exception on error
                // or returns a simple boolean for success.
                // If it returns an object like `ApiResponse`, you would check `apiResponse.IsSuccessStatusCode`.

                await _mainController.AddMahasiswaAsync(newMahasiswa); // Let's assume this is the call

                MessageBox.Show(
                    string.Format(_configService.GetMessage("AddSuccessMessage") ?? "Mahasiswa dengan NIM {0} berhasil ditambahkan.", nim),
                    _configService.GetMessage("SuccessTitle") ?? "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // Set DialogResult to indicate success
                this.Close();
            }
            catch (Exception ex)
            {
                // This catch block will handle exceptions thrown by AddMahasiswaAsync
                // or other unexpected errors during the process.
                MessageBox.Show(
                    (_configService.GetMessage("AddErrorMessage") ?? "Gagal menambahkan mahasiswa: ") + ex.Message,
                    _configService.GetMessage("ErrorTitle") ?? "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel; // Optionally set DialogResult if form remains open
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Indicate form was closed without saving
            this.Close();
        }
    }
}
