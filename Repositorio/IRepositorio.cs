namespace APIProfit.Repositorio
{
    using System.Collections.Generic;
    using Entidades;

    interface IRepositorio<T> where T: class
    {
        IEnumerable<T> GetAll(string empresaDB);
        T Find(string key, string empresaDB);
        Response Save(T item, string empresaDB);
        Response Remove(string key, string user, string empresaDB);
        Response Update(T item, string empresaDB);
    }
}
