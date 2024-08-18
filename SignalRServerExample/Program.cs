﻿using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
    policy.AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials()
          .SetIsOriginAllowed(origin => true)
));

builder.Services.AddTransient<MyBusiness>();

builder.Services.AddSignalR();
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors();
app.UseRouting();
app.MapHub<MyHub>("/myhub");
app.MapHub<MessageHub>("/messagehub");
app.MapControllers();

app.Run();

