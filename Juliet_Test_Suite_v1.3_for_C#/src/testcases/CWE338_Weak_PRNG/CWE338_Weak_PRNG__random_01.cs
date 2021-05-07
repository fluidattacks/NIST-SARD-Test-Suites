/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE338_Weak_PRNG__random_01.cs
Label Definition File: CWE338_Weak_PRNG.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 338 Use of Cryptographically Weak PRNG
* Sinks: random
*    GoodSink: stronger PRNG
*    BadSink : weak PRNG
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Security.Cryptography;
using System.Text;

namespace testcases.CWE338_Weak_PRNG
{
class CWE338_Weak_PRNG__random_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        /* FLAW: use a weak PRNG */
        IO.WriteLine("" + new Random().NextDouble());
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        /* FIX: use a strong PRNG */
        using (RNGCryptoServiceProvider secureRandom = new RNGCryptoServiceProvider())
        {
            byte[] randomNumber = new byte[10];
            secureRandom.GetNonZeroBytes(randomNumber);
            IO.WriteLine("" + Encoding.Default.GetString(randomNumber));
        }
    }
#endif //omitgood
}
}
