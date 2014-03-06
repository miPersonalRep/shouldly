﻿using NUnit.Framework;

namespace Shouldly.Tests
{
    [TestFixture]
    public class ShouldBeTests
    {
        [Test]
        public void ShouldBe_GreaterThan()
        {
            7.ShouldBeGreaterThan(1);
            "b".ShouldBeGreaterThan("a");
            "b".ShouldBeGreaterThan(null);
            Shouldly.Should.Throw<ChuckedAWobbly>(() => 0.ShouldBeGreaterThan(7));
            Shouldly.Should.Throw<ChuckedAWobbly>(() => "a".ShouldBeGreaterThan("b"));
            Shouldly.Should.Throw<ChuckedAWobbly>(() => ((string)null).ShouldBeGreaterThan("b"));
        }

        [Test]
        public void ShouldBe_LessThan()
        {
            1.ShouldBeLessThan(7);
            "a".ShouldBeLessThan("b");
            ((string)null).ShouldBeLessThan("b");
            Shouldly.Should.Throw<ChuckedAWobbly>(() => 7.ShouldBeLessThan(0));
            Shouldly.Should.Throw<ChuckedAWobbly>(() => "b".ShouldBeLessThan("a"));
            Shouldly.Should.Throw<ChuckedAWobbly>(() => "b".ShouldBeLessThan(null));
        }

        [Test]
        public void ShouldBe_GreaterThanOrEqualTo()
        {
            7.ShouldBeGreaterThanOrEqualTo(1);
            1.ShouldBeGreaterThanOrEqualTo(1);
            Shouldly.Should.Throw<ChuckedAWobbly>(() => 0.ShouldBeGreaterThanOrEqualTo(1));
        }

        [Test]
        public void ShouldBe_LessThanOrEqualTo()
        {
            1.ShouldBeLessThanOrEqualTo(7);
            1.ShouldBeLessThanOrEqualTo(1);
            Shouldly.Should.Throw<ChuckedAWobbly>(() => 2.ShouldBeLessThanOrEqualTo(1));
        }

        [Test]
        public void ShouldBeAssignableTo_ShouldNotThrowForStrings()
        {
            "Sup yo".ShouldBeAssignableTo(typeof(string));
        }

        [Test]
        public void ShouldBeOfType_ShouldNotThrowForStrings()
        {
            "Sup yo".ShouldBeOfType(typeof(string));
        }

        [Test]
        public void ShouldBeAssignableToWithGenericParameter_ShouldNotThrowForStrings()
        {
            "Sup yo".ShouldBeAssignableTo<string>();
        }

        [Test]
        public void ShouldBeOfTypeWithGenericParameter_ShouldNotThrowForStrings()
        {
            "Sup yo".ShouldBeOfType<string>();
        }

        [Test]
        public void ShouldBeAssignableToWithGenericParameter_ShouldReturnThis()
        {
            string str = "Sup yo";
            string ret = str.ShouldBeAssignableTo<string>();
            ret.ShouldBe(str);
        }

        [Test]
        public void ShouldBeOfTypeWithGenericParameter_ShouldReturnThis()
        {
            string str = "Sup yo";
            string ret = str.ShouldBeOfType<string>();
            ret.ShouldBe(str);
        }

        [Test]
        public void ShouldNotBeAssignableTo_ShouldNotThrowForNonMatchingType()
        {
            "Sup yo".ShouldNotBeAssignableTo(typeof(int));
        }

        [Test]
        public void ShouldNotBeOfType_ShouldNotThrowForNonMatchingType()
        {
            "Sup yo".ShouldNotBeOfType(typeof(int));
        }

        [Test]
        public void ShouldNotBeAssignableToWithGenericParameter_ShouldNotThrowForNonMatchingTypes()
        {
            "Sup yo".ShouldNotBeAssignableTo<int>();
        }

        [Test]
        public void ShouldNotBeOfTypeWithGenericParameter_ShouldNotThrowForNonMatchingTypes()
        {
            "Sup yo".ShouldNotBeOfType<int>();
        }

        [Test]
        public void ShouldNotBeOfType_TreatsNullAsNotMatchingAndDoesNotThrow()
        {
            object o = null;
            o.ShouldNotBeOfType<int>();
        }

        [Test]
        public void ShouldBeAssignableTo_ShouldNotThrowForInheritance()
        {
            new MyThing().ShouldBeAssignableTo<MyBase>();
        }

        [Test]
        public void ShouldBeOfType_ShouldNotThrowForSameType()
        {
            new MyThing().ShouldBeAssignableTo<MyThing>();
        }

        [Test]
        public void ShouldBe_WhenThingsAreDifferentTypes_ThatOverrideEqualsPoorly_ShouldThrow()
        {
            Shouldly.Should.Throw<ChuckedAWobbly>(() => new Strange().ShouldBe("hello"));
        }

        [Test]
        public void ShouldBe_WhenGivenEqualArray_ShouldPass()
        {
            new[]{1,2,3,4}.ShouldBe(new []{1,2,3,4});
        }

        [Test]
        public void ShouldBe_WhenGivenEqualMultidimensionArray_ShouldPass()
        {
            new[,]{{"1","2"}, {"3", "4"}}.ShouldBe(new[,]{{"1","2"},{"3","4"}});
        }

        [Test]
        public void ShouldBe_WhenGivenNotEqualArrays_ShouldThrow()
        {
            Shouldly.Should.Throw<ChuckedAWobbly>(() => new[]{99,2,3,5}.ShouldBe(new []{1,2,3,4}));
        }

        [Test]
        public void ShouldBe_WhenGivenNotEqualMultidimensionArrays_ShouldThrow()
        {
            Shouldly.Should.Throw<ChuckedAWobbly>(() => new[,]{{"1","2"}, {"3", "5"}}.ShouldBe(new[,]{{"1","2"},{"3","4"}}));
        }

    }
}
