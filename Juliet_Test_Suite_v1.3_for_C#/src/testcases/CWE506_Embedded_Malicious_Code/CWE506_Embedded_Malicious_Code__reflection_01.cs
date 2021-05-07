/*
 * @description Embedded Malicious Code. Abuse of reflection by modifying a public static final variable
 * 
 * */

using System;
using System.Reflection;
using TestCaseSupport;

namespace testcases.CWE506_Embedded_Malicious_Code
{
    class CWE506_Embedded_Malicious_Code__reflection_01 : AbstractTestCase
    {
        private readonly string READONLY_VARIABLE = "Please don't modify me";
#if (!OMITBAD)
        public override void Bad()
        {
            CWE506_Embedded_Malicious_Code__reflection_01 test = new CWE506_Embedded_Malicious_Code__reflection_01();
            /* FLAW: Use reflection to modify a variable declared final */
            FieldInfo field = typeof(CWE506_Embedded_Malicious_Code__reflection_01).GetField
            ("READONLY_VARIABLE", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(test, "Sorry, but I've changed.");
            IO.WriteLine(test.READONLY_VARIABLE);
        }
#endif // OMITBAD
#if (!OMITGOOD)
        private void Good1()
        {
            /* FIX: Use, but do not attempt to change a final variable */
            IO.WriteLine(READONLY_VARIABLE);
        }

        public override void Good()
        {
            Good1();
        }
#endif // OMITGOOD
}
}
