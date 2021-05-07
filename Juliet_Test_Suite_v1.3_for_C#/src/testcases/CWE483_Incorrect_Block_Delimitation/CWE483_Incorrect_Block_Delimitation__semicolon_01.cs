/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE483_Incorrect_Block_Delimitation__semicolon_01.cs
Label Definition File: CWE483_Incorrect_Block_Delimitation.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 483 Incorrect Block Delimitation
* Sinks: semicolon
*    GoodSink: Absence of suspicious semicolon
*    BadSink : Suspicious semicolon before the if statement brace
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE483_Incorrect_Block_Delimitation
{
class CWE483_Incorrect_Block_Delimitation__semicolon_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int x, y;
        x = (new Random()).Next(3);
        y = 0;
        /* FLAW: Suspicious semicolon before the if statement brace */
        if (x == 0) ;
        {
            IO.WriteLine("x == 0");
            y = 1; /* do something other than just printing in block */
        }
        IO.WriteLine(y);
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        int x, y;
        x = (new Random()).Next(3);
        y = 0;
        /* FIX: Remove the suspicious semicolon before the if statement brace */
        if (x == 0)
        {
            IO.WriteLine("x == 0");
            y = 1; /* do something other than just printing in block */
        }
        IO.WriteLine(y);
    }
#endif //omitgood
}
}
