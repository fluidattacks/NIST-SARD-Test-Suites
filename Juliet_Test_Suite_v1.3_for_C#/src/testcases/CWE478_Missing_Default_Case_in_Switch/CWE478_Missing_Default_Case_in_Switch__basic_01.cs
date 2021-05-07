/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE478_Missing_Default_Case_in_Switch__basic_01.cs
Label Definition File: CWE478_Missing_Default_Case_in_Switch__basic.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 478 Missing Default Case in Switch
* Sinks:
*    GoodSink: Use default case in switch statement
*    BadSink : No default case in a switch statement
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE478_Missing_Default_Case_in_Switch
{
class CWE478_Missing_Default_Case_in_Switch__basic_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        string stringIntValue = "";
        int x = (new Random()).Next(3);
        switch (x)
        {
        case 0:
            stringIntValue = "0";
            break;
        case 1:
            stringIntValue = "1";
            break;
            /* FLAW: x could be 2, and there is no 'default' case for that */
        }
        IO.WriteLine(stringIntValue);
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        string stringIntValue = "";
        int x = (new Random()).Next(3);
        switch (x)
        {
        case 0:
            stringIntValue = "0";
            break;
        case 1:
            stringIntValue = "1";
            break;
            /* FIX: Add a default case */
        default:
            stringIntValue = "2";
            break;
        }
        IO.WriteLine(stringIntValue);
    }
#endif //omitgood
}
}
