using AutoMapper;
using Core.DataTransferObject.Vib;
using Core.Entities.Logging;

namespace Crosscutting.Mappers
{
    public static class AutomapperMaps
    {
        public static void Initialize()
        {
         Mapper.Initialize(mapper =>
         {
             mapper.CreateMap<ColpatriaLog, ColpatriaLogDto>();
         });
        }
        public static TTo Map<TFrom, TTo>(this TFrom from)
        {
            return Mapper.Map<TFrom, TTo>(from);
        }
    }
}
