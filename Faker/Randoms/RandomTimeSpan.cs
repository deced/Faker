using System;
using System.Globalization;
using Faker.Abstrations;

namespace Faker.Randoms
{
    public class RandomTimeSpan:RandomValue
    {
        public override object Get(Type type)
        {
            return TimeSpan.FromSeconds(_random.Next());
        }
    }
}