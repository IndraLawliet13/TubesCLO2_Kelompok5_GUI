using System;
using System.Globalization;
using System.Windows.Forms;
using TubesCLO2_Kelompok5_GUI.Controllers;
using TubesCLO2_Kelompok5_GUI.Models;
using TubesCLO2_Kelompok5_GUI.Services;

namespace TubesCLO2_Kelompok5_GUI.Views
{
    public partial class EditMahasiswaForm : Form
    {
        private readonly MainController _mainController;
        private readonly ConfigurationService _configService;
        private readonly Mahasiswa _mahasiswaToEdit;

        // Constructor for actual use
        public EditMahasiswaForm(MainController controller, Mahasiswa mahasiswaToEdit)
        {
            InitializeComponent();
            _mainController = controller;
            _configService = controller.ConfigService;
            _mahasiswaToEdit = mahasiswaToEdit;

            // Connect event handlers
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);

            PopulateFields();
            ApplyLocalization();
        }

        // Constructor for design time (optional, if MainController and Mahasiswa are problematic for designer)
        // public EditMahasiswaForm()
        // {
        //     InitializeComponent();
        //     // Design-time specific initializations, if any
        //     // For example, you might set default text for labels if _configService is not available
        //     if (DesignMode)
        //     {
        //          lblNIM.Text = "NIM (Design):";
        //          // ... and so on for other controls
        //     }
        // }


        private void PopulateFields()
        {
            if (_mahasiswaToEdit != null)
            {
                txtNIM.Text = _mahasiswaToEdit.NIM;
                txtNama.Text = _mahasiswaToEdit.Nama;
                txtJurusan.Text = _mahasiswaToEdit.Jurusan;
                // Format IPK using InvariantCulture to ensure '.' is used as decimal separator
                txtIPK.Text = _mahasiswaToEdit.IPK.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void ApplyLocalization()
        {
            this.Text = _configService.GetMessage("EditMahasiswaFormTitle") ?? "Edit Mahasiswa";

            lblNIM.Text = _configService.GetMessage("LabelNIM") ?? "NIM:";
            lblNama.Text = _configService.GetMessage("LabelNama") ?? "Nama:";
            lblJurusan.Text = _configService.GetMessage("LabelJurusan") ?? "Jurusan:";
            lblIPK.Text = _configService.GetMessage("LabelIPK") ?? "IPK:";

            btnSimpan.Text = _configService.GetMessage("ButtonSimpan") ?? "Simpan";
            btnKembali.Text = _configService.GetMessage("ButtonKembali") ?? "Kembali";
        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text.Trim();
            string jurusan = txtJurusan.Text.Trim();
            string ipkString = txtIPK.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(nama))
            {
                MessageBox.Show(_configService.GetMessage("ValidationNamaEmpty") ?? "Nama tidak boleh kosong.",
                                _configService.GetMessage("ValidationErrorTitle") ?? "Validasi Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNama.Focus();
                return;
            }

            double ipk;
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

            Mahasiswa updatedMahasiswa = new Mahasiswa
            {
                NIM = _mahasiswaToEdit.NIM, // NIM is not changed
                Nama = nama,
                Jurusan = jurusan,
                IPK = ipk
            };

            try
            {
                // Assuming UpdateMahasiswaAsync returns void or a simple boolean
                // Adjust if it returns a more complex ApiResponse object
                await _mainController.UpdateMahasiswaAsync(_mahasiswaToEdit.NIM, updatedMahasiswa);

                MessageBox.Show(
                    string.Format(_configService.GetMessage("UpdateSuccessMessage") ?? "Data mahasiswa dengan NIM {0} berhasil diperbarui.", _mahasiswaToEdit.NIM),
                    _configService.GetMessage("SuccessTitle") ?? "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    (_configService.GetMessage("UpdateErrorMessage") ?? "Gagal memperbarui data mahasiswa: ") + ex.Message,
                    _configService.GetMessage("ErrorTitle") ?? "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, set DialogResult.Cancel or handle as needed if the form should remain open
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
