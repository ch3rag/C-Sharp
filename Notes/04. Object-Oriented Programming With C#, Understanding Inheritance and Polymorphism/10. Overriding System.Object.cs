// SYSTEM.OBJECT & OVERRIDING

// Equals()
// By default, this method returns true only if the items being compared refer to the same item in memory. Thus, Equals() is used
// to compare object references, not the state of the object. Typically, this method is overridden to return true only if the objects being
// compared have the same internal state values. Be aware that if you override Equals(), you should also override GetHashCode(), as these
// methods are used internally by Hashtable types to retrieve subobjects from the container.

// Finalize()
// This method (when overridden) is called to free any allocated resources before the object is destroyed.

// GetHashCode()
// This method returns an int that identifies a specific object instance.

// ToString() 
// This method returns a string representation of this object, using the <namespace>.<type name> format (termed the fully qualified name). 
// This method will often be overridden by a subclass to return a tokenized string of name/value pairs that represent the object’s internal 
// state, rather than its fully qualified name.

// GetType() 
// This method returns a Type object that fully describes the object you are currently referencing. In short, this is a Runtime Type
// Identification (RTTI) method available to all objects

// MemberwiseClone()
// This method exists to return a member-by-member copy of the current object, which is often used when cloning an object 


using System;

namespace Experiment {

    public class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string fname, string lname, int age) {
            FirstName = fname;
            LastName = lname;
            Age = age;
        }

        public override string ToString() {
            return String.Format("[First Name: {0}; Last Name: {1}; Age: {2}]", FirstName, LastName, Age);
        }

        // public override bool Equals(object obj) {
        //     if (obj is Person && obj != null) {
        //         Person other = (Person)obj;
        //         return (this.FirstName == other.FirstName &&
        //             this.LastName == other.LastName &&
        //             this.Age == other.Age);
        //     }
         
        //     return false;
        // }

        // OR USING TOSTRING() (BETTER WAY)
        public override bool Equals(object obj) {           
            // C# 7 WAY
            // return obj?.ToString() == this.ToString();
            // OLD WAY
            return (obj == null ? null : obj.ToString()) == this.ToString();
           
        }

        // When a class overrides the Equals() method, you should also override the default implementation of GetHashCode() (YOU ARE WARNED BY 
        // COMPILER AS WELL). Simply put, a hash code is a numerical value that represents an object as a particular state. For example, if you 
        // create two string variables that hold the value Hello, you would obtain the same hash code. However, if one of the string objects 
        // were in all lowercase (hello), you would obtain different hash codes. By default, System.Object.GetHashCode() uses your object’s 
        // current location in memory to yield the hash value. However, if you are building a custom type that you intend to "store in a Hashtable 
        // type (within the System.Collections namespace)", you should always override this member, as the Hashtable will be internally invoking 
        // Equals() and GetHashCode() to retrieve the correct object.

        // WE ARE NOT STORING PERSON IN HASTABLE BUT WE OVERRIDE IT ANYWAY
        // IF PERSON CLASS HAS A UNIQUE DATA FIELD SUCH AS PHONE NUMBER WE CAN USE IT TO GENERATE HASCODE

        public override int GetHashCode() {
            return this.ToString().GetHashCode();
        }
    };

    class Program {
        static void Main(string[] args) {
            Person p = new Person("Scott", "Smith", 30);
            
            Console.WriteLine("ToString(): {0}", p.ToString());
            Console.WriteLine("GetHashCode(): {0}", p.GetHashCode());
            Console.WriteLine("GetType(): {0}", p.GetType());

            Person p2 = new Person("Scott", "Smith", 30);
            
            if(p.Equals(p2)) {
                Console.WriteLine("Same State");
            } else {
                Console.WriteLine("Different State");
            }

            if (Object.Equals(p, p2)) {
                Console.WriteLine("Same State");
            } else {
                Console.WriteLine("Different State");
            }

            if(p.GetHashCode() == p2.GetHashCode()) {
                Console.WriteLine("Same Hash Codes");
            } else {
                Console.WriteLine("Different Hash Codes");
            }

            p2.Age = 45;

            if(p.Equals(p2)) {
                Console.WriteLine("Same State");
            } else {
                Console.WriteLine("Different State");
            }

            if(p.GetHashCode() == p2.GetHashCode()) {
                Console.WriteLine("Same Hash Codes");
            } else {
                Console.WriteLine("Different Hash Codes");
            }

            Person p3 = p2;
            if(Object.ReferenceEquals(p3, p2)) {
                Console.WriteLine("Same Reference");
            } else {
                Console.WriteLine("Different Reference");
            }


            Console.ReadKey();
        }
    }
}
 