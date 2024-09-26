﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clases
{
    public class Subasta : Publicacion
    {
        #region PROPERTYS
        public List<Oferta> _listaOfertas { get; set; } = new List<Oferta>();
        #endregion
        #region CONSTRUCTORES
        public Subasta()
        {
            
        }

        public Subasta(List<Oferta> listaOfertas, string Nombre, Estado Estado, DateTime FechaPublicacion)
            : base(Nombre, Estado, FechaPublicacion)
        {
            _listaOfertas = listaOfertas;
           
        }
        #endregion
    }
}