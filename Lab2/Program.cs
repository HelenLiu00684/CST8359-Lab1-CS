namespace Lab2;

internal class Program
{
     static void Main(string[] args)
     {
          string choice;

          IList<string> words = new List<string>();

          do
          {
               DisplayMenu();
               Console.Write("Enter your choice: ");

               choice = Console.ReadLine()?.Trim().ToUpper() ?? "";

               switch (choice)
               {
                    case "1":
                         try
                         {
                              words = File.ReadAllLines("Words.txt").ToList();
                              Console.WriteLine($"{words.Count} words were imported.");
                         }
                         catch (FileNotFoundException)
                         {
                              Console.WriteLine("Error: Words.txt was not found.");
                         }
                         catch (IOException ex)
                         {
                              Console.WriteLine($"Error reading Words.txt: {ex.Message}");
                         }
                         break;

                    case "2":
                         if (words.Count == 0)
                         {
                              Console.WriteLine("Please import the words first using option 1.");
                              break;
                         }

                         IList<string> bubbleSortedWords = BubbleSort(words);

                         foreach (string word in bubbleSortedWords)
                         {
                              Console.WriteLine(word);
                         }

                         break;

                    case "3":
                         if (words.Count == 0)
                         {
                              Console.WriteLine("Please import the words first using option 1.");
                              break;
                         }

                         IList<string> linqSortedWords = LINQSort(words);

                         foreach (string word in linqSortedWords)
                         {
                              Console.WriteLine(word);
                         }

                         break;

                    case "4":
                         if (words.Count == 0)
                         {
                              Console.WriteLine("Please import the words first using option 1.");
                              break;
                         }

                         int distinctWordCount = words
                             .Distinct(StringComparer.OrdinalIgnoreCase)
                             .Count();

                         Console.WriteLine(
                             $"The number of distinct words is: {distinctWordCount}");

                         break;

                    case "5":
                         if (words.Count == 0)
                         {
                              Console.WriteLine("Please import the words first using option 1.");
                              break;
                         }

                         IEnumerable<string> firstTenWords = words.Take(10);

                         Console.WriteLine("The first 10 words are:");

                         foreach (string word in firstTenWords)
                         {
                              Console.WriteLine(word);
                         }

                         break;

                    case "6":
                         if (words.Count == 0)
                         {
                              Console.WriteLine("Please import the words first using option 1.");
                              break;
                         }

                         IList<string> reversedWords = words
                             .Select(word => new string(word.Reverse().ToArray()))
                             .ToList();

                         Console.WriteLine("The reversed words are:");

                         foreach (string word in reversedWords)
                         {
                              Console.WriteLine(word);
                         }

                         break;

                    case "7":
                         if (words.Count == 0)
                         {
                              Console.WriteLine("Please import the words first using option 1.");
                              break;
                         }

                         IList<string> wordsEndingWithA = words
                             .Where(word => word.EndsWith(
                                 "a", StringComparison.OrdinalIgnoreCase))
                             .ToList();

                         Console.WriteLine("Words ending with 'a':");

                         foreach (string word in wordsEndingWithA)
                         {
                              Console.WriteLine(word);
                         }

                         Console.WriteLine(
                             $"Total words ending with 'a': {wordsEndingWithA.Count}");

                         break;

                    case "8":
                         if (words.Count == 0)
                         {
                              Console.WriteLine("Please import the words first using option 1.");
                              break;
                         }

                         IList<string> wordsStartingWithM = words
                             .Where(word => word.StartsWith(
                                 "m", StringComparison.OrdinalIgnoreCase))
                             .ToList();

                         Console.WriteLine("Words starting with 'm':");

                         foreach (string word in wordsStartingWithM)
                         {
                              Console.WriteLine(word);
                         }

                         Console.WriteLine(
                             $"Total words starting with 'm': {wordsStartingWithM.Count}");

                         break;

                    case "9":
                         if (words.Count == 0)
                         {
                              Console.WriteLine("Please import the words first using option 1.");
                              break;
                         }

                         IList<string> matchingWords = words
                             .Where(word =>
                                 word.Length > 5 &&
                                 word.Contains("s", StringComparison.OrdinalIgnoreCase))
                             .ToList();

                         Console.WriteLine(
                             "Words longer than 5 characters and containing 's':");

                         foreach (string word in matchingWords)
                         {
                              Console.WriteLine(word);
                         }

                         Console.WriteLine(
                             $"Total matching words: {matchingWords.Count}");

                         break;

                    case "X":
                         Console.WriteLine("Exiting the application.");
                         break;

                    default:
                         Console.WriteLine("Invalid option. Please try again.");
                         break;
               }

               Console.WriteLine();

          } while (choice != "X");
     }

     static void DisplayMenu()
     {
          Console.WriteLine("Choose an option:");
          Console.WriteLine("1 - Import Words from File");
          Console.WriteLine("2 - Bubble Sort");
          Console.WriteLine("3 - LINQ/Lambda Sort");
          Console.WriteLine("4 - Count Distinct Words");
          Console.WriteLine("5 - Display First 10 Words");
          Console.WriteLine("6 - Reverse Each Word");
          Console.WriteLine("7 - Words Ending with 'a'");
          Console.WriteLine("8 - Words Starting with 'm'");
          Console.WriteLine(
              "9 - Words Longer Than 5 Characters and Containing 's'");
          Console.WriteLine("X - Exit");
     }

     static IList<string> BubbleSort(IList<string> words)
     {
          // Create a copy so the original list is not modified.
          List<string> sortedWords = new List<string>(words);

          for (int i = 0; i < sortedWords.Count - 1; i++)
          {
               bool swapped = false;

               for (int j = 0; j < sortedWords.Count - i - 1; j++)
               {
                    if (string.Compare(
                            sortedWords[j],
                            sortedWords[j + 1],
                            StringComparison.OrdinalIgnoreCase) > 0)
                    {
                         string temporaryWord = sortedWords[j];
                         sortedWords[j] = sortedWords[j + 1];
                         sortedWords[j + 1] = temporaryWord;

                         swapped = true;
                    }
               }

               // Stop early when the list is already sorted.
               if (!swapped)
               {
                    break;
               }
          }

          return sortedWords;
     }

     static IList<string> LINQSort(IList<string> words)
     {
          // OrderBy creates a new list without modifying the original list.
          return words
              .OrderBy(word => word, StringComparer.OrdinalIgnoreCase)
              .ToList();
     }
}