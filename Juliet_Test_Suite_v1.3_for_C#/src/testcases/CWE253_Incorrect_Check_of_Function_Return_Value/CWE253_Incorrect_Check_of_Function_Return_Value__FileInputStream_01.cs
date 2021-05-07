/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE253_Incorrect_Check_of_Function_Return_Value__FileInputStream_01.cs
Label Definition File: CWE253_Incorrect_Check_of_Function_Return_Value__FileInputStream.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 253 Incorrect Check of Function Return Value
* Sinks:
*    GoodSink: Check the return value from FileInputStream.read() and handle possible errors
*    BadSink : Check the return value of FileInputStream.read() for the wrong value
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE253_Incorrect_Check_of_Function_Return_Value
{
class CWE253_Incorrect_Check_of_Function_Return_Value__FileInputStream_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        using (Stream s = new MemoryStream())
        {
            for (int i = 0; i < 122; i++)
            {
                s.WriteByte((byte)i);
            }
            s.Position = 0;
            try
            {
                while (true)
                {
                    // Now read s into a byte buffer with a little padding.
                    byte[] bytes = new byte[s.Length + 10];
                    int numBytesToRead = (int)s.Length;
                    int numBytesRead = 0;
                    int n = s.Read(bytes, numBytesRead, 1);
                    /* FLAW: Incorrect check of return value, which should be 0 for EOF */
                    if (n == -1)
                    {
                        IO.WriteLine("The end of the file has been reached.");
                        break;
                    }
                }
                /* INCIDENTAL: CWE561 dead code */
                s.Close();
            }
            catch (FileNotFoundException exceptFileNotFound)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "FileNotFoundException opening file", exceptFileNotFound);
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "IOException reading file", exceptIO);
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        using (Stream s = new MemoryStream())
        {
            for (int i = 0; i < 122; i++)
            {
                s.WriteByte((byte)i);
            }
            s.Position = 0;
            try
            {
                while (true)
                {
                    // Now read s into a byte buffer with a little padding.
                    byte[] bytes = new byte[s.Length + 10];
                    int numBytesToRead = (int)s.Length;
                    int numBytesRead = 0;
                    int n = s.Read(bytes, numBytesRead, 1);
                    /* FIX: Check the return value of read() for EOF */
                    if (n == 0)
                    {
                        IO.WriteLine("The end of the file has been reached.");
                        break;
                    }
                }
                s.Close();
            }
            catch (FileNotFoundException exceptFileNotFound)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "FileNotFoundException opening file", exceptFileNotFound);
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "IOException reading file", exceptIO);
            }
        }
    }
#endif //omitgood
}
}
