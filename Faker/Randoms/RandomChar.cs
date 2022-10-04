using System;
using Faker.Abstrations;

namespace Faker.Randoms
{
    public class RandomChar:RandomValue
    {
        public override object Get(Type type)
        {
            return (char) _random.Next(-1, 256);
        }
    }
}