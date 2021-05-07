/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE510_Trapdoor__network_connection_11.cs
Label Definition File: CWE510_Trapdoor.badonly.label.xml
Template File: point-flaw-badonly-11.tmpl.cs
*/
/*
* @description
* CWE: 510 Trapdoor
* Sinks: network_connection
*    BadSink : Presence of a network connection
*    BadOnly (No GoodSink)
* Flow Variant: 11 Control flow: if(IO.StaticReturnsTrue())
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Net;

namespace testcases.CWE510_Trapdoor
{
class CWE510_Trapdoor__network_connection_11 : AbstractTestCaseBadOnly
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrue())
        {
            Stream streamInput = null;
            try
            {
                /* FLAW: direct usage of URI */
                Uri url = new Uri("http://123.123.123.123:80");
                WebRequest request = WebRequest.Create(url);
                streamInput = request.GetRequestStream();
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "caught IOException");
            }
            finally
            {
                try
                {
                    if (streamInput != null)
                    {
                        streamInput.Close();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "caught IOException");
                }
            }
        }
    }
#endif //omitbad
}
}
