/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE336_Same_Seed_in_PRNG__basic_01.cs
Label Definition File: CWE336_Same_Seed_in_PRNG__basic.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 336 Same Seed in PRNG
* Sinks:
*    GoodSink: no explicit seed specified
*    BadSink : hardcoded seed
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE336_Same_Seed_in_PRNG
{
class CWE336_Same_Seed_in_PRNG__basic_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int SEED = 10;
        /* FLAW: using the same seed can make the PRNG sequence predictable if the seed is known */
        Random random = new Random(SEED);
        IO.WriteLine("" + random.Next()); /* run this several times and notice that the bad values are always the same */
        IO.WriteLine("" + random.Next());
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        Random random = new Random();
        /* FIX: no explicit seed specified; produces far less predictable PRNG sequence */
        IO.WriteLine("" + random.Next());
        IO.WriteLine("" + random.Next());
    }
#endif //omitgood
}
}
