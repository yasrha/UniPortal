using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using UniPortal.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Setting up the DB Context
var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
var connectionString = builder.Configuration.GetConnectionString("UniPortalDB");

builder.Services.AddDbContext<UniContext>(options =>
    options.UseMySql(connectionString, serverVersion));


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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();  // This ensures that controller routes are recognized
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});


app.Run();
