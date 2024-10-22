using System;
using System.Globalization;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Order[] orders = new Order[100];
        StreamReader line = new StreamReader("C:\\Users\\Denchik\\source\\repos\\Effective Mobile internship task\\Effective Mobile internship task\\orders.txt");
        String inputLine;
        inputLine = line.ReadLine();
        int j = 0;
        while (inputLine!=null)
        {
            string[] parts = inputLine.Split(' ');
            try
            {
                orders[j] = new Order
                {
                    Id = int.Parse(parts[0]),
                    Weight = double.Parse(parts[1]), 
                    AdressID = int.Parse(parts[2]), 
                    Date = DateTime.ParseExact(parts[3] + " " + parts[4], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) 
                };
                j++;
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Format error in line: " + inputLine + ". Error: " + fe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General error in line: " + inputLine + ". Error: " + ex.Message);
            };
            inputLine = line.ReadLine();
        }
        line.Close();
        for (int i = 0; i < j; i++)
        {
            Console.WriteLine($"Id: {orders[i].Id}, Weight: {orders[i].Weight}, AdressID: {orders[i].AdressID}, OrderDate: {orders[i].Date.ToString("yyyy-MM-dd HH:mm:ss")}");
        };


        Console.WriteLine("Input adress and date to sort by:");
        int AdressFilter = Convert.ToInt32(Console.ReadLine());
        DateTime filterStartTime;
        DateTime filterEndTime;
        filterStartTime = DateTime.Parse(Console.ReadLine()); 
        filterEndTime = DateTime.Parse(Console.ReadLine());
        int k = 0;
        for(int i= 0;i<j;i++)
        {
            if ((orders[i].AdressID == AdressFilter) &( filterStartTime < orders[i].Date) & (orders[i].Date < filterEndTime))
            {
                Console.WriteLine($"Id: {orders[i].Id}, Weight: {orders[i].Weight}, AdressID: {orders[i].AdressID}, OrderDate: {orders[i].Date.ToString("yyyy-MM-dd HH:mm:ss")}");
            }
        }
    }
}

class Order
{
    public int Id { get; set; }
    public double Weight { get; set; }
    public int AdressID { get; set; }
    public DateTime Date { get; set; }
}