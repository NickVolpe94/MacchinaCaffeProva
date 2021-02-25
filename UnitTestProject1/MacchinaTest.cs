using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary1;
using MacchinaCaffe;

namespace UnitTestProject1
{
    [TestClass]
    public class MacchinaTest
    {
        MacchiaCImpl lavazza = new MacchiaCImpl();
        [TestMethod]
        public void TestMethod1()
        {
            int x = -1;
            lavazza.ControlloValore(x);

        }
    }
}
