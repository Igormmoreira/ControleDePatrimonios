using ControleDePatrimonios.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDePatrimonios.Models
{
    public class PatrimonioDAO
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

        public List<Patrimonio> FindAll()
        {
            string sql =    "       SELECT PATRIMONIOS.ID,                             " +
                            "              PATRIMONIOS.NOME,                           " +
                            "              PATRIMONIOS.DESCRICAO,                      " +
                            "              PATRIMONIOS.NUMEROTOMBO,                    " +
                            "              PATRIMONIOS.IDMARCA,                        " +
                            "              MARCAS.ID ID_FK,                            " +
                            "              MARCAS.NOME NOME_MARCA                      " +
                            "         FROM PATRIMONIOS                                 " +
                            "    LEFT JOIN MARCAS ON PATRIMONIOS.IDMARCA = MARCAS.ID   " ;
            List<Patrimonio> patrimonios = new List<Patrimonio>();

            SqlDataAdapter dataAdapter = ExecuteSQL(sql);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            foreach (DataRow linha in table.Rows)
            {
                int id = int.Parse(linha["ID"].ToString());
                string nome = linha["NOME"].ToString();
                string descricao = linha["DESCRICAO"].ToString();
                int numeroTombo = int.Parse(linha["NUMEROTOMBO"].ToString());

                int marcaId = int.Parse(linha["ID_FK"].ToString());
                string marcaNome = linha["NOME_MARCA"].ToString();

                Marca marca = new Marca { MarcaId = marcaId, Nome = marcaNome };
                patrimonios.Add(new Patrimonio { Id = id, Nome = nome, Descricao = descricao, NumeroTombo = numeroTombo , marca = marca, MarcaID = marcaId });
            }
            return patrimonios;
        }

        public Patrimonio Insert(Patrimonio patrimonio)
        {
            string sql = string.Format(" INSERT INTO PATRIMONIOS(NOME, DESCRICAO, IDMARCA) VALUES('{0}', '{1}', '{2}') ",
                patrimonio.Nome, patrimonio.Descricao, patrimonio.MarcaID);

            SqlDataAdapter dataAdapter = ExecuteSQL(sql);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            return LastInserted();
        }

        public Patrimonio FindById(int id)
        {
            string sql =    "       SELECT PATRIMONIOS.ID,                             " +
                            "              PATRIMONIOS.NOME,                           " +
                            "              PATRIMONIOS.DESCRICAO,                      " +
                            "              PATRIMONIOS.NUMEROTOMBO,                    " +
                            "              PATRIMONIOS.IDMARCA,                        " +
                            "              MARCAS.ID ID_FK,                            " +
                            "              MARCAS.NOME NOME_MARCA                      " +
                            "         FROM PATRIMONIOS                                 " +
                            "    LEFT JOIN MARCAS ON PATRIMONIOS.IDMARCA = MARCAS.ID   " +
                            "        WHERE PATRIMONIOS.ID = " + id;
            // Implementar busca ao invez de criar um novo
            Patrimonio patrimonio = new Patrimonio();

            SqlDataAdapter dataAdapter = ExecuteSQL(sql);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            foreach (DataRow linha in table.Rows)
            {
                int chave = int.Parse(linha["ID"].ToString());
                string nome = linha["NOME"].ToString();
                string descricao = linha["DESCRICAO"].ToString();
                int numeroTombo = int.Parse(linha["NUMEROTOMBO"].ToString());

                int marcaId = int.Parse(linha["ID_FK"].ToString());
                string marcaNome = linha["NOME_MARCA"].ToString();

                Marca marca = new Marca { MarcaId = marcaId, Nome = marcaNome };

                patrimonio.Id = chave;
                patrimonio.Nome = nome;
                patrimonio.Descricao = descricao;
                patrimonio.NumeroTombo = numeroTombo;
                patrimonio.marca = marca;
                patrimonio.MarcaID = marcaId;
            }
            return patrimonio;
        }

        public void Remove(int id)
        {
            Remove(FindById(id));
        }

        public void Remove(Patrimonio patrimonio)
        {
            string sql = " DELETE FROM PATRIMONIOS WHERE PATRIMONIOS.ID = " + patrimonio.Id;

            SqlDataAdapter dataAdapter = ExecuteSQL(sql);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
        }

        public void Update(Patrimonio patrimonio)
        {
            string sql = string.Format( "  UPDATE PATRIMONIOS                                       " +
                                        "     SET NOME = '{0}', DESCRICAO = '{1}', IDMARCA = {2}    " +
                                        "   WHERE ID = {3}                                          ",
                                        patrimonio.Nome, patrimonio.Descricao, patrimonio.MarcaID, patrimonio.Id); 

            SqlDataAdapter dataAdapter = ExecuteSQL(sql);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
        }

        public Patrimonio LastInserted()
        {
            Patrimonio patrimonio = new Patrimonio();

            string sql =    "       SELECT PATRIMONIOS.ID,                             " +
                            "              PATRIMONIOS.NOME,                           " +
                            "              PATRIMONIOS.DESCRICAO,                      " +
                            "              PATRIMONIOS.NUMEROTOMBO,                    " +
                            "              PATRIMONIOS.IDMARCA,                        " +
                            "              MARCAS.ID ID_FK,                            " +
                            "              MARCAS.NOME NOME_MARCA                      " +
                            "         FROM PATRIMONIOS                                 " +
                            "    LEFT JOIN MARCAS ON PATRIMONIOS.IDMARCA = MARCAS.ID   " +
                            "        WHERE PATRIMONIOS.ID =                            " +
                            "      (SELECT MAX(PATRIMONIOS.ID) FROM PATRIMONIOS)       ";

            SqlDataAdapter dataAdapter = ExecuteSQL(sql);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            foreach (DataRow linha in table.Rows)
            {
                int chave = int.Parse(linha["ID"].ToString());
                string nome = linha["NOME"].ToString();
                string descricao = linha["DESCRICAO"].ToString();
                int numeroTombo = int.Parse(linha["NUMEROTOMBO"].ToString());

                int marcaId = int.Parse(linha["ID_FK"].ToString());
                string marcaNome = linha["NOME_MARCA"].ToString();

                Marca marca = new Marca { MarcaId = marcaId, Nome = marcaNome };

                patrimonio.Id = chave;
                patrimonio.Nome = nome;
                patrimonio.Descricao = descricao;
                patrimonio.NumeroTombo = numeroTombo;
                patrimonio.marca = marca;
                patrimonio.MarcaID = marcaId;
            }
            return patrimonio;
        }
    }
}
