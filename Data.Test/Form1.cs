using System;
using System.Windows.Forms;
using Data.Interface;
using Data.SqlServer2012;

namespace Data.Test
{
    public partial class Form1 : Form
    {
        private IDatabaseFactory DbFactory { get; set; }

        public Form1(IDatabaseFactory dbFactory)
        {
            DbFactory = dbFactory;
            InitializeComponent();
        }

        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            var database = new Database();
            var connected = await database.Connect(textBoxConnectionString.Text);
            if (connected)
            {
                var tables = await database.GetTables();
            }
            
        }
    }
}
