using AutoMapper;

namespace Crusscutting.Mappers
{
    public static class AutomapperMaps
    {
        public static void Initialize()
        {
         
        }
        public static TTo Map<TFrom, TTo>(this TFrom from)
        {
            return Mapper.Map<TFrom, TTo>(from);
        }
    }
}
