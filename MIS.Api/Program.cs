using Mis.Api.Extensions;
using MIS.Api.Extensions;
using MIS.Business.Extensions;
using MIS.Data.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args).ConfigureSerilog();

builder.Logging.AddConfiguration(builder.Configuration);

builder.Logging.AddSerilog();
builder.Services.AddSwaggerModule(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddMisData(builder.Configuration);
builder.Services.AddMisBusinessServices(builder.Configuration);
builder.Services.AddAutoMapper();

var app = builder.Build();

app.UseCustomExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerModule();
}

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.MapControllers();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
