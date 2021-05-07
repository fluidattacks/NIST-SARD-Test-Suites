/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE379_Temporary_File_Creation_in_Insecure_Dir__basic_03.cs
Label Definition File: CWE379_Temporary_File_Creation_in_Insecure_Dir__basic.label.xml
Template File: point-flaw-03.tmpl.cs
*/
/*
* @description
* CWE: 379 File Creation in Insecure Directory
* Sinks:
*    GoodSink: Restrict permissions on directory
*    BadSink : Permissions never set on directory
* Flow Variant: 03 Control flow: if(5==5) and if(5!=5)
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE379_Temporary_File_Creation_in_Insecure_Dir
{
class CWE379_Temporary_File_Creation_in_Insecure_Dir__basic_03 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (5 == 5)
        {
            string tempPath = Path.GetTempFileName();
            int p = (int)Environment.OSVersion.Platform;
            string directoryName;
            if (p == (int)PlatformID.Win32NT || p == (int)PlatformID.Win32Windows || p == (int)PlatformID.Win32S || p == (int)PlatformID.WinCE)
            {
                /* running on Windows */
                directoryName = "C:\\testcases\\insecureDir";
            }
            else
            {
                /* running on non-Windows */
                directoryName = "/home/user/testcases/insecureDir/";
            }
            try
            {
                /* FLAW: Permissions never set on directory */
                Directory.CreateDirectory(directoryName);
                if (Directory.Exists(directoryName))
                {
                    IO.WriteLine("Directory created");
                    using (StreamWriter sw = new StreamWriter(tempPath))
                    {
                        /* Set file as writable by owner, readable by owner, not executable (if file system supports it) */
                        File.SetAttributes(tempPath, FileAttributes.Normal);
                        /* Write something to the file */
                        sw.Write(42);
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error writing to temporary file", exceptIO);
            }
            finally
            {
                /* Delete the temporary file */
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes 5==5 to 5!=5 */
    private void Good1()
    {
        if (5 != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            string tempPath = Path.GetTempFileName();
            int p = (int)Environment.OSVersion.Platform;
            string directoryName;
            if (p == (int)PlatformID.Win32NT || p == (int)PlatformID.Win32Windows || p == (int)PlatformID.Win32S || p == (int)PlatformID.WinCE)
            {
                /* running on Windows */
                directoryName = ".\\src\\testcases\\CWE379_File_Creation_in_Insecure_Dir\\secureDir";
            }
            else
            {
                /* running on non-Windows */
                directoryName = "/home/user/testcases/CWE379_File_Creation_in_Insecure_Dir/secureDir/";
            }
            try
            {
                /* FIX: Set newDirectory as writable by owner, readable by owner, not executable (if file system supports it) */
                File.SetAttributes(directoryName, FileAttributes.Normal);
                Directory.CreateDirectory(directoryName);
                if (Directory.Exists(directoryName))
                {
                    IO.WriteLine("Directory created");
                    using (StreamWriter sw = new StreamWriter(tempPath))
                    {
                        /* Set file as writable by owner, readable by owner, not executable (if file system supports it) */
                        File.SetAttributes(tempPath, FileAttributes.Normal);
                        /* Write something to the file */
                        sw.Write(42);
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error writing to temporary file", exceptIO);
            }
            finally
            {
                /* Delete the temporary file */
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }
            }
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (5 == 5)
        {
            string tempPath = Path.GetTempFileName();
            int p = (int)Environment.OSVersion.Platform;
            string directoryName;
            if (p == (int)PlatformID.Win32NT || p == (int)PlatformID.Win32Windows || p == (int)PlatformID.Win32S || p == (int)PlatformID.WinCE)
            {
                /* running on Windows */
                directoryName = ".\\src\\testcases\\CWE379_File_Creation_in_Insecure_Dir\\secureDir";
            }
            else
            {
                /* running on non-Windows */
                directoryName = "/home/user/testcases/CWE379_File_Creation_in_Insecure_Dir/secureDir/";
            }
            try
            {
                /* FIX: Set newDirectory as writable by owner, readable by owner, not executable (if file system supports it) */
                File.SetAttributes(directoryName, FileAttributes.Normal);
                Directory.CreateDirectory(directoryName);
                if (Directory.Exists(directoryName))
                {
                    IO.WriteLine("Directory created");
                    using (StreamWriter sw = new StreamWriter(tempPath))
                    {
                        /* Set file as writable by owner, readable by owner, not executable (if file system supports it) */
                        File.SetAttributes(tempPath, FileAttributes.Normal);
                        /* Write something to the file */
                        sw.Write(42);
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error writing to temporary file", exceptIO);
            }
            finally
            {
                /* Delete the temporary file */
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
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
