using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Value_referance_Type x = new Value_referance_Type();
            x.ValueRefType();

            //---------------------------------------------------------

            //CasinoDise caseinoGame = new CasinoDise();
            //caseinoGame.CasionoDice();

            CasinoRoulette casinoRoulette = new CasinoRoulette();
            casinoRoulette.CasinoRouletteGame();


        }
    }
}
