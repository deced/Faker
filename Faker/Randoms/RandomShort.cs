using System;
using Faker.Abstrations;

namespace Faker.Randoms
{
    public class RandomShort:RandomValue
    {
        public override object Get(Type type)
        {
            return (short) _random.Next(short.MinValue, short.MinValue);
        }
    }
}