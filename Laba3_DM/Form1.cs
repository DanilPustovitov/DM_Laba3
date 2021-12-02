using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3_DM
{
    public partial class Form1 : Form
    {
        List<DataGridInitializer> init = new List<DataGridInitializer>();
        List<TriangleTable> triangle = new List<TriangleTable>();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            init.Add(new DataGridInitializer(0, 0, 0, 0,0));
            init.Add(new DataGridInitializer(0, 0, 1, 0,0));
            init.Add(new DataGridInitializer(0, 1, 0, 0,0));
            init.Add(new DataGridInitializer(0, 1, 1, 0,0));
            init.Add(new DataGridInitializer(1, 0, 0, 0,0));
            init.Add(new DataGridInitializer(1, 0, 1, 0,0));
            init.Add(new DataGridInitializer(1, 1, 0, 0,0));
            init.Add(new DataGridInitializer(1, 1, 1, 0,0));
            triangle.Add(new TriangleTable("000", "001", "010", "011", "100", "101", "110", "111"));
            triangle.Add(new TriangleTable("1", "z", "y", "yz", "x", "xz", "xy", "xyz"));
            dataGridView1.DataSource = init;
            dataGridView2.DataSource = triangle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            List<int> f_apos = new List<int>();
            foreach(var i in init)
            {
                f_apos.Add(i.F == 0 ? 1 : 0);
            }
            List<int> f_bin = new List<int>();
            int j = 0;
            for(int i=f_apos.Count-1; i>=0; i--)
            {
                init[j++].Fbin = f_apos[i];
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = init;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = "";
            foreach(var i in init)
            {
                if (i.F == 1)
                {
                    text += i.X == 0 ? "x' " : "x ";
                    text += i.Y == 0 ? "y' " : "y ";
                    text += i.Z == 0 ? "z' " : "z ";
                    text += " v ";
                }
            }
            richTextBox1.Text = text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = "";
            foreach (var i in init)
            {
                if (i.F == 0)
                {
                    text += "(";
                    text += i.X == 1 ? " x' v" : " x v";
                    text += i.Y == 1 ? " y' v" : " y v";
                    text += i.Z == 1 ? " z'" : " z";
                    text += ")";
                }
            }
            richTextBox2.Text = text;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            for(int i=0; i < 8; i++)
            {
                triangle.Add(new TriangleTable());
            }


            List<int> func = new List<int>();
            foreach(var i in init)
            {
                func.Add(i.F);
            }
            
            List<List<int>> data = new List<List<int>>();
            data.Add(func);
            data.Add(new List<int>());//7
            data.Add(new List<int>());//6
            data.Add(new List<int>());//5
            data.Add(new List<int>());//4
            data.Add(new List<int>());//3
            data.Add(new List<int>());//2
            data.Add(new List<int>());//1

            for (int u=0; u < data.Count; u++)
            {
                if (u + 1 == data.Count)
                {

                }
                else
                {
                    for (int i = 0; i < data[u].Count; i++)
                    {
                        if (i + 1 == data[u].Count)
                        {

                        }
                        else
                        {
                            data[u+1].Add((data[u][i] ^ data[u][i + 1]));
                        }
                    }
                }
            }

            int j = 7;
            for (int i=2; i < triangle.Count; i++)
            {
                triangle[i].e1 = data[0][i - 2].ToString();
                if (j >= 1)
                {
                    triangle[i].e2 = data[1][i - 2].ToString();
                }
                if (j >= 2)
                {
                    triangle[i].e3 = data[2][i - 2].ToString();
                }
                if (j >= 3)
                {
                    triangle[i].e4 = data[3][i - 2].ToString();
                }
                if (j >= 4)
                {
                    triangle[i].e5 = data[4][i - 2].ToString();
                }
                if (j >= 5)
                {
                    triangle[i].e6 = data[5][i - 2].ToString();
                }
                if (j >= 6)
                {
                    triangle[i].e7 = data[6][i - 2].ToString();
                }
                if (j == 7)
                {
                    triangle[i].e8 = data[7][i - 2].ToString();
                }
                j--;
            }

            string pol = "";
            for (int i=0; i < 8; i++)
            {
                if (data[i][0] == 1)
                {
                    switch (i)
                    {
                        case 0:
                            pol += "1 ";
                            break;
                        case 1:
                            pol += " z ";
                            break;
                        case 2:
                            pol += " y ";
                            break;
                        case 3:
                            pol += " yz ";
                            break;
                        case 4:
                            pol += " x ";
                            break;
                        case 5:
                            pol += " xz ";
                            break;
                        case 6:
                            pol += " xy ";
                            break;
                        case 7:
                            pol += " xyz ";
                            break;
                    }
                }
            }
            pol = pol.Replace(' ', '+');
            

            richTextBox3.Text = pol;


            if (func[0] == 0)
            {
                label12.Text = "Да";
            } else
            {
                label12.Text = "Нет";
            }
            if (func[func.Count - 1] == 1)
            {
                label11.Text = "Да";
            }else
            {
                label11.Text = "Нет";
            }

            bool samodvoynaya = true;
            foreach(var i in init)
            {
                if (i.F != i.Fbin)
                {
                    samodvoynaya = false;
                }
            }

            label9.Text = samodvoynaya ? "Да" : "Нет";

            label8.Text = triangle[2].e4 == "1" && triangle[2].e6 == "1" && triangle[2].e7 == "1" && triangle[2].e8 == "1" ? "Да" : "Нет";

            label10.Text = func[0] <= func[1] && func[0] <= func[2] && func[0] <= func[3] && func[1] <= func[3] && func[1] <= func[5] && func[2] <= func[3] && func[2] <= func[6] && func[3] <= func[7] && func[4] <= func[5] && func[4] <= func[6] && func[5] <= func[7] && func[6] <= func[7] ? "Да" : "Нет";

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = triangle;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
