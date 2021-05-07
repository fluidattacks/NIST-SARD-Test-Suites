/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE396_Catch_Generic_Exception__Exception_01.cs
Label Definition File: CWE396_Catch_Generic_Exception.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 396 An overly broad catch statement may cause errors in program execution if unexpected exceptions are thrown
* Sinks: Exception
*    GoodSink: Catch specific exception type (NumberFormatException)
*    BadSink : Catch Exception, which is overly generic
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE396_Catch_Generic_Exception
{
class CWE396_Catch_Generic_Exception__Exception_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
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
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
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
#endif //omitgood
}
}
