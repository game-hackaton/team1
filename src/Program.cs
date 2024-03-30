using System.Drawing;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using thegame.GameModels;
using thegame.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddMvc();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<Point, VectorDto>()
        .ForMember(
            dest => dest.X,
            opt => opt.MapFrom(src => src.X))
        .ForMember(
            dest => dest.Y,
            opt => opt.MapFrom(src => src.Y));
    
    cfg.CreateMap<Cell, CellDto>()
        .ForMember(
            dest => dest.Id,
            opt => opt.MapFrom(src => src.Id.ToString()))
        .ForMember(
            dest => dest.Pos,
            opt => opt.MapFrom(src => src.Id.ToString()))
        .ForMember(
            dest => dest.ZIndex,
            opt => opt.MapFrom(src => 1))
        .ForMember(
            dest => dest.Type,
            opt => opt.MapFrom(src => $"tile-{src.Score}"))
        .ForMember(
            dest => dest.Content,
            opt => opt.MapFrom(src => src.Score.ToString()));

    cfg.CreateMap<Game, GameDto>()
        .ForMember(
            dest => dest.Cells,
            opt => opt.MapFrom(src => src.Map.ToArray()))
        .ForMember(
            dest => dest.MonitorKeyboard,
            opt => opt.MapFrom(src => true))
        .ForMember(dest => dest.MonitorMouseClicks,
            opt => opt.MapFrom(src => false))
        // todo
        .ForMember(
            dest => dest.Id,
            opt => opt.MapFrom(src => src.Id.ToString()))
        .ForMember(
            dest => dest.IsFinished,
            opt => opt.MapFrom(src => src.IsFinished))
        .ForMember(
            dest => dest.Score,
            opt => opt.MapFrom(src => src.Score));

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