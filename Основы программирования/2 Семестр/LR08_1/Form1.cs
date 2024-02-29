using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LR08_1
{
    public partial class Form1 : Form
    {
        static List<IVectorable> Vectors = new List<IVectorable>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] elements = Convert.ToString(textBox1.Text).Split(' ');
            IVectorable vector;
            if (int.Parse(elements[0]) == 1)
            {
                vector = new ArrayVector(elements.Length - 1);
                for (int i = 0; i < vector.Length; i++)
                {
                    vector[i] = Convert.ToInt32(elements[i+1]);
                }
                Vectors.Add(vector);
            }
            else if (int.Parse(elements[0]) == 2)
            {
                vector = new LinkedListVector(elements.Length - 1);
                for (int i = 0; i < vector.Length; i++)
                {
                    vector[i] = Convert.ToInt32(elements[i + 1]);
                }
                Vectors.Add(vector);
            }
            textBox1.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = null;
            if (Vectors.Count == 0)
            {
                textBox4.Text += "Список пуст" + Environment.NewLine;
            }
            List<IVectorable> sorted = new List<IVectorable>(Vectors);
            sorted.Sort();
            int i = 0;
            while (i < sorted.Count && sorted[0].Length == sorted[i].Length)
            {
                textBox4.Text += sorted[i].ToString() + Environment.NewLine;
                i++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = null;
            if (Vectors.Count == 0)
            {
                textBox3.Text += "Список пуст" + Environment.NewLine;
            }
            List<IVectorable> sorted = new List<IVectorable>(Vectors);
            sorted.Sort();
            int i = sorted.Count - 1;
            while (i >= 0 && sorted[sorted.Count - 1].Length == sorted[i].Length)
            {
                textBox3.Text += sorted[i].ToString() + Environment.NewLine;
                i--;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            if (Vectors.Count == 0)
            {
                textBox2.Text += "Список пуст" + Environment.NewLine;
            }
            List<IVectorable> sorted = new List<IVectorable>(Vectors);
            sorted.Sort(new VectorComparer());
            for (int i = 0; i < sorted.Count; i++)
            {
                textBox2.Text += sorted[i].ToString() + Environment.NewLine;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            if (Vectors.Count == 0)
            {
                textBox2.Text += "Список пуст" + Environment.NewLine;
            }
            for (int i = 0; i < Vectors.Count; i++)
            {
                textBox2.Text += Vectors[i].ToString() + Environment.NewLine;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = int.Parse(textBox5.Text);
            Vectors.RemoveAt(index);
            textBox5.Text = null;
        }
    }
}
