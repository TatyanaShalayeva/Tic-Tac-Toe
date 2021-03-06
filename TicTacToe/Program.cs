﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.IO;

namespace TicTacToe
{
    /// <summary>
    /// <c> Класс Program содержит массив с номерами полей для игры, глобальные переменные, методы для игры и проверки победителя</c>  
    /// </summary>
    class Program
    {
        /// <summary>
        /// <remark> making array and by default I am providing 0-9 where no use of zero</remark>
        /// </summary>
        
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        /// <summary>
        /// <remark> Counter, which control who next turn</remark>
        /// </summary>
        static int player = 1;
        /// <summary>
        /// <remark>By default Person1 starts to play</remark>
        /// </summary>
        static bool passage = true;
        /// <summary>
        /// <remark>This holds the choice at which position user want to mark</remark>
        /// </summary>
        static int choice;
        /// <summary>
        /// <remark>Variable which hold to select whether to continue the game or exit</remark>
        /// </summary>
        static int circle = 1;
        /// <summary>
        /// <remark>This holds the choice at with whom user want to play</remark>
        /// </summary>
        static int choiceOpponent = 0;
        /// <summary>
        /// <remark>The flag veriable checks who has won if it's value is 1 then some one has won the match if -1 then Match has Draw if 0 then match is still running</remark>
        /// </summary>
        static int flag = 0;
        /// <summary>
        /// <c> Start of the game</c>  
        /// </summary>
        static void Main(string[] args)
        {
            FileStream fs = null;
            Console.Title = "TicTacToe";              // Name of this game in top of console
            Console.Clear();                          // whenever loop will be again start then screen will be clear

            Console.WriteLine("Hello! This is TicTacToe game!");
            Console.WriteLine();
            Console.WriteLine("At first please enter your name:");
            string playerName = Console.ReadLine();  // Name of user which want to play
            string opponentName = null;             // Name of user's opponent before user makes a choice by default null

            
            do
            {
                Person person1 = new Person(playerName);          // create Player
                player = 1;                                        //if it is not first game, the player by default = 1
                
                Person person2 = null;                      //Creation of objects of three variants of players
                Combat combat = null;
                Scout scout = null;

                do
                {
                    Console.Clear();
                    if(File.Exists("Statistic.txt") == false)
                        Console.WriteLine("Choose opponent:\n1 - Another person\n2 - Computer - combat\n3 - Computer - scout");
                    else
                        Console.WriteLine("Choose opponent:\n1 - Another user\n2 - Computer - combat\n3 - Computer scout\n4 - Print results");
                    try
                    {
                        choiceOpponent = int.Parse(Console.ReadLine());

                        if (choiceOpponent == 1)
                        {
                            Console.WriteLine("Enter person name:");
                            opponentName = Console.ReadLine();

                            person2 = new Person(opponentName);  // if user wants to play with another person create another Player
                        }
                        else if (choiceOpponent == 2)
                        {
                            opponentName = "Combat";
                            combat = new Combat(opponentName);  // if user wants to play with Computer combat create Combat
                        }
                        else if (choiceOpponent == 3)
                        {
                            opponentName = "Scout";
                            scout = new Scout(opponentName);    // if user wants to play with Computer scout create Scout
                        }
                        else if (choiceOpponent == 4)
                            Console.WriteLine(File.ReadAllText("Statistic.txt")); // if user want to see statistic of his games
                        else
                        {
                            Console.WriteLine("You entered an invalid value, try again"); // checking if user entered wrong number
                            choiceOpponent = 0;
                        }
                    }
                    catch (Exception)                                   // checking if user entered char instead number
                    {
                        if (File.Exists("Statistic.txt") == true)
                            Console.WriteLine("Enter number from 1 or 4");
                        else
                            Console.WriteLine("Enter number from 1 to 3");
                    }
                } while (choiceOpponent == 0);  // check of player choice

                try
                {
                    if (File.Exists("Statistic.txt") == true)
                        fs = new FileStream("Statistic.txt", FileMode.Append, FileAccess.Write); // if file with statistic is exists open file to add data
                    else
                        fs = new FileStream("Statistic.txt", FileMode.Create, FileAccess.ReadWrite);// if file with statistic isn't exists create file to add data
                    byte[] buf = new byte[20];
                    if (choiceOpponent == 1)
                    {
                        Game(person1, person2);                 //Game between two users
                        ResultWin(person1, person2);            //Checking result
                        if (flag == 1)                          // if flag value is 1 then some one has win or means who played marked last time which has win
                        {
                            if (((player % 2) + 1) == 1)
                            {
                                buf = Encoding.Unicode.GetBytes(person1.GetName());
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes(" 1:0 ");
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes(person2.GetName());
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes("\n");
                                fs.Write(buf, 0, buf.Length);
                            }
                            else
                            {
                                buf = Encoding.Unicode.GetBytes(person1.GetName());
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes(" 0:1 ");
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes(person2.GetName());
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes("\n");
                                fs.Write(buf, 0, buf.Length);
                            }

                        }
                        else// if flag value is -1 the match will be draw and no one is winner
                        {
                            buf = Encoding.Unicode.GetBytes(person1.GetName());
                            fs.Write(buf, 0, buf.Length);
                            buf = Encoding.Unicode.GetBytes(" 0:0 ");
                            fs.Write(buf, 0, buf.Length);
                            buf = Encoding.Unicode.GetBytes(person2.GetName());
                            fs.Write(buf, 0, buf.Length);
                            buf = Encoding.Unicode.GetBytes("\n");
                            fs.Write(buf, 0, buf.Length);
                        }
                    }
                    if (choiceOpponent == 2) 
                    {
                        Game(person1, combat);                  //Game between user and Computer Combat
                        ResultWin(person1, combat);             //Cheking result
                        if (flag == 1)                          // if flag value is 1 then some one has win or means who played marked last time which has win
                        {
                            if (((player % 2) + 1) == 1)
                            {
                                buf = Encoding.Unicode.GetBytes(person1.GetName());
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes(" 1:0 ");
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes(combat.GetName());
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes("\n");
                                fs.Write(buf, 0, buf.Length);
                            }
                            else
                            {
                                buf = Encoding.Unicode.GetBytes(person1.GetName());
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes(" 0:1 ");
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes(combat.GetName());
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes("\n");
                                fs.Write(buf, 0, buf.Length);
                            }

                        }
                        else// if flag value is -1 the match will be draw and no one is winner
                        {
                            buf = Encoding.Unicode.GetBytes(person1.GetName());
                            fs.Write(buf, 0, buf.Length);
                            buf = Encoding.Unicode.GetBytes(" 0:0 ");
                            fs.Write(buf, 0, buf.Length);
                            buf = Encoding.Unicode.GetBytes(combat.GetName());
                            fs.Write(buf, 0, buf.Length);
                            buf = Encoding.Unicode.GetBytes("\n");
                            fs.Write(buf, 0, buf.Length);
                        }
                    }
                    if (choiceOpponent == 3)
                    {
                        Game(person1, scout);                   //Game between user and Computer scout
                        ResultWin(person1, scout);              //Checking result
                        if (flag == 1)                          // if flag value is 1 then some one has win or means who played marked last time which has win
                        {
                            if (((player % 2) + 1) == 1)
                            {
                                buf = Encoding.Unicode.GetBytes(person1.GetName());
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes(" 1:0 ");
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes(scout.GetName());
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes("\n");
                                fs.Write(buf, 0, buf.Length);
                            }
                            else
                            {
                                buf = Encoding.Unicode.GetBytes(person1.GetName());
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes(" 0:1 ");
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes(scout.GetName());
                                fs.Write(buf, 0, buf.Length);
                                buf = Encoding.Unicode.GetBytes("\n");
                                fs.Write(buf, 0, buf.Length);
                            }

                        }
                        else// if flag value is -1 the match will be draw and no one is winner
                        {
                            buf = Encoding.Unicode.GetBytes(person1.GetName());
                            fs.Write(buf, 0, buf.Length);
                            buf = Encoding.Unicode.GetBytes(" 0:0 ");
                            fs.Write(buf, 0, buf.Length);
                            buf = Encoding.Unicode.GetBytes(scout.GetName());
                            fs.Write(buf, 0, buf.Length);
                            buf = Encoding.Unicode.GetBytes("\n");
                            fs.Write(buf, 0, buf.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();             //closing FileStream and make memory free
                    }
                }
                Console.WriteLine("Do you want to play again? 1 -yes/ 2 - no");
                do
                {
                    circle = ChekAnsw();
                } while (circle != 1 && circle != 2); // Choosing want to continue play or exit

                ResetField();
            } while (circle == 1);

            File.Delete("Statistic.txt");           //Delete statistic file after exit
            Console.Clear();
            Console.WriteLine("Good bye!");

        }
        /// <summary>
        /// <remark>Method of Reset Field for new game</remark>
        /// </summary>
        public static void ResetField()
        {
            for (var i = 1; i < arr.Length; i++)
            {
                arr[i] = char.Parse(i.ToString());
            }
        }
        /// <summary>
        /// <remark>Checking correct entering number for continue or stop this game</remark>
        /// </summary>
        private static int ChekAnsw()
        {
            try
            {
                circle = int.Parse(Console.ReadLine());

                if (circle != 1 && circle != 2)
                    Console.WriteLine("You enter wrong data, try again:");
            }
            catch (Exception)
            {
                Console.WriteLine("Enter 1 or 2");
            }
            return circle;
        }
        /// <summary>
        /// <remark>Method which painting the game's board</remark>
        /// </summary>
        private static void Board()                             
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }
        /// <summary>
        /// <remark>Method for interaction of players</remark>
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        private static void Game(Player one, Player two)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("{0}: X and {1}: O", one.GetName(), two.GetName());
                Console.WriteLine("\n");
                Board();                                                                      // calling the board Function
                if (player % 2 == 1)                                                         //checking the chance of the player
                {
                    Console.Write("{0} Chance: ", one.GetName());
                    choice = one.Selection(arr, player, ref passage);
                    arr[choice] = 'X';
                    player++;
                    
                }
                else
                {
                    Console.Write("{0} Chance: ", two.GetName());
                    choice = two.Selection(arr, player, ref passage);
                    arr[choice] = 'O';
                    player++;

                }
                
                flag = CheckWin();                       // calling of check win
            } while (flag != 1 && flag != -1);          // This loof will be run until all cell of the grid is not marked with X and O 
                                                       //or some player is not win

            Console.Clear();                          // clearing the console
            Board();                                 // getting filled board again

            
        }
        /// <summary>
        /// <remark>Show to console who won</remark>
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        private static void ResultWin(Player one, Player two)
        {
            

            if (flag == 1)                          // if flag value is 1 then some one has win or means who played marked last time which has win
            {
                if (((player % 2) + 1) == 1)
                {
                    Console.WriteLine("Player {0} has won", one.GetName());
                    one.GetWin(); 
                }
                else
                {
                    Console.WriteLine("Player {0} has won", two.GetName());
                    two.GetWin();
                }

            }
            else                                     // if flag value is -1 the match will be draw and no one is winner
            {
                Console.WriteLine("Draw");
                one.GetDraw();
                two.GetDraw();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// <remark>Winner determination method</remark>
        /// </summary>
        /// <returns></returns>
        private static int CheckWin()                 //Checking that any player has won or not
        {
            
            //Winning Condition For First Row   
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //Winning Condition For Second Row   
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //Winning Condition For Third Row   
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            
            //vertical Winning Condtion
            //Winning Condition For First Column       
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //Winning Condition For Second Column  
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //Winning Condition For Third Column  
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            
            //Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
           

            
            // If all the cells or values filled with X or O then any player has won the match  
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            
            else
            {
                return 0;
            }
        }

        private static void SMS()
        {
            Console.WriteLine("Method for play with github");
        }
        
    }
}
