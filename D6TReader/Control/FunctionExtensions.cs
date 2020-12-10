using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6TReader.Control
{
    public static class FunctionExtensions
    {

        public static  void Try(this Action act , Action<Exception> onFail)
        {
            try
            {
                act();
            }
            catch(Exception ex)
            {
                onFail(ex);
            }
        }
    }
}
