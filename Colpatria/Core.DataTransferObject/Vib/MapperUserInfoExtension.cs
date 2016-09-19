namespace Core.DataTransferObject.Vib
{
    public static class MapperUserInfoExtension
    {
        public static UserInfoDto Mapping(this MapperUserInfo row)
        {
            var userInfo = new UserInfoDto
            {
                Identification = row.Identification,
                IdentificationType = row.IdentificationType,
                Id = row.Id,
                Address = row.Address,
                Cellphone = row.Cellphone,
                Email = row.Email,
                LastName = row.LastName,
                SecondLastName = row.SecondLastName,
                Names = row.Names,
                Telephone = row.Telephone,
                DateOfExpedition = row.DateOfExpedition
            };
            return userInfo;
        }
    }
}
