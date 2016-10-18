using AutoMapper;

namespace Crosscutting.Mappers
{
    public static class AutomapperMaps
    {
        public static void Initialize()
        {
         Mapper.Initialize(mapper =>{});
        }
        public static TTo Map<TFrom, TTo>(this TFrom from)
        {
            return Mapper.Map<TFrom, TTo>(from);
        }
    }
}
