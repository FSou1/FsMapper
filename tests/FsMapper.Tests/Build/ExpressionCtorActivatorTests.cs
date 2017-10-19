using System;
using FsMapper.Build;
using FsMapper.Tests.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FsMapper.Tests.Build
{
    [TestClass]
    public class ExpressionCtorActivatorTests
    {
        [TestMethod]
        public void Test_When_CtorExist_Then_CorrectActivator_Returns()
        {
            // Arrange
            var builder = new ExpressionCtorObjectBuilder();
            
            // Act
            var activatorExpression = builder.GetActivator<Customer>();
            var activatorFunc = activatorExpression.Compile();

            // Assert
            Assert.IsNotNull(activatorFunc);
            Assert.IsInstanceOfType(activatorFunc, typeof(Func<Customer>));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The default constructor of Sale type is missing")]
        public void Test_When_CtorMissing_Then_Activator_ThrowsException()
        {
            // Arrange
            var builder = new ExpressionCtorObjectBuilder();

            // Act
            var activatorExpression = builder.GetActivator<Sale>();
            var activatorFunc = activatorExpression.Compile();
        }
    }
}