// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Data\wordlist.txt"));

var words = data.Split("\n").ToList();


List<string> resultWords = FilterWordsByExactLength(words, 6);
List<string> filteredWords = FilterWordsByMaxLength(words, 6);
var result = new List<string>();

HashSet<string> wordsOfSixSet = new HashSet<string>(resultWords);


for (int i = 0; i < filteredWords.Count; i++)
{
    for (int j = 0; j < filteredWords.Count; j++)
    {
        if (i != j)
        {
            string concatWord = filteredWords[i] + filteredWords[j];
            if (concatWord.Length == 6 && wordsOfSixSet.Contains(concatWord))
            {
                var item = $"{filteredWords[i]} + {filteredWords[j]} => {filteredWords[i]}{filteredWords[j]}";
                result.Add(item);
                Console.WriteLine(item);
            }
        }
    }
}

static List<string> FilterWordsByMaxLength(List<string> words, int maxLength)
{
    return words.Where(word => word.Length < maxLength).ToList();
}

static List<string> FilterWordsByExactLength(List<string> words, int maxLength)
{
    return words.Where(word => word.Length == maxLength).ToList();
}