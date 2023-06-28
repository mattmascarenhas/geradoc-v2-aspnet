
using geradoc_v2;
using geradoc_v2.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //usar rotas em controllers
//builder.Services.AddResponseCompression(); //comprimir as requisições
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<Database, Database>();


var app = builder.Build();

app.UseRouting();


//utilizando rotas do controller
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

//usando a compressao das req
//app.UseResponseCompression();

app.Run();
