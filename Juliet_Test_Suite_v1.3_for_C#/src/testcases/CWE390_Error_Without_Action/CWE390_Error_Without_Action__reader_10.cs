/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE390_Error_Without_Action__reader_10.cs
Label Definition File: CWE390_Error_Without_Action.label.xml
Template File: point-flaw-10.tmpl.cs
*/
/*
* @description
* CWE: 390 Detection of Error Condition Without Action
* Sinks: reader
*    GoodSink: Report and rethrow FileNotFoundException
*    BadSink : Catch FileNotFoundException, but don't do anything about it
* Flow Variant: 10 Control flow: if(IO.staticTrue) and if(IO.staticFalse)
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE390_Error_Without_Action
{
class CWE390_Error_Without_Action__reader_10 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.staticTrue)
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

    /* good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.staticTrue)
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
