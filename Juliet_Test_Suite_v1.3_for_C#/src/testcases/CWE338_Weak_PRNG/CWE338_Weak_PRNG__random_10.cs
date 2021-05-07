/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE338_Weak_PRNG__random_10.cs
Label Definition File: CWE338_Weak_PRNG.label.xml
Template File: point-flaw-10.tmpl.cs
*/
/*
* @description
* CWE: 338 Use of Cryptographically Weak PRNG
* Sinks: random
*    GoodSink: stronger PRNG
*    BadSink : weak PRNG
* Flow Variant: 10 Control flow: if(IO.staticTrue) and if(IO.staticFalse)
*
* */

using TestCaseSupport;
using System;

using System.Security.Cryptography;
using System.Text;

namespace testcases.CWE338_Weak_PRNG
{
class CWE338_Weak_PRNG__random_10 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.staticTrue)
        {
            /* FLAW: use a weak PRNG */
            IO.WriteLine("" + new Random().NextDouble());
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* good1() changes IO.staticTrue to IO.staticFalse */
    private void Good1()
    {
        if (IO.staticFalse)
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
        if (IO.staticTrue)
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
