namespace APIProfit.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Entidades;
    using Models;

    public class ArticulosRepositorio : IRepositorio<SaArticulo>
    {
        readonly ConexionAlterna conn = new ConexionAlterna();

        #region Find
        public SaArticulo Find(string key,string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            SaArticulo data = db.SaArticulo.FirstOrDefault(a => a.CoArt == key);
            if (data == null) return null;
            return data;
        }
        #endregion

        #region GetAll
        public IEnumerable<SaArticulo> GetAll(string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            return db.SaArticulo.ToList();
        }
        #endregion

        #region Remove
        public Response Remove(string key, string user,string empresaDB)
        {
            try
            {
                using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

                SaArticulo data = Find(key, empresaDB);
                data.Anulado = true;
                data.FechaInac = DateTime.Now;
                data.CoUsMo = user;
                data.FeUsMo = DateTime.Now;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return new Response { Status = "OK", Message = $"Eliminación del artículo '{data.CoArt.Trim()}' realizada con éxito." };
            }
            catch (Exception ex)
            {
                return new Response { Status = "ERROR", Message = string.Format("{0}", ex.Message) };
            }
        }
        #endregion

        #region Save
        public Response Save(SaArticulo item,string empresaDB)
        {
            try
            {
                using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

                SaArticulo existArticulo = Find(item.CoArt, empresaDB);
                if (existArticulo != null)
                {
                    throw new ArgumentException($"El código del artículo '{item.CoArt.Trim()}' se encuentra registrado.");
                }
                else
                {
                    db.Entry(item).State = EntityState.Added;
                    db.SaveChanges();

                    /*Insertar articulo caracteristica*/
                    insertArtCaracteristicas(item, empresaDB);
                    /*///////////////////////////////*/

                    return new Response { Status = "OK", Message = $"Se ha registrado el artículo ID: [{item.CoArt.Trim()}]" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Status = "ERROR", Message = string.Format("{0}", ex.Message) };
            }
        }
        #endregion

        #region Update
        public Response Update(SaArticulo item,string empresaDB)
        {
            try
            {
                using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return new Response { Status = "OK", Message = "Actualización realizada con éxito." };
            }
            catch (Exception ex)
            {
                return new Response { Status = "ERROR", Message = string.Format("{0}", ex.Message) };
            }
        }
        #endregion

        #region Articulo con sus caracteristicas
        private void insertArtCaracteristicas(SaArticulo item,string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

            SaArtCaracteristica articuloC = new SaArtCaracteristica();
            articuloC.CoArt = item.CoArt;
            articuloC.CoUsIn = item.CoUsIn;
            articuloC.FeUsIn = item.FeUsIn;
            articuloC.CoUsMo = item.CoUsMo;
            articuloC.FeUsMo = item.FeUsMo;
            articuloC.SinDerCreFis = false;
            articuloC.CreditoFiscal = 1;
            db.Entry(articuloC).State = EntityState.Added;
            db.SaveChanges();
        }
        #endregion

    }
}