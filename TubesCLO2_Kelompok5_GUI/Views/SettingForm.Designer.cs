namespace TubesCLO2_Kelompok5_GUI.Views
{
    partial class SettingForm
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
            lblPilihBahasa = new Label();
            rbIndonesia = new RadioButton();
            rbEnglish = new RadioButton();
            btnSimpan = new Button();
            btnKembali = new Button();
            SuspendLayout();
            // 
            // lblPilihBahasa
            // 
            lblPilihBahasa.AutoSize = true;
            lblPilihBahasa.Location = new Point(16, 31);
            lblPilihBahasa.Margin = new Padding(4, 0, 4, 0);
            lblPilihBahasa.Name = "lblPilihBahasa";
            lblPilihBahasa.Size = new Size(91, 20);
            lblPilihBahasa.TabIndex = 0;
            lblPilihBahasa.Text = "Pilih Bahasa:";
            // 
            // rbIndonesia
            // 
            rbIndonesia.AutoSize = true;
            rbIndonesia.Location = new Point(20, 69);
            rbIndonesia.Margin = new Padding(4, 5, 4, 5);
            rbIndonesia.Name = "rbIndonesia";
            rbIndonesia.Size = new Size(94, 24);
            rbIndonesia.TabIndex = 1;
            rbIndonesia.TabStop = true;
            rbIndonesia.Text = "Indonesia";
            rbIndonesia.UseVisualStyleBackColor = true;
            // 
            // rbEnglish
            // 
            rbEnglish.AutoSize = true;
            rbEnglish.Location = new Point(20, 108);
            rbEnglish.Margin = new Padding(4, 5, 4, 5);
            rbEnglish.Name = "rbEnglish";
            rbEnglish.Size = new Size(77, 24);
            rbEnglish.TabIndex = 2;
            rbEnglish.TabStop = true;
            rbEnglish.Text = "English";
            rbEnglish.UseVisualStyleBackColor = true;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(20, 169);
            btnSimpan.Margin = new Padding(4, 5, 4, 5);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(100, 35);
            btnSimpan.TabIndex = 3;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(133, 169);
            btnKembali.Margin = new Padding(4, 5, 4, 5);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(100, 35);
            btnKembali.TabIndex = 4;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1808, 878);
            Controls.Add(btnKembali);
            Controls.Add(btnSimpan);
            Controls.Add(rbEnglish);
            Controls.Add(rbIndonesia);
            Controls.Add(lblPilihBahasa);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pengaturan";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPilihBahasa;
        private System.Windows.Forms.RadioButton rbIndonesia;
        private System.Windows.Forms.RadioButton rbEnglish;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnKembali;
    }
}
