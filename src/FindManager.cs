public class FindManagerTests
 {
     [Fact]
     public void FindManager()
     {
         var count = 5;
         var first = "Hilary";
         var second = "James";
         var items = new[] {"Sarah Fred", "Sarah Paul", "Fred Hilary", "Fred Jenny ", "Jenny James"};

         var relations = new KeyValuePair<string,string>[items.Length];

         for (var index = 0; index < items.Length; index++)
         {
             var item = items[index];
             var input = item.Split(' ');
             relations[index] = new KeyValuePair<string, string>(input[0], input[1]);
         }

         var firstHirarchy = new List<string>();
         FindHirarchy(relations, first, firstHirarchy);

         var secondHirarchy = new List<string>();
         FindHirarchy(relations, second, secondHirarchy);

         var findCommon = FindCommon(firstHirarchy, secondHirarchy);

         Assert.Equal("Fred", findCommon);

     }


     private static string FindCommon(IReadOnlyList<string> firstHirarchy, IReadOnlyList<string> secondHirarchy)
     {
         var common = string.Empty;
         var fisrtCount = firstHirarchy.Count;
         var secondCount = secondHirarchy.Count;

         var max = Math.Max(fisrtCount, secondCount);

         for (var i = max; i >= 0; i--)
         {
             fisrtCount--;
             secondCount--;

             if (fisrtCount < 0 || secondCount < 0 || firstHirarchy[fisrtCount] != secondHirarchy[secondCount])
             {
                 common = firstHirarchy[fisrtCount + 1];
                 break;
             }
         }

         return common;
     }

     private static void FindHirarchy(KeyValuePair<string, string>[] relations, string first, ICollection<string> hirarchy)
     {
         while (true)
         {
             var findBoss = relations.FirstOrDefault(rel => rel.Value == first);

             if (findBoss.Key != null)
             {
                 hirarchy.Add(findBoss.Key);
                 FindHirarchy(relations, findBoss.Key, hirarchy);
             }

             break;
         }

     }
 }
