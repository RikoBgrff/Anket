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
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(
                new User
                {
                    Name = textBox1.Text
                }
                );
        }

        class User
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public DateTime BirthDate { get; set; }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "Name";
        }
        static void JsonSerialize(User user)
        {
            string fileName = user.Name + ".json";
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(fileName))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, user);
                }
            }
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
            JsonSerialize(user);
        }
        void JsonDeserialize(User user)
        {
            string fileName = textBox5.Text;
            User[] datas = null;
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader(fileName))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    datas = serializer.Deserialize<User[]>(jr);
                }
                foreach (var item in datas)
                {
                    textBox1.Text = item.Name;
                    textBox2.Text = item.Surname;
                    textBox3.Text = item.Email;
                    textBox4.Text = item.Phone;
                    dateTimePicker1.Value = item.BirthDate;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Name = textBox5.Name
            };
            JsonDeserialize(user);
        }
    }
}