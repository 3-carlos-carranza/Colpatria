using System;
using Crosscutting.Common.Tools.DataType;

namespace Core.DataTransferObject.Vib
{
    public class UserInfoDto
    {
        public long Id { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string FullName => Names + " " + LastName + " " + SecondLastName;
        public IdentificationType IdentificationType { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public DateTime DateOfExpedition { get; set; }
        public DateTime CreatedDateExecution { get; set; }
        public string ExpeditionPlace { get; set; }
        public string SimpleId { get; set; }
        public string Birthdate { get; set; }
        public string CivilStatus { get; set; }
        public string EconomicActivity { get; set; }
        public string Income { get; set; }
        public string PublicServer { get; set; }
        public string PickTheCard { get; set; }
        public string Office { get; set; }
        public string AccountType { get; set; }
        public string ExtractMail { get; set; }
        public string MoreInformation { get; set; }
        public string ResponseWsMotor { get; set; }
    }
}
