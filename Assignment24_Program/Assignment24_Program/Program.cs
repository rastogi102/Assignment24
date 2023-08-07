using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConAppAssignment24;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment24_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 2 - Binary Serialization and Deserialization
            Employee employee = new Employee
            {
                Id = 101,
                FirstName = "Nikhil",
                LastName = "Rastogi",
                Salary = 50000.0
            };

            // Binary Serialization
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("employee.bin", FileMode.Create))
            {
                binaryFormatter.Serialize(fileStream, employee);
            }

            // Binary Deserialization
            Employee deserializedEmployee;
            using (FileStream fileStream = new FileStream("employee.bin", FileMode.Open))
            {
                deserializedEmployee = (Employee)binaryFormatter.Deserialize(fileStream);
            }

            // Display properties of deserialized Employee
            Console.WriteLine("Binary Deserialization Result:");
            Console.WriteLine($"ID: {deserializedEmployee.Id}");
            Console.WriteLine($"First Name: {deserializedEmployee.FirstName}");
            Console.WriteLine($"Last Name: {deserializedEmployee.LastName}");
            Console.WriteLine($"Salary: {deserializedEmployee.Salary}");

            

            // Step 3 - XML Serialization and Deserialization
            // XML Serialization
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            using (FileStream fileStream = new FileStream("F:\\Training Stuff\\Dot netTraining\\DAY-21\\Assignment-24\\employee.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, employee);
            }
            using (FileStream fileStream = new FileStream("F:\\Training Stuff\\Dot netTraining\\DAY-21\\Assignment-24\\employee.xml", FileMode.Open))
            {
                deserializedEmployee = (Employee)xmlSerializer.Deserialize(fileStream);
            }

            // Display properties of deserialized Employee
            Console.WriteLine("\nXML Deserialization Result:");
            Console.WriteLine($"ID: {deserializedEmployee.Id}");
            Console.WriteLine($"First Name: {deserializedEmployee.FirstName}");
            Console.WriteLine($"Last Name: {deserializedEmployee.LastName}");
            Console.WriteLine($"Salary: {deserializedEmployee.Salary}");

            Console.ReadKey();
        }
    }
    
    
}
