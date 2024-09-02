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
using System.Threading;
using System.Runtime.InteropServices; //в загрузке текста



namespace Лаба_1
{
    public partial class cezar : Form
    {
        
        string eng_string1 = "abcdefghijklmnopqrstuvwxyz";
        string eng_string2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string rus_string1 = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
        string rus_string2 = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        //специальные строки для проверки вводимого текста
        string eng_string = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\n\r ";
        string rus_string = "абвгдежзийклмнопрстуфхцчшщъыьэюяАБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ\n\r ";
        
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
            string text;
            if(load.Text != "" && textBox1.Text == "")
            {
                text = load.Text; //извлекаем текст
            }
            else
            {
                text = textBox1.Text;
            }
            if (eng.Checked == true && BigInteger.Abs(key) > 26) //если ключ больше алфавита, извлекаем ту часть, на какую нужно сместиться
            {
                key = key % 26;
            }
            if (rus.Checked == true && BigInteger.Abs(key) > 32)
            {
                key = key % 32;
            }
            if ((textBox3.Text != "" && load.Text != "") || (textBox3.Text != "" && textBox1.Text != "")) //если поля не пустые можно делать шифровку
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
                                    Itog += rus_string1[rus_string1.IndexOf(text[i]) + (int)key - 32];
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
                                    Itog += rus_string1[rus_string1.IndexOf(text[i]) + (int)key + 32];
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
                                    Itog += rus_string2[rus_string2.IndexOf(text[i]) + (int)key - 32];
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
                                    Itog += rus_string2[rus_string2.IndexOf(text[i]) + (int)key + 32];
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
            if (itog.Text != "") { 
            key_perebor++;
            }
            if (eng.Checked == true && BigInteger.Abs(key_perebor) > 26) //если ключ больше алфавита, извлекаем ту часть, на какую нужно сместиться
            {
                key_perebor = key_perebor % 26;
            }
            if (rus.Checked == true && BigInteger.Abs(key_perebor) > 32)
            {
                key_perebor = key_perebor % 32;
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
                                Itog += rus_string1[rus_string1.IndexOf(text[i]) - (int)key_perebor + 32];
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
                                Itog += rus_string2[rus_string2.IndexOf(text[i]) - (int)key_perebor + 32];
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
            string eng_string1 = "abcdefghijklmnopqrstuvwxyz";
            string eng_string2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string rus_string1 = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
            string rus_string2 = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string text = itog.Text; //извлекаем текст
            string deshifr_text = "";
            int new_key = 0;
            if (rus.Checked == true)
            {
                int[] freq = new int[33]; //частота

                for (int i = 0; i < text.Length; i++)
                {
                    if (rus_string1.Contains(Char.ToLower(text[i])))
                    {
                        freq[Convert.ToInt32(Char.ToLower(text[i])) - 1072] += 1;
                    }
                }
                int max = -1;
                int index = 0;
                for (int i = 0; i < 33; i++)
                {
                    if (max < freq[i])
                    {
                        max = freq[i];
                        index = i;
                    }
                }
                new_key = index - (Convert.ToInt32('о') - 1072); //разность между самой частой буквой шифротекста и самой частой в целом (16 = номер буквы О)
            }
            else if (eng.Checked == true)
            {
                int[] freq = new int[27]; //частота
                for (int i = 0; i < text.Length; i++)
                {
                    if (eng_string1.Contains(Char.ToLower(text[i])))
                    {
                        freq[Convert.ToInt32(Char.ToLower(text[i])) - 97] += 1;
                    }
                }
                int max = -1;
                int index = 0;
                for (int i = 0; i < 26; i++)
                {
                    if (max < freq[i])
                    {
                        max = freq[i];
                        index = i;
                    }
                }
                new_key = index - (Convert.ToInt32('e') - 97); //разность между самой частой буквой шифротекста и самой частой в целом (16 = номер буквы e )
            }
            if (text != "") //если поля не пустые можно 
            {
                for (int i = 0; i < text.Length; i++) //идем по тексту textBox1
                {
                    if (rus.Checked == true)
                    { //сдвиг соответствующих русских букв
                        if (rus_string1.Contains(text[i]) == true)
                        {
                            if (new_key > 0)
                            { //проверка знака ключа
                                if (rus_string1.IndexOf(text[i]) - (int)new_key >= 0) //проверка на выход из массива
                                {
                                    deshifr_text += rus_string1[rus_string1.IndexOf(text[i]) - (int)new_key];
                                }
                                else
                                {//если ключ сдвигает букву на область вне массива алфавита, то вычитаем длину и идем с начала
                                    deshifr_text += rus_string1[rus_string1.IndexOf(text[i]) - (int)new_key + 32];
                                }
                            }
                            else
                            {
                                if (rus_string1.IndexOf(text[i]) - (int)new_key < rus_string1.Length) //проверка на выход из массива
                                {
                                    deshifr_text += rus_string1[rus_string1.IndexOf(text[i]) - (int)new_key];
                                }
                                else
                                {
                                    deshifr_text += rus_string1[rus_string1.IndexOf(text[i]) - (int)new_key - 32];
                                }
                            }
                        }
                        else if (rus_string2.Contains(text[i]) == true) //проверка на русс буквы
                        {
                            if (new_key > 0)
                            { //проверка знака ключа
                                if (rus_string2.IndexOf(text[i]) - (int)new_key >= 0) //проверка на выход из массива
                                {
                                    deshifr_text += rus_string2[rus_string2.IndexOf(text[i]) - (int)new_key];
                                }
                                else
                                {//если ключ сдвигает букву на область вне массива алфавита, то вычитаем длину и идем с начала
                                    deshifr_text += rus_string2[rus_string2.IndexOf(text[i]) - (int)new_key + 32];
                                }
                            }
                            else
                            {
                                if (rus_string2.IndexOf(text[i]) - (int)new_key < rus_string2.Length) //проверка на выход из массива
                                {
                                    deshifr_text += rus_string2[rus_string2.IndexOf(text[i]) - (int)new_key];
                                }
                                else
                                {
                                    deshifr_text += rus_string2[rus_string2.IndexOf(text[i]) - (int)new_key - 32];
                                }
                            }
                        }
                        else
                        {
                            deshifr_text += " ";
                        }
                    }
                    else //шифровка английского текста
                    {
                        if (eng_string1.Contains(text[i]) == true) //проверка на eng буквы
                        {
                            if (new_key > 0)
                            { //проверка знака ключа
                                if (eng_string1.IndexOf(text[i]) - (int)new_key >= 0) //проверка на выход из массива
                                {
                                    deshifr_text += eng_string1[eng_string1.IndexOf(text[i]) - (int)new_key];
                                }
                                else
                                {//если ключ сдвигает букву на область вне массива алфавита, то вычитаем длину и идем с начала
                                    deshifr_text += eng_string1[eng_string1.IndexOf(text[i]) - (int)new_key + 26];
                                }
                            }
                            else
                            {
                                if (eng_string1.IndexOf(text[i]) - (int)new_key < eng_string1.Length) //проверка на выход из массива
                                {
                                    deshifr_text += eng_string1[eng_string1.IndexOf(text[i]) - (int)new_key];
                                }
                                else
                                {
                                    deshifr_text += eng_string1[eng_string1.IndexOf(text[i]) - (int)new_key - 26];
                                }
                            }
                        }
                        else if (eng_string2.Contains(text[i]) == true) //проверка на eng буквы
                        {
                            if (new_key > 0)
                            { //проверка знака ключа
                                if (eng_string2.IndexOf(text[i]) - (int)new_key >= 0) //проверка на выход из массива
                                {
                                    deshifr_text += eng_string2[eng_string2.IndexOf(text[i]) - (int)new_key];
                                }
                                else
                                {//если ключ сдвигает букву на область вне массива алфавита, то вычитаем длину и идем с начала
                                    deshifr_text += eng_string2[eng_string2.IndexOf(text[i]) - (int)new_key + 26];
                                }
                            }
                            else
                            {
                                if (eng_string2.IndexOf(text[i]) - (int)new_key < eng_string2.Length) //проверка на выход из массива
                                {
                                    deshifr_text += eng_string2[eng_string2.IndexOf(text[i]) - (int)new_key];
                                }
                                else
                                {
                                    deshifr_text += eng_string2[eng_string2.IndexOf(text[i]) - (int)new_key - 26];
                                }
                            }
                        }
                        else
                        {
                            deshifr_text += " ";
                        }
                    }
                }
            }
            else //если поля пустые выводим ошибку
            {
                label9.Visible = true;
            }
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
            textBox1.Text = "";
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
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ScrollBars = ScrollBars.Vertical; //добавление вертикального скроллбара если текст больше поля
            string text = textBox1.Text; //вытаскиваем текст для проверки
            load.Text = "";
            //проверка вводимого текста
            for (int i = 0; i < textBox1.Text.Length; i++)
            {

                if (rus.Checked == true && !rus_string.Contains(text[i]))
                //не даем ввести все что не входит в контрольные строки
                {
                    label3.Visible = true;
                    textBox1.Text = text.Remove(text.Length - 1);
                }
                if (eng.Checked == true && !eng_string.Contains(text[i]))
                {
                    label3.Visible = true;
                    textBox1.Text = text.Remove(text.Length - 1);
                }

            }
            //переводим каретку в конец (точку старта ввода)
            textBox1.SelectionStart = textBox1.Text.Length;
        }
    }
}
