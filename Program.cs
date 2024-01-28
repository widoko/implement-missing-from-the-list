namespace MissingFinder;

public abstract class Program
{
  public static void Main(string[] args)
  {
    if (args.Length < 3)
    {
      Console.WriteLine("Please provide a list of numbers followed by the range a and b.");
      return;
    }

    string[] listStrings = args[0].Split(',');
    int[] list = new int[listStrings.Length];
    for (int i = 0; i < listStrings.Length; i++)
    {
      if (!int.TryParse(listStrings[i], out list[i]))
      {
        Console.WriteLine("Invalid input for the list of numbers.");
        return;
      }
    }

    if (!int.TryParse(args[1], out var a) || !int.TryParse(args[2], out var b))
    {
      Console.WriteLine("Invalid input for the range values a and b.");
      return;
    }

    if (a > b)
    {
      Console.WriteLine($"The value of b must be greater than the value of a");
      return;
    }
    
    int missing = Missing(list, a, b);
    Console.WriteLine($"Number of missing integers between {a} and {b}: {missing}");
  }

  private static int Missing(int[] list, int a, int b)
  {
    return Enumerable.Range(a, b - a + 1).Count(i => !list.Contains(i));
  }
}