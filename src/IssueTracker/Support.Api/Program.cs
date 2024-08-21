using IssueTracker.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // /swagger/index.html
    app.UseSwaggerUI();
}

app.MapGet("/support-info", () =>
{

    var response = new SupportContactResponseModel
    {
        EMail = "jeff@company.com",
        Phone = "800 867-5309"
    };
    return Results.Ok(response);
});

app.Run();


