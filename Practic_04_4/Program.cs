using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_04_4
{

#if Binary
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int _indentNumber;

        [NonSerialized]
        const string Planet = "Earth";

        public Person(int number)
        {
            _indentNumber = number;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, " + $"Identification number: {_indentNumber}, Planet: {Planet}";
        }
    } 
#endif

#if SOAP
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int _indentNumber;

        [NonSerialized]
        const string Planet = "Earth";

        public Person(int number)
        {
            _indentNumber = number;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, " + $"Identification number: {_indentNumber}, Planet: {Planet}";
        }
    } 
#endif

#if XML
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int _indentNumber;

        [NonSerialized]
        const string Planet = "Earth";

        public Person() { }

        public Person(int number)
        {
            _indentNumber = number;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, " + $"Identification number: {_indentNumber}, Planet: {Planet}";
        }
    } 
#endif

#if XML_LIST
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int _indentNumber;

        [NonSerialized]
        const string Planet = "Earth";

        public Person() { }

        public Person(int number)
        {
            _indentNumber = number;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, " + $"Identification number: {_indentNumber}, Planet: {Planet}";
        }
    } 
#endif

#if On_De_ser
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        //вызывается во время процесса сериализации
        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            Name = Name.ToUpper();
            BirthDate = BirthDate.ToUniversalTime();
        }

        //вызывается по завершению процесса десериализации
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Name = Name.ToLower();
            BirthDate = BirthDate.ToLocalTime();
        }


        public override string ToString()
        {
            return $"Name: {Name}, BirthDate: {BirthDate}";
        }

    } 
#endif

#if Serialization
    [Serializable]
    public class Person : ISerializable
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public Person() { }

        private Person(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name").ToUpper();
            BirthDate = info.GetDateTime("Date of Birth").ToUniversalTime();
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name.ToLower());
            info.AddValue("Date of Birth", BirthDate.ToLocalTime());
        }

        public override string ToString()
        {
            return $"Name: {Name}, BirthDate: {BirthDate}";
        }

    } 
#endif

    internal class Program
    {
        static void Main(string[] args)
        {
#if Binary
            Person person = new Person(35478) { Name = "Alex", Age = 50 };

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                using (Stream fStream = File.Create("test.bin"))
                {
                    binaryFormatter.Serialize(fStream, person);
                }
                WriteLine("Бинарная серилизация прошла успешно!");

                Person p = null;

                using (Stream fStream = File.OpenRead("test.bin"))
                {
                    p = (Person)binaryFormatter.Deserialize(fStream);
                }
                WriteLine(p);
            }
            catch (Exception ex)
            { WriteLine(ex.Message); } 
#endif

#if SOAP
            Person person = new Person(35478) { Name = "Alex", Age = 50 };

            SoapFormatter soapFormatter = new SoapFormatter();

            try
            {
                using (Stream fStream = File.Create("test.soap"))
                {
                    soapFormatter.Serialize(fStream, person);
                }
                WriteLine("Soap серилизация прошла успешно!");

                Person p = null;

                using (Stream fStream = File.OpenRead("test.soap"))
                {
                    p = (Person)soapFormatter.Deserialize(fStream);
                }
                WriteLine(p);
            }
            catch (Exception ex)
            { WriteLine(ex.Message); } 
#endif

#if XML
            Person person = new Person(35478) { Name = "Alex", Age = 50 };

            XmlSerializer xmlFormatter = new XmlSerializer(typeof(Person));

            try
            {
                using (Stream fStream = File.Create("test.xml"))
                {
                    xmlFormatter.Serialize(fStream, person);
                }
                WriteLine("XML серилизация прошла успешно!");

                Person p = null;

                using (Stream fStream = File.OpenRead("test.xml"))
                {
                    p = (Person)xmlFormatter.Deserialize(fStream);
                }
                WriteLine(p);
            }
            catch (Exception ex)
            { WriteLine(ex.Message); } 
#endif

#if XML_LIST
            List<Person> persons = new List<Person>()
            {
                new Person(79844){Name = "Alex",Age = 50},
                new Person(46516){Name = "Ivan",Age = 24},
                new Person(14887){Name = "Petr",Age = 48}
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));

            try
            {
                using (Stream stream = File.Create("test1.xml"))
                {
                    xmlSerializer.Serialize(stream, persons);
                }

                WriteLine("Сериализация прошла успешно!");

                List<Person> list = null;
                using (Stream stream = File.OpenRead("test1.xml"))
                {
                    list = (List<Person>)xmlSerializer.Deserialize(stream);
                }

                foreach (Person person in list)
                    WriteLine(person);
            }
            catch (Exception ex)
            { WriteLine(ex.Message); } 
#endif

#if On_De_ser
            Person person = new Person
            {
                Name = "Alex",
                BirthDate = new DateTime(1998, 11, 5)
            };

            SoapFormatter soapFormatter = new SoapFormatter();

            try
            {
                using (Stream stream = File.Create("test.soap"))
                {
                    soapFormatter.Serialize(stream, person);
                }
                WriteLine("SOAP сериализация прошла успешно!");
                Person p = null;
                using (Stream stream = File.OpenRead("test.soap"))
                {
                    p = (Person)soapFormatter.Deserialize(stream);
                }
                WriteLine(p);
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            } 
#endif

#if Seralization
            Person person = new Person { Name = "Alex", BirthDate = new DateTime(1996, 5, 5) };

            SoapFormatter soapFormatter = new SoapFormatter();

            try
            {
                using (Stream stream = File.Create("test3.soap"))
                {
                    soapFormatter.Serialize(stream, person);
                }
                WriteLine("SOAP сериализация прошла успешно!");

                Person p = null;

                using (Stream stream = File.OpenRead("test3.soap"))
                {
                    p = (Person)soapFormatter.Deserialize(stream);
                }
                WriteLine(p);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            } 
#endif

        }
    }
}
