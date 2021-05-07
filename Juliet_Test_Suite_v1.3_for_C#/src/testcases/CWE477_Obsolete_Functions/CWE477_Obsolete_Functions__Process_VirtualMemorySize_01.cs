/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE477_Obsolete_Functions__Process_VirtualMemorySize_01.cs
Label Definition File: CWE477_Obsolete_Functions.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 477 Use of Obsolete Functions
* Sinks: Process_VirtualMemorySize
*    GoodSink: Use of preferred System.Diagnostics.Process.VirtualMemorySize64
*    BadSink : Use of deprecated System.Diagnostics.Process.VirtualMemorySize
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Diagnostics;

namespace testcases.CWE477_Obsolete_Functions
{
class CWE477_Obsolete_Functions__Process_VirtualMemorySize_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        /* FLAW: Use of deprecated Process.VirtualMemorySize method */
        using (Process myProcess = new Process())
        {
            int vms = myProcess.VirtualMemorySize;
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
        /* FIX: Use preferred Process.VirtualMemorySize64 method */
        using (Process myProcess = new Process())
        {
            long vms = myProcess.VirtualMemorySize64;
        }
    }
#endif //omitgood
}
}
