var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/Get ", () =>
{
    return "Get Hello";
});
app.MapPost("/Post", () =>
{
    var response = new {message = "Succesfully Posted",
    success = true };
    return response;
});
app.MapDelete("/Delete",() => 
{ var response = new
{
    message = "Succesfully deleted ",
    success = true };
    return response;

});

app.UseAuthorization();

app.MapControllers();

app.Run();
