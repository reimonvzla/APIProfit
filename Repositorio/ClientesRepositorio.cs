namespace APIProfit.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Entidades;
    using Models;

    public class ClientesRepositorio : IRepositorio<SaCliente>
    {
        readonly ConexionAlterna conn = new ConexionAlterna();

        #region Find
        public SaCliente Find(string key,string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            SaCliente data = db.SaCliente.FirstOrDefault(c => c.CoCli == key);
            if (data == null) return null;
            return data;
        }
        #endregion

        #region GetAll
        public IEnumerable<SaCliente> GetAll(string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            List<SaCliente> cli = new List<SaCliente>();
            var Qry = db.SaCliente.ToList();
            foreach (var iCliente in Qry)
            {
                cli.Add(new SaCliente
                {
                    #region Campos
                    CoCli = iCliente.CoCli,
                    TipCli = iCliente.TipCli,
                    CliDes = iCliente.CliDes,
                    Direc1 = iCliente.Direc1,
                    DirEnt2 = iCliente.DirEnt2,
                    Direc2 = iCliente.Direc2,
                    Telefonos = iCliente.Telefonos,
                    Fax = iCliente.Fax,
                    Inactivo = iCliente.Inactivo,
                    Comentario = iCliente.Comentario,
                    Respons = iCliente.Respons,
                    FechaReg = iCliente.FechaReg,
                    Puntaje = iCliente.Puntaje,
                    MontCre = iCliente.MontCre,
                    CoMone = iCliente.CoMone,
                    CondPag = iCliente.CondPag,
                    PlazPag = iCliente.PlazPag,
                    DescPpago = iCliente.DescPpago,
                    CoZon = iCliente.CoZon,
                    CoSeg = iCliente.CoSeg,
                    CoVen = iCliente.CoVen,
                    DescGlob = iCliente.DescGlob,
                    HorarCaja = iCliente.HorarCaja,
                    FrecuVist = iCliente.FrecuVist,
                    Lunes = iCliente.Lunes,
                    Martes = iCliente.Martes,
                    Miercoles = iCliente.Miercoles,
                    Jueves = iCliente.Jueves,
                    Viernes = iCliente.Viernes,
                    Sabado = iCliente.Sabado,
                    Domingo = iCliente.Domingo,
                    Rif = iCliente.Rif,
                    Nit = iCliente.Nit,
                    Contrib = iCliente.Contrib,
                    Numcom = iCliente.Numcom,
                    Feccom = iCliente.Feccom,
                    DisCen = iCliente.DisCen,
                    Email = iCliente.Email,
                    CoCtaIngrEgr = iCliente.CoCtaIngrEgr,
                    Juridico = iCliente.Juridico,
                    TipoAdi = iCliente.TipoAdi,
                    Matriz = iCliente.Matriz,
                    CoTab = iCliente.CoTab,
                    TipoPer = iCliente.TipoPer,
                    Valido = iCliente.Valido,
                    Ciudad = iCliente.Ciudad,
                    Zip = iCliente.Zip,
                    Login = iCliente.Login,
                    Password = iCliente.Password,
                    Website = iCliente.Website,
                    Sincredito = iCliente.Sincredito,
                    ContribuE = iCliente.ContribuE,
                    ReteRegisDoc = iCliente.ReteRegisDoc,
                    PorcEsp = iCliente.PorcEsp,
                    CoPais = iCliente.CoPais,
                    Serialp = iCliente.Serialp,
                    Id = iCliente.Id,
                    Salestax = iCliente.Salestax,
                    Estado = iCliente.Estado,
                    Campo1 = iCliente.Campo1,
                    Campo2 = iCliente.Campo2,
                    Campo3 = iCliente.Campo3,
                    Campo4 = iCliente.Campo4,
                    Campo5 = iCliente.Campo5,
                    Campo6 = iCliente.Campo6,
                    Campo7 = iCliente.Campo7,
                    Campo8 = iCliente.Campo8,
                    CoUsIn = iCliente.CoUsIn,
                    FeUsIn = iCliente.FeUsIn,
                    CoSucuIn = iCliente.CoSucuIn,
                    CoUsMo = iCliente.CoUsMo,
                    FeUsMo = iCliente.FeUsMo,
                    CoSucuMo = iCliente.CoSucuMo,
                    Revisado = iCliente.Revisado,
                    Trasnfe = iCliente.Trasnfe,
                    Validador = iCliente.Validador,
                    EmailAlterno = iCliente.EmailAlterno 
                    #endregion
                });
            }
            return cli;
        }
        #endregion

        #region Remove
        public Response Remove(string key, string user, string empresaDB)
        {
            try
            {
                using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

                SaCliente data = Find(key, empresaDB);
                data.Inactivo = true;
                data.CoUsMo = user;
                data.FeUsMo = DateTime.Now;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return new Response { Status = "OK", Message = $"Eliminación del cliente '{data.CoCli.Trim()}' realizada con éxito." };
            }
            catch (Exception ex)
            {
                return new Response { Status = "ERROR", Message = string.Format("{0}", ex.Message) };
            }
        }
        #endregion

        #region Save
        public Response Save(SaCliente item,string empresaDB)
        {
            try
            {
                using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

                SaCliente existCliente = Find(item.CoCli,empresaDB);
                if (existCliente != null)
                {
                    throw new ArgumentException($"El codigo cliente '{item.CoCli.Trim()}' se encuentra registrado.");
                }
                else
                {

                    db.Entry(item).State = EntityState.Added;
                    db.SaveChanges();
                    return new Response { Status = "OK", Message = $"Se ha registrado el cliente ID: [{item.CoCli.Trim()}]" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Status = "ERROR", Message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message };
            }
        }
        #endregion

        #region Update
        public Response Update(SaCliente item,string empresaDB)
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

        #region Cuentas de Ingreso/Egreso
        public IEnumerable<SaCuentaIngEgr>GetAllCtaIngrEgre(string empresaDB)
        {
            return new Utilitarios().GetAllCtaIngrEgre(empresaDB);
        }
        #endregion

        #region Tipo Cliente
        public IEnumerable<SaTipoCliente> GetAllTipoCliente(string empresaDB)
        {
            return new Utilitarios().GetAllTipoCliente(empresaDB);
        }
        #endregion

        #region GetAllSegmentos
        public IEnumerable<SaSegmento> GetAllSegmentos(string empresaDB)
        {
            return new Utilitarios().GetAllSegmentos(empresaDB);
        }
        #endregion

        #region GetAllZonas
        public IEnumerable<SaZona> GetAllZonas(string empresaDB)
        {
            return new Utilitarios().GetAllZonas(empresaDB);
        } 
        #endregion

    }
}
