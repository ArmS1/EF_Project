using EF_Project.Helpers;
using EF_Project.Helpers.Repositories;
using EF_Project.Servicies.Users;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddDbContext<DataContext>();

    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddScoped<IUserService, UserService>();

    builder.Services.AddControllers();

    //builder.Services.addf
    //builder.Services.AddControllers()
    //    .AddFluentValidation(options => 
    //        options.RegisterValidatorsFromAssemblyContaining(typeof(EF_Project.Validators.AssemblyReference)));

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

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
