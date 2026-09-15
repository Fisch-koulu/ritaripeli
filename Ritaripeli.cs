using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritaripeli
{
	internal class Ritaripeli
	{
		Ritari pelaaja;
		List<Hirviö> hirviot;
		List<IKauppa> kaupat;
		Reppu reppu;
		int voitto = 50;
		
		public Ritaripeli()
		{
			pelaaja = new Ritari(aloitusOsumapisteet: 10, aloitusRahat: 10);
			hirviot = new List<Hirviö>();
			// TODO luo erilaiset hirviöt
			kaupat = new List<IKauppa>();
			// TODO luo erilaiset kaupat
			NuoliKauppa nuoliKauppa = new NuoliKauppa();
			kaupat.Add(nuoliKauppa);
			// luo pelaajan reppu
			reppu = new Reppu();
			reppu.YritäLisaa(new Jousi());
		}

		public void PeliSilmukka()
		{
			Print.Line("Tervetuloa suureen seikkailuun!");
			while (true)
			{

				// TODO näytä pelaajan tilanne
				Print.WriteColor("Tilanne: Osumapisteitä: ", ConsoleColor.White);
				Print.WriteColor($"{pelaaja.Osumapisteet} op ", ConsoleColor.Green);
				Print.WriteColor("Kultaa: ", ConsoleColor.White);
				Print.LineColor($"{pelaaja.Rahapussi.Rahoja} kr", ConsoleColor.Yellow);
				// TODO anna pelaajan valita meneekö kauppaan vai taistelemaan vai käyttääkö tavaroita Repusta
				//pelaaja valitsee
				int valinta = Valitse(1, 4, 
					"Valitse toiminto:" +
                    "\r\n1 Mene nuolikauppaan" +
                    "\r\n2 Mene ravintolaan" +
                    "\r\n3 Lähde taisteluun" +
                    "\r\n4 Käytä repussa olevia esineitä") - 1;

				//pelaaja on valinnut 1-4
				if (valinta <= 1)
				{
					KauppaTila(kaupat[valinta]);
				}
				else if (valinta == 2)
				{
					TaisteluTila();
				}
				else
				{
					ReppuTila();
				}

				// Tarkista onko peli päättynyt
				if (pelaaja.Osumapisteet <= 0 || pelaaja.Rahapussi.Rahoja >= voitto)
				{
					break;
				}
			}
			//jotain tekstiä
		}

		public void TaisteluTila()
		{
			// TODO arvo pelaajaa vastaan taisteleva hirviö
			Hirviö vastustaja = new Goblin();
			while (vastustaja.Osumapisteet > 0 && pelaaja.Osumapisteet > 0)
			{
				int valinta = Valitse(1, 3, 
						"Valitse toiminto:" +
                        "\r\n1 Hyökkää" +
                        "\r\n2 Käytä esineitä" +
                        "\r\n3 Pakene");
				switch (valinta)
				{
				// TODO anna pelaajan valita toiminto:
					case 1:
					// 1. hyökkää : aiheuta vahinkoa hirviölle
						vastustaja.OtaVahinkoa(valinta);
						break;
					case 2:
					// 2. käytä esinettä ; näytä Repun sisältö ja anna pelaajan valita tavara
					// Jos pelaaja käyttää ruoka-annosta, lisää pelaajan osumapisteitä
					// Jos pelaaja käyttää nuolta, ammu nuoli kohti vihollista
					// Jos pelaaja käyttää jotain muuta tavaraa, toimi valinnan mukaan
						break;
					case 3:
					// 3. pakene : poistu TaisteluTilasta
						Console.WriteLine("Pakenet taistelusta.");
						return;
				}

				// TODO Jos hirviöllä on osumapisteitä jäljellä
				if (vastustaja.Osumapisteet > 0)
				{
					// arvo hirviön tekemä vahinko ja vähennä se pelaajan osumapisteistä
					pelaaja.OtaVahinkoa(vastustaja.AnnaVahinko());
					Console.WriteLine($"{vastustaja.Nimi} aiheutti sinulle {vastustaja.AnnaVahinko}");
				}
			}
			// Kun taistelu loppuu, palaa PeliSilmukkaan
		}

		public void KauppaTila(IKauppa kauppa)
		{
			// TODO anna pelaajan valita mihin kauppaan pelaaja menee

			while (true)
			{
				// listaa kaupan tavarat ja anna pelaajan valita minkä hän haluaa
				int kauppaValinta = Valitse(1, 4, 
						"Valitse toiminto:" +
                        "\r\n1 Osta mittatilausnuoli" +
                        "\r\n2 Listaa kaupan tavarat" +
                        "\r\n3 Osta tavara" +
                        "\r\n4 Poistu");

				switch (kauppaValinta)
				{
					case 1: break;
					case 2:
						//Listaa tavarat
						kauppa.ListaaTavarat(); break;
					case 3:
						//listaa tavarat varmuuden vuoksi
                        //var Lista = kauppa.ListaaTavarat();
                        kauppaValinta = Valitse(1, kauppa.ListaaTavarat().Count);
                        // yrittää ostaa ja poistuu kaupasta oston tai ei oston jälkeen.
                        kauppa.OstaTavara(kauppaValinta, pelaaja.Rahapussi); return;
					// lisää vaihtoehto jolla pelaaja pääsee pois kaupasta ja Kauppatilasta
					case 4: return; //poistuu kaupasta
				}
			}

		}


		public void ReppuTila()
		{
			// Kerro pelaajalle vaihtoehdot
			// Anna pelaajan valita mitä ottaa repusta
            int valitse = Valitse(1, reppu.ListaaRepunTavarat().Count);
			// Tai voi poistua
			if (valitse >= reppu.ListaaRepunTavarat().Count)
			{
				return;
			}
			reppu.OtaRepunTavara(valitse);
		}


		/// <summary>
		/// tarkistaa, että pelaaja antaa numeron ja numero on vaihtoehto.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <param name="teksti">Toistaa vaihtoehdot. Ei pakollinen.</param>
		/// <param name="virhe">Ei tarvitse kirjoittaa virheviestiä.</param>
		/// <returns></returns>
		public static int Valitse(int min, int max, string? teksti = null, string? virhe = "Vaihtoehto ei käy.")
		{ 
			while (true)
			{
				Console.WriteLine(teksti);
				int valinta;
				if (int.TryParse(Console.ReadLine(), out valinta))
				{
					
					if (valinta >= min && valinta <= max)
					{
						return valinta;
					}
					
				}
				Console.WriteLine(virhe);
			}
		}

		/*public static Tyyppi ValitseEnum<Tyyppi>() where Tyyppi : Enum
		{
			Type enumType = typeof(Tyyppi);
			Console.WriteLine($"Vaihtoehdot {enumType.Name}");
			string[] vaihtoehdot = Enum.GetNames( enumType );
			for (int i =  0; i < vaihtoehdot.Length; i++)
			{
				Console.WriteLine($"{i+1}: {vaihtoehdot[i]}");
			}
			
		}*/
	}
}
