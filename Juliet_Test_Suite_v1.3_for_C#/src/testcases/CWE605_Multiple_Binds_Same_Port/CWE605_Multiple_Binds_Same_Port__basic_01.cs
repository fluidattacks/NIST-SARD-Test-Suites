/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE605_Multiple_Binds_Same_Port__basic_01.cs
Label Definition File: CWE605_Multiple_Binds_Same_Port__basic.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 605 Multiple binds to the same port
* Sinks:
*    GoodSink: two binds on different ports
*    BadSink : two binds on one port
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Net;
using System.Net.Sockets;

namespace testcases.CWE605_Multiple_Binds_Same_Port
{
class CWE605_Multiple_Binds_Same_Port__basic_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
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
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
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
#endif //omitgood
}
}
