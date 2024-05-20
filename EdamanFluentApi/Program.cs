using EdamanFluentApi.Components;
using EdamanFluentApi.Data;
using EdamanFluentApi.Mappings;
using EdamanFluentApi.Repositories.Interfaces;
using EdamanFluentApi.Services.Implementations.Edaman;
using EdamanFluentApi.Services.Interfaces.Edaman;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;


//const string BaseURL = "https://api.edamam.com";

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("YoutubeDB");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<YoutubeDbContext>(options => options.UseSqlite(connectionString));
builder.Services.AddAutoMapper(typeof(AppMappings));

builder.Services.AddHttpClient();
builder.Services.AddFluentUIComponents();

builder.Services.AddDataGridEntityFrameworkAdapter();

builder.Services.AddTransient<IRecipesService, RecipesService>();
builder.Services.AddTransient<IFoodDatabaseService, FoodDatabaseService>();
builder.Services.AddTransient<IAutoCompleteFoodDatabaseService, AutoCompleteFoodDatabaseService>();
builder.Services.AddTransient<IJsonFileManager, JsonFileManager>();

builder.Services.AddTransient<IYoutubeService, YoutubeService>();
builder.Services.AddScoped<IYoutubeRepository, YoutubeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
