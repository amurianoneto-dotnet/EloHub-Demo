using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using EcoCicloPortal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoCicloPortal.Controllers
{
    public class LoginController : Controller
    {
        // [CÓDIGO OCULTO POR SEGURANÇA]
        // A injeção de dependência do ApplicationDbContext foi removida nesta versão pública.

        public LoginController()
        {
        }

        // ==========================================
        // 1. TELA DE LOGIN
        // ==========================================
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string senha)
        {
            // [CÓDIGO OCULTO POR SEGURANÇA]
            // A consulta real de credenciais no banco de dados foi removida.

            // Simulação de autenticação bem-sucedida para fins de demonstração da UI
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(senha))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim("Nome", "Usuário de Demonstração"),
                    new Claim("Perfil", "SuperAdmin")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Erro = "E-mail ou senha incorretos (Modo Demonstração).";
            return View();
        }

        // ==========================================
        // 2. TELA DE CADASTRO DO CIDADÃO
        // ==========================================
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario novoUsuario)
        {
            // Ocultada a persistência real de dados.
            if (ModelState.IsValid)
            {
                TempData["MensagemSucesso"] = "Conta criada com sucesso (Modo Demonstração)! Faça login para começar.";
                return RedirectToAction("Index");
            }

            return View(novoUsuario);
        }

        // ==========================================
        // 3. SAIR DO SISTEMA
        // ==========================================
        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // ==========================================
        // MODO DESENVOLVEDOR: SEED DE DEMONSTRAÇÃO
        // ==========================================
        [HttpGet]
        public IActionResult GerarUsuariosTeste()
        {
            // Lógica de manipulação direta de seed de banco oculta.
            return Content("Ambiente de demonstração configurado com sucesso! (Persistência desativada no repositório público).");
        }

        // ==========================================
        // ÁREA DA PREFEITURA: CADASTRAR PARCEIROS
        // ==========================================
        [HttpGet]
        public IActionResult CadastrarParceiro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarParceiro(Usuario novoParceiro)
        {
            // Lógica de criação de perfis institucionais via back-end oculta.
            TempData["MensagemSucesso"] = $"Órgão cadastrado com sucesso (Modo Demonstração)!";
            return RedirectToAction("Dashboard", "Ocorrencias");
        }
    }
}