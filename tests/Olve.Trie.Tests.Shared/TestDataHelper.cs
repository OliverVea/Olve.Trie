namespace Olve.Trie.Tests.Shared;

public static class TestDataHelper
{
    private const string TestDataPath = "TestData/words_alpha.txt";
    private const int RandomSeed = 42;

    public static string[] GetTestData(bool shuffle = true)
    {
        var words = File.ReadAllLines(TestDataPath);

        var random = new Random(RandomSeed);
        random.Shuffle(words);

        return words;
    }
}