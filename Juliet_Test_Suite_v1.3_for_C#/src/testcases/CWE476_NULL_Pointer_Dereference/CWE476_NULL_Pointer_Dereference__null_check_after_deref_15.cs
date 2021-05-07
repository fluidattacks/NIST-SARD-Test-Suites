/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__null_check_after_deref_15.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.pointflaw.label.xml
Template File: point-flaw-15.tmpl.cs
*/
/*
* @description
* CWE: 476 NULL Pointer Dereference
* Sinks: null_check_after_deref
*    GoodSink: Do not check for null after the object has been dereferenced
*    BadSink : Check for null after the object has already been dereferenced
* Flow Variant: 15 Control flow: switch(7)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__null_check_after_deref_15 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        switch (7)
        {
        case 7:
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
        break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() change the switch to switch(8) */
    private void Good1()
    {
        switch (8)
        {
        case 7:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        default:
        {
            string myString = null;
            myString = "Hello";
            IO.WriteLine(myString.Length);
            /* FIX: Don't check for null since we wouldn't reach this line if the object was null */
            myString = "my, how I've changed";
            IO.WriteLine(myString.Length);
        }
        break;
        }
    }

    /* Good2() reverses the blocks in the switch  */
    private void Good2()
    {
        switch (7)
        {
        case 7:
        {
            string myString = null;
            myString = "Hello";
            IO.WriteLine(myString.Length);
            /* FIX: Don't check for null since we wouldn't reach this line if the object was null */
            myString = "my, how I've changed";
            IO.WriteLine(myString.Length);
        }
        break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
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
