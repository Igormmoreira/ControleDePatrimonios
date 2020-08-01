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
            List<Marca> marca = new List<Marca>();
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(@"Data Source=DESKTOP-S6B4635\SQLEXPRESS;Initial Catalog=PatrimonioDB;Integrated Security=True");
            SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

            // SqlConnection connection = new SqlConnection(@"Data Source = DESKTOP - S6B4635\SQLEXPRESS; Initial Catalog = PatrimonioDB; Integrated Security = True");

            //new SqlConnection(ConfigurationManager.ConnectionStrings["PatrimonioDB"].ConnectionString);

            SqlCommand command = new SqlCommand(" SELECT * FROM MARCAS ", connection);
            connection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            foreach (DataRow linha in table.Rows)
            {
                int id = int.Parse(linha["ID"].ToString());
                string nome = linha["NOME"].ToString();

                marca.Add(new Marca { MarcaId = id, Nome = nome });
            }
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
