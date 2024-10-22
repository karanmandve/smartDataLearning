using Autofac;
using Autofac.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);

// TO CHANGE DEFAULT PACKAGES
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


builder.Services.AddControllersWithViews();



// builder.Services // IOC container here
//builder.Services.Add(new ServiceDescriptor(
//    typeof(ICitiesService),
//    typeof(CitiesService),
//    ServiceLifetime.Scoped
//    ));

//builder.Services.AddTransient<ICitiesService, CitiesService>();
builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder =>
{
    // ADD Transient
    //ContainerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency();

    // ADD Scoped
    ContainerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope();

    // ADD Scoped
    //ContainerBuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance();

});
//builder.Services.AddSingleton<ICitiesService, CitiesService>();


var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
