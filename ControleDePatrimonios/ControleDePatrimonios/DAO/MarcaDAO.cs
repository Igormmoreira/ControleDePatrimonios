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
        private string ConStr = @"Data Source=DESKTOP-S6B4635\SQLEXPRESS;Initial Catalog=PatrimonioDB;Integrated Security=True";

        private SqlDataAdapter ExecuteSQL(string query)
        {
            //new SqlConnection(ConfigurationManager.ConnectionStrings["PatrimonioDB"].ConnectionString);
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(ConStr);
            SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            return new SqlDataAdapter(command);
        }

        public List<Marca> FindAll()
        {
            List<Marca> marca = new List<Marca>();

            SqlDataAdapter dataAdapter = ExecuteSQL(" SELECT * FROM MARCAS ");
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

        public Marca Insert(Marca marca)
        {
            string sql = " INSERT INTO MARCAS(NOME) VALUES('" + marca.Nome + "') ";

            SqlDataAdapter dataAdapter = ExecuteSQL(sql);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            return LastInserted();
            // Tratar exceção UNIQUE no nome da marca
            // SqlException: Violação da restrição UNIQUE KEY 'UQ__MARCAS__E2AB1FF41D19ADD2'. Não é possível inserir a chave duplicada no objeto 'dbo.MARCAS'. O valor de chave duplicada é (Daisy).
        }

        public Marca FindById(int chave)
        {
            Marca marca = new Marca();

            SqlDataAdapter dataAdapter = ExecuteSQL(" SELECT * FROM MARCAS WHERE MARCAS.ID = " + chave);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            
            // Não é assim que pega os dados do dataset
            //marca.MarcaId = int.Parse(table.Rows.DataRow["ID"].ToString());
            //marca.Nome = table.Columns["NOME"].ToString();

            foreach (DataRow linha in table.Rows)
            {
                marca.MarcaId = int.Parse(linha["ID"].ToString());
                marca.Nome = linha["NOME"].ToString();
            }

            return marca;
        }

        public void Remove(int id)
        {
            Remove(FindById(id));
        }

        public void Remove(Marca marca)
        {
            string sql = " DELETE FROM MARCAS WHERE MARCAS.ID = " + marca.MarcaId;

            SqlDataAdapter dataAdapter = ExecuteSQL(sql);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
        }

        public void Update(Marca marca)
        {
            string sql = string.Format( "  UPDATE MARCAS        " +
                                        "     SET NOME = '{0}'  " +
                                        "   WHERE ID = {1}      ",
                                        marca.Nome, marca.MarcaId);

            SqlDataAdapter dataAdapter = ExecuteSQL(sql);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
        }

        public Marca LastInserted()
        {
            Marca marca = new Marca();

            string sql = " SELECT * FROM MARCAS WHERE MARCAS.ID = (SELECT MAX(MARCAS.ID) FROM MARCAS) ";

            SqlDataAdapter dataAdapter = ExecuteSQL(sql);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            foreach (DataRow linha in table.Rows)
            {
                marca.MarcaId = int.Parse(linha["ID"].ToString());
                marca.Nome = linha["NOME"].ToString();
            }

            return marca;
        }
    }
}
