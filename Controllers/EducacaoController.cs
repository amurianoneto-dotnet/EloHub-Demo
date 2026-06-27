using EcoCicloPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EcoCicloPortal.Controllers
{
    public class EducacaoController : Controller
    {
        // [CÓDIGO OCULTO POR SEGURANÇA]
        // A injeção de dependência do ApplicationDbContext foi removida nesta versão
        // pública para proteger a infraestrutura do sistema.

        public EducacaoController()
        {
        }

        public IActionResult Index()
        {
            // [CÓDIGO OCULTO POR SEGURANÇA]
            // A busca de artigos e materiais educativos no banco de dados (LINQ) foi removida.

            // Simulando uma lista vazia de conteúdos para a View renderizar o layout base (Mock)
            var conteudosMock = new List<ConteudoEducativo>();

            return View(conteudosMock);
        }

        public IActionResult Detalhes(int id)
        {
            // [CÓDIGO OCULTO POR SEGURANÇA]
            // Lógica de busca detalhada (Find) no banco de dados foi removida.

            // Simulando um artigo retornado para demonstração do design da página de leitura
            var artigoMock = new ConteudoEducativo
            {
                Id = id,
                // Os nomes das propriedades abaixo dependem de como você montou seu Model, 
                // mas você pode simular os principais aqui se quiser que apareçam na tela:
                // Titulo = "O papel da tecnologia na Economia Circular",
                // Resumo = "Artigo de demonstração para o repositório público."
            };

            return View(artigoMock);
        }
    }
}