using System;
using System.Collections.Generic; //dictionary в частотном анализе
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Numerics; //BigInteger
using System.Runtime.CompilerServices;
using System.IO;
using System.Threading; //в загрузке текста



namespace Лаба_1
{
    public partial class cezar : Form
    {
        
        string eng_string1 = "abcdefghijklmnopqrstuvwxyz";
        string eng_string2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string rus_string1 = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string rus_string2 = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        //специальные строки для проверки вводимого текста
        string eng_string = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\n\r ";
        string rus_string = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ\n\r ";
        
        //интегрируем большое число для ключа
        BigInteger key;
        //используем общую для
        string Itog = "";
        int key_perebor = 0;
        public cezar()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "CezarProgram";
            
        }
        //
        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        //
        private void rus_CheckedChanged(object sender, EventArgs e)
        {
            if (rus.Checked == true) //проверка свойства (выбрана или нет)
            {
                eng.Checked = false; //меняем свойство другой кнопки 
                label3.Visible = false; //прячем текст об ошибке
                load.Text = ""; //очистка поля
            }
            else
            {
                eng.Checked = true;
            }
        }

        private void eng_CheckedChanged(object sender, EventArgs e)
        {
            if (eng.Checked == true)
            {
                rus.Checked = false; //меняем свойство другой кнопки 
                label3.Visible = false; //прячем текст об ошибке
                load.Text = ""; //очистка поля
            }
            else
            {
                rus.Checked = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string text = textBox3.Text; //извлекаем текст в поле ключа
            string numbers = "1234567890-"; //контрольная строка 
            for(int i = 0; i < textBox3.Text.Length; i++)
            {
                if (!numbers.Contains(text[i])) //проверка на вхождение в контрольную строку
                { 
                    label2.Visible = true;
                    textBox3.Text = text.Remove(text.IndexOf(text[i]));
                }
            }
            for (int i = 1; i < textBox3.Text.Length; i++) 
            {
                if (text[i] == '-') //нельзя ввести минус не в начало -> нельзя ввести больше одного раза
                {
                    textBox3.Text = text.Remove(i);
                }
            }
            if (text.Length > 1 && text[0] == '0' && numbers.Contains(text[1]))
            {
                textBox3.Text = text.Remove(1); //нельзя вписать число с нуля (т.е. 0 только один, и после него не может быть знаков)
            }
            if (text.Length > 1 && text[0] == '-'  && text[1] == '0') // нельзя вписать число -0
            {
                textBox3.Text = text.Remove(1);
            }
            //если совершены ошибки возвращаем каретку в конец строки
            textBox3.SelectionStart = textBox3.Text.Length;
            //присваиваем введеное число в ключ?
            if(textBox3.Text != "" && textBox3.Text != "-")
            {
                string key_string = textBox3.Text;
                key = BigInteger.Parse(key_string);
            }
           
        }


        private void shifr_Click(object sender, EventArgs e)
        {
            string text = load.Text; //извлекаем текст
            if (eng.Checked == true && BigInteger.Abs(key) > 26) //если ключ больше алфавита, извлекаем ту часть, на какую нужно сместиться
            {
                key = key % 26;
            }
            if (rus.Checked == true && BigInteger.Abs(key) > 33)
            {
                key = key % 33;
            }
            if (textBox3.Text != "" && load.Text != "") //если поля не пустые можно делать шифровку
            {
                for (int i = 0; i < text.Length; i++) //идем по тексту load
                {
                    if (rus.Checked == true)
                    { //сдвиг соответствующих русских букв
                        if (rus_string1.Contains(text[i]) == true) //проверка на русс буквы
                        {
                            if (key.Sign > 0)
                            { //проверка знака ключа
                                if (rus_string1.IndexOf(text[i]) + (int)key < rus_string1.Length) //проверка на выход из массива
                                {
                                    Itog += rus_string1[rus_string1.IndexOf(text[i]) + (int)key];
                                }
                                else
                                {//если ключ сдвигает букву на область вне массива алфавита, то вычитаем длину и идем с начала
                                    Itog += rus_string1[rus_string1.IndexOf(text[i]) + (int)key - 33];
                                }
                            }
                            else
                            {
                                if (rus_string1.IndexOf(text[i]) + (int)key >= 0) //проверка на выход из массива
                                {
                                    Itog += rus_string1[rus_string1.IndexOf(text[i]) + (int)key];
                                }
                                else
                                {
                                    Itog += rus_string1[rus_string1.IndexOf(text[i]) + (int)key + 33];
                                }
                            }

                        }
                        else if (rus_string2.Contains(text[i]) == true) //проверка на русс буквы
                        {
                            if (key.Sign > 0)
                            { //проверка знака ключа
                                if (rus_string2.IndexOf(text[i]) + (int)key < rus_string2.Length) //проверка на выход из массива
                                {
                                    Itog += rus_string2[rus_string2.IndexOf(text[i]) + (int)key];
                                }
                                else
                                {//если ключ сдвигает букву на область вне массива алфавита, то вычитаем длину и идем с начала
                                    Itog += rus_string2[rus_string2.IndexOf(text[i]) + (int)key - 33];
                                }
                            }
                            else
                            {
                                if (rus_string2.IndexOf(text[i]) + (int)key >= 0) //проверка на выход из массива
                                {
                                    Itog += rus_string2[rus_string2.IndexOf(text[i]) + (int)key];
                                }
                                else
                                {
                                    Itog += rus_string2[rus_string2.IndexOf(text[i]) + (int)key + 33];
                                }
                            }
                        }
                        else
                        {
                            Itog += " ";
                        }
                    }
                    else //шифровка английского текста
                    {
                        if (eng_string1.Contains(text[i]) == true) //проверка на eng буквы
                        {
                            if (key.Sign > 0)
                            { //проверка знака ключа
                                if (eng_string1.IndexOf(text[i]) + (int)key < eng_string1.Length) //проверка на выход из массива
                                {
                                    Itog += eng_string1[eng_string1.IndexOf(text[i]) + (int)key];
                                }
                                else
                                {//если ключ сдвигает букву на область вне массива алфавита, то вычитаем длину и идем с начала
                                    Itog += eng_string1[eng_string1.IndexOf(text[i]) + (int)key - 26];
                                }
                            }
                            else
                            {
                                if (eng_string1.IndexOf(text[i]) + (int)key >= 0) //проверка на выход из массива
                                {
                                    Itog += eng_string1[eng_string1.IndexOf(text[i]) + (int)key];
                                }
                                else
                                {
                                    Itog += eng_string1[eng_string1.IndexOf(text[i]) + (int)key + 26];
                                }
                            }

                        }
                        else if (eng_string2.Contains(text[i]) == true) //проверка на eng буквы
                        {
                            if (key.Sign > 0)
                            { //проверка знака ключа
                                if (eng_string2.IndexOf(text[i]) + (int)key < eng_string2.Length) //проверка на выход из массива
                                {
                                    Itog += eng_string2[eng_string2.IndexOf(text[i]) + (int)key];
                                }
                                else
                                {//если ключ сдвигает букву на область вне массива алфавита, то вычитаем длину и идем с начала
                                    Itog += eng_string2[eng_string2.IndexOf(text[i]) + (int)key - 26];
                                }
                            }
                            else
                            {
                                if (eng_string2.IndexOf(text[i]) + (int)key >= 0) //проверка на выход из массива
                                {
                                    Itog += eng_string2[eng_string2.IndexOf(text[i]) + (int)key];
                                }
                                else
                                {
                                    Itog += eng_string2[eng_string2.IndexOf(text[i]) + (int)key + 26];
                                }
                            }
                        }
                        else
                        {
                            Itog += " ";
                        }
                    }
                }

            }
            else //если поля пустые выводим ошибку
            {
                label5.Visible = true;
            }
            itog.Text = Itog; //помещаем зашифрованный текст в элемент itog (label)
            Itog = ""; //очищаем переменную для дальнейших операций
        }

        private void deshifr_Click(object sender, EventArgs e) //перебор ключа
        {
            string text = itog.Text; //извлекаем текст
            key_perebor++;
            if (eng.Checked == true && BigInteger.Abs(key_perebor) > 26) //если ключ больше алфавита, извлекаем ту часть, на какую нужно сместиться
            {
                key_perebor = key_perebor % 26;
            }
            if (rus.Checked == true && BigInteger.Abs(key_perebor) > 33)
            {
                key_perebor = key_perebor % 33;
            }
            key_label.Text = "Подобранный ключ: " + Convert.ToString(key_perebor);
            if (itog.Text != "") //если поля не пустые можно 
            {

                for (int i = 0; i < text.Length; i++) //идем по тексту load
                {
                    if (rus.Checked == true)
                    { //сдвиг соответствующих русских букв
                        if (rus_string1.Contains(text[i]) == true)
                        {
                            if (rus_string1.IndexOf(text[i]) - (int)key_perebor >= 0) //проверка на выход из массива
                            {
                                Itog += rus_string1[rus_string1.IndexOf(text[i]) - (int)key_perebor];
                            }
                            else
                            {
                                Itog += rus_string1[rus_string1.IndexOf(text[i]) - (int)key_perebor + 33];
                            }

                        }
                        else if (rus_string2.Contains(text[i]) == true) //проверка на русс буквы
                        {
                            if (rus_string2.IndexOf(text[i]) - (int)key_perebor >= 0) //проверка на выход из массива
                            {
                                Itog += rus_string2[rus_string2.IndexOf(text[i]) - (int)key_perebor];
                            }
                            else
                            {
                                Itog += rus_string2[rus_string2.IndexOf(text[i]) - (int)key_perebor + 33];
                            }
                        }
                        else
                        {
                            Itog += " ";
                        }


                    }

                    else //шифровка английского текста
                    {
                        if (eng_string1.Contains(text[i]) == true) //проверка на eng буквы
                        {


                            if (eng_string1.IndexOf(text[i]) - (int)key_perebor >= 0) //проверка на выход из массива
                            {
                                Itog += eng_string1[eng_string1.IndexOf(text[i]) - (int)key_perebor];
                            }
                            else
                            {
                                Itog += eng_string1[eng_string1.IndexOf(text[i]) - (int)key_perebor + 26];
                            }


                        }
                        else if (eng_string2.Contains(text[i]) == true) //проверка на eng буквы
                        {


                            if (eng_string2.IndexOf(text[i]) - (int)key_perebor >= 0) //проверка на выход из массива
                            {
                                Itog += eng_string2[eng_string2.IndexOf(text[i]) - (int)key_perebor];
                            }
                            else
                            {
                                Itog += eng_string2[eng_string2.IndexOf(text[i]) - (int)key_perebor + 26];
                            }


                        }
                        else
                        {
                            Itog += " ";
                        }
                    }
                }
            }
            else //если поля пустые выводим ошибку
            {
                label7.Visible = true;
            }
            perebor.Text = Itog; //помещаем зашифрованный текст в элемент label (окно внизу)
            Itog = ""; //очищаем переменную с текстом
        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
        private void itog_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
       
        private void deshifr2_Click(object sender, EventArgs e) //частотный анализ
        {
            
            string text = itog.Text; //извлекаем текст
            Dictionary<string, double> rus_dict = new Dictionary<string, double>()
            {
                { "Оо", 9.28 },
                { "Аа", 8.66 },
                { "Ее", 8.10 },
                { "Ёё", 0.04 },
                { "Ии", 7.45 },
                { "Нн", 6.35 },
                { "Тт", 6.30 },
                { "Рр", 5.53 },
                { "Сс", 5.45 },
                { "Лл", 4.32 },
                { "Вв", 4.19 },
                { "Кк", 3.47 },
                { "Пп",  3.35},
                { "Мм",  3.29},
                { "Уу",  2.90},
                { "Дд",  2.56},
                { "Яя",  2.22},
                { "Ыы",  2.11},
                { "Ьь",  1.90},
                { "Зз",  1.81},
                { "Бб",  1.51},
                { "Гг",  1.41},
                { "Йй",  1.31},
                { "Чч",  1.27},
                { "Юю",  1.03},
                { "Хх",  0.92},
                { "Жж",  0.78},
                { "Шш",  0.77},
                { "Цц",  0.52},
                { "Щщ",  0.49},
                { "Фф",  0.40},
                { "Ээ",  0.17},
                { "Ъъ",  0.04}
            };
            Dictionary<string, double> eng_dict = new Dictionary<string, double>()
            {
                { "Aa",  8.17 },
                { "Bb",  1.49 },
                { "Cc",  2.78 },
                { "Dd",  4.25 },
                { "Ee",  12.70 },
                { "Ff",  2.23 },
                { "Gg",  2.02 },
                { "Hh",  6.09 },
                { "Ii",  6.97 },
                { "Jj",  0.15 },
                { "Kk",  0.77 },
                { "Ll",  4.03 },
                { "Mm",  2.41 },
                { "Nn",  6.75 },
                { "Oo",  7.51 },
                { "Pp",  1.93 },
                { "Qq",  0.10 },
                { "Rr",  5.99 },
                { "Ss",  6.33 },
                { "Tt",  9.06 },
                { "Uu",  2.76 },
                { "Vv",  0.98 },
                { "Ww",  2.36 },
                { "Xx",  0.15 },
                { "Yy",  1.97 },
                { "Zz",  0.07 },
            };
            Dictionary<string, double> rus2_dict = new Dictionary<string, double>() { };
            Dictionary<string, double> eng2_dict = new Dictionary<string, double>() { };
            double count_letter = 0;
            string deshifr_text = "";
            for (int i = 0; i < text.Length; i++)
            {
                deshifr_text += " ";
            }
            if (text != "") //если поля не пустые можно 
            {
                if (rus.Checked == true)
                {
                    foreach (var item in rus_dict)
                    {
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (item.Key.Contains(text[i]))
                            {
                                count_letter++;
                            }
                        }
                        rus2_dict.Add(item.Key, Math.Round((count_letter / text.Length) * 100, 12));
                        count_letter = 0;
                    }
                    foreach (var item in rus2_dict) //проход по буквам словаря
                    {
                        if (item.Value > 0)
                        {
                            double min = 10000;
                            string keys = "";
                            for (int i = 0; i < text.Length; i++)
                            {
                                foreach (var item2 in rus_dict) //сравнение частот
                                {
                                    if (min > Math.Abs(item2.Value - item.Value))
                                    {
                                        min = Math.Abs(item2.Value - item.Value);
                                        keys = item2.Key;
                                    }
                                }

                                if (item.Key.Contains(text[i]))
                                {
                                    if (Convert.ToInt16(text[i]) > 1071)
                                    {

                                        deshifr_text = deshifr_text.Insert(i, Convert.ToString(keys[1]));
                                        deshifr_text = deshifr_text.Remove(i + 1, 1);
                                    }
                                    else
                                    {
                                        deshifr_text = deshifr_text.Insert(i, Convert.ToString(keys[0]));
                                        deshifr_text = deshifr_text.Remove(i + 1, 1);
                                    }
                                }
                            }

                            
}

                    }
                }
                else
                {
                    foreach (var item in eng_dict)
                    {
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (item.Key.Contains(text[i]))
                            {
                                count_letter++;
                            }
                        }
                        eng2_dict.Add(item.Key, Math.Round((count_letter / text.Length) * 100, 12));
                        count_letter = 0;
                    }
                    for (int i = 0; i < text.Length; i++)
                    {
                        foreach (var item in eng2_dict) //проход по буквам вводного текста
                        {
                            double min = 10000;
                            string keys = "";
                            if (item.Value > 0)
                            {
                                foreach (var item2 in eng_dict) //сравнение частот
                                {

                                    if (min > Math.Abs(item2.Value - item.Value))
                                    {
                                        min = Math.Abs(item2.Value - item.Value);
                                        keys = item2.Key;
                                    }

                                }

                                if (item.Key.Contains(text[i]))
                                {
                                    if (Convert.ToInt16(text[i]) > 96)
                                    {

                                        deshifr_text = deshifr_text.Insert(i, Convert.ToString(keys[1]));
                                        deshifr_text = deshifr_text.Remove(i + 1, 1);
                                    }
                                    else
                                    {
                                        deshifr_text = deshifr_text.Insert(i, Convert.ToString(keys[0]));
                                        deshifr_text = deshifr_text.Remove(i + 1, 1);
                                    }
                                }

                            }
                        }
                    }
                }
            }
            else //если поля пустые выводим ошибку
            {
                label9.Visible = true;
            }
            /*foreach(var item in )
            {
                chast_analiz.Text += item.Key + " " + item.Value;
            }*/
            chast_analiz.Text = deshifr_text; //помещаем зашифрованный текст в элемент label (окно внизу)
            deshifr_text = ""; //очищаем переменную с текстом
        }
        
        private void sbros_key_Click(object sender, EventArgs e)
        {
            key_perebor = 0;
            key_label.Text = "Подобранный ключ: " + key_perebor;
            
        }

        private void loadtext_Click(object sender, EventArgs e)
        {
            //загрузка текста через кнопку

            OpenFileDialog openFile1 = new OpenFileDialog();
            //формат файла:
            openFile1.DefaultExt = "*.txt";
            openFile1.Filter = "Text File(*.txt)|*.txt";
            //открытие проводника, выбор файла и считывание с него текста
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                //фильтр по выбранному языку
                string filetext = File.ReadAllText(openFile1.FileName);
                if(rus.Checked == true)
                {
                    for(int i = 0; i < filetext.Length; i++)
                    {
                        if (!(rus_string1.Contains(filetext[i]) || rus_string2.Contains(filetext[i]) || filetext[i] == ' '))
                        {
                            filetext = filetext.Remove(i, 1);
                            i--;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < filetext.Length; i++)
                    {
                        if (!(eng_string1.Contains(filetext[i]) || eng_string2.Contains(filetext[i]) || filetext[i] == ' '))
                        {
                            filetext = filetext.Remove(i, 1);
                            i--;
                        }
                    }
                }
                load.Text = filetext;
            }
            
        }

        private void load_TextChanged(object sender, EventArgs e)
        {
            //проверка вводимого текста
            string text = load.Text; //вытаскиваем текст для проверки
            
            for (int i = 0; i < load.Text.Length; i++)
            {
                if (rus.Checked == true && !rus_string.Contains(text[i]))
                //не даем ввести все что не входит в контрольные строки
                {
                    label3.Visible = true;
                    load.Text = text.Remove(text.Length - 1);
                }
                if (eng.Checked == true && !eng_string.Contains(text[i]))
                {
                    label3.Visible = true;
                    load.Text = text.Remove(text.Length - 1);
                }
            }
            //переводим каретку в конец (точку старта ввода)
            load.SelectionStart = load.Text.Length;
        }
    }
}
