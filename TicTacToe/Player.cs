using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// <remark>Interface for three classes of players</remark>
    /// </summary>
    interface Player
    {
        string GetName();
        int GetWin();
        int GetDraw();
        int Selection(char[] arr, int player, ref bool passage);
        
    }
}
