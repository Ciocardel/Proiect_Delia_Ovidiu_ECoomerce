using Microsoft.EntityFrameworkCore;
using Proiect_Delia_Ovidiu.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proiect_Delia_Ovidiu.Bussiness;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<CartService>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AutentificareMagazinContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Ovi_Delia_Connection") ?? throw new InvalidOperationException("Connection string 'Ovi_Delia_Connection' not found."))
);

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AutentificareMagazinContext>();

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapPost("addToCart", async ([FromQuery] int prodId, CartService cartService,HttpContext httpContext) =>
{
    var userEmail = httpContext!.User!.Identities!.FirstOrDefault().Claims.FirstOrDefault(x=>x.Type == ClaimTypes.Email)?.Value;
    return await cartService.AddProductToCart(prodId, userEmail);
});

app.MapPost("removeFromCart", async ([FromQuery] int prodCosId, [FromQuery]int cosId , CartService cartService, HttpContext httpContext) =>
{
     await cartService.RemoveFromCos(prodCosId, cosId);
});

app.MapRazorPages();

app.Run();
