/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE23_Relative_Path_Traversal__NetClient_17.cs
Label Definition File: CWE23_Relative_Path_Traversal.label.xml
Template File: sources-sink-17.tmpl.cs
*/
/*
* @description
* CWE: 23 Relative Path Traversal
* BadSource: NetClient Read data from a web server with WebClient
* GoodSource: A hardcoded string
* BadSink: readFile no validation
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.IO;

using System.Web;

using System.Net;

namespace testcases.CWE23_Relative_Path_Traversal
{

class CWE23_Relative_Path_Traversal__NetClient_17 : AbstractTestCase
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad()
    {
        string data;
        data = ""; /* Initialize data */
        /* read input from WebClient */
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (StreamReader sr = new StreamReader(client.OpenRead("http://www.example.org/")))
                    {
                        /* POTENTIAL FLAW: Read data from a web server with WebClient */
                        /* This will be reading the first "line" of the response body,
                        * which could be very long if there are no newlines in the HTML */
                        data = sr.ReadLine();
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
            }
        }
        for (int i = 0; i < 1; i++)
        {
            int p = (int)Environment.OSVersion.Platform;
            string root;
            if (p == (int)PlatformID.Win32NT || p == (int)PlatformID.Win32Windows || p == (int)PlatformID.Win32S || p == (int)PlatformID.WinCE)
            {
                /* running on Windows */
                root = "C:\\uploads\\";
            }
            else
            {
                /* running on non-Windows */
                root = "/home/user/uploads/";
            }
            if (data != null)
            {
                /* POTENTIAL FLAW: no validation of concatenated value */
                if (File.Exists(root + data))
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(root + data))
                        {
                            IO.WriteLine(sr.ReadLine());
                        }
                    }
                    catch (IOException exceptIO)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
                    }
                }
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink by reversing the block outside the
     * for statement with the one in the for statement */
    private void GoodG2B()
    {
        string data;
        /* FIX: Use a hardcoded string */
        data = "foo";
        for (int i = 0; i < 1; i++)
        {
            int p = (int)Environment.OSVersion.Platform;
            string root;
            if (p == (int)PlatformID.Win32NT || p == (int)PlatformID.Win32Windows || p == (int)PlatformID.Win32S || p == (int)PlatformID.WinCE)
            {
                /* running on Windows */
                root = "C:\\uploads\\";
            }
            else
            {
                /* running on non-Windows */
                root = "/home/user/uploads/";
            }
            if (data != null)
            {
                /* POTENTIAL FLAW: no validation of concatenated value */
                if (File.Exists(root + data))
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(root + data))
                        {
                            IO.WriteLine(sr.ReadLine());
                        }
                    }
                    catch (IOException exceptIO)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
                    }
                }
            }
        }
    }

    public override void Good()
    {
        GoodG2B();
    }
#endif //omitgood
}
}
