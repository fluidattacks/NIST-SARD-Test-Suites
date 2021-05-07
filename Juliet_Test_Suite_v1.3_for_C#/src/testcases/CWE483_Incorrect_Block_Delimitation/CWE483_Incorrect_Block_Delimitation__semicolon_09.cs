/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE483_Incorrect_Block_Delimitation__semicolon_09.cs
Label Definition File: CWE483_Incorrect_Block_Delimitation.label.xml
Template File: point-flaw-09.tmpl.cs
*/
/*
* @description
* CWE: 483 Incorrect Block Delimitation
* Sinks: semicolon
*    GoodSink: Absence of suspicious semicolon
*    BadSink : Suspicious semicolon before the if statement brace
* Flow Variant: 09 Control flow: if(IO.STATIC_READONLY_TRUE) and if(IO.STATIC_READONLY_FALSE)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE483_Incorrect_Block_Delimitation
{
class CWE483_Incorrect_Block_Delimitation__semicolon_09 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.STATIC_READONLY_TRUE)
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
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes IO.STATIC_READONLY_TRUE to IO.STATIC_READONLY_FALSE */
    private void Good1()
    {
        if (IO.STATIC_READONLY_FALSE)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
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
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.STATIC_READONLY_TRUE)
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
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
