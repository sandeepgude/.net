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

            // Mocking the database using library Moq
            var mockRepository = new Mock<IRepository>(MockBehavior.Strict);
            //setting the input value to the Repository
            mockRepository.Setup(x => x.GetString()).Returns(input);
            // Creating an instance for String Reversor Class
            var SystemUnderTest = new StringReversor(mockRepository.Object);


            string expectedoutput = "D2C;1B*A";
            // Calling Reverse_string function to Test the functionality
            var Result = SystemUnderTest.Reverse_String();
            Assert.AreEqual(expectedoutput, Result);

            mockRepository.VerifyAll();
        }
    }
}
