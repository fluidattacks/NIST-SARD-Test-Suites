/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE396_Catch_Generic_Exception__Exception_05.cs
Label Definition File: CWE396_Catch_Generic_Exception.label.xml
Template File: point-flaw-05.tmpl.cs
*/
/*
* @description
* CWE: 396 An overly broad catch statement may cause errors in program execution if unexpected exceptions are thrown
* Sinks: Exception
*    GoodSink: Catch specific exception type (NumberFormatException)
*    BadSink : Catch Exception, which is overly generic
* Flow Variant: 05 Control flow: if(privateTrue) and if(privateFalse)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE396_Catch_Generic_Exception
{
class CWE396_Catch_Generic_Exception__Exception_05 : AbstractTestCase
{
    /* The two variables below are not defined as "readonly", but are never
     * assigned any other value, so a tool should be able to identify that
     * reads of these will always return their initialized values.
     */
    private bool privateTrue = true;
    private bool privateFalse = false;
#if (!OMITBAD)
    public override void Bad()
    {
        if (privateTrue)
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
    /* Good1() changes privateTrue to privateFalse */
    private void Good1()
    {
        if (privateFalse)
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

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (privateTrue)
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
