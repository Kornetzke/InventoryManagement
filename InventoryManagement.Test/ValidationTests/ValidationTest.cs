using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using InventoryManagement.Service.DataValidation;

namespace InventoryManagement.Test.ValidationTests
{
    [TestFixture]
    class ValidationTest
    {
        [Test]
        public void EmailValidationShouldAcceptOnlyValidEmails()
        {
            Dictionary<string, bool> ValidEmailDictionary = new Dictionary<string, bool>()
            {
                {"david.jones@proseware.com",true},
                {"d.j@server1.proseware.com",true},
                {"jones@ms1.proseware.com", true},
                {"j.@server1.proseware.com", false},
                {"j@proseware.com9", true},
                {"js#internal@proseware.com", true},
                {"j_9@[129.126.118.1]", true},
                {"j..s@proseware.com", false},
                {"js*@proseware.com", false},
                {"js@proseware..com", false},
                {"js@proseware.com9", true},
                {"j.s@server1.proseware.com", true},
                {"\"j\\\"s\\\"\"@proseware.com", true},
                {"js@contoso.中国", true}

            };
            foreach (KeyValuePair<string, bool> validEmail in ValidEmailDictionary)
            {
                bool isValid = DataValidationHelper.IsValidEmailAddress(validEmail.Key);
                Assert.That(isValid, Is.EqualTo(validEmail.Value), "Email Address : " + validEmail.Key + " Failed");
            }

        }
        [Test]
        public void PhoneValidationShouldAcceptOnlyValidPhoneNumbers()
        {
            Dictionary<string, bool> validPhoneNumbers = new Dictionary<string, bool>(){
                {"608658501", false},
                {"6086585015",true},
                {"65865850155",false},
                {"hellohelloh",false},
                {"(608)658-5015",true},
                {"608-658-5015",true}
            };

            foreach (KeyValuePair<string, bool> validPhoneNumber in validPhoneNumbers)
            {
                bool isValid = DataValidationHelper.IsValidPhoneNumber(validPhoneNumber.Key);
                Assert.That(isValid, Is.EqualTo(validPhoneNumber.Value), "PhoneNumber : " + validPhoneNumber.Key + " Failed");
            }

        }
    }
}
