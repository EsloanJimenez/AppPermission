using System;
using System.Collections.Generic;
using System.Text;

namespace AppPermission.Infrastructure.Exceptions
{
    public class PermissionException : Exception
    {
        public PermissionException(string msj) : base(msj)
        {
            
        }
    }
}
