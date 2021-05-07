/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__deref_after_check_01.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.pointflaw.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 476 NULL Pointer Dereference
* Sinks: deref_after_check
*    GoodSink: Do not dereference an object if it is null
*    BadSink : Dereference after checking to see if an object is null
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__deref_after_check_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        {
            /* FLAW: Check for null, but still dereference the object */
            string myString = null;
            if (myString == null)
            {
                IO.WriteLine(myString.Length);
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
        {
            /* FIX: Check for null and do not dereference the object if it is null */
            string myString = null;
            if (myString == null)
            {
                IO.WriteLine("The string is null");
            }
        }
    }
#endif //omitgood
}
}
