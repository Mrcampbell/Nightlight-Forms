using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nightlight;
using Nightlight.TestClasses;
using Nightlight.Models.Form;
using Nightlight.Test.TestObjects;

namespace Nightlight.Test
{
    [TestClass]
    public class TestAttributeProperties
    {

        [TestInitialize]
        public void SetupTest()
        {
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "The Attribute should have thrown error saying that a Node cannot have required length below zero.")]
        public void Test_RequiredIsSetToTrue()
        {
            StringAttributeObjectWithMinLengthLessThanZero obj = new StringAttributeObjectWithMinLengthLessThanZero();

            NightlightFormController<StringAttributeObjectWithMinLengthLessThanZero> formcontroller =
                new NightlightFormController<StringAttributeObjectWithMinLengthLessThanZero>(ref obj);
        }
    }
}
