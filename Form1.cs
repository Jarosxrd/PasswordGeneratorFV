using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGeneratorFV
{
    public partial class Form1 : Form
    {
        int currentPasswordLength = 0;
        Random character = new Random();

        public Form1()
        {
            InitializeComponent();
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 14;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = " " + trackBar1.Value.ToString();
            currentPasswordLength = trackBar1.Value;
        }

        private void техническаяПоддержкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 AA = new Form3();
            AA.ShowDialog();
        }

        private void обАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 AA = new Form2();
            AA.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (numericUpDown1.Value == 0 && trackBar1.Value == 0)
            {
                toolStripStatusLabel1.Visible = true;
                statusStrip1.BackColor = Color.Red;
                toolStripStatusLabel1.Text = "Ошибка!!!";

                MessageBox.Show("Выберите необходимое количество символов для пароля, а также количество паролей для генерации!", "Ошибка!!!", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return;
            }
            if (numericUpDown1.Value == 0)
            {
                statusStrip1.BackColor = Color.Red;
                toolStripStatusLabel1.Text = "Ошибка!!!";

                MessageBox.Show("Выберите необходимое количество паролей для генерации!", "Ошибка!!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (trackBar1.Value == 0)
            {
                statusStrip1.BackColor = Color.Red;
                toolStripStatusLabel1.Text = "Ошибка!!!";

                MessageBox.Show("Введите необходимое количество символов для генерации пароля!", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string allCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz!@#$%^&$";
            String randomPassword = "" ;
            int quantityOfPasswords = (int)numericUpDown1.Value;

            for (int j = 0; j < quantityOfPasswords; j++)
            {

                for (int i = 0; i < currentPasswordLength; i++)
                {
                    int randomNum = character.Next(0, allCharacters.Length);
                    randomPassword += allCharacters[randomNum];
                }
                listBox1.Items.Add(randomPassword)  ;
                randomPassword = "";
                statusStrip1.BackColor = Color.Green;
                toolStripStatusLabel1.Text = "Пароль(-и) были успешно сгенерированы!";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string text = "";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                text += listBox1.Items[i].ToString() + " " ;
            }
            Clipboard.SetText(text);
            statusStrip1.BackColor = Color.Green;
            toolStripStatusLabel1.Text = "Пароль(-и) были успешно скопированы!";
        }
    }
}
