using System.Collections.Generic;

namespace EcoCicloPortal.Models
{
    public class DashboardViewModel
    {
        // Esta bandeja carrega as duas listas para o nosso painel
        public IEnumerable<Ocorrencia> Ocorrencias { get; set; }
        public IEnumerable<ContatoLead> Leads { get; set; }

        // NOVO: Guarda o nome da cidade para mostrarmos no título do painel!
        public string NomeCidade { get; set; }
    }
}