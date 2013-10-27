using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.CodeSchool;

namespace CSharp.CodeSchool.Tests
{
    [TestClass]
    public class AccountTest
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void ShouldGetCurrentAccount()
        {
            var client = new CodeSchoolRestClient("scottksmith95");
            var result = client.GetAccount();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(result.user.username, "scottksmith95");
        }

        [TestMethod]
        public void ShouldGetErrorAccountForInvalid()
        {
            var client = new CodeSchoolRestClient("jksfkdjsafkjskfjdskfjds");
            var result = client.GetAccount();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.RestException);
            Assert.IsNotNull(result.RestException.error);
            Assert.AreEqual(result.RestException.error.message, "Houston, we have a problem.");
        }

        [TestMethod]
        public void ShouldGetErrorAccountForEmpty()
        {
            var client = new CodeSchoolRestClient("");
            var result = client.GetAccount();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.RestException);
            Assert.IsNotNull(result.RestException.error);
            Assert.AreEqual(result.RestException.error.message, "Houston, we have a problem.");
        }
    }
}
