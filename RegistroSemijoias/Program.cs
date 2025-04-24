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

app.MapGet("/", () => "Serviço em produção...");

app.Run();
