using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNAA.Class
{
    public class CertificateExpireException : Exception
    {
        public CertificateExpireException(string message) : base(message)
        {
        }
    }
}
