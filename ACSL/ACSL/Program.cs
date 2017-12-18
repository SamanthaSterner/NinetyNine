using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ACSL
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("data.txt");
            string[] start = lines[0].Replace(" ", "").Split(new char[] { ',' });
            List<int> p1c = new List<int>();
            List<int> p2c = new List<int>();
            int total = 0;
            for (int a = 0; a < start.Length; a++)
            {
                if (start[a].Contains("T"))
                {
                    start[a] = "10";
                }
                if (start[a].Contains("J"))
                {
                    start[a] = "11";
                }
                if (start[a].Contains("Q"))
                {
                    start[a] = "12";
                }
                if (start[a].Contains("K"))
                {
                    start[a] = "13";
                }
                if (start[a].Contains("A"))
                {
                    start[a] = "14";
                }
            }
            for (int b = 0; b < 5; b++)
            {
                p1c.Add (Convert.ToInt32(start[b]));
            }
            for (int c = 5; c < start.Length; c++)
            {
                p2c.Add(Convert.ToInt32(start[c]));
            }







            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Replace(" ", "").Split(new char[] { ',' });

                List<int> p1 = new List<int>(p1c);
                List<int> p2 = new List<int>(p2c);
                total = Convert.ToInt32(parts[0].Trim());

                for (int k = 1; k < parts.Length; k++)
                {
                    p1.Sort();
                    p2.Sort();

                    int play1 = p1[2];
                    int play2 = p2[2];
                    if (play1 == 9)
                    {
                        total = total;
                    }
                    else if (play1 == 10)
                    {
                        total = total - 10;
                    }
                    else if (play1 == 7)
                    {
                        if (total >= 92)
                        {
                            total = total + 1;
                        }
                        else
                        {
                            total = total + 7;
                        }
                    }
                    else
                    {
                        total = total + play1;
                    }
                    if (total > 99)
                    {
                        Console.Write(total + ", Player #1");
                        break;

                    }

                    p1[2] = "0123456789TJQKA".IndexOf(parts[k]);
                    p1.Sort();
                    k++;

                    if (play2 == 9)
                    {
                        total = total;
                    }
                    if (play2 == 10)
                    {
                        total = total - 10;
                    }
                    if (play2 == 7)
                    {
                        if (total >= 92)
                        {
                            total = total + 1;
                        }
                        else
                        {
                            total = total + 7;
                        }
                    }
                    else
                    {
                        total = total + play2;
                    }
                    if (total > 99)
                    {
                        Console.Write(total + ", Player #2");
                        break;
                    }
                    p1[2] = "0123456789TJQKA".IndexOf(parts[k]);
                    p1.Sort();
                    k++;

                }
            }
        }
    }
}
