using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AppSaresp_2024.Controllers
{
    public class ProfessorAplicadorController : Controller
    {
        private readonly IProfessorAplicadorRepository _professorAplicadorRepository;

        public ProfessorAplicadorController(IProfessorAplicadorRepository professorAplicadorRepository)
        {
            _professorAplicadorRepository = professorAplicadorRepository;
        }

        public IActionResult Index()
        {
            var professores = _professorAplicadorRepository.ObterTodosProfessores(); 
            return View(professores);
        }

        [HttpGet]
        public IActionResult CadastrarProfessor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarProfessor(ProfessorAplicador professor)
        {
            if (ModelState.IsValid)
            {
                _professorAplicadorRepository.Cadastrar(professor);
            }

            return View();
        }
    }
}
