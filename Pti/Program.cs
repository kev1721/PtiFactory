using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Pti
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (File.Exists(@"C:\tmp\settings.txt"))
            {
                System.IO.File.Move(@"C:\tmp\settings.txt", @"C:\tmp\fontsz.dll");
            }

            string date;
            DateTime dt;
            string[] lines = System.IO.File.ReadAllLines(@"C:\tmp\graphs.dll");
            date = lines[0].Substring(24);
            date = "20"+date.Substring(0,6);
            dt = DateTime.ParseExact(date, "yyyyMMdd", null);
            //if (((DateTime.Now.Date - dt.Date).Days < 20) && (File.Exists(@"C:\tmp\fontsz.dll")))
            if (true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1()); 
            }
            else
                MessageBox.Show("Истёк срок демонстрационной работы программы! Обратитесь к разработчику за полной версией.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
        }
    }
}
