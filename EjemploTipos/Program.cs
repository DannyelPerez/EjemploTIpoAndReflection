using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EjemploTipos
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic a = 12.1f;
            a = 1;
            a = "hola";
            a = Activator.CreateInstance(Type.GetType("EjemploTipos.MyClass"), new object[] {12});
            Console.WriteLine(a);

            Console.WriteLine(suma(a.getNumero(),2));
            Console.WriteLine(suma("Hola", "Mundo"));
            Type type = a.GetType();
            Console.WriteLine(type.FullName);
            var fields = type.GetFields(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance);
            foreach (var field in fields)
            {
                Console.WriteLine(field.Name+" = "+field.GetValue(a));
            }
            Console.ReadKey();

        }

        static dynamic suma(dynamic a, dynamic b)
        {
            return a + b;
        }
    }


    class MyClass
    {
        private int _numero;
        public int otro = 23; 
        public MyClass(int numero)
        {
            _numero = numero;
        }

        public int getNumero()
        {
            return _numero;

        }
    }
}

