using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.Infrastructure.Extensions;
using static MovieTickets.Web.Infrastructure.Extensions.WebApplicationBuilderExtensions;

using Shopping;
using MovieTickets.Web.Infrastructure.ModelBinders;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
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
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<MovieDbContext>();



builder.Services.AddApplicationServices(typeof(IActorService));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

//builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
});


builder.Services.AddControllersWithViews()
    .AddMvcOptions(option =>
    {
        option.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseCors(builder =>
    builder.WithOrigins("https://localhost:7056/"));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
