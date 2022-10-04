using System;
using Faker.Abstrations;

namespace Faker.Randoms
{
    public class RandomString:RandomValue
    {
        public override object Get(Type type)
        {
            string str = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            string result = "";
            for (byte i = 0; i < _random.Next(0, 255); i++)
                result += str[_random.Next(0, str.Length)];
            return result;
        }

    }
    
}