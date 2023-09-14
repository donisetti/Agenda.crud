using Agenda.Crud.Infra;
using Newtonsoft.Json.Serialization;
using Syncfusion.Licensing;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



//Syncfusion Licensing Registration
SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NGaF1cXGNCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdgWXdcdHZURWFfUUJ3XEs=");

builder.Services.AddInfrastructure(builder.Configuration);



// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddCors();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;

});

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
