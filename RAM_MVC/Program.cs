using Hanssens.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using RAM_MVC.Contracts;
using RAM_MVC.Middleware;
using RAM_MVC.Services;
using RAM_MVC.Services.Base;
using System.Reflection;

//�������� ������� ����������
var builder = WebApplication.CreateBuilder(args);

//���������� �������� � ���������
builder.Services.AddHttpContextAccessor();

//��������� �������� ������������� ����
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

//��������� ���� ��� ������
builder.Services.AddAuthentication(CookieAuthenticationDefaults
    .AuthenticationScheme).AddCookie(options =>
    {
        options.LoginPath = new PathString("/users/login");
    });

//���������� ������� ��� �����������
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

//��������� HttpClienta � ������� �������
builder.Services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://localhost:44375"));

//���������� AutoMapper � �������������� ������� ������
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
// ���������� ��������� ������������ � ���������������
builder.Services.AddControllersWithViews();

//���������� ����������
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// ��������������� HTTP �� HTTPS
app.UseHttpsRedirection();
// ������������ ����������� ������
app.UseStaticFiles();
// ��������� �������������
app.UseRouting();

//�������� ������������� Cookie
app.UseCookiePolicy();
//��������� ��������������
app.UseAuthentication();
//��������� �����������
app.UseAuthorization();

// ���������������� middleware ��� ��������� ��������
app.UseMiddleware<RequestMiddleware>();

//��������� ��������� ������������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
