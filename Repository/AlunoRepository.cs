using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using MySql.Data.MySqlClient;

namespace AppSaresp_2024.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _conexaoMySQL;

        public AlunoRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("conexaoMySQL");
        }

        public void Cadastrar(Aluno aluno)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into aluno(Nome, Email, Telefone, Serie, Turma, DataNasc) values(@Nome, @Email, @Telefone, @Serie, @Turma, @DataNasc)", conexao);

                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = aluno.Nome;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = aluno.Email;
                cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = decimal.Parse(aluno.Telefone);
                cmd.Parameters.Add("@Serie", MySqlDbType.VarChar).Value = aluno.Serie;
                cmd.Parameters.Add("@Turma", MySqlDbType.VarChar).Value = aluno.Turma;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.DateTime).Value = aluno.DataNasc;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<Aluno> ObterTodosAlunos()
        {
            var alunos = new List<Aluno>();

            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM aluno", conexao);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var aluno = new Aluno
                        {
                            IdAluno= reader.GetInt32("IdAluno"),
                            Nome = reader.GetString("Nome"),
                            Email = reader.GetString("Email"),
                            Telefone = reader.GetDecimal("Telefone").ToString("0"),
                            Serie = reader.GetString("Serie"),
                            Turma = reader.GetString("Turma"),
                            DataNasc = reader.GetDateTime("DataNasc")
                        };

                        alunos.Add(aluno);
                    }
                }

                conexao.Close();
            }

            return alunos;
        }
    }
}

