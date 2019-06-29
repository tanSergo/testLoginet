using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testLoginet.Helpers
{
    public interface IEncryptor
    {
        string EncryptString(string src);

        string DecryptString(string src);
    }
}
