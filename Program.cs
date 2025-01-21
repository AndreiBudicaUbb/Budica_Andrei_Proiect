using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Budica_Andrei_Proiect.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Budica_Andrei_ProiectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Budica_Andrei_ProiectContext") ?? throw new InvalidOperationException("Connection string 'Budica_Andrei_ProiectContext' not found.")));

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
