using EmailService.API.Service;
using FluentValidation.AspNetCore;
using MailApp.API.Helpter;
using MailApp.API.Service;
using MailApp.Core.Repositories;
using MailApp.Core.Services;
using MailApp.Core.UnitOfWorks;
using MailApp.Repository;
using MailApp.Repository.Repositories;
using MailApp.Repository.UnitOfWorks;
using MailApp.Service.Services;
using MailApp.Service.Validations;
using Microsoft.EntityFrameworkCore;
using NLayerApp.Service.Mapping;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<EmailAddressDtoValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IEmailAddressRepository, EmailAddressRepository>();
builder.Services.AddScoped<IEmailAddressService, EmailAddressService>();

builder.Services.AddScoped<IEmailLogRepository, EmailLogRepository>();
builder.Services.AddScoped<IEmailLogService, EmailLogService>();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<ISendEmailService, SendEmailService>();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        //option.MigrationsAssembly("NLayerApp.Repository");
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
