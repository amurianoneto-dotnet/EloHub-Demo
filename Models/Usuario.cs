using System.ComponentModel.DataAnnotations;

namespace EcoCicloPortal.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }

        // O Perfil vai definir o que ele pode acessar: "Prefeitura", "Empresa" ou "Cidadao"
        public string Perfil { get; set; }

        // NOVO CAMPO: Se o perfil for "Parceiro", de qual órgão ele é?
        [Display(Name = "Órgão Vinculado (Apenas para Parceiros)")]
        public string? OrgaoVinculado { get; set; }
        // NOVA PROPRIEDADE: A carteira do usuário (inicia zerada)
        [Display(Name = "Saldo de Cashback")]
        public decimal SaldoCashback { get; set; } = 0.00m;

        // --- VÍNCULOS DE GESTÃO PÚBLICA ---
        // Se for preenchido, esse usuário é um funcionário público
        public int? PrefeituraId { get; set; }
        public Prefeitura Prefeitura { get; set; }

        public int? OrgaoId { get; set; }
        public Orgao Orgao { get; set; }
    }
}
