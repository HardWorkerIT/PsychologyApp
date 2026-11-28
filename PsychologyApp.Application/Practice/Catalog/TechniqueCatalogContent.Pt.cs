using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice.Catalog;

internal static class TechniqueCatalogContentPt
{
    internal static TheorySection[] Theory(string what, string when, string how, string example) =>
    [
        new("O que é", what),
        new("Quando experimentar", when),
        new("Como é a prática", how),
        new("Exemplo", example)
    ];

    /// <summary>Common topics for a "problem" field: a start to tap and then add a word or two, not a full answer.</summary>
    private static readonly string[] ProblemTopics =
        ["Uma briga com alguém próximo", "Algo no trabalho", "Um conflito com meu chefe", "Os estudos ou uma prova", "A saúde", "Dinheiro", "A solidão", "Um fracasso", "Um término", "A relação com meus pais", "Os filhos", "Uma mudança de casa", "O futuro", "Críticas a mim"];

    private static readonly string[] BackupOptions =
        ["Pedir ajuda", "Esperar e tentar de novo", "Encontrar outro caminho", "Cobrar menos de mim", "Fazer uma pausa", "Conversar com alguém próximo", "Procurar um especialista", "Arrumar um trabalho extra", "Fazer um curso", "Dividir a tarefa em etapas", "Adiar a decisão", "Começar pequeno"];

    private static readonly string[] HarshThoughts =
        ["\"Vou estragar tudo\"", "\"Vão me julgar\"", "\"Não dou conta\"", "\"Ninguém precisa de mim\"", "\"É um desastre\"", "\"Nada vai dar certo\"", "\"Sou pior que os outros\"", "\"Tudo sempre dá errado\"", "\"A culpa é minha\"", "\"Tem algo errado comigo\"", "\"Isso nunca vai acabar\"", "\"Tenho que ser perfeito\""];

    internal static readonly BuiltInTechniqueDefinition Spin = new(
        "Prática", "Nomear o que estou sentindo",
        [
            "1. Escolha uma situação cotidiana recente que tenha incomodado um pouco",
            "2. Dê nome ao sentimento principal",
            "3. Avalie a intensidade agora, de 0 a 10"
        ],
        "Anote brevemente a situação e o sentimento, sem esperar alívio imediato.",
        TechniqueUiKind.Entry, "Técnica nº 1", "26.01.2023", "Nomear o que estou sentindo", "Perceba o que acontece agora", "Momento difícil", "Equipe PsychologyApp", 5, "Autorenew",
        [
            new TechniqueEntrySeed("Situação", "Por exemplo: um pequeno problema no trabalho. Evite detalhes dolorosos.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Sentimento principal", "Mágoa, preocupação, raiva…", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("Intensidade agora", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Anote a situação, o sentimento e a intensidade agora. É uma observação pessoal, não um tratamento nem uma promessa de mudança imediata.",
            "Para uma situação cotidiana moderadamente incômoda, se você se sentir à vontade para escrever sobre ela. Não escolha uma lembrança traumática nem uma crise aguda.",
            "Descreva apenas o necessário e avalie o sentimento agora. Se o desconforto aumentar, pare, olhe ao redor e escolha uma prática mais neutra. Não é preciso repetir.",
            "Situação: um colega me interrompeu. Sentimento: irritação. Intensidade agora: 5 de 10."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Comparison = new(
        "Prática", "Ampliar a perspectiva",
        [
            "1. Nomeie o que está difícil agora, sem minimizar",
            "2. Quais áreas da sua vida isso afeta?",
            "3. O que mais importa ou também precisa de atenção?",
            "4. De quem ou do que você gostaria de cuidar hoje?",
            "5. Anote o que percebeu, sem classificar o problema como pequeno ou grande"
        ],
        "Este exercício ajuda a nomear diferentes áreas da vida; não determina a gravidade de um problema.",
        TechniqueUiKind.Entry, "Técnica nº 2", "26.01.2023", "Ampliar a perspectiva", "Quando uma dificuldade ocupa toda a sua atenção", "Tamanho do problema", string.Empty, 7, "CompareArrows",
        [
            new TechniqueEntrySeed("O que está acontecendo", "O que está difícil agora?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Áreas afetadas", "Ex.: trabalho, saúde, relacionamentos", Suggestions: ["O trabalho", "A família", "Os amigos", "A saúde", "Os estudos", "Dinheiro", "Os relacionamentos", "O sono", "A casa", "Os hobbies", "O descanso", "Os planos"]),
            new TechniqueEntrySeed("O que mais importa", "O que também precisa de atenção?", Suggestions: ["O trabalho", "A família", "A saúde", "Os relacionamentos", "O descanso", "Os filhos", "Os amigos", "Os estudos", "O sono", "Paz de espírito", "Crescimento pessoal", "Tarefas do dia a dia"]),
            new TechniqueEntrySeed("Do que cuidar", "Quem ou o que precisa da sua atenção hoje?", Suggestions: ["A saúde", "Pessoas próximas", "O sono", "O descanso", "Uma questão de trabalho", "Uma conversa", "Uma tarefa diária", "Meus limites", "Ainda não sei"]),
            new TechniqueEntrySeed("O que você percebe", "Não é preciso chegar a uma conclusão positiva")
        ],
        Theory(
            "O exercício ajuda a nomear outras necessidades e tarefas sem diminuir a importância da dificuldade.",
            "Quando um assunto ocupa quase toda a sua atenção e você quer reconhecer outras necessidades ou tarefas.",
            "Escreva com suas palavras e não procure uma conclusão positiva obrigatória. Se houver uma ação prática ou questão de segurança, priorize-a. Você pode deixar campos em branco.",
            "Procurar trabalho afeta o dinheiro e o sono; hoje também quero cuidar de alguém próximo. Talvez eu escolha uma etapa da busca e peça apoio. Isso não torna a preocupação menos séria."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Polarity = new(
        "Prática", "Polaridades",
        [
            "1. Escreva o que você gosta na situação",
            "2. Escreva o que você não gosta",
            "3. Compare os pares e perceba o equilíbrio"
        ],
        "O método das polaridades ajuda a ver os dois lados e a reduzir a tensão interna.",
        TechniqueUiKind.Polarity, "Técnica nº 3", "26.01.2023", "Polaridades", "Ver os dois lados de uma situação", "Lados diferentes", "Zivorad Slavinski", 5, "Contrast",
        null,
        Theory(
            "Toda situação tem lados agradáveis e desagradáveis. Nomear os dois reduz a fixação em um só.",
            "Quando você só vê o negativo ou só o positivo e se sente travado.",
            "Adicione pares de \"gosto / não gosto\" sobre um tema. Compare as listas sem julgar o que é certo.",
            "Trabalho: gosto do salário, não gosto do horário. Casa: gosto do aconchego, não gosto do barulho dos vizinhos."),
        "O que você não gosta", "O que você gosta");

    internal static readonly BuiltInTechniqueDefinition Paper = new(
        "Prática", "Um pensamento no papel",
        [
            "1. Escreva um pensamento abaixo ou em uma folha",
            "2. Leia uma vez e nomeie o sentimento, se quiser",
            "3. Escolha o que fazer com a folha: guardar, dobrar ou rasgar. Também pode não fazer nada"
        ],
        "Escrever ajuda a notar como o pensamento está formulado; não é preciso destruir a folha nem esperar alívio.",
        TechniqueUiKind.Paper, "Técnica nº 4", "26.01.2023", "Um pensamento no papel", "Quando um pensamento volta sempre", "Pensamentos", "Equipe PsychologyApp", 3, "Description",
        [new TechniqueEntrySeed("Pensamento", "Por exemplo: “Vou estragar a apresentação.”", Suggestions: HarshThoughts)],
        Theory(
            "Você escreve um pensamento para observar como ele está formulado. É auto-observação, não tratamento nem garantia de mudança no sentimento.",
            "Quando um pensamento se repete e você se sente à vontade para escrevê-lo. Pare se isso piorar seu desconforto.",
            "Escreva uma frase e leia uma vez. Guardar, deixar de lado ou rasgar a folha é uma escolha sua. Você não precisa se obrigar a ficar calmo.",
            "Pensamento: “Vou estragar a apresentação.” Você pode guardar a anotação e conferir um slide."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Future = new(
        "Prática", "Olhar a partir do futuro",
        [
            "1. Escolha uma dificuldade cotidiana que você consiga manejar",
            "2. Imagine olhar para ela a partir do prazo que escolher — por exemplo, daqui a um ou cinco anos"
        ],
        "Avalie a situação com uma distância no tempo. Ela pode continuar importante; não é preciso diminuí-la.",
        TechniqueUiKind.Entry, "Técnica nº 5", "30.01.2023", "Olhar a partir do futuro", "Teste outra perspectiva sem desvalorizar a situação", "Tamanho do problema", "Equipe PsychologyApp", 2, "Schedule",
        [
            new TechniqueEntrySeed("Situação", "Por exemplo: uma dificuldade administrável no trabalho.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Qual a importância vista dessa distância?", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "A perspectiva temporal é uma forma imaginada de olhar para uma situação. A importância pode continuar igual, e tudo bem.",
            "Para uma dificuldade cotidiana administrável. Não escolha uma lembrança traumática ou um problema urgente que exija ação.",
            "Escolha um prazo, como um ou cinco anos. Imagine olhar a situação a partir dali e dê uma nota. Não há resposta certa; pare se o exercício não fizer sentido.",
            "Não receber resposta a um convite ainda pode importar daqui a um ano. Hoje, você pode perguntar ou escolher outro próximo passo."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Hack = new(
        "Prática", "Pausa com detalhes ao redor",
        [
            "1. Escolha um objeto neutro próximo, sem voltar a uma lembrança dolorosa",
            "2. Nomeie três detalhes: cor, forma e superfície",
            "3. Decida se quer continuar ou parar"
        ],
        "Uma breve orientação para um objeto próximo, sem reviver um acontecimento doloroso.",
        TechniqueUiKind.Entry, "Técnica nº 6", "30.01.2023", "Pausa com detalhes ao redor", "Volte a atenção para o ambiente", "Momento difícil", "Equipe PsychologyApp", 3, "BlurOn",
        [new TechniqueEntrySeed("Objeto próximo", "Por exemplo: uma xícara, uma janela ou um livro.", Role: EntryFieldRole.None)],
        Theory(
            "Volte a atenção para um objeto neutro, aqui e agora. É um breve exercício de orientação, não um tratamento nem um substituto para apoio profissional.",
            "Quando quiser se concentrar por um instante no que está ao redor. Não use a prática no lugar de ajuda urgente.",
            "Nomeie três detalhes do objeto. Se você se sentir pior ou desconfortável, pare, olhe ao redor e escolha outra ação.",
            "Por exemplo: uma xícara — branca, redonda e fria ao toque."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Experience = new(
        "Prática", "Modificação da experiência",
        [
            "1. Escolha uma área para trabalhar",
            "2. Descreva sua atitude em relação a ela",
            "3. Diga quais crenças estão ligadas a ela",
            "4. Como a atitude muda quando você pensa em experiências passadas?",
            "5. Descreva uma experiência negativa",
            "6. Avalie a experiência negativa (−10…10)",
            "7. Que experiência positiva poderia substituí-la?",
            "8. Como sua atitude mudaria com essa experiência?",
            "9. Avalie a nova experiência (−10…10)"
        ],
        "A EMO ajuda a substituir uma experiência limitante por outra que apoie mais.",
        TechniqueUiKind.Entry, "Técnica nº 7", "08.02.2023", "Modificação da experiência", "Reescrever uma experiência limitante", "Momento difícil", "Filip Slavinski", 15, "Psychology",
        [
            new TechniqueEntrySeed("Área", "Relacionamentos, trabalho, saúde…", Suggestions: ["Os relacionamentos", "O trabalho", "A saúde", "Dinheiro", "Falar em público", "A família", "Os estudos", "A aparência", "A amizade", "A criatividade", "O esporte", "A carreira"]),
            new TechniqueEntrySeed("Atitude em relação à área", "Como você se sente em relação a isso agora?", Suggestions: ["Ansiedade", "Insegurança", "Irritação", "Indiferença", "Interesse", "Cansaço", "Medo", "Vergonha", "Esperança", "Raiva", "Confusão", "Calma"]),
            new TechniqueEntrySeed("Crenças ligadas", "Ex.: \"Não vou conseguir\"", Suggestions: ["\"Não vou conseguir\"", "\"Não sou bom o bastante\"", "\"Não vão me aceitar\"", "\"Nada vai mudar\"", "\"Tenho que ser perfeito\"", "\"Não tenho sorte\"", "\"Não mereço\"", "\"Os outros são melhores\"", "\"Errar não é permitido\"", "\"Estou velho demais para isso\""]),
            new TechniqueEntrySeed("Atitude e experiência passada", "O que muda quando você lembra do passado?", Suggestions: ["Fica mais pesado", "Fica mais calmo", "Nada muda", "Vem a raiva", "Vem a tristeza", "Vem o medo", "Lembro que dei conta", "Quero evitar"]),
            new TechniqueEntrySeed("Experiência negativa", "Um episódio específico ou um padrão"),
            new TechniqueEntrySeed("Nota da experiência negativa", "", EntryFieldKind.RatingNeg10To10),
            new TechniqueEntrySeed("Substituição positiva", "Que experiência de apoio é possível?", Suggestions: ["Uma vez em que consegui", "Uma vez em que me apoiaram", "Uma vez em que dei conta sozinho", "Uma vez em que me elogiaram", "Uma vez em que ajudei alguém", "Uma vez em que aprendi algo novo", "Uma vez em que não desisti", "Uma vez em que me aceitaram como sou"]),
            new TechniqueEntrySeed("Atitude com o positivo", "Como mudaria seu olhar sobre a área?", Suggestions: ["Surge esperança", "Mais calma", "Quero tentar de novo", "Fica interessante", "Surge confiança", "Fica mais leve", "Sinto força", "Ainda é difícil acreditar"]),
            new TechniqueEntrySeed("Nota da nova experiência", "", EntryFieldKind.RatingNeg10To10)
        ],
        Theory(
            "As crenças muitas vezes se apoiam em uma única experiência negativa marcante. Substituí-la de forma consciente pode mudar sua atitude.",
            "Quando \"sempre foi assim\" e a mudança parece impossível.",
            "Preencha os campos em ordem. Compare as duas notas — a ideia é que a segunda seja maior.",
            "Área: falar em público. Negativa: uma prova em que fui mal (−8). Substituição: uma boa apresentação (+6)."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Copied = new(
        "Prática", "Observe o pensamento",
        [
            "1. Escreva uma frase curta que volta sempre",
            "2. Leia uma vez e pergunte: é um fato, uma previsão ou uma avaliação?",
            "3. Se for confortável, confira um fato. Pare se o desconforto aumentar"
        ],
        "Este exercício ajuda a observar como um pensamento é formulado; repetir não garante que a ansiedade diminua.",
        TechniqueUiKind.Copied, "Técnica nº 8", "21.01.2025", "Observe o pensamento", "Nomeie uma frase ansiosa sem discutir consigo", "Tamanho do problema", string.Empty, 2, "Repeat",
        [new TechniqueEntrySeed("Frase", "Tenho medo de perder meu emprego", Suggestions: HarshThoughts)],
        Theory(
            "Esta é uma forma breve de observar as palavras de um pensamento e verificar em que ele se baseia. Você não precisa dizê-lo em voz alta nem repeti-lo.",
            "Quando uma frase volta com frequência e você quer observá-la por um momento. Pule o exercício se o pensamento parecer pesado demais agora.",
            "Escreva o pensamento em poucas palavras. Pergunte-se o que você sabe com certeza e o que é previsão. Não se obrigue a acreditar em uma resposta. Pare se o desconforto aumentar.",
            "Pensamento: \"Vou fracassar na reunião, com certeza.\" Fato: \"Tenho uma reunião amanhã.\" O resultado ainda é desconhecido."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Extend = new(
        "Prática", "Planejar para lidar com a incerteza",
        [
            "1. Nomeie a situação para a qual você quer uma alternativa",
            "2. Anote uma opção realista e os recursos disponíveis",
            "3. Escolha o próximo passo ou quando retomar o plano"
        ],
        "Planejar pode esclarecer ações disponíveis; não garante um resultado nem alívio imediato.",
        TechniqueUiKind.Entry, "Técnica nº 9", "21.01.2025", "Planejar para lidar com a incerteza", "Encontrar um próximo passo prático", "Tamanho do problema", string.Empty, 3, "Backup",
        [
            new TechniqueEntrySeed("Situação", "O que pode não sair como planejado?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Opção prática", "Ex.: confirmar um prazo ou pedir ajuda", Suggestions: BackupOptions),
            new TechniqueEntrySeed("Recurso ou apoio", "A quem ou a que você pode recorrer?", Suggestions: BackupOptions),
            new TechniqueEntrySeed("Próximo passo", "O que pode fazer agora ou quando retomar o assunto?", Suggestions: BackupOptions)
        ],
        Theory(
            "Planejar pode esclarecer ações possíveis, mas não controla as decisões de outras pessoas nem garante calma.",
            "Quando há uma incerteza prática específica e você quer considerar uma opção possível.",
            "Separe fatos conhecidos de preocupações. Identifique um passo realista, um recurso ou um momento para voltar ao assunto. Se o planejamento virar uma revisão repetida de todos os cenários e aumentar o desconforto, pare.",
            "Se não houver resposta após uma entrevista, você pode escolher um momento razoável para perguntar e se dedicar a outras tarefas enquanto isso. Isso não prevê a decisão da empresa."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Resize = new(
        "Prática", "Observe a imagem à distância",
        [
            "1. Nomeie brevemente uma situação cotidiana; não precisa usar lembranças dolorosas",
            "2. Se for confortável, imagine-a como uma imagem parada",
            "3. Você pode mudar o tamanho ou a distância, sem forçar a imagem a mudar"
        ],
        "Uma visualização opcional para observar a atenção; ela não muda a situação nem promete alívio.",
        TechniqueUiKind.Entry, "Técnica nº 10", "22.01.2025", "Observe a imagem à distância", "Experimente a distância apenas se for confortável", "Tamanho do problema", string.Empty, 2, "ZoomOutMap",
        [new TechniqueEntrySeed("O que incomoda você", "Ex.: um conflito que tira seu sono", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem)],
        Theory(
            "Este é um breve exercício de imaginação: você pode observar uma imagem à distância. Cada pessoa reage de um jeito, e a situação em si não muda por isso.",
            "Apenas para uma preocupação cotidiana manejável. Não escolha uma lembrança dolorosa; você pode pular o exercício.",
            "Imagine a situação sem acrescentar detalhes. Mude o tamanho ou a distância apenas se for confortável. Se o desconforto aumentar, pare e observe o ambiente ao redor.",
            "Você pode imaginar uma tarefa como um bilhete sobre a mesa e decidir quando voltar a ela. A imagem não precisa ficar menor ou mais calma."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Check = new(
        "Prática", "Redirecione a atenção",
        [
            "1. Nomeie o pensamento recorrente em poucas palavras, sem detalhes",
            "2. Perceba: \"Estou tendo o pensamento de que…\"",
            "3. Se quiser, leve a atenção a um som ou objeto neutro; o pensamento pode continuar"
        ],
        "O exercício ajuda a escolher onde colocar a atenção; não exige que os pensamentos desapareçam.",
        TechniqueUiKind.Entry, "Técnica nº 11", "22.01.2025", "Redirecione a atenção", "Observe o pensamento e escolha um foco neutro", "Tamanho do problema", string.Empty, 2, "FactCheck",
        [new TechniqueEntrySeed("Aquilo em que você fica girando", "Que pensamento volta sempre?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem)],
        Theory(
            "Esta é uma forma breve de notar um pensamento recorrente e dar outra tarefa à atenção. Você não precisa suprimi-lo nem ficar calmo.",
            "Quando você fica revendo o mesmo assunto e se sente confortável para experimentar uma mudança breve. Se o pensamento se refere a perigo real, cuide primeiro da segurança.",
            "Nomeie o pensamento em uma frase e escolha um som ou objeto neutro ao redor. Pare se o desconforto aumentar. Não use isso no lugar de uma ação médica ou prática necessária.",
            "Pensamento: \"E se eu estiver doente?\" Você pode notá-lo como pensamento e decidir se precisa dar um passo real, como consultar um profissional sobre um sintoma."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Observer = new(
        "Prática", "Falar consigo com distanciamento",
        [
            "1. Nomeie a situação e o sentimento em uma frase; não é preciso detalhar um acontecimento doloroso.",
            "2. Fale consigo usando seu nome ou «você», em vez de usar apenas «eu». Por exemplo: «[Nome], o que está acontecendo agora?»",
            "3. Escreva o que importa agora e um próximo passo seguro e possível. Não justifique danos nem minimize perigos.",
            "4. Avalie sua tensão agora. Ela pode diminuir, continuar igual ou aumentar. Se você se sentir pior, pare e escolha outro apoio."
        ],
        "Uma adaptação breve do diálogo interno distanciado: fale consigo usando seu nome ou «você», em vez de apenas «eu». Isso pode criar espaço para refletir, mas não promete alívio imediato.",
        TechniqueUiKind.Entry, "Técnica nº 12", "12.06.2026", "Falar consigo com distanciamento", "Use seu nome ou «você» ao falar consigo e escolha um passo seguro", "Momento difícil", "Autocuidado", 1, "Visibility",
        [
            new TechniqueEntrySeed("Situação", "Em poucas palavras: o que está acontecendo agora? Não é preciso contar os detalhes de um acontecimento doloroso.", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Sentimentos em primeira pessoa", "O que você está sentindo? Uma frase curta basta.", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("O que o observador vê", "Fale consigo usando seu nome ou «você»: o que importa e qual é um próximo passo seguro?", Suggestions: ["[Nome], o que é importante para você agora?", "Qual é um passo seguro e possível?", "Como você pode se apoiar?", "O que diria a alguém próximo?", "Você pode responder mais tarde, quando estiver mais claro"]),
            new TechniqueEntrySeed("Tensão agora", "Avalie no final; ela pode continuar igual.", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "O diálogo interno distanciado usa seu nome ou «você», em vez de apenas «eu». Isso pode abrir espaço para refletir, mas não garante alívio imediato.",
            "Experimente durante uma tensão emocional ou social manejável e somente se você estiver em segurança. Não use para justificar danos nem minimizar um perigo real.",
            "Nomeie brevemente o sentimento, fale consigo usando seu nome ou «você» e pergunte o que importa agora e qual passo seguro é possível.",
            "Em vez de «Não vou dar conta»: «[Nome], isso está difícil. Qual é um próximo passo seguro para você?»"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Anchor = new(
        "Prática", "Memória de apoio",
        [
            "1. Lembre de um momento seguro em que recebeu apoio ou superou uma dificuldade",
            "2. Perceba o que ajudou e o que você sentia no corpo",
            "3. Se quiser, escolha um gesto apenas como lembrete dessa lembrança",
            "4. Avalie quanto a lembrança ajuda agora (0 = nada, 10 = muito); escolher 0 também está bem"
        ],
        "Uma lembrança pode trazer à mente fontes de apoio já conhecidas. A resposta varia; um gesto é apenas um lembrete opcional e não muda o estado de forma confiável.",
        TechniqueUiKind.Entry, "Técnica nº 13", "12.06.2026", "Memória de apoio", "Relembrar uma experiência de apoio e perceber recursos disponíveis", "Momento difícil", "Memória de apoio", 4, "SelfImprovement",
        [
            new TechniqueEntrySeed("Lembrança de recurso", "Escolha uma lembrança segura para você; se não encontrar uma, pode pular o exercício.", Suggestions: ["Uma apresentação que deu certo", "Férias na praia", "O abraço de alguém próximo", "Terminar algo difícil", "Uma caminhada na natureza", "Passar em uma prova", "O nascimento de um filho", "Vencer uma competição", "Uma noite com amigos", "Um elogio do meu chefe", "O primeiro dia em um emprego novo", "Uma manhã sem pressa"]),
            new TechniqueEntrySeed("Sensações do corpo", "Onde você sente isso? Calor, leveza, firmeza…", Suggestions: ["Calor no peito", "Leveza", "Ombros abertos", "Respiração tranquila", "Pernas firmes", "Um sorriso", "Um coração calmo", "As costas retas", "Energia nas mãos", "A barriga relaxada"]),
            new TechniqueEntrySeed("Gesto opcional de lembrança", "Este gesto pode lembrar a experiência; você pode pular esta etapa", Suggestions: ["Fechar a mão", "Tocar o pulso", "Juntar o polegar e o indicador", "A mão no coração", "Uma respiração profunda", "Apertar o lóbulo da orelha", "Abrir os ombros", "Acariciar a palma da mão"]),
            new TechniqueEntrySeed("Resposta à lembrança", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Este é um breve exercício de lembrança. Seu efeito e qualquer ligação com um gesto não são garantidos.",
            "Quando quiser lembrar o que já ajudou. Escolha apenas uma lembrança segura; pare se isso ficar mais difícil.",
            "Perceba o que ajudou naquela situação. O gesto é opcional e serve apenas como lembrete; você não precisa se obrigar a ficar calmo.",
            "Lembro que um amigo me ouviu. Conversar ajudou; posso escrever para ele agora. Resposta à lembrança: 5 de 10."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Grounding = new(
        "Prática", "Ancoragem 5-4-3-2-1",
        [
            "1. Diga 5 coisas que você vê",
            "2. Diga 4 coisas que você sente com o corpo",
            "3. Diga 3 sons ao seu redor",
            "4. Diga 2 cheiros",
            "5. Diga 1 sabor ou uma sensação agradável"
        ],
        "A ancoragem pelos sentidos leva a atenção dos pensamentos ansiosos para o momento presente.",
        TechniqueUiKind.Entry, "Técnica nº 14", "12.06.2026", "Ancoragem 5-4-3-2-1", "Voltar ao presente pelos sentidos", "Momento difícil", "Psique", 3, "Nature",
        [
            new TechniqueEntrySeed("5 coisas que vejo", "Ex.: janela, xícara, livro, luminária, mão", Suggestions: ["Janela", "Mesa", "Celular", "Computador", "Notebook", "Monitor", "Teclado", "Xícara", "Luminária", "Mão", "Porta", "Livro", "Cadeira", "Parede", "Quadro", "Planta", "Relógio", "Armário", "Céu", "Carro"]),
            new TechniqueEntrySeed("4 coisas que sinto com o corpo", "Ex.: a cadeira, o chão, a roupa, a temperatura do ar", Suggestions: ["Cadeira", "O chão sob os pés", "A roupa", "O frescor", "O calor", "O celular na mão", "O encosto da cadeira", "O tecido na pele", "A respiração no peito", "O vento", "O mouse", "As chaves", "O travesseiro", "O relógio no pulso"]),
            new TechniqueEntrySeed("3 sons", "Ex.: a rua, o relógio, sua respiração", Suggestions: ["A rua", "Relógio", "A respiração", "Vozes", "A geladeira", "O vento", "O silêncio", "Computador", "Os carros", "Os pássaros", "Música", "O ar-condicionado", "Passos", "A chuva"]),
            new TechniqueEntrySeed("2 cheiros", "Ex.: café, ar fresco", Suggestions: ["Café", "Ar fresco", "Sabonete", "Comida", "Perfume", "Quase nada", "Chá", "Pão", "Livros", "Flores", "Creme para as mãos", "Madeira"]),
            new TechniqueEntrySeed("1 sabor ou sensação agradável", "Ex.: água na boca, um tecido macio", Suggestions: ["Água", "Chá", "Um tecido macio", "As palmas quentes", "A boca fresca", "Café", "Um chiclete de menta", "Chocolate", "Uma maçã", "Um cobertor quentinho"])
        ],
        Theory(
            "Preste atenção ao que vê, ouve e sente à sua volta.",
            "Quando a preocupação toma sua atenção e você quer se concentrar no que está ao redor.",
            "Comece pelo que você vê. Se não perceber um cheiro ou um sabor, siga em frente. Respire como de costume.",
            "Vejo uma xícara e uma luminária. Sinto o chão sob os pés. Ouço o trânsito lá fora."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Breathing = new(
        "Prática", "Respiração guiada suave",
        [
            "1. Avalie a tensão antes de começar",
            "2. Sente-se confortavelmente. Respire com suavidade, sem inspirar mais profundamente que o habitual",
            "3. Se for confortável, acompanhe o círculo: inspire por cerca de 4 tempos e expire por cerca de 6. Não prenda a respiração",
            "4. Se o ritmo não funcionar para você, pare de contar ou encerre a prática. Se sentir tontura ou falta de ar, volte à respiração natural",
            "5. Avalie a tensão novamente ao terminar. Ela pode não mudar; isso também é uma informação útil"
        ],
        "Quando sentir tensão, você pode experimentar um ritmo breve e suave, sem pausas. Ele não é adequado para todas as pessoas: contar ou focar na respiração pode aumentar o desconforto.",
        TechniqueUiKind.Entry, "Técnica nº 15", "04.07.2026", "Respiração guiada suave", "Experimente um ritmo confortável com a expiração um pouco mais longa", "Momento difícil", "Psique", 3, "Air",
        [
            new TechniqueEntrySeed("Tensão antes", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Anotações", "O que você percebeu? Qualquer reação é válida.", Suggestions: ["O ritmo foi confortável", "Contar me distraiu", "O ritmo estava lento demais", "Fiquei tonto", "Respirar pareceu desconfortável", "Fiquei um pouco mais calmo", "A tensão não mudou", "Fiquei mais tenso", "Parei e observei o que estava ao meu redor"]),
            new TechniqueEntrySeed("Tensão depois", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Um ritmo breve e suave, com a expiração um pouco mais longa, permite experimentar acompanhar a respiração quando há tensão. Cada pessoa reage de um jeito; esta prática não garante alívio.",
            "Quando sentir tensão e for confortável prestar atenção à respiração.",
            "Sente-se confortavelmente. Respire com suavidade, sem inspirar mais profundamente que o habitual. Por cerca de um minuto, você pode acompanhar o círculo: inspire por cerca de 4 tempos e expire por cerca de 6, sem pausas. Se o ritmo parecer forçado, volte à respiração natural. Pare se o desconforto aumentar e nomeie alguns objetos ao seu redor.",
            "A tensão estava em 7/10. Depois de um minuto, continuou em 7/10; contar parecia forçado, então parei e nomeei cinco objetos ao meu redor."
        ),
        null, null);

    internal static readonly BuiltInTechniqueDefinition SmallStep = new(
        "Prática", "Um pequeno passo",
        [
            "1. Escolha uma pequena atividade de autocuidado, interesse, conexão ou sensação de conclusão",
            "2. Reduza-a a um começo seguro de 2–5 minutos. Você não precisa terminar toda a tarefa",
            "3. Escolha um horário concreto nas próximas 24 horas. Se agora não for o momento, escolha descanso, apoio ou um passo menor",
            "4. Avalie se parece possível: 0 — nenhuma confiança, 10 — total confiança. Se tiver dúvida, diminua mais"
        ],
        "Um breve plano de atividade inspirado nos princípios da ativação comportamental. Um passo pequeno pode ajudar a começar, mas não garante melhora do humor nem mais energia.",
        TechniqueUiKind.Entry, "Técnica nº 16", "04.07.2026", "Um pequeno passo", "Escolha uma atividade e torne o começo viável", "Momento difícil", "TCC", 5, "DirectionsWalk",
        [
            new TechniqueEntrySeed("O que dificulta começar?", "Cansaço, ansiedade, solidão, coisa demais para fazer?", Suggestions: ["Cansaço", "Ansiedade", "Solidão", "Coisa demais para fazer", "Tédio", "Não sei por onde começar", "Preciso descansar", "As condições não estão boas agora"], Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Uma pequena atividade para mim", "Autocuidado, interesse, conexão ou uma tarefa pequena", Suggestions: ["Beber água ou comer algo", "Me lavar ou me vestir", "Tomar um ar por 2 minutos", "Ouvir uma música de que gosto", "Mandar uma mensagem para alguém próximo", "Dedicar 2 minutos a algo importante", "Guardar uma coisa", "Pedir para alguém ficar comigo"]),
            new TechniqueEntrySeed("Quando você vai tentar?", "Um horário concreto nas próximas 24 horas", Suggestions: ["Agora por 2 minutos", "Depois do café da manhã", "Depois do almoço", "Depois do trabalho ou estudo", "Em um horário que eu escolher hoje", "Pedir para alguém próximo me lembrar"]),
            new TechniqueEntrySeed("Quão possível parece?", "0 — nenhuma confiança, 10 — total confiança", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "O humor baixo ou a falta de energia podem dificultar o começo. Uma pequena atividade planejada pode ajudar a sair da inércia; o efeito varia de pessoa para pessoa.",
            "Quando o humor ou a energia dificultam começar e há uma atividade segura e viável. Descansar ou pedir ajuda também pode ser um bom passo.",
            "Escolha algo de autocuidado, interesse, conexão ou sensação de realização; reduza o início a 2–5 minutos e marque um momento nas próximas 24 horas. Planejar não é o mesmo que fazer. Se não parecer viável, diminua o passo ou peça apoio.",
            "Em vez de «arrumar a casa toda», lave uma xícara depois do almoço — ou escreva para alguém próximo: «Tem um minuto para conversar?»"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition ThoughtRecord = new(
        "Prática", "Registro de pensamentos",
        [
            "1. Descreva a situação sem julgá-la",
            "2. Escreva o pensamento automático",
            "3. Nomeie o sentimento e avalie a intensidade agora",
            "4. Separe fatos de suposições e encontre outra possibilidade",
            "5. Avalie o sentimento de novo; ele pode continuar igual"
        ],
        "Separe situação, pensamento e sentimento; depois confira a conclusão diante dos fatos. O sentimento não precisa diminuir.",
        TechniqueUiKind.Entry, "Técnica nº 17", "04.07.2026", "Registro de pensamentos", "Separe um fato de uma interpretação", "Momento difícil", "TCC", 7, "EditNote",
        [
            new TechniqueEntrySeed("Situação", "O que aconteceu? Onde e quando? Apenas o essencial.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Pensamento automático", "O que você pensou naquele momento?", Suggestions: HarshThoughts),
            new TechniqueEntrySeed("Sentimento antes", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Uma visão mais precisa", "Que fatos apoiam ou contradizem isso? O que mais é possível?", Role: EntryFieldRole.Reframe),
            new TechniqueEntrySeed("Sentimento depois", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "O exercício separa um acontecimento da sua interpretação. Não é diagnóstico nem tratamento.",
            "Para uma situação moderadamente incômoda, se você tiver disposição para escrever agora. Não escolha uma lembrança traumática nem uma crise aguda.",
            "Anote fatos observáveis e depois o pensamento. Procure uma explicação que considere o que sabe e o que ainda não sabe; não force positividade. Se a avaliação não mudar, isso não significa que você fez algo errado.",
            "Situação: ainda não responderam à mensagem. Pensamento: “Ninguém precisa de mim.” Fato: ainda não há resposta. Outra possibilidade: o motivo é desconhecido; a pessoa pode estar ocupada."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition SelfCompassion = new(
        "Prática", "Palavras gentis para si",
        [
            "1. Escreva pelo que você está se criticando",
            "2. Imagine que um amigo próximo dissesse isso — o que você diria a ele?",
            "3. Formule a mesma frase de apoio para você",
            "4. Avalie o acolhimento ou o alívio"
        ],
        "A autocompaixão reduz a autocrítica dura e ajuda a se recuperar depois de um erro.",
        TechniqueUiKind.Entry, "Técnica nº 18", "04.07.2026", "Palavras gentis para si", "Suavizar a autocrítica com apoio", "Momento difícil", "TCC", 5, "Favorite",
        [
            new TechniqueEntrySeed("Pelo que você se critica", "O que você diz a si mesmo ou do que se culpa?", Suggestions: ["Um erro no trabalho", "Não terminei", "Fui grosso com alguém próximo", "Me comparo com os outros", "Adiei de novo", "Minha aparência", "Meu peso", "Falei o que não devia", "Não sou um pai ou mãe bom o bastante", "Ganho pouco", "Quebrei uma promessa", "Sensível demais"]),
            new TechniqueEntrySeed("O que você diria a um amigo", "Como você apoiaria alguém próximo nessa situação?", Role: EntryFieldRole.Kindness),
            new TechniqueEntrySeed("Frase para você", "A mesma gentileza, voltada para você", Role: EntryFieldRole.SelfKindness),
            new TechniqueEntrySeed("Acolhimento / alívio", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "A autocrítica raramente motiva — mais vezes alimenta a vergonha e a paralisia. A autocompaixão não tira a responsabilidade, mas dá apoio.",
            "Depois de um erro, ao se comparar com os outros ou ao se sentir insuficiente.",
            "Escreva a crítica e depois responda a si mesmo como responderia a um amigo — com respeito e sem minimizar.",
            "Crítica: estraguei tudo de novo. Para um amigo: você tentou, isso tem conserto. Para mim: posso aprender com isso. Acolhimento: 3 → 6."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition BodyScan = new(
        "Prática", "Onde está no corpo?",
        [
            "1. Avalie sua tensão agora",
            "2. Passe a atenção devagar pelo corpo, da cabeça aos pés",
            "3. Encontre o lugar onde a sensação é mais forte",
            "4. Descreva: como é, grande ou pequena, quente ou fria",
            "5. Dê nome ao sentimento que vem junto",
            "6. Se quiser, observe o que mudou ou permaneceu igual. Você pode parar ou voltar a atenção para o ambiente a qualquer momento."
        ],
        "O escaneamento corporal convida você a observar sensações e sentimentos sem precisar mudá-los.",
        TechniqueUiKind.Entry, "Técnica nº 19", "16.10.2026", "Onde está no corpo?", "Observar as sensações sem tentar mudá-las", "Momento difícil", "Mindfulness", 4, "Accessibility",
        [
            new TechniqueEntrySeed("Tensão agora", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Em que parte do corpo você sente?", "Por exemplo: peito, garganta, ombros", Suggestions: ["Cabeça", "Testa", "Olhos", "Mandíbula", "Garganta", "Pescoço", "Ombros", "Peito", "Coração", "Barriga", "Costas", "Lombar", "Braços", "Mãos", "Pernas", "O corpo todo"]),
            new TechniqueEntrySeed("Como é a sensação?", "Por exemplo: aperto, peso, um nó", Suggestions: ["Aperto", "Peso", "Um nó", "Pressão", "Tensão", "Calor", "Frio", "Tremor", "Formigamento", "Latejamento", "Vazio", "Dormência", "Dor", "Difícil de descrever"]),
            new TechniqueEntrySeed("Que sentimento vem junto?", "Por exemplo: ansiedade, mágoa, cansaço", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("Tensão depois", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "O escaneamento corporal pode ajudar a notar sensações e sentimentos que talvez venham junto. Percebê-los não precisa reduzir a tensão; ela pode continuar igual. Essa prática aparece em alguns programas de mindfulness.",
            "Quando você se sente ansioso ou pesado, mas não sabe dizer exatamente o que sente; quando o corpo fica tenso depois de uma conversa ou um dia difícil. A prática não explica doenças nem substitui o médico: se uma sensação for nova, forte ou não passar, procure um médico.",
            "Sente-se confortavelmente, se isso for bom para você, e leve a atenção aos poucos para diferentes partes do corpo. Descreva uma sensação com o máximo de precisão que conseguir; se fizer sentido, nomeie também um sentimento. Você não precisa mudar nada. Se voltar a atenção para dentro for desconfortável, abra os olhos, observe objetos ao seu redor ou encerre a prática. Respire normalmente.",
            "Tensão 6/10. Local: peito. Sensação: aperto. Sentimento: ansiedade antes de uma conversa. Depois, a tensão continuou em 6/10. Abri os olhos e nomeei objetos no ambiente. Esse também é um resultado válido."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Flashback = new(
        "Prática", "Uma lembrança tomou conta",
        [
            "1. Avalie a intensidade",
            "2. Diga a si mesmo: \"Isto é uma lembrança. Aquilo foi antes, e agora é hoje\"",
            "3. Diga onde você está e que hora do dia é",
            "4. Sinta o apoio sob os pés, feche e abra as mãos",
            "5. Diga três coisas que você vê",
            "6. Cinco expirações lentas, água fria, e avalie de novo"
        ],
        "Ajuda em um flashback: voltar da lembrança para o presente pelo tempo, pelo lugar, pelo corpo e pelos sentidos.",
        TechniqueUiKind.Entry, "Técnica nº 20", "16.10.2026", "Uma lembrança tomou conta", "Voltar ao presente quando uma lembrança difícil toma conta", "Momento difícil", "Trauma", 3, "MyLocation",
        [
            new TechniqueEntrySeed("Intensidade", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Onde você está e que hora do dia é", "Por exemplo: em casa, à noite", Suggestions: ["Em casa", "No trabalho", "Na rua", "No transporte", "Na casa de alguém", "Manhã", "Tarde", "Noite", "Madrugada"]),
            new TechniqueEntrySeed("Três coisas que você vê", "Por exemplo: janela, xícara, luminária", Suggestions: ["Janela", "Mesa", "Celular", "Xícara", "Luminária", "Porta", "Cadeira", "Parede", "Quadro", "Planta", "Relógio", "Céu"]),
            new TechniqueEntrySeed("Intensidade agora", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Um flashback é uma lembrança de trauma vivida como se estivesse acontecendo de novo: com os mesmos sentimentos e reações do corpo. O cérebro confunde \"antes\" e \"agora\". O tempo, o lugar, o apoio do corpo e o que você vê e ouve ajudam a voltar ao presente.",
            "Quando a lembrança de um acontecimento difícil toma conta, com imagens que surgem de repente e a sensação de \"estou lá de novo\". Flashbacks frequentes são um sinal comum de reação pós-traumática e respondem bem ao tratamento com um especialista em trauma.",
            "Não tente elaborar a lembrança: agora a única tarefa é voltar. Diga a si mesmo onde está e que dia é, pressione os pés no chão, diga o que vê, solte o ar devagar, use o frio.",
            "Intensidade 8. \"Aquilo foi antes; agora é 2026, estou em casa, é noite.\" Pés no chão; vejo uma janela, uma xícara, uma luminária. Água fria. Agora 4."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Nightmare = new(
        "Prática", "Reescrever um pesadelo",
        [
            "1. Escolha um pesadelo que se repete, não o mais difícil para começar",
            "2. Descreva em poucas palavras, sem detalhes pesados",
            "3. Decida o que mudar nele: o final, o lugar, você mesmo, alguém por perto",
            "4. Escreva a nova versão do sonho inteira, até um final calmo",
            "5. Todo dia, por 10 a 20 minutos, imagine a nova versão em detalhes",
            "6. Depois de uma ou duas semanas, veja como os pesadelos mudaram"
        ],
        "Ensaio por imagens: um pesadelo recorrente é reescrito acordado, e o cérebro começa a sonhar a nova versão.",
        TechniqueUiKind.Entry, "Técnica nº 21", "16.10.2026", "Reescrever um pesadelo", "Tornar um pesadelo recorrente mais raro e mais fraco", "O sono", "Trauma", 15, "NightsStay",
        [
            new TechniqueEntrySeed("Quão pesado é esse pesadelo", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Sobre o que é o pesadelo, em poucas palavras", "Uma ou duas frases, sem detalhes pesados", Suggestions: ["Alguém está me perseguindo", "Não consigo fugir", "Estou de volta onde foi assustador", "Estou perdendo alguém próximo", "Não consigo gritar", "Estou caindo", "Estou sendo atacado", "Estou atrasado e não chego a tempo"]),
            new TechniqueEntrySeed("O que você muda", "O que quiser: o sonho é seu", Suggestions: ["O final", "O lugar", "Fico mais forte", "Aparece alguém para ajudar", "Consigo falar e gritar", "O perigo desaparece", "Tudo fica seguro", "Percebo que é um sonho"]),
            new TechniqueEntrySeed("A nova versão do sonho", "Descreva inteira, do começo até um final calmo", Suggestions: ["Percebo que é um sonho", "Aparece alguém que me protege", "Me vejo em um lugar seguro", "Vou embora com calma", "Tudo termina bem"]),
            new TechniqueEntrySeed("Quando vou ensaiar a nova versão", "Todo dia, de 10 a 20 minutos", Suggestions: ["De manhã", "Durante o dia, em uma pausa", "À noite, umas duas horas antes de dormir", "Todo dia no mesmo horário"]),
            new TechniqueEntrySeed("Quão pesado está agora", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Pesadelos recorrentes depois de um trauma ou estresse se mantêm por hábito: o cérebro repete o mesmo enredo várias vezes. Na terapia de ensaio por imagens, o enredo é reescrito acordado, e a nova versão é ensaiada mentalmente todos os dias. Pesquisas mostram que isso torna os pesadelos mais raros e mais fracos e melhora o sono.",
            "Com pesadelos recorrentes que dão medo de dormir. Se o pesadelo repete diretamente um trauma e até uma descrição curta traz muito pavor, faça isso junto com um especialista em trauma.",
            "Comece com um pesadelo mais leve. Não escreva as partes assustadoras em detalhes: umas duas frases bastam. Mude o sonho como quiser; a nova versão não precisa ser realista. Ensaie durante o dia, não logo antes de dormir, de 10 a 20 minutos por dia.",
            "Pesadelo: alguém me persegue e não consigo fugir. Mudança: percebo que é um sonho, me viro, e é só uma sombra; volto para casa com calma. Ensaio isso todo dia à tarde. Depois de duas semanas, o pesadelo aparece menos."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Balloons = new(
        "Prática", "Estoure os balões",
        [
            "1. Avalie sua tensão antes do jogo",
            "2. Comece a rodada e toque no seu ritmo; não é preciso estourar todos os balões",
            "3. Respire como de costume. Não é necessário sincronizar a expiração com cada estouro",
            "4. A rodada termina sozinha. Se o jogo frustrar ou você se sentir pior, volte",
            "5. Avalie a tensão depois e anote o que percebeu. Não mudar também é um resultado"
        ],
        "Um jogo curto para ocupar as mãos e a atenção. Pode distrair por um momento, mas não precisa mudar como você se sente nem substitui ação ou apoio.",
        TechniqueUiKind.Entry, "Técnica nº 22", "26.10.2026", "Estoure os balões", "Uma pausa breve com jogo, se você quiser", "Momento difícil", "Psique", 3, "BubbleChart",
        [
            new TechniqueEntrySeed("Tensão antes", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notas", "O que você percebeu, se percebeu algo? Pode deixar em branco.", Suggestions: ["Um pouco menos de tensão", "Sem mudança perceptível", "Mais tensão", "Me distraí por um momento", "Percebi as cores ou o movimento", "O jogo me frustrou", "Não sei", "Outra coisa"]),
            new TechniqueEntrySeed("Tensão depois", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Um jogo curto pode ocupar as mãos e a atenção por um momento; o efeito varia. Ele não garante reduzir a ansiedade nem é um tratamento.",
            "Quando uma breve pausa com jogo parecer adequada. Não adie ações urgentes de saúde ou segurança para jogar.",
            "Toque no seu ritmo; não é preciso acertar todos os balões. Respire normalmente e não sincronize a respiração com cada estouro. Depois, compare sua avaliação sem esperar um resultado específico. Se houver um problema prático a resolver, retome o próximo passo quando estiver pronto.",
            "Depois de uma discussão, minha tensão estava em 7/10 e continuou em 7/10 após a rodada. Percebi que ainda estava irritado e decidi esperar antes de responder."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition CyclicSigh = new(
        "Prática", "Suspiro cíclico",
        [
            "1. Avalie sua tensão",
            "2. Inspire pelo nariz e, no final, faça mais uma inspiração curta",
            "3. Expire devagar pela boca, por mais tempo do que inspirou",
            "4. Respire no ritmo do círculo por cerca de três minutos",
            "5. Avalie sua tensão depois"
        ],
        "Duas inspirações suaves seguidas de uma expiração mais longa criam um ritmo respiratório. Não é preciso prender a respiração nem inspirar mais fundo do que o habitual.",
        TechniqueUiKind.Entry, "Técnica nº 23", "26.10.2026", "Suspiro cíclico", "Uma inspiração dupla e uma expiração longa para acalmar o corpo", "Momento difícil", "Psique", 3, "Air",
        [
            new TechniqueEntrySeed("Tensão antes", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notas", "O que você percebeu?", Suggestions: ["Um pouco mais calmo", "Sem mudança perceptível", "Mais desconfortável", "Fiquei tonto", "Prefiro não avaliar", "Outra coisa"]),
            new TechniqueEntrySeed("Tensão depois", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Em um estudo randomizado com 111 participantes, o suspiro cíclico foi praticado por cinco minutos ao dia durante um mês. As pontuações de humor positivo melhoraram mais do que no grupo de atenção plena. Isso não demonstra que uma sessão curta reduza a tensão rapidamente nem que todos respondam da mesma forma.",
            "Experimente se prestar atenção à respiração for confortável, por exemplo antes de uma conversa ou durante uma pausa. Se isso aumentar o desconforto, escolha uma prática voltada ao ambiente.",
            "Respire com suavidade, sem tentar inspirar o máximo possível. Repita o ritmo apenas enquanto for confortável. Se sentir tontura ou mal-estar, pare, sente-se em um lugar estável e volte à respiração habitual. Procure orientação médica se os sintomas forem intensos ou persistirem.",
            "Antes de uma ligação, percebo a tensão e experimento alguns ciclos suaves. Se nada mudar ou eu me sentir pior, paro e volto a respirar normalmente."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition MuscleRelax = new(
        "Prática", "Contrair e soltar",
        [
            "1. Avalie sua tensão",
            "2. Contraia um grupo de músculos por cinco segundos, com metade da força",
            "3. Solte e perceba o relaxamento por quinze segundos",
            "4. Passe por cinco grupos: mãos, ombros, rosto, barriga, pernas",
            "5. Avalie sua tensão depois"
        ],
        "Contrair os músculos primeiro e depois soltar ajuda o corpo a sentir o que é relaxar.",
        TechniqueUiKind.Entry, "Técnica nº 24", "26.10.2026", "Contrair e soltar", "Um relaxamento muscular curto para um corpo tenso", "Momento difícil", "Psique", 4, "SelfImprovement",
        [
            new TechniqueEntrySeed("Tensão antes", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notas", "Em que parte do corpo ficou mais leve?", Suggestions: ["Meus ombros relaxaram", "Minha mandíbula se soltou", "Minhas mãos esquentaram", "Ficou mais fácil respirar", "Deu sono", "Ainda sobrou alguma tensão", "Nada mudou"]),
            new TechniqueEntrySeed("Tensão depois", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "O relaxamento muscular progressivo é um dos jeitos mais estudados de reduzir a ansiedade e a tensão. Contrair um músculo e depois soltá-lo cria um contraste que ajuda a perceber o relaxamento e, com o tempo, aprender a provocá-lo. Não é um tratamento, mas uma habilidade que funciona melhor com a prática.",
            "Quando o corpo está tenso de estresse, quando é difícil ficar parado ou pegar no sono. Combina bem com a noite, antes de dormir.",
            "Contraia com metade da força, sem dor. Se alguma parte do corpo dói ou está machucada, não a contraia; apenas observe. Ao soltar, respire com calma e não tenha pressa de passar ao próximo grupo.",
            "Tensão 7/10 à noite depois do trabalho, ombros encolhidos. Cinco grupos: mãos, ombros, rosto, barriga, pernas. Tensão 4/10, os ombros relaxaram."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition BusyMind = new(
        "Prática", "Pausa breve da atenção",
        [
            "1. Avalie sua tensão apenas se isso for útil agora",
            "2. Escolha uma tarefa neutra por cerca de 30–60 segundos",
            "3. Se a atenção voltar à preocupação, não se critique; você pode retornar com calma à tarefa uma vez",
            "4. Pare e veja se precisa de um próximo passo prático ou apoio"
        ],
        "Uma tarefa neutra e breve pode mudar a atenção por um momento quando os pensamentos parecem presos. Ela não elimina pensamentos nem resolve o problema.",
        TechniqueUiKind.Entry, "Técnica nº 25", "26.10.2026", "Pausa breve da atenção", "Uma pausa temporária quando os pensamentos se repetem", "Momento difícil", "Psique", 1, "Extension",
        [
            new TechniqueEntrySeed("Tensão antes", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Anotações", "Como foi essa pausa breve?", Suggestions: ["Mudei o foco por um momento", "Nada mudou", "Fiquei mais tenso ou frustrado", "Agora vejo um próximo passo", "Preciso de apoio", "Parei o exercício"]),
            new TechniqueEntrySeed("Tensão depois", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Uma tarefa neutra e breve — como nomear objetos de uma cor — às vezes ajuda a atravessar um momento intenso. É uma mudança temporária de atenção, não elimina pensamentos; o efeito varia.",
            "Quando pensamentos repetidos ocupam sua atenção e você quer uma pausa breve. Se houver um problema urgente ou uma questão de segurança ou saúde, cuide disso e procure ajuda adequada.",
            "Escolha uma tarefa simples por 30–60 segundos; não precisa se concentrar perfeitamente. Depois, veja se existe um próximo passo prático. Se a tarefa frustrar ou piorar como você se sente, pare e escolha outra abordagem.",
            "Depois de uma discussão, a conversa continua voltando à mente. Por meio minuto, nomeie cinco objetos ao redor; depois decida se precisa esclarecer um fato, descansar ou pedir apoio."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition ThoughtDefusion = new(
        "Prática", "Tomar distância de um pensamento",
        [
            "1. Perceba um pensamento curto; escrevê-lo é opcional",
            "2. Diga: “Estou percebendo o pensamento de que…”",
            "3. Observe um objeto à sua frente e sinta o apoio sob seus pés",
            "4. Escolha um pequeno próximo passo ou pare por aqui"
        ],
        "Uma habilidade breve da terapia de aceitação e compromisso (ACT): perceber um pensamento como algo que a mente faz, não necessariamente como um fato ou uma ordem.",
        TechniqueUiKind.Entry, "Técnica nº 26", "03.11.2026", "Tomar distância de um pensamento", "Uma prática breve para criar espaço em torno de um pensamento preocupante", "Pensamentos", "Psique", 1, "FormatQuote",
        [
            new TechniqueEntrySeed("Pensamento", "Opcional: você pode fazer a prática em silêncio", Suggestions: HarshThoughts)
        ],
        Theory(
            "Um pensamento repetido pode tomar toda a atenção. Na ACT, desfusão é percebê-lo sem discutir com ele nem tentar afastá-lo.",
            "Quando uma preocupação, autocrítica ou medo fica voltando. Você não precisa escolher uma lembrança angustiante.",
            "Não é preciso escrever nada. Coloque “Estou percebendo o pensamento de que…” antes do pensamento, olhe para um objeto e sinta o apoio sob os pés. Se o desconforto aumentar, pare e nomeie alguns objetos ao redor.",
            "“Vou estragar tudo” vira “Estou percebendo o pensamento de que vou estragar tudo”. Você nota a xícara à sua frente e decide responder a um e-mail ou fazer uma pausa."),
        null, null);
}
