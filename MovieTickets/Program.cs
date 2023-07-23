using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Services.Data;
using MovieTickets.Services.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = 
    builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = builder.Configuration
            .GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

        options.Password.RequireDigit = builder.Configuration
            .GetValue<bool>("Identity:SignIn:RequireDigit");

		options.Password.RequireNonAlphanumeric = builder.Configuration
            .GetValue<bool>("Identity:SignIn:RequireNonAlphanumeric");

		options.Password.RequiredLength = builder.Configuration
            .GetValue<int>("Identity:SignIn:RequiredLength");

		options.Password.RequireLowercase = builder.Configuration
            .GetValue<bool>("Identity:SignIn:RequireLowercase");

		options.Password.RequireUppercase = builder.Configuration
            .GetValue<bool>("Identity:SignIn:RequireUppercase");
    })
    .AddEntityFrameworkStores<MovieDbContext>();

builder.Services.AddScoped<IActorService, ActorService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
