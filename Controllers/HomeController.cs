using EcoCicloPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcoCicloPortal.Controllers
{
    public class HomeController : Controller
    {
        // [CÓDIGO OCULTO POR SEGURANÇA]
        // A injeção de dependência do ApplicationDbContext foi removida nesta versão
        // pública para proteger as credenciais e a modelagem do banco de dados do ELO Hub.

        public HomeController()
        {
        }

        // HOME
        public IActionResult Index()
        {
            decimal saldoAtual = 0.00m;

            // [CÓDIGO OCULTO POR SEGURANÇA]
            // A busca real do usuário logado via Identity e a consulta LINQ ao banco de dados
            // foram ocultadas para evitar a exposição da estrutura da tabela de usuários.

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                // Simulando um saldo fictício caso o usuário esteja autenticado na demonstração
                saldoAtual = 75.50m;
            }

            // Mantendo o envio para a página HTML para que o layout preserve o espaço do ELO Cashback
            ViewBag.SaldoCashback = saldoAtual;

            return View();
        }

        // 2. A PÁGINA SOBRE NÓS
        public IActionResult Sobre()
        {
            return View();
        }

        // 3. A PÁGINA PARA PREFEITURAS
        public IActionResult Prefeituras()
        {
            return View();
        }

        // 4. CAPTAÇÃO DE LEADS (B2G / B2B)
        [HttpPost]
        public IActionResult EnviarContato(ContatoLead lead)
        {
            // [CÓDIGO OCULTO POR SEGURANÇA]
            // Lógica de persistência no banco de dados (_context.ContatosLead.Add e SaveChanges) removida.

            if (ModelState.IsValid)
            {
                // Mantemos o comportamento dos feedbacks visuais e redirecionamentos para demonstrar domínio do fluxo MVC
                TempData["MensagemSucesso"] = "Solicitação enviada (Modo Demonstração)! Nossa equipe comercial entraria em contato.";
            }

            if (lead.Perfil == "Prefeitura")
                return RedirectToAction("Prefeituras");
            else
                return RedirectToAction("Index", "Empresas");
        }

        // 5. PÁGINA DE ERRO PADRÃO DO SISTEMA
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}