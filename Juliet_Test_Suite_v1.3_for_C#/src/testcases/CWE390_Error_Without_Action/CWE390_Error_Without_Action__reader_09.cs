/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE390_Error_Without_Action__reader_09.cs
Label Definition File: CWE390_Error_Without_Action.label.xml
Template File: point-flaw-09.tmpl.cs
*/
/*
* @description
* CWE: 390 Detection of Error Condition Without Action
* Sinks: reader
*    GoodSink: Report and rethrow FileNotFoundException
*    BadSink : Catch FileNotFoundException, but don't do anything about it
* Flow Variant: 09 Control flow: if(IO.STATIC_READONLY_TRUE) and if(IO.STATIC_READONLY_FALSE)
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE390_Error_Without_Action
{
class CWE390_Error_Without_Action__reader_09 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.STATIC_READONLY_TRUE)
        {
            int p = (int)Environment.OSVersion.Platform;
            string path = null;
            if (p == (int)PlatformID.Win32NT || p == (int)PlatformID.Win32Windows || p == (int)PlatformID.Win32S || p == (int)PlatformID.WinCE)
            {
                /* running on Windows */
                path = "C:\\doesntexistandneverwill.txt";
            }
            else
            {
                /* running on non-Windows */
                path = "/home/user/doesntexistandneverwill.txt";
            }
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    IO.WriteLine("Created a StreamReader");
                }
            }
            catch (FileNotFoundException exceptFileNotFound)
            {
                /* FLAW: do nothing if the file doesn't exist */
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes IO.STATIC_READONLY_TRUE to IO.STATIC_READONLY_FALSE */
    private void Good1()
    {
        if (IO.STATIC_READONLY_FALSE)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            int p = (int)Environment.OSVersion.Platform;
            string path = null;
            if (p == (int)PlatformID.Win32NT || p == (int)PlatformID.Win32Windows || p == (int)PlatformID.Win32S || p == (int)PlatformID.WinCE)
            {
                /* running on Windows */
                path = "C:\\doesntexistandneverwill.txt";
            }
            else
            {
                /* running on non-Windows */
                path = "/home/user/doesntexistandneverwill.txt";
            }
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    IO.WriteLine("Created a StreamReader");
                }
            }
            catch (FileNotFoundException exceptFileNotFound)
            {
                /* FIX: report read failure and rethrow */
                IO.WriteLine("Error reading path: " + exceptFileNotFound.ToString());
                throw exceptFileNotFound;
            }
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.STATIC_READONLY_TRUE)
        {
            int p = (int)Environment.OSVersion.Platform;
            string path = null;
            if (p == (int)PlatformID.Win32NT || p == (int)PlatformID.Win32Windows || p == (int)PlatformID.Win32S || p == (int)PlatformID.WinCE)
            {
                /* running on Windows */
                path = "C:\\doesntexistandneverwill.txt";
            }
            else
            {
                /* running on non-Windows */
                path = "/home/user/doesntexistandneverwill.txt";
            }
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    IO.WriteLine("Created a StreamReader");
                }
            }
            catch (FileNotFoundException exceptFileNotFound)
            {
                /* FIX: report read failure and rethrow */
                IO.WriteLine("Error reading path: " + exceptFileNotFound.ToString());
                throw exceptFileNotFound;
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
