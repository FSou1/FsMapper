using System;
using FsMapper.Build;
using FsMapper.Tests.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FsMapper.Tests.Build
{
    [TestClass]
    public class DynamicMethodObjectBuilderTests
    {
        [TestMethod]
        public void Test_When_CtorExist_Then_CorrectActivator_Returns()
        {
            // Arrange
            var builder = new DynamicMethodObjectBuilder();

            // Act
            var activator = builder.GetActivator<Customer>();

            // Assert
            Assert.IsNotNull(activator);
            Assert.IsInstanceOfType(activator, typeof(Func<Customer>));
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException), "The default constructor of Sale type is missing")]
        public void Test_When_CtorMissing_Then_Activator_ThrowsException()
        {
            // Arrange
            var builder = new DynamicMethodObjectBuilder();

            // Act
            var activator = builder.GetActivator<Sale>();
        }

        [TestMethod]
        public void Test_When_CtorExist_Then_Call_Returns_Instance()
        {
            // Arrange
            var builder = new DynamicMethodObjectBuilder();

            // Act
            var activator = builder.GetActivator<Customer>();
            var instance = activator();

            // Assert
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof(Customer));
        }
    }
}