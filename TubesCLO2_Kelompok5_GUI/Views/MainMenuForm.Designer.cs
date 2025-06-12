namespace TubesCLO2_Kelompok5_GUI.Views
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewMahasiswa = new DataGridView();
            btnTambah = new Button();
            btnSettings = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMahasiswa).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMahasiswa
            // 
            dataGridViewMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMahasiswa.Dock = DockStyle.Fill;
            dataGridViewMahasiswa.Location = new Point(0, 0);
            dataGridViewMahasiswa.Name = "dataGridViewMahasiswa";
            dataGridViewMahasiswa.RowHeadersWidth = 51;
            dataGridViewMahasiswa.Size = new Size(1534, 810);
            dataGridViewMahasiswa.TabIndex = 0;
            // 
            // btnTambah
            // 
            btnTambah.Location = new Point(12, 12);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(94, 29);
            btnTambah.TabIndex = 1;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = true;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(121, 12);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(94, 29);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "Setting";
            btnSettings.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1534, 810);
            Controls.Add(btnSettings);
            Controls.Add(btnTambah);
            Controls.Add(dataGridViewMahasiswa);
            Name = "MainMenuForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewMahasiswa).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewMahasiswa;
        private Button btnTambah;
        private Button btnSettings;
    }
}