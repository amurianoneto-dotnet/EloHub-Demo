// [CÓDIGO OCULTO POR SEGURANÇA] - Usings do banco de dados removidos
// using EcoCicloPortal.Data;
// using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// [CÓDIGO OCULTO POR SEGURANÇA]
// A injeção do Entity Framework Core (ApplicationDbContext) e a configuração
// da Connection String do SQL Server foram removidas do repositório público.
// builder.Services.AddDbContext<ApplicationDbContext>(...);

builder.Services.AddControllersWithViews();

// Configura o sistema de Login por Cookies (Estrutura mantida para demonstração)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // Se alguém tentar invadir, é mandado pra cá
        options.AccessDeniedPath = "/Home/Index"; // Se não tiver permissão
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Middlewares de Segurança
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();