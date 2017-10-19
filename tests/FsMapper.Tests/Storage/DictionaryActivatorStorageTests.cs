using System;
using System.Linq.Expressions;
using FsMapper.Storage;
using FsMapper.Tests.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FsMapper.Tests.Storage
{
    [TestClass]
    public class DictionaryActivatorStorageTests
    {
        [TestMethod]
        public void Test_When_ActivatorMissing_Then_Exist_Returns_False()
        {
            // Arrange
            var storage = new DictionaryActivatorStorage();

            // Act
            var exist = storage.Exist<Customer>();

            // Assert
            Assert.IsFalse(exist);
        }

        [TestMethod]
        public void Test_When_ActivatorAdded_Then_Exist_Returns_True()
        {
            // Arrange
            var storage = new DictionaryActivatorStorage();
            Expression<Func<Customer>> activator = () => null;

            // Act
            storage.Add(activator);

            var exist = storage.Exist<Customer>();

            // Assert
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void Test_When_ActivatorAdded_Then_Get_Returns_CompiledFunc()
        {
            // Arrange
            var storage = new DictionaryActivatorStorage();

            Expression<Func<Customer>> activator = () => null;

            // Act
            storage.Add(activator);

            var compiled = storage.Get<Customer>();

            // Assert
            Assert.IsInstanceOfType(compiled, typeof(Func<Customer>));
        }
    }
}