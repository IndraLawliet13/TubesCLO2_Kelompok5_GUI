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
            _configService = mainController.ConfigService; // Assuming ConfigService is accessible this way
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.dataGridViewMahasiswa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMahasiswa_CellContentClick);
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // Ensure btnTambah_Click is connected if not already by designer
            // this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click); 
        }

        private async void MainMenuForm_Load(object sender, EventArgs e)
        {
            ApplyLocalization();
            AddButtonColumns();
            await LoadMahasiswaDataAsync();
        }

        private async Task LoadMahasiswaDataAsync()
        {
            try
            {
                var mahasiswaList = await mainController.GetAllMahasiswaAsync();
                // Assuming Mahasiswa class has properties like NIM, Nama, etc.
                // And these are public and can be bound to DataGridView
                dataGridViewMahasiswa.DataSource = mahasiswaList;

                // Optionally, configure columns if not auto-generated as desired
                // Example: dataGridViewMahasiswa.Columns["NIM"].HeaderText = _configService.GetMessage("NIMColumnHeader");
            }
            catch (Exception ex)
            {
                MessageBox.Show(_configService.GetMessage("LoadDataError") + $": {ex.Message}",
                                _configService.GetMessage("ErrorTitle"),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButtonColumns()
        {
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditColumn";
            editButtonColumn.HeaderText = _configService.GetMessage("EditColumnHeader") ?? "Edit";
            editButtonColumn.Text = _configService.GetMessage("EditButtonText") ?? "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;
            dataGridViewMahasiswa.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteColumn";
            deleteButtonColumn.HeaderText = _configService.GetMessage("DeleteColumnHeader") ?? "Delete";
            deleteButtonColumn.Text = _configService.GetMessage("DeleteButtonText") ?? "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridViewMahasiswa.Columns.Add(deleteButtonColumn);
        }

        private async void dataGridViewMahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header clicks

            // Assuming "NIM" is a valid column name in your Mahasiswa model and DataGridView
            // And it's not hidden or has a different name.
            // You might need to adjust "NIM" to the actual column name if it differs.
            string nim = dataGridViewMahasiswa.Rows[e.RowIndex].Cells["NIM"].Value?.ToString();
            if (nim == null)
            {
                // This can happen if the NIM column is not found or value is null.
                // Consider logging this or showing a more specific error.
                MessageBox.Show(_configService.GetMessage("ErrorNIMNotFound") ?? "NIM tidak ditemukan.",
                                _configService.GetMessage("ErrorTitle") ?? "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridViewMahasiswa.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                var confirmResult = MessageBox.Show(
                    string.Format(_configService.GetMessage("ConfirmDeleteMessage") ?? "Apakah Anda yakin ingin menghapus mahasiswa dengan NIM {0}?", nim),
                    _configService.GetMessage("ConfirmDeleteTitle") ?? "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        await mainController.DeleteMahasiswaAsync(nim);
                        MessageBox.Show(
                            string.Format(_configService.GetMessage("DeleteSuccessMessage") ?? "Mahasiswa dengan NIM {0} berhasil dihapus.", nim),
                            _configService.GetMessage("SuccessTitle") ?? "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadMahasiswaDataAsync(); // Refresh data
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            (_configService.GetMessage("DeleteErrorMessage") ?? "Gagal menghapus mahasiswa: ") + ex.Message,
                            _configService.GetMessage("ErrorTitle") ?? "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (dataGridViewMahasiswa.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                // Placeholder for Edit functionality
                MessageBox.Show($"Edit button clicked for NIM: {nim}", "Edit Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TODO: Implement Edit Mahasiswa functionality
                // Example:
                // EditMahasiswaForm editForm = new EditMahasiswaForm(nim, mainController, _configService);
                // editForm.ShowDialog();
                // await LoadMahasiswaDataAsync(); // Refresh data if changes were made
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            // Placeholder for Add functionality
            MessageBox.Show("Tambah button clicked", "Add Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implement Add Mahasiswa functionality
            // Example:
            // AddMahasiswaForm addForm = new AddMahasiswaForm(mainController, _configService);
            // addForm.ShowDialog();
            // await LoadMahasiswaDataAsync(); // Refresh data if a new mahasiswa was added
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            // Placeholder for Settings functionality
            MessageBox.Show(_configService.GetMessage("SettingsNotImplementedMessage") ?? "Fungsi pengaturan belum diimplementasikan.",
                           _configService.GetMessage("InformationTitle") ?? "Informasi",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implement Settings functionality
            // Example:
            // SettingsForm settingsForm = new SettingsForm(_configService);
            // settingsForm.ShowDialog();
            // ApplyLocalization(); // Re-apply localization if settings changed language
            // await LoadMahasiswaDataAsync(); // Refresh data if needed
        }

        private void ApplyLocalization()
        {
            this.Text = _configService.GetMessage("MainMenuFormTitle") ?? "Main Menu";
            btnTambah.Text = _configService.GetMessage("AddButtonText") ?? "Tambah";
            btnSetting.Text = _configService.GetMessage("SettingsButtonText") ?? "Pengaturan";

            // If DataGridView columns are added dynamically and need localization for headers
            // Or if specific columns added via designer need header localization
            // Example for a pre-existing column named "NIM_Column" in the designer:
            // if (dataGridViewMahasiswa.Columns["NIM_Column"] != null)
            // {
            //     dataGridViewMahasiswa.Columns["NIM_Column"].HeaderText = _configService.GetMessage("NIMColumnHeader") ?? "NIM";
            // }
            // if (dataGridViewMahasiswa.Columns["Nama_Column"] != null)
            // {
            //      dataGridViewMahasiswa.Columns["Nama_Column"].HeaderText = _configService.GetMessage("NameColumnHeader") ?? "Nama";
            // }
            // Note: Edit and Delete column headers are set in AddButtonColumns using _configService
        }
    }
}
