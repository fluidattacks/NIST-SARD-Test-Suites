/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE477_Obsolete_Functions__Process_VirtualMemorySize_12.cs
Label Definition File: CWE477_Obsolete_Functions.label.xml
Template File: point-flaw-12.tmpl.cs
*/
/*
* @description
* CWE: 477 Use of Obsolete Functions
* Sinks: Process_VirtualMemorySize
*    GoodSink: Use of preferred System.Diagnostics.Process.VirtualMemorySize64
*    BadSink : Use of deprecated System.Diagnostics.Process.VirtualMemorySize
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using System.Diagnostics;

namespace testcases.CWE477_Obsolete_Functions
{
class CWE477_Obsolete_Functions__Process_VirtualMemorySize_12 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            /* FLAW: Use of deprecated Process.VirtualMemorySize method */
            using (Process myProcess = new Process())
            {
                int vms = myProcess.VirtualMemorySize;
            }
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
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes the "if" so that both branches use the GoodSink */
    private void Good1()
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: Use preferred Process.VirtualMemorySize64 method */
            using (Process myProcess = new Process())
            {
                long vms = myProcess.VirtualMemorySize64;
            }
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

    public override void Good()
    {
        Good1();
    }
#endif //omitgood
}
}
