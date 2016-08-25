using AutoMapper;
using Core.DataTransferObject.Mongo;
using Core.Entities.Mongo;

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
