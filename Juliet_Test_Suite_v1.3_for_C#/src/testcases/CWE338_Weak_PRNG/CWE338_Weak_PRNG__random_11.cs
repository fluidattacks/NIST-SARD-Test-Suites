/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE338_Weak_PRNG__random_11.cs
Label Definition File: CWE338_Weak_PRNG.label.xml
Template File: point-flaw-11.tmpl.cs
*/
/*
* @description
* CWE: 338 Use of Cryptographically Weak PRNG
* Sinks: random
*    GoodSink: stronger PRNG
*    BadSink : weak PRNG
* Flow Variant: 11 Control flow: if(IO.StaticReturnsTrue()) and if(IO.StaticReturnsFalse())
*
* */

using TestCaseSupport;
using System;

using System.Security.Cryptography;
using System.Text;

namespace testcases.CWE338_Weak_PRNG
{
class CWE338_Weak_PRNG__random_11 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrue())
        {
            /* FLAW: use a weak PRNG */
            IO.WriteLine("" + new Random().NextDouble());
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* good1() changes IO.StaticReturnsTrue() to IO.StaticReturnsFalse() */
    private void Good1()
    {
        if (IO.StaticReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: use a strong PRNG */
            using (RNGCryptoServiceProvider secureRandom = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[10];
                secureRandom.GetNonZeroBytes(randomNumber);
                IO.WriteLine("" + Encoding.Default.GetString(randomNumber));
            }
        }
    }

    /* good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.StaticReturnsTrue())
        {
            /* FIX: use a strong PRNG */
            using (RNGCryptoServiceProvider secureRandom = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[10];
                secureRandom.GetNonZeroBytes(randomNumber);
                IO.WriteLine("" + Encoding.Default.GetString(randomNumber));
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
