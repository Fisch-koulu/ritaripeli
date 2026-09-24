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
		int voitto = 50;
		
		public Ritaripeli()
		{
			pelaaja = new Ritari(aloitusOsumapisteet: 10, aloitusRahat: 10);
			hirviot = new List<Hirviö>();
			// TODO luo erilaiset hirviöt


			kaupat = new List<IKauppa>();
			// TODO luo erilaiset kaupat
			NuoliKauppa nuoliKauppa = new NuoliKauppa();
			RuokaKauppa ruokaKauppa = new RuokaKauppa();
			kaupat.Add(nuoliKauppa);
			kaupat.Add(ruokaKauppa);
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
					KäytäTavaraa(ReppuTila());
				}

				// Tarkista onko peli päättynyt
				if (pelaaja.Osumapisteet <= 0 || pelaaja.Rahapussi.Rahoja >= voitto)
				{
					break;
				}
			}
			if (pelaaja.Rahapussi.Rahoja >= voitto)
			{
				Print.LineColor("Voitit pelin :D", ConsoleColor.Yellow);
			}
			else
			{
				Print.LineColor("Hävisit pelin :(", ConsoleColor.Red);
			}
		}

		public void TaisteluTila()
		{
			// TODO arvo pelaajaa vastaan taisteleva hirviö
			Hirviö vastustaja = new Goblin();
			//kertoo minkä vastustajan kohtaa
			Console.WriteLine($"Kohtaat {vastustaja.Nimi} hirviön.");

			while (vastustaja.Osumapisteet > 0 && pelaaja.Osumapisteet > 0)
			{
				//pelaajan ja vastustajan osumapiste tilanne
				Print.WriteColor("Oma op:", ConsoleColor.White);
				//TODO: tee muuttuja jolla on max osumapiste arvo
				Print.WriteColor($" ({pelaaja.Osumapisteet}/10) ", ConsoleColor.Green);
				Print.WriteColor("Vihollinen:", ConsoleColor.White);
				//TODO: tee muuttuja jolla on max osumapiste arvo
				Print.LineColor($" ({vastustaja.Osumapisteet}/{vastustaja.MaxOsumapisteet}) ", ConsoleColor.Red);

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
						//anna ritarille ase. Ase aiheuttaa vahinkoa.
						vastustaja.OtaVahinkoa(5);
						Console.WriteLine($"Ritari aiheutti 10 vahinkoa.");
						break;
					case 2:
						// 2. käytä esinettä ; näytä Repun sisältö ja anna pelaajan valita tavara
						KäytäTavaraa(ReppuTila(), vastustaja);
						// Jos pelaaja käyttää ruoka-annosta, lisää pelaajan osumapisteitä
						// Jos pelaaja käyttää jotain muuta tavaraa, toimi valinnan mukaan
						// ^^en tiedä mitä tarkoittaa
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
					Console.WriteLine($"{vastustaja.Nimi} aiheutti sinulle {vastustaja.AnnaVahinko()} vahinkoa.");
				}
			}
			// Kun taistelu loppuu, palaa PeliSilmukkaan
			if (pelaaja.Osumapisteet >= 0)
			{
				int raha = vastustaja.AnnaRahaa();
				pelaaja.Rahapussi.LisääRahaa(raha);

				Print.WriteColor("Voitit ja sait",ConsoleColor.White);
				Print.WriteColor($" {raha} ",ConsoleColor.Yellow);
				Print.LineColor("kultarahaa.",ConsoleColor.White);
			}
		}

		public void KauppaTila(IKauppa kauppa)
		{
			// TODO anna pelaajan valita mihin kauppaan pelaaja menee

			while (true)
			{
				// listaa kaupan tavarat ja anna pelaajan valita minkä hän haluaa
				int kauppaValinta = Valitse(1, 4, kauppa.ListaaValinnat());

				switch (kauppaValinta)
				{
					case 1: 
						//TODO: anna pelaajan tilata mittatilaus.
						break;
					case 2:
						//Listaa tavarat
						kauppa.ListaaTavarat(); break;
					case 3:
						//listaa tavarat varmuuden vuoksi
                        //var Lista = kauppa.ListaaTavarat();
                        kauppaValinta = Valitse(1, kauppa.ListaaTavarat().Count);
                        // yrittää ostaa ja poistuu kaupasta oston tai ei oston jälkeen.
						pelaaja.PelaajanReppu.YritäLisaa(kauppa.OstaTavara(kauppaValinta, pelaaja.Rahapussi));
						return;
					// lisää vaihtoehto jolla pelaaja pääsee pois kaupasta ja Kauppatilasta
					case 4: return; //poistuu kaupasta
				}
			}

		}

		/// <summary>
		/// Listaa, tarkistaa ja palauttaa tavaran repusta.
		/// </summary>
		/// <returns></returns>
		public Tavara? ReppuTila()
		{
			// Kerro pelaajalle vaihtoehdot
			pelaaja.PelaajanReppu.ListaaRepunTavarat();
			int repunTavara = pelaaja.PelaajanReppu.TavaraList.Count; // reppu.ListaaRepunTavarat().Count;
			// Anna pelaajan valita mitä ottaa repusta
            int valitse = Valitse(1, repunTavara+1);
			// Tai voi poistua
			if (valitse > repunTavara)
			{
				return null;
			}
			//palauta valittu tavara jos ei ollut poistunut
			return pelaaja.PelaajanReppu.OtaRepunTavara(valitse);
		}

		/// <summary>
		/// Käyttää antaman tavaran.
		/// </summary>
		/// <param name="tavara">Antama tavara ja jos ei ole tavaraa, palauta funktio.</param>
		/// <param name="vastustaja">Jos on hirviö, johon yritetään käyttää tavara.</param>
		public void KäytäTavaraa(Tavara? tavara, Hirviö? vastustaja = null)
		{
			//jos ei ole tavaraa, paalaa takaisin
			if (tavara == null) return;

			//yritä käyttää tavaraa
			if (tavara.Vahingoittava) //katsoo onko tavara vahingoittava
			{
				//jos ei ole vastustajaa palauta;
				if (vastustaja == null)
				{
					Print.LineColor("Heitit tavaran pois.", ConsoleColor.White);
					return;
				}

				var vahinko = tavara.Vahinko();
				vastustaja.OtaVahinkoa(vahinko); //vastusja saa vahingon
				//viesti
				Print.WriteColor($"{tavara} aiheuttaa vastustajalle", ConsoleColor.White);
				Print.WriteColor($" {vahinko} ",ConsoleColor.Red);
				Print.WriteColor("vahinkoa.", ConsoleColor.White);
			}
			if (tavara.Parantava) //katsoo onko tavara parantava
			{
				var paranna = tavara.Paranna();
				pelaaja.SaaHipaa(paranna); //pelaaja saa parannuksen
                //viesti
                Print.WriteColor($"Ritari saa", ConsoleColor.White);
                Print.WriteColor($" {paranna} ", ConsoleColor.Green);
                Print.WriteColor("osumapistettä takaisin.", ConsoleColor.White);
            }
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
