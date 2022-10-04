using System;
using System.Collections.Generic;
using System.Reflection;
using Faker.Abstrations;

namespace Faker.Randoms
{
    public class RandomList : RandomValue
    {
        public override object Get(Type type)
        {
            var genericType = type.GenericTypeArguments;
            var list = Activator.CreateInstance(type);

            var size = (byte) _random.Next(1, 15);
            for (int i = 0; i < size; i++)
            {
                var methodInfo = typeof(Faker).GetMethod("Create");
                var methodInfoRef = methodInfo.MakeGenericMethod(genericType[0]);
                var element = methodInfoRef.Invoke(new Faker(), null);
                var tempArray = new object[] {element};
                MethodInfo magicMethod = type.GetMethod("Add");
                magicMethod.Invoke(list, tempArray);
            }
            return list;
        }
    }
}
//рекурсия, тесты