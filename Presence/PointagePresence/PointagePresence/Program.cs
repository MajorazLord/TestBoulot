using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using PointagePresence.Model;
using PointagePresence.DataBase;

namespace PointagePresence
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Site x = new Site(DataBaseManager.ChargerSecteurs());
            Application.Run(new Form1());
        }
    }
}