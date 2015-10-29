using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWorkWithList_Array
{
    public class MyArray
    {
        private string[] A;

        public void InitArray(string[] A)
        {
            this.A = A;
        }

        public string GetSecondByLength()
        {            
            int n = 1;
            int m = 1;
            int arrayLength = A.Length;

            for (int i = 0; i < arrayLength; i++)
            {
                if (A[n].Length < A[i].Length)
                    n = i;
            }

            for (int j = 0; j < arrayLength; j++)
            {
                if (j != n)
                {
                    if (A[m].Length < A[j].Length)
                        m = j;
                }
            }
            return A[m];
        }        

        public  void ShowArray()
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine("A[{0}] = '{1}'", i, A[i]);
            }
        }

        public void ShowArrayWithLength()
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine("A[{0}] = '{1}' - {2}", i, A[i], A[i].Length);
            }
        }
        
        public void ShowArrayWithCountOfVowels()
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine("A[{0}] = '{1}' - {2}", i, A[i], GetCountOfVowels(A[i]));
            }
        }

        public void ShowArrayWithCountOfConsonants()
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine("A[{0}] = '{1}' - {2}", i, A[i], GetCountOfConsonants(A[i]));
            }
        }

        #region Sort list or array by string length
        public void SortByLengthDown() //по убыванию длинны
        {
            Console.WriteLine("Sort by length down:");
            string tmp = "";
            bool flag = false;
            while (!flag)
            {
                flag = true;
                for (int i = 0; i < (A.Length - 1); i++)
                {
                    if (A[i + 1].Length > A[i].Length)
                    {
                        tmp = A[i];
                        A[i] = A[i + 1];
                        A[i + 1] = tmp;
                        flag = false;
                    }
                }
            }
        }

        public void SortByLengthUp() // по возрастанию длинны
        {
            Console.WriteLine("Sort by length up:");
            string tmp = "";
            bool flag = false;
            while (!flag)
            {
                flag = true;
                for (int i = 0; i < (A.Length - 1); i++)
                {
                    if (A[i + 1].Length < A[i].Length)
                    {
                        tmp = A[i];
                        A[i] = A[i + 1];
                        A[i + 1] = tmp;
                        flag = false;
                    }
                }
            }
        }

        #endregion

        public void SortByCountOfVowels() //Sort list or array by count of vowels in string
        {
            Console.WriteLine("Sort by count of vowels:");
            string tmp = "";
            bool flag = false;
            while (!flag)
            {
                flag = true;
                for (int i = 0; i < (A.Length - 1); i++)
                {
                    if (GetCountOfVowels(A[i + 1]) < GetCountOfVowels(A[i]))
                    {
                        tmp = A[i];
                        A[i] = A[i + 1];
                        A[i + 1] = tmp;
                        flag = false;
                    }
                }
            }
        }

        public void SortByCountOfConsonants() //Sort list or array by count of consonants in string
        {
            Console.WriteLine("Sort by count of Consonants:");
            string tmp = "";
            bool flag = false;
            while (!flag)
            {
                flag = true;
                for (int i = 0; i < (A.Length - 1); i++)
                {
                    if (GetCountOfConsonants(A[i + 1]) < GetCountOfConsonants(A[i]))
                    {
                        tmp = A[i];
                        A[i] = A[i + 1];
                        A[i + 1] = tmp;
                        flag = false;
                    }
                }
            }
        }

        private int GetCountOfVowels(string s)
        {
            string vowels = "AaEeYyUuIiOo";
            int count = 0;
            char[] chararray = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
                {
                    if (vowels.Contains(chararray[i]))
                        count++;
                }            
            return count;
        }

        private int GetCountOfConsonants(string s)
        {
            string consonants = "QWRTPSDFGHJKLZXCVBNMqwrtpsdfghjklzxcvbnm";
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (consonants.Contains(s[i]))
                    count++;
            }
            return count;
        }

    }

    public class MyList
    {
        private List<string> L;

        public void InitList(List<string> L)
        {
            this.L = L;
        }

        private string ReplaceFirstAndLast(string s)
        {
            char tmp;
            int length = s.Length;
            char[] chararray = s.ToCharArray();

            tmp = chararray[0];
            chararray[0] = chararray[length - 1];
            chararray[length - 1] = tmp;
            s = new string(chararray);
            return s;
        }

        public void MakeMagic()
        {
            int count = L.Count();
            for(int i = 1; i < count; i++)
            {
                L[i] = ReplaceFirstAndLast(L[i]);
                if((i+2) > count)
                { break; }
                else i++;
            }
        }

        public void Clear()
        {
            L.Clear();

        }

        public void ShowList()
        {
            Console.WriteLine("Elements of list:");
            foreach (string s in L)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("");
        }

        public void RevertRows()
        {
            List<string> L1 = new List<string>();
            foreach (string s in L)
            {
                //RevertRow(s);
                L1.Add(RevertRow(s));                
            }
            L.Clear();
            L = L1;
        }

        private string RevertRow(string s)
        {            
            int length = s.Length;
            char[] chararray = s.ToCharArray();
            char[] chreverted = s.ToCharArray();
            int j = length-1;

            for(int i = 0; i < length; i++)
            {
                chreverted[j] = chararray[i];
                j--;
            }
            s = new string(chreverted);
            return s;
        }
    }
     
    class Program
    {
        static void Main(string[] args)
        {
            MyList myL = new MyList();

            MyArray myA = new MyArray();
            myA.InitArray(GetArray());

            Console.WriteLine("This Console app shows work with list and array.");
            Console.WriteLine("Please make your choice:");

            ShowMenu();

            string userChoice = "";
            do
            {
                userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1": //Find the second by length string in a list or array
                        {
                            
                            myA.ShowArrayWithLength();
                            string secondByLength = myA.GetSecondByLength();
                            Console.WriteLine("Second by length row in this array: {0} (length = {1})", secondByLength, secondByLength.Length);
                            //Console.ReadLine();
                            continue;
                        }
                    case "2": //Sort list or array by string length
                        {
                            myA.ShowArrayWithLength();
                            Console.WriteLine("");

                            myA.SortByLengthUp();
                            myA.ShowArrayWithLength();
                            Console.WriteLine("");

                            myA.SortByLengthDown();
                            myA.ShowArrayWithLength();
                            //Console.ReadLine();
                            continue;
                        }
                    case "3":  //Sort list or array by count of vowels in string
                        {
                            myA.ShowArrayWithCountOfVowels();
                            Console.WriteLine("");

                            myA.SortByCountOfVowels();
                            myA.ShowArrayWithCountOfVowels();
                            //Console.ReadLine();
                            continue;
                        }

                    case "4":  //Sort list or array by count of consonants in string
                        {
                            myA.ShowArrayWithCountOfConsonants();
                            Console.WriteLine("");

                            myA.SortByCountOfConsonants();
                            myA.ShowArrayWithCountOfConsonants();
                            //Console.ReadLine();
                            continue;
                        }
                    case "5":  //Change by places first and last letters in each second string of list or array
                        {                            
                            myL.InitList(GetList());

                            myL.ShowList();
                            myL.MakeMagic();
                            myL.ShowList();
                            myL.Clear();
                            continue;
                        }

                    case "6":  //Revert strings of list or array
                        {                            
                            myL.InitList(GetList());

                            myL.ShowList();
                            myL.RevertRows();
                            myL.ShowList();
                            myL.Clear();
                            continue;
                        }
                }
            }
            while (userChoice != "7");

        }


        public static string[] GetArray()
        {
            string[] days =
                {
                "Monday",  //6  3
                "Tuesday",  //7  4
                "Wednesday",  //9  4
                "Thursday",  //8  3
                "Friday", //6 3
                "Saturday",  //8  4
                "Sunday" //6  3
            };
            return days;
        }


        public static List<string> GetList()
        {
            List<string> L = new List<string>();
            L.Add("Red");
            L.Add("Orange");
            L.Add("Blue");
            L.Add("Navy");
            L.Add("Green");
            L.Add("Yellow");
            L.Add("Violet");
            return L;
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Please make your choice:");
            Console.WriteLine("1 - Find the second by length string in a list or array");
            Console.WriteLine("2 - Sort list or array by string length ");
            Console.WriteLine("3 - Sort list or array by count of vowels in string ");
            Console.WriteLine("4 - Sort list or array by count of consonants in string ");
            Console.WriteLine("5 - Change by places first and last letters in each second string of list or array");
            Console.WriteLine("6 - Revert strings of list or array ");
            Console.WriteLine("7 - Exit");
            Console.WriteLine("");
        }
    }
}
