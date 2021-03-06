﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableList
{
    public class ImmutableList
    {
        public List<int> collection;

        public ImmutableList(List<int> collection)
        {
            if (collection == null)
            {
                this.collection = new List<int>();
            }

            this.collection = collection;
        }

        public ImmutableList Get()
        {
            var newCollection = new List<int>(this.collection);
            var newImmutable = new ImmutableList(newCollection);
            return newImmutable;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Type immutableList = typeof(ImmutableList);
            FieldInfo[] fields = immutableList.GetFields();
            if (fields.Length < 1)
            {
                throw new Exception();
            }
            else
            {
                Console.WriteLine(fields.Length);
            }

            MethodInfo[] methods = immutableList.GetMethods();
            bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("ImmutableList"));
            if (!containsMethod)
            {
                throw new Exception();
            }
            else
            {
                Console.WriteLine(methods[0].ReturnType.Name);
            }
        }
    }
}
