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
                Mahasiswa selectedMahasiswa = dataGridViewMahasiswa.Rows[e.RowIndex].DataBoundItem as Mahasiswa;
                if (selectedMahasiswa != null)
                {
                    EditMahasiswaForm editForm = new EditMahasiswaForm(mainController, selectedMahasiswa);
                    DialogResult result = editForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        await LoadMahasiswaDataAsync(); // Refresh data if changes were made
                    }
                }
                else
                {
                    // Optionally, handle the case where selectedMahasiswa is null
                    MessageBox.Show(_configService.GetMessage("ErrorRetrievingMahasiswa") ?? "Gagal mengambil data mahasiswa.",
                                    _configService.GetMessage("ErrorTitle") ?? "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnTambah_Click(object sender, EventArgs e)
        {
            // Create an instance of TambahMahasiswaForm, passing the mainController instance
            TambahMahasiswaForm tambahMahasiswaForm = new TambahMahasiswaForm(mainController);

            // Show the TambahMahasiswaForm as a dialog
            DialogResult result = tambahMahasiswaForm.ShowDialog();

            // After the dialog is closed, check if its DialogResult is DialogResult.OK
            if (result == DialogResult.OK)
            {
                // If it is DialogResult.OK, call await LoadMahasiswaDataAsync() to refresh the student list
                await LoadMahasiswaDataAsync();
            }
        }

        private async void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingsForm = new SettingForm(mainController.ConfigService);
            DialogResult result = settingsForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                ApplyLocalization();
                await LoadMahasiswaDataAsync(); // Refresh data to update DataGridView headers/texts
            }
        }

        private void ApplyLocalization()
        {
            this.Text = _configService.GetMessage("MainMenuFormTitle") ?? "Main Menu";
            btnTambah.Text = _configService.GetMessage("AddButtonText") ?? "Tambah";
            btnSetting.Text = _configService.GetMessage("SettingsButtonText") ?? "Pengaturan";

            // Update DataGridView column headers and button texts
            if (dataGridViewMahasiswa.Columns["EditColumn"] is DataGridViewButtonColumn editCol)
            {
                editCol.HeaderText = _configService.GetMessage("EditColumnHeader") ?? "Edit";
                editCol.Text = _configService.GetMessage("EditButtonText") ?? "Edit";
            }

            if (dataGridViewMahasiswa.Columns["DeleteColumn"] is DataGridViewButtonColumn deleteCol)
            {
                deleteCol.HeaderText = _configService.GetMessage("DeleteColumnHeader") ?? "Delete";
                deleteCol.Text = _configService.GetMessage("DeleteButtonText") ?? "Delete";
            }

            // Example for localizing other data-bound columns if needed:
            // if (dataGridViewMahasiswa.Columns["NIM"] != null) // Assuming "NIM" is the DataPropertyName
            // {
            //     dataGridViewMahasiswa.Columns["NIM"].HeaderText = _configService.GetMessage("NIMColumnHeader") ?? "NIM";
            // }
            // if (dataGridViewMahasiswa.Columns["Nama"] != null) // Assuming "Nama" is the DataPropertyName
            // {
            //      dataGridViewMahasiswa.Columns["Nama"].HeaderText = _configService.GetMessage("NameColumnHeader") ?? "Nama";
            // }
        }
    }
}
