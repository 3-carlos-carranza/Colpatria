using System;

namespace Core.Entities.Evidente
{
    public class ValidateUserSettings : BaseSettings
    {
        public DateTime ExpeditionDate { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
    }
}
