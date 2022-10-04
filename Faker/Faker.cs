using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Faker.Abstrations;
using Faker.Randoms;

namespace Faker
{
    public class Faker
    {
        private Dictionary<string, RandomValue> _randoms;
        public List<string> types;

        public T Create<T>()
        {
            return (T) Create(typeof(T));
        }

        public Faker()
        {
            types = new List<string>();
            _randoms = new Dictionary<string, RandomValue>()
            {
                { nameof(Boolean), new RandomBool() },
                { nameof(Byte), new RandomByte() },
                { nameof(Char), new RandomChar() },
                { nameof(TimeSpan), new RandomTimeSpan() },
                { nameof(Double), new RandomDouble() },
                { nameof(Single), new RandomFloat() },
                { nameof(Int32), new RandomInt() },
                { typeof(List<>).Name, new RandomList() },
                { nameof(Int64), new RandomLong() },
                { nameof(Int16), new RandomShort() },
                { nameof(String), new RandomString() }
            };
        }
        

        private object CreateObjectUsingConstructor(Type type)
        {
            var constructors = type
                .GetConstructors(BindingFlags.Instance | BindingFlags.Public)
                .OrderByDescending(x => x.GetParameters().Length)
                .ToList();
            
            if (constructors.Count == 0 && type.BaseType != typeof(ValueType))
                throw new Exception("Unable to create object with private constructor");
            
            foreach (var constructor in constructors)
            {
                var parameterValues = new List<object>();
                var parameters = constructor.GetParameters();
                foreach (var parameter in parameters)
                    parameterValues.Add(Create(parameter.ParameterType));
                
                try
                {
                    var obj = Activator.CreateInstance(type, args: parameterValues.ToArray());
                    return obj;
                }
                catch { }
            }

            return Activator.CreateInstance(type);
        }

        private object Create(Type type)
        {
            if (types.Any(x => x == type.Name))
                return null;

            if (_randoms.ContainsKey(type.Name))
                return _randoms[type.Name].Get(type);

            if (type.IsValueType)
                return Activator.CreateInstance(type);
            
            types.Add(type.Name);
            
            var obj = CreateObjectUsingConstructor(type);
            
            var properties = type.GetProperties();
            foreach (var property in properties)
                property.SetValue(obj, Create(property.PropertyType));
            
            var fields = type.GetFields();
            foreach (var field in fields)
                field.SetValue(obj, Create(field.FieldType));
            
            return obj;
        }
    }
}