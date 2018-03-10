using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); //list box'u temizle
            string[] kelime = textBox1.Text.Split(' ', ',', ':', '\n'); // cümle parçalama fonksiyonu 
            for (int i = 0; i < kelime.Length; i++)
            {
                listBox1.Items.Add(kelime[i]); //parçalanan cümleyi list box'a ekleme
                                               //listBox1.Items.RemoveAt(2);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            string[] kelime = new string[listBox1.Items.Count];
            int[] harf = new int[100];

            for (int i = 0; i < kelime.Length; i++)
            {
                kelime[i] = listBox1.Items[i].ToString(); //listbox1'deki verileri tekrar kullanabilmek için tekrar stringe yükledik

            }

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                for (int j = 0; j < listBox1.Items.Count - 1; j++)
                {
                    string temp1 = kelime[j].ToLower();
                    string temp2 = kelime[j + 1].ToLower();
                     temp1 = temp1.Replace('ö', 'o');
                     temp1 = temp1.Replace('ü', 'u');
                     temp1 = temp1.Replace('ğ', 'g');
                     temp1 = temp1.Replace('ş', 's');
                     temp1 = temp1.Replace('ç', 'c');
                     temp1 = temp1.Replace('ı', 'i');
                     temp2 = temp2.Replace('ö', 'o');
                     temp2 = temp2.Replace('ü', 'u');
                     temp2 = temp2.Replace('ğ', 'g');
                     temp2 = temp2.Replace('ş', 's');
                     temp2 = temp2.Replace('ç', 'c');
                     temp2 = temp2.Replace('ı', 'i');
                    
                    if (temp1.Length == 0 || temp2.Length == 0)
                    {
                        if (temp2.Length == 0 && temp1.Length != 0)
                        {

                            string temp3 = kelime[i];
                            kelime[i] = kelime[j];
                            kelime[j] = temp3;
                        }
                        else if (temp1.Length == 0 && temp2.Length != 0)
                        {

                            string temp3 = kelime[i];
                            kelime[i] = kelime[j];
                            kelime[j] = temp3;
                        }
                    }
                    else if (temp1.Length < temp2.Length)
                    {
                        if (temp2[0] < temp1[0])
                        {
                            string temp3 = kelime[j];
                            kelime[j] = kelime[j + 1];
                            kelime[j + 1] = temp3;
                        }
                        else if (temp2[0] == temp1[0] && temp1.Length > 1)
                        {
                            for (int z = 1; z < temp1.Length; z++)
                            {
                                if (temp2[z] < temp1[z])
                                {
                                    string temp3 = kelime[j];
                                    kelime[j] = kelime[j + 1];
                                    kelime[j + 1] = temp3;
                                    break;
                                }
                                /*else if (z == temp2.Length - 1 && temp1[z] == temp2[z])
                                {
                                    string temp3 = kelime[j];
                                    kelime[j] = kelime[j + 1];
                                    kelime[j + 1] = temp3;
                                    break;
                                }*/
                                else if (temp1[z] < temp2[z])
                                {
                                     break;
                                }
                                else continue;
                            }
                        }

                    }
                    else if (temp1.Length > temp2.Length)
                    {
                        if (temp2[0] < temp1[0])
                        {
                            string temp3 = kelime[j];
                            kelime[j] = kelime[j + 1];
                            kelime[j + 1] = temp3;
                        }
                        else if (temp2[0] == temp1[0] && temp2.Length > 1)
                        {
                            for (int z = 1; z < temp2.Length; z++)
                            {
                                if (temp2[z] < temp1[z])
                                {
                                    string temp3 = kelime[j];
                                    kelime[j] = kelime[j + 1];
                                    kelime[j + 1] = temp3;
                                    break;
                                }
                                else if (z == temp2.Length - 1 && temp2[z] == temp1[z])
                                {
                                    string temp3 = kelime[j];
                                    kelime[j] = kelime[j + 1];
                                    kelime[j + 1] = temp3;
                                    break;
                                }
                                else if (temp1[z] < temp2[z])
                                {
                                    break;
                                }
                                else continue;
                            }
                        }
                        else if (temp2[0] == temp1[0] && temp2.Length == 1)
                        {
                            string temp3 = kelime[j];
                            kelime[j] = kelime[j + 1];
                            kelime[j + 1] = temp3;
                        }
                    }
                    else if (temp1.Length == temp2.Length)
                    {
                        if (temp2[0] < temp1[0])
                        {
                            string temp3 = kelime[j];
                            kelime[j] = kelime[j + 1];
                            kelime[j + 1] = temp3;
                        }
                        else if (temp2[0] == temp1[0] && temp2.Length > 1)
                        {
                            for (int z = 1; z < temp2.Length; z++)
                            {
                                if (temp2[z] < temp1[z])
                                {
                                    string temp3 = kelime[j];
                                    kelime[j] = kelime[j + 1];
                                    kelime[j + 1] = temp3;
                                    break;
                                }
                                else if (temp1[z] < temp2[z])
                                {
                                    break;
                                }
                                else continue;
                            }
                        }
                    }
                }

            }


            for(int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox2.Items.Add(kelime[i]);
            }



        }
    }
}
