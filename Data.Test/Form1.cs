using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Interface;
using Data.SqlServer2012;

namespace Data.Test
{
    public partial class Form1 : Form
    {
        private IDatabaseFactory _databaseFactory { get; set; }
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public Form1(IDatabaseFactory dbFactory)
        {
            _databaseFactory = dbFactory;
            InitializeComponent();
        }

        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            var database = new Database();

            var connected = await database.Connect(_cts.Token, textBoxConnectionString.Text);

            if (connected)
            {
                var tables = await database.GetTables(_cts.Token);
            }

        }
    }
}
