/*
 * @description Missing Release of File Descriptor or Handle After Effective Lifetime.  Performs some, but not all, necessary resource cleanup (StreamReader is not closed).
 * 
 * */

using System;
using System.IO;
using TestCaseSupport;

namespace testcases.CWE775_Missing_Release_of_File_Descriptor_or_Handle
{
    class CWE775_Missing_Release_of_File_Descriptor_or_Handle__StreamReader_01 : AbstractTestCase
    {
#if (!OMITBAD)
        public override void Bad()
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("c:\\file.txt");
                string readString = sr.ReadLine();

                IO.WriteLine(readString);
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
            }
            /* FLAW: file, readerFile, and readerBuffered not closed */
        }
#endif // OMITBAD

#if (!OMITGOOD)
        public void Good1()
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("c:\\file.txt");
                string readString = sr.ReadLine();

                IO.WriteLine(readString);
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
            }
            finally
            {
                /* FIX: StreamReader closed appropriately */
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
