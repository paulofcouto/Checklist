using CheckList.Application.Services;
using CheckList.Infrastructure.MySql;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<TarefaService>();
builder.Services.AddScoped<TarefaRepository>();

//Injetando configuração do MySql
builder.Services.AddDbContextPool<ChecklistDbContext>(options =>
{
    var connetionString = builder.Configuration.GetConnectionString("MySql");
    options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Dashboard/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
