using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("Smtp"));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(opt =>
{
    #region Password

    opt.Password.RequireDigit = true;
    opt.Password.RequiredLength = 8;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = true;

    #endregion



    #region User

    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = true;

    #endregion



    #region Lockout

    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    opt.Lockout.AllowedForNewUsers = false;

    #endregion
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IAdvantageRepository, AdvantageRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<ISectionHeaderRepository, SectionHeaderRepository>();
builder.Services.AddScoped<ISettingRepository, SettingRepository>();
builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>();
builder.Services.AddScoped<ISubscribeRepository, SubscribeRepository>();
builder.Services.AddScoped<ISocialRepository, SocialRepository>();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IGameCommentRepository, GameCommentRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartGameRepository, CartGameRepository>();
builder.Services.AddScoped<IBlogCommentRepository, BlogCommentRepository>();
builder.Services.AddScoped<IBlogAuthorRepository, BlogAuthorRepository>();
builder.Services.AddScoped<IBlogImageRepository, BlogImageRepository>();
builder.Services.AddScoped<IGameImageRepository, GameImageRepository>();
builder.Services.AddScoped<IGamePlatformRepository, GamePlatformRepository>();
builder.Services.AddScoped<IGameGenreRepository, GameGenreRepository>();

builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IAdvantageService, AdvantageService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IStaticDataService, StaticDataService>();
builder.Services.AddScoped<IDeveloperService, DeveloperService>();
builder.Services.AddScoped<ISubscribeService, SubscribeService>();
builder.Services.AddScoped<ISocialService, SocialService>();
builder.Services.AddScoped<IPlatformService, PlatformService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IGameCommentService, GameCommentService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IBlogCommentService, BlogCommentService>();
builder.Services.AddScoped<IBlogAuthorService, BlogAuthorService>();
builder.Services.AddScoped<IBlogImageService, BlogImageService>();
builder.Services.AddScoped<IGameImageService, GameImageService>();
builder.Services.AddScoped<IGamePlatformService, GamePlatformService>();
builder.Services.AddScoped<IGameGenreService, GameGenreService>();
builder.Services.AddScoped<EmailSetting>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithRedirects("/Error/{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();