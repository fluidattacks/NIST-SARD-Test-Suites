/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE390_Error_Without_Action__reader_01.cs
Label Definition File: CWE390_Error_Without_Action.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 390 Detection of Error Condition Without Action
* Sinks: reader
*    GoodSink: Report and rethrow FileNotFoundException
*    BadSink : Catch FileNotFoundException, but don't do anything about it
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE390_Error_Without_Action
{
class CWE390_Error_Without_Action__reader_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
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
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
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
#endif //omitgood
}
}
