using PsychologyApp.Application.Conversation.Companion;
using Xunit;

namespace PsychologyApp.Application.Tests.Conversation;

public class LocalModelCatalogTests
{
    [Fact]
    public void ModelWeightsAndLargeTokenizer_AreVerifiedByHash()
    {
        foreach (LocalModelFile file in LocalModelCatalog.Default.Files.Where(file =>
                     file.Path is "model.onnx" or "model_q4f16.onnx_data" or "tokenizer.json"))
        {
            Assert.False(string.IsNullOrWhiteSpace(file.Sha256), $"{file.Path} has no SHA-256 integrity check.");
            Assert.Equal(64, file.Sha256!.Length);
        }

        Assert.All(LocalModelCatalog.Default.Files.Where(file => file.Sha256 is null), file => Assert.True(file.VerifySize));
    }

    [Fact]
    public void EveryUrl_IsHttpsAndPinnedToACommit()
    {
        foreach (LocalModelFile file in LocalModelCatalog.Default.Files)
        {
            Assert.StartsWith("https://", file.Url);
            Assert.DoesNotContain("/resolve/main/", file.Url);
        }
    }
}
