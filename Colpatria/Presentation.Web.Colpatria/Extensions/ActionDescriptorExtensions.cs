using System;
using System.Linq;
using System.Web.Mvc;

namespace Presentation.Web.Colpatria.Extensions
{
    public static class ActionDescriptorExtensions
    {
        public static bool HasAllowAnonimouseAttribute(this ActionDescriptor actionDescriptor) => actionDescriptor.HasAttribute<AllowAnonymousAttribute>();

        public static bool HasAttribute<TAttribute>(this ActionDescriptor actionDescriptor)
            where TAttribute : Attribute
            => actionDescriptor.GetCustomAttributes(typeof(TAttribute), false).Any();

        public static bool HasAuthorizeAttribute(this ActionDescriptor actionDescriptor) => actionDescriptor.HasAttribute<AuthorizeAttribute>();
    }
}