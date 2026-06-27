using System;
using System.ComponentModel.DataAnnotations;

namespace EcoCicloPortal.Models
{
    public class ContatoLead
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } // Nome da pessoa

        [Required]
        public string Instituicao { get; set; } // Nome da Prefeitura ou Empresa

        [Required]
        public string Email { get; set; }

        public string Perfil { get; set; } // Para sabermos se veio da página de Empresa ou Prefeitura

        public DateTime DataSolicitacao { get; set; } = DateTime.Now; // Salva a data e hora automática
    }
}