namespace APIProfit.Repositorio
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Entidades;
    using Models;

    public class Utilitarios
    {
        readonly ConexionAlterna cone = new ConexionAlterna();

        #region GetEmpresas (MasterProfitPro)
        public IEnumerable<Empresa> GetEmpresas()
        {
            ProfitAdmin2K12 db = new ProfitAdmin2K12();
            List<Empresa> empresas = new List<Empresa>();

            using (var command = db.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = "SELECT * FROM MasterProfitPro.dbo.MpEmpresa";
                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            empresas.Add(new Empresa
                            {
                                CodEmpresa = result.GetString(0),
                                DescEmpresa = result.GetString(1),
                                Rif = result.GetString(5),
                                Producto = result.GetString(8)
                            });
                        }
                    }
                    //result.Close();
                }
                command.Connection.Close();
            }
            return empresas;
        } 
        #endregion

        #region Consulta a la tabla saConsecutivoTipo para saber si el campo UsoSucursal se encuentra encendido.
        public UsoSucursalConsecutivoTipo GetUsoSucursalConsecutivoTipo(string codigoConsecutivo,string empresaDB)
        {

            UsoSucursalConsecutivoTipo row = new UsoSucursalConsecutivoTipo();
            using var db = new ProfitAdmin2K12(cone.GetDbContextOptions(empresaDB));

            var conn = db.Database.GetDbConnection();
            conn.Open();
            var command = conn.CreateCommand();
            string query = $"EXEC pSeleccionarUsoSucursalConsecutivoTipo @sCo_Consecutivo={codigoConsecutivo}";
            command.CommandText = query;
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                row.UsoSucursal = reader.GetBoolean(0);
                row.maneja_sucursal = reader.GetBoolean(0);
            }
            reader.Close();
            conn.Close();

            return row;
        }
        #endregion

        #region GetNumero
        public string GetProximoNumero(string codigoConsecutivo, string codigoSucursal,string empresaDB)
        {
            string proximoConsecutivo = "";
            var usaSucursal = GetUsoSucursalConsecutivoTipo(codigoConsecutivo, empresaDB).UsoSucursal;

            /*Esta propiedad no pertenece al esquema de la base de datos si a un alias creado dentro del sp q se invoca. (Se agregó al modelo)*/
            var manejaSucursal = GetUsoSucursalConsecutivoTipo(codigoConsecutivo, empresaDB).maneja_sucursal;

            if (usaSucursal && manejaSucursal)
            {
                proximoConsecutivo = GetProximoConsecutivo(codigoConsecutivo, codigoSucursal, empresaDB);
            }
            return proximoConsecutivo;
        }
        #endregion

        #region Obtiene el próximo consecutivo de la serie en una sucursal.
        public string GetProximoConsecutivo(string codigoConsecutivo, string codigoSucursal,string empresaDB)
        {
            using var db = new ProfitAdmin2K12(cone.GetDbContextOptions(empresaDB));

            string valor = "";
            var conn = db.Database.GetDbConnection();
            conn.Open();
            var command = conn.CreateCommand();
            string query = $"EXEC pConsecutivoProximo @sCo_Consecutivo='{codigoConsecutivo.Trim()}',@sCo_Sucur='{codigoSucursal.Trim()}'";
            command.CommandText = query;
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                valor = reader.GetString(0);
            }
            reader.Close();
            conn.Close();
            return valor;
        }
        #endregion

        #region Verificar moneda
        public SaMoneda GetMoneda(string codMoneda, string empresaDB)
        {
            using var db = new ProfitAdmin2K12(cone.GetDbContextOptions(empresaDB));

            SaMoneda moneda = db.SaMoneda.FirstOrDefault(m => m.CoMone.Trim() == codMoneda.Trim());
            if (moneda == null)
            {
                throw new ArgumentException($"La moneda indicada {codMoneda.Trim()} no existe.");
            }
            return moneda;
        }
        #endregion

        #region Verificar unidad primaria
        public SaUnidad GetUnidadPrimaria(string codUnidad, string empresaDB)
        {
            using var db = new ProfitAdmin2K12(cone.GetDbContextOptions(empresaDB));
            SaUnidad unidad = db.SaUnidad.FirstOrDefault(u => u.CoUni.Trim() == codUnidad.Trim());
            if (unidad == null)
            {
                throw new ArgumentException($"La unidad primaria {codUnidad.Trim()} no existe.");
            }
            return unidad;
        }
        #endregion

        #region Lista Cta Ingreso/Egreso
        public List<SaCuentaIngEgr>GetAllCtaIngrEgre(string empresaDB)
        {
            using var db = new ProfitAdmin2K12(cone.GetDbContextOptions(empresaDB));
            return db.SaCuentaIngEgr.ToList();
        }
        #endregion

        #region Lista Tipo Cliente
        public IEnumerable<SaTipoCliente>GetAllTipoCliente(string empresaDB)
        {
            using var db = new ProfitAdmin2K12(cone.GetDbContextOptions(empresaDB));
            return db.SaTipoCliente.ToList();
        }
        #endregion

        #region Lista de Segmentos
        public IEnumerable<SaSegmento> GetAllSegmentos(string empresaDB)
        {
            using var db = new ProfitAdmin2K12(cone.GetDbContextOptions(empresaDB));
            return db.SaSegmento.ToList();
        }
        #endregion

        #region Lista de Zonas
        public IEnumerable<SaZona> GetAllZonas(string empresaDB)
        {
            using var db = new ProfitAdmin2K12(cone.GetDbContextOptions(empresaDB));
            return db.SaZona.ToList();
        }
        #endregion

    }
}
