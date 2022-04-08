using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Console;
using StudentLibrary;
using System.Xml;

namespace Practic_06_04
{

#if osVersion
    public unsafe struct OsVersionInfo
    {
        public uint osVersionInfoSize;
        public uint majorVersion;
        public uint minorVersion;
        public uint buildVersion;
        public uint platformId;
        public fixed byte servicePackVersion[128];

    }

    public class DllImportExample
    {
        [DllImport("Kernel32.dll", EntryPoint = "GetVersionEx")]
        public static extern bool GetVersion(ref OsVersionInfo vetsionInfo);
    } 
#endif

#if MessageBox2
    public class DllImportExample
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr h, string text, string c, int type);
    } 
#endif

#if PrintF
    public class DllImportExample
    {
        [DllImport("msvcrt.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int printf(string f, int i, double d);

        [DllImport("msvcrt.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int printf(string f, int i, string s);
    } 
#endif

#if UserName
    public class DllImportExample
    {
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool GetUserName(StringBuilder b, ref int lenght);
    } 
#endif

#if NotePad
    public class DllImportExample
    {
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr p);
    } 
#endif

#if Calc
    public class DllImportExample
    {
        [DllImport("SimpleCalc.dll")]
        public static extern int add(int a, int b);
        [DllImport("SimpleCalc.dll")]
        public static extern int sub(int a, int b);
        [DllImport("SimpleCalc.dll")]
        public static extern int mult(int a, int b);
        [DllImport("SimpleCalc.dll")]
        public static extern int div(int a, int b);
    } 
#endif

    internal class Program
    {

#if MessageBox
        [DllImport("user32.dll", ExactSpelling = true)]
        static extern int MessageBoxA(IntPtr h, string m, string c, int type); 
#endif

#if OutputNode
        static void OutputNode(XmlNode node)
        {
            WriteLine($"Type - {node.NodeType}\tName - {node.Name}\tValue - {node.Value}");
            if (node.Attributes != null)
            {
                foreach (XmlNode attrib in node.Attributes)
                {
                    WriteLine($"Type - {node.NodeType}\tName - {node.Name}\tValue - {node.Value}");
                }
            }
            if (node.HasChildNodes)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                    OutputNode(childNode);
            }
        } 
#endif

        static void Main(string[] args)
        {

#if MessageBox
            MessageBoxA(IntPtr.Zero, "Testing is successful", "Test DllImportAttribute", 0); 
#endif

#if osVersion
            OsVersionInfo versionInfo = new OsVersionInfo();
            versionInfo.osVersionInfoSize = (uint)Marshal.SizeOf(typeof(OsVersionInfo));

            bool result = DllImportExample.GetVersion(ref versionInfo);

            if (result)
            {
                Console.WriteLine($"Assembly ID {versionInfo.buildVersion}");
            } 
#endif

#if MessageBox2
            DllImportExample.MessageBox(IntPtr.Zero, "Testing is successful", "Test Dll", 0); 
#endif

#if PrintF
            DllImportExample.printf("Print params: %i %f\n", 99, 99.99);
            DllImportExample.printf("Print params: %i %s\n", 99, "qwerty"); 
#endif

#if UserName
            int lenght = 20;
            StringBuilder sb = new StringBuilder();

            DllImportExample.GetUserName(sb, ref lenght);
            Console.WriteLine($"User Name: {sb}"); 
#endif

#if NotePad
            string proccessName = "notepad.exe", text;
            Console.WriteLine("Введите текст: ");
            text = Console.ReadLine();
            Process p = Process.Start(proccessName);
            p.WaitForInputIdle();
            IntPtr h = p.MainWindowHandle;
            DllImportExample.SetForegroundWindow(h);
            SendKeys.SendWait(text); 
#endif

#if Calc
            try
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                Console.WriteLine(DllImportExample.add(num1, num2));
                Console.WriteLine(DllImportExample.sub(num1, num2));
                Console.WriteLine(DllImportExample.mult(num1, num2));
                Console.WriteLine(DllImportExample.div(num1, num2));
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); } 
#endif

#if Dll_Student
            Student student = new Student()
            {
                FirstName = "Alex",
                LastName = "Dronov",
                BirthDate = new DateTime(1990, 03, 07)
            };

            WriteLine(student); 
#endif

#if XML
            //XPath
            //XSLT
            //DOM
            //SAX

            XmlTextWriter writer = null;

            try
            {
                writer = new XmlTextWriter("Cars.xml", System.Text.Encoding.Unicode);
                //делает отступы
                writer.Formatting = Formatting.Indented;
                //Indetation IndentChar
                writer.WriteStartDocument();
                writer.WriteStartElement("Cars");
                writer.WriteStartElement("Car");
                writer.WriteAttributeString("Image", "MyCar.jpeg");
                writer.WriteElementString("Manufactured", "Описание");
                writer.WriteElementString("Model", "Описание модели");
                writer.WriteElementString("Year", "1912");
                writer.WriteElementString("Color", "Black");
                writer.WriteElementString("Speed", "180");
                writer.WriteEndElement();
                writer.WriteEndElement();
                WriteLine("Все прошло успешно!");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            {
                if (writer != null)
                    writer.Close();
            } 
#endif

#if OutputNode
            //XmlDocument.DocumentElement
            //XmlNode
            //Load()
            //HashChildNodes
            //ChildNodes

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Cars.xml");
                OutputNode(doc.DocumentElement);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
#endif

#if Add_Xml
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Cars.xml");

                XmlNode root = doc.DocumentElement;
                //root.RemoveChild(root.FirstChild); //удаление
                //создание элементов
                XmlNode bike = doc.CreateElement("Moto");
                XmlNode elem1 = doc.CreateElement("Manufactured");
                XmlNode elem2 = doc.CreateElement("Model");
                XmlNode elem3 = doc.CreateElement("Year");
                XmlNode elem4 = doc.CreateElement("Color");

                //создание текстовых узлов
                XmlNode text1 = doc.CreateTextNode("Harley");
                XmlNode text2 = doc.CreateTextNode("Harley 20J");
                XmlNode text3 = doc.CreateTextNode("1980");
                XmlNode text4 = doc.CreateTextNode("Olive");

                //присоединение узлов текста к узлам элементов
                elem1.AppendChild(text1);
                elem2.AppendChild(text2);
                elem3.AppendChild(text3);
                elem4.AppendChild(text4);

                //присоединение узлов элементов к узлу байка
                bike.AppendChild(elem1);
                bike.AppendChild(elem2);
                bike.AppendChild(elem3);
                bike.AppendChild(elem4);

                //присоединение узла байк к корневому узлу
                root.AppendChild(bike);

                //сохранение измененного документа
                doc.Save("Cars.xml");
            }
            catch (Exception ex)
            { WriteLine(ex.Message); } 
#endif

#if XmlTextReader
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader("Cars.xml");
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    WriteLine($"Type {reader.NodeType}, Name {reader.Name}, Value {reader.Value}");

                    if (reader.AttributeCount > 0)
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            WriteLine($"Type {reader.NodeType}, Name {reader.Name}, Value {reader.Value}");
                        }
                    }
                }
            }
            catch (Exception ex)
            { WriteLine(ex.Message); }
            finally
            {
                if (reader != null)
                    reader.Close();
            } 
#endif

#if XmlTextReader_Color
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader("Cars.xml");
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Cars" && reader.AttributeCount > 0)
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            if (reader.Name == "Moto")
                            {
                                WriteLine(reader.Value);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { WriteLine(ex.Message); }
            finally
            {
                if (reader != null)
                    reader.Close();
            } 
#endif

        }
    }
}
