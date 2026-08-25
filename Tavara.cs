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
        public float Pituus
        {
            get { return pituus; }
            set
            {
                pituus = value;

                if (pituus < 60)
                    pituus = 60.0f;
                if (pituus > 100.0f)
                    pituus = 100.0f;
            }
        }

        private Karki karki;
        private Pera pera;
        private float pituus;

        public Jousi(Karki karki, Pera pera, float pituus) : base("Jousi") 
        {
            this.karki = karki;
            this.pera = pera;
            this.pituus = pituus;
        }

        public static Jousi Aloittelija()
        {
            Jousi uusi = new Jousi(Karki.timantti, Pera.lehti, 60f);
            return uusi;
        }

        public static Jousi LuoPerusNuoli()
        {
            Jousi uus = new Jousi(Karki.teräs, Pera.kanansulka, 85f);
            return uus;
        }

        public static Jousi LuoAloittelijaNuoli()
        {
            Jousi uus = new Jousi(Karki.puu, Pera.lehti, 70f);
            return uus;
        }
    }
}
