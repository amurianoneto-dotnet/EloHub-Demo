using EcoCicloPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EcoCicloPortal.Controllers
{
    public class EmpresasController : Controller
    {
        // [CÓDIGO OCULTO POR SEGURANÇA]
        // A injeção de dependência do ApplicationDbContext foi removida para blindar 
        // a infraestrutura do banco de dados na demonstração pública.

        public EmpresasController()
        {
        }

        // Página principal de serviços para empresas
        public IActionResult Index()
        {
            return View();
        }

        // Página para listar empresas/parceiros certificados (Monetização)
        public IActionResult Parceiros()
        {
            // [CÓDIGO OCULTO POR SEGURANÇA]
            // A listagem real dos assinantes B2B do banco de dados foi removida.

            // Simulando uma lista de empresas para manter o funcionamento da View (Mock)
            var parceirosMock = new List<Empresa>();

            return View(parceirosMock);
        }

        // Página de solicitação de consultoria (PGRS/MTR)
        public IActionResult Consultoria()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Consultoria(SolicitacaoConsultoria solicitacao)
        {
            // [CÓDIGO OCULTO POR SEGURANÇA]
            // - Validação real de segurança removida.
            // - Lógica de persistência da solicitação de consultoria (captação de leads) removida.

            TempData["MensagemSucesso"] = "Solicitação enviada (Modo Demonstração)! Nossos consultores entrariam em contato.";
            return RedirectToAction("Index");
        }
    }
}