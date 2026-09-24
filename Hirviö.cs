using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritaripeli
{
	/// <summary>
	/// Tämä on pohjaluokka kaikille pelin hirviöille
	/// </summary>
	internal abstract class Hirviö
	{
		public int Osumapisteet { get; set; }
		public int MaxOsumapisteet { get; set; }
		public string Nimi { get; set; }
		public int Damage { get; set; }

		public virtual int AnnaVahinko()
		{
			return Damage;
		}
		public abstract void OtaVahinkoa(int määrä);

		public abstract int AnnaRahaa();
	}

	internal class Goblin : Hirviö
	{
		public Goblin() 
		{
			this.Osumapisteet = 10;
			this.MaxOsumapisteet = this.Osumapisteet;
			this.Nimi = "Goblin";
			this.Damage = 1;
		}

		public override int AnnaVahinko()
		{
			return base.AnnaVahinko();
		}

        public override void OtaVahinkoa(int määrä)
		{
            Osumapisteet -= määrä;
        }

        public override int AnnaRahaa()
        {
            Random rnd = new Random();
			return rnd.Next(5, 10);
        }
    }
}
