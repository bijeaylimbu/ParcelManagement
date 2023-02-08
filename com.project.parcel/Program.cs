using com.project.parcel.Domain.IRepository;
using com.project.parcel.Domain.IServices;
using com.project.parcel.Infrastructure;
using com.project.parcel.Repository;
using com.project.parcel.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddDbContext<ParcelDbContext>(options =>
    options.UseSqlServer(builder
        .Configuration
        .GetConnectionString("Parcel")
    )
);
builder.Services.AddScoped<IParcelService, ParcelService>();
builder.Services.AddScoped<IParcelRepository, ParcelRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();