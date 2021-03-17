using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        FileHelper helper = new FileHelper();
        bool changeBtnPressed = false;
        public Form1()
        {

            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddBtn.Location = new Point(119, 271);
            ChangeBtn.Location = new Point(119, 299);

            listBox1.Items.Add(
                new User
                {
                    Name = nameTxtBx.Text
                }
                );
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "Name";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            User user = new User
            {
                Name = nameTxtBx.Text,
                Surname = surnameTxtBx.Text,
                Email = phoneTxtBx.Text,
                Phone = emailTxtBx.Text,
                BirthDate = birthDate.Value
            };
            helper.JsonSerialize(user);
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = listBox1.SelectedItem;
        }

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            changeBtnPressed = true;
            if (changeBtnPressed == true)
            {
                ChangeBtn.Location = new Point(119, 271);
                AddBtn.Location = new Point(119, 299);
            }
        }

        private void GunaLoadBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.Text != "")
            {
                var obj = listBox1.SelectedItem as User;
                var p = FileHelper.JsonDeserialize((obj)?.Name);
                try
                {
                    nameTxtBx.Text = p.Name;
                    surnameTxtBx.Text = p.Surname;
                    emailTxtBx.Text = p.Surname;
                    phoneTxtBx.Text = p.Phone;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Name = nameTxtBx.Text,
                Surname = surnameTxtBx.Text,
                Email = phoneTxtBx.Text,
                Phone = emailTxtBx.Text,
                BirthDate = birthDate.Value
            };
            helper.JsonSerialize(user);

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            AddBtn.Location = new Point(99, 270);
            ChangeBtn.Location = new Point(99, 299);

            listBox1.Items.Add(
                new User
                {
                    Name = nameTxtBx.Text
                }
                );
        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            changeBtnPressed = true;
            if (changeBtnPressed == true)
            {
                ChangeBtn.Location = new Point(99, 270);
                AddBtn.Location = new Point(99, 299);
            }
            var obj = listBox1.SelectedItem as User;
            var p = FileHelper.JsonDeserialize((obj)?.Name);
            try
            {
                nameTxtBx.Text = p.Name;
                surnameTxtBx.Text = p.Surname;
                emailTxtBx.Text = p.Surname;
                phoneTxtBx.Text = p.Phone;
                birthDate.Value = p.BirthDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            User user = new User
            {
                Name = nameTxtBx.Text,
                Surname = surnameTxtBx.Text,
                Email = emailTxtBx.Text,
                Phone = phoneTxtBx.Text
            };
            helper.JsonSerialize(user);
        }


        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

