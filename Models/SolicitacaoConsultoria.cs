using System.ComponentModel.DataAnnotations;

namespace EcoCicloPortal.Models
{
    public class SolicitacaoConsultoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da empresa é obrigatório")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Informe um e-mail de contato")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [Required(ErrorMessage = "Selecione o serviço desejado")]
        public string ServicoInteresse { get; set; } // PGRS, MTR, Treinamento, etc.

        public string Mensagem { get; set; }

        public DateTime DataSolicitacao { get; set; } = DateTime.Now;

        public bool Respondido { get; set; } = false;
    }
}