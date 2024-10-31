using System.ComponentModel.DataAnnotations;

namespace AppSaresp_2024.Models
{
    public class ProfessorAplicador
    {

        [Display(Name = "ID do Professor")]
        public int IdProfessor { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 dígitos.")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O RG é obrigatório.")]
        [StringLength(9, ErrorMessage = "O RG deve ter no máximo 9 dígitos.")]
        [Display(Name = "RG")]
        public string RG { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(12, ErrorMessage = "O telefone deve ter no máximo 12 dígitos.")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }
    }
    }
