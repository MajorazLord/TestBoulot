using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PointagePresence.Model
{
    public class Site
    {
        List<Secteur> LesSecteurs;

        public Site(List<Secteur> secteurs)
        {
            LesSecteurs = secteurs;
        }
    }
}
