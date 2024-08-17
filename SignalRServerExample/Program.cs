using SignalRServerExample.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
    policy.AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials()
          .SetIsOriginAllowed(origin => true)
));
builder.Services.AddSignalR();

var app = builder.Build();

app.UseCors();
app.UseRouting();
app.MapHub<MyHub>("/myhub");

app.Run();

