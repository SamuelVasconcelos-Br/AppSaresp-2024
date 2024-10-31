using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace AppSaresp_2024.Repository
{
    public class ProfessorAplicadorRepository : IProfessorAplicadorRepository
    {
        private readonly string _conexaoMySQL;

        public ProfessorAplicadorRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("conexaoMySQL");
        }
    
        public void Cadastrar(ProfessorAplicador professor)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into professoraplicador(Nome, CPF, RG, Telefone, DataNasc) values(@Nome, @CPF, @RG, @Telefone, @DataNasc)", conexao); 

                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = professor.Nome;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = decimal.Parse(professor.CPF);
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = decimal.Parse(professor.RG);
                cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = decimal.Parse(professor.Telefone);
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = professor.DataNasc.ToString("yyyy/MM/dd");

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<ProfessorAplicador> ObterTodosProfessores()
        {
            var professores = new List<ProfessorAplicador>();

            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM professoraplicador", conexao);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var professor = new ProfessorAplicador
                        {
                            IdProfessor = reader.GetInt32("IdProfessor"),
                            Nome = reader.GetString("Nome"),

                            
                            CPF = reader.GetDecimal("CPF").ToString("0"), 
                            RG = reader.GetDecimal("RG").ToString("0"),   
                            Telefone = reader.GetDecimal("Telefone").ToString("0"),

                            DataNasc = reader.GetDateTime("DataNasc")
                        };

                        professores.Add(professor);
                    }
                }

                conexao.Close();
            }

            return professores;
        }
    }
}
