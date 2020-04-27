namespace OrderBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new ReadData("..\\..\\..\\order_books_data.json");
            data.ReadFile();
            ReadJsonData jsonData = new ReadJsonData(data);
            jsonData.Execute();
        }
    }
}
