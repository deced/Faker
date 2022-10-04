using System;
using Faker.Abstrations;

namespace Faker.Randoms
{
    public class RandomFloat : RandomValue
    {
        public override object Get(Type type)
        {
            return (float) _random.NextDouble();
        }
    }
}