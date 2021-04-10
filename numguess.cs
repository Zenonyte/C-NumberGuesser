using System;

namespace TestProgram
{
  class Program
  {
    public static void Main(string[] args)
    {
      int maxn; bool cont = true;
      do
      {
        Console.WriteLine("Maxnum (default = 100):");
        bool r1 = int.TryParse(Console.ReadLine(), out maxn);
        if (r1 == false) // if input left empty, maxn = 100
        {
          maxn = 100;
        }
        int rnum = GenerateRnum(maxn); int guessc = 0; int guess = 0; string glist = "guesses:";
        Console.WriteLine($"The number will be between 0 and {maxn}. ");
        do
        {
          guessc++;
          Console.WriteLine($"Guess {guessc}: Previous {glist}");
          try
          {
            int Guess = Convert.ToInt32(Console.ReadLine());
            guess = Guess;
            if (guess > rnum)
            {
            Console.WriteLine($"{guess} is too high!");
            glist = AddGIndex(glist, $"<{guess.ToString()}");
            }
            else if (guess < rnum)
            {
            Console.WriteLine($"{guess} is too low!");
            glist = AddGIndex(glist, $"{guess.ToString()}<");
            }
          }
          catch
          {
            Console.WriteLine("Wrong input.");
          }
        }
        while (guess != rnum);
        glist = AddGIndex(glist, $"={guess.ToString()}=");
        Console.WriteLine($"Spot on! You got the number in {guessc} tries! All {glist}");
        Console.WriteLine("Press enter or type 'c' to cancel. ");
        string choice = Console.ReadLine().ToUpper();
        if (string.Equals(choice, "C"))
        {
          cont = false;
        }
      }
      while (cont == true);
    static int GenerateRnum(int maxn = 100) // gen a random number w/ given maxn
    {
      System.Random rnd = new System.Random();
      int rnum = rnd.Next(maxn);
      return rnum;
    }
    static string AddGIndex(string glist, string ix)
    {
      glist = $"{glist} {ix}";
      return glist;
    }
  }
}
