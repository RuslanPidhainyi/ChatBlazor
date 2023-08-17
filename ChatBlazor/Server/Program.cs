using ChatBlazor.Server.Hubs;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


///////////////////////////////////////////////////////////////////////////////////
//This is code recomendation us Microsoft documents 
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(options =>
	options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" })
);
///////////////////////////////////////////////////////////////////////////////////



var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();



app.MapHub<ChatHub>("/chathub"); //This end-point. This impotend element, because we can connect to our chat-hub from the client        
								 //When user which connect chat or leave chat, we can see User'S name

app.MapFallbackToFile("index.html");

app.Run();
