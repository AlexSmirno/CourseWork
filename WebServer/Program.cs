using WebServer.Data;
using WebServer.Data.Repositories;
using WebServer.Data.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StorageContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddTransient<SupplierService>();
builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<SupplyService>();
builder.Services.AddTransient<ClientService>();
builder.Services.AddTransient<ProductRepository>();
builder.Services.AddTransient<ClientRepository>();
builder.Services.AddTransient<SupplierRepository>();
builder.Services.AddTransient<SupplyRepository>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.Run();
