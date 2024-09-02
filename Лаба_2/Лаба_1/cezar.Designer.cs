using System.Windows.Forms;

namespace Лаба_1
{
    partial class cezar
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.shifr = new System.Windows.Forms.Button();
            this.deshifr = new System.Windows.Forms.Button();
            this.rus = new System.Windows.Forms.CheckBox();
            this.eng = new System.Windows.Forms.CheckBox();
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.itog = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.perebor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.loadtext = new System.Windows.Forms.Button();
            this.deshifr2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.chast_analiz = new System.Windows.Forms.Label();
            this.key_label = new System.Windows.Forms.Label();
            this.sbros_key = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.ForeColor = System.Drawing.Color.Lime;
            this.textBox3.Location = new System.Drawing.Point(15, 285);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(1355, 22);
            this.textBox3.TabIndex = 2;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // shifr
            // 
            this.shifr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shifr.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shifr.ForeColor = System.Drawing.Color.Lime;
            this.shifr.Location = new System.Drawing.Point(15, 330);
            this.shifr.Name = "shifr";
            this.shifr.Size = new System.Drawing.Size(145, 39);
            this.shifr.TabIndex = 3;
            this.shifr.Text = "Зашифровать";
            this.shifr.UseVisualStyleBackColor = true;
            this.shifr.Click += new System.EventHandler(this.shifr_Click);
            // 
            // deshifr
            // 
            this.deshifr.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.deshifr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deshifr.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deshifr.ForeColor = System.Drawing.Color.Lime;
            this.deshifr.Location = new System.Drawing.Point(15, 507);
            this.deshifr.Name = "deshifr";
            this.deshifr.Size = new System.Drawing.Size(311, 39);
            this.deshifr.TabIndex = 4;
            this.deshifr.Text = "Расшифровать перебором ключа";
            this.deshifr.UseVisualStyleBackColor = false;
            this.deshifr.Click += new System.EventHandler(this.deshifr_Click);
            // 
            // rus
            // 
            this.rus.AutoSize = true;
            this.rus.Checked = true;
            this.rus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rus.ForeColor = System.Drawing.Color.Lime;
            this.rus.Location = new System.Drawing.Point(15, 76);
            this.rus.Name = "rus";
            this.rus.Size = new System.Drawing.Size(93, 21);
            this.rus.TabIndex = 5;
            this.rus.Text = "русский";
            this.rus.UseVisualStyleBackColor = true;
            this.rus.CheckedChanged += new System.EventHandler(this.rus_CheckedChanged);
            // 
            // eng
            // 
            this.eng.AutoSize = true;
            this.eng.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eng.ForeColor = System.Drawing.Color.Lime;
            this.eng.Location = new System.Drawing.Point(114, 76);
            this.eng.Name = "eng";
            this.eng.Size = new System.Drawing.Size(120, 21);
            this.eng.TabIndex = 6;
            this.eng.Text = "английский";
            this.eng.UseVisualStyleBackColor = true;
            this.eng.CheckedChanged += new System.EventHandler(this.eng_CheckedChanged);
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.title.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.ForeColor = System.Drawing.Color.Lime;
            this.title.Location = new System.Drawing.Point(12, 21);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(1265, 26);
            this.title.TabIndex = 7;
            this.title.Text = "Приветствуем! Программа посвящена шифру Цезаря. Выберите язык, введите текст, цел" +
    "очисленный ключ и выберите нужную опцию.\r\n";
            this.title.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(12, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ключ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Только целое число!";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(314, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Вводите только на выбранном языке!";
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // itog
            // 
            this.itog.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itog.ForeColor = System.Drawing.Color.Lime;
            this.itog.Location = new System.Drawing.Point(15, 372);
            this.itog.Name = "itog";
            this.itog.Size = new System.Drawing.Size(1355, 109);
            this.itog.TabIndex = 12;
            this.itog.Click += new System.EventHandler(this.itog_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Введите ваш текст:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(166, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Не введен текст или ключ!";
            this.label5.Visible = false;
            // 
            // perebor
            // 
            this.perebor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.perebor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.perebor.ForeColor = System.Drawing.Color.Lime;
            this.perebor.Location = new System.Drawing.Point(15, 549);
            this.perebor.Name = "perebor";
            this.perebor.Size = new System.Drawing.Size(1355, 109);
            this.perebor.TabIndex = 15;
            this.perebor.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(332, 529);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(233, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Нет зашифрованного текста";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(12, 487);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Взлом:";
            // 
            // loadtext
            // 
            this.loadtext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadtext.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadtext.ForeColor = System.Drawing.Color.Lime;
            this.loadtext.Location = new System.Drawing.Point(1202, 76);
            this.loadtext.Name = "loadtext";
            this.loadtext.Size = new System.Drawing.Size(168, 39);
            this.loadtext.TabIndex = 18;
            this.loadtext.Text = "Загрузить текст";
            this.loadtext.UseVisualStyleBackColor = true;
            this.loadtext.Click += new System.EventHandler(this.loadtext_Click);
            // 
            // deshifr2
            // 
            this.deshifr2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.deshifr2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deshifr2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deshifr2.ForeColor = System.Drawing.Color.Lime;
            this.deshifr2.Location = new System.Drawing.Point(15, 661);
            this.deshifr2.Name = "deshifr2";
            this.deshifr2.Size = new System.Drawing.Size(317, 39);
            this.deshifr2.TabIndex = 19;
            this.deshifr2.Text = "Расшифровать частотным анализом";
            this.deshifr2.UseVisualStyleBackColor = false;
            this.deshifr2.Click += new System.EventHandler(this.deshifr2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(338, 683);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(233, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Нет зашифрованного текста";
            this.label9.Visible = false;
            // 
            // chast_analiz
            // 
            this.chast_analiz.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chast_analiz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chast_analiz.ForeColor = System.Drawing.Color.Lime;
            this.chast_analiz.Location = new System.Drawing.Point(15, 703);
            this.chast_analiz.Name = "chast_analiz";
            this.chast_analiz.Size = new System.Drawing.Size(1355, 109);
            this.chast_analiz.TabIndex = 21;
            // 
            // key_label
            // 
            this.key_label.AutoSize = true;
            this.key_label.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.key_label.ForeColor = System.Drawing.Color.Lime;
            this.key_label.Location = new System.Drawing.Point(568, 507);
            this.key_label.Name = "key_label";
            this.key_label.Size = new System.Drawing.Size(179, 17);
            this.key_label.TabIndex = 22;
            this.key_label.Text = "Подобранный ключ: 0";
            // 
            // sbros_key
            // 
            this.sbros_key.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sbros_key.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sbros_key.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sbros_key.ForeColor = System.Drawing.Color.Lime;
            this.sbros_key.Location = new System.Drawing.Point(1218, 496);
            this.sbros_key.Name = "sbros_key";
            this.sbros_key.Size = new System.Drawing.Size(152, 39);
            this.sbros_key.TabIndex = 23;
            this.sbros_key.Text = "Сбросить ключ";
            this.sbros_key.UseVisualStyleBackColor = false;
            this.sbros_key.Click += new System.EventHandler(this.sbros_key_Click);
            // 
            // load
            // 
            this.load.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.load.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.load.ForeColor = System.Drawing.Color.Lime;
            this.load.Location = new System.Drawing.Point(15, 127);
            this.load.Name = "load";
            this.load.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.load.Size = new System.Drawing.Size(1355, 118);
            this.load.TabIndex = 24;
            this.load.Text = "";
            this.load.TextChanged += new System.EventHandler(this.load_TextChanged);
            // 
            // cezar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1384, 832);
            this.Controls.Add(this.load);
            this.Controls.Add(this.sbros_key);
            this.Controls.Add(this.key_label);
            this.Controls.Add(this.chast_analiz);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.deshifr2);
            this.Controls.Add(this.loadtext);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.perebor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.itog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.eng);
            this.Controls.Add(this.rus);
            this.Controls.Add(this.deshifr);
            this.Controls.Add(this.shifr);
            this.Controls.Add(this.textBox3);
            this.Name = "cezar";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button shifr;
        private System.Windows.Forms.Button deshifr;
        private System.Windows.Forms.CheckBox rus;
        private System.Windows.Forms.CheckBox eng;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label itog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Label perebor;
        private Label label7;
        private Label label8;
        private Button loadtext;
        private Button deshifr2;
        private Label label9;
        private Label chast_analiz;
        private Label key_label;
        private Button sbros_key;
        private RichTextBox load;
    }
}

