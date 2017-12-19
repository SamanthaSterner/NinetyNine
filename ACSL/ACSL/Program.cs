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



            int starttot = 0;
            int p1end = 0;
            int p2end = 0;
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

                    starttot = total;
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
                        if (total + 7 > 99)
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
                    p1end = total;
                    if(starttot < 33 && p1end > 34)
                    {
                        total = total + 5;
                    }
                    if(starttot < 55 && p1end > 56)
                    {
                        total = total + 5;
                    }
                    if(starttot < 77 && p1end > 78)
                    {
                        total = total + 5;
                    }
                    if (starttot > 34 && p1end < 33)
                    {
                        total = total + 5;
                    }
                    if( starttot > 56 && p1end <55)
                    {
                        total = total + 5;
                    }
                    if (starttot > 78 && p1end < 77)
                    {
                        total = total + 5; 
                    }
                    starttot = total; 
                    if (total > 99)
                    {
                        Console.WriteLine(total + " , player #2 ");
                        break;
                    }

                    p1[2] = "0123456789TJQKA".IndexOf(parts[k]);
                    p1.Sort();
                    k++;
                    play1 = p1[2];
                    if (play2 == 9)
                    {
                        total = total;
                    }
                    else if (play2 == 10)
                    {
                        total = total - 10;
                    }
                    if (play2 == 7)
                    {
                        if (total + 7 > 99)
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

                    p2end = total;
                    if (starttot < 34 && p2end > 33)
                    {
                        total = total + 5;
                    }
                    if (starttot < 56 && p2end > 55)
                    {
                        total = total + 5;
                    }
                    if (starttot < 78 && p2end > 77)
                    {
                        total = total + 5;
                    }
                    if (starttot > 33 && p2end < 34)
                    {
                        total = total + 5;
                    }
                    if (starttot > 55 && p2end < 56)
                    {
                        total = total + 5;
                    }
                    if (starttot > 77 && p2end < 78)
                    {
                        total = total + 5;
                    }
                    starttot = total;

                    if (total > 99)
                    {
                        Console.WriteLine(total + ", Player #1 ");
                        break;
        
                    }


                    p2[2] = "0123456789TJQKA".IndexOf(parts[k]);
                    p2.Sort();
                    k++;
                    play2 = p2[2];
                }
            }
        }
    }
}
