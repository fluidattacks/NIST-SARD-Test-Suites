/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE338_Weak_PRNG__random_12.cs
Label Definition File: CWE338_Weak_PRNG.label.xml
Template File: point-flaw-12.tmpl.cs
*/
/*
* @description
* CWE: 338 Use of Cryptographically Weak PRNG
* Sinks: random
*    GoodSink: stronger PRNG
*    BadSink : weak PRNG
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using System.Security.Cryptography;
using System.Text;

namespace testcases.CWE338_Weak_PRNG
{
class CWE338_Weak_PRNG__random_12 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            /* FLAW: use a weak PRNG */
            IO.WriteLine("" + new Random().NextDouble());
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
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes the "if" so that both branches use the GoodSink */
    private void Good1()
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: use a strong PRNG */
            using (RNGCryptoServiceProvider secureRandom = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[10];
                secureRandom.GetNonZeroBytes(randomNumber);
                IO.WriteLine("" + Encoding.Default.GetString(randomNumber));
            }
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

    public override void Good()
    {
        Good1();
    }
#endif //omitgood
}
}
