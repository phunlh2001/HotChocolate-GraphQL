using LearnChocolate.Schema.Mutations;
using LearnChocolate.Schema.Queries;
using LearnChocolate.Subscriptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseWebSockets();

app.MapGraphQL();

app.Run();
