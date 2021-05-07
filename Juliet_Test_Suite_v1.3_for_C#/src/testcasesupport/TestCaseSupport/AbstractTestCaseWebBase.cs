using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;

namespace TestCaseSupport
{
    public abstract class AbstractTestCaseWebBase 
    {

        public abstract void RunTest(String webName, HttpRequest req, HttpResponse resp);
        
    }
}
