﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicAr
{
    internal class Disco
    {
        public string Titulo { get; set; }
        public int CantidadCanciones { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string UrlImagenTapa { get; set; }
        public Elemento Estilo { get; set; }
        public Elemento TipoEdicion { get; set; }
    }
}
