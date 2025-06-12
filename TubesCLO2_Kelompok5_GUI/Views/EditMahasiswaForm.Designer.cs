// Placeholder for EditMahasiswaForm.Designer.cs
// Will be populated with UI elements.
namespace TubesCLO2_Kelompok5_GUI.Views
{
    partial class EditMahasiswaForm
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
            lblNIM = new Label();
            txtNIM = new TextBox();
            lblNama = new Label();
            txtNama = new TextBox();
            lblJurusan = new Label();
            txtJurusan = new TextBox();
            lblIPK = new Label();
            txtIPK = new TextBox();
            btnSimpan = new Button();
            btnKembali = new Button();
            SuspendLayout();
            // 
            // lblNIM
            // 
            lblNIM.AutoSize = true;
            lblNIM.Location = new Point(16, 23);
            lblNIM.Margin = new Padding(4, 0, 4, 0);
            lblNIM.Name = "lblNIM";
            lblNIM.Size = new Size(40, 20);
            lblNIM.TabIndex = 0;
            lblNIM.Text = "NIM:";
            // 
            // txtNIM
            // 
            txtNIM.Location = new Point(133, 18);
            txtNIM.Margin = new Padding(4, 5, 4, 5);
            txtNIM.Name = "txtNIM";
            txtNIM.ReadOnly = true;
            txtNIM.Size = new Size(265, 27);
            txtNIM.TabIndex = 1;
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Location = new Point(16, 69);
            lblNama.Margin = new Padding(4, 0, 4, 0);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(52, 20);
            lblNama.TabIndex = 2;
            lblNama.Text = "Nama:";
            // 
            // txtNama
            // 
            txtNama.Location = new Point(133, 65);
            txtNama.Margin = new Padding(4, 5, 4, 5);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(265, 27);
            txtNama.TabIndex = 3;
            // 
            // lblJurusan
            // 
            lblJurusan.AutoSize = true;
            lblJurusan.Location = new Point(16, 115);
            lblJurusan.Margin = new Padding(4, 0, 4, 0);
            lblJurusan.Name = "lblJurusan";
            lblJurusan.Size = new Size(60, 20);
            lblJurusan.TabIndex = 4;
            lblJurusan.Text = "Jurusan:";
            // 
            // txtJurusan
            // 
            txtJurusan.Location = new Point(133, 111);
            txtJurusan.Margin = new Padding(4, 5, 4, 5);
            txtJurusan.Name = "txtJurusan";
            txtJurusan.Size = new Size(265, 27);
            txtJurusan.TabIndex = 5;
            // 
            // lblIPK
            // 
            lblIPK.AutoSize = true;
            lblIPK.Location = new Point(16, 162);
            lblIPK.Margin = new Padding(4, 0, 4, 0);
            lblIPK.Name = "lblIPK";
            lblIPK.Size = new Size(33, 20);
            lblIPK.TabIndex = 6;
            lblIPK.Text = "IPK:";
            // 
            // txtIPK
            // 
            txtIPK.Location = new Point(133, 157);
            txtIPK.Margin = new Padding(4, 5, 4, 5);
            txtIPK.Name = "txtIPK";
            txtIPK.Size = new Size(265, 27);
            txtIPK.TabIndex = 7;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(133, 215);
            btnSimpan.Margin = new Padding(4, 5, 4, 5);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(100, 35);
            btnSimpan.TabIndex = 8;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(241, 215);
            btnKembali.Margin = new Padding(4, 5, 4, 5);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(100, 35);
            btnKembali.TabIndex = 9;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            // 
            // EditMahasiswaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1806, 880);
            Controls.Add(btnKembali);
            Controls.Add(btnSimpan);
            Controls.Add(txtIPK);
            Controls.Add(lblIPK);
            Controls.Add(txtJurusan);
            Controls.Add(lblJurusan);
            Controls.Add(txtNama);
            Controls.Add(lblNama);
            Controls.Add(txtNIM);
            Controls.Add(lblNIM);
            Margin = new Padding(4, 5, 4, 5);
            Name = "EditMahasiswaForm";
            Text = "Edit Mahasiswa";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNIM;
        private System.Windows.Forms.TextBox txtNIM;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label lblJurusan;
        private System.Windows.Forms.TextBox txtJurusan;
        private System.Windows.Forms.Label lblIPK;
        private System.Windows.Forms.TextBox txtIPK;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnKembali;
    }
}
