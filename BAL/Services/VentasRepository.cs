﻿using BAL.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class VentasRepository : IVentasRepository, IDisposable
    {
        private readonly Contexto contexto;
        public VentasRepository(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        //IMPLEMENTACIÓN DEL MÉTODO LISTAR
        public List<tabVentas> ListarVentas()
        {
            var listaVentas = contexto.tabVentas.ToList();
            return listaVentas;
        }
        //IMPLEMENTACIÓN DEL MÉTODO Obtener ID Venta
        public tabVentas ObtenerVentaPorID(int id)
        {
            var ventaEncontrada = contexto.tabVentas.FirstOrDefault(v => v.idVenta == id);
            return ventaEncontrada;
        }

        public void AgregarVentas(tabVentas venta)
        {
            contexto.Entry(venta).State = EntityState.Added;
            contexto.SaveChanges();
            
        }

        public void ActualizarVentas(tabVentas venta)
        {
            contexto.Entry(venta).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void EliminarVentas(int id)
        {
            var model = ObtenerVentaPorID(id);

            if(model != null)
            {
                contexto.Entry(model).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
