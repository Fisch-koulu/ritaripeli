using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritaripeli
{
	internal class Ritari
	{
		public int Osumapisteet {  get; private set; }
		public Lompakko Rahapussi { get; private set; }
		// TODO private Reppu reppu;
		public Reppu PelaajanReppu { get; private set; }

		public Ritari(int aloitusOsumapisteet, int aloitusRahat)
		{
			Osumapisteet = aloitusOsumapisteet;
			Rahapussi = new Lompakko(aloitusRahat);
			// TODO luo tyhjä Reppu
			PelaajanReppu = new Reppu();
		}

		public void OtaVahinkoa(int määrä)
		{
			Osumapisteet -= määrä;
		}

		public void SaaHipaa(int määrä)
		{
			Osumapisteet += määrä;
		}

	}
}
