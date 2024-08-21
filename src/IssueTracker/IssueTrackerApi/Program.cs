using IssueTrackerApi.Controllers;
using IssueTrackerApi.TypedClients;
using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Above this line is configuring the "services" for our API.
builder.Services.AddScoped<ILookupSupportInfo, RemoteSupportLookup>();
builder.Services.AddSingleton<HitCounter>();

var supportApiUri = builder.Configuration.GetValue<string>("supportApiUrl")
    ?? throw new Exception("No support api url");

Console.WriteLine("using the api url of " + supportApiUri);
builder.Services.AddHttpClient<SupportApiClient>(client =>
{
    client.BaseAddress = new Uri(supportApiUri);
    // any other configuration you need for the client is here.
}); // retry policy, circuit 

var issuesConnectionString = builder.Configuration.GetConnectionString("data")
    ?? throw new Exception("No data connection string");
builder.Services.AddMarten(config =>
{
    config.Connection(issuesConnectionString);
}).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers(); // looks for all the classes that are controllers (public, controllbase, etc.) and reads those "route" attributes. and creates a "route table"

app.Run(); // kestrel is up and running listening for requests.

public partial class Program { }