using EcoCicloPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EcoCicloPortal.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // [CÓDIGO OCULTO POR SEGURANÇA]
        // A injeção de dependência do ApplicationDbContext foi removida nesta versão de demonstração
        // para proteger a infraestrutura e modelagem real do banco de dados do ELO Hub.

        public AdminController()
        {
        }

        // ==========================================
        // PAINEL DE CONTROLE DO DONO DA STARTUP (SaaS)
        // ==========================================
        public IActionResult Index()
        {
            // [CÓDIGO OCULTO POR SEGURANÇA]
            // - Lógica de verificação de perfil "SuperAdmin" através do Identity removida.
            // - Consultas de métricas e agregações usando Entity Framework (LINQ) removidas.

            // Simulando dados estáticos (Mock) para a View renderizar corretamente no portfólio
            ViewBag.TotalUsuarios = 2450;
            ViewBag.TotalOcorrencias = 840;
            ViewBag.AnimaisSalvos = 120;
            ViewBag.TotalCashback = 15400.00m;
            ViewBag.UltimasOcorrencias = new List<Ocorrencia>(); // Mock de lista vazia

            ViewBag.TotalPrefeituras = 14;
            ViewBag.MRR = 35000.00m; // Faturamento Mensal SaaS (Mock)
            ViewBag.TotalOrgaos = 42;

            // Instância simulada do Model para evitar NullReferenceException na View
            var prefeiturasMock = new List<Prefeitura>();

            return View(prefeiturasMock);
        }

        // ==========================================
        // ÁREA DE PUBLICAÇÃO DE MATÉRIAS (EDUCAÇÃO)
        // ==========================================
        [HttpGet]
        public IActionResult NovaMateria()
        {
            // Verificação de segurança baseada em Claims/Roles removida na demo.
            return View();
        }

        [HttpPost]
        public IActionResult NovaMateria(ConteudoEducativo novaMateria)
        {
            // [CÓDIGO OCULTO POR SEGURANÇA]
            // Lógica de persistência (_context.Add e _context.SaveChanges) removida.

            TempData["MensagemSucesso"] = "Matéria publicada com sucesso na Biblioteca Digital (Demonstração)!";
            return RedirectToAction("Index");
        }

        // ==========================================
        // ÁREA DE CADASTRO DE CLIENTES (PREFEITURAS)
        // ==========================================
        [HttpGet]
        public IActionResult NovaPrefeitura()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovaPrefeitura(Prefeitura prefeitura)
        {
            // [CÓDIGO OCULTO POR SEGURANÇA]
            // Tratamento de ModelState, injeção de status 'Ativo' e persistência de novo cliente B2G removidos.

            TempData["MensagemSucesso"] = $"Prefeitura ativada com sucesso (Demonstração)!";
            return RedirectToAction("Index");
        }

        // ==========================================
        // GERENCIAR UMA PREFEITURA ESPECÍFICA (ÓRGÃOS)
        // ==========================================
        [HttpGet]
        public IActionResult GerenciarPrefeitura(int id)
        {
            // [CÓDIGO OCULTO POR SEGURANÇA]
            // Consulta relacional complexa (.Include) removida.

            var prefeituraMock = new Prefeitura { Id = id, Nome = "Prefeitura Demo (Smart City)" };
            return View(prefeituraMock);
        }

        [HttpPost]
        public IActionResult AdicionarOrgao(int prefeituraId, string nomeOrgao)
        {
            // [CÓDIGO OCULTO POR SEGURANÇA]
            // Persistência relacional 1:N (Prefeitura -> Órgãos) removida.

            TempData["MensagemSucesso"] = $"Órgão '{nomeOrgao}' cadastrado com sucesso (Demonstração)!";
            return RedirectToAction("GerenciarPrefeitura", new { id = prefeituraId });
        }
    }
}