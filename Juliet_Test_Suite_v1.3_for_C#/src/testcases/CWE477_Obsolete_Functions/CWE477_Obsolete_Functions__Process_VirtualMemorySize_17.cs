/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE477_Obsolete_Functions__Process_VirtualMemorySize_17.cs
Label Definition File: CWE477_Obsolete_Functions.label.xml
Template File: point-flaw-17.tmpl.cs
*/
/*
* @description
* CWE: 477 Use of Obsolete Functions
* Sinks: Process_VirtualMemorySize
*    GoodSink: Use of preferred System.Diagnostics.Process.VirtualMemorySize64
*    BadSink : Use of deprecated System.Diagnostics.Process.VirtualMemorySize
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.Diagnostics;

namespace testcases.CWE477_Obsolete_Functions
{
class CWE477_Obsolete_Functions__Process_VirtualMemorySize_17 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        for(int j = 0; j < 1; j++)
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
    /* Good1() use the GoodSinkBody in the for statement */
    private void Good1()
    {
        for(int k = 0; k < 1; k++)
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
