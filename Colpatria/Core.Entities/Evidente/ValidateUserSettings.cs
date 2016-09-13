using System;

namespace Core.Entities.Evidente
{
    public class ValidateUserSettings : BaseSettings
    {
        public DateTime ExpeditionDate { get; set; }
        public string Fullname { get; set; }
        public string Lastname { get; set; }
        public string SecondLastname { get; set; }
    }
}
