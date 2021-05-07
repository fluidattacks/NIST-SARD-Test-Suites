/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE605_Multiple_Binds_Same_Port__basic_06.cs
Label Definition File: CWE605_Multiple_Binds_Same_Port__basic.label.xml
Template File: point-flaw-06.tmpl.cs
*/
/*
* @description
* CWE: 605 Multiple binds to the same port
* Sinks:
*    GoodSink: two binds on different ports
*    BadSink : two binds on one port
* Flow Variant: 06 Control flow: if(PRIVATE_CONST_FIVE==5) and if(PRIVATE_CONST_FIVE!=5)
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Net;
using System.Net.Sockets;

namespace testcases.CWE605_Multiple_Binds_Same_Port
{
class CWE605_Multiple_Binds_Same_Port__basic_06 : AbstractTestCase
{
    /* The variable below is declared "const", so a tool should be able
     * to identify that reads of this will always give its initialized
     * value.
     */
    private const int PRIVATE_CONST_FIVE = 5;
#if (!OMITBAD)
    public override void Bad()
    {
        if (PRIVATE_CONST_FIVE == 5)
        {
            TcpListener socket1 = null;
            TcpListener socket2 = null;
            try
            {
                socket1 = new TcpListener(IPAddress.Parse("10.10.1.10"), 15000);
                /* FLAW: This will bind a second Socket to port 15000, but only for connections from localhost */
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                socket2 = new TcpListener(localAddr, 15000);
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Unable to bind a socket");
            }
            finally
            {
                try
                {
                    if (socket2 != null)
                    {
                        socket2.Stop();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error closing Socket");
                }

                try
                {
                    if (socket1 != null)
                    {
                        socket1.Stop();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error closing Socket");
                }
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes PRIVATE_CONST_FIVE==5 to PRIVATE_CONST_FIVE!=5 */
    private void Good1()
    {
        if (PRIVATE_CONST_FIVE != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            TcpListener socket1 = null;
            TcpListener socket2 = null;
            try
            {
                socket1 = new TcpListener(IPAddress.Parse("10.10.1.10"), 15000);
                /* FIX: This will bind the second Socket to a different port */
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                socket2 = new TcpListener(localAddr, 15001);
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Unable to bind a socket");
            }
            finally
            {
                try
                {
                    if (socket2 != null)
                    {
                        socket2.Stop();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error closing Socket");
                }

                try
                {
                    if (socket1 != null)
                    {
                        socket1.Stop();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error closing Socket");
                }
            }
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (PRIVATE_CONST_FIVE == 5)
        {
            TcpListener socket1 = null;
            TcpListener socket2 = null;
            try
            {
                socket1 = new TcpListener(IPAddress.Parse("10.10.1.10"), 15000);
                /* FIX: This will bind the second Socket to a different port */
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                socket2 = new TcpListener(localAddr, 15001);
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Unable to bind a socket");
            }
            finally
            {
                try
                {
                    if (socket2 != null)
                    {
                        socket2.Stop();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error closing Socket");
                }

                try
                {
                    if (socket1 != null)
                    {
                        socket1.Stop();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error closing Socket");
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
