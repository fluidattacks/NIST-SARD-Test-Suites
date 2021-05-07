/*
 * @description Missing Release of Resource After Effective Lifetime.  Performs some, but not all, necessary resource cleanup (StreamReader is not closed).
 * 
 * */

using System;
using System.IO;
using TestCaseSupport;

namespace testcases.CWE772_Missing_Release_of_Resource
{
    class CWE772_Missing_Release_of_Resource__console_StreamReader_01 : AbstractTestCase
    {
#if (!OMITBAD)
        public override void Bad()
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(Console.OpenStandardInput());
                string readString = sr.ReadLine();

                IO.WriteLine(readString);
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
            }
            /* FLAW: Streams are not closed */
        }
#endif // OMITBAD

#if (!OMITGOOD)
        public void Good1()
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(Console.OpenStandardInput());
                string readString = sr.ReadLine();

                IO.WriteLine(readString);
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
            }
            /* FIX: Streams closed appropriately */
            finally
            {
                try
                {
                    if (sr != null)
                    {
                        sr.Close();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing StreamReader", exceptIO);
                }
            }
        }

        public override void Good()
        {
            Good1();
        }
#endif // OMITGOOD

}
}
