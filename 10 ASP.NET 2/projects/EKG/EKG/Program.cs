using EKG;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

Dictionary<Person, List<ECG>> data = new();
app.MapPost("person/add", (Person person) =>
{
    if (data.TryAdd(person, new List<ECG>()))
    {
        return Results.Created($"/ekg/summary/{person.CPR}", person);
    }
    else
    {
        return Results.BadRequest("Patient already exists");

    }
        
});

app.MapPost("/ekg/summary", (ECG ecg) =>
{
    if (data.Any(kv => kv.Key.CPR.Equals(ecg.CPR)))
    {
        ecg.Date = DateTime.Now;
        var keyValuePair = data.First(kv => kv.Key.CPR.Equals(ecg.CPR));
        keyValuePair.Value.Add(ecg);
        return Results.Created($"/ekg/summary/{ecg.CPR}", ecg);
    }
    else
    {
        return Results.BadRequest("Patient not added");
    }
});

app.MapGet("/ekg/summary/{cpr}", (string cpr) => 
    data.FirstOrDefault(kv => kv.Key.CPR.Equals(cpr),
                        new KeyValuePair<Person, List<ECG>>(new Person(), new List<ECG>()))
            .Value);

Dictionary<string, string> clients = new();
app.MapPost("client/register/{ip}", (string ip, string whoami) =>
{
    clients[ip] = whoami;
});

app.MapGet("client/", () => clients.Aggregate(new List<object>(), (l, c) => {
    l.Add(new { Ip = c.Key, Who = c.Value });
    return l;
}) );
    
app.Run();