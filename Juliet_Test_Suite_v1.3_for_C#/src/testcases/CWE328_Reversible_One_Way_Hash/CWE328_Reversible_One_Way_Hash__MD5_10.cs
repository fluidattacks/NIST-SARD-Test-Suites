/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE328_Reversible_One_Way_Hash__MD5_10.cs
Label Definition File: CWE328_Reversible_One_Way_Hash.label.xml
Template File: point-flaw-10.tmpl.cs
*/
/*
* @description
* CWE: 328 Reversible One Way Hash
* Sinks: MD5
*    GoodSink: SHA512
*    BadSink : MD5
* Flow Variant: 10 Control flow: if(IO.staticTrue) and if(IO.staticFalse)
*
* */

using TestCaseSupport;
using System;

using System.Text;
using System.Security.Cryptography;

namespace testcases.CWE328_Reversible_One_Way_Hash
{
class CWE328_Reversible_One_Way_Hash__MD5_10 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.staticTrue)
        {
            using (HashAlgorithm md5 = new MD5CryptoServiceProvider())
            {
                /* FLAW: Insecure cryptographic hashing algorithm (MD5) */
                byte[] textWithUTF8 = Encoding.UTF8.GetBytes("Test Input"); /* INCIDENTAL FLAW: Hard-coded input to hash algorithm */
                byte[] textWithReversibleHash = md5.ComputeHash(textWithUTF8);
                IO.WriteLine(IO.ToHex(textWithReversibleHash));
            }
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
            using (HashAlgorithm sha512 = new SHA512CryptoServiceProvider())
            {
                /* FIX: Secure cryptographic hashing algorithm (SHA-512) */
                byte[] textWithUTF8 = Encoding.UTF8.GetBytes("Test Input"); /* INCIDENTAL FLAW: Hard-coded input to hash algorithm */
                byte[] textWithReversibleHash = sha512.ComputeHash(textWithUTF8);
                IO.WriteLine(IO.ToHex(textWithReversibleHash));
            }
        }
    }

    /* good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.staticTrue)
        {
            using (HashAlgorithm sha512 = new SHA512CryptoServiceProvider())
            {
                /* FIX: Secure cryptographic hashing algorithm (SHA-512) */
                byte[] textWithUTF8 = Encoding.UTF8.GetBytes("Test Input"); /* INCIDENTAL FLAW: Hard-coded input to hash algorithm */
                byte[] textWithReversibleHash = sha512.ComputeHash(textWithUTF8);
                IO.WriteLine(IO.ToHex(textWithReversibleHash));
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
