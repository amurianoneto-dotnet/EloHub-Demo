using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EcoCicloPortal.Models;
using System;
using System.Linq;

namespace EcoCicloPortal.Controllers
{
    [Authorize]
    public class ParceirosController : Controller
    {
        // [CÓDIGO OCULTO POR SEGURANÇA]
        // Contexto de persistência removido desta demonstração pública do portfólio.

        public ParceirosController()
        {
        }

        // ==========================================
        // 1. A VITRINE DA LOJA DE RECOMPENSAS
        // ==========================================
        public IActionResult Index()
        {
            // Injetando um saldo fictício estável para garantir que a carteira do usuário apareça cheia no portfólio
            ViewBag.SaldoAtual = 120.50m;
            return View();
        }

        // ==========================================
        // 2. AÇÃO DE COMPRAR / DOAR O CASHBACK
        // ==========================================
        [HttpPost]
        public IActionResult Resgatar(decimal valorCusto, string nomeParceiro, string tipoAcao)
        {
            // [CÓDIGO OCULTO POR SEGURANÇA]
            // A lógica de subtração de saldo em tempo real e validação de limite em conta foi removida.

            if (tipoAcao == "Doacao")
            {
                TempData["MensagemSucesso"] = $"Doação de R$ {valorCusto:F2} enviada para {nomeParceiro} com sucesso (Demonstração)! 🐾";
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Voucher", new { parceiro = nomeParceiro, valor = valorCusto });
            }
        }

        // ==========================================
        // 4. A TELA DE EMISSÃO DO VOUCHER / PROTOCOLO
        // ==========================================
        [HttpGet]
        public IActionResult Voucher(string parceiro, decimal valor)
        {
            // Mantemos esse gerador dinâmico de códigos porque ele é excelente para mostrar proficiência em C# no front!
            var random = new Random();
            string codigoGerado = "ELO-" + DateTime.Now.ToString("yyMM") + "-" + random.Next(1000, 9999).ToString();

            ViewBag.Parceiro = parceiro;
            ViewBag.Valor = valor;
            ViewBag.Codigo = codigoGerado;
            ViewBag.DataValidade = DateTime.Now.AddHours(48).ToString("dd/MM/yyyy HH:mm");
            ViewBag.NomeCidadao = "Cidadão Guardião (Demo)";

            return View();
        }

        // ==========================================
        // 3. PÁGINA: SEJA UM PARCEIRO (CADASTRO DE LOJISTAS)
        // ==========================================
        [HttpGet]
        public IActionResult SejaParceiro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SejaParceiro(string nomeLoja, string cnpj, string oferta, decimal valorCashback)
        {
            TempData["MensagemSucesso"] = $"Pré-cadastro da empresa {nomeLoja} simulado com sucesso!";
            return RedirectToAction("Index");
        }

        // ==========================================
        // 5. PAINEL DO LOJISTA (VALIDAÇÃO DE VOUCHER)
        // ==========================================
        [HttpGet]
        public IActionResult PainelLojista()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidarVoucher(string codigoVoucher)
        {
            // Mantemos a casca da validação estrutural básica por strings
            if (string.IsNullOrWhiteSpace(codigoVoucher))
            {
                TempData["ErroValidacao"] = "Por favor, digite o código do protocolo.";
                return RedirectToAction("PainelLojista");
            }

            codigoVoucher = codigoVoucher.Trim().ToUpper();

            if (codigoVoucher.StartsWith("ELO-"))
            {
                TempData["SucessoValidacao"] = $"✅ PROTOCOLO {codigoVoucher} AUTORIZADO VIA MOCK! O desconto simulado foi validado.";
            }
            else
            {
                TempData["ErroValidacao"] = $"❌ ALERTA: Código '{codigoVoucher}' fora do padrão do sistema ELO.";
            }

            return RedirectToAction("PainelLojista");
        }
    }
}