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
                    Name = textBox1.Text
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
                Name = textBox1.Text,
                Surname = textBox2.Text,
                Email = textBox3.Text,
                Phone = textBox4.Text,
                BirthDate = dateTimePicker1.Value
            };
            helper.JsonSerialize(user);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            helper.JsonDeserialize(fileNameTxtBx.Text);
            var obj = listBox1.SelectedItem as User;
            var p = helper.JsonDeserialize((obj)?.Name);
            textBox1.Text = p.Name;
            textBox2.Text = p.Surname;
            textBox3.Text = p.Email;
            textBox4.Text = p.Phone;
            dateTimePicker1.Value = p.BirthDate;
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
    }
}

