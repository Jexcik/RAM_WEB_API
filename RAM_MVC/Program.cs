using Hanssens.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using RAM_MVC.Contracts;
using RAM_MVC.Middleware;
using RAM_MVC.Services;
using RAM_MVC.Services.Base;
using System.Reflection;

//Создание билдера приложения
var builder = WebApplication.CreateBuilder(args);

//Добавление сервисов в контейнер
builder.Services.AddHttpContextAccessor();

//Настройка политики использования куки
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

//Установка пути для логина
builder.Services.AddAuthentication(CookieAuthenticationDefaults
    .AuthenticationScheme).AddCookie(options =>
    {
        options.LoginPath = new PathString("/users/login");
    });

//Добавление сервиса для авторизации
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

//Настройка HttpClienta с базовым адресом
builder.Services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://localhost:44375"));

//Добавление AutoMapper с использованием текущей сборки
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
// Добавление поддержки контроллеров с представлениями
builder.Services.AddControllersWithViews();

//Построение приложения
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Перенаправление HTTP на HTTPS
app.UseHttpsRedirection();
// Обслуживание статических файлов
app.UseStaticFiles();
// Включение маршрутизации
app.UseRouting();

//Политика использования Cookie
app.UseCookiePolicy();
//Включение аутентификации
app.UseAuthentication();
//Включение авторизации
app.UseAuthorization();

// Пользовательский middleware для обработки запросов
app.UseMiddleware<RequestMiddleware>();

//Настройка маршрутов контроллеров
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
