/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE390_Error_Without_Action__CreateDirectory_04.cs
Label Definition File: CWE390_Error_Without_Action.label.xml
Template File: point-flaw-04.tmpl.cs
*/
/*
* @description
* CWE: 390 Detection of Error Condition Without Action
* Sinks: CreateDirectory
*    GoodSink: Throw Exception if newDirectory cannot be created
*    BadSink : Do nothing if newDirectory cannot be created
* Flow Variant: 04 Control flow: if(PRIVATE_CONST_TRUE) and if(PRIVATE_CONST_FALSE)
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE390_Error_Without_Action
{
class CWE390_Error_Without_Action__CreateDirectory_04 : AbstractTestCase
{
    /* The two variables below are declared "const", so a tool should
     * be able to identify that reads of these will always return their
     * initialized values.
     */
    private const bool PRIVATE_CONST_TRUE = true;
    private const bool PRIVATE_CONST_FALSE = false;
#if (!OMITBAD)
    public override void Bad()
    {
        if (PRIVATE_CONST_TRUE)
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
    /* Good1() changes PRIVATE_CONST_TRUE to PRIVATE_CONST_FALSE */
    private void Good1()
    {
        if (PRIVATE_CONST_FALSE)
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

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (PRIVATE_CONST_TRUE)
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
