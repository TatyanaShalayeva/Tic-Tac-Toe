using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TicTacToe
{
    /// <summary>
    /// <remark>Class for user</remark>
    /// </summary>
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
        /// <summary>
        /// <remark>Method to get name of user</remark>
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return this.Name;
        }
        /// <summary>
        /// <remark>Method to sum win's points</remark>
        /// </summary>
        /// <returns></returns>
        public int GetWin()
        {
            return this.win += 1;
        }
        /// <summary>
        /// <remark>Method to sum draw's points</remark>
        /// </summary>
        /// <returns></returns>
        public int GetDraw()
        {
            return this.draw += 1;
        }

        /// <summary>
        /// <remark>Method for choosing next turn by user</remark>
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="player"></param>
        /// <param name="passage"></param>
        /// <returns></returns>
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
        
    }
}
