﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Venta : Publicacion    
    {
        #region PROPERTYS
        public bool OfertaRelampago { get; set; }
        public double PrecioVenta { get; set; }
        #endregion

        #region CONSTRUCTORES
        public Venta()
        {
            
        }

        public Venta(bool ofertaRelampago, double precioVenta, string Nombre, Estado Estado, DateTime FechaPublicacion)
            : base(Nombre, Estado, FechaPublicacion)
        {
            OfertaRelampago = ofertaRelampago;
            PrecioVenta = precioVenta;
            Validar();
            
        }

        private void CalcularPrecio()
        {
            double precioAux = 0;

            foreach (Articulo a in _listaArticulos)
            {
                precioAux += a.Precio;
            }


         validarOfertaRelampago(precioAux);
            

        }

        private void validarOfertaRelampago(double precioAux)
        {
            if (OfertaRelampago)
            {
                PrecioVenta = precioAux * 0.8;
            }
            else 
            {
                PrecioVenta = precioAux;
            }

        }
        #endregion

        private void Validar()
        {
          //Este Metodo de ValidarSaldoParaVenta no se tendria que correr al momento que un usuario quiera hacer una compra?
          //Dejo este metodo comentado ->
          //  ValidarSaldoParaVenta();
        }

        private void ValidarSaldoParaVenta()
        {
            if (ClienteCompra.Saldo < PrecioVenta)
            {
                throw new Exception("No tiene saldo para realizar la compra de la publicacion");
            }
        }
        public void AgregarArticulo(Articulo articulo)
        {
            try
            {
                articulo.Validar();
                _listaArticulos.Add(articulo);
                CalcularPrecio();
            }
            catch (Exception e) {
                throw;
            }
        }

        public override void CerrarPublicacion()
        {
            if (Estado == Estado.Abierta)
            {
                    try
                    {

            
                    ValidarSaldoParaVenta();
                    Estado = Estado.Cerrada;
                
                    FechaCompra = DateTime.Now;
            

                    }
                catch (Exception e)
                    {

                    throw;
                    }
            }


    }
    }
}
