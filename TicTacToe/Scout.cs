using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// <remark>Class for Computer scout</remark>
    /// </summary>
    class Scout : Player
    {
        public string Name;
        public int win;
        public int draw;
        public Scout(string s)
        {
            this.Name = s;
            this.win = 0;
            this.draw = 0;
        }
        Random rand = new Random();

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
        /// <remark>Method for choosing next turn by Computer Scout</remark>
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="player"></param>
        /// <param name="passage"></param>
        /// <returns></returns>
        public int Selection(char[] arr, int player, ref bool passage)
        {
            //int marker = 0;
            int muve = 0;
            int tmp = 0;
            do
            {
                int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                tmp = a[new Random().Next(0, a.Length)];
                if (arr[tmp] != 'X' && arr[tmp] != 'O')
                {
                    muve = tmp;
                    passage = true;
                    break;
                }
                

            } while (passage == false);
            Console.Beep();
            return muve;
        }
        
    }
}
