using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritaripeli
{
    /// <summary>
    /// Tästä luokasta peritään kaikki erilaiset 
    /// tavarat joita voi säilyttää repussa
    /// </summary>
    internal abstract class Tavara
    {
        public string TavaraNimi { get { return tavaraNimi; } set => tavaraNimi = value; }

        protected string tavaraNimi;

        public Tavara(string tavaraNimi)
        {
            this.tavaraNimi = tavaraNimi;
        }

        public override string ToString()
        {
            return tavaraNimi;
        }
    }

    ///luulen, että tämä tarkoittaa nuolia, mutta vahingossa käytettiin sanaa Jousi.
    internal class Jousi : Tavara
    {
        //nuolen rakennus osat
        //parametrit
        public enum Karki
        {
            puu,
            teräs,
            timantti
        }
        public enum Pera
        {
            lehti,
            kanansulka,
            kotkansulka
        }

        private Karki karki;
        private Pera pera;

        public Jousi() : base("Jousi") { }

        /// <summary>
        /// luo uuden aloitelija nuolen
        /// </summary>
        /// <returns></returns>
        public static Jousi LuoAloittelijaNuoli()
        {
            Jousi uusi = new Jousi();
            uusi.karki = Karki.puu;
            uusi.pera = Pera.lehti;
            return uusi;
        }

        /// <summary>
        /// luo uuden perus nuolen
        /// </summary>
        /// <returns></returns>
        public static Jousi LuoPerusNuoli()
        {
            Jousi uusi = new Jousi();
            uusi.karki = Karki.teräs;
            uusi.pera = Pera.kanansulka;
            return uusi;
        }

        /// <summary>
        /// luo uuden eliitti nuolen
        /// </summary>
        /// <returns></returns>
        public static Jousi LuoEliittiNuoli()
        {
            Jousi uusi = new Jousi();
            uusi.karki = Karki.timantti;
            uusi.pera = Pera.kotkansulka;
            return uusi;
        }
    }

    internal class Ruoka : Tavara
    {
        //parametrit
        //mitä ruuassa on
        public enum Paaraaka
        {
            nautaa,
            kanaa,
            kasviksia
        }
        public enum Lisuke
        {
            perunaa,
            riisiä,
            pastaa
        }
        public enum Kastike
        {
            curry,
            hapanimelä,
            pippuri,
            chili
        }

        public Ruoka() : base("Ruoka") { }
    }
}
