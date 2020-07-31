using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ControleDePatrimonios.Models
{
    public class MarcaDAO
    {
        public List<Marca> FindAll()
        {
            // SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            // SqlConnection connection = new SqlConnection();

            List<Marca> marca = new List<Marca>();
            marca.Add(new Marca { MarcaId = 1, Nome = "Teste do nome" });
            marca.Add(new Marca { MarcaId = 2, Nome = "Teste do nome 2" });

            return marca;
        }

        public void Insert(Marca marca)
        {
            // Implementar
        }

        public Marca FindById(int id)
        {
            return new Marca(); // Implementar busca ao invez de criar um novo
        }

        public void Remove(int id)
        {
            Remove(FindById(id));
        }

        public void Remove(Marca marca)
        {
            // Implementar remoção por objeto
        }
    }
}
