using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using YamahaEventos;
using YamahaEventos.Data;

var builder = WebApplication.CreateBuilder(args);






var YamahaEventosConnectionString = builder.Configuration.GetConnectionString("YamahaEventosConnectionString");


builder.Services.AddDbContext<YamahaEventoDbContext>(options =>options.UseSqlServer(YamahaEventosConnectionString));

var host = new WebHostBuilder()
  .UseKestrel()
  .UseContentRoot(Directory.GetCurrentDirectory())
  .UseIISIntegration()
  .UseStartup<Startup>()
  .Build();

builder.Services.Configure<IISOptions>(o =>
{
    o.ForwardClientCertificate = false;
});


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
