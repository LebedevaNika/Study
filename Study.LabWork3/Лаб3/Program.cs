using Microsoft.EntityFrameworkCore;
using Study.LabWork3.Logic;
using Study.LabWork3.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Добавляем Swagger генератор
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VetClinicDbContext>(options =>
    options.UseSqlite("Data Source=vetclinic.db"));

builder.Services.AddScoped<OwnerService>();
builder.Services.AddScoped<PetService>();
builder.Services.AddScoped<AppointmentService>();

var app = builder.Build();

// Настраиваем Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<VetClinicDbContext>();
    db.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
