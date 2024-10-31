using AppSaresp_2024.Models;

namespace AppSaresp_2024.Repository.Contract
{
    public interface IProfessorAplicadorRepository
    {
        IEnumerable<ProfessorAplicador> ObterTodosProfessores();
        void Cadastrar(ProfessorAplicador professor);
    }
}
