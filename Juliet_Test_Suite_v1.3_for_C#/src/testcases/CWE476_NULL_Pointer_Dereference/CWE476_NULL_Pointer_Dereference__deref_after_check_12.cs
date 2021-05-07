/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__deref_after_check_12.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.pointflaw.label.xml
Template File: point-flaw-12.tmpl.cs
*/
/*
* @description
* CWE: 476 NULL Pointer Dereference
* Sinks: deref_after_check
*    GoodSink: Do not dereference an object if it is null
*    BadSink : Dereference after checking to see if an object is null
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__deref_after_check_12 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrueOrFalse())
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
        else
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
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes the "if" so that both branches use the GoodSink */
    private void Good1()
    {
        if (IO.StaticReturnsTrueOrFalse())
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
        else
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
    }

    public override void Good()
    {
        Good1();
    }
#endif //omitgood
}
}
