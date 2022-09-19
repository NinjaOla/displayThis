using Sanity.Linq;
using Sanity.Linq.BlockContent;
using Vanir.Website.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/Course2022", "kurs");
    options.Conventions.AddPageRoute("/ExtShop","shop");
});

builder.Services.AddScoped<ArticlesService>();
builder.Services.AddScoped<TeamsService>();
builder.Services.AddSingleton<OMCache>();

builder.Services.AddSingleton<SanityOptions>(s =>
{
    return new SanityOptions
    {
        ProjectId = "7vkpakb4",
        Dataset = "production",
        Token = builder.Configuration["SanityToken"],
        UseCdn = false,
        ApiVersion = "v1"
    };
});

builder.Services.AddScoped<SanityDataContext>(s =>
{
    var options = s.GetService<SanityOptions>();

    return new SanityDataContext(options);
});

builder.Services.AddTransient<SanityHtmlBuilder>(s =>
{
    return s.GetService<SanityDataContext>().HtmlBuilder;
});

builder.Services.AddTransient<VNRSanityServices>();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
    options.AppendTrailingSlash = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapRazorPages();

app.Run();
