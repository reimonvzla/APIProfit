﻿namespace APIProfit.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Entidades;
    using Models;

    public class CondicionesPagosRepositorio : IRepositorio<SaCondicionPago>
    {
        readonly ConexionAlterna conn = new ConexionAlterna();

        #region Find
        public SaCondicionPago Find(string key, string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            return db.SaCondicionPago.FirstOrDefault(cp => cp.CoCond.Trim() == key.Trim());
        } 
        #endregion

        #region GetAll
        public IEnumerable<SaCondicionPago> GetAll(string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            return db.SaCondicionPago.ToList();
        }
        #endregion

        #region Remove
        public Response Remove(string key, string user, string empresaDB)
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region Save
        public Response Save(SaCondicionPago item, string empresaDB)
        {
            try
            {
                using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
                db.Entry(item).State = EntityState.Added;
                db.SaveChanges();
                return new Response { Status = "OK", Message = "Transacción realizada con éxito." };
            }
            catch (Exception ex)
            {
                return new Response { Status = "ERROR", Message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message };
            }
        } 
        #endregion

        #region Update
        public Response Update(SaCondicionPago item, string empresaDB)
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
                return new Response { Status = "ERROR", Message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message };
            }
        } 
        #endregion
    }
}
