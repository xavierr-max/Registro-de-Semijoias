using RegistroDeSemiJoias.Data;

var builder = WebApplication.CreateBuilder(args);


builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
builder
    .Services
    .AddDbContext<RegistroDbContext>();

var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "Servi�o em produ��o...");

app.Run();
