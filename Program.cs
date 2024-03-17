using BlazorStatic;
using BlazorStaticMinimalBlog.Components;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseStaticWebAssets();

builder.Services.AddBlazorStaticService(opt => {
    opt.IgnoredPathsOnContentCopy.Add("app.css");//pre-build version for tailwind
}
).AddBlogService<FrontMatter>();

builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.UseBlog<FrontMatter>();
app.UseBlazorStaticGenerator(shutdownApp: !app.Environment.IsDevelopment());

app.Run();

public static class WebsiteKeys
{
    public const string GitHubRepo = "https://github.com/Husseinbeygi";
    public const string Twitter = "https://twitter.com/husseinbeygi";
	public const string Linkedin = "https://www.linkedin.com/in/husseinbeygi/";
	public const string Title = "H U S S E I N  B E Y G I";
    public const string BlogPostStorageAddress = $"{GitHubRepo}/tree/main/Content/Blog";
    public const string BlogLead = "Welcome to my blog :)";

}
