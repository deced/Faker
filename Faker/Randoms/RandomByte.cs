using System;
using Faker.Abstrations;

namespace Faker.Randoms
{
    public class RandomByte : RandomValue
    {
        public override object Get(Type type)
        {
            return (byte) _random.Next(1, 256);
        }
    }
}