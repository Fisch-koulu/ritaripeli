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
}
