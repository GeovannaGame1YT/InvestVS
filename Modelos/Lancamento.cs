using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest_VS.Modelos
{
    public class Lancamento
    {
        public String Sigla { get; set; }

        public String Tipo { get; set; }
        public Decimal Valor { get; set; }

        public DateTime Data_movimento { get; set; }

        public Decimal Acrescimos { get; set; }
        public int Usuario { get; set; }
        public int Quantidade { get; set; }

    }
}
