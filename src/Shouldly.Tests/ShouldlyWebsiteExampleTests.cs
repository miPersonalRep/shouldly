﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Shouldly.Tests
{
    [TestFixture]
    public class ShouldlyWebsiteExampleTests
    {
        // Tests for the examples shown on http://shouldly.github.io/ (https://github.com/shouldly/shouldly.github.com)

        public class ContestantPoints
        {
            [Test]
            public void NUnit_ContestantPointsShouldBe1337()
            {
                var contestant = new Contestant() {Points = 0};

                var exception =
                    Shouldly.Should.Throw<Exception>(
                        () => Assert.That(contestant.Points, NUnit.Framework.Is.EqualTo(1337)));

                exception.Message.ShouldContainWithoutWhitespace("Expected: 1337 But was: 0");
            }

            [Test]
            public void Shouldly_ContestantPointsShouldBe1337()
            {
                var contestant = new Contestant {Points = 0};

                Should.Error(
                    () => contestant.Points.ShouldBe(1337),
                    "() => contestant.Points should be 1337 but was 0");
            }

            [Test]
            public void Shouldly_ContestantPointsShouldBe1337_HappyPath()
            {
                var contestant = new Contestant {Points = 0};

                contestant.Points.ShouldBe(0);
            }

            private class Contestant
            {
                public int Points { get; set; }
            }
        }

        public class MapIndexOfBoo
        {
            private IList<string> GetMap()
            {
                return new[]
                {
                    "aoo",
                    "boo",
                    "coo"
                };
            }

            [Test]
            public void NUnit_IndexOfBoo()
            {
                var map = GetMap();

                var exception =
                    Shouldly.Should.Throw<Exception>(
                        () => Assert.That(map.IndexOf("boo"), NUnit.Framework.Is.EqualTo(2)));

                exception.Message.ShouldContainWithoutWhitespace("Expected: 2 But was: 1");
            }

            [Test]
            public void Shouldly_IndexOfBoo()
            {
                var map = GetMap();

                Should.Error(
                    () => map.IndexOf("boo").ShouldBe(2),
                    "() => map.IndexOf(\"boo\") should be 2 but was 1");
            }

            [Test]
            public void Shouldly_IndexOfBoo_HappyPath()
            {
                var map = GetMap();

                map.IndexOf("boo").ShouldBe(1);
            }
        }

        public class CompareTwoCollections
        {
            [Test]
            public void Shouldly_CompareTwoCollections()
            {
                Should.Error(
                    () => (new[] {1, 2, 3}).ShouldBe(new[] {1, 2, 4}),
                    "() => (new[] {1, 2, 3}) should be [1, 2, 4] but was [1, 2, 3] difference [1, 2, *3*]");
            }

            [Test]
            public void Shouldly_CompareTwoCollections_HappyPath()
            {
                (new[] {1, 2, 3}).ShouldBe(new[] {1, 2, 3});
            }
        }

        public class ShouldThrowException
        {
            [Test]
            public void Shouldly_ShouldThrowException()
            {
                var widget = new Widget();

                Shouldly.Should.Throw<ArgumentOutOfRangeException>(() => widget.Twist(-1));
            }

            [Test]
            public void Shouldly_ShouldNotThrowException()
            {
                var widget = new Widget();

                Shouldly.Should.NotThrow(() => widget.Twist(5));
            }

            [Test]
            public void Shouldly_ShouldErrorIfCatchingExceptionOfWrongType()
            {
                var widget = new Widget();

                Should.Error(
                    () => Shouldly.Should.Throw<ArgumentOutOfRangeException>(() => widget.Twist(-2)),
                    "() => Shouldly.Should throw System.ArgumentOutOfRangeException but was System.InvalidOperationException");
            }

            [Test]
            public void Shouldly_ShouldErrorIfNoExceptionWasThrown()
            {
                var widget = new Widget();

                Should.Error(
                    () => Shouldly.Should.Throw<ArgumentOutOfRangeException>(() => widget.Twist(5)),
                    "() => Shouldly.Should throw System.ArgumentOutOfRangeException but does not");
            }

            private class Widget
            {
                public void Twist(int i)
                {
                    if (i == -1)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    if (i == -2)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}