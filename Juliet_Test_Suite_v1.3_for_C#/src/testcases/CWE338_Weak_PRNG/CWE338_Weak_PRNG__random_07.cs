/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE338_Weak_PRNG__random_07.cs
Label Definition File: CWE338_Weak_PRNG.label.xml
Template File: point-flaw-07.tmpl.cs
*/
/*
* @description
* CWE: 338 Use of Cryptographically Weak PRNG
* Sinks: random
*    GoodSink: stronger PRNG
*    BadSink : weak PRNG
* Flow Variant: 07 Control flow: if(privateFive==5) and if(privateFive!=5)
*
* */

using TestCaseSupport;
using System;

using System.Security.Cryptography;
using System.Text;

namespace testcases.CWE338_Weak_PRNG
{
class CWE338_Weak_PRNG__random_07 : AbstractTestCase
{
    /* The variable below is not declared "readonly", but is never assigned
     * any other value so a tool should be able to identify that reads of
     * this will always give its initialized value.
     */
    private int privateFive = 5;
#if (!OMITBAD)
    public override void Bad()
    {
        if (privateFive == 5)
        {
            /* FLAW: use a weak PRNG */
            IO.WriteLine("" + new Random().NextDouble());
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes privateFive==5 to privateFive!=5 */
    private void Good1()
    {
        if (privateFive != 5)
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

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (privateFive == 5)
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
