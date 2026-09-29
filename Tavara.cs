using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        //pakko kertoa onko tavara paratnava tai vahingoittava
        public abstract bool Parantava { get; }
        public abstract bool Vahingoittava { get; }

        public Tavara(string tavaraNimi)
        {
            this.tavaraNimi = tavaraNimi;
        }

        public override string ToString()
        {
            return tavaraNimi;
        }


        /// <summary>
        /// Palauttaa Tavaran hinnan.
        /// </summary>
        /// <returns></returns>
        public abstract int PalautaHinta();

        /// <summary>
        /// funktio vahingoittavalle esineelle.
        /// </summary>
        /// <returns></returns>
        public virtual int Vahinko() { return 0; }

        /// <summary>
        /// funktio parantavalle esineelle.
        /// </summary>
        /// <returns></returns>
        public virtual int Paranna() { return 0; }
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

        public override bool Vahingoittava => true;
        public override bool Parantava => false;

        public Jousi() : base("Jousi") {  }

        /// <summary>
        /// luo uuden aloitelija nuolen
        /// </summary>
        /// <returns></returns>
        public static Jousi LuoAloittelijaNuoli()
        {
            Jousi uusi = new Jousi();
            uusi.karki = Karki.puu;
            uusi.pera = Pera.lehti;
            uusi.tavaraNimi = "Aloittelijanuoli";
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
            uusi.tavaraNimi = "Perusnuoli";
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
            uusi.tavaraNimi = "Eliittinuoli";
            return uusi;
        }

        /// <summary>
        /// Palauttaa nuolen hinnan.
        /// </summary>
        /// <returns></returns>
        public override int PalautaHinta()
        {
            // Laske hinta kärjen ja perän mukaan

            /*int hinta = 0;
            switch (karki)
            {
                case Karki.puu:
                    hinta += 3; break;
                case Karki.teräs:
                    hinta += 5; break;
                case Karki.timantti:
                    hinta += 10; break;
                default: hinta += 0; break;
            }
            switch (pera)
            {
                case Pera.lehti:
                    hinta += 0; break;
                case Pera.kanansulka:
                    hinta += 1; break;
                case Pera.kotkansulka:
                    hinta += 5; break;
                default: hinta += 0; break;
            }
            //return hinta;*/
            return Vahinko() * 2;
        }

        public override int Vahinko()
        {
            int vahinko = 0;
            switch (karki)
            {
                case Karki.puu:
                    vahinko += 1; break;
                case Karki.teräs:
                    vahinko += 2; break;
                case Karki.timantti:
                    vahinko += 3; break;
                default: vahinko += 0; break;
            }
            switch (pera)
            {
                case Pera.lehti:
                    vahinko += 2; break;
                case Pera.kanansulka:
                    vahinko += 3; break;
                case Pera.kotkansulka:
                    vahinko += 4; break;
                default: vahinko += 0; break;
            }
            return vahinko;
        }

        public void AsetaKarki(Karki karki)
        {
            this.karki = karki;
        }

        public void AsetaPera(Pera pera)
        {
            this.pera = pera;
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
            pippuri,
            chili
        }
        private Paaraaka paaraaka;
        private Lisuke lisuke;
        private Kastike kastike;

        public override bool Vahingoittava => false;
        public override bool Parantava => true;

        public Ruoka() : base("Ruoka") {  }

        /// <summary>
        /// Luo aloittelija annoksen.
        /// </summary>
        /// <returns></returns>
        public static Ruoka LuoAloittelijaAnnos()
        {
            Ruoka uus = new Ruoka();
            uus.paaraaka = Paaraaka.nautaa;
            uus.lisuke = Lisuke.perunaa;
            uus.kastike = Kastike.curry;
            uus.tavaraNimi = "Aloittelija-annos";
            return uus;
        }

        /// <summary>
        /// Luo perus annoksen.
        /// </summary>
        /// <returns></returns>
        public static Ruoka LuoPerusAnnos()
        {
            Ruoka uus = new Ruoka();
            uus.paaraaka = Paaraaka.kanaa;
            uus.lisuke = Lisuke.riisiä;
            uus.kastike = Kastike.pippuri;
            uus.tavaraNimi = "Perusannos";
            return uus;
        }

        /// <summary>
        /// Luo perus annoksen.
        /// </summary>
        /// <returns></returns>
        public static Ruoka LuoEliittiAnnos()
        {
            Ruoka uus = new Ruoka();
            uus.paaraaka = Paaraaka.kasviksia;
            uus.lisuke = Lisuke.pastaa;
            uus.kastike = Kastike.chili;
            uus.tavaraNimi = "Eliittiannos";
            return uus;
        }

        public override int PalautaHinta() { return Paranna()*2; }

        public override int Paranna() 
        {
            int paranna = 0;
            switch (paaraaka)
            {
                case Paaraaka.nautaa: paranna = 1; break;
                case Paaraaka.kanaa: paranna = 2; break;
                case Paaraaka.kasviksia: paranna = 3; break;
            }
            switch (lisuke)
            {
                case Lisuke.perunaa: paranna += 0; break;
                case Lisuke.riisiä: paranna += 1; break;
                case Lisuke.pastaa: paranna += 2; break;
            }
            switch (kastike)
            {
                case Kastike.curry: paranna += 0; break;
                case Kastike.pippuri: paranna += 1; break;
                case Kastike.chili: paranna += 2; break;
            }
            return paranna;
        }

        /// <summary>
        /// Asettaa paaraa'an.
        /// </summary>
        /// <param name="paaraaka">Paaraka, joka asetetaan.</param>
        public void AsetaPaaraaka(Paaraaka paaraaka) 
        { 
            this.paaraaka = paaraaka;
        }

        /// <summary>
        /// Asettaa lisukkeen.
        /// </summary>
        /// <param name="lisuke">Lisuke, joka asetetaan.</param>
        public void AsetaLisuke(Lisuke lisuke) 
        { 
            this.lisuke = lisuke;
        }

        /// <summary>
        /// Asettaa kastikkeen.
        /// </summary>
        /// <param name="kastike">Kastike, joka asetetaan.</param>
        public void AsetaKastike(Kastike kastike) 
        { 
            this.kastike = kastike;
        }
    }

    internal class Miekka : Tavara
    {
        public override bool Vahingoittava => true;
        public override bool Parantava => false;

        public Miekka() : base("Miekka") {}

        public override int PalautaHinta()
        {
            throw new NotImplementedException();
        }

        public override int Vahinko()
        {
            return 2;
        }
    }
}
