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
			this.Osumapisteet = 4;
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
			return rnd.Next(5, 11);
        }
    }

	internal class RatMan : Hirviö
	{
		public RatMan() 
		{
			this.Osumapisteet = 1;
			this.MaxOsumapisteet = this.Osumapisteet;
			this.Nimi = "Rat man";
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
			return rnd.Next(0, 2);
        }
    }

	internal class Skeleton : Hirviö
	{
		public Skeleton() 
		{
			this.Osumapisteet = 6;
			this.MaxOsumapisteet = this.Osumapisteet;
			this.Nimi = "Skeleton";
			this.Damage = 3;
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
			return rnd.Next(10, 14);
        }
    }

	internal class Mimic : Hirviö
	{
		public Mimic() 
		{
			this.Osumapisteet = 12;
			this.MaxOsumapisteet = this.Osumapisteet;
			this.Nimi = "Mimic";
			this.Damage = 5;
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
			return rnd.Next(20, 26);
        }
    }
}
