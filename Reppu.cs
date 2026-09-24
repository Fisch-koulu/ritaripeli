using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritaripeli
{
    internal class Reppu
    {
        int maxMaara = 10;
        private List<Tavara> tavaraList = new List<Tavara>();
        public List<Tavara> TavaraList { get { return tavaraList; } }

        /// <summary>
        /// Yrittää lisätä uuden tavaran reppuun.
        /// </summary>
        /// <param name="tavara"></param>
        /// <returns></returns>
        public bool YritäLisaa(Tavara tavara)
        {
            if (tavara == null) return false;
            //katso ettei voi lisätä repun maksimi määrän.
            if (tavaraList.Count + 1 < maxMaara)
            {
                tavaraList.Add(tavara);
                Print.LineColor($"{tavara.ToString()} lisättiin reppuusi.", ConsoleColor.Yellow);
                return true;
            }
            Print.LineColor("Sinulla on liika tavaroita repussa.", ConsoleColor.Red);
            return false;
        }

        public void ListaaRepunTavarat()
        {
            Console.WriteLine("Repussa on:");
            for (int i = 0; i < tavaraList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {tavaraList[i]}");
            }
            Console.WriteLine($"{tavaraList.Count + 1}: Mene takaisin");
        }

        /// <summary>
        /// Valinnassa pitää tarkistaa, onko pelaajan antama numero repun sisällä.
        /// </summary>
        /// <param name="valittu"></param>
        /// <returns></returns>
        public Tavara OtaRepunTavara(int valittu)
        {
            //miinusta yksi valinnasta.
            valittu--;
            //ota tavara talteen.
            Tavara annaTavara = tavaraList[valittu];
            //poista tavara listasta.
            tavaraList.RemoveAt(valittu);
            //ja palauta tavara.
            return annaTavara;
        }
    }
}
