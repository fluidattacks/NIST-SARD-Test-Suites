/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE395_Catch_NullPointerException__basic_01.cs
Label Definition File: CWE395_Catch_NullPointerException__basic.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 395 Use of NullPointerException Catch to Detect NULL Pointer Dereference
* Sinks:
*    GoodSink: Check for null before taking action
*    BadSink : Catch NullReferenceException to detect null
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE395_Catch_NullPointerException
{
class CWE395_Catch_NullPointerException__basic_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        String catchingNull = null;
        if (new Random().Next(2) == 1)
        {
            catchingNull = "CWE395";
        }
        try
        {
            /* INCIDENTAL: Possible Null Pointer Dereference (CWE476 / CWE690) */
            if (catchingNull.Equals("CWE395"))
            {
                IO.WriteLine("catchingNull is CWE395");
            }
        }
        catch (NullReferenceException exceptNullPointer) /* FLAW: Use of catch block to detect null dereferences */
        {
            IO.WriteLine("catchingNull is null");
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
        String catchingNull = null;
        if (new Random().Next(2) == 1)
        {
            catchingNull = "CWE395";
        }
        if (catchingNull != null) /* FIX: Check for null before calling equals() */
        {
            if (catchingNull.Equals("CWE395"))
            {
                IO.WriteLine("catchingNull is CWE395");
            }
        }
        else
        {
            IO.WriteLine("catchingNull is null");
        }
    }
#endif //omitgood
}
}
