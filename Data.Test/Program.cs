using System;
using System.Windows.Forms;


namespace Data.Test
{
    using Data.Generic.Concrete;
    using Data.Generic.Concrete.FieldTypes;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Field f = new Field(new FieldDefinition("a", new StringFieldType(), false, 10, 0));
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(new SqlServer2012.DatabaseFactory()));


        }
    }
}
