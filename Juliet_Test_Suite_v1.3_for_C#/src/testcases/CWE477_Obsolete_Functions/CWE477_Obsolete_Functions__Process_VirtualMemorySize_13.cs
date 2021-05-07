/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE477_Obsolete_Functions__Process_VirtualMemorySize_13.cs
Label Definition File: CWE477_Obsolete_Functions.label.xml
Template File: point-flaw-13.tmpl.cs
*/
/*
* @description
* CWE: 477 Use of Obsolete Functions
* Sinks: Process_VirtualMemorySize
*    GoodSink: Use of preferred System.Diagnostics.Process.VirtualMemorySize64
*    BadSink : Use of deprecated System.Diagnostics.Process.VirtualMemorySize
* Flow Variant: 13 Control flow: if(IO.STATIC_READONLY_FIVE==5) and if(IO.STATIC_READONLY_FIVE!=5)
*
* */

using TestCaseSupport;
using System;

using System.Diagnostics;

namespace testcases.CWE477_Obsolete_Functions
{
class CWE477_Obsolete_Functions__Process_VirtualMemorySize_13 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.STATIC_READONLY_FIVE == 5)
        {
            /* FLAW: Use of deprecated Process.VirtualMemorySize method */
            using (Process myProcess = new Process())
            {
                int vms = myProcess.VirtualMemorySize;
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes IO.STATIC_READONLY_FIVE==5 to IO.STATIC_READONLY_FIVE!=5 */
    private void Good1()
    {
        if (IO.STATIC_READONLY_FIVE != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: Use preferred Process.VirtualMemorySize64 method */
            using (Process myProcess = new Process())
            {
                long vms = myProcess.VirtualMemorySize64;
            }
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.STATIC_READONLY_FIVE == 5)
        {
            /* FIX: Use preferred Process.VirtualMemorySize64 method */
            using (Process myProcess = new Process())
            {
                long vms = myProcess.VirtualMemorySize64;
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
