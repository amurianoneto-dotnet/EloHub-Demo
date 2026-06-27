using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcoCicloPortal.Models
{
    public class Prefeitura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } // Ex: Prefeitura de Barra Bonita

        public string CNPJ { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        // A "Chavinha" de Gerenciar Acesso (Bloqueio de Inadimplência)
        public bool Ativo { get; set; } = true;

        // Valor do contrato mensal (para o dashboard do Super Admin)
        public decimal ValorMensalidade { get; set; }

        // Relacionamentos (O que pertence a esta prefeitura)
        public ICollection<Orgao> Orgaos { get; set; }
        public ICollection<Ocorrencia> Ocorrencias { get; set; }
        public ICollection<Usuario> Funcionarios { get; set; }
    }
}