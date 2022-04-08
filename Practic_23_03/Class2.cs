using System;
using static System.Console;
using static System.Exception;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_23_03
{
#if sposob1
    public class MyException : ApplicationException
    {
        private string _message;
        public DateTime TimeException { get; private set; }

        public MyException()
        {
            _message = "Моё исключение";
            TimeException = DateTime.Now;
        }

        public override string Message
        {
            get { return _message; }
        }
    } 
#endif

#if sposob2
    public class MyException : ApplicationException
    {
        public DateTime TimeException { get; private set; }

        public MyException() : base("Моё исключение") { TimeException = DateTime.Now; }
    } 
#endif


#if true
    [Serializable]
    public class MyException : Exception
    {
        public DateTime TimeException { get; private set; }
        public MyException() : this("Моё исключение") { TimeException = DateTime.Now; }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception inner) : base(message, inner) { }
        protected MyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
#endif

    internal class Class2
    {
        /*
        string Message
        IDictionary Data
        string Source
        Methodbase TargetSite
        string HelpLink
        Exception InnerException
         */

        /*
        SystemException
            StackOverflowException
            ArgumentException

        ApplicationException
         */
        public void DividByZero()
        {
            try
            {
                int a = int.Parse(ReadLine());
                int b = int.Parse(ReadLine());
                WriteLine($"{a} / {b} = {a / b}");
            }
            catch (DivideByZeroException ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                WriteLine("Освобождение ресурсов");
            }
        }
    }
}
