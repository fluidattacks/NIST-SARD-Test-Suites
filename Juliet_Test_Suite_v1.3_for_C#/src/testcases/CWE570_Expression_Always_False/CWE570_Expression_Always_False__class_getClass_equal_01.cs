/*
 * @description statement always evaluates to false
 * 
 * */

using System;
using TestCaseSupport;
using System.Security.Cryptography;
using System.Collections;

namespace testcases.CWE570_Expression_Always_False
{
    class CWE570_Expression_Always_False__class_getClass_equal_01 : AbstractTestCase
    {
#if (!OMITBAD)
        public override void Bad()
        {
            /* FLAW: always evaluates to false */
            Random random = new Random();
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

            if (random.GetType() == rngCsp.GetType())
            {
                IO.WriteLine("never prints");
            }
        }
#endif // OMITBAD

#if (!OMITGOOD)
        public override void Good()
        {
            Good1();
        }

        private void Good1()
        {
            ArrayList objectArray = new ArrayList();
            objectArray.Add(new Random());
            objectArray.Add(new RNGCryptoServiceProvider());
            objectArray.Add(new RNGCryptoServiceProvider());

            int intSecureRandom = (new Random()).Next(3);

            /* FIX: may evaluate to true or false */
            if (objectArray[1].GetType() == objectArray[intSecureRandom].GetType())
            {
                IO.WriteLine("sometimes prints");
            }
        }
#endif // OMITGOOD

}
}
