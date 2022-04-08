using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_28_03
{
    internal class Program
    {

#if Zapis_i_4tenie_string
        static void WriteFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                WriteLine("Введите значение для записи в файл: ");
                string writeText = ReadLine();
                byte[] writeBytes = Encoding.Default.GetBytes(writeText);
                fs.Write(writeBytes, 0, writeBytes.Length);
                WriteLine("Информация записана!");
            }
        }

        static string ReadFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] readBytes = new byte[(int)fs.Length];
                fs.Read(readBytes, 0, readBytes.Length);
                return Encoding.Default.GetString(readBytes);
            }
        } 
#endif

#if DirectoryInfo1
        static void WriteFile(FileInfo file)
        {
            using (FileStream fs = file.Open(FileMode.Create, FileAccess.Write, FileShare.None))
            {
                WriteLine("Введите информацию для записи: ");
                string writeText = ReadLine();
                byte[] writeBytes = Encoding.UTF8.GetBytes(writeText);
                fs.Write(writeBytes, 0, writeBytes.Length);
                WriteLine("Запись завершена!");
            }
        }

        static string ReeadFile(FileInfo file)
        {
            using (FileStream fs = file.OpenRead())
            {
                byte[] readBytes = new byte[(int)fs.Length];
                fs.Read(readBytes, 0, readBytes.Length);
                return Encoding.UTF8.GetString(readBytes);
            }
        } 
#endif

#if StreamReader
        static void WriteFile(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                WriteLine("Введите информацию для записи: ");
                string writeText = ReadLine();
                sw.WriteLine(writeText);
                foreach (var i in writeText)
                    sw.WriteLine(i + " ");
                WriteLine("\nЗапись завершена!");
            }
        }

        static string ReeadFile(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                return sr.ReadToEnd();
            }
        } 
#endif

        static void Main(string[] args)
        {
#if Konspekt
            /*
              StreamWriter
                 свойства:
                     CanRead and CanWrite (true/false) - определяют возможность чтения или записи
                     CanSeek (true/false) - подерживает возможно ли позиционирование потоков
                 методы:
                     Read() and Write() - выполняют чтение или запись
                     Seek() или Свойство Position - устонавливает позицию в потоке
                     SetLenght() - позволяет изменить длину потока
                     Flush() - используется для удаление буферов и обеспечивает запись данных в хранилище либо в поток
                     Close() - освобождает ресурсы потоков(закрывает потоки) 

              StreamReader
                 свойства
                     BaseStream
                     CurrentEncoding
                     EndOfStream
                 методы
                     Read()
                     ReadBlock()
                     ReadLine()
                     ReadToEnd()

             */

            /*
            Байтовые классы
            FileStream
            MemoryStream
            BufferedStream

            Символные классы
            TextReader - базовый класс для StringReader
                StreamReader - обеспечивает чтение символов в байтовой кодировке её можно изменить
            TextWriter - базовый клас для StringWriter
                StreamWriter - обеспечивает запись символов в байтовой кодировке её можно изменить
             
            Двоичные классы
            BinaryReader - для чтение двоичных данных из потока можно поменять систему счисления
            BinaryWriter - для записи двоичных данных из потока можно поменять систему счисления
             */ 

            /*
            FileStream file = new FileStream(путь к файлу, режим_создания, режим_доступа, режим_совместного_использования);
            путь к файлу - обсолютный или относительный(если в папке debug) (C:/Users/User/Text.txt)(Text.txt)
            
            режим_создания - классы FileMode:
            1.FileMode.Append - открывает файл если существует перемещает курсор в конец или создает новый файл
            2.FileMode.Create - Если существует файл тогда создает новый
            3.FileMode.CreateNew - Создает новый файл если создает то вызывает исключение(IOException)
            4.FileMode.Open - открывает файл если его нет то исключение (FileNotFindException)
            5.FileMode.OpenOrCreate - открывает файл или создает если его нет
            6.FileMode.Truncate - открывает файл и очищает его
            
            режим_доступа - FileAccess
            FileAccess.Write
            FileAccess.Read
            FileAccess.ReadWrite

            режим_совместного_использования - FileShare
            FileShare.Delete - разрешает удаление файла
            FileShare.Inheritable - Наследование дискрипторов файла
            FileShare.None - отклоняет совместное использование файла
            FileShare.Read - разрешает читать файл нельзя использовать пока не будет закрыт пред 
            FileShare.ReadWrite
            FileShare.Write - разрешает записовать в файл нельзя использовать пока не будет закрыт пред 
            */

            /*
            Directory
                DirectoryInfo

            File
                FileInfo
            
            
            
            */
#endif

#if Zapis_i_chtenie
            string filePath = "text.bin";
            WriteFile(filePath);
            WriteLine($"Результат чтения из файла: {ReadFile(filePath)}"); 
#endif

#if StreamWriter
            string filePath = "test.txt";
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    WriteLine("Введите информацию для записи в файл: ");
                    string writeText = ReadLine();
                    sw.WriteLine(writeText);
                    foreach (var i in writeText)
                        sw.Write(i + " ");
                    WriteLine("Информация записана");
                }
            } 
#endif

#if StreamReader
            string filePath = "test.txt";
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    WriteLine("Чтение информации из файла: ");
                    WriteLine(sr.ReadToEnd());
                }
            } 
#endif

#if BinaryWriter
            string filePath = "test.dat";
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Unicode))
                {
                    WriteLine("Введите информацию для записи в файл: ");
                    string writeText = ReadLine();
                    double pi = 3.14;
                    int num = 123465;

                    bw.Write(writeText);
                    bw.Write(pi);
                    bw.Write(num);

                    WriteLine("Запись завершина!");
                }
            } 
#endif

#if BinaryReader
            string filePath = "test.dat";
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs, Encoding.Unicode))
                {
                    WriteLine("Чтение информации из файла: ");
                    WriteLine(br.ReadString());
                    WriteLine(br.ReadDouble());
                    WriteLine(br.ReadInt32());
                }
            } 
#endif

#if DirectoryInfo
            DirectoryInfo dir = new DirectoryInfo(".");
            WriteLine($"Полный путь к каталогу: {dir.FullName}");
            WriteLine($"Время создания: {dir.CreationTime}");

            WriteLine($"Все файлы каталога: ");
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
                WriteLine(file.Name); 
#endif

#if DirectoryInfo1
            DirectoryInfo dir = new DirectoryInfo("C:\\Test");
            if (!dir.Exists)
                dir.Create();
            else
                WriteLine($"Каталог уже существует, {dir.LastAccessTime}");

            DirectoryInfo dir1 = dir.CreateSubdirectory("SubTest");
            WriteLine($"Полный путь к каталогу SubTest: {dir1.FullName}");
            FileInfo file = new FileInfo(dir1 + "\\Test.bin");
            WriteFile(file);
            WriteLine(ReeadFile(file));

            WriteLine("Только файл с расширением bin: ");
            FileInfo[] fileInfos = dir1.GetFiles("*.bin");
            foreach (FileInfo fileInfo in fileInfos)
                WriteLine(fileInfo.Name); 
#endif

#if StreamReader
            string path = "C:\\Test\\SubTest\\Test.txt";

            try
            {
                WriteFile(path);
                WriteLine($"Чтение информации из файла");
                WriteLine(ReeadFile(path));
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            } 
#endif

#if Directory
            string path = "C:\\Test";

            if (Directory.Exists(path))
            {
                WriteLine($"Дата и время создания каталога: {Directory.GetCreationTime(path)}");
                WriteLine("какие подкаталоги содержатся: ");
                foreach (string file in Directory.GetDirectories(path))
                    WriteLine(file);

                WriteLine($"Логические девайсы на компьютере");
                foreach (string file in Directory.GetLogicalDrives())
                    WriteLine(file);

                Directory.Delete(path, true);
            }

            if (!Directory.Exists(path))
                WriteLine("Такого каталога не существует"); 
#endif


        }
    }
}
