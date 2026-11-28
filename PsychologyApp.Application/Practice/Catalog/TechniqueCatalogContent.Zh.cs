using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice.Catalog;

internal static class TechniqueCatalogContentZh
{
    internal static TheorySection[] Theory(string what, string when, string how, string example) =>
    [
        new("这是什么", what),
        new("什么时候可以尝试", when),
        new("练习怎么做", how),
        new("示例", example)
    ];

    /// <summary>Common topics for a "problem" field: a start to tap and then add a word or two, not a full answer.</summary>
    private static readonly string[] ProblemTopics =
        ["和亲近的人吵架", "工作上的事", "和上司的冲突", "学习或考试", "健康", "钱", "孤独", "一次失败", "分手", "和父母的关系", "孩子", "搬家", "未来", "别人对我的批评"];

    private static readonly string[] BackupOptions =
        ["寻求帮助", "等一等再试", "另找办法", "降低对自己的要求", "休息一下", "和亲近的人聊聊", "去看专业人士", "找份兼职", "上一门课", "把任务拆成小步", "推迟决定", "从小处开始"];

    private static readonly string[] HarshThoughts =
        ["“我会把一切都搞砸”", "“他们会评判我”", "“我应付不了”", "“没有人需要我”", "“这是一场灾难”", "“什么都不会成功”", "“我不如别人”", "“总是事事不顺”", "“都是我的错”", "“我有问题”", "“这永远不会结束”", "“我必须完美”"];

    internal static readonly BuiltInTechniqueDefinition Spin = new(
        "练习", "说出此刻的感受",
        [
            "1. 选择最近一件让你有些不舒服的日常小事",
            "2. 说出最主要的感受",
            "3. 评估此刻的感受强度（0 到 10）"
        ],
        "简单记录事情和感受，不必期待马上轻松下来。",
        TechniqueUiKind.Entry, "技巧 #1", "26.01.2023", "说出此刻的感受", "留意现在的感受", "艰难时刻", "PsychologyApp 团队", 5, "Autorenew",
        [
            new TechniqueEntrySeed("情境", "例如：工作中一件小事。无需写下令人痛苦的细节。", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("主要感受", "委屈、担心、愤怒……", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("此刻的强度", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "记录情境、感受及其此刻的强度。这是自我观察，不是治疗，也不保证感受会立刻改变。",
            "如果你愿意书写，可用于一件程度较轻的日常烦心事。不要选择创伤性回忆或正在经历的急性危机。",
            "只写必要内容，并评估此刻的感受。如果不适加重，请停下来，看看周围，再选择更中性的练习。无需重复。",
            "情境：同事打断了我。感受：烦躁。此刻强度：5 分（满分 10 分）。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Comparison = new(
        "练习", "看看更广阔的生活背景",
        [
            "1. 说说现在什么让你为难，不必淡化它",
            "2. 这件事影响了生活中的哪些方面？",
            "3. 还有什么重要的事也需要关注？",
            "4. 今天你想照顾谁或什么？",
            "5. 记下你的发现，不必判断问题是大是小"
        ],
        "这个练习帮助你列出生活中的不同方面；它不能判断问题有多严重。",
        TechniqueUiKind.Entry, "技巧 #2", "26.01.2023", "看看更广阔的生活背景", "当一件困难的事占据全部注意力时", "问题的规模", string.Empty, 7, "CompareArrows",
        [
            new TechniqueEntrySeed("正在发生什么", "现在什么让你为难？", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("受到影响的方面", "例如：工作、健康、人际关系", Suggestions: ["工作", "家庭", "朋友", "健康", "学业", "金钱", "人际关系", "睡眠", "居住", "爱好", "休息", "计划"]),
            new TechniqueEntrySeed("还有什么重要", "什么也需要你的关注？", Suggestions: ["工作", "家庭", "健康", "人际关系", "休息", "孩子", "朋友", "学业", "睡眠", "内心平静", "自我成长", "日常事务"]),
            new TechniqueEntrySeed("想照顾的事", "今天谁或什么需要你的关注？", Suggestions: ["健康", "亲近的人", "睡眠", "休息", "工作上的事", "一次谈话", "日常任务", "个人界限", "还不确定"]),
            new TechniqueEntrySeed("你注意到了什么", "不必得出积极的结论")
        ],
        Theory(
            "这个练习帮助你说出其他需求和事务，同时不否定当前困难的重要性。",
            "当一个话题几乎占满你的注意力，而你想看看还有哪些需求或事情需要关注时。",
            "用自己的话填写，不必寻找积极的转折。如果需要处理实际行动或安全问题，请先处理。任何一栏都可以留空。",
            "找工作影响了收入和睡眠；今天我也想照顾一位亲近的人。也许我可以选择一个求职步骤并寻求支持。这并不意味着烦恼不严重。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Polarity = new(
        "练习", "两极",
        [
            "1. 写下这件事中你喜欢的方面",
            "2. 写下你不喜欢的方面",
            "3. 对比每一组，留意其中的平衡"
        ],
        "两极方法帮助你看到事情的两面，减轻内心的紧张。",
        TechniqueUiKind.Polarity, "技巧 #3", "26.01.2023", "两极", "看到事情的两面", "不同的方面", "日沃拉德·斯拉文斯基", 5, "Contrast",
        null,
        Theory(
            "每件事都有吸引人和令人不快的一面。把两面都说出来，可以减少片面的执着。",
            "当你只看到坏的或只看到好的，感觉卡住了时。",
            "针对一个主题，添加“喜欢 / 不喜欢”的组合。比较两张清单，不评判谁对谁错。",
            "工作：喜欢收入，不喜欢作息。家：喜欢舒适，不喜欢邻居的噪音。"),
        "你不喜欢的", "你喜欢的");

    internal static readonly BuiltInTechniqueDefinition Paper = new(
        "练习", "把想法写下来",
        [
            "1. 在下方或纸上写下一句话",
            "2. 读一遍；如果愿意，说出此刻的感受",
            "3. 自己决定怎么处理这张纸：保留、折起或撕掉；什么也不做也可以"
        ],
        "写下来可以看清想法的表达方式；不必撕掉纸，也不必期待马上轻松。",
        TechniqueUiKind.Paper, "技巧 #4", "26.01.2023", "把想法写下来", "当一个想法反复出现时", "想法", "PsychologyApp 团队", 3, "Description",
        [new TechniqueEntrySeed("想法", "例如：“我会把演讲搞砸。”", Suggestions: HarshThoughts)],
        Theory(
            "写下一句话，看看这个想法是怎样表达的。这是自我观察，不是治疗，也不保证感受会改变。",
            "当想法反复出现，而且你愿意写下来时尝试。如果书写让你更不舒服，请停下。",
            "写一句话并读一遍。保留、收起或撕掉纸张都由你决定；不必强迫自己平静下来。",
            "想法：“我会把演讲搞砸。”你可以保留这张纸，再检查一页幻灯片。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Future = new(
        "练习", "从未来回看",
        [
            "1. 选择一件目前能够应对的日常困难",
            "2. 选择一个时间跨度，例如一年或五年后，再想象从那里回看这件事"
        ],
        "试着从未来的角度评估眼前的事。它仍然可能很重要，不必刻意淡化。",
        TechniqueUiKind.Entry, "技巧 #5", "30.01.2023", "从未来回看", "换个角度，但不淡化问题", "问题的规模", "PsychologyApp 团队", 2, "Schedule",
        [
            new TechniqueEntrySeed("情境", "例如：工作中一件可以处理的小困难。", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("从这个时间跨度看，它有多重要？", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "时间视角是一种想象中的观察方式。事情的重要性可能保持不变，这也完全可以。",
            "适用于能够应对的日常困难。不要选择创伤性回忆或需要立即处理的紧急问题。",
            "选择一个时间跨度，例如一年或五年后，想象从那里回看，并给重要性打分。没有标准答案；如果这种角度不合适，就停下来。",
            "一年后，没收到邀请的事仍可能重要。今天可以询问计划，也可以选择下一步行动。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Hack = new(
        "练习", "留意身边的细节",
        [
            "1. 选择身边一个中性的物品，不必回想痛苦的经历",
            "2. 说出它的三个细节：颜色、形状和表面",
            "3. 决定要继续练习还是停下来"
        ],
        "短暂留意身边的物品，不必重新回想痛苦事件。",
        TechniqueUiKind.Entry, "技巧 #6", "30.01.2023", "留意身边的细节", "把注意力转向周围", "艰难时刻", "PsychologyApp 团队", 3, "BlurOn",
        [new TechniqueEntrySeed("身边的物品", "例如：杯子、窗户或书。", Role: EntryFieldRole.None)],
        Theory(
            "把注意力放在眼前一个中性的物品上。这是短暂的定向练习，不是治疗，也不能替代专业支持。",
            "当你想短暂关注周围环境时可以尝试。不要用它代替紧急求助。",
            "说出物品的三个细节。如果感觉更糟或不舒服，请停下来，看看周围，并选择其他做法。",
            "例如：杯子——白色、圆形、摸起来有些凉。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Experience = new(
        "练习", "经历调整",
        [
            "1. 选择一个要处理的领域",
            "2. 描述你对它的态度",
            "3. 说出相关的信念",
            "4. 想到过去的经历时，态度会怎样变化？",
            "5. 描述一次负面经历",
            "6. 给这次负面经历打分（−10…10）",
            "7. 什么样的积极经历可以替代它？",
            "8. 有了那样的经历，你的态度会怎样变化？",
            "9. 给新的经历打分（−10…10）"
        ],
        "EMO 帮助你用更有支持力的经历替代限制你的经历。",
        TechniqueUiKind.Entry, "技巧 #7", "08.02.2023", "经历调整", "改写限制你的经历", "艰难时刻", "菲利普·斯拉文斯基", 15, "Psychology",
        [
            new TechniqueEntrySeed("领域", "人际关系、工作、健康……", Suggestions: ["人际关系", "工作", "健康", "钱", "公开演讲", "家庭", "学业", "外貌", "友谊", "创造力", "运动", "事业"]),
            new TechniqueEntrySeed("对这个领域的态度", "你现在对它有什么感觉？", Suggestions: ["焦虑", "自我怀疑", "烦躁", "冷漠", "兴趣", "疲惫", "恐惧", "羞耻", "希望", "愤怒", "困惑", "平静"]),
            new TechniqueEntrySeed("相关的信念", "例如：“我不会成功的”", Suggestions: ["“我不会成功的”", "“我不够好”", "“他们不会接受我”", "“什么都不会改变”", "“我必须完美”", "“我运气不好”", "“我不配”", "“别人都比我好”", "“不允许犯错”", "“我年纪太大了”"]),
            new TechniqueEntrySeed("态度与过去的经历", "回想过去时，有什么变化？", Suggestions: ["变得更沉重", "变得更平静", "没有变化", "愤怒涌上来", "悲伤涌上来", "恐惧涌上来", "我想起自己挺过来了", "我想回避"]),
            new TechniqueEntrySeed("负面经历", "一件具体的事或一种模式"),
            new TechniqueEntrySeed("负面经历评分", "", EntryFieldKind.RatingNeg10To10),
            new TechniqueEntrySeed("积极的替代", "可能有什么支持性的经历？", Suggestions: ["我成功的一次", "我得到支持的一次", "我独自应对过来的一次", "我被表扬的一次", "我帮助别人的一次", "我学会新东西的一次", "我没有放弃的一次", "我被如实接纳的一次"]),
            new TechniqueEntrySeed("有了积极经历后的态度", "你对这个领域的看法会怎样变化？", Suggestions: ["出现希望", "更平静", "我想再试一次", "变得有趣", "出现信心", "变得更轻松", "我感到有力量", "还是很难相信"]),
            new TechniqueEntrySeed("新经历评分", "", EntryFieldKind.RatingNeg10To10)
        ],
        Theory(
            "信念常常建立在一次鲜明的负面经历上。有意识地替代它，可以改变你的态度。",
            "当“一直都是这样”，改变似乎不可能时。",
            "按顺序填写各项。比较两个评分——争取第二个更高。",
            "领域：公开演讲。负面：考试失利（−8）。替代：一次成功的发言（+6）。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Copied = new(
        "练习", "留意这个想法",
        [
            "1. 写下一句反复出现的简短想法",
            "2. 读一遍，然后问自己：这是事实、预测还是评价？",
            "3. 如果感觉舒服，可以核实一个事实；如果不适加重，就停下来"
        ],
        "这个练习帮助你观察想法是如何表达的；重复它并不保证焦虑会减轻。",
        TechniqueUiKind.Copied, "技巧 #8", "21.01.2025", "留意这个想法", "说出一个焦虑的想法，不必和自己争辩", "问题的规模", string.Empty, 2, "Repeat",
        [new TechniqueEntrySeed("句子", "我害怕失去工作", Suggestions: HarshThoughts)],
        Theory(
            "这是一个简短的方法，用来留意想法中的措辞并检查它依据什么。不必大声说出来，也不必重复。",
            "当一句话反复出现，而你愿意暂时看看它时可以尝试。如果这个想法现在让你难以承受，就跳过练习。",
            "用几个字写下这个想法。问问自己，哪些是确定知道的，哪些是预测。不要强迫自己相信某个答案。如果不适加重，就停下来。",
            "想法：“我肯定会搞砸会议。”事实：“我明天有个会议。”结果目前还不知道。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Extend = new(
        "练习", "为不确定情况做计划",
        [
            "1. 说出你想为之准备备选方案的情况",
            "2. 写下一种现实可行的选择和可用资源",
            "3. 选择下一步，或决定何时再考虑这个计划"
        ],
        "计划可以帮助看清可采取的行动；它不保证结果，也不保证马上轻松。",
        TechniqueUiKind.Entry, "技巧 #9", "21.01.2025", "为不确定情况做计划", "找到一个实际可行的下一步", "问题的规模", string.Empty, 3, "Backup",
        [
            new TechniqueEntrySeed("情况", "什么可能不会按计划发展？", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("实际可行的选择", "例如：确认期限或寻求帮助", Suggestions: BackupOptions),
            new TechniqueEntrySeed("资源或支持", "可以向谁或什么资源求助？", Suggestions: BackupOptions),
            new TechniqueEntrySeed("下一步", "现在可以做什么，或何时再回头处理？", Suggestions: BackupOptions)
        ],
        Theory(
            "计划可以帮你理清可行的行动，但无法控制他人的决定，也不保证让人平静。",
            "当你面对具体的实际不确定性，并想考虑一种可执行的选择时。",
            "把已知事实和担忧分开，找出一个现实的步骤、可用资源，或之后重新考虑的时间。如果计划让你反复检查所有可能性并更不安，就停下来。",
            "面试后还没有收到回复，可以选择一个合适的时间询问，同时先处理其他事情。这无法预测招聘方会如何决定。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Resize = new(
        "练习", "从远处观察画面",
        [
            "1. 简短说出一个日常情境；不必使用痛苦的回忆",
            "2. 如果感觉舒服，可以把它想象成一幅静止的画面",
            "3. 你可以调整画面的大小或距离，但不要强迫它改变"
        ],
        "一种可选的想象练习，用来观察注意力；它不会改变现实情境，也不保证带来轻松。",
        TechniqueUiKind.Entry, "技巧 #10", "22.01.2025", "从远处观察画面", "只在感觉舒服时尝试拉开距离", "问题的规模", string.Empty, 2, "ZoomOutMap",
        [new TechniqueEntrySeed("困扰你的事", "例如：让你睡不着的冲突", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem)],
        Theory(
            "这是一个简短的想象练习：你可以试着从一定距离观察画面。每个人的反应不同，现实情境本身不会因此改变。",
            "仅适用于可以应对的日常烦恼。不要选择痛苦的回忆；你也可以跳过练习。",
            "想象情境时不要补充细节。只有在感觉舒服时才调整大小或距离。如果不适加重，就停下来看看周围的房间。",
            "你可以把一项任务想象成桌上的便条，然后决定何时再处理它。画面不必变小，也不必变得平静。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Check = new(
        "练习", "转移注意力",
        [
            "1. 用一句简短的话说出反复出现的想法，不必描述细节",
            "2. 留意：“我正在有这样的想法……”",
            "3. 如果愿意，可以把注意力转向一个中性的声音或物品；想法可能仍会存在"
        ],
        "这个练习帮助你选择把注意力放在哪里；它不要求想法消失。",
        TechniqueUiKind.Entry, "技巧 #11", "22.01.2025", "转移注意力", "留意想法并选择一个中性焦点", "问题的规模", string.Empty, 2, "FactCheck",
        [new TechniqueEntrySeed("让你反复纠结的事", "哪个想法不断回来？", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem)],
        Theory(
            "这是一个简短的方法，用来留意反复出现的想法，并给注意力安排另一件事。不必压制想法，也不必追求平静。",
            "当你反复琢磨同一件事，并且愿意短暂转移注意力时可以尝试。如果想法涉及真实危险，请先处理安全问题。",
            "用一句话说出这个想法，然后选择周围一个中性的声音或物品。如果不适加重，就停下来。不要用它代替必要的医疗或实际行动。",
            "想法：“万一我生病了呢？”你可以把它当作一个想法留意，并判断是否需要采取实际步骤，例如因某个症状咨询医生。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Observer = new(
        "练习", "用旁观视角与自己对话",
        [
            "1. 用一句话说出当前情境和感受；不必描述痛苦事件的细节。",
            "2. 用自己的名字或“你”来称呼自己，而不只说“我”。例如：“[名字]，现在发生了什么？”",
            "3. 写下此刻重要的事，以及一个安全、可行的下一步。不要为伤害找借口，也不要淡化危险。",
            "4. 现在评估紧张程度。它可能减轻、保持不变或增强。如果感觉更糟，请停止并选择其他支持方式。"
        ],
        "这是一种简短的自我疏离对话：用自己的名字或“你”来称呼自己，而不只说“我”。这可能为思考留出空间，但不保证立刻缓解。",
        TechniqueUiKind.Entry, "技巧 #12", "12.06.2026", "用旁观视角与自己对话", "用名字或“你”与自己对话，再选择一个安全的下一步", "艰难时刻", "自我照护", 1, "Visibility",
        [
            new TechniqueEntrySeed("情境", "简要描述：现在发生了什么？不必讲述痛苦事件的细节。", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("第一人称的感受", "你现在有什么感受？一句话就够了。", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("观察者看到的", "用自己的名字或“你”对自己说：此刻什么最重要？一个安全的下一步是什么？", Suggestions: ["[名字]，现在什么对你最重要？", "哪一步既安全又可行？", "你怎样支持自己？", "你会对亲近的人说什么？", "等事情更清楚后再回复也可以"]),
            new TechniqueEntrySeed("现在的紧张程度", "在练习最后评估；数值可能不变。", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "自我疏离对话建议用自己的名字或“你”来称呼自己，而不只用“我”。这可能为思考留出空间，但不保证立刻缓解。",
            "当情绪或社交压力尚可承受且你身处安全环境时，可以尝试。不要用它为伤害找借口或淡化现实危险。",
            "简短地说出感受，用名字或“你”来称呼自己，并问此刻什么重要、哪一个安全的步骤可行。",
            "把“我应付不了”换成：“[名字]，现在确实很难。对你来说，下一步安全的做法是什么？”"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Anchor = new(
        "练习", "支持经历回忆",
        [
            "1. 回想一个让你感到被支持或克服困难的安全时刻",
            "2. 留意当时什么帮助了你，以及身体有什么感受",
            "3. 如果愿意，可以选一个手势，只把它当作这段回忆的提示",
            "4. 评估这段回忆现在对你的帮助程度（0 = 没有，10 = 很大）；选 0 也可以"
        ],
        "回忆可能让你想起熟悉的支持来源。每个人的反应不同；手势只是可选的提醒，不能保证改变状态。",
        TechniqueUiKind.Entry, "技巧 #13", "12.06.2026", "支持经历回忆", "回想一次获得支持的经历，留意现在可用的资源", "艰难时刻", "回忆练习", 4, "SelfImprovement",
        [
            new TechniqueEntrySeed("资源回忆", "请选择对你来说安全的回忆；如果没有合适的回忆，可以跳过练习。", Suggestions: ["一次成功的发言", "一次海边度假", "亲近的人的拥抱", "完成了一件难事", "在大自然中散步", "通过了考试", "孩子出生", "赢得比赛", "和朋友度过的夜晚", "上司的表扬", "新工作的第一天", "一个不赶时间的早晨"]),
            new TechniqueEntrySeed("身体感觉", "你在哪里感觉到？温暖、轻盈、踏实……", Suggestions: ["胸口温暖", "轻盈", "肩膀舒展", "均匀的呼吸", "双腿稳稳的", "一个微笑", "平静的心", "挺直的背", "双手有力量", "放松的腹部"]),
            new TechniqueEntrySeed("可选的回忆提示手势", "这个手势只是回忆提示；你可以跳过这一步", Suggestions: ["握拳", "触碰手腕", "拇指和食指相碰", "手放在心口", "深呼吸", "捏一下耳垂", "舒展肩膀", "抚摸手掌"]),
            new TechniqueEntrySeed("回忆带来的帮助", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "这是一个简短的回忆练习。它的效果以及手势与回忆之间的联系都没有保证。",
            "当你想起过去什么曾有帮助时。只选择让你感到安全的回忆；如果感觉更难受，请停止。",
            "留意当时什么帮助了你。手势只是可选的提示；不需要强迫自己平静下来。",
            "我想起朋友曾听我倾诉。交谈有帮助；现在我可以给对方发消息。回忆带来的帮助：5 分（满分 10 分）。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Grounding = new(
        "练习", "着陆练习 5-4-3-2-1",
        [
            "1. 说出你能看到的 5 样东西",
            "2. 说出你身体能感觉到的 4 样东西",
            "3. 说出周围的 3 种声音",
            "4. 说出 2 种气味",
            "5. 说出 1 种味道或舒服的感觉"
        ],
        "感官着陆能把注意力从焦虑的想法转到当下。",
        TechniqueUiKind.Entry, "技巧 #14", "12.06.2026", "着陆练习 5-4-3-2-1", "通过感官回到当下", "艰难时刻", "心理", 3, "Nature",
        [
            new TechniqueEntrySeed("我看到的 5 样东西", "例如：窗户、杯子、书、台灯、手", Suggestions: ["窗户", "桌子", "手机", "电脑", "笔记本电脑", "显示器", "键盘", "杯子", "台灯", "手", "门", "书", "椅子", "墙", "画", "植物", "钟", "衣柜", "天空", "汽车"]),
            new TechniqueEntrySeed("我身体感觉到的 4 样东西", "例如：椅子、地板、衣服、空气的温度", Suggestions: ["椅子", "脚下的地板", "衣服", "凉意", "温暖", "手里的手机", "椅背", "皮肤上的布料", "胸口的呼吸", "风", "鼠标", "钥匙", "枕头", "手腕上的表"]),
            new TechniqueEntrySeed("3 种声音", "例如：街道、钟表、你的呼吸", Suggestions: ["街道", "钟", "呼吸", "说话声", "冰箱", "风", "安静", "电脑", "汽车声", "鸟叫", "音乐", "空调", "脚步声", "雨声"]),
            new TechniqueEntrySeed("2 种气味", "例如：咖啡、新鲜空气", Suggestions: ["咖啡", "新鲜空气", "香皂", "食物", "香水", "几乎没有", "茶", "面包", "书", "花", "护手霜", "木头"]),
            new TechniqueEntrySeed("1 种味道或舒服的感觉", "例如：口中的水、柔软的布料", Suggestions: ["水", "茶", "柔软的布料", "温暖的手掌", "口气清新", "咖啡", "薄荷口香糖", "巧克力", "一个苹果", "温暖的毯子"])
        ],
        Theory(
            "把注意力放在周围能看到、听到和感觉到的事物上。",
            "当担忧占据注意力，而你想把注意力转向周围时。",
            "先从看到的事物开始。如果闻不到气味或尝不到味道，可以跳过。照常呼吸。",
            "我看到杯子和台灯，感觉到脚下的地板，听到窗外的车声。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Breathing = new(
        "练习", "轻柔节律呼吸",
        [
            "1. 先评估一下当前的紧张程度",
            "2. 找一个舒服的姿势。轻柔地呼吸，不要比平常吸得更深",
            "3. 如果感觉舒服，可以跟着圆圈：吸气约 4 拍，呼气约 6 拍。不要屏息",
            "4. 如果节奏不合适，就不必数拍或直接停止。若感到头晕或气短，请恢复自然呼吸",
            "5. 结束后再评估紧张程度。它可能没有变化，这也是有用的信息"
        ],
        "感到紧张时，可以尝试短暂、轻柔地调整呼吸节奏，不需要屏息。每个人的反应不同；数拍或关注呼吸有时会让不适加重。",
        TechniqueUiKind.Entry, "技巧 #15", "04.07.2026", "轻柔节律呼吸", "尝试舒适的节奏，让呼气稍长一些", "艰难时刻", "心理", 3, "Air",
        [
            new TechniqueEntrySeed("练习前的紧张程度", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("备注", "你注意到了什么？任何反应都可以。", Suggestions: ["这个节奏很舒服", "数拍让我分心", "节奏太慢了", "我有点头晕", "呼吸让我不舒服", "感觉稍微平静了一些", "紧张程度没有变化", "感觉更紧张了", "停下来后注意了周围事物"]),
            new TechniqueEntrySeed("练习后的紧张程度", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "感到紧张时，可以试着用短暂、轻柔且呼气稍长的节奏来配合呼吸。每个人的反应不同；这项练习不保证缓解不适。",
            "感到紧张，并且此时关注呼吸让你觉得舒服时。",
            "坐舒服，轻柔地呼吸，不要比平常更深。约一分钟内，如果感觉舒服，可以跟着圆圈：吸气约 4 拍、呼气约 6 拍，中间不停顿。如果觉得节奏勉强，就按自然节奏呼吸。若不适加重就停下，看看周围并在心里说出几样物品。",
            "紧张程度是 7/10。一分钟后仍是 7/10；数拍感觉勉强，所以我停下来，说出了周围五样物品。"
        ),
        null, null);

    internal static readonly BuiltInTechniqueDefinition SmallStep = new(
        "练习", "一小步",
        [
            "1. 选择一项能带来照顾自己、兴趣、联结或完成感的小活动",
            "2. 把开始缩小到安全的 2–5 分钟；不必完成整件事",
            "3. 为未来 24 小时选一个具体时间。如果现在不合适，可以选择休息、求助或更小的一步",
            "4. 评估这一步是否可行：0 — 完全没把握，10 — 很有把握。如果犹豫，就再缩小一步"
        ],
        "一个受行为激活原则启发的简短活动计划。小步骤可能帮助开始，但不保证心情变好或精力增加。",
        TechniqueUiKind.Entry, "技巧 #16", "04.07.2026", "一小步", "选择一项活动，让开始变得可行", "艰难时刻", "CBT", 5, "DirectionsWalk",
        [
            new TechniqueEntrySeed("什么让你难以开始？", "疲惫、焦虑、孤独，还是要做的事太多？", Suggestions: ["疲惫", "焦虑", "孤独", "要做的事太多", "无聊", "不知道从哪里开始", "需要休息", "现在条件不合适"], Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("为自己做的一件小事", "照顾自己、兴趣、联系他人或一个小任务", Suggestions: ["喝点水或吃点东西", "洗漱或穿好衣服", "到户外呼吸两分钟", "播放一首喜欢的歌", "给亲近的人发一条消息", "花两分钟做一件重要的事", "收好一件物品", "请人陪在身边"]),
            new TechniqueEntrySeed("你准备什么时候尝试？", "未来 24 小时内的一个具体时间", Suggestions: ["现在做两分钟", "早饭后", "午饭后", "工作或学习结束后", "今天自己选定的时间", "请亲近的人提醒我"]),
            new TechniqueEntrySeed("这一步有多可行？", "0 — 完全没把握，10 — 很有把握", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "心情低落或精力不足时，开始行动可能很困难。一个小而具体的活动计划有时能帮助恢复行动感；每个人的反应不同。",
            "当低落或缺乏精力让你难以开始，且有安全、可行的活动时。休息或寻求帮助也可以是合适的一步。",
            "选择照顾自己、兴趣、联系他人或带来完成感的活动；把开始缩小到 2–5 分钟，并安排在未来 24 小时内。计划不等于已经完成。如果觉得做不到，就再缩小一步或寻求支持。",
            "不必“打扫整个房间”，可以午饭后洗一个杯子；或者给亲近的人发消息：“有空聊一分钟吗？”"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition ThoughtRecord = new(
        "练习", "想法记录",
        [
            "1. 不作评价地描述情境",
            "2. 写下自动想法",
            "3. 说出感受并评估此刻强度",
            "4. 区分事实和推测，寻找另一种可能",
            "5. 再次评估感受；它可能没有变化"
        ],
        "区分情境、想法和感受，再用事实检查结论。感受不必因此减轻。",
        TechniqueUiKind.Entry, "技巧 #17", "04.07.2026", "想法记录", "区分事实与解读", "艰难时刻", "CBT", 7, "EditNote",
        [
            new TechniqueEntrySeed("情境", "发生了什么？在哪里、什么时候？只写必要内容。", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("自动想法", "那一刻你在想什么？", Suggestions: HarshThoughts),
            new TechniqueEntrySeed("记录前的感受", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("更准确的看法", "哪些事实支持或反驳它？还有什么可能？", Role: EntryFieldRole.Reframe),
            new TechniqueEntrySeed("记录后的感受", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "这个练习把事件和你对它的解读区分开。它不是诊断或治疗。",
            "如果你现在有精力书写，可用于程度较轻的日常烦心事。不要选择创伤性回忆或急性危机。",
            "先写可观察到的事实，再写想法。寻找同时考虑已知事实和未知信息的解释；不要强迫自己积极思考。评分没有变化，不代表你做错了。",
            "情境：消息暂时没有回复。想法：“没有人需要我。”事实：目前还没有回复。另一种可能：原因未知，对方可能正忙。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition SelfCompassion = new(
        "练习", "对自己说温和的话",
        [
            "1. 写下你在为什么批评自己",
            "2. 想象一位好朋友这样说——你会怎么对他说？",
            "3. 对自己说同样支持的话",
            "4. 评估温暖或释然的程度"
        ],
        "自我关怀能减少严厉的自我批评，帮助你在犯错后恢复。",
        TechniqueUiKind.Entry, "技巧 #18", "04.07.2026", "对自己说温和的话", "用支持缓和自我批评", "艰难时刻", "CBT", 5, "Favorite",
        [
            new TechniqueEntrySeed("你批评自己的地方", "你对自己说什么，或者在责怪自己什么？", Suggestions: ["工作上出了错", "没做完", "对亲近的人发了脾气", "拿自己和别人比", "又在拖延", "我的外貌", "我的体重", "说错了话", "不是一个足够好的父母", "挣得太少", "没有遵守承诺", "太敏感"]),
            new TechniqueEntrySeed("你会对朋友说的话", "在这种情况下，你会怎样支持亲近的人？", Role: EntryFieldRole.Kindness),
            new TechniqueEntrySeed("对自己说的话", "同样的善意，送给你自己", Role: EntryFieldRole.SelfKindness),
            new TechniqueEntrySeed("温暖 / 释然", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "自我批评很少能激励人——它更常助长羞耻和停滞。自我关怀并不免除责任，而是给予支持。",
            "在犯错之后、和别人比较时，或觉得自己不够好时。",
            "写下批评，然后像回应朋友那样回应自己——带着尊重，不轻描淡写。",
            "批评：我又把一切搞砸了。对朋友：你努力过了，这可以弥补。对自己：我可以从中学到东西。温暖：3 → 6。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition BodyScan = new(
        "练习", "它在身体的哪里？",
        [
            "1. 评估你现在的紧张程度",
            "2. 把注意力从头到脚慢慢扫过身体",
            "3. 找到感觉最强烈的地方",
            "4. 描述它：是什么样的，大还是小，暖还是冷",
            "5. 说出伴随它的情绪",
            "6. 如果你愿意，可以留意哪些感觉变了、哪些保持不变。你随时可以停止练习，或把注意力转向周围环境。"
        ],
        "身体扫描邀请你留意身体感觉和情绪，不必试图改变它们。",
        TechniqueUiKind.Entry, "技巧 #19", "16.10.2026", "它在身体的哪里？", "留意身体感觉，不必试图改变它们", "艰难时刻", "正念", 4, "Accessibility",
        [
            new TechniqueEntrySeed("现在的紧张程度", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("你在身体的哪里感觉到它？", "例如：胸口、喉咙、肩膀", Suggestions: ["头", "额头", "眼睛", "下巴", "喉咙", "脖子", "肩膀", "胸口", "心脏", "腹部", "背", "腰", "手臂", "双手", "腿", "全身"]),
            new TechniqueEntrySeed("是什么样的感觉？", "例如：紧绷、沉重、哽住", Suggestions: ["紧绷", "沉重", "哽住", "压迫感", "紧张", "发热", "发冷", "颤抖", "刺麻", "跳痛", "空虚", "麻木", "疼痛", "难以描述"]),
            new TechniqueEntrySeed("伴随的是什么情绪？", "例如：焦虑、委屈、疲惫", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("练习后的紧张程度", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "身体扫描可以帮助你留意身体感觉，以及可能伴随的情绪。留意这些感觉并不一定会减轻紧张；它也可能保持不变。这类练习会用于一些正念课程中。",
            "当你感到焦虑或沉重，却说不清到底是什么感受时；当一次艰难的谈话或一天之后身体紧绷时。这个练习不解释疾病，也不能代替医生：如果某种感觉是新出现的、强烈的或一直不消退，请去看医生。",
            "如果这样让你感觉舒服，可以坐好，把注意力慢慢移到身体的不同部位。尽可能具体地描述一种感觉；如果合适，也可以说出伴随的情绪。你不必改变任何东西。如果向内关注让你不舒服，请睁开眼睛，看看周围的物品，或结束练习。保持自然呼吸。",
            "紧张程度 6/10。位置：胸口。感觉：紧绷。情绪：谈话前的焦虑。之后紧张程度仍为 6/10。我睁开眼睛，说出周围的物品。这也是有效的结果。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Flashback = new(
        "练习", "被一段记忆淹没了",
        [
            "1. 评估它有多强烈",
            "2. 告诉自己：“这是回忆。那是过去，现在是今天”",
            "3. 说出你在哪里，现在是一天中的什么时候",
            "4. 感受脚下的支撑，握紧拳头再松开",
            "5. 说出你看到的三样东西",
            "6. 慢慢呼气五次，用冷水，然后再次评估"
        ],
        "闪回时的帮助：通过时间、地点、身体和感官，从回忆回到当下。",
        TechniqueUiKind.Entry, "技巧 #20", "16.10.2026", "被一段记忆淹没了", "当痛苦的记忆占据你时，回到当下", "艰难时刻", "创伤", 3, "MyLocation",
        [
            new TechniqueEntrySeed("有多强烈", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("你在哪里，现在是什么时候", "例如：在家，晚上", Suggestions: ["在家", "在工作", "在外面", "在交通工具上", "在别人家", "早上", "下午", "晚上", "夜里"]),
            new TechniqueEntrySeed("你看到的三样东西", "例如：窗户、杯子、台灯", Suggestions: ["窗户", "桌子", "手机", "杯子", "台灯", "门", "椅子", "墙", "画", "植物", "钟", "天空"]),
            new TechniqueEntrySeed("现在有多强烈", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "闪回是一种创伤记忆，经历时就像事情又在发生一样：带着同样的情绪和身体反应。大脑把“过去”和“现在”混在了一起。时间、地点、身体的支撑以及你看到和听到的东西，能帮助你回到当下。",
            "当痛苦事件的记忆占据你，画面闪现，感觉“我又回到了那里”时。频繁的闪回是创伤后反应的常见迹象，在创伤专业人士的治疗下效果很好。",
            "不要试图处理这段记忆：现在唯一的任务就是回来。告诉自己你在哪里、今天是几号，双脚用力踩地，说出你看到的东西，慢慢呼气，借助冷的东西。",
            "强度 8。“那是过去；现在是 2026 年，我在家，是晚上。”双脚踩在地上；我看到窗户、杯子、台灯。冷水。现在 4。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Nightmare = new(
        "练习", "改写噩梦",
        [
            "1. 选一个反复出现的噩梦，开始时不要选最难的",
            "2. 简短描述，不写令人难受的细节",
            "3. 决定要改变什么：结局、地点、你自己、身边的人",
            "4. 完整写下新版本的梦，直到平静的结局",
            "5. 每天花 10 到 20 分钟，详细想象新版本",
            "6. 一两周后，看看噩梦有什么变化"
        ],
        "意象排练：在清醒时改写反复出现的噩梦，大脑会开始梦到新版本。",
        TechniqueUiKind.Entry, "技巧 #21", "16.10.2026", "改写噩梦", "让反复出现的噩梦变少、变弱", "睡眠", "创伤", 15, "NightsStay",
        [
            new TechniqueEntrySeed("这个噩梦有多难受", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("噩梦的内容，简单说", "一两句话，不写令人难受的细节", Suggestions: ["有人在追我", "我逃不掉", "我又回到了那个可怕的地方", "我失去了亲近的人", "我喊不出来", "我在坠落", "我被攻击", "我迟到了，赶不上"]),
            new TechniqueEntrySeed("你要改变的", "想改什么都行：这是你的梦", Suggestions: ["结局", "地点", "我变得更强大", "有人来帮忙", "我能说话、能喊", "危险消失了", "一切变得安全", "我意识到这是梦"]),
            new TechniqueEntrySeed("新版本的梦", "从开头到平静的结局，完整描述", Suggestions: ["我意识到这是梦", "出现了保护我的人", "我到了一个安全的地方", "我平静地离开", "一切都结束得很好"]),
            new TechniqueEntrySeed("什么时候排练新版本", "每天 10 到 20 分钟", Suggestions: ["早上", "白天，休息的时候", "晚上，睡前两小时左右", "每天同一时间"]),
            new TechniqueEntrySeed("现在有多难受", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "创伤或压力后反复出现的噩梦，是靠习惯维持的：大脑一遍遍播放同样的情节。在意象排练疗法中，人在清醒时改写情节，并每天在脑中排练新版本。研究表明，这能让噩梦变少、变弱，睡眠变好。",
            "适用于让你害怕入睡的反复噩梦。如果噩梦直接重现了创伤，哪怕简短描述都会带来强烈恐惧，请和创伤专业人士一起做这个练习。",
            "从一个较轻的噩梦开始。不要详细写出可怕的部分：几句话就够了。随你喜欢去改变梦；新版本不必符合现实。白天排练，不要在临睡前，每天 10 到 20 分钟。",
            "噩梦：有人在追我，我逃不掉。改变：我意识到这是梦，转过身，那只是一个影子；我平静地走回家。我每天下午排练一次。两周后，这个噩梦出现得少了。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Balloons = new(
        "练习", "戳气球",
        [
            "1. 先评估当前的紧张程度",
            "2. 开始这一轮，按自己的节奏点击气球；不必戳中每一个",
            "3. 像平常一样呼吸，不必让呼气配合每一次气球爆开",
            "4. 这一轮会自动结束。如果游戏让你烦躁或感觉更糟，就返回上一页",
            "5. 再评估紧张程度，并记下观察到的情况。没有变化也是一种结果"
        ],
        "一个让双手和注意力短暂投入的小游戏。它可能暂时转移注意力，但不一定改变感受，也不能替代实际行动或支持。",
        TechniqueUiKind.Entry, "技巧 #22", "26.10.2026", "戳气球", "可选的短暂游戏暂停", "艰难时刻", "心理", 3, "BubbleChart",
        [
            new TechniqueEntrySeed("之前的紧张程度", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("笔记", "你注意到了什么？可以留空。", Suggestions: ["紧张稍有减轻", "没有明显变化", "更紧张了", "注意力短暂转移", "注意到了颜色或移动", "游戏让我烦躁", "不确定", "其他"]),
            new TechniqueEntrySeed("之后的紧张程度", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "简短的游戏可能暂时占用双手和注意力；每个人的反应不同。它不能保证减轻焦虑，也不是治疗。",
            "当你觉得短暂玩一会儿合适时。不要为了玩游戏而推迟紧急的健康或安全行动。",
            "按自己的节奏点击；不必戳中每个气球。正常呼吸，不必让呼吸配合每一次爆开。结束后如实比较前后的评分，不必期待某种结果。如果有实际问题需要处理，准备好后再回到下一步。",
            "争吵后我的紧张程度是 7/10。游戏结束后仍是 7/10；我注意到自己还在生气，于是决定等平静些再回复。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition CyclicSigh = new(
        "练习", "循环叹息呼吸",
        [
            "1. 给紧张程度打分",
            "2. 用鼻子吸气，吸满后再短短地补吸一口",
            "3. 用嘴慢慢呼气，呼气比吸气更长",
            "4. 跟着圆圈的节奏呼吸约三分钟",
            "5. 再给紧张程度打分"
        ],
        "两次轻柔吸气后接一次较长的呼气，形成一个呼吸节奏。不需要屏气，也不必比平时吸得更深。",
        TechniqueUiKind.Entry, "技巧 #23", "26.10.2026", "循环叹息呼吸", "两次吸气、一次长呼气，让身体平静下来", "艰难时刻", "心理", 3, "Air",
        [
            new TechniqueEntrySeed("之前的紧张程度", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("笔记", "你注意到了什么？", Suggestions: ["稍微平静一些", "没有明显变化", "感觉更不舒服", "有点头晕", "不想评价", "其他"]),
            new TechniqueEntrySeed("之后的紧张程度", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "一项有111名参与者的随机研究中，参与者连续一个月每天练习五分钟循环叹息。该组的积极情绪评分提升幅度大于正念冥想组。这并不能证明只练一次就能迅速减轻紧张，也不代表每个人都会有相同反应。",
            "如果关注呼吸让你觉得舒服，可以尝试一下，例如在谈话前或短暂休息时。如果这样让你更不舒服，就选一个关注周围环境的练习。",
            "轻柔呼吸，不必尽可能深吸。只在感觉舒服时重复这个节奏。如果头晕或不适，请停止练习，坐稳并恢复平常的呼吸。如果症状严重或持续不退，请寻求医疗建议。",
            "打电话前，我注意到自己有些紧张，试着做几个轻柔的循环。如果没有变化或感觉更不舒服，就停下来，恢复平常的呼吸。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition MuscleRelax = new(
        "练习", "绷紧再放松",
        [
            "1. 给紧张程度打分",
            "2. 把一组肌肉绷紧五秒，大约用一半的力气",
            "3. 放松，用十五秒感受放松的感觉",
            "4. 依次做五组：双手、肩膀、面部、腹部、双腿",
            "5. 再给紧张程度打分"
        ],
        "先绷紧肌肉再放松，身体更容易体会到什么是放松。",
        TechniqueUiKind.Entry, "技巧 #24", "26.10.2026", "绷紧再放松", "给紧绷身体的简短肌肉放松", "艰难时刻", "心理", 4, "SelfImprovement",
        [
            new TechniqueEntrySeed("之前的紧张程度", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("笔记", "身体哪些地方变轻松了？", Suggestions: ["肩膀放松了", "下巴松开了", "手变暖了", "呼吸更顺畅了", "有点困了", "还有些地方紧", "没什么变化"]),
            new TechniqueEntrySeed("之后的紧张程度", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "渐进式肌肉放松是研究最充分的缓解焦虑和紧张的方法之一。先绷紧肌肉再放松，这种对比能帮你察觉放松的感觉，并逐渐学会主动让自己放松。这不是治疗，而是一项越练越有效的技能。",
            "当身体因压力而紧绷、坐不住或睡不着时。很适合在晚上睡前做。",
            "大约用一半的力气，不要用到疼。如果身体某处疼痛或受过伤，不要绷紧它，只需留意它。放松时平静地呼吸，不要急着做下一组。",
            "下班后的晚上紧张程度 7/10，肩膀耸到耳边。做了五组：双手、肩膀、面部、腹部、双腿。紧张程度 4/10，肩膀放下来了。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition BusyMind = new(
        "练习", "短暂转移注意力",
        [
            "1. 只有在有帮助时才评估当前紧张程度",
            "2. 选择一个中性的任务，做约 30–60 秒",
            "3. 如果注意力又回到担忧上，不要责怪自己；可以轻轻回到任务一次",
            "4. 停下来看看是否需要采取实际行动或寻求支持"
        ],
        "当念头似乎卡住时，一个简短、中性的任务有时能让注意力暂时转移。它不会消除念头，也不能解决问题。",
        TechniqueUiKind.Entry, "技巧 #25", "26.10.2026", "短暂转移注意力", "念头反复时的临时暂停", "艰难时刻", "心理", 1, "Extension",
        [
            new TechniqueEntrySeed("之前的紧张程度", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("笔记", "这次短暂停顿感觉如何？", Suggestions: ["注意力暂时转移了", "没有变化", "我更烦躁或紧张了", "我现在看到了下一步", "我需要支持", "我停止了练习"]),
            new TechniqueEntrySeed("之后的紧张程度", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "一个简短的中性任务——例如说出身边同一种颜色的物品——有时能帮助度过紧张时刻。这只是暂时转移注意力，不会消除念头；效果因人因时而异。",
            "当反复出现的念头占据注意力，而你想短暂停一下时。如果有紧急问题或安全、健康方面的需要，请先处理并寻求合适的帮助。",
            "选择一个简单任务，做 30–60 秒；不必要求自己完美专注。之后看看是否有实际的下一步。如果任务让你烦躁或感觉更糟，就停下来换一种方式。",
            "争吵后，对话还在脑海里反复出现。用半分钟说出身边五件物品，然后决定是核实一件事、休息一下，还是寻求支持。"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition ThoughtDefusion = new(
        "练习", "与念头拉开距离",
        [
            "1. 留意一个简短的念头；是否写下来由你决定",
            "2. 对自己说：“我注意到自己有这样的念头……”",
            "3. 看看面前的一件物品，感受双脚下方的支撑",
            "4. 选择一个很小的下一步，或在这里结束"
        ],
        "这是接纳与承诺疗法（ACT）中的一个简短练习：把念头看作头脑正在进行的活动，而不一定是事实或命令。",
        TechniqueUiKind.Entry, "技巧 #26", "03.11.2026", "与念头拉开距离", "用一个简短练习，与令人担忧的念头拉开距离", "念头", "心理", 1, "FormatQuote",
        [
            new TechniqueEntrySeed("念头", "可选：你也可以默默完成练习", Suggestions: HarshThoughts)
        ],
        Theory(
            "反复出现的念头可能占据全部注意力。在 ACT 中，认知解离是留意这个念头，而不与它争辩，也不试图把它赶走。",
            "当某个担忧、自我批评或恐惧反复出现时。无需选择令人痛苦的回忆。",
            "不必写下任何内容。在念头前加上“我注意到自己有这样的念头……”，看一件物品，并感受双脚下方的支撑。如果不适加重，请停止并说出周围几件物品。",
            "把“我会把一切搞砸”改成“我注意到自己有‘我会把一切搞砸’这个念头”。然后看看面前的杯子，再决定回复一封邮件或先暂停一下。"),
        null, null);
}
