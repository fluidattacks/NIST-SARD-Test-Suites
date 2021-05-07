using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestCaseSupport
{
    public abstract class AbstractTestCaseWeb : AbstractTestCaseWebBase
    {
#if (!OMITBAD)
        public abstract void Bad(HttpRequest req, HttpResponse resp);
#endif //omitbad
#if (!OMITGOOD)
        public abstract void Good(HttpRequest req, HttpResponse resp);
#endif //omitgood
        override public void RunTest(String webName, HttpRequest req, HttpResponse resp)
        {
            resp.Write("<br><br>Starting tests for Web testcase " + webName);
#if (!OMITGOOD)
            try
            {
                Good(req, resp);

                resp.Write("<br>Completed good() without Exception for Web testcase " + webName);
            }
            catch (Exception throwableException)
            {
                resp.Write("<br>Caught thowable from good() in Web testcase " + webName);

                resp.Write("<br>Throwable's message = " + throwableException.Message);

                resp.Write("<br><br>Stack trace below");

                resp.Write("<br>" + throwableException.StackTrace);
                
            }
#endif //omitgood
#if (!OMITBAD)
            try
            {
                Bad(req, resp);

                resp.Write("<br>Completed bad() without Exception for Web testcase " + webName);
            }
            catch (Exception throwableException)
            {
                resp.Write("<br>Caught thowable from bad() in Web testcase " + webName);

                resp.Write("<br>Throwable's message = " + throwableException.Message);

                resp.Write("<br><br>Stack trace below");

                resp.Write("<br>" + throwableException.StackTrace);

            }
#endif //omitbad
        }
    }
}
