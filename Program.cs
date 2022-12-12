using simplePropertyManagementSystemAPI.Services.LocalDb;
using simplePropertyManagementSystemAPI.Services.LocalDb.Interfaces;
using simplePropertyManagementSystemAPI.Services.LocalDb.Tables;


var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<ISystemUserData, SystemUserData>();
builder.Services.AddSingleton<IPropertyData, PropertyData>();
builder.Services.AddSingleton<ITenantData, TenantData>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          //policy.WithOrigins("http://localhost:3000").AllowAnyHeader();
                          //policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          //policy.WithOrigins("http://localhost:3000").AllowAnyHeader();
                          //policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});


builder.Services.AddControllers(options => {
    options.SuppressAsyncSuffixInActionNames = false;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
