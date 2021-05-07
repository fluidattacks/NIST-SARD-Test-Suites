/*
 * @description Improper Resource Shutdown.  Performs some, but not all, necessary resource cleanup (InputStreamReader is not closed properly).
 * 
 * */

using TestCaseSupport;
using System;
using System.IO;
using System.Text;


namespace testcases.CWE404_Improper_Resource_Shutdown
{

    class CWE404_Improper_Resource_Shutdown__console_InputStreamReader_01 : AbstractTestCase
    {
#if (!OMITBAD)
        /* uses badsource and badsink */
        public override void Bad()
        {
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(Console.OpenStandardInput(), Encoding.UTF8);
                string readString = sr.ReadLine();

                IO.WriteLine(readString);

                /* FLAW: Attempts to close the streams should be in a finally block. */
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
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
            }
        }
#endif // OMITBAD
#if (!OMITGOOD)
        public override void Good()
        {
            Good1();
        }

        /* goodG2B() - uses goodsource and badsink */
        private void Good1()
        {
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(Console.OpenStandardInput(), Encoding.UTF8);
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
#endif // OMITGOOD
}
}
