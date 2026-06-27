using System;
using System.ComponentModel.DataAnnotations;

namespace EcoCicloPortal.Models
{
    // Criamos o Enum para o sistema saber qual módulo abrir
    public enum CategoriaOcorrencia
    {
        Residuos,      // EcoCiclo (Lixo, Entulho)
        Zeladoria,     // EcoCiclo (Mato alto, buracos)
        ProtecaoAnimal // Voz Animal (Maus-tratos, abandono)
    }

    public class Ocorrencia
    {
        [Key]
        public int Id { get; set; }

        // NOVA PROPRIEDADE: A categoria principal da ocorrência
        [Required(ErrorMessage = "A categoria é obrigatória")]
        [Display(Name = "Categoria da Denúncia")]
        public CategoriaOcorrencia Categoria { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [Display(Name = "Título da Ocorrência")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Descreva o problema")]
        [Display(Name = "Descrição Detalhada")]
        public string Descricao { get; set; }

        // Deixei sem o [Required] porque ocorrência de Animal não tem "Tipo de Resíduo"
        [Display(Name = "Subcategoria (Ex: Orgânico, Entulho, Cachorro, Gato)")]
        public string? TipoResiduo { get; set; }

        [Display(Name = "Endereço Aproximado")]
        public string Localizacao { get; set; }

        // ==========================================
        // NOVAS PROPRIEDADES: MAPA E GPS
        // ==========================================
        [Display(Name = "Latitude")]
        public double? Latitude { get; set; }

        [Display(Name = "Longitude")]
        public double? Longitude { get; set; }

        public DateTime DataRegistro { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pendente"; // Pendente, Em Análise, Resolvido

        // Quem assumiu esse caso? (Fica vazio até alguém clicar em "Assumir")
        [Display(Name = "Órgão Atendente")]
        public string? OrgaoAtendente { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        public string Estado { get; set; } = "SP";

        public string? FotoPath { get; set; }

        // NOVA PROPRIEDADE: Cashback gerado por esta denúncia
        [Display(Name = "Cashback Gerado (R$)")]
        public decimal ValorCashbackGerado { get; set; } = 0.00m;
        // --- VÍNCULOS DE GESTÃO PÚBLICA (MULTI-TENANT) ---

        // Em qual cidade/prefeitura essa denúncia aconteceu?
        public int? PrefeituraId { get; set; }
        public Prefeitura Prefeitura { get; set; }

        // Qual órgão apertou o botão "Assumir"?
        public int? OrgaoResponsavelId { get; set; }
        public Orgao OrgaoResponsavel { get; set; }
    }
}