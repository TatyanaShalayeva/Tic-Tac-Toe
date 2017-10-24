using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TicTacToe
{
    class Person : Player
    {
        public string Name;
        public int win;
        public int draw;
        public Person(string s)
        {
            this.Name = s;
            this.win = 0;
            this.draw = 0;
        }

        public string GetName()
        {
            return this.Name;
        }

        public int GetWin()
        {
            return this.win += 1;
        }

        public int GetDraw()
        {
            return this.draw += 1;
        }

        public int Selection(char[] arr, int player, ref bool passage)
        {
            if (passage == false)
                passage = true;
            int muve = 0;
            do
            {
                try
                {
                    muve = int.Parse(Console.ReadLine());               //Taking users choice 
                

                    if (arr[muve] != 'X' && arr[muve] != 'O')
                    {
                        passage = false;
                    }
                   else //If there is any possition where user want to run and that is already marked then show message and load board again
                   {
                         Console.WriteLine("Sorry the row {0} is already marked with {1}", muve, arr[muve]);
                         Console.WriteLine("Try again...");
                        //Thread.Sleep(2000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Enter number from 0 to 9");
                }
            } while (passage == true);
            return muve;
        }
        public void PrintClass()
        {
            Console.WriteLine("Name: {0}\t win: {1}\t draw: {2}", this.Name, this.win, this.draw);
        }
    }
}
