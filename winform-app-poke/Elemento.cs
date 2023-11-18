using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app_poke
{
    internal class Elemento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        //Hago un override del metodo ToString() para que el DGV me devuelva el Tipo como Descripcion
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
