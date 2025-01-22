using Olve.Trie.Tests.Shared;
using TUnit.Assertions.Enums;
// ReSharper disable CollectionNeverUpdated.Local

namespace Olve.Trie.Tests;

[InheritsTests]
public class NaiveArrayTrieTests : TrieTests<NaiveArrayTrie>;

public abstract class TrieTests<TTrie> where TTrie : ITrie, new()
{
    [Test]
    public async Task Contains_AfterAddingItem_ReturnsTrue()
    {
        // Arrange
        const string item = "hello";

        var trie = new TTrie { item };

        // Act
        var actual = trie.Contains("hello");

        // Assert
        await Assert
            .That(actual)
            .IsTrue();
    }

    [Test]
    public async Task Contains_WithoutAddingItem_ReturnsFalse()
    {
        // Arrange
        var trie = new TTrie();

        // Act
        var actual = trie.Contains("hello");

        // Assert
        await Assert
            .That(actual)
            .IsFalse();
    }

    [Test]
    public async Task GetEnumerator_AfterAddingItems_ReturnsAllItems()
    {
        // Arrange
        var trie = new TTrie { "hello", "world" };

        // Act
        var actual = trie.ToList();

        // Assert
        await Assert
            .That(actual)
            .IsEquivalentTo(["hello", "world"]);
    }

    [Test]
    public async Task Clear_AfterAddingItems_IsEmpty()
    {
        // Arrange
        var trie = new TTrie { "hello", "world" };

        // Act
        trie.Clear();

        // Assert
        await Assert
            .That(trie)
            .IsEmpty();
    }

    [Test]
    public async Task Count_AfterAddingItems_ReturnsNumberOfItems()
    {
        // Arrange
        var trie = new TTrie { "hello", "world" };

        // Act
        var actual = trie.Count;

        // Assert
        await Assert
            .That(actual)
            .IsEqualTo(2);
    }

    [Test]
    public async Task Count_AfterRemovingItem_ReturnsNumberOfItems()
    {
        // Arrange
        var trie = new TTrie { "hello", "world" };

        // Act
        trie.Remove("hello");

        // Assert
        await Assert
            .That(trie.Count)
            .IsEqualTo(1);
    }

    [Test]
    public async Task Add_DuplicateItem_DoesNotIncreaseCount()
    {
        // Arrange
        var trie = new TTrie { "hello" };

        // Act
        trie.Add("hello");

        // Assert
        await Assert
            .That(trie.Count)
            .IsEqualTo(1);
    }

    [Test]
    public async Task Remove_NonExistentItem_ReturnsFalse()
    {
        // Arrange
        var trie = new TTrie { "hello" };

        // Act
        var result = trie.Remove("world");

        // Assert
        await Assert
            .That(result)
            .IsFalse();
    }

    [Test]
    public async Task Remove_ExistingItem_ReturnsTrueAndDecreasesCount()
    {
        // Arrange
        var trie = new TTrie { "hello", "world" };

        // Act
        var result = trie.Remove("hello");

        // Assert
        await Assert
            .That(result)
            .IsTrue();
        await Assert
            .That(trie.Count)
            .IsEqualTo(1);
    }

    [Test]
    public async Task Contains_PrefixOfExistingItem_ReturnsFalse()
    {
        // Arrange
        var trie = new TTrie { "hello" };

        // Act
        var result = trie.Contains("hell");

        // Assert
        await Assert
            .That(result)
            .IsFalse();
    }

    [Test]
    public async Task Enumerator_WithNoItems_IsEmpty()
    {
        // Arrange
        var trie = new TTrie();

        // Act
        var actual = trie.ToList();

        // Assert
        await Assert
            .That(actual)
            .IsEmpty();
    }

    [Test]
    public async Task Clear_OnEmptyTrie_DoesNotThrow()
    {
        // Arrange
        var trie = new TTrie();

        // Act
        trie.Clear();

        // Assert
        await Assert
            .That(trie)
            .IsEmpty();
    }

    [Test]
    public async Task Add_MultipleItemsWithCommonPrefix_StoresCorrectly()
    {
        // Arrange
        var trie = new TTrie { "test", "testing", "tester" };

        // Act
        var actual = trie.ToList();

        // Assert
        await Assert
            .That(actual)
            .IsEquivalentTo(["test", "testing", "tester"], CollectionOrdering.Any);
    }

    [Test]
    public async Task Remove_ItemWithSharedPrefix_DoesNotAffectOthers()
    {
        // Arrange
        var trie = new TTrie { "test", "testing", "tester" };

        // Act
        trie.Remove("testing");

        // Assert
        await Assert
            .That(trie.Contains("test"))
            .IsTrue();
        await Assert
            .That(trie.Contains("tester"))
            .IsTrue();
        await Assert
            .That(trie.Contains("testing"))
            .IsFalse();
        await Assert
            .That(trie.Count)
            .IsEqualTo(2);
    }

    [Test]
    public async Task NewTrie_WithWordsAlpha_ReturnsCorrectCount()
    {
        // Arrange
        var words = TestDataHelper.GetTestData();
        var expected = words.Length;
        TTrie trie = [..words];

        // Act
        var actual = trie.Count;

        // Assert
        await Assert
            .That(actual)
            .IsEqualTo(expected);

    }

}