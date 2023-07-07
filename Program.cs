using geradoc_v2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers(); //usar rotas em controllers
//builder.Services.AddResponseCompression(); //comprimir as requisições
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<Database, Database>();


var app = builder.Build();

app.UseRouting();

//usando o cors para poder liberar acesso ao front-end
app.UseCors(builder =>
    builder.WithOrigins("http://localhost:3000")
           .AllowAnyHeader()
           .AllowAnyMethod()
);


//utilizando rotas do controller
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

//usando a compressao das req
//app.UseResponseCompression();

app.Run();
