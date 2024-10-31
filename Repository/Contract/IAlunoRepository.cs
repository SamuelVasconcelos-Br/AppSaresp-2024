using AppSaresp_2024.Models;

namespace AppSaresp_2024.Repository.Contract
{
    public interface IAlunoRepository
    {
        IEnumerable<Aluno> ObterTodosAlunos();
        void Cadastrar(Aluno aluno);
    }
}
