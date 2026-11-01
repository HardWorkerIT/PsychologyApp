namespace PsychologyApp.Application.Conversation.Companion;

public static class LocalModelCatalog
{
    private const string Revision = "d6beae7d59bc21264488d12f466f4ca6b252806f";
    private const string Repository = "https://huggingface.co/onnx-community/Qwen3-0.6B-DQ-ONNX/resolve/" + Revision + "/";

    public static LocalModelManifest Default { get; } = new(
        "qwen3-0.6b-dq-onnx",
        "Qwen3 0.6B (4-bit)",
        "https://huggingface.co/Qwen/Qwen3-0.6B-Base/blob/main/LICENSE",
        [
            new("added_tokens.json", Repository + "added_tokens.json", 707),
            new("config.json", Repository + "config.json", 983),
            new("genai_config.json", Repository + "genai_config.json", 1718),
            new("model.onnx", Repository + "onnx/model_q4f16.onnx", 64_200_000, "e020dd2bd158459e12296648fe73b6ec92c15a2cd83da5487f1efdf42c3d1b52", false),
            new("model_q4f16.onnx_data", Repository + "onnx/model_q4f16.onnx_data", 291_000_000, "2705201c0bc9a7b11e31c3354644f99d274e266272870045d61e7410966a88e5", false),
            new("special_tokens_map.json", Repository + "special_tokens_map.json", 613),
            new("tokenizer.json", Repository + "tokenizer.json", 11_400_000, "aeb13307a71acd8fe81861d94ad54ab689df773318809eed3cbe794b4492dae4", false),
            new("tokenizer_config.json", Repository + "tokenizer_config.json", 9_762)
        ],
        Languages: ["en", "ru"],
        MinTotalMemoryBytes: 4L * 1024 * 1024 * 1024,
        MinAvailableMemoryBytes: 1024L * 1024 * 1024);
}
