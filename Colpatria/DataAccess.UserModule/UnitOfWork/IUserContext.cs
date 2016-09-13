﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DataAccess.UserModule.UnitOfWork
{
    using System.Data.Entity;
    using Core.Entities.User;
    using Data.Common.Definition;
    
    public partial interface IUserContext : IQueryableUnitOfWork
    {
        DbSet<BaseDataList> BaseDataList { get; set; }
        DbSet<BaseDataListValue> BaseDataListValue { get; set; }
        DbSet<BaseField> BaseField { get; set; }
        DbSet<BaseFieldValue> BaseFieldValue { get; set; }
        DbSet<BaseFile> BaseFile { get; set; }
        DbSet<FieldToCreateUser> FieldToCreateUser { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<User> User { get; set; }
        DbSet<UserRole> UserRole { get; set; }
    }
}
