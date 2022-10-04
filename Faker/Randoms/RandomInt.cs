using System;
using Faker.Abstrations;

namespace Faker.Randoms
{
    public class RandomInt:RandomValue
    {
        public override object Get(Type type)
        {
            return _random.Next(Int32.MinValue, Int32.MaxValue);
        }
    }
}