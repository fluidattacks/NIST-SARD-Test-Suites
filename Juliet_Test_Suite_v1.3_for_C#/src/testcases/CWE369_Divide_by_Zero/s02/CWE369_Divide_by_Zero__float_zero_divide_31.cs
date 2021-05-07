/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE369_Divide_by_Zero__float_zero_divide_31.cs
Label Definition File: CWE369_Divide_by_Zero__float.label.xml
Template File: sources-sinks-31.tmpl.cs
*/
/*
 * @description
 * CWE: 369 Divide by zero
 * BadSource: zero Set data to a hardcoded value of zero
 * GoodSource: A hardcoded non-zero number (two)
 * Sinks: divide
 *    GoodSink: Check for zero before dividing
 *    BadSink : Dividing by a value that may be zero
 * Flow Variant: 31 Data flow: make a copy of data within the same method
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE369_Divide_by_Zero
{
class CWE369_Divide_by_Zero__float_zero_divide_31 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        float dataCopy;
        {
            float data;
            data = 0.0f; /* POTENTIAL FLAW: data is set to zero */
            dataCopy = data;
        }
        {
            float data = dataCopy;
            /* POTENTIAL FLAW: Possibly divide by zero */
            int result = (int)(100.0 / data);
            IO.WriteLine(result);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        float dataCopy;
        {
            float data;
            /* FIX: Use a hardcoded number that won't a divide by zero */
            data = 2.0f;
            dataCopy = data;
        }
        {
            float data = dataCopy;
            /* POTENTIAL FLAW: Possibly divide by zero */
            int result = (int)(100.0 / data);
            IO.WriteLine(result);
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        float dataCopy;
        {
            float data;
            data = 0.0f; /* POTENTIAL FLAW: data is set to zero */
            dataCopy = data;
        }
        {
            float data = dataCopy;
            /* FIX: Check for value of or near zero before dividing */
            if (Math.Abs(data) > 0.000001)
            {
                int result = (int)(100.0 / data);
                IO.WriteLine(result);
            }
            else
            {
                IO.WriteLine("This would result in a divide by zero");
            }
        }
    }
#endif //omitgood
}
}
