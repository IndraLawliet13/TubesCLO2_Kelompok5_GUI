using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TubesCLO2_Kelompok5_GUI.Views
{
    public partial class SettingsForm : Form
    {

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            rbEnglish = new RadioButton();
            rbIndonesia = new RadioButton();
            btnSaveSettings = new Button();
            btnBackSettings = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbEnglish);
            groupBox1.Controls.Add(rbIndonesia);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(130, 108);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pilih Bahasa";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // rbEnglish
            // 
            rbEnglish.AutoSize = true;
            rbEnglish.Location = new Point(8, 56);
            rbEnglish.Name = "rbEnglish";
            rbEnglish.Size = new Size(77, 24);
            rbEnglish.TabIndex = 1;
            rbEnglish.TabStop = true;
            rbEnglish.Text = "English";
            rbEnglish.UseVisualStyleBackColor = true;
            rbEnglish.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // rbIndonesia
            // 
            rbIndonesia.AutoSize = true;
            rbIndonesia.Location = new Point(7, 26);
            rbIndonesia.Name = "rbIndonesia";
            rbIndonesia.Size = new Size(94, 24);
            rbIndonesia.TabIndex = 0;
            rbIndonesia.TabStop = true;
            rbIndonesia.Text = "Indonesia";
            rbIndonesia.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(148, 86);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(94, 29);
            btnSaveSettings.TabIndex = 1;
            btnSaveSettings.Text = "Simpan";
            btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // btnBackSettings
            // 
            btnBackSettings.Location = new Point(248, 86);
            btnBackSettings.Name = "btnBackSettings";
            btnBackSettings.Size = new Size(94, 29);
            btnBackSettings.TabIndex = 2;
            btnBackSettings.Text = "Kembali";
            btnBackSettings.UseVisualStyleBackColor = true;
            btnBackSettings.Click += button2_Click;
            // 
            // SettingsForm
            // 
            ClientSize = new Size(349, 127);
            Controls.Add(btnBackSettings);
            Controls.Add(btnSaveSettings);
            Controls.Add(groupBox1);
            Name = "SettingsForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
