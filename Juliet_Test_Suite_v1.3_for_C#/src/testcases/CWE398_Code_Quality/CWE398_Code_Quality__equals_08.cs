/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE398_Code_Quality__equals_08.cs
Label Definition File: CWE398_Code_Quality.label.xml
Template File: point-flaw-08.tmpl.cs
*/
/*
* @description
* CWE: 398 One of the 7 Pernicious Kingdoms - Code Quality
* Sinks: equals
*    GoodSink: Set a variable equal to another variable
*    BadSink : Setting a variable equal to itself has no effect
* Flow Variant: 08 Control flow: if(PrivateReturnsTrue()) and if(PrivateReturnsFalse())
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE398_Code_Quality
{
class CWE398_Code_Quality__equals_08 : AbstractTestCase
{
    /* The methods below always return the same value, so a tool
     * should be able to figure out that every call to these
     * methods will return true or return false.
     */
    private static bool PrivateReturnsTrue()
    {
        return true;
    }

    private static bool PrivateReturnsFalse()
    {
        return false;
    }
#if (!OMITBAD)
    public override void Bad()
    {
        if (PrivateReturnsTrue())
        {
            int intOne = 1;
            IO.WriteLine(intOne);
            /* FLAW: The statement below has no effect since it is setting a variable to itself */
            intOne = intOne;
            IO.WriteLine(intOne);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes PrivateReturnsTrue() to privateReturnsFalse() */
    private void Good1()
    {
        if (PrivateReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            int intOne = 1, intFive = 5;
            IO.WriteLine(intOne);
            /* FIX: Assign intFive to intOne */
            intOne = intFive;
            IO.WriteLine(intOne);
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (PrivateReturnsTrue())
        {
            int intOne = 1, intFive = 5;
            IO.WriteLine(intOne);
            /* FIX: Assign intFive to intOne */
            intOne = intFive;
            IO.WriteLine(intOne);
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
