using System;

namespace Faker.Abstrations
{
    public abstract class RandomValue
    {
        protected static Random _random;

        static RandomValue()
        {
            _random = new Random();
        }

        public abstract object Get(Type type);
    }
}