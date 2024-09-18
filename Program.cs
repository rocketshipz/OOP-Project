// See https://aka.ms/new-console-template for more information

class Programs
{
    static void Main(string[] args)
    {
        Transaction transaction = new Transaction();

        transaction.setDate( new DateTime(2008, 6, 11, 7, 47, 0));
        transaction.setVal( 10.5f);

        Console.WriteLine("transaction value is " + transaction.getVal() + " at time " + transaction.getDate().ToString());
        Console.WriteLine("Byee");
    }
}