using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDriverService, DriverService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configuring swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// registers all the services associated with the Application Layer
// builder.Services.AddApplication();
// builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// registers all the services associated with the Persistence Layer
// builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddDbContext<ApplicationDbContext>( options =>
{
    options.UseNpgsql
    (
        builder.Configuration.GetConnectionString("ApplicationDbContext")
    );
} );

// builder.Services.AddScoped<IApplicationDbContext>( provider =>
// {
//     provider.GetService<ApplicationDbContext>();
// } );
builder.Services.AddScoped<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
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
app.MapFallbackToFile("index.html");

app.Run();
