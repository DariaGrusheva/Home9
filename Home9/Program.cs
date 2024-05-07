using System.IO;
using System.Threading;
//Дописать приложение поиска файла используя многопоточность
namespace Home9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            HomeWork.FindFiles("D:\\projects\\example-generator\\Output", "*.txt", list);

            var findLit2 = HomeWork.FindWordInMultiThread(list, "comment:447a2fef-13db-4b73-9b04-c5eb1743ae59");
            foreach (string word in findLit2)
            {
                Console.WriteLine(word);
            }
        }

        /*static void Main(string[] args)
        {
            Console.ReadKey();
            Console.WriteLine($"Start");

            Thread thread = new Thread(Print);
            thread.Start();
            //Примеры создания потоков
            //Thread thread = new Thread(new ThreadStart(Print));
            //Thread thread = new Thread(() => Console.Writeline($"Thread"));
            //Thread thread = new Thread(() =>
            //{
            //Console.Writeline($"Thread")
            //});
            Thread.Sleep(3000);
            Console.WriteLine($"Main Thread");
        }

        public static void Print()
        {
            Thread.Sleep(3000);
            Console.WriteLine($"Second Thread");
        }*/


        //синхронизация
        /*static void Main(string[] args)
        {
            Console.ReadKey();
            Console.WriteLine($"Start");

            Thread thread = new Thread(Print);
            thread.Start();
           
            thread.Join();//приостанавливает текущий поток
            Console.WriteLine($"Main End");
        }

        public static void Print()
        {
            Thread.Sleep(5000);
            Console.WriteLine($"Second Thread");
        }*/

        /* static void Main(string[] args)
         {
             Console.ReadKey();
             Console.WriteLine($"Start");

             Thread thread1 = new Thread(()=>
             {
                 Thread thread2 = new Thread(() =>
                 {
                     Console.WriteLine($"Thread2 Start");
                     Thread.Sleep(5000);
                     Console.WriteLine($"Thread2 End");

                 });
                 Console.WriteLine($"Thread1 Start");
                 thread2.Start();
                 thread2.Join();

                 Console.WriteLine($"Thread1 End");

             });
             Console.WriteLine($"Main Start");

             thread1.Start();


             Console.WriteLine($"Main End");

         }

         public static void Print()
         {
             Thread.Sleep(5000);
             Console.WriteLine($"Second Thread");
         }*/
        /*static void Main(string[] args)
        {
            Console.ReadKey();
            Console.WriteLine($"Start");

            Thread currentThread = Thread.CurrentThread;

            Console.WriteLine(currentThread.Name);
            Console.WriteLine(currentThread.ManagedThreadId);
            Console.WriteLine(currentThread.Priority);
            Console.WriteLine(currentThread.ThreadState);

            new Thread(Thread1).Start(currentThread);

            Console.WriteLine("Main end");


        }
        public static void Thread1(object? obj)
        {
            Thread.Sleep(2000);
            Thread thread = obj as Thread;

            Console.WriteLine(thread.ThreadState);
        }*/
        /*static void Main(string[] args)
        {
            Console.ReadKey();
            Console.WriteLine($"Start");

            Thread thread1 = new Thread(Thread1);
            Thread thread2 = new Thread(Thread2);
            thread2.Start();
            thread1.Start(thread2);

        }

        private static void Thread2(object? obj)
        {
            Thread.Sleep(5000);
        }

        public static void Thread1(object? obj)
        {
            Thread.Sleep(3000);
            Thread thread = obj as Thread;

            Console.WriteLine(thread.ThreadState);
        }*/

        /*static object locker = new object();
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(Thread1);
                thread.Name = $"Thread{i}";
                Console.WriteLine($"Thread {i} start");
                thread.Start();
              

            }
        }

        public static void Thread1()
        {
            lock (locker)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} {i + 1}");
                    Thread.Sleep(100);
                }
            }
        }*/

        //Task - не зависит от потока, в котором он был запущен.
        /*static void Main(string[] args)
            {
                //Task task2 = new Task(() => { });
                //Task task2 = Task.Run(() => { });
                Task task = new Task(Thread1);
                task.Start();

                task.Wait();
                Console.WriteLine("Main end");
            }

            public static void Thread1()
            {
                Console.WriteLine("Task1 start");
                Thread.Sleep(1000);
                Console.WriteLine("Task1 end");
            }*/

        //Массив Tasks
        /*static void Main(string[] args)
        {
                
            Task[] tasks = new Task[3];

            for (int i = 0; i < tasks.Length; i++) 
            {
                tasks[i] = new Task(() =>
                {
                    Console.WriteLine($"Task {i} start");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Task {i} end");
                });
                tasks[i].Start();
            }

            Task.WaitAll(tasks); //ожидает все tasks
            Console.WriteLine("Main end");
            //tasks = null; обнуление потоков
        }

        public static void Thread1()
        {
            Console.WriteLine("Task1 start");
            Thread.Sleep(1000);
            Console.WriteLine("Task1 end");
        }*/

        //мягкое завершение

        /*static CancellationTokenSource tokenSource = new CancellationTokenSource();
        static CancellationToken token = tokenSource.Token; 
        static void Main(string[] args)
        {
                
            Task task = new Task(Task1, token);
            task.Start();

            Thread.Sleep(500);
            tokenSource.Cancel();

            Console.WriteLine("Main end");

            Console.WriteLine(task.Status); //статус
        }

        public static void Task1()
        {
            for (int i = 0; i < 10; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine($"Task abort");
                    return;
                }
                Console.WriteLine($"{i * i}");
                Thread.Sleep(200); 
               
            }
            
        }*/

        //ContinueWith
        /*static void Main(string[] args)
        {

            Task task1 = new Task(Task1);
            Task task2 = task1.ContinueWith(Task2);

            task1.Start();
            

            Task.WaitAll(task1,task2); //ожидает все tasks
            
        }

        public static void Task1()
        {
            Console.WriteLine("Task1 start");
            Thread.Sleep(2000);
            Console.WriteLine("Task1 end");
        }
        public static void Task2(Task task)
        {
            Console.WriteLine("Task2 start");
            Thread.Sleep(1000);
            Console.WriteLine("Task2 end");

            Console.WriteLine($"\n\n{Task.CurrentId} {task.Id}");
        */



        /*static void Main(string[] args)
        {

            Task<int> task1 = new Task<int>(() => Sum(4, 5));
            Task task2 = task1.ContinueWith(task => Print(task.Result));

            task1.Start();

            task2.Wait();



            int Sum(int a, int b) => a + b;
            void Print(int sum) => Console.WriteLine($"Sum: {sum}");
        }

        */
    }

}




