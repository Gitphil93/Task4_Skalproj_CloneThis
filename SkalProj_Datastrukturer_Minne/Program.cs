using System;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack (with ReverseText)"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");

                char input = ' ';
                try
                {
                    input = Console.ReadLine()![0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        static void ExamineList()
        {
            List<string> list = new List<string>();

            while (true)
            {
                Console.WriteLine("\nSkriv +namn för att lägga till, -namn för att ta bort, eller 0 för att gå tillbaka:");
                string input = Console.ReadLine();

                if (input == "0") break;
                if (string.IsNullOrWhiteSpace(input)) continue;

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        list.Add(value);
                        Console.WriteLine($"{value} lades till.");
                        break;
                    case '-':
                        if (list.Remove(value))
                            Console.WriteLine($"{value} togs bort.");
                        else
                            Console.WriteLine($"{value} fanns inte i listan.");
                        break;
                    default:
                        Console.WriteLine("Använd + eller - följt av ett namn.");
                        break;
                }

                Console.WriteLine($"Antal element (Count): {list.Count}, Kapacitet (Capacity): {list.Capacity}");

                /*
                Fråga 2: När list.Count === list.Capacity.
                Fråga 3: Den fördubblas.
                Fråga 4: För att undvika skapande av ny array vid varje tillägg av element.
                Fråga 5: Nej, capacity minskar inte automatiskt vid borttagning utan håller kvar storleken ifall element tillkommer.
                Fråga 6: Använd array när du vet hur många element du ska jobba med.
                */
            }
        }

        static void ExamineQueue()
        {
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("\nSkriv +namn för att ställa någon i kön, - för att expediera, eller 0 för att gå tillbaka:");
                string input = Console.ReadLine();

                if (input == "0") break;
                if (string.IsNullOrWhiteSpace(input)) continue;

                char nav = input[0];
                string value = input.Length > 1 ? input.Substring(1) : "";

                switch (nav)
                {
                    case '+':
                        queue.Enqueue(value);
                        Console.WriteLine($"{value} ställde sig i kön.");
                        break;
                    case '-':
                        if (queue.Count > 0)
                        {
                            string removed = queue.Dequeue();
                            Console.WriteLine($"{removed} fick hjälp och lämnade kön.");
                        }
                        else
                        {
                            Console.WriteLine("Kön är tom.");
                        }
                        break;
                    default:
                        Console.WriteLine("Använd +namn, - eller 0.");
                        break;
                }

                Console.WriteLine("Kön nu:");
                foreach (var person in queue)
                {
                    Console.WriteLine($" - {person}");
                }
            }
        }

        static void ExamineStack()
        {
            Stack<string> stack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("\nSkriv +namn för att lägga någon överst i stacken, - för att ta bort översta,");
                Console.WriteLine("reverse för att vända en text, eller 0 för att gå tillbaka:");
                string input = Console.ReadLine();

                if (input == "0") break;
                if (string.IsNullOrWhiteSpace(input)) continue;
                if (input == "reverse")
                {
                    ReverseText();
                    continue;
                }

                char nav = input[0];
                string value = input.Length > 1 ? input.Substring(1) : "";

                switch (nav)
                {
                    case '+':
                        stack.Push(value);
                        Console.WriteLine($"{value} lades till överst i stacken.");
                        break;
                    case '-':
                        if (stack.Count > 0)
                        {
                            string removed = stack.Pop();
                            Console.WriteLine($"{removed} togs bort från toppen av stacken.");
                        }
                        else
                        {
                            Console.WriteLine("Stacken är tom.");
                        }
                        break;
                    default:
                        Console.WriteLine("Använd +namn, - eller reverse.");
                        break;
                }

                Console.WriteLine("Stackens innehåll (överst först):");
                foreach (var person in stack)
                {
                    Console.WriteLine($" - {person}");
                }

                
                //En kö ska funka enligt FIFO, en stack funkar enligt FILO
               
                
            }
        }

        static void ReverseText()
        {
            Console.Write("\nSkriv en text du vill reversa: ");
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                stack.Push(c);
            }

            Console.Write("Reversad text: ");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }

        static void CheckParanthesis()
        {
            Console.Write("\nSkriv en sträng att kontrollera: ");
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> matching = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            foreach (char c in input)
            {
                if (matching.ContainsValue(c))
                {
                    stack.Push(c);
                }
                else if (matching.ContainsKey(c))
                {
                    if (stack.Count == 0 || stack.Pop() != matching[c])
                    {
                        Console.WriteLine("Ogiltig parentesstruktur!");
                        return;
                    }
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("Strängen är giltig.");
            }
            else
            {
                Console.WriteLine("Strängen är inte giltig. saknar avslutande parenteser!");
            }
        }
    }
}
