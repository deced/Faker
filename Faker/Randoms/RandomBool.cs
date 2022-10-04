using System;
using Faker.Abstrations;

namespace Faker.Randoms
{
    public class RandomBool: RandomValue
    {
        public override object Get(Type type)
        {
            if (_random.Next(-1, 2) == 1)
                return true;
            return false;
        }
        
    }
}