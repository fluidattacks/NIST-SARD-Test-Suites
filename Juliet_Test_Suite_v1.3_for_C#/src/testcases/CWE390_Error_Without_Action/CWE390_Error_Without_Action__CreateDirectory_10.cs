/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE390_Error_Without_Action__CreateDirectory_10.cs
Label Definition File: CWE390_Error_Without_Action.label.xml
Template File: point-flaw-10.tmpl.cs
*/
/*
* @description
* CWE: 390 Detection of Error Condition Without Action
* Sinks: CreateDirectory
*    GoodSink: Throw Exception if newDirectory cannot be created
*    BadSink : Do nothing if newDirectory cannot be created
* Flow Variant: 10 Control flow: if(IO.staticTrue) and if(IO.staticFalse)
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE390_Error_Without_Action
{
class CWE390_Error_Without_Action__CreateDirectory_10 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.staticTrue)
        {
            int p = (int)Environment.OSVersion.Platform;
            string newDirectory = null;
            if (p == (int)PlatformID.Win32NT || p == (int)PlatformID.Win32Windows || p == (int)PlatformID.Win32S || p == (int)PlatformID.WinCE)
            {
                /* running on Windows */
                newDirectory = "C:\\lvl_1\\lvl_2\\lvl_3\\";
            }
            else
            {
                /* running on non-Windows */
                newDirectory = "/home/user/lvl_1/lvl_2/lvl_3/";
            }
            if (!Directory.CreateDirectory(newDirectory).Exists)
            {
                /* FLAW: do nothing if newDirectory cannot be created */
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* good1() changes IO.staticTrue to IO.staticFalse */
    private void Good1()
    {
        if (IO.staticFalse)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            int p = (int)Environment.OSVersion.Platform;
            string newDirectory = null;
            if (p == (int)PlatformID.Win32NT || p == (int)PlatformID.Win32Windows || p == (int)PlatformID.Win32S || p == (int)PlatformID.WinCE)
            {
                /* running on Windows */
                newDirectory = "C:\\lvl_1\\lvl_2\\lvl_3\\";
            }
            else
            {
                /* running on non-Windows */
                newDirectory = "/home/user/lvl_1/lvl_2/lvl_3/";
            }
            /* FIX: report the CreateDirectory failure and throw a new Exception */
            try
            {
                Directory.CreateDirectory(newDirectory);
            }
            catch (Exception except)
            {
                throw except;
            }
        }
    }

    /* good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.staticTrue)
        {
            int p = (int)Environment.OSVersion.Platform;
            string newDirectory = null;
            if (p == (int)PlatformID.Win32NT || p == (int)PlatformID.Win32Windows || p == (int)PlatformID.Win32S || p == (int)PlatformID.WinCE)
            {
                /* running on Windows */
                newDirectory = "C:\\lvl_1\\lvl_2\\lvl_3\\";
            }
            else
            {
                /* running on non-Windows */
                newDirectory = "/home/user/lvl_1/lvl_2/lvl_3/";
            }
            /* FIX: report the CreateDirectory failure and throw a new Exception */
            try
            {
                Directory.CreateDirectory(newDirectory);
            }
            catch (Exception except)
            {
                throw except;
            }
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
