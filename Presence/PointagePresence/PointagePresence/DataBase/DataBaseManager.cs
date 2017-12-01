using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using PointagePresence.Model;
using System.Data;

namespace PointagePresence.DataBase
{
    public static class DataBaseManager
    {
        public const String S3SQL = "SERVER=10.163.14.203;UID=sa;PWD=Passw0rd;DATABASE=SAISIE_CONT;Connection Timeout=2;";

        public static List<Secteur> ChargerSecteurs()
        {
            
            return new List<Secteur>();
        }

    }
}
