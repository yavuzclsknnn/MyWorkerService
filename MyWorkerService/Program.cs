 
using MyWorkerService;
using MyWorkerService_Business.Abstract;
using MyWorkerService_Business.Concrete;
using MyWorkerService_Core.Options;
using MyWorkerService_Data.Abstract;
using MyWorkerService_Data.Concrete;
using MyWorkerService_Infrastructure.Db;


//var builder = Host.CreateApplicationBuilder(args);
//builder.Services.AddHostedService<Worker>();

//var host = builder.Build();
//host.Run();


var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<DbContext>();
builder.Services.AddScoped<IUrunRepository, UrunRepository>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddHostedService<ImageCleanerWorker>();

builder.Services.Configure<WorkerSettings>(
    builder.Configuration.GetSection("WorkerSettings"));

var host = builder.Build();
host.Run();
