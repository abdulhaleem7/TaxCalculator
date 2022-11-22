using TaxCalculator;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(a => a.AddPolicy("CorsPollicy", b =>
{
    b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
}));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ITaxCalculator, TaxCalculatorService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
