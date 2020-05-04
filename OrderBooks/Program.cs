using System;

namespace OrderBooks
{
    class Program
    {
        static void Main()
        {
            var x = new ExecuteWork();
            x.MatchDataFromFile("..\\..\\..\\..\\OrderBooks\\order_books_data.json");
        }

    }
}
