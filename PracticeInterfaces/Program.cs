using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This is a program which demonstrates some of the concepts of interfaces
//Emer Campbell
//2017

namespace PracticeInterfaces
{
    class Program
    {

        interface IAnimal //Note the convention for naming an interface
            
            //note that an interface has no fields

        {            
            string Describe();//note that the constructor isn't fully implemented as this is an interface            
        }
        
        class Dog : IAnimal, IComparable<Dog> /*note that the dog class can inherit from 2 base classes.  
                                              This is only possible with interfaces.  Also note that the IComporable interface must state 
                                               the class name it is being implemented for. (Dog)*/
        {
            private string name;
            
            public Dog(string name)//field constructor to initialise the Dog properties
            {
                this.name = name;
            }

            public string Describe()
            {
                return "Hello, I'm a dog and my name is " + this.name;
            }

            public int CompareTo(Dog other)/*  Implements the CompareTo method from the Icomparable class.  Remember that because IComparable 
                                            * is an interface, the implementation must be finished in the base class.*/ 
            {              
                return this.Name.CompareTo(other.Name); /* This statement compares the properties of this instance of the class with the object 
                                                         being passed in as a parameter*/
            }


            public string Name //get sets allows us to access the private variable 'name' from outside the class
            {
                get { return name; }
                set { name = value; }
            }
        }


        static void Main(string[] args)
        {      
            List<Dog> dogs = new List<Dog>(); //Initialise a list of Dog objects and set the name property
            dogs.Add(new Dog("Fido"));
            dogs.Add(new Dog("Bob"));
            dogs.Add(new Dog("Adam"));

            Dog newdog = new Dog("Bob");/*Create a new Dog object, initialise it with a name and call the Describe method*/
            Console.WriteLine(newdog.Describe());
            Console.WriteLine("I'm a new dog");
            
            for(int i = 0; i<3;i++) //loop through each dog in the list
            {
                Console.WriteLine(dogs[i].Describe());//call the describe mtthod for each dod in the list (allows us to illustrate that CompareTo is working

                /*Because of the structure of CompareTo, it is the CompareTo method belonging to the list object which is called in the if statement.  This list object is 
                 compared to the new dog as the new dog is the one passed in in the parameter.  If CompareTo returns 1, the list object needs to be sorted alphabetically
                 after the new dog object.  If -1 is returned, the list object needs to be sorted alphabetically before the new dog.  If it returns 0 the values are the same.*/
                
                if (dogs[i].Name.CompareTo(newdog.Name) == -1)
                {
                    Console.WriteLine("My name comes before the new dog's in the alphabet");
                }
                else if(dogs[i].Name.CompareTo(newdog.Name) == 1)
                {
                    Console.WriteLine("My name comes after the new dog's in the alphabet");
                }
                else if(dogs[i].Name.CompareTo(newdog.Name) == 0)
                {
                    Console.WriteLine("My name is the same as the new dog's");
                }

            }
            Console.ReadKey();

        }
    }
}
