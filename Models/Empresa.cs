public class Empresa
{
    public int Id { get; set; }
    public string NomeFantasia { get; set; }
    public string CNPJ { get; set; }
    public string TipoServico { get; set; } // Coleta, Consultoria, Reciclagem
    public string Contato { get; set; }
    public bool Certificada { get; set; } // Diferencial ECOCICLO
}