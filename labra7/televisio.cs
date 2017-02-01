using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    [Serializable]
    class TvOhjelma
    {
        public string Nimi { get; set; }
        public string Kanava { get; set; }
        public string Alku { get; set; }
        public string Loppu { get; set; }
        public string Info { get; set; }

        public TvOhjelma(string nimi, string kanava, string alku, string loppu, string info)
        {
            Nimi = nimi;
            Kanava = kanava;
            Alku = alku;
            Loppu = loppu;
            Info = info;
        }

        public override string ToString()
        {
            string s = string.Format("Nimi: {0}, Kanava: {1}\nLähetysaika: {2} - {3}\nInfo: {4}", Nimi, Kanava, Alku, Loppu, Info);
            return s;
        }

    }
}
