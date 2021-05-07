/*
* @description Helper IO class
* 
*
* */

using System;
using System.Data.SqlClient;

namespace TestCaseSupport
{
    public class IO
    {
        /* fill in these parameters if you want to be able to actually connect
       * to a database
       */
        private static readonly string serverName = "";
        private static readonly string dbName = "";
        private static readonly string dbUsername = "";
        private static readonly string dbPassword = "";
        private static readonly string connetionString = @"Data Source=" + serverName + ";Initial Catalog=" + dbName + ";User ID=" + dbUsername + ";Password=" + dbPassword;

        public static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static void WriteString(string str)
        {
            Console.WriteLine(str);
        }

        public static void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public static void WriteLine(int intNumber)
        {
            WriteLine(string.Format("{0:0.##}", intNumber));
        }

        public static void WriteLine(long longNumber)
        {
            WriteLine(string.Format("{0:0.##}", longNumber));
        }

        public static void WriteLine(double doubleNumber)
        {
            WriteLine(string.Format("{0:0.##}", doubleNumber));
        }

        public static void WriteLine(float floatNumber)
        {
            WriteLine(string.Format("{0:0.##}", floatNumber));
        }

        public static void WriteLine(short shortNumber)
        {
            WriteLine(string.Format("{0:0.##}", shortNumber));
        }

        public static void WriteLine(byte byteHex)
        {
            WriteLine(string.Format("{0:0.##}", byteHex));
        }

        /* use this method to get a database connection for use in SQL 
         * Injection and other test cases that use a database.
         */
        public static SqlConnection GetDBConnection()
        {
            SqlConnection connection = new SqlConnection(connetionString);
            return connection;
        }

        /* The variables below are declared "readonly", so a tool doing whole
        program analysis should be able to identify that reads of these 
        will always return their initialized values. */
        public static readonly bool STATIC_READONLY_TRUE = true;
        public static readonly bool STATIC_READONLY_FALSE = false;
        public static readonly int STATIC_READONLY_FIVE = 5;

        /* The variables below are not defined as "readonly", but are never
        assigned any other value, so a tool doing whole program analysis
        should be able to identify that reads of these will always return 
        their initialized values. */
        public static bool staticTrue = true;
        public static bool staticFalse = false;
        public static int staticFive = 5;

        public static bool StaticReturnsTrue()
        {
            return true;
        }

        public static bool StaticReturnsFalse()
        {
            return false;
        }

        public static bool StaticReturnsTrueOrFalse()
        {
            return new Random().Next(100) % 2 == 0;
        }

        /* Turns array of bytes into string. */
        public static string ToHex(byte[] byteBuffer)
        {
            string s = System.Text.Encoding.UTF8.GetString(byteBuffer, 0, byteBuffer.Length);
            return s;
        }

        public static void GoodExceptionCatch(Exception e)
        {
            WriteLine("Caught an exception from good() for Class $TestCaseRoot$");
            WriteLine("Exception's message = " + e.Message);
            string stackTrace = e.StackTrace;
            WriteLine("Stack trace below");
            WriteLine(stackTrace);
        }

        public static void BadExceptionCatch(Exception e)
        {
            WriteLine("Caught an exception from bad() for Class $TestCaseRoot$");
            WriteLine("Exception's message = " + e.Message);
            string stackTrace = e.StackTrace;
            WriteLine("Stack trace below");
            WriteLine(stackTrace);
        }

        public static long GetRandomLong()
        {
            var buffer = new byte[sizeof(Int64)];
            new Random().NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }

        public static ulong GetRandomULong()
        {
            var buffer = new byte[sizeof(Int64)];
            new Random().NextBytes(buffer);
            return BitConverter.ToUInt64(buffer, 0);
        }

        public static double GetRandomDouble()
        {
            Random random = new Random();
            var buffer = new byte[sizeof(Double)];
            random.NextBytes(buffer);
            var value = BitConverter.ToDouble(buffer, 0);
            while (double.IsNaN(value) || double.IsInfinity(value))
            {
                random.NextBytes(buffer);
                value = BitConverter.ToDouble(buffer, 0);
            }
            return value;
        }

    }
}
