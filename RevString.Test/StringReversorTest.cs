using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevString;
using Moq;


namespace RevString.Test
{
    [TestClass]
    public class StringReversorTest
    {

        [TestMethod]
        public void ReverseString_Always_ReturnsExpectedValue()
        {
            string input = "AB1;C2*D";
            var mockRepository = new Mock<IRepository>(MockBehavior.Strict);
            mockRepository.Setup(x => x.GetString()).Returns(input);
            var SystemUnderTest = new StringReversor(mockRepository.Object);


            string expectedoutput = "D2C;1B*A";
            var Result = SystemUnderTest.Reverse_String();
            Assert.AreEqual(expectedoutput, Result);

            mockRepository.VerifyAll();
        }
    }
}
