﻿#region Signature

// ----------------------------------------------------------------------- <copyright
// file=IUserAppService.cs company="Banlinea S.A.S"> Copyright (c) Banlinea Todos los derechos
// reservados. </copyright> <author>Jeysson Stevens Ramirez </author> <Date> 2016 -09-08 - 10:17 a.
// m.</Date> <Update> 2016-09-08 - 11:08 a. m.</Update> -----------------------------------------------------------------------

#endregion Signature

#region

using Core.DataTransferObject.Vib;
using Core.Entities.Process;
using Core.Entities.User;
using Crosscutting.Common.Tools.DataType;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

#endregion

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IUserAppService
    {
        Task<IdentityResult> ConfirmEmailAsync(long user, string token);

        Task<IdentityResult> CreateAsync(User user, string password);

        Task<ClaimsIdentity> CreateIdentityAsync(User user, string type);

        Task<User> FindAsync(string email, string password);

        Task<User> FindAsync(string identification, int identificationType, string password);

        Task<User> FindByIdAsync(long userId);

        Task<User> FindByNameAsync(string email);

        Task<string> GenerateEmailConfirmationTokenAsync(long id);

        Task<string> GeneratePasswordResetTokenAsync(long id);

        Task<bool> IsEmailConfirmedAsync(long id);

        Execution GetRequestUserByRequestId(long requestid);

        Task SendEmailAsync(long id, string subject, string body);

        Task<IdentityResult> UpdateAsync(long user);

        Task<IdentityResult> UpdateUserAndPassword(User user, string newPassword);

        Task<IQueryable<string>> UsersAreRegistered(IEnumerable<string> cleanEmailsList);

        IEnumerable<Page> GetAllPagesWithSections();

        IEnumerable<FieldToCreateUser> GetMappingFieldToCreateUsers();

        Task<User> GetUserByMappingField(IEnumerable<FieldToCreateUser> mappingfields,
            IEnumerable<FieldValueOrder> fields);

        UserInfoDto GetUserInfoByExecutionId(long executionId);

        long GetValidExecutionByUserAndProduct(long userId, int productId);

        Execution GetRequestBySimpleId(string simpleId);
    }
}