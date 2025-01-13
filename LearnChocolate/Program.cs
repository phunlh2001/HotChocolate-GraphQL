using LearnChocolate.Schema;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddGraphQLServer().AddQueryType<Query>();

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapGraphQL();

app.Run();
