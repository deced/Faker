using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Faker.Tests
{
    public class User { }

    public class Car { public string Name { get; set; } }

    public class Student { public string name; public byte age; }

    public class Bike
    {
        private byte wheelsCount;

        public Bike(byte whCount)
        {
            wheelsCount = whCount;
        }

        public int GetWheelsCount()
        {
            return wheelsCount;
        }
    }

    public class A {public B _b { get; set; } }

    public class B { public A _a { get; set; } }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateEmptyObject()
        {
            Faker faker = new Faker();
            var user = faker.Create<User>();
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void CreateObjectWithProperty()
        {
            Faker faker = new Faker();
            var car = faker.Create<Car>();
            Assert.IsNotNull(car);
            Assert.IsNotNull(car);
        }

        [TestMethod]
        public void CreateObjectWithField()
        {
            Faker faker = new Faker();
            var student = faker.Create<Student>();
            Assert.IsNotNull(student);
            Assert.IsNotNull(student.name);
            Assert.IsTrue(student.age != 0);
        }

        [TestMethod]
        public void CreateObjectWithConstructor()
        {
            Faker faker = new Faker();
            var bike = faker.Create<Bike>();
            Assert.IsNotNull(bike);
            Assert.IsTrue(bike.GetWheelsCount() > 0);
        }

        [TestMethod]
        public void CreateObjectWithCycle()
        {
            Faker faker = new Faker();
            var a = faker.Create<A>();
            Assert.IsNotNull(a);
            Assert.IsNotNull(a._b);
            Assert.IsNull(a._b._a);
        }

        [TestMethod]
        public void CreateValueTypes()
        {
            Faker faker = new Faker();
            Assert.IsNotNull(faker.Create<string>());
            Assert.IsTrue(faker.Create<byte>() > 0);
            Assert.IsNotNull(faker.Create<TimeSpan>().Milliseconds > 0);
        }

        [TestMethod]
        public void CreateList()
        {
            Faker faker = new Faker();
            var bytes = faker.Create<List<List<byte>>>();
            Assert.IsNotNull(bytes);
            Assert.IsNotNull(bytes[0]);
            Assert.IsTrue(bytes[0][0] > 0);
        }
    }
}