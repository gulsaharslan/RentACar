using RentACar.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACar.Application.Features.CQRS.Handlers.BannerHandlers;
using RentACar.Application.Features.CQRS.Handlers.BrandHandlers;
using RentACar.Application.Features.CQRS.Handlers.CarHandlers;
using RentACar.Application.Features.CQRS.Handlers.CategoryHandlers;
using RentACar.Application.Features.CQRS.Handlers.ContactHandlers;
using RentACar.Application.Interfaces;
using RentACar.Application.Interfaces.CarInterfaces;
using RentACar.Persistence.Context;
using RentACar.Persistence.Repositories;
using RentACar.Persistence.Repositories.CarRepositories;
using RentACar.Application.Services;
using RentACar.Application.Interfaces.BlogInterfaces;
using RentACar.Persistence.Repositories.BlogRepositories;
using RentACar.Application.Interfaces.CarPricingInterfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Repositories.CarPricingRepositories;
using RentACar.Application.Features.Mediator.Handlers.CarPricingHandlers;
using RentACar.Application.Interfaces.TagCloudInterfaces;
using RentACar.Persistence.Repositories.TagCloudRepositories;
using RentACar.Application.Features.RepositoryPattern;
using RentACar.Persistence.Repositories.CommentRepositories;
using RentACar.Application.Interfaces.StatisticsInterfaces;
using RentACar.Persistence.Repositories.StatisticsRepositories;
using RentACar.Application.Interfaces.RentACarInterfaces;
using RentACar.Persistence.Repositories.RentACarRepositories;
using RentACar.Application.Features.Mediator.Handlers.CommandHandlers;
using RentACar.Application.Interfaces.CarFeatureInterfaces;
using RentACar.Persistence.Repositories.CarFeatureRepositories;
using RentACar.Application.Interfaces.ReviewInterfaces;
using RentACar.Persistence.Repositories.ReviewRepositories;
using FluentValidation.AspNetCore;
using System.Reflection;
using FluentValidation;
using RentACar.Application.Validators.ReviewValidator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RentACar.Application.Tools;
using RentACar.WebApi.Hubs;
using RentACar.Application.Interfaces.ReservationInterfaces;
using RentACar.Persistence.Repositories.ReservationRepositories;
using RentACar.Application.Interfaces.MailServiceInterfaces;
using RentACar.Persistence.Repositories.MailServiceRepositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});

builder.Services.AddSignalR();
// Add services to the container.


#region Registirations
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
builder.Services.AddScoped(typeof(IMailServiceRepository), typeof(MailServiceRepository));

builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddScoped<CreateCommentCommandHandler>();


builder.Services.AddScoped<GetCarPricingWithCarQueryHandler>();
#endregion

builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateReviewValidator>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<CarHub>("/carhub");

app.Run();
