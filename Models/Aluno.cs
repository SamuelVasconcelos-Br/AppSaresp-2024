using System.ComponentModel.DataAnnotations;

namespace AppSaresp_2024.Models
{
    public class Aluno
    {
        [Display(Name = "ID do Aluno")]
        public int IdAluno { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [StringLength(200, ErrorMessage = "O email deve ter no máximo 200 caracteres.")]
        [EmailAddress(ErrorMessage = "O email deve ser válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(12, ErrorMessage = "O telefone deve ter no máximo 12 caracteres.")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A série é obrigatória.")]
        [StringLength(200, ErrorMessage = "A série deve ter no máximo 200 caracteres.")]
        [Display(Name = "Série")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "A turma é obrigatória.")]
        [StringLength(50, ErrorMessage = "A turma deve ter no máximo 50 caracteres.")]
        [Display(Name = "Turma")]
        public string Turma { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }
    }
}

