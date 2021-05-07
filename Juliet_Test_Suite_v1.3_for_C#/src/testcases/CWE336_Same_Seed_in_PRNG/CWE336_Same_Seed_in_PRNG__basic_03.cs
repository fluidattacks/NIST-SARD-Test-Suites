/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE336_Same_Seed_in_PRNG__basic_03.cs
Label Definition File: CWE336_Same_Seed_in_PRNG__basic.label.xml
Template File: point-flaw-03.tmpl.cs
*/
/*
* @description
* CWE: 336 Same Seed in PRNG
* Sinks:
*    GoodSink: no explicit seed specified
*    BadSink : hardcoded seed
* Flow Variant: 03 Control flow: if(5==5) and if(5!=5)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE336_Same_Seed_in_PRNG
{
class CWE336_Same_Seed_in_PRNG__basic_03 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (5 == 5)
        {
            int SEED = 10;
            /* FLAW: using the same seed can make the PRNG sequence predictable if the seed is known */
            Random random = new Random(SEED);
            IO.WriteLine("" + random.Next()); /* run this several times and notice that the bad values are always the same */
            IO.WriteLine("" + random.Next());
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes 5==5 to 5!=5 */
    private void Good1()
    {
        if (5 != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            Random random = new Random();
            /* FIX: no explicit seed specified; produces far less predictable PRNG sequence */
            IO.WriteLine("" + random.Next());
            IO.WriteLine("" + random.Next());
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (5 == 5)
        {
            Random random = new Random();
            /* FIX: no explicit seed specified; produces far less predictable PRNG sequence */
            IO.WriteLine("" + random.Next());
            IO.WriteLine("" + random.Next());
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
