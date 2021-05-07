/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE252_Unchecked_Return_Value__MemoryStream_08.cs
Label Definition File: CWE252_Unchecked_Return_Value__MemoryStream.label.xml
Template File: point-flaw-08.tmpl.cs
*/
/*
* @description
* CWE: 252 Unchecked Return Value
* Sinks:
*    GoodSink: Check the return value from MemoryStream.Read()
*    BadSink : Do not check the return value of MemoryStream.Read()
* Flow Variant: 08 Control flow: if(PrivateReturnsTrue()) and if(PrivateReturnsFalse())
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE252_Unchecked_Return_Value
{
class CWE252_Unchecked_Return_Value__MemoryStream_08 : AbstractTestCase
{
    /* The methods below always return the same value, so a tool
     * should be able to figure out that every call to these
     * methods will return true or return false.
     */
    private static bool PrivateReturnsTrue()
    {
        return true;
    }

    private static bool PrivateReturnsFalse()
    {
        return false;
    }
#if (!OMITBAD)
    public override void Bad()
    {
        if (PrivateReturnsTrue())
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
                        /* FLAW: Do not check the return value of Read(), for EOF */
                    }
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
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes PrivateReturnsTrue() to privateReturnsFalse() */
    private void Good1()
    {
        if (PrivateReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
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
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (PrivateReturnsTrue())
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
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
