namespace BoldReports.Server.ORM
{
    using System;
    using System.ComponentModel;
    using System.Net;
    using System.Reflection;

    using BoldReports.Server.Base.DataClasses;

    public class ExceptionHelper
    {
        //    public static void ThrowException(HttpStatusCode httpStatusCode, ErrorCode errorCode, MethodBase methodBase)
        //    {
        //        throw new ApiException
        //        {
        //            StatusCode = httpStatusCode,
        //            ErrorCode = errorCode,
        //            ErrorMessage = GetDescription(errorCode),
        //            ReturnedFrom = !string.IsNullOrWhiteSpace(methodBase.DeclaringType.FullName) ? methodBase.DeclaringType.FullName + " " + methodBase : string.Empty
        //        };
        //    }

        //    public static string GetDescription(Enum value)
        //    {
        //        var field = value.GetType().GetField(value.ToString());
        //        var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
        //        return attribute == null ? value.ToString() : attribute.Description;
        //    }
        //}
    }
}