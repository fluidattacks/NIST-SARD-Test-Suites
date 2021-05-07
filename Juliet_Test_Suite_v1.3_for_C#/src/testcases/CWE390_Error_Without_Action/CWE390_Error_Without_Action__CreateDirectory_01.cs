/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE390_Error_Without_Action__CreateDirectory_01.cs
Label Definition File: CWE390_Error_Without_Action.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 390 Detection of Error Condition Without Action
* Sinks: CreateDirectory
*    GoodSink: Throw Exception if newDirectory cannot be created
*    BadSink : Do nothing if newDirectory cannot be created
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE390_Error_Without_Action
{
class CWE390_Error_Without_Action__CreateDirectory_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
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
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
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
#endif //omitgood
}
}
