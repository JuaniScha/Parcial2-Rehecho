using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Resultado
    {
        public bool Ok { get; set; }
        public string Error { get; set; }
        public string Codigo { get; set; }

        public Resultado(string cod, bool ok)
        {
            this.Ok = ok;
            this.Codigo = cod;
        }

        public Resultado(bool ok, string error)
        {
            this.Ok = ok;
            this.Error = error;
        }
    }   
}
