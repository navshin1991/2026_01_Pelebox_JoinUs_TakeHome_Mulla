using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.MicrosoftExtensions; // May be needed for advanced options
using Pelebox.API.Extension;
using Pelebox.API.Security;
using Pelebox.Application.Interfaces;
using Pelebox.Application.UseCases;
using Pelebox.Infrastructure.Data;
using Pelebox.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Cross Origin Access
var MyAllowSpecificOrigins = "OriginPolicy";
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy => {
        policy.WithOrigins(builder.Configuration.GetSection($"AppOrigins:url").Get<string[]>())
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
    }
    );
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Token Key *********************************************************
// Add Key Vault to configuration
var keyVaultUri = new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/");
builder.Configuration.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());

// standard JWT setup
var secretKey = builder.Configuration["peleboxjwtsecret"]; // Automatically fetched from Key Vault
string issuer = builder.Configuration["peleboxjwtsecret"];
string audience = builder.Configuration["peleboxjwtsecret"];
int expireMinutes = Convert.ToInt32(60);



// 2. Add JWT Authentication
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        // Use the secret from Key Vault to sign/verify tokens
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});
builder.Services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(secretKey, issuer, audience, expireMinutes));
// ==================================================================

// Dependency Injection
builder.Services.RegisterServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Logging.AddDebug();
builder.Logging.AddConsole();

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Error");
}


app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();