namespace Labo4ka7
{
    partial class Kartochka_Clienta
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MachinesTab = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.RepairsTab = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxPhoneDom = new System.Windows.Forms.TextBox();
            this.EndPhoneStac = new System.Windows.Forms.Label();
            this.EndPhoneSmart = new System.Windows.Forms.Label();
            this.EndCompany = new System.Windows.Forms.Label();
            this.EndFIO = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.LabelDateAdd = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.MachinesTab.SuspendLayout();
            this.RepairsTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MachinesTab);
            this.tabControl1.Controls.Add(this.RepairsTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 203);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 162);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // MachinesTab
            // 
            this.MachinesTab.Controls.Add(this.label9);
            this.MachinesTab.Location = new System.Drawing.Point(4, 25);
            this.MachinesTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MachinesTab.Name = "MachinesTab";
            this.MachinesTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MachinesTab.Size = new System.Drawing.Size(855, 133);
            this.MachinesTab.TabIndex = 0;
            this.MachinesTab.Text = "Станки";
            this.MachinesTab.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(191, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(486, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Нажмите для просмотра станков данного клиента";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // RepairsTab
            // 
            this.RepairsTab.Controls.Add(this.label10);
            this.RepairsTab.Location = new System.Drawing.Point(4, 25);
            this.RepairsTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RepairsTab.Name = "RepairsTab";
            this.RepairsTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RepairsTab.Size = new System.Drawing.Size(855, 133);
            this.RepairsTab.TabIndex = 1;
            this.RepairsTab.Text = "Ремонты";
            this.RepairsTab.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(194, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(501, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Нажмите для просмотра ремонтов данного клиента";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(6, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Дата добавления:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(6, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Телефон Сотовый:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Компания:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО:";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Gold;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSave.Location = new System.Drawing.Point(544, 66);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(246, 67);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "СОХРАНИТЬ";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(458, 188);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Клиент";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.textBoxPhoneDom);
            this.panel1.Controls.Add(this.EndPhoneStac);
            this.panel1.Controls.Add(this.EndPhoneSmart);
            this.panel1.Controls.Add(this.EndCompany);
            this.panel1.Controls.Add(this.EndFIO);
            this.panel1.Controls.Add(this.textBoxPhone);
            this.panel1.Controls.Add(this.textBoxCompany);
            this.panel1.Controls.Add(this.textBoxFIO);
            this.panel1.Controls.Add(this.LabelDateAdd);
            this.panel1.Location = new System.Drawing.Point(161, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 163);
            this.panel1.TabIndex = 1;
            // 
            // textBoxPhoneDom
            // 
            this.textBoxPhoneDom.Location = new System.Drawing.Point(9, 105);
            this.textBoxPhoneDom.Name = "textBoxPhoneDom";
            this.textBoxPhoneDom.Size = new System.Drawing.Size(248, 22);
            this.textBoxPhoneDom.TabIndex = 10;
            // 
            // EndPhoneStac
            // 
            this.EndPhoneStac.AutoSize = true;
            this.EndPhoneStac.Location = new System.Drawing.Point(263, 108);
            this.EndPhoneStac.Name = "EndPhoneStac";
            this.EndPhoneStac.Size = new System.Drawing.Size(17, 17);
            this.EndPhoneStac.TabIndex = 11;
            this.EndPhoneStac.Text = "X";
            this.EndPhoneStac.Click += new System.EventHandler(this.EndPhoneStac_Click);
            // 
            // EndPhoneSmart
            // 
            this.EndPhoneSmart.AutoSize = true;
            this.EndPhoneSmart.Location = new System.Drawing.Point(263, 74);
            this.EndPhoneSmart.Name = "EndPhoneSmart";
            this.EndPhoneSmart.Size = new System.Drawing.Size(17, 17);
            this.EndPhoneSmart.TabIndex = 9;
            this.EndPhoneSmart.Text = "X";
            this.EndPhoneSmart.Click += new System.EventHandler(this.EndPhoneSmart_Click);
            // 
            // EndCompany
            // 
            this.EndCompany.AutoSize = true;
            this.EndCompany.Location = new System.Drawing.Point(263, 43);
            this.EndCompany.Name = "EndCompany";
            this.EndCompany.Size = new System.Drawing.Size(17, 17);
            this.EndCompany.TabIndex = 8;
            this.EndCompany.Text = "X";
            this.EndCompany.Click += new System.EventHandler(this.EndCompany_Click);
            // 
            // EndFIO
            // 
            this.EndFIO.AutoSize = true;
            this.EndFIO.Location = new System.Drawing.Point(263, 9);
            this.EndFIO.Name = "EndFIO";
            this.EndFIO.Size = new System.Drawing.Size(17, 17);
            this.EndFIO.TabIndex = 7;
            this.EndFIO.Text = "X";
            this.EndFIO.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(9, 71);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(248, 22);
            this.textBoxPhone.TabIndex = 6;
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.Location = new System.Drawing.Point(9, 40);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.Size = new System.Drawing.Size(248, 22);
            this.textBoxCompany.TabIndex = 5;
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(9, 7);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(248, 22);
            this.textBoxFIO.TabIndex = 4;
            // 
            // LabelDateAdd
            // 
            this.LabelDateAdd.AutoSize = true;
            this.LabelDateAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelDateAdd.Location = new System.Drawing.Point(6, 139);
            this.LabelDateAdd.Name = "LabelDateAdd";
            this.LabelDateAdd.Size = new System.Drawing.Size(46, 18);
            this.LabelDateAdd.TabIndex = 3;
            this.LabelDateAdd.Text = "label8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(6, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 18);
            this.label8.TabIndex = 5;
            this.label8.Text = "Телефон Домашний:";
            // 
            // Kartochka_Clienta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 376);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Kartochka_Clienta";
            this.Text = "Карточка клиента";
            this.tabControl1.ResumeLayout(false);
            this.MachinesTab.ResumeLayout(false);
            this.MachinesTab.PerformLayout();
            this.RepairsTab.ResumeLayout(false);
            this.RepairsTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MachinesTab;
        private System.Windows.Forms.TabPage RepairsTab;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelDateAdd;
        private System.Windows.Forms.Label EndPhoneSmart;
        private System.Windows.Forms.Label EndCompany;
        private System.Windows.Forms.Label EndFIO;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label EndPhoneStac;
        private System.Windows.Forms.TextBox textBoxPhoneDom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}