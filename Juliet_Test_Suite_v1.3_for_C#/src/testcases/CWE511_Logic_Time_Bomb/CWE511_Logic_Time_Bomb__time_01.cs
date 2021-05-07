/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE511_Logic_Time_Bomb__time_01.cs
Label Definition File: CWE511_Logic_Time_Bomb.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 511 Logic Time Bomb
* Sinks: time
*    GoodSink: after a certain date, print to the console
*    BadSink : after a certain date, launch an executable
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Diagnostics;

namespace testcases.CWE511_Logic_Time_Bomb
{
class CWE511_Logic_Time_Bomb__time_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        DateTime dateNow = DateTime.Now;
        DateTime dateCheck = new DateTime(2030, 1, 1);
        /* FLAW: date triggered backdoor */
        if (dateNow > dateCheck)
        {
            using (Process myProcess = new Process())
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "c:\\windows\\system32\\evil.exe";
                myProcess.Start();
            }
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
        DateTime dateNow = DateTime.Now;
        DateTime dateCheck = new DateTime(2030, 1, 1);
        /* FIX: no backdoor exists */
        if (dateNow > dateCheck)
        {
            IO.WriteLine("Sorry, your license has expired.  Please contact support.");
        }
    }
#endif //omitgood
}
}
