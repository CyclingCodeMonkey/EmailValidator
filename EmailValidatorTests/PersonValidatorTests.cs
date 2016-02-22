using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmailValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailValidator.Tests
{
    [TestClass]
    public class PersonValidatorTests
    {
        [TestMethod]
        public void PersonValidator_Test()
        {
            var person = new Person();
            person.EmailAddress = "joe@hotmail.com";

            var target = new PersonValidator();
            var actual = target.Validate(person);

            Assert.IsTrue(actual.IsValid);
        }

        [TestMethod]
        public void PersonValidator_Bulk_Test()
        {
            var person = new Person();
            var testcases = Create();
            foreach (var testcase in testcases)
            {
                person.EmailAddress = testcase.Key;

                var target = new PersonValidator();
                var actual = target.Validate(person);

                Assert.AreEqual(testcase.Value, actual.IsValid);
            }   
        }


        private static IEnumerable<KeyValuePair<string, bool>> Create()
        {
            var testCases = new List<KeyValuePair<string,bool>>();
            testCases.Add(new KeyValuePair<string, bool>("joe@outlook.com", true));
            testCases.Add(new KeyValuePair<string, bool>("joe@outlook", false));
            testCases.Add(new KeyValuePair<string, bool>("joe@outlook.mortgage", true));
            testCases.Add(new KeyValuePair<string, bool>("\"j@oe\"@outlook.mortgage", true));
            return testCases;
        }


    }
}