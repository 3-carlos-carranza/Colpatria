using System;

namespace Core.DataTransferObject.Vib
{
    public class MapperUserInfo
    {
        public long Id { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string FullName => Names + " " + LastName + " " + SecondLastName;
        public int IdentificationType { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public DateTime DateOfExpedition { get; set; }
    }
}