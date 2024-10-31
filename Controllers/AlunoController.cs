using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AppSaresp_2024.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public IActionResult Index()
        {
            var alunos = _alunoRepository.ObterTodosAlunos();
            return View(alunos);
        }

        [HttpGet]
        public IActionResult CadastrarAluno()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarAluno(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _alunoRepository.Cadastrar(aluno);
            }

            return View();
        }
    }
}
