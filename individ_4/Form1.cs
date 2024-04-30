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
using System.Collections;

namespace individ_4
{
    public partial class Form1 : Form
    {
        Hashtable colec = new Hashtable();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "номер диска";
            dataGridView1.Columns[1].Name = "исполнитель";
            dataGridView1.Columns[2].Name = "песня";
        }
    

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
    
         
        }

        private void button7_Click(object sender, EventArgs e)
        {
    
        }
        private void UpdateDgv()
        {
            dataGridView1.Rows.Clear();
            foreach (DictionaryEntry it in colec)
            {
                string num = it.Key.ToString();
                ArrayList pesnya = (ArrayList)it.Value;
                string[] row = { num, pesnya[0].ToString(), pesnya[1].ToString() };
                dataGridView1.Rows.Add(row);
            }
        }
            private void button3_Click(object sender, EventArgs e)
        {
           
            string num = Convert.ToString(numericUpDown1.Value);
            string isp = textBox3.Text;
            string pesnya = textBox2.Text;
            if (num != "" && isp != "" && pesnya != "")
            {
                if (!colec.ContainsKey(num))
                { 
                colec.Add(num, new ArrayList());
                    ArrayList pesni = (ArrayList)colec[num];
                    pesni.Add(isp);
                    pesni.Add(pesnya);
                    UpdateDgv();
                }
                else MessageBox.Show("диск с таким номером уже есть", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else MessageBox.Show("заполните все строки!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
          
            if (selectedRowIndex >= 0)
            {
                string num = dataGridView1[0, selectedRowIndex].Value.ToString();
                colec.Remove(num);
                UpdateDgv();
            }
            else MessageBox.Show("выберите строку для удаления", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") {
                string singer = textBox1.Text;
                var ss = from DictionaryEntry it in colec
                         where ((ArrayList)it.Value)[0].ToString() == singer
                         select new
                         {
                             num=it.Key,
                             isp = ((ArrayList)it.Value)[0],
                             pesnya = ((ArrayList)it.Value)[1]

                         };
                foreach (var s in ss)
                {
                    string isp = (string)s.isp, num = (string)s.num, pesnya = (string)s.pesnya;
                    string rez =  isp +" - "+pesnya+" лежит на диске " + num ;
                    MessageBox.Show(rez);
                }

            }
            else MessageBox.Show("введите исполнителя", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
