using System;
using System.Windows.Forms;
using Data.Interface;
using Data.SqlServer2012;

namespace Data.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            var database = new Database();
            var connected = await database.Connect(textBoxConnectionString.Text).Result;
            if (connected)
            {
                var tables = database.GetTables().Result;
            }
            else
            {
                int i = 0;
            }
            
        }
    }
}
