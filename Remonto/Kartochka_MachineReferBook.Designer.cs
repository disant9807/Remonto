namespace Labo4ka7
{
    partial class Kartochka_MachineReferBook
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EndMaster = new System.Windows.Forms.Label();
            this.labelMaster = new System.Windows.Forms.Label();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.EndCountry = new System.Windows.Forms.Label();
            this.EndMark = new System.Windows.Forms.Label();
            this.EndName = new System.Windows.Forms.Label();
            this.textBoxMark = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.MachinesTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MachinesTab);
            this.tabControl1.Location = new System.Drawing.Point(11, 161);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 162);
            this.tabControl1.TabIndex = 7;
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
            this.label9.Size = new System.Drawing.Size(454, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Нажмите для просмотра станков данного типа";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Gold;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSave.Location = new System.Drawing.Point(548, 40);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(246, 67);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "СОХРАНИТЬ";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(458, 156);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Станок";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Мастер:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(6, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Страна:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Марка:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.EndMaster);
            this.panel1.Controls.Add(this.labelMaster);
            this.panel1.Controls.Add(this.comboBoxCountry);
            this.panel1.Controls.Add(this.EndCountry);
            this.panel1.Controls.Add(this.EndMark);
            this.panel1.Controls.Add(this.EndName);
            this.panel1.Controls.Add(this.textBoxMark);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Location = new System.Drawing.Point(161, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 142);
            this.panel1.TabIndex = 1;
            // 
            // EndMaster
            // 
            this.EndMaster.AutoSize = true;
            this.EndMaster.Location = new System.Drawing.Point(263, 105);
            this.EndMaster.Name = "EndMaster";
            this.EndMaster.Size = new System.Drawing.Size(17, 17);
            this.EndMaster.TabIndex = 10;
            this.EndMaster.Text = "X";
            // 
            // labelMaster
            // 
            this.labelMaster.AutoSize = true;
            this.labelMaster.Location = new System.Drawing.Point(6, 105);
            this.labelMaster.Name = "labelMaster";
            this.labelMaster.Size = new System.Drawing.Size(47, 17);
            this.labelMaster.TabIndex = 1;
            this.labelMaster.Text = "Пусто";
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Items.AddRange(new object[] {
            "Абхазия",
            "Австралия",
            "Австрия",
            "Азербайджан",
            "Албания",
            "Алжир",
            "Ангола",
            "Андорра",
            "Антигуа и Барбуда",
            "Аргентина",
            "Армения",
            "Афганистан",
            "Багамские Острова",
            "Бангладеш",
            "Барбадос",
            "Бахрейн",
            "Беларусь",
            "Белиз",
            "Бельгия",
            "Бенин",
            "Болгария",
            "Боливия",
            "Босния и Герцеговина",
            "Ботсвана",
            "Бразилия",
            "Бруней",
            "Буркина Фасо",
            "Бурунди",
            "Бутан",
            "Вануату",
            "Ватикан",
            "Великобритания",
            "Венгрия",
            "Венесуэла",
            "Восточный Тимоp",
            "Вьетнам",
            "Габон",
            "Гаити",
            "Гайана",
            "Гамбия",
            "Гана",
            "Гватемала",
            "Гвинея",
            "Гвинея-Бисау",
            "Германия",
            "Гондурас",
            "Гренада",
            "Греция",
            "Грузия\t",
            "Дания",
            "Демократическая Республика Конго",
            "Джибути",
            "Доминиканская Республика",
            "Доминикана",
            "Египет",
            "Замбия",
            "Зимбабве",
            "Израиль",
            "Индия",
            "Индонезия",
            "Иордания",
            "Ирак",
            "Иран",
            "Ирландия",
            "Исландия",
            "Испания",
            "Италия",
            "Йемен",
            "Кабо-Верде",
            "Казахстан",
            "Камбоджа",
            "Камерун",
            "Канада",
            "Катар",
            "Кения",
            "Кипр",
            "Киргизия",
            "Кирибати",
            "Китай",
            "Колумбия",
            "Коморские острова",
            "КНДР",
            "Коста-Рика",
            "Кот-д’Ивуар",
            "Куба",
            "Кувейт",
            "Лаос",
            "Латвия",
            "Лесото",
            "Либерия",
            "Ливан",
            "Ливия",
            "Литва",
            "Лихтенштейн",
            "Люксембург",
            "Маврикий",
            "Мавритания",
            "Мадагаскар",
            "Македония\t",
            "Малави",
            "Малайзия",
            "Мали",
            "Мальдивы",
            "Мальта",
            "Марокко",
            "Маршалловы Острова",
            "Мексика",
            "Микронезия",
            "Мозамбик",
            "Молдова",
            "Монако",
            "Монголия",
            "Мьянма",
            "Намибия",
            "Науру",
            "Непал",
            "Нигер",
            "Нигерия",
            "Нидерланды",
            "Никарагуа",
            "Новая Зеландия",
            "Норвегия",
            "ОАЭ",
            "Оман",
            "Пакистан",
            "Палау",
            "Панама",
            "Папуа-Новая Гвинея",
            "Парагвай",
            "Перу",
            "Польша",
            "Португалия",
            "Республика Конго",
            "Республика Корея",
            "Россия",
            "Руанда",
            "Румыния",
            "Сальвадор",
            "Самоа",
            "Сан-Марино",
            "Сан-Томе и Принсипи",
            "Саудовская Аравия",
            "Свазиленд",
            "Северные Марианские острова",
            "Сейшелы",
            "Сенегал",
            "Сент-Винсент и Гренадины",
            "Сент-Китс и Невис\t",
            "Сент-Люсия",
            "Сербия",
            "Сингапур",
            "Сирия",
            "Словакия",
            "Словения",
            "Соединённые Штаты Америки",
            "Соломоновы Острова",
            "Сомали",
            "Судан",
            "Сьерра-Леоне",
            "Таджикистан",
            "Таиланд",
            "Танзания",
            "Того",
            "Тонга",
            "Тринидад и Тобаго",
            "Тувалу",
            "Тунис",
            "Туркмения",
            "Турция",
            "Уганда",
            "Узбекистан",
            "Украина",
            "Уругвай",
            "Фиджи",
            "Филиппины",
            "Финляндия",
            "Франция",
            "Хорватия",
            "Центральноафриканская Республика",
            "Чад",
            "Черногория",
            "Чехия",
            "Чили",
            "Швейцария",
            "Швеция",
            "Шри-Ланка",
            "Эквадор",
            "Экваториальная Гвинея",
            "Эритрея",
            "Эстония",
            "Эфиопия",
            "Южно-Африканская Республика",
            "Южный Судан",
            "Ямайка",
            "Япония"});
            this.comboBoxCountry.Location = new System.Drawing.Point(9, 68);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(248, 24);
            this.comboBoxCountry.TabIndex = 1;
            // 
            // EndCountry
            // 
            this.EndCountry.AutoSize = true;
            this.EndCountry.Location = new System.Drawing.Point(263, 71);
            this.EndCountry.Name = "EndCountry";
            this.EndCountry.Size = new System.Drawing.Size(17, 17);
            this.EndCountry.TabIndex = 9;
            this.EndCountry.Text = "X";
            this.EndCountry.Click += new System.EventHandler(this.EndCountry_Click);
            // 
            // EndMark
            // 
            this.EndMark.AutoSize = true;
            this.EndMark.Location = new System.Drawing.Point(263, 39);
            this.EndMark.Name = "EndMark";
            this.EndMark.Size = new System.Drawing.Size(17, 17);
            this.EndMark.TabIndex = 8;
            this.EndMark.Text = "X";
            this.EndMark.Click += new System.EventHandler(this.EndMark_Click);
            // 
            // EndName
            // 
            this.EndName.AutoSize = true;
            this.EndName.Location = new System.Drawing.Point(263, 9);
            this.EndName.Name = "EndName";
            this.EndName.Size = new System.Drawing.Size(17, 17);
            this.EndName.TabIndex = 7;
            this.EndName.Text = "X";
            this.EndName.Click += new System.EventHandler(this.EndName_Click);
            // 
            // textBoxMark
            // 
            this.textBoxMark.Location = new System.Drawing.Point(9, 36);
            this.textBoxMark.Name = "textBoxMark";
            this.textBoxMark.Size = new System.Drawing.Size(248, 22);
            this.textBoxMark.TabIndex = 5;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(9, 7);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(248, 22);
            this.textBoxName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            // 
            // Kartochka_MachineReferBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 322);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Kartochka_MachineReferBook";
            this.Text = "Карточка справочника станков";
            this.tabControl1.ResumeLayout(false);
            this.MachinesTab.ResumeLayout(false);
            this.MachinesTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MachinesTab;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label EndCountry;
        private System.Windows.Forms.Label EndMark;
        private System.Windows.Forms.Label EndName;
        private System.Windows.Forms.TextBox textBoxMark;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label EndMaster;
        private System.Windows.Forms.Label labelMaster;
    }
}