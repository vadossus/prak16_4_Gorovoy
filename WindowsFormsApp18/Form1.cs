using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp18
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("test.txt"))
            {
                string[] lines = File.ReadAllLines("test.txt");

                foreach (string line in lines)
                {
                    listBox1.Items.Add(line);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Вы ничего не ввели в поле", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    List<string> goroda = new List<string>();
                    double n = Convert.ToDouble(textBox1.Text);

                    string[] lines = File.ReadAllLines("test.txt");

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(' ');
                        string imya_goroda = parts[0];
                        double nacelenie = Convert.ToDouble(parts[1].Replace(" ", ""));

                        if (nacelenie > n)
                            goroda.Add($"{imya_goroda} {nacelenie}");
                    }

                    goroda = goroda.OrderBy(x => x.Length).ThenBy(x => x).ToList();

                    listBox2.Items.Clear();
                    foreach (string gorod in goroda)
                    {
                        listBox2.Items.Add(gorod);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка: Вы ввели неправильный формат строки");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return;
            }
            
            
        }


    }
}
