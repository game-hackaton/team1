using thegame.GameModels;

namespace thegame.Models;

public class CellDto
{
    /// <summary>
    /// Frontend animate transition of the cell from old to new state.
    /// </summary>
    /// <param name="id">Id is used to identificate cell to apply right animation</param>
    /// <param name="pos">Logical position of the cell in the game grid. Upper left corner is `new Vec(0, 0)`</param>
    /// <param name="type">Frontend apply images and other styling to the cell according to this type</param>
    /// <param name="content">Frontend can put this text in the cell</param>
    /// <param name="zIndex">Frontend render cells with higher zIndex above cells with lower zIndex</param>
    public CellDto(string id, VectorDto pos, string type, string content, int zIndex)
    {
        Id = id;
        Pos = pos;
        Type = type;
        Content = content;
        ZIndex = zIndex;
    }

    public string Id { get; set; }
    public VectorDto Pos { get; set; }
    public int ZIndex { get; set; }
    public string Type { get; set; }
    public string Content { get; set; }

    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {
            CreateMap<Cell, CellDto>()
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
        }
    }
}