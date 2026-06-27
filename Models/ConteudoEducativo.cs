using System;

namespace EcoCicloPortal.Models
{
    public class ConteudoEducativo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string TextoCompleto { get; set; }
        public string Categoria { get; set; } // Rio Tietê, Reciclagem, Legislação
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}