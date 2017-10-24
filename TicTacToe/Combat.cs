using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// <remark>Class for Computer combat</remark>
    /// </summary>
    class Combat : Player
    {
        public string Name;
        public int win;
        public int draw;
        public Combat(string s)
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

        Random rand = new Random();

        /// <summary>
        /// <remark>Method for choosing next turn by Computer Combat</remark>
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="player"></param>
        /// <param name="passage"></param>
        /// <returns></returns>
        public int Selection(char[] arr, int player, ref bool passage)
        {
            //int marker = 0;
            int muve = 0;
            do
            {
                //chek opponents markers
                if (player <= 2)
                {
                    if (arr[1] == 'X' || arr[2] == 'X'|| arr[3] == 'X' || arr[4]=='X' || arr[6] == 'X' || arr[7] == 'X' || arr[8] == 'X' || arr[9] == 'X')
                    {
                        muve = 5;
                        passage = true;
                        break;
                    }
                    if (arr[5] == 'X')
                    {
                        int[] a = { 1, 2, 3, 4, 6, 7, 8, 9 };
                        muve = a[new Random().Next(0, a.Length)];
                        passage = true;
                        break;
                    }
                    if (arr[1] == '1' && arr[2] == '2' && arr[3] == '3' && arr[4] == '4' && arr[5] == '5' && arr[6] == '6' && arr[7] == '7' && arr[8] == '8' && arr[9] == '9')
                    {
                        int[] a = { 1, 3, 7, 9 };
                        muve = a[new Random().Next(0, a.Length)];
                        passage = true;
                        break;
                    }
                }

                if (player >= 3)
                {
                    
                    if (arr[1] == 'X' && arr[7] == 'X' && arr[4] == '4')
                    {
                        muve = 4;
                        passage = true;
                        break;
                    }
                    if (arr[1] == 'X' && arr[3] == 'X' && arr[2] == '2')
                    {
                        muve = 2;
                        passage = true;
                        break;
                    }
                    if (arr[1] == 'X' && arr[9] == 'X' && arr[5] == '5')
                    {
                        muve = 5;
                        passage = true;
                        break;
                    }
                    if (arr[1] == 'X' && arr[4] == 'X' && arr[7] == '7')
                    {
                        muve = 7;
                        passage = true;
                        break;
                    }
                    if (arr[1] == 'X' && arr[2] == 'X' && arr[3] == '3')
                    {
                        muve = 3;
                        passage = true;
                        break;
                    }
                    if (arr[1] == 'X' && arr[5] == 'X' && arr[9] == '9')
                    {
                        muve = 9;
                        passage = true;
                        break;
                    }
                    if (arr[4] == 'X' && arr[7] == 'X' && arr[1] == '1')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }
                    if (arr[2] == 'X' && arr[3] == 'X' && arr[1] == '1')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }
                    if (arr[5] == 'X' && arr[9] == 'X' && arr[1] == '1')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }
                    if (arr[2] == 'X' && arr[5] == 'X' && arr[8] == '8')
                    {
                        muve = 8;
                        passage = true;
                        break;
                    }
                    if (arr[2] == 'X' && arr[8] == 'X' && arr[5] == '5')
                    {
                        muve = 5;
                        passage = true;
                        break;
                    }
                    if (arr[5] == 'X' && arr[8] == 'X' && arr[2] == '2')
                    {
                        muve = 2;
                        passage = true;
                        break;
                    }
                    if (arr[3] == 'X' && arr[5] == 'X' && arr[7] == '7')
                    {
                        muve = 7;
                        passage = true;
                        break;
                    }
                    if (arr[3] == 'X' && arr[7] == 'X' && arr[5] == '5')
                    {
                        muve = 5;
                        passage = true;
                        break;
                    }
                    if (arr[5] == 'X' && arr[7] == 'X' && arr[3] == '3')
                    {
                        muve = 3;
                        passage = true;
                        break;
                    }
                    if (arr[3] == 'X' && arr[6] == 'X' && arr[9] == '9')
                    {
                        muve = 9;
                        passage = true;
                        break;
                    }
                    if (arr[3] == 'X' && arr[9] == 'X' && arr[6] == '6')
                    {
                        muve = 6;
                        passage = true;
                        break;
                    }
                    if (arr[6] == 'X' && arr[9] == 'X' && arr[3] == '3')
                    {
                        muve = 3;
                        passage = true;
                        break;
                    }
                    if (arr[4] == 'X' && arr[5] == 'X' && arr[6] == '6')
                    {
                        muve = 6;
                        passage = true;
                        break;
                    }
                    if (arr[4] == 'X' && arr[6] == 'X' && arr[5] == '5')
                    {
                        muve = 5;
                        passage = true;
                        break;
                    }
                    if (arr[5] == 'X' && arr[6] == 'X' && arr[4] == '4')
                    {
                        muve = 4;
                        passage = true;
                        break;
                    }
                    if (arr[7] == 'X' && arr[8] == 'X' && arr[9] == '9')
                    {
                        muve = 9;
                        passage = true;
                        break;
                    }
                    if (arr[7] == 'X' && arr[9] == 'X' && arr[8] == '8')
                    {
                        muve = 8;
                        passage = true;
                        break;
                    }
                    if (arr[8] == 'X' && arr[9] == 'X' && arr[7] == '7')
                    {
                        muve = 7;
                        passage = true;
                        break;
                    }

                    //chek own markers
                    // first line
                    if (arr[1] == 'O' && arr[2] == '2' && arr[3] == '3')
                    {
                        muve = 3;
                        passage = true;
                        break;
                    }
                    if (arr[1] == 'O' && arr[2] == 'O' && arr[3] == '3')
                    {
                        muve = 3;
                        passage = true;
                        break;
                    }
                    if (arr[1] == 'O' && arr[2] == '2' && arr[3] == 'O')
                    {
                        muve = 2;
                        passage = true;
                        break;
                    }
                    if (arr[1] == '1' && arr[2] == 'O' && arr[3] == 'O')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }
                    if (arr[1] == '1' && arr[2] == '2' && arr[3] == 'O')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }
                    if (arr[1] == '1' && arr[2] == 'O' && arr[3] == '3')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }
                    //second line
                    if (arr[4] == 'O' && arr[5] == '5' && arr[6] == '6')
                    {
                        muve = 6;
                        passage = true;
                        break;
                    }
                    if (arr[4] == 'O' && arr[5] == 'O' && arr[6] == '6')
                    {
                        muve = 6;
                        passage = true;
                        break;
                    }
                    if (arr[4] == 'O' && arr[5] == '5' && arr[6] == 'O')
                    {
                        muve = 5;
                        passage = true;
                        break;
                    }
                    if (arr[4] == '4' && arr[4] == 'O' && arr[6] == 'O')
                    {
                        muve = 4;
                        passage = true;
                        break;
                    }
                    if (arr[4] == '4' && arr[5] == '5' && arr[6] == 'O')
                    {
                        muve = 4;
                        passage = true;
                        break;
                    }
                    if (arr[4] == '4' && arr[5] == 'O' && arr[6] == '6')
                    {
                        muve = 4;
                        passage = true;
                        break;
                    }
                    //third line
                    if (arr[7] == 'O' && arr[8] == '8' && arr[9] == '9')
                    {
                        muve = 9;
                        passage = true;
                        break;
                    }
                    if (arr[7] == 'O' && arr[8] == 'O' && arr[9] == '9')
                    {
                        muve = 9;
                        passage = true;
                        break;
                    }
                    if (arr[7] == 'O' && arr[8] == '8' && arr[9] == 'O')
                    {
                        muve = 8;
                        passage = true;
                        break;
                    }
                    if (arr[7] == '7' && arr[8] == 'O' && arr[9] == 'O')
                    {
                        muve = 7;
                        passage = true;
                        break;
                    }
                    if (arr[7] == '7' && arr[8] == '8' && arr[9] == 'O')
                    {
                        muve = 7;
                        passage = true;
                        break;
                    }
                    if (arr[7] == '7' && arr[8] == 'O' && arr[9] == '9')
                    {
                        muve = 4;
                        passage = true;
                        break;
                    }
                    // first column
                    if (arr[1] == 'O' && arr[4] == '4' && arr[7] == '7')
                    {
                        muve = 7;
                        passage = true;
                        break;
                    }
                    if (arr[1] == 'O' && arr[4] == 'O' && arr[7] == '7')
                    {
                        muve = 7;
                        passage = true;
                        break;
                    }
                    if (arr[1] == 'O' && arr[4] == '4' && arr[7] == 'O')
                    {
                        muve = 4;
                        passage = true;
                        break;
                    }
                    if (arr[1] == '1' && arr[4] == 'O' && arr[7] == 'O')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }
                    if (arr[1] == '1' && arr[4] == '4' && arr[7] == 'O')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }
                    if (arr[1] == '1' && arr[4] == 'O' && arr[7] == '7')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }

                    // second column
                    if (arr[2] == 'O' && arr[5] == '5' && arr[8] == '8')
                    {
                        muve = 8;
                        passage = true;
                        break;
                    }
                    if (arr[2] == 'O' && arr[5] == 'O' && arr[8] == '8')
                    {
                        muve = 8;
                        passage = true;
                        break;
                    }
                    if (arr[2] == 'O' && arr[5] == '5' && arr[8] == 'O')
                    {
                        muve = 5;
                        passage = true;
                        break;
                    }
                    if (arr[2] == '2' && arr[5] == 'O' && arr[8] == 'O')
                    {
                        muve = 2;
                        passage = true;
                        break;
                    }
                    if (arr[2] == '2' && arr[5] == '5' && arr[8] == 'O')
                    {
                        muve = 2;
                        passage = true;
                        break;
                    }
                    if (arr[2] == '2' && arr[5] == 'O' && arr[8] == '8')
                    {
                        muve = 2;
                        passage = true;
                        break;
                    }

                    // third column
                    if (arr[3] == 'O' && arr[6] == '6' && arr[9] == '9')
                    {
                        muve = 9;
                        passage = true;
                        break;
                    }
                    if (arr[3] == 'O' && arr[6] == 'O' && arr[9] == '9')
                    {
                        muve = 9;
                        passage = true;
                        break;
                    }
                    if (arr[3] == 'O' && arr[6] == '6' && arr[9] == 'O')
                    {
                        muve = 6;
                        passage = true;
                        break;
                    }
                    if (arr[3] == '3' && arr[6] == 'O' && arr[9] == 'O')
                    {
                        muve = 3;
                        passage = true;
                        break;
                    }
                    if (arr[3] == '3' && arr[6] == '6' && arr[9] == 'O')
                    {
                        muve = 3;
                        passage = true;
                        break;
                    }
                    if (arr[3] == '3' && arr[6] == 'O' && arr[9] == '9')
                    {
                        muve = 3;
                        passage = true;
                        break;
                    }

                    //first cross line
                    if (arr[1] == 'O' && arr[5] == '5' && arr[9] == '9')
                    {
                        muve = 9;
                        passage = true;
                        break;
                    }
                    if (arr[1] == 'O' && arr[5] == 'O' && arr[9] == '9')
                    {
                        muve = 9;
                        passage = true;
                        break;
                    }
                    if (arr[1] == 'O' && arr[5] == '5' && arr[9] == 'O')
                    {
                        muve = 5;
                        passage = true;
                        break;
                    }
                    if (arr[1] == '1' && arr[5] == 'O' && arr[9] == 'O')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }
                    if (arr[1] == '1' && arr[5] == '5' && arr[9] == 'O')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }
                    if (arr[1] == '1' && arr[5] == 'O' && arr[9] == '9')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }

                    //second cross line
                    if (arr[3] == 'O' && arr[5] == '5' && arr[7] == '7')
                    {
                        muve = 7;
                        passage = true;
                        break;
                    }
                    if (arr[3] == 'O' && arr[5] == 'O' && arr[7] == '7')
                    {
                        muve = 7;
                        passage = true;
                        break;
                    }
                    if (arr[3] == 'O' && arr[5] == '5' && arr[7] == 'O')
                    {
                        muve = 5;
                        passage = true;
                        break;
                    }
                    if (arr[3] == '3' && arr[5] == 'O' && arr[7] == 'O')
                    {
                        muve = 3;
                        passage = true;
                        break;
                    }
                    if (arr[3] == '3' && arr[5] == '5' && arr[7] == 'O')
                    {
                        muve = 3;
                        passage = true;
                        break;
                    }
                    if (arr[3] == '3' && arr[5] == 'O' && arr[7] == '7')
                    {
                        muve = 1;
                        passage = true;
                        break;
                    }
                }

            } while (passage == false);
            Console.Beep();
            return muve;
        }
        
    }
}
