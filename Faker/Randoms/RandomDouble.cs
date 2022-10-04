using System;
using Faker.Abstrations;

namespace Faker.Randoms
{
    public class RandomDouble:RandomValue
    {
        public override object Get(Type type)
        {
            return _random.NextDouble();
        }
    }
}