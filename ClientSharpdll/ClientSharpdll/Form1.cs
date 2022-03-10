using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using ClassLibrary1;
using System.Data.SqlClient;


namespace ClientSharpdll
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        Class1 remote = (Class1)Activator.GetObject(
                         typeof(Class1),
                          "http://localhost:5000/CalculationArFunction.soap");
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HttpChannel ch = new HttpChannel();
            ChannelServices.RegisterChannel(ch, false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x, y, z;
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            z = remote.addNumbers(x, y);
            textBox3.Text = z.ToString();
            //remote.SaveOperation(x, y, z, "add");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x, y, z;
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            z = remote.subNumbers(x, y);
            textBox3.Text = z.ToString();
            //remote.SaveOperation(x, y, z, "sub");

        }
    }
}
