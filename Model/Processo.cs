using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebUriel.Model
{
    public class Processo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O número do processo é obrigatório.")]
        [StringLength(200, ErrorMessage = "O número deve ter no máximo 200 caracteres.")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data do processo é obrigatória.")]
        public DateOnly? Data { get; set; }

        [Required(ErrorMessage = "O interessado do processo é obrigatório.")]
        [StringLength(200, ErrorMessage = "O interessado deve ter no máximo 200 caracteres.")]
        public string Interessado { get; set; } = string.Empty;

        [Required(ErrorMessage = "O assunto do processo é obrigatório.")]
        [StringLength(200, ErrorMessage = "O assunto deve ter no máximo 200 caracteres.")]
        public string Assunto { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição do processo é obrigatória.")]
        [StringLength(2000, ErrorMessage = "A descrição deve ter no máximo 2000 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A situação do processo é obrigatória.")]
        [StringLength(200, ErrorMessage = "A situação deve ter no máximo 200 caracteres.")]
        public string Situacao { get; set; } = "Aberto";
    }
}
