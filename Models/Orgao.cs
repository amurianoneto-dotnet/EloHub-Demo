using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcoCicloPortal.Models
{
    public class Orgao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } // Ex: Zoonoses, Meio Ambiente, Obras

        // Chave do Apartamento: De qual prefeitura é esse órgão?
        public int PrefeituraId { get; set; }
        public Prefeitura Prefeitura { get; set; }

        // Relacionamentos
        public ICollection<Ocorrencia> OcorrenciasAssumidas { get; set; }
        public ICollection<Usuario> Funcionarios { get; set; }
    }
}