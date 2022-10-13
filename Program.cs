using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainData;

namespace MainData
{
    public class Animal
    {
        protected string name;
        protected int age;
        protected double height, weight;
        public Animal(string name = "", int age = 0, double height = 0, double weight = 0)
        {
            this.name = name;
            this.age = age;
            this.height = height;
            this.weight = weight;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine("Name = {0}, Age = {1}, Height = {2}, Weight = {3}", name, age, height, weight);
        }
        public void InputInfo()
        {
            Console.Write("Input Name:");
            name = Console.ReadLine();

            Console.Write("Input Age:");
            string str = Console.ReadLine();
            age = int.Parse(str);
            InputAge(age);

            Console.Write("Input Height:");
            string strheight = Console.ReadLine();
            InputHeigt(strheight);


            Console.Write("Input Weight:");
            string strweight = Console.ReadLine();
            InputWeight(strweight);
        }
        public void InputHeigt(string Height)
        {
            try
            {
                height = double.Parse(Height);
            }
            catch (FormatException)
            {
                Console.Write("Please reinput number: ");
                string strheight = Console.ReadLine();
                InputHeigt(strheight);
            }
        }

        public void InputWeight(string Weight)
        {
            try
            {
                weight = double.Parse(Weight);
            }
            catch (FormatException)
            {
                Console.Write("Please reinput number: ");
                string strweight = Console.ReadLine();
                InputHeigt(strweight);
            }
        }
        public void InputAge(int Age)
        {

            try
            {
                if (age <= 0 || age > 20)
                    throw (new InvalidNumException("Invalid Age"));
            }
            catch (InvalidNumException e)
            {
                Console.Write("{0} \nPlease input Age again:", e);
                string str = Console.ReadLine();
                age = int.Parse(str);
                InputAge(age);
            }
        }
    }
    public class Dog : Animal
    {

        public Dog(string name = "", int age = 0, double height = 0, double weight = 0) : base(name, age, height, weight) { }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
        }
        public override string ToString()
        {
            return "Age = " + age + ", Name = " + name + ", Height = " + height + ", Weight = " + weight;
        }
    }

    public class Cat : Animal
    {
        public Cat(string name = "", int age = 0, double height = 0, double weight = 0) : base(name, age, height, weight) { }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
        }
        public override string ToString()
        {
            return "Age = " + age + ", Name = " + name + ", Height = " + height + ", Weight = " + weight;
        }
    }
    public class InvalidNumException : Exception
    {
        public InvalidNumException() { }
        public InvalidNumException(string message) : base(message) { }
    }
}

namespace AnimalListManagament
{
    class Program
    {
        static public void Process()
        {
            int nDog = 3;
            int nCat = 2;
            Dog dog;
            Cat cat;
            Animal[] animals = new Animal[nDog + nCat];
            for (int i = 0; i < nDog; i++)
            {
                dog = new Dog();
                Console.WriteLine("Input Information of Dog {0}: ", i + 1);
                animals[i] = (Dog)dog;
                dog.InputInfo();
            }
            for (int i = 0; i < nCat; i++)
            {
                cat = new Cat();
                Console.WriteLine("Input Information of Cat {0}: ", i + 1);
                animals[nDog + i] = (Cat)cat;
                cat.InputInfo();
            }
            Console.WriteLine("-------LIST OF DOGS------:");
            for (int i = 0; i < (nDog); i++)
            {

                animals[i].DisplayInfo();
            }
            Console.WriteLine("-------LIST OF CATS------:");
            for (int i = 0; i < nCat; i++)
            {

                animals[i + nDog].DisplayInfo();
            }
        }
        static void Main(string[] args)
        {
            Process();
            Console.ReadLine();
        }
    }
}

