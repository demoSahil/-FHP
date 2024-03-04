using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    public interface IDataHandlerMessages
    {
        string GetMessageDesc(byte key,string tableName);

        byte GetKey(string messageKey,string tableName);

    }
}
