var builder = WebApplication.CreateBuilder(args); // Creates a new builder for configuring the web application.

builder.Services.AddControllers(); // Adds services required for controllers to the DI container.
builder.Services.AddEndpointsApiExplorer(); // Adds support for API endpoint exploration.
builder.Services.AddSwaggerGen(); // Adds Swagger generation for API documentation.
builder.Services.AddCors(options =>
{
   // Configures CORS (Cross-Origin Resource Sharing) policies.
   options.AddPolicy("AllowAngularApp",
        builder => builder.WithOrigins("http://localhost:4200") // Allows requests from the specified origin (Angular app running on localhost:4200).
                          .AllowAnyMethod() // Allows any HTTP method (GET, POST, etc.).
                          .AllowAnyHeader()); // Allows any HTTP headers.
});

var app = builder.Build(); // Builds the web application with the configured services.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enables Swagger middleware in development mode.
    app.UseSwaggerUI(); // Enables the Swagger UI middleware for API documentation in development mode.
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS.
app.UseCors("AllowAngularApp"); // Applies the CORS policy named "AllowAngularApp".
app.UseAuthorization(); // Enables authorization middleware.
app.MapControllers(); // Maps attribute-routed controllers.

app.Run(); // Runs the web application.
