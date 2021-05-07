/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE369_Divide_by_Zero__float_Environment_modulo_22b.cs
Label Definition File: CWE369_Divide_by_Zero__float.label.xml
Template File: sources-sinks-22b.tmpl.cs
*/
/*
 * @description
 * CWE: 369 Divide by zero
 * BadSource: Environment Read data from an environment variable
 * GoodSource: A hardcoded non-zero number (two)
 * Sinks: modulo
 *    GoodSink: Check for zero before modulo
 *    BadSink : Modulo by a value that may be zero
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE369_Divide_by_Zero
{
class CWE369_Divide_by_Zero__float_Environment_modulo_22b
{
#if (!OMITBAD)
    public static void BadSink(float data )
    {
        if (CWE369_Divide_by_Zero__float_Environment_modulo_22a.badPublicStatic)
        {
            /* POTENTIAL FLAW: Possibly modulo by zero */
            int result = (int)(100.0 % data);
            IO.WriteLine(result);
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0.0f;
        }
    }
#endif

#if (!OMITGOOD)
    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    public static void GoodB2G1Sink(float data )
    {
        if (CWE369_Divide_by_Zero__float_Environment_modulo_22a.goodB2G1PublicStatic)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0.0f;
        }
        else
        {
            /* FIX: Check for value of or near zero before modulo */
            if (Math.Abs(data) > 0.000001)
            {
                int result = (int)(100.0 % data);
                IO.WriteLine(result);
            }
            else
            {
                IO.WriteLine("This would result in a modulo by zero");
            }
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    public static void GoodB2G2Sink(float data )
    {
        if (CWE369_Divide_by_Zero__float_Environment_modulo_22a.goodB2G2PublicStatic)
        {
            /* FIX: Check for value of or near zero before modulo */
            if (Math.Abs(data) > 0.000001)
            {
                int result = (int)(100.0 % data);
                IO.WriteLine(result);
            }
            else
            {
                IO.WriteLine("This would result in a modulo by zero");
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0.0f;
        }
    }

    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(float data )
    {
        if (CWE369_Divide_by_Zero__float_Environment_modulo_22a.goodG2BPublicStatic)
        {
            /* POTENTIAL FLAW: Possibly modulo by zero */
            int result = (int)(100.0 % data);
            IO.WriteLine(result);
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0.0f;
        }
    }
#endif
}
}
