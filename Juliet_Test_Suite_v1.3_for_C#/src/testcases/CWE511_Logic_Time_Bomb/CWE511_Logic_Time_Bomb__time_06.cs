/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE511_Logic_Time_Bomb__time_06.cs
Label Definition File: CWE511_Logic_Time_Bomb.label.xml
Template File: point-flaw-06.tmpl.cs
*/
/*
* @description
* CWE: 511 Logic Time Bomb
* Sinks: time
*    GoodSink: after a certain date, print to the console
*    BadSink : after a certain date, launch an executable
* Flow Variant: 06 Control flow: if(PRIVATE_CONST_FIVE==5) and if(PRIVATE_CONST_FIVE!=5)
*
* */

using TestCaseSupport;
using System;

using System.Diagnostics;

namespace testcases.CWE511_Logic_Time_Bomb
{
class CWE511_Logic_Time_Bomb__time_06 : AbstractTestCase
{
    /* The variable below is declared "const", so a tool should be able
     * to identify that reads of this will always give its initialized
     * value.
     */
    private const int PRIVATE_CONST_FIVE = 5;
#if (!OMITBAD)
    public override void Bad()
    {
        if (PRIVATE_CONST_FIVE == 5)
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
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes PRIVATE_CONST_FIVE==5 to PRIVATE_CONST_FIVE!=5 */
    private void Good1()
    {
        if (PRIVATE_CONST_FIVE != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            DateTime dateNow = DateTime.Now;
            DateTime dateCheck = new DateTime(2030, 1, 1);
            /* FIX: no backdoor exists */
            if (dateNow > dateCheck)
            {
                IO.WriteLine("Sorry, your license has expired.  Please contact support.");
            }
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (PRIVATE_CONST_FIVE == 5)
        {
            DateTime dateNow = DateTime.Now;
            DateTime dateCheck = new DateTime(2030, 1, 1);
            /* FIX: no backdoor exists */
            if (dateNow > dateCheck)
            {
                IO.WriteLine("Sorry, your license has expired.  Please contact support.");
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
