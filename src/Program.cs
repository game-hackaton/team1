using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using thegame.GameModels;
using thegame.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddMvc();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<Cell, CellDto>()
        .ForMember(
            dest => dest.Content,
            opt => opt.MapFrom(src => src.Score.ToString()))
        .ForMember(
            dest => dest.Type,
            opt => opt.MapFrom(src => $"tile-{src.Score}"))
        .ForMember(
            dest => dest.Id,
            opt => opt.MapFrom(src => src.Id.ToString()))
        .ForMember(
            dest => dest.Pos,
            opt => opt.MapFrom(src => src.Id.ToString()));
    
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Use((context, next) =>
{
    context.Request.Path = "/index.html";
    return next();
});
app.UseStaticFiles();

app.Run();