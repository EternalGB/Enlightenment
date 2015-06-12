using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NormalisationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NotAndTest()
        {
            Atom A = new AllHave(new PropertyCheckers.PropertyHasValue("Face", "One"));
            Atom B = new ExistsOneHas(new PropertyCheckers.PropertyHasValue("Colour", "Black"));
            Rule rule1 = new Rule(new Not(new And(A, B)));
            Rule rule2 = new Rule(new Or(A.Negate(), B.Negate()));

            Assert.AreEqual("NOT ((AllHave [Face == One]) AND (ExistsOneHas [Colour == Black]))", rule1.ToString());
            Assert.AreEqual("(ExistsOneHas [NOT (Face == One)]) OR (AllHave [NOT (Colour == Black)])", rule2.ToString());

            Assert.AreEqual("(ExistsOneHas [NOT (Face == One)]) OR (AllHave [NOT (Colour == Black)])", rule1.ToNormalForm().ToString());

            Assert.AreEqual(true, rule1.ToNormalForm().Equals(rule2.ToNormalForm()));
        }

        [TestMethod]
        public void NotOrTest()
        {
            Atom A = new AllHave(new PropertyCheckers.PropertyHasValue("Face", "One"));
            Atom B = new ExistsOneHas(new PropertyCheckers.PropertyHasValue("Colour", "Black"));
            Rule rule1 = new Rule(new Not(new Or(A, B)));
            Rule rule2 = new Rule(new And(A.Negate(), B.Negate()));

            Assert.AreEqual("NOT ((AllHave [Face == One]) OR (ExistsOneHas [Colour == Black]))", rule1.ToString());
            Assert.AreEqual("(ExistsOneHas [NOT (Face == One)]) AND (AllHave [NOT (Colour == Black)])", rule2.ToString());

            Assert.AreEqual("(ExistsOneHas [NOT (Face == One)]) AND (AllHave [NOT (Colour == Black)])", rule1.ToNormalForm().ToString());

            Assert.AreEqual(true, rule1.ToNormalForm().Equals(rule2.ToNormalForm()));
        }

        [TestMethod]
        public void DoubleNegationTest()
        {
            Atom A = new AllHave(new PropertyCheckers.PropertyHasValue("Face", "One"));
            Rule rule1 = new Rule(new Not(new Not(A)));

            Assert.AreEqual("NOT (NOT (AllHave [Face == One]))", rule1.ToString());

            Assert.AreEqual("AllHave [Face == One]", rule1.ToNormalForm().ToString());
        }

        [TestMethod]
        public void ComplexTest()
        {
            Atom A = new AllHave(new PropertyCheckers.PropertyHasValue("Face", "One"));
            Atom B = new ExistsOneHas(new PropertyCheckers.PropertyHasValue("Colour", "Black"));
            Rule rule1 = new Rule(new Not(new Not(new Or(new Not(new And(A,B)), B))));

            Assert.AreEqual("NOT (NOT ((NOT ((AllHave [Face == One]) AND (ExistsOneHas [Colour == Black]))) OR (ExistsOneHas [Colour == Black])))", rule1.ToString());

            Assert.AreEqual("((ExistsOneHas [NOT (Face == One)]) OR (AllHave [NOT (Colour == Black)])) OR (ExistsOneHas [Colour == Black])", rule1.ToNormalForm().ToString());
        }
    }
}
