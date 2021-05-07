/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE396_Catch_Generic_Exception__Exception_11.cs
Label Definition File: CWE396_Catch_Generic_Exception.label.xml
Template File: point-flaw-11.tmpl.cs
*/
/*
* @description
* CWE: 396 An overly broad catch statement may cause errors in program execution if unexpected exceptions are thrown
* Sinks: Exception
*    GoodSink: Catch specific exception type (NumberFormatException)
*    BadSink : Catch Exception, which is overly generic
* Flow Variant: 11 Control flow: if(IO.StaticReturnsTrue()) and if(IO.StaticReturnsFalse())
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE396_Catch_Generic_Exception
{
class CWE396_Catch_Generic_Exception__Exception_11 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrue())
        {
            try
            {
                int.Parse("Test"); /* Will throw FormatException */
            }
            catch (Exception exception) /* FLAW: Catch Exception, which is overly generic */
            {
                IO.WriteLine("Caught Exception");
                throw exception; /* Rethrow */
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* good1() changes IO.StaticReturnsTrue() to IO.StaticReturnsFalse() */
    private void Good1()
    {
        if (IO.StaticReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            try
            {
                int.Parse("Test"); /* Will throw FormatException */
            }
            catch (FormatException exceptNumberFormat) /* FIX: Catch FormatException */
            {
                IO.WriteLine("Caught Exception");
                throw exceptNumberFormat; /* Rethrow */
            }
        }
    }

    /* good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.StaticReturnsTrue())
        {
            try
            {
                int.Parse("Test"); /* Will throw FormatException */
            }
            catch (FormatException exceptNumberFormat) /* FIX: Catch FormatException */
            {
                IO.WriteLine("Caught Exception");
                throw exceptNumberFormat; /* Rethrow */
            }
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
