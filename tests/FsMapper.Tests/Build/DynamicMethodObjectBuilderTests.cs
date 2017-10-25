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
        public void Test_When_ActivatorExist_Then_CorrectActivator_Returns()
        {
            // Arrange
            var builder = new DynamicMethodObjectBuilder();

            // Act
            var activatorExpression = builder.GetActivator<Customer>();
            var activatorFunc = activatorExpression.Compile();

            // Assert
            Assert.IsNotNull(activatorFunc);
            Assert.IsInstanceOfType(activatorFunc, typeof(Func<Customer>));
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException), "The default constructor of Sale type is missing")]
        public void Test_When_ActivatorMissing_Then_Activator_ThrowsException()
        {
            // Arrange
            var builder = new DynamicMethodObjectBuilder();

            // Act
            var activatorExpression = builder.GetActivator<Sale>();
            var activatorFunc = activatorExpression.Compile();
        }

        [TestMethod]
        public void Test_When_ActivatorExist_Then_Call_Returns_Instance()
        {
            // Arrange
            var builder = new DynamicMethodObjectBuilder();

            // Act
            var activatorExpression = builder.GetActivator<Customer>();
            var activatorFunc = activatorExpression.Compile();
            var instance = activatorFunc();

            // Assert
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof(Customer));
        }
    }
}