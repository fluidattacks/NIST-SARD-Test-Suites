/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__null_check_after_deref_01.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.pointflaw.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 476 NULL Pointer Dereference
* Sinks: null_check_after_deref
*    GoodSink: Do not check for null after the object has been dereferenced
*    BadSink : Check for null after the object has already been dereferenced
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__null_check_after_deref_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        {
            string myString = null;
            myString = "Hello";
            IO.WriteLine(myString.Length);
            /* FLAW: Check for null after dereferencing the object. This null check is unnecessary. */
            if (myString != null)
            {
                myString = "my, how I've changed";
            }
            IO.WriteLine(myString.Length);
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
            string myString = null;
            myString = "Hello";
            IO.WriteLine(myString.Length);
            /* FIX: Don't check for null since we wouldn't reach this line if the object was null */
            myString = "my, how I've changed";
            IO.WriteLine(myString.Length);
        }
    }
#endif //omitgood
}
}
