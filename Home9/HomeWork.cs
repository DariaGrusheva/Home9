using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home9
{
    // Дописать приложение поиска файла используя многопоточность

    internal class HomeWork
    {
        /// <summary>
        /// Поиск слов в файлах с использование многопоточности
        /// </summary>
        /// <param name="filePaths">Список имен файлов</param>
        /// <param name="word">Искомое слово</param>
        /// <returns></returns>
        public static List<string> FindWordInMultiThread(List<string> filePaths, string word)
        {
            List<string> result = new List<string>();
            var threads = new List<Thread>();
            foreach (var path in filePaths)
            {
                var thread = new Thread(() =>
                {
                    string content = File.ReadAllText(path);
                    if (content.Contains(word))
                        result.Add(path);
                });
                threads.Add(thread);
                thread.Start();
            }
            foreach (var thread in threads) thread.Join();
            return result;
        }

        /// <summary>
        /// Поиск имени файла
        /// </summary>
        /// <param name="path"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool FindWord(string path, string word)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    var tempStr = sr.ReadLine();
                    if (tempStr.Contains(word))
                    {
                        return true;
                    }
                }
                return false;
            }

        }


        /// <summary>
        /// Перебор файлов по заданному пути с заданным и добавлением в список имен файлов
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="fileExtension"> Расширение котрое ищем</param>
        /// <param name="list">Пополняемый список</param>
        public static void FindFiles(string path, string fileExtension, List<string> list)
        {
            list.AddRange(Directory.GetFiles(path, fileExtension));

            foreach (var dir in Directory.GetDirectories(path))
            {
                FindFiles(dir, fileExtension, list);
            }
        }

    }
}