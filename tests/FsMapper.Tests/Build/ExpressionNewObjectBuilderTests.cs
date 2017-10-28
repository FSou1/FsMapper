using System;
using FsMapper.Build;
using FsMapper.Tests.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FsMapper.Tests.Build
{
    [TestClass]
    public class ExpressionNewObjectBuilderTests
    {
        [TestMethod]
        public void Test_When_CtorExist_Then_CorrectActivator_Returns()
        {
            // Arrange
            var builder = new ExpressionNewObjectBuilder();
            
            // Act
            var activator = builder.GetActivator<CustomerDto, Customer>();

            // Assert
            Assert.IsNotNull(activator);
            Assert.IsInstanceOfType(activator, typeof(Func<CustomerDto, Customer>));
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException), "The default constructor of Sale type is missing")]
        public void Test_When_CtorMissing_Then_Activator_ThrowsException()
        {
            // Arrange
            var builder = new ExpressionNewObjectBuilder();

            // Act
            var activator = builder.GetActivator<Customer, Sale>();
        }

        [TestMethod]
        public void Test_When_CtorExist_Then_Call_Returns_Instance()
        {
            // Arrange
            var builder = new ExpressionNewObjectBuilder();
            var dto = new CustomerDto
            {
                Id = 1,
                Title = "LLC"
            };

            // Act
            var activator = builder.GetActivator<CustomerDto, Customer>();
            var instance = activator(dto);

            // Assert
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof(Customer));
            Assert.AreEqual(1, instance.Id);
        }
    }
}