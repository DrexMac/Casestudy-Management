var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache(); // Adds an in-memory implementation of IDistributedCache.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout.
    options.Cookie.HttpOnly = true; // Ensures the session cookie is not accessible via JavaScript.
    options.Cookie.IsEssential = true; // Makes the session cookie essential for the application.
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Adds HTTP Strict Transport Security middleware.
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS.
app.UseStaticFiles(); // Serves static files (like CSS, JavaScript, images).

app.UseRouting(); // Adds routing capabilities.

app.UseAuthorization(); // Adds authorization capabilities.

app.UseSession(); // Adds session capabilities.

app.MapRazorPages(); // Maps Razor Pages endpoints.

app.Run(); // Runs the application.
