/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE114_Process_Control__basic_01.cs
Label Definition File: CWE114_Process_Control__basic.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 114 Process Control
* Sinks:
*    GoodSink: use Assembly.LoadFrom() to load a library
*    BadSink : use Assembly.Load() to load a library
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Reflection;

namespace testcases.CWE114_Process_Control
{
class CWE114_Process_Control__basic_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        string libraryName = "test.dll";
        /* FLAW: Attempt to load a library with Assembly.Load() without the full path to the library. */
        Assembly.Load(libraryName);
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
        string root;
        string libraryName = "test.dll";
        if (p == (int)PlatformID.Win32NT || p == (int)PlatformID.Win32Windows || p == (int)PlatformID.Win32S || p == (int)PlatformID.WinCE)
        {
            /* running on Windows */
            root = "C:\\libs\\";
        }
        else
        {
            /* running on non-Windows */
            root = "/home/user/libs/";
        }
        /* FIX: Use Assembly.LoadFrom() which allows you to specify a full path to the library */
        Assembly.LoadFrom(root + libraryName);
    }
#endif //omitgood
}
}
