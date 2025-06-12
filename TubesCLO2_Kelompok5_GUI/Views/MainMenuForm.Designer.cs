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
            btnSetting = new Button(); // Changed btnSettings to btnSetting
            ((System.ComponentModel.ISupportInitialize)dataGridViewMahasiswa).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMahasiswa
            // 
            dataGridViewMahasiswa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; // Added Anchor
            dataGridViewMahasiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Added AutoSizeColumnsMode
            dataGridViewMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMahasiswa.Location = new Point(12, 50); // Changed Location
            dataGridViewMahasiswa.Name = "dataGridViewMahasiswa";
            dataGridViewMahasiswa.RowHeadersWidth = 51;
            dataGridViewMahasiswa.Size = new Size(1510, 748); // Changed Size
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
            btnTambah.Click += btnTambah_Click; // Re-enabled this line
            // 
            // btnSetting
            // 
            btnSetting.Location = new Point(112, 12); // Changed Location slightly
            btnSetting.Name = "btnSetting"; // Changed variable name
            btnSetting.Size = new Size(94, 29);
            btnSetting.TabIndex = 2;
            btnSetting.Text = "Pengaturan"; // Changed Text
            btnSetting.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1534, 810);
            Controls.Add(btnSetting); // Changed variable name
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
        private Button btnSetting; // Changed variable name
    }
}