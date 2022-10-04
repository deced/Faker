using System;
using Faker.Abstrations;

namespace Faker.Randoms
{
    public class RandomLong:RandomValue
    {
        public override object Get(Type type)
        {
            return _random.Next(Int32.MinValue, Int32.MaxValue) *
                   _random.Next(Int32.MinValue, Int32.MaxValue);
        }
    }
}