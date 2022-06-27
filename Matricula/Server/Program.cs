using Matricula.BD.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//.NET3.1
//Instala la librería: Microsoft.AspNetCore.Mvc.NewtonsoftJson
//services.AddControllers().AddNewtonsoftJson(x =>
//    x.SerializerSettings.ReferenceLoopHandling =
//    Newtonsoft.Json.ReferenceLoopHandling.Ignore);
//.NET5
//services.AddControllersWithViews().AddJsonOptions(x =>
//    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
//.NET6
builder.Services.AddControllersWithViews().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var conn = builder.Configuration.GetConnectionString("con");
builder.Services.AddDbContext<dbcontext>(opciones => opciones.UseSqlServer(conn));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Matricula", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
    "Matricula v1"));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
