/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE789_Uncontrolled_Mem_Alloc__heap_01.cs
Label Definition File: CWE789_Uncontrolled_Mem_Alloc__heap.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 789 Uncontrolled Memory Allocation
* Sinks:
*    GoodSink: check for memory consumption
*    BadSink : no check for memory consumption
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Collections;

namespace testcases.CWE789_Uncontrolled_Mem_Alloc
{
class CWE789_Uncontrolled_Mem_Alloc__heap_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        ArrayList byteArrayList = new ArrayList();
        while(true)
        {
            /* FLAW: continued consumption of memory in 10MB XXXXXs with no verification of available memory */
            byte[] byteArray = new byte[10485760];
            byteArrayList.Add(byteArray);
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
        ArrayList byteArrayList = new ArrayList();
        while (true)
        {
            try
            {
                /* consume memory in 10MB chunks */
                byte[] byteArray = new byte[10485760];
                byteArrayList.Add(byteArray);
            }
            /* FIX: check memory consumption */
            catch (OutOfMemoryException e)
            {
                IO.WriteLine("Not enough memory to go again");
                break;
            }
        }
    }
#endif //omitgood
}
}
