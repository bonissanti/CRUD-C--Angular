using SuperHeroDatabase;
using SuperHeroRoutes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SHDatabase>();
builder.Services.AddCors(option =>
		option.AddDefaultPolicy(policy =>
		{
			policy.AllowAnyOrigin();
			policy.AllowAnyMethod();
			policy.AllowAnyHeader();
		}));

var app = builder.Build();

//Seed the database - Super Powers
using (var scope = app.Services.CreateScope()){
	var context = scope.ServiceProvider.GetRequiredService<SHDatabase>();
	SHDatabase.SeedData(context);
}

if (app.Environment.IsDevelopment()){
	app.UseSwagger();
	app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();
app.UseCors();
app.AddSuperHero();
app.AddSuperPower();

app.Run();
