using System;
using Microsoft.AspNetCore.Mvc;

namespace Template.Web.Controllers
{
    public class BaseController : Controller
    {
        private bool IsInstanceOfGenericType(Type genericType, object instance)
        {
            var type = instance.GetType();
            while (type != null)
            {
                if (type.IsGenericType &&
                    type.GetGenericTypeDefinition() == genericType)
                    return true;
                type = type.BaseType;
            }

            return false;
        }
    }
}