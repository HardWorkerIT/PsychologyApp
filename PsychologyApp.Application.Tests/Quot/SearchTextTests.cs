using PsychologyApp.Application.Common;
using Xunit;

namespace PsychologyApp.Application.Tests.Quot;

public class SearchTextTests
{
    private static bool Finds(string text, string query) => SearchText.Matches(text, SearchText.Stems(query));

    [Theory]
    [InlineData("Тревоги и страхи", "тревога")]
    [InlineData("Как справиться с тревогой", "тревога")]
    [InlineData("Он увидел ёлочку", "елочка")]
    [InlineData("Он увидел елочку", "ёлочка")]
    [InlineData("БОЛЬ В ГРУДИ", "боль")]
    [InlineData("Страх публичных выступлений", "страх выступление")]
    public void Other_forms_case_and_yo_still_match(string text, string query) => Assert.True(Finds(text, query));

    [Theory]
    [InlineData("Тревога", "радость")]
    [InlineData("Тревога на работе", "тревога семья")]
    [InlineData("", "тревога")]
    [InlineData("текст", "")]
    [InlineData("текст", "   ")]
    public void Unrelated_or_empty_does_not_match(string text, string query) => Assert.False(Finds(text, query));

    [Fact]
    public void Short_words_are_matched_exactly_as_typed() => Assert.False(Finds("сон и покой", "сом"));

    [Fact]
    public void Every_word_of_the_query_must_be_present() => Assert.False(Finds("Тревога", "тревога работа"));

    [Theory]
    [InlineData(256)]
    [InlineData(257)]
    public void Case_and_yo_match_on_both_sides_of_the_buffer_limit(int length)
    {
        string quote = new string('x', length - 4) + " ЁЖ!";

        Assert.True(Finds(quote, "еж"));
        Assert.False(Finds(quote, "еж я"));
    }
}
