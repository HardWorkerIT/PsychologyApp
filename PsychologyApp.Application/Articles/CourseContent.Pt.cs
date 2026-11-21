using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Articles;

public static partial class ArticleContent
{
    private static readonly Course[] CoursesPt =
    [
        new(
            CourseIds.Sleep,
            "Dormir sem remédios",
            "Sete dias de terapia cognitivo-comportamental da insônia, o jeito mais estudado de recuperar o sono",
            "Bedtime",
            "isi",
            "ISI-7",
            [
                new(
                    "Como o sono funciona",
                    4,
                    [
                        P("O sono não se «liga» com esforço. Duas forças o preparam: a pressão do sono, que se acumula o dia todo enquanto você está acordado, e o relógio interno, que nos dá sono e nos deixa alertas nos mesmos horários todos os dias."),
                        P("Na insônia, as duas forças se desregulam: a pessoa deita mais cedo para «compensar», fica muito tempo acordada, cochila de dia, levanta em horários diferentes. A pressão do sono não tem tempo de se acumular, e o relógio se confunde."),
                        Cycle("O ciclo da insônia", "Uma noite ruim", "Preocupação: «de novo não vou dormir»", "Esforçar-se para dormir", "A tensão afasta o sono"),
                        P("Este curso se baseia na terapia cognitivo-comportamental da insônia (TCC-I). As diretrizes médicas a recomendam em primeiro lugar, antes dos remédios para dormir: o efeito dura depois que o curso termina."),
                        Warning("Quando procurar primeiro um médico"),
                        List(
                            "Ronco alto, pausas na respiração durante o sono, muita sonolência durante o dia",
                            "Sensações desagradáveis nas pernas à noite que dão vontade de se mexer",
                            "Insônia junto com humor baixo há mais de duas semanas",
                            "Você dirige ou opera máquinas e sente muito sono durante o dia")
                    ],
                    "Toda manhã, anote: quando você deitou, mais ou menos quando adormeceu, quantas vezes acordou, quando levantou e como dormiu de 0 a 10. Sem relógio à noite, mais ou menos, pela sensação.",
                    "Em que horário você costuma deitar e levantar? O que mais atrapalha o seu sono?"),
                new(
                    "A cama é para dormir",
                    4,
                    [
                        P("Se você costuma ficar acordado na cama, se preocupar ou olhar o celular ali, o cérebro associa a cama a estar acordado. É por isso que dá para cochilar numa poltrona e ficar totalmente desperto assim que se deita."),
                        H("Regras que restauram a associação"),
                        List(
                            "Vá para a cama só quando sentir sono, não apenas cansaço",
                            "Se você não consegue dormir por uns 20 minutos, levante e faça algo tranquilo com luz baixa. Volte quando sentir sono",
                            "A cama é só para dormir e para a intimidade: sem celular, séries ou trabalho",
                            "Levante no mesmo horário todos os dias, mesmo depois de uma noite ruim e nos fins de semana",
                            "Não cochile e, se precisar muito, não mais que 20 minutos e antes das 15h"),
                        Quiz("A noite foi ruim. O que é melhor de manhã?", 1, "Um horário fixo para levantar é a principal âncora do sono. Se você dormir até mais tarde, haverá menos pressão do sono à noite, e a próxima noite também será difícil.", "Dormir até mais tarde para se recuperar", "Levantar no horário de sempre", "Levantar e depois tirar um bom cochilo durante o dia")
                    ],
                    "Escolha um horário para levantar que você consiga manter nos sete dias, e levante nele. Se não conseguir dormir por uns 20 minutos, saia da cama.",
                    "Que horário para levantar você escolheu? O que foi difícil na regra «levantar se não conseguir dormir»?"),
                new(
                    "A janela de sono",
                    5,
                    [
                        P("Quanto mais tempo a pessoa fica acordada na cama, mais leve e picado o sono fica. Uma técnica chamada compressão do sono ajuda: o tempo na cama é aproximado de quanto você realmente dorme."),
                        H("Como calcular a janela"),
                        List(
                            "Com as anotações dos últimos dias, calcule quanto você dorme em média",
                            "Some 30 minutos: esse é o seu tempo na cama, mas não menos que seis horas",
                            "Conte para trás a partir do horário de levantar escolhido: assim você tem o horário de deitar",
                            "Não deite antes desse horário, mesmo que tenha muita vontade"),
                        P("Nos primeiros dias você vai sentir sono: isso quer dizer que a pressão do sono está se acumulando. Depois de uma semana, se você dormir a maior parte do tempo na cama, a janela pode ser ampliada em 15 minutos."),
                        Warning("Atenção"),
                        P("Não comprima o sono se você tem transtorno bipolar ou epilepsia, se está grávida, ou se a sonolência torna dirigir ou trabalhar perigoso. Nesses casos, converse sobre o sono com um médico.")
                    ],
                    "Calcule sua janela de sono e mantenha-a até o fim do curso: nada de cama antes do horário de deitar, levantar no mesmo horário.",
                    "Qual é a sua janela de sono? Como foi a primeira noite com ela?"),
                new(
                    "Uma noite que prepara para o sono",
                    4,
                    [
                        P("O sono vem mais fácil quando o corpo e a mente têm tempo de desacelerar. A hora antes de deitar é a ponte entre o dia e o sono."),
                        H("O que ajuda"),
                        List(
                            "Uma hora antes de deitar: luz baixa e atividades tranquilas sem telas",
                            "Evite café, chá forte e energéticos por pelo menos 6 horas antes de dormir; se atrapalharem seu sono, experimente parar mais cedo",
                            "O álcool ajuda a adormecer, mas deixa o sono superficial e faz acordar de madrugada",
                            "Um jantar pesado 2–3 horas antes de deitar",
                            "De manhã, luz do dia por pelo menos 15 minutos: ela acerta o relógio interno"),
                        P("Plano de um minuto: escolha quando vai começar a desacelerar e uma atividade tranquila, como ler algumas páginas. Se não tiver uma hora livre, escolha antes uma versão mais curta. Por exemplo: «Depois das tarefas da noite, vou diminuir a luz e ler um pouco»."),
                        H("Relaxar antes de dormir"),
                        P("A respiração lenta com uma expiração longa diminui a ativação. Experimente agora."),
                        Breathe("Inspire contando 4, expire contando 6")
                    ],
                    "Experimente seu plano hoje à noite: reserve tempo para atividades tranquilas antes de deitar quando puder e use a versão curta se não tiver uma hora. Deixe o celular fora da cama, mantendo os avisos importantes.",
                    "O que entrou no seu ritual da noite? O que se mostrou difícil?"),
                new(
                    "Pensamentos que não deixam dormir",
                    4,
                    [
                        P("A mente muitas vezes começa a trabalhar justamente na cama: durante o dia não houve tempo para pensar. Por isso ajuda dar tempo a esses pensamentos mais cedo."),
                        H("Um tempo para os pensamentos"),
                        List(
                            "À noite, umas duas horas antes de deitar, reserve 15 minutos",
                            "Escreva tudo o que preocupa você e, para cada item, um próximo passo ou «por enquanto não há o que fazer»",
                            "Se o pensamento voltar na cama, diga a si mesmo: «já anotei isso, cuido disso amanhã»"),
                        Quiz("Na cama você pensa: «Se eu não dormir, amanhã vou estragar tudo.» O que está mais perto da verdade?", 1, "O pensamento exagera. Depois de uma noite ruim fica mais difícil, mas a maioria das pessoas ainda dá conta das tarefas. Quanto maior o medo do dia seguinte, mais difícil adormecer.", "É verdade, o fracasso é inevitável", "Depois de uma noite ruim é mais difícil, mas geralmente dou conta do principal", "Melhor nem ir para a cama"),
                        Practice(TechniqueId.ThoughtDefusion, "Tomar distância de um pensamento")
                    ],
                    "Toda noite, reserve 15 minutos para escrever o que preocupa você, e não leve esses pensamentos para a cama.",
                    "Que pensamentos aparecem com mais frequência à noite? Escrevê-los ajudou?"),
                new(
                    "Parar de lutar contra o sono",
                    4,
                    [
                        P("Quanto mais você tenta dormir, pior fica. O sono é como um pássaro arisco: vem quando ninguém está correndo atrás dele."),
                        H("O que ajuda a soltar o controle"),
                        List(
                            "Tire o relógio da vista: contar «faltam cinco horas» desperta",
                            "Permita-se não dormir: «vou ficar aqui deitado descansando, o sono vem quando vier»",
                            "Uma noite ruim não é uma catástrofe: o corpo se recupera mesmo depois de um sono incompleto",
                            "Não cancele planos por causa de uma noite ruim: assim a insônia não comanda a sua vida"),
                        P("Compare suas anotações dos primeiros dias com as de agora: como mudaram o tempo para adormecer, o número de despertares e a nota do sono?")
                    ],
                    "À noite, mantenha o relógio fora da vista. Depois de uma noite ruim, viva o dia normalmente.",
                    "Segundo suas anotações, o que mudou no seu sono nesses dias?"),
                new(
                    "Resumo e plano",
                    4,
                    [
                        P("Em uma semana você passou pelo núcleo da TCC da insônia. O sono se recupera aos poucos: muitas pessoas percebem melhora em duas a quatro semanas se seguirem as regras."),
                        H("O que continuar fazendo"),
                        List(
                            "Um mesmo horário para levantar todos os dias",
                            "Ir para a cama só com sono e levantar se não conseguir dormir",
                            "Se você dorme a maior parte da noite, ampliar a janela em 15 minutos por semana",
                            "O ritual da noite e o tempo para os pensamentos"),
                        H("Se a insônia voltar"),
                        P("Depois de estresse, doença ou viagem, o sono pode sair dos trilhos de novo. É normal: volte às regras deste curso, e ele vai se recuperar mais rápido do que da primeira vez."),
                        P("Refaça o índice ISI-7 e compare com o seu resultado do início. Se não houver melhora, procure um médico: existem especialistas em sono que aplicam a TCC-I."),
                        TestsTab("Índice ISI-7", "isi")
                    ],
                    "Escreva seu plano para o caso de o sono sair dos trilhos de novo.",
                    "O que mais ajudou no curso? O que você vai continuar fazendo?")
            ]),
        new(
            CourseIds.Anxiety,
            "A ansiedade sob controle",
            "Seis dias: entender como a ansiedade funciona, acalmar o corpo, conferir pensamentos assustadores e dar um primeiro passo em direção ao medo",
            "Psychology",
            "gad7",
            "GAD-7",
            [
                new(
                    "Como a ansiedade funciona",
                    4,
                    [
                        P("A ansiedade é um alarme feito para avisar do perigo. O problema começa quando ele dispara com frequência demais, alto demais, e demora a se calar."),
                        Cycle("O ciclo da ansiedade", "Um pensamento assustador", "Ansiedade no corpo", "Evitação ou uma muleta", "Alívio por um instante", "O cérebro aprende: «era perigoso»"),
                        P("O que mantém a ansiedade não é o medo em si, mas o que fazemos para não senti-lo: evitar, reconferir, pedir que nos tranquilizem, remoer pensamentos. Passo a passo, o curso trabalha cada elo desse ciclo."),
                        P("No início do curso, vale a pena fazer a escala GAD-7: no fim você vai comparar o resultado."),
                        TestsTab("Escala GAD-7", "gad7")
                    ],
                    "Hoje, três vezes, quando sentir ansiedade, repare: o que aconteceu, qual foi o pensamento, o que o corpo sentiu e o que você fez.",
                    "Quando e onde a ansiedade aparece com mais frequência?"),
                new(
                    "Acalmar o corpo",
                    4,
                    [
                        P("Quando a ansiedade está alta, é difícil discutir com os pensamentos. Primeiro ajuda acalmar o corpo: uma expiração lenta aciona o sistema que freia a reação de luta ou fuga."),
                        Breathe("Inspire contando 4, expire contando 6"),
                        P("Se a ansiedade está forte e tudo parece irreal, traga a atenção de volta ao presente pelos sentidos."),
                        Practice(TechniqueId.Grounding, "Ancoragem 5-4-3-2-1"),
                        P("Importante: a respiração não é um jeito de se livrar da ansiedade a qualquer custo. Ela ajuda a atravessar o pico, não a evitar situações.")
                    ],
                    "Duas vezes por dia, dois minutos de respiração lenta, mesmo com calma: assim a habilidade estará lá quando você precisar.",
                    "O que você notou no corpo ao respirar devagar?"),
                new(
                    "Conferir um pensamento assustador",
                    5,
                    [
                        P("Pensamentos ansiosos soam como fatos: «vou passar vergonha», «vai acontecer algo terrível». Mas são previsões, e dá para conferi-las."),
                        H("Perguntas para fazer ao pensamento"),
                        List(
                            "Que fatos apoiam esse pensamento e quais vão contra?",
                            "O que aconteceu em casos parecidos antes?",
                            "O que é mais provável, e não mais assustador?",
                            "Se o pior acontecer, como vou lidar com isso?",
                            "O que eu diria a um amigo com esse pensamento?"),
                        Quiz("«Com certeza vou estragar tudo.» Que armadilha do pensamento é essa?", 1, "É adivinhar o futuro: o pensamento trata como fato algo que ainda não aconteceu.", "Ler a mente", "Adivinhar o futuro", "Desqualificar o positivo"),
                        Practice(TechniqueId.ThoughtRecord, "Registro de pensamentos")
                    ],
                    "Hoje, uma vez, confira um pensamento ansioso com um registro de pensamentos.",
                    "Que pensamento você conferiu? Quanto você acreditava nele antes e depois?"),
                new(
                    "O horário da preocupação",
                    4,
                    [
                        P("Preocupar-se parece útil: «se eu pensar mais, vou estar preparado». Na verdade, remoer raramente leva a uma solução e mantém a ansiedade alta."),
                        Quiz("Como distinguir resolver de andar em círculos?", 0, "Resolver avança para um passo: o que posso fazer, e quando. Andar em círculos produz novos «e se».", "Resolver termina num passo; andar em círculos, num novo «e se»", "Andar em círculos leva mais tempo", "Não dá"),
                        H("Como adiar a preocupação"),
                        List(
                            "Escolha 15–20 minutos por dia, não antes de dormir",
                            "Quando a preocupação vier em outra hora, anote o assunto numa linha e diga a si mesmo: «vou pensar nisso no meu horário da preocupação»",
                            "No seu horário da preocupação, repasse a lista: planeje um passo para o que você pode fazer, solte o que não pode",
                            "Muitas vezes, na hora marcada, o assunto já não parece importante"),
                        Practice(TechniqueId.ThoughtDefusion, "Tomar distância de um pensamento"),
                        P("Se você volta às notícias em busca de certeza, anote a pergunta específica e decida se precisa agir agora. Se não, escolha quando vai conferir novamente."),
                        See(ArticleIds.NewsLoop, "Quando as notícias não deixam você se desligar")
                    ],
                    "Defina um horário da preocupação e adie para ele os pensamentos ansiosos.",
                    "Você conseguiu adiar a preocupação? O que aconteceu com os assuntos na hora marcada?"),
                new(
                    "Muletas e evitação",
                    4,
                    [
                        P("O que mais mantém a ansiedade é a evitação. Ela pode ser aberta (não vou, não ligo) ou escondida: muletas que ajudam a atravessar uma situação."),
                        Check("Eu tenho muletas?", 2, "Você tem várias muletas. Elas mantêm o medo: o cérebro acha que tudo deu certo só graças a elas. Tente abrir mão de uma numa situação fácil.", "Você tem poucas muletas. Repare também no que você evita por completo.", "Levo um remédio, água ou o celular carregado «por via das dúvidas»", "Só vou acompanhado a lugares difíceis", "Sento perto da saída", "Me distraio para não perceber a ansiedade", "Confiro ou pergunto de novo muitas vezes"),
                        P("A saída é encontrar aos poucos o que você teme e dispensar as muletas. Assim o cérebro aprende pela experiência que o temido não acontece ou é suportável.")
                    ],
                    "Faça uma lista de três a cinco situações que você evita, da mais fácil à mais difícil.",
                    "Que situação da lista você está pronto para tentar primeiro?"),
                new(
                    "O primeiro passo e um plano",
                    4,
                    [
                        P("O jeito mais eficaz de enfraquecer a ansiedade é a exposição: encontrar o medo aos poucos. Não é preciso ir direto ao mais assustador: comece com um passo fácil e confira uma previsão."),
                        List(
                            "Antes do passo, anote o que você teme e o quanto tem certeza de que vai acontecer",
                            "Dê o passo sem muletas e fique na situação até ter conferido a previsão",
                            "Depois, anote o que realmente aconteceu"),
                        Ladder("Escada do medo"),
                        H("O que continuar fazendo"),
                        List(
                            "A respiração lenta no pico da ansiedade",
                            "Conferir pensamentos e o horário da preocupação",
                            "Degraus na escada do medo a cada poucos dias"),
                        P("Refaça a escala GAD-7 e compare com o início. Se a ansiedade estiver forte ou atrapalhar a vida, procure um psicoterapeuta: a TCC da ansiedade é bem estudada."),
                        TestsTab("Escala GAD-7", "gad7")
                    ],
                    "Dê o primeiro passo na sua escada do medo e anote o que aconteceu.",
                    "O que você tinha previsto, e o que realmente aconteceu?")
            ]),
        new(
            CourseIds.Mood,
            "Sair da apatia",
            "Seis dias de ativação comportamental: pequenos passos para trazer de volta a energia e o que dá alegria",
            "Cloud",
            "phq9",
            "PHQ-9",
            [
                new(
                    "O ciclo da inatividade",
                    4,
                    [
                        P("Quando o humor está no zero, é natural fazer menos: não há forças, nada atrai. Mas quanto menos fazemos, menos há na vida que traga alegria e a sensação de «eu consegui», e o humor cai ainda mais."),
                        Cycle("O ciclo da inatividade", "Sem forças", "Faço menos", "Menos alegria e conquistas", "Ainda menos forças"),
                        P("A ativação comportamental quebra esse ciclo pelo outro lado: não esperar a vontade, mas dar pequenos passos depois dos quais as forças e a vontade voltam aos poucos. É um dos métodos de ajuda mais estudados para a depressão."),
                        P("Faça a escala PHQ-9 no início do curso: no fim você vai comparar o resultado."),
                        TestsTab("Escala PHQ-9", "phq9"),
                        Warning("Se surgirem pensamentos sobre a morte"),
                        P("Se você tem pensamentos de que seria melhor se você não existisse, não fique sozinho com eles: este curso não substitui a ajuda de um especialista."),
                        Crisis("Preciso de ajuda agora")
                    ],
                    "Hoje e amanhã, repare no que você faz e dê uma nota ao seu humor de 0 a 10 várias vezes ao dia.",
                    "Como estão seus dias agora? O que você parou de fazer ultimamente?"),
                new(
                    "O que levanta o humor",
                    4,
                    [
                        P("Olhe suas observações: em que momentos o humor estava um pouco mais alto? Muitas vezes é algo pequeno: uma conversa, uma caminhada, um banho, uma tarefa feita."),
                        H("Dois tipos de atividades úteis"),
                        List(
                            "As agradáveis: o que dá prazer, mesmo que fraco — música, comida gostosa, sol",
                            "As de «eu consegui»: o que deixa a sensação de realização — lavar a louça, responder um e-mail"),
                        P("Na depressão, o prazer das coisas agradáveis é mais fraco do que antes. É normal: o que importa é fazer, e não esperar a alegria de antes.")
                    ],
                    "Faça uma lista de dez atividades: cinco agradáveis e cinco de «eu consegui». Quanto menores e mais simples, melhor.",
                    "O que entrou na sua lista? Houve algo que levantou um pouco o seu humor?"),
                new(
                    "Pequenos passos",
                    4,
                    [
                        P("Planos grandes assustam na apatia e não saem do papel. Ajuda dividir as coisas: não «limpar a casa», mas «tirar três coisas da mesa»."),
                        List(
                            "Escolha uma atividade da lista para hoje",
                            "Divida-a até chegar a um passo de cinco minutos",
                            "Defina um horário e um lugar: «depois do café da manhã, na cozinha»",
                            "Depois, anote como seu humor mudou"),
                        Practice(TechniqueId.SmallStep, "Um pequeno passo"),
                        P("O objetivo não é melhorar o humor na hora. Se ele continuar igual, observe se a atividade foi viável e ajuste o próximo passo."),
                        See(ArticleIds.SmallStepReview, "Quando um pequeno passo não melhora o humor")
                    ],
                    "Todos os dias, faça uma atividade agradável e uma de «eu consegui» no horário que você definiu.",
                    "O que você conseguiu fazer? Como seu humor mudou depois?"),
                new(
                    "«Não estou com vontade»",
                    4,
                    [
                        P("O principal obstáculo é o pensamento «não estou com vontade, vou fazer quando tiver forças». Na apatia, a vontade vem depois da ação, não antes."),
                        Quiz("Sem forças, e hoje está planejada uma caminhada. O que é melhor?", 1, "Na apatia, a vontade volta depois da ação. Mesmo cinco minutos dão ao corpo e ao humor o sinal «eu fiz alguma coisa».", "Esperar até ter vontade", "Sair pelo menos por cinco minutos", "Deixar para o fim de semana"),
                        H("Outros pensamentos que travam"),
                        List(
                            "«Não adianta nada»: confira depois — algo ficou nem que seja um pouco diferente?",
                            "«É pouco demais»: é justamente de pequenos passos que se faz a saída",
                            "«Antes eu fazia mais»: compare-se com ontem, não com quem você era antes"),
                        Practice(TechniqueId.SelfCompassion, "Palavras gentis para si")
                    ],
                    "Quando não estiver com vontade, faça pelo menos uma versão de cinco minutos do que planejou.",
                    "Que pensamento mais impede você de começar? O que ajudou a contorná-lo?"),
                new(
                    "As pessoas ao seu redor",
                    4,
                    [
                        P("Na apatia dá vontade de se fechar para todo mundo. Mas o contato com as pessoas é um dos remédios mais fortes contra o humor baixo, mesmo que agora não traga a alegria de antes."),
                        List(
                            "Escreva para uma pessoa com quem você não fala há algum tempo",
                            "Um encontro curto ou uma ligação é melhor do que nada",
                            "Você não precisa explicar tudo: «está difícil agora, vamos só dar uma volta»",
                            "Se as forças estiverem baixas, escolha pessoas com quem é fácil estar"),
                        Practice(TechniqueId.SmallStep, "Um pequeno passo"),
                        P("Você não precisa contar tudo: pode pedir algo concreto, como ser ouvido, ter companhia ou receber ajuda com uma tarefa."),
                        See(ArticleIds.SupportRequest, "Como pedir apoio")
                    ],
                    "Entre em contato com pelo menos uma pessoa nos próximos dois dias.",
                    "Com quem você entrou em contato? Como foi?"),
                new(
                    "O que importa para mim",
                    4,
                    [
                        P("Para que os passos não virem obrigações, ajuda ligá-los ao que importa para você: as pessoas próximas, a saúde, o trabalho, a criatividade, a natureza."),
                        List(
                            "Escolha uma área que importa para você",
                            "Pense em quem você quer ser nela",
                            "Escolha um pequeno passo nessa direção para a semana"),
                        H("O que continuar fazendo"),
                        List(
                            "Todos os dias, uma atividade agradável e uma de «eu consegui»",
                            "Pequenos passos em vez de grandes planos",
                            "O contato com as pessoas"),
                        P("Refaça a escala PHQ-9 e compare com o início. Se o resultado estiver alto ou não mudar, procure um médico ou psicoterapeuta: a depressão tem tratamento muito bom."),
                        TestsTab("Escala PHQ-9", "phq9"),
                        Crisis("Preciso de ajuda agora")
                    ],
                    "Dê um passo nesta semana numa área que importa para você.",
                    "O que importa para você? Que passo você escolheu?")
            ]),
        new(
            CourseIds.Trauma,
            "Depois de um trauma",
            "Cinco dias sobre o que é seguro fazer sozinho: entender sua reação, lidar com flashbacks e pesadelos, encontrar um especialista",
            "Healing",
            "pcl5",
            "PCL-5",
            [
                new(
                    "Uma reação normal a um acontecimento anormal",
                    4,
                    [
                        P("Depois de um acontecimento difícil, quase todo mundo tem lembranças invasivas, pesadelos, ansiedade, entorpecimento, irritação. Não é fraqueza, e sim a reação de um cérebro tentando proteger você de que aconteça de novo."),
                        P("Este curso não vai processar o trauma: isso exige terapia com um especialista. Ele vai ajudar você a entender o que está acontecendo, a lidar com os momentos difíceis e a chegar preparado ao especialista. Neste curso, você não precisa lembrar nem descrever o acontecimento em si."),
                        P("Faça a escala PCL-5 no início: no fim você vai comparar o resultado."),
                        TestsTab("Escala PCL-5", "pcl5"),
                        Warning("Se o perigo continua"),
                        P("Se você está sob ameaça agora, ou se surgiram pensamentos de se machucar, a segurança vem primeiro."),
                        Crisis("Preciso de ajuda agora")
                    ],
                    "Repare quando as coisas ficam mais difíceis durante o dia, sem detalhes do acontecimento: o horário, o lugar, o que havia ao redor.",
                    "Quais dessas reações você reconhece em si?"),
                new(
                    "Voltar ao presente",
                    4,
                    [
                        P("Um flashback é uma lembrança revivida como se estivesse acontecendo agora. O momento, o lugar, o apoio do corpo e os sentidos ajudam a voltar."),
                        Practice(TechniqueId.Flashback, "Uma lembrança tomou conta"),
                        Practice(TechniqueId.Grounding, "Ancoragem 5-4-3-2-1"),
                        H("Seu kit de ancoragem"),
                        List(
                            "Uma frase: «É uma lembrança. Agora é outro momento, estou seguro»",
                            "Algo para levar com você: uma pedrinha, um anel, algo com cheiro",
                            "Uma pessoa para quem você pode mandar mensagem",
                            "Algo frio: água, gelo"),
                        Breathe("A expiração mais longa que a inspiração"),
                        P("Se focar na respiração ou no corpo aumentar o desconforto, pare. Abra os olhos, escolha um objeto neutro ao seu redor ou pule o exercício."),
                        See(ArticleIds.TraumaGrounding, "Quando a ancoragem aumenta o desconforto")
                    ],
                    "Monte seu kit de ancoragem e experimente a prática «Uma lembrança tomou conta» num momento tranquilo, para conhecê-la antes.",
                    "O que entrou no seu kit de ancoragem?"),
                new(
                    "O sono e os pesadelos",
                    4,
                    [
                        P("Depois de um trauma, o sono costuma sofrer: é difícil adormecer, o sono é leve, vêm os pesadelos. A falta de sono deixa os dias mais ansiosos e irritados."),
                        List(
                            "Um mesmo horário para levantar todos os dias",
                            "Luz de manhã, uma noite tranquila sem notícias",
                            "Se um pesadelo acordar você: luz, onde estou e que dia é hoje, água, expirações lentas",
                            "O álcool aumenta os pesadelos na segunda metade da noite"),
                        P("Um pesadelo que se repete pode ser reescrito: o ensaio por imagens torna os pesadelos menos frequentes e mais fracos. Comece por um mais leve."),
                        Practice(TechniqueId.Nightmare, "Reescrever um pesadelo")
                    ],
                    "Mantenha um mesmo horário para levantar. Se você tem pesadelos que se repetem, tente reescrever um deles, começando por um mais leve.",
                    "Como você está dormindo agora? O que ajuda depois de uma noite difícil?"),
                new(
                    "Apoio e pessoas",
                    4,
                    [
                        P("O trauma muitas vezes afasta as pessoas dos outros e do que importava antes. O apoio das pessoas próximas é um dos fatores mais fortes de recuperação."),
                        List(
                            "Você não precisa falar do acontecimento: dá para simplesmente estar junto",
                            "Diga às pessoas próximas como ajudar você num momento difícil",
                            "Traga de volta aos poucos o que dava apoio: caminhadas, movimento, coisas de que você gostava",
                            "Não anestesie as emoções com álcool: isso atrapalha a recuperação"),
                        P("Evitar o que lembra o acontecimento é compreensível, mas com o tempo isso estreita a vida e mantém o trauma «quente». É melhor trabalhar isso com um especialista do que se forçar sozinho."),
                        P("O que o acontecimento mudou no seu jeito de pensar sobre si — a culpa, «tem algo errado comigo», «não dá para confiar em ninguém» — pode ser trabalhado no chat, sem recontar o que aconteceu."),
                        TraumaChat("Trabalhar isso no chat"),
                        Practice(TechniqueId.SelfCompassion, "Palavras gentis para si")
                    ],
                    "Faça uma coisa que antes dava apoio a você, e passe um tempo com alguém de confiança.",
                    "Quem e o que dá apoio a você agora?"),
                new(
                    "O caminho até um especialista",
                    5,
                    [
                        P("Os sintomas pós-traumáticos respondem bem à psicoterapia focada no trauma: exposição prolongada, terapia cognitiva, EMDR, exposição escrita. Geralmente leva 8–16 sessões."),
                        See(ArticleIds.TraumaTreatment, "Como o trauma é tratado e como escolher um especialista"),
                        H("Como se preparar"),
                        List(
                            "Refaça a escala PCL-5 e compare com o início",
                            "Exporte um resumo do aplicativo para o especialista: «Perfil → Opções → Dados e backup»",
                            "Anote suas perguntas: qual método, quantas sessões, como o progresso será medido",
                            "Você não precisa contar tudo sobre o acontecimento no primeiro encontro"),
                        TestsTab("Escala PCL-5", "pcl5"),
                        Crisis("Preciso de ajuda agora")
                    ],
                    "Encontre um ou dois especialistas que trabalhem com trauma e marque uma consulta.",
                    "O que foi mais útil no curso? Sobre o que você quer conversar com o especialista?")
            ]),
        new(
            CourseIds.MoneyStress,
            "Preocupações com dinheiro: 14 dias de apoio",
            "Quatorze passos breves para verificar a urgência, separar fatos de previsões e encontrar apoio. O GAD-7 mede ansiedade geral das últimas duas semanas, não as finanças; uma mudança não comprova o efeito do curso. Não é aconselhamento financeiro ou jurídico.",
            "AccountBalanceWallet",
            "gad7",
            "GAD-7",
            [
                new(
                    "Uma preocupação",
                    4,
                    [P("O GAD-7 mede sintomas gerais de ansiedade das últimas duas semanas, não preocupações financeiras. Descreva uma preocupação sem valores, dados bancários ou nomes."), TestsTab("Abrir GAD-7: ansiedade geral nas últimas duas semanas", "gad7"), See(ArticleIds.MoneyStress, "Preocupações com dinheiro: fatos e previsões")],
                    "Anote em termos gerais ou diga em voz baixa.",
                    "O que costuma trazer sua atenção de volta a ela?"),
                new(
                    "Verificar a urgência",
                    4,
                    [P("Se alimentos, moradia, medicamentos essenciais ou segurança estão em risco, procure ajuda prática hoje; o curso pode esperar.")],
                    "Nomeie uma necessidade de hoje e alguém que você pode contatar.",
                    "O que precisa de atenção primeiro?"),
                new(
                    "Fatos e previsões",
                    4,
                    [P("Separe fatos conhecidos, o que falta verificar e um receio sobre o futuro. Reconhecer a incerteza não exige imaginar o pior."), Practice(TechniqueId.MoneyWorryPlan, "Organizar uma preocupação com dinheiro"), See(ArticleIds.MoneyStress, "Preocupações com dinheiro: fatos e previsões")],
                    "Experimente a prática com notas gerais.",
                    "O que conseguiu separar do receio?"),
                new(
                    "Uma pergunta para verificar",
                    4,
                    [P("Escolha uma pergunta cuja resposta possa reduzir a incerteza. Para contas ou serviços, use um canal oficial conhecido.")],
                    "Escreva uma pergunta e onde conferir a resposta com segurança.",
                    "O que ficou mais claro?"),
                new(
                    "Proteger dados pessoais",
                    4,
                    [P("Não compartilhe senhas, PINs, códigos ou dados completos de contas. Confira por outro meio pedidos inesperados de transferência.")],
                    "Escolha uma regra de pausa antes de compartilhar dados ou dinheiro.",
                    "Que limite aumenta sua segurança?"),
                new(
                    "Fazer um pedido específico",
                    4,
                    [P("Apoio pode ser companhia, fazer uma ligação juntos ou encontrar um serviço local, não só dinheiro. A outra pessoa pode aceitar ou recusar."), See(ArticleIds.SupportRequest, "Como pedir apoio")],
                    "Escreva um pedido para uma tarefa e horário, sem segredos financeiros.",
                    "A quem você poderia pedir?"),
                new(
                    "Um passo possível",
                    4,
                    [P("Escolha uma ação segura, reversível e sob seu controle. Para questões financeiras ou jurídicas especializadas, procure um profissional local qualificado."), Practice(TechniqueId.MoneyWorryPlan, "Organizar uma preocupação com dinheiro")],
                    "Escolha um passo pequeno ou peça apoio.",
                    "O que ajuda a não assumir tudo sozinho?"),
                new(
                    "Uma alternativa",
                    4,
                    [P("O plano fica mais flexível quando prevê outra opção diante de atraso ou recusa. Ela não precisa resolver tudo.")],
                    "Nomeie uma alternativa e um contato de apoio.",
                    "Qual opção parece realista?"),
                new(
                    "Um horário para rever",
                    4,
                    [P("Se não houver urgência, reserve um período curto para conferir informações e depois retome sua tarefa. Não adie a ajuda necessária.")],
                    "Escolha um horário tranquilo para rever o plano.",
                    "O que pode esperar?"),
                new(
                    "Apoio prático",
                    4,
                    [P("Na sua região pode haver serviços sociais, comunitários ou de saúde. As opções variam; o aplicativo não recomenda decisões financeiras.")],
                    "Encontre uma fonte local conhecida para perguntar sobre apoios.",
                    "O que você gostaria de perguntar?"),
                new(
                    "Conversar sem revelar segredos",
                    4,
                    [P("Você pode dizer: estou preocupado e gostaria que você ficasse comigo um pouco. Não precisa compartilhar valores ou dados de contas.")],
                    "Decida com quem conversar e o que contar em termos gerais.",
                    "Que tipo de apoio você gostaria?"),
                new(
                    "Cuidar de si",
                    4,
                    [P("Descansar, beber água, comer ou fazer algo tranquilizador não resolve a questão financeira, mas pode ajudar a atravessar o dia.")],
                    "Escolha um cuidado possível que não exija gastos.",
                    "O que poderia dar algum alívio?"),
                new(
                    "Rever seus limites",
                    4,
                    [P("Observe o que ficou claro, o que continua incerto e onde precisa de ajuda. Você pode simplificar o plano.")],
                    "Mantenha um próximo passo e adie o restante se for seguro.",
                    "O que não precisa resolver hoje?"),
                new(
                    "Escolher como continuar",
                    4,
                    [P("Depois de cerca de duas semanas, você pode repetir o GAD-7. Ele não avalia finanças nem comprova o efeito do curso. Se a ansiedade continuar atrapalhando sua vida, converse com um profissional."), TestsTab("Repetir GAD-7; ele não avalia finanças nem explica uma mudança", "gad7"), Crisis("Preciso de ajuda agora")],
                    "Escolha um apoio ou passo para continuar.",
                    "O que você manteria ou conversaria com um profissional?")
            ]),

        new(CourseIds.ValuesAction, "Pequenos passos em direção ao que importa", "Cinco dias para escolher uma direção significativa e experimentar ações possíveis.", "TrackChanges", "who5", "WHO-5",
            [
                new("Encontre uma direção", 3, [P("Um valor descreve como você quer ser em uma área da vida, não um resultado que precisa concluir de uma vez por todas."), See(ArticleIds.ValuesAction, "Valores como direção: escolher um passo possível")], "Nomeie uma área importante para você agora.", "O que torna essa área importante para você?"),
                new("Diminua o passo", 3, [P("Escolha uma ação de poucos minutos. Ela deve ser pequena o suficiente para experimentar e significativa o bastante para ser uma escolha sua.")], "Anote uma ação que leve no máximo 5–10 minutos.", "Como deixá-la mais fácil ou mais curta?"),
                new("Planeje um obstáculo", 3, [P("Pense no que pode atrapalhar e escolha uma alternativa. Um plano pode mudar; isso não é fracasso.")], "Complete: “Se … atrapalhar, posso tentar …”.", "Qual alternativa seria mais gentil se você tiver menos energia?"),
                new("Experimente sem esperar pelo ânimo ideal", 3, [P("Você não precisa se sentir confiante ou motivado antes. Pode experimentar um passo pequeno, perceber o que surge e parar ou simplificá-lo se isso for mais seguro.")], "Se for seguro, experimente o passo ou uma versão mais fácil.", "O que você percebeu antes e depois?"),
                new("Reveja o plano", 3, [P("Avalie se a ação combinou com você, sem se julgar. Repita, ajuste ou escolha outra direção.")], "Anote o que deseja repetir ou mudar nesta semana.", "Que ação pode apoiar o que importa sem aumentar a pressão?")
            ]),


        new(CourseIds.ProblemPlanning, "Um plano para tarefas possíveis", "Divida um problema em passos e reveja o plano", "Checklist", "gad7", "GAD-7",
            [
                new("Escolha um problema", 3, [P("Primeiro identifique um problema específico. Nem tudo depende de você; escolha aquilo que pode influenciar."), See(ArticleIds.ProblemPlanning, "Um plano para tarefas possíveis")], "Anote um problema e o que depende de você.", "Em que parte da situação você pode influir?"),
                new("Escolha um passo", 3, [P("Anote algumas opções, mesmo que nenhuma pareça perfeita. Escolha um passo pequeno e seguro."), See(ArticleIds.ProblemPlanning, "Um plano para tarefas possíveis")], "Anote duas opções e escolha um passo possível.", "O que pode atrapalhar e qual seria uma alternativa?"),
                new("Reveja o plano", 3, [P("Depois observe o que ajudou e o que foi difícil demais. Você pode ajustar o plano ou pedir apoio."), See(ArticleIds.ProblemPlanning, "Um plano para tarefas possíveis")], "Experimente o passo se for seguro e anote o resultado.", "O que manter, mudar ou conversar com alguém?")
            ]),
        new(
            CourseIds.Overwhelm,
            "Menos sobrecarga, um próximo passo mais claro",
            "Cinco dias curtos para organizar urgências, reduzir uma tarefa e encontrar apoio. Vá no seu ritmo.",
            "Checklist",
            "pss10",
            "PSS-10",
            [
                new("Tire as tarefas da cabeça", 4, [P("Uma lista curta mostra o que está pedindo atenção. Algumas palavras bastam; não é preciso incluir detalhes pessoais."), H("Verifique primeiro a urgência"), Warning("Se segurança, saúde, alimentação, moradia ou medicamentos essenciais estiverem em risco, procure ajuda prática primeiro."), See(ArticleIds.Overwhelm, "Quando tudo se acumula: escolha o próximo passo")], "Anote o que pede atenção e marque apenas o que não pode esperar com segurança.", "O que ficou mais claro depois da lista?"),
                new("Separe urgência de preocupação", 4, [P("Uma preocupação intensa merece atenção, mas não define sozinha a ordem das tarefas. Verifique prazos, consequências e o que você pode influenciar."), Quiz("O que ajuda a escolher a primeira tarefa?", 1, "Prazos e consequências ajudam a avaliar a urgência; a intensidade da preocupação, por si só, não torna uma tarefa a primeira.", "Escolher a preocupação mais forte", "Verificar o prazo e as consequências", "Tentar resolver tudo ao mesmo tempo")], "Escolha uma tarefa para hoje e outra que possa esperar.", "O que realmente não pode ser adiado?"),
                new("Reduza o próximo passo", 4, [P("Descreva uma ação que leve alguns minutos. Se ainda parecer grande demais, divida-a novamente."), See(ArticleIds.Overwhelm, "Quando tudo se acumula: escolha o próximo passo"), Practice(TechniqueId.ExternalOrientation, "Três detalhes neutros")], "Nomeie o começo: abrir, ligar, perguntar ou reunir um item.", "Como tornar esse passo mais fácil?"),
                new("Peça uma ajuda possível", 4, [P("Pedir uma ação específica é mais claro do que pedir que alguém resolva tudo. A pessoa pode aceitar, sugerir outra opção ou dizer não; então você pode procurar outro apoio."), List("Pedir que alguém fique por perto", "Pedir ajuda para conferir um dado", "Pedir para dividir uma tarefa")], "Escreva um pedido breve e pense para quem poderia fazê-lo.", "Que resposta ou alternativa seria útil?"),
                new("Reveja o plano", 4, [P("Veja se o plano combina com suas circunstâncias atuais, não se você foi rígido o bastante consigo. Você pode continuar, simplificar ou pedir apoio."), TestsTab("Se quiser, repita o PSS-10. Ele rastreia o estresse percebido, não diagnostica; uma mudança na pontuação não prova que o curso a causou.", "pss10")], "Escolha um passo que queira manter nos próximos dias.", "Como evitar que o plano vire mais uma pressão?")
            ]),

        new(
            CourseIds.NewsBoundaries,
            "Notícias no seu ritmo",
            "Cinco dias para consultar menos por hábito e manter os avisos importantes.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Perceba o hábito", 4, [P("Quando abrir o feed, pergunte: o que quero saber e preciso agir agora?"), See(ArticleIds.NewsLoop, "Quando as notícias não deixam você se desligar"), TestsTab("O PSS-10 mede o estresse percebido no último mês. É uma ferramenta de rastreio, não um diagnóstico.", "pss10")], "Perceba uma vez o que despertou a vontade de conferir as notícias.", "O que você queria descobrir?"),
                new("Uma pergunta, uma fonte", 4, [P("Formule uma pergunta e escolha uma fonte confiável que possa respondê-la. Depois de encontrar a resposta, novas atualizações talvez não tragam informação útil."), Quiz("Você encontrou a resposta necessária. O que pode fazer se não há uma ação urgente?", 1, "Escolher quando consultar de novo pode interromper a atualização automática.", "Atualizar até se sentir tranquilo", "Escolher quando consultar novamente e voltar à sua atividade", "Proibir-se completamente de ler notícias")], "Escolha uma pergunta e uma fonte para a próxima consulta.", "Como saberá que já tem a informação necessária?"),
                new("Mantenha os avisos importantes", 4, [P("Você pode desativar notificações opcionais e manter os avisos importantes para segurança, família ou trabalho."), List("Manter avisos de serviços essenciais", "Desativar notificações opcionais", "Pedir às pessoas próximas que liguem em caso de urgência")], "Revise as configurações apenas se isso for útil.", "Quais avisos você precisa manter?"),
                new("Monte um plano de consulta", 4, [P("Escolha um horário e uma fonte adequados. Não é preciso impor um limite rígido: ajuste o plano se surgir algo urgente ou uma nova circunstância."), Practice(TechniqueId.NewsCheckPlan, "Planejar uma consulta de notícias")], "Preencha o plano curto ou apenas pense nele.", "O que você fará depois da consulta?"),
                new("Revise sem se julgar", 4, [P("Observe se essa rotina parece mais viável. Mantenha, ajuste ou deixe de lado. Uma mudança no PSS-10 não prova que o curso a causou."), Quiz("O que fazer se surgir uma informação importante para a segurança?", 1, "O plano não deve impedir que você confira informações urgentes ou siga orientações oficiais.", "Esperar o próximo horário", "Conferir uma fonte confiável e agir conforme a situação", "Desativar todos os avisos"), TestsTab("Se quiser, repita o PSS-10. Comparar pontuações não identifica a causa de uma mudança.", "pss10")], "Mantenha um ajuste que funcione para você.", "Que ritmo pareceu possível?")
            ]),
        new(
            CourseIds.HabitMaintenance,
            "Um hábito ao qual você pode voltar",
            "Cinco dias para escolher um sinal, facilitar o começo e retomar com gentileza depois de uma pausa.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Escolha uma ação", 4, [P("Comece com uma ação pequena, sob seu controle, que apoie o bem-estar no dia a dia. Não escolha vários objetivos de uma vez."), See(ArticleIds.HabitFormation, "Criar um hábito: uma ação pequena e um sinal"), TestsTab("O WHO-5 é uma triagem breve do bem-estar nas últimas duas semanas, não um diagnóstico nem uma medida de força de vontade.", "who5")], "Nomeie uma ação que gostaria de repetir.", "Por que esse passo combina com sua vida agora?"),
                new("Associe a um sinal", 4, [P("Escolha um acontecimento regular que lembre você de começar, como depois do café da manhã ou ao chegar em casa."), Practice(TechniqueId.ImplementationIntention, "Plano «se… então…»"), Quiz("Qual plano será mais fácil de lembrar no momento certo?", 1, "Um sinal específico e uma ação pequena ajudam a começar sem esperar por um humor especial.", "Um dia vou me dedicar mais a isso", "Depois do café da manhã, vou escrever uma frase", "Vou começar quando estiver motivado")], "Complete: Depois de …, vou …", "Que sinal regular já existe no seu dia?"),
                new("Facilite o começo", 4, [P("Remova um pequeno obstáculo: deixe algo preparado, abra o arquivo ou escolha um lugar. O primeiro passo pode levar apenas alguns minutos."), List("Preparar o que será necessário", "Reduzir a duração ou a quantidade", "Escolher um lugar ou horário mais conveniente")], "Torne o início um passo mais fácil.", "O que dificultava e o que você mudou?"),
                new("Planeje como retomar", 4, [P("Um dia sem fazer a ação informa o que aconteceu; não prova fracasso. Você não precisa dobrar o esforço nem se criticar: pode voltar na próxima oportunidade adequada."), Practice(TechniqueId.HabitRestartPlan, "Retomar com gentileza"), Quiz("Você deixou de fazer sua ação habitual. O que pode ajudar a retomá-la sem pressão extra?", 1, "O próximo sinal adequado e uma etapa menor ajudam a continuar sem punição nem compensação.", "Fazer o dobro amanhã", "Retomar no próximo sinal e começar pequeno", "Abandonar o plano para sempre")], "Escolha um sinal para voltar e a versão mais fácil da ação.", "Como continuar sem tentar compensar tudo?"),
                new("Mantenha o que funciona", 4, [P("Trate o plano como um experimento: repita, reduza a ação, mude o sinal ou faça uma pausa. Se quiser, repita o WHO-5; uma mudança na pontuação não prova que o curso a causou."), TestsTab("O WHO-5 é uma triagem do bem-estar, não um diagnóstico. Comparar resultados não identifica a causa de uma mudança.", "who5")], "Mantenha um ajuste que queira experimentar depois.", "O que foi viável e o que você gostaria de mudar?")
            ]),
        new(
            CourseIds.FeedbackResponse,
            "Responder ao feedback sem autocrítica",
            "Quatro etapas breves: separar fatos de rótulos, esclarecer expectativas e escolher uma resposta que respeite seus limites.",
            "Forum", "who5", "WHO-5",
            [
                new("Perceba a primeira reação", 4, [P("As palavras podem machucar. Você não precisa concordar, discutir ou se justificar imediatamente. Primeiro, note o que ouviu e como isso repercutiu."), See(ArticleIds.Feedback, "Feedback sem rótulos"), TestsTab("O WHO-5 aborda o bem-estar geral nas últimas duas semanas; não é diagnóstico nem mede como você recebeu feedback.", "who5")], "Escolha uma frase que dê tempo para pensar.", "O que você poderia dizer para não responder no calor do momento?"),
                new("Peça detalhes", 4, [P("Pedir um exemplo pode mostrar o que dá para mudar. Esclareça o prazo, o critério ou a situação sem prometer aceitar tudo o que foi dito."), Practice(TechniqueId.FeedbackReview, "Organizar o feedback")], "Anote uma pergunta que esclareça a expectativa.", "O que ainda está vago demais?"),
                new("Escolha a parte útil", 4, [P("Você pode considerar um comentário específico, esclarecer o que está em dúvida e recusar um rótulo. A meta é escolher o próximo passo, não provar seu valor."), Warning("Ameaças, humilhação, discriminação ou pressão pedem limites e apoio, não autocrítica.")], "Escolha um ponto que você queira conferir ou conversar.", "O que posso influenciar e o que não preciso aceitar?"),
                new("Encerre com um próximo passo", 4, [P("Combine uma ação ou um momento para rever o assunto. Se não houver acordo, anote os fatos e consulte alguém de confiança ou as regras da organização."), Quiz("Qual resposta ajuda mais a esclarecer o que fazer depois?", 1, "Uma pergunta específica esclarece a expectativa; uma pausa deixa espaço para escolher a resposta.", "Concordar com tudo para encerrar a conversa.", "Pedir um exemplo ou critério e responder mais tarde.", "Decidir que um erro define a pessoa inteira."), TestsTab("Uma reação forte não prova que as palavras são verdadeiras. O WHO-5 é uma triagem geral de bem-estar, não um teste sobre feedback; uma mudança na pontuação não prova o efeito do curso.", "who5")], "Experimente uma pergunta ou resposta que respeite seus limites.", "Que pequeno passo você escolhe?")
            ]),
        new(
            CourseIds.ConnectionWithoutPressure,
            "Criar vínculos no seu ritmo",
            "Cinco passos pequenos para identificar o vínculo que você deseja, escolher um formato seguro e convidar sem pressão.",
            "Group", "who5", "WHO-5",
            [
                new("Nomeie o tipo de contato que você quer", 4, [P("Às vezes, você quer conversar; em outras, fazer algo junto, ter companhia tranquila ou receber ajuda prática. Não precisa alcançar um número de contatos."), See(ArticleIds.Loneliness, "A solidão"), TestsTab("O WHO-5 é uma triagem geral do bem-estar nas últimas duas semanas, não uma medida de solidão nem um diagnóstico. Uma mudança na pontuação, sozinha, não prova o efeito do curso.", "who5")], "Escolha um tipo de contato que seria útil agora.", "O que significa uma conexão confortável para mim?"),
                new("Escolha um formato seguro", 4, [P("Pense com quem e como você se sente mais seguro: a sós, em grupo, on-line ou por uma mensagem breve. Uma pausa também é uma opção; não procure alguém perto de quem não se sente seguro.")], "Nomeie uma pessoa, grupo ou formato que pareça seguro o bastante.", "Que formato facilitaria começar?"),
                new("Convide sem pressionar", 4, [P("Um convite breve e específico é mais fácil de aceitar ou recusar. Deixe a outra pessoa escolher o horário ou dizer não."), See(ArticleIds.SupportRequest, "Como pedir apoio"), Practice(TechniqueId.ConnectionStepPlan, "Planejar um contato pequeno")], "Escreva um convite para uma caminhada curta, conversa ou atividade em comum.", "Como posso deixar a outra pessoa livre para escolher?"),
                new("Deixe espaço para ajustar", 4, [P("Comece num horário conveniente e com uma forma simples de encerrar. Se estiver com pouca energia, reduza ou adie o plano. Uma resposta ou a falta dela não define seu valor."), Practice(TechniqueId.ConnectionStepPlan, "Planejar um contato pequeno")], "Escolha um formato simples e decida quando poderia encerrar ou remarcar.", "Como vou me apoiar se os planos mudarem?"),
                new("Reflita sem se julgar", 4, [P("Note se o contato pareceu seguro e agradável e se gostaria de repetir ou mudar o formato. Não avalie seu valor pelo número de mensagens nem pela reação de alguém."), Quiz("O que vale notar depois de um contato pequeno?", 0, "É útil avaliar o formato e a própria experiência. A resposta de outra pessoa não mede seu valor.", "Foi seguro e confortável, e o que posso ajustar?", "Quantas mensagens recebi em uma hora?", "A falta de resposta prova que ninguém quer me ver?"), TestsTab("O WHO-5 é uma triagem geral do bem-estar nas últimas duas semanas, não uma medida de solidão nem um diagnóstico. Uma mudança na pontuação, sozinha, não prova o efeito do curso.", "who5")], "Escolha um formato que queira experimentar ou ajustar.", "Que pequeno passo combina comigo agora?")
            ]),
        new(
            CourseIds.Boundaries,
            "Comunicar limites",
            "Quatro passos breves para reconhecer seus limites, expressá-los com clareza e escolher uma resposta segura.",
            "Forum", "who5", "WHO-5",
            [
                new("O que importa para mim", 4, [P("Comunicar-se com assertividade é expressar o que você precisa e respeitar o direito da outra pessoa de responder. Isso não garante concordância e nunca é uma obrigação."), H("Três formas de responder"), List("Ficar em silêncio mesmo discordando", "Pressionar ou insultar de volta", "Dizer com calma sua posição e seu pedido"), Quiz("Qual resposta é assertiva?", 2, "Uma frase clara e tranquila expressa sua posição e deixa a outra pessoa livre para responder.", "Concordar mesmo sem querer", "Falar mais alto até a pessoa concordar", "Dizer: «Hoje não posso. Podemos conversar outro dia?»"), TestsTab("WHO-5 é uma triagem geral de bem-estar nas últimas duas semanas, não uma medida de assertividade nem um diagnóstico.", "who5"), Crisis("Preciso de ajuda agora")], "Perceba uma situação segura em que gostaria de colocar um limite. Você não precisa agir ainda.", "O que é importante para você nessa situação?"),
                new("Dizer não com clareza", 4, [P("Uma recusa pode ser breve e educada. Você não precisa se explicar em detalhes. Se fizer sentido para você, pode sugerir outra opção, mas não é obrigatório."), List("«Agora não consigo»", "«Não posso assumir isso»", "«Preciso pensar. Respondo amanhã»"), P("Se a pessoa insistir, repita com calma sua frase principal. Você não precisa provar que seu motivo é válido o bastante.")], "Prepare uma frase de recusa para uma situação cotidiana de baixo risco.", "Quais palavras parecem naturais para você?"),
                new("Fazer um pedido específico", 4, [P("Um pedido específico é mais fácil de entender do que uma indireta ou acusação. Diga qual é a situação, o que importa para você e uma opção possível."), Quiz("Qual pedido é mais claro?", 1, "Um pedido específico descreve uma ação e um momento sem presumir as intenções da outra pessoa.", "«Você nunca me escuta»", "«Quando puder, você pode me ouvir por dez minutos?»", "Não dizer nada e esperar que a pessoa adivinhe"), P("A outra pessoa pode aceitar, propor um acordo ou recusar. Você continua tendo o direito de pedir e escolher seu próximo passo.")], "Escreva ou pense em um pedido breve.", "O que você poderia deixar mais específico?"),
                new("Escolher um próximo passo seguro", 4, [P("Comece por uma situação de menor risco e pense no que poderia fazer diante de respostas diferentes. Você pode adiar ou encerrar a conversa, ou ter alguém de apoio por perto."), P("Se falar diretamente puder levar a ameaças, violência, punição ou mais controle, não pratique sozinho. Priorize sua segurança e procure uma pessoa ou serviço de confiança."), TestsTab("WHO-5 avalia o bem-estar geral, não a habilidade de estabelecer limites. Uma mudança na pontuação não comprova o efeito do curso.", "who5")], "Escolha um passo seguro: dizer a frase, buscar apoio ou não mudar nada por enquanto.", "Qual seria um próximo passo cuidadoso com você?")
            ]),
        new(
            CourseIds.WorkRecovery,
            "Recuperar-se após o trabalho",
            "Quatro dias para perceber o que ajuda a se desligar, escolher um descanso possível e cuidar do tempo fora do trabalho.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("O que me ajuda a recuperar", 4, [P("Cada pessoa descansa de um jeito. A pesquisa estuda se afastar dos pensamentos de trabalho, relaxar, fazer algo envolvente e escolher o próprio ritmo ou horário. São opções, não uma lista obrigatória."), H("Ideias para experimentar"), List("Uma pausa tranquila ou descanso", "Uma atividade envolvente ou que ensine algo novo", "Tempo com outras pessoas ou sozinho", "Movimento leve, se fizer bem a você"), TestsTab("PSS-10 mede o estresse percebido no último mês. Não diagnostica esgotamento nem mede recuperação do trabalho.", "pss10"), Crisis("Preciso de ajuda agora")], "Perceba uma forma de descanso que às vezes ajuda ou parece possível.", "O que ajuda você a mudar o foco, mesmo um pouco?"),
                new("Encerrar o expediente com calma", 4, [P("Tarefas pendentes podem continuar ocupando a atenção. Se puder, escolha um pequeno sinal de fim do trabalho: fechar as abas, anotar o primeiro passo para amanhã ou trocar de roupa."), P("Adapte isso a turnos, plantões e responsabilidades urgentes. Mantenha alertas necessários para sua segurança ou trabalho.")], "Escolha um sinal breve para encerrar o trabalho que caiba na sua rotina.", "O que poderia marcar a passagem para seu tempo pessoal?"),
                new("Escolher descanso sem um plano perfeito", 4, [P("Descansar não precisa virar outra tarefa. Pergunte-se se agora prefere silêncio, companhia, uma atividade envolvente ou não fazer nada."), List("Encurtar uma atividade", "Escolher algo que exija pouca preparação", "Permitir-se mudar de ideia"), P("A pesquisa encontra associações entre algumas experiências de recuperação e bem-estar, mas não promete o mesmo efeito para todos. Observe sua experiência.")], "Experimente uma pausa pequena ou escolha quando poderá voltar a ela.", "O que pareceu agradável, neutro ou inadequado?"),
                new("Proteger um tempo pessoal possível", 4, [P("Nem toda demanda está sob seu controle. Se o trabalho invade o descanso com frequência, você pode conversar sobre prioridades, prazos ou apoio com uma pessoa responsável, colega ou alguém de confiança."), P("Se as condições ainda não podem mudar, isso não é uma falha pessoal. Escolha apenas o que está ao seu alcance: uma pausa, uma atividade curta ou quando voltar a verificar o trabalho."), TestsTab("Repetir o PSS-10 é apenas uma referência geral de estresse. A diferença na pontuação não explica por que houve mudança nem mede o efeito do curso.", "pss10")], "Mantenha um pequeno ajuste que gostaria de experimentar nesta semana.", "O que você quer manter ou mudar em seguida?")
            ]),
        new(
            CourseIds.SelfCompassion,
            "Ser mais gentil consigo após um erro",
            "Quatro passos para notar a autocrítica, separar fatos de rótulos e escolher uma resposta útil.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Perceber a voz crítica", 4, [P("Depois de um erro, a autocrítica pode transformar uma atitude em um rótulo sobre toda a pessoa. Você não precisa discutir com ela nem forçar pensamentos positivos: comece separando o que aconteceu do seu julgamento."), H("Fato e rótulo"), List("Esqueci de responder — um fato", "Sou uma amizade péssima — um rótulo", "O que pode ajudar a reparar isso? — uma pergunta"), TestsTab("WHO-5 é uma triagem geral de bem-estar das últimas duas semanas. Não mede autocompaixão nem comprova o efeito do curso.", "who5"), Crisis("Preciso de ajuda agora")], "Perceba um rótulo autocrítico e tente descrever o ocorrido sem se julgar. Não precisa escrever.", "O que aconteceu quando você tira o rótulo?"),
                new("Falar consigo como falaria com alguém querido", 4, [P("Imagine que alguém próximo cometeu o mesmo erro. Apoiar a si mesmo não é justificar tudo; pode ajudar a ver a situação por inteiro e escolher um próximo passo."), Quiz("Qual resposta é gentil e honesta?", 2, "Ela reconhece o erro sem atacar a pessoa e aponta um passo concreto.", "Você sempre estraga tudo", "Isso não importa de jeito nenhum", "Você errou em uma coisa; vamos ver o que dá para reparar")], "Diga a si mesmo uma frase verdadeira sem se diminuir.", "Como essa frase soa?"),
                new("Reparar o possível sem se punir", 4, [P("Ser gentil consigo pode andar junto com responsabilidade. Você pode reconhecer o impacto e reparar o que for possível sem transformar um erro em condenação de toda a sua pessoa."), List("O que aconteceu exatamente?", "Quem ou o que foi afetado?", "Que pequeno passo pode ajudar agora?"), P("Nem tudo pode ser reparado de imediato. Ainda assim, você pode aprender e pedir conselho a alguém de confiança.")], "Escolha uma ação possível para reparar ou apoiar.", "O que está ao seu alcance agora?"),
                new("Planejar um próximo passo gentil", 4, [P("Faça um plano curto para a próxima vez: notar a autocrítica, pausar e escolher uma ação útil. Mude o plano se ele não servir."), TestsTab("Repetir WHO-5 oferece apenas uma referência geral de bem-estar. A diferença na pontuação não mede autocompaixão nem comprova o efeito do curso.", "who5")], "Guarde uma frase ou ação à qual possa voltar.", "O que gostaria de tentar da próxima vez?")
            ]),
        new(
            CourseIds.SupportSomeone,
            "Apoiar alguém sem pressionar",
            "Quatro passos para perguntar, ouvir, oferecer ajuda possível e buscar mais apoio se necessário.",
            "Group", "pss10", "PSS-10",
            [
                new("Começar com uma pergunta simples", 4, [P("Escolha um momento e local tranquilos, se for seguro. Pergunte se a pessoa quer conversar; você não precisa adivinhar nem insistir."), List("Como você está agora?", "Quer conversar ou prefere só ter companhia?", "Há algo que eu possa fazer para ajudar?"), TestsTab("PSS-10 avalia o estresse percebido no último mês. Não mede habilidade de apoio nem avalia a condição de outra pessoa.", "pss10"), Crisis("Preciso de ajuda agora")], "Pense em uma pergunta aberta e sem pressão. Não precisa fazê-la agora.", "Como mostrar que a pessoa pode recusar a conversa?"),
                new("Ouvir sem correr para resolver", 4, [P("Deixe a pessoa terminar e aceite as pausas. Confira se entendeu, em vez de aconselhar, comparar ou dar um diagnóstico de imediato."), Quiz("Qual resposta deixa mais espaço para a pessoa?", 1, "Uma pergunta aberta permite que ela escolha o que quer compartilhar.", "Você só precisa se distrair", "O que está mais difícil agora?", "Já passei por isso e sei o que você deve fazer")], "Resuma com suas palavras o que ouviu e pergunte se entendeu corretamente.", "O que muda quando você não se apressa para aconselhar?"),
                new("Oferecer opções de ajuda", 4, [P("O apoio pode ser simples e concreto. Pergunte o que seria mais útil: ouvir, ajudar em uma tarefa ou buscar informações juntos. Ofereça apenas o que realmente pode fazer."), List("Quer que eu escute?", "Posso ajudar em algo específico?", "Quer pensar comigo em quem procurar?"), P("Se a pessoa disser não, respeite. Você pode deixar aberta a possibilidade de conversar outra hora.")], "Com a permissão dela, ofereça uma ajuda concreta ou pense em uma opção para outro momento.", "Que ajuda é possível para vocês dois?"),
                new("Buscar apoio e respeitar seus limites", 4, [P("Você pode estar presente sem resolver tudo sozinho nem ser a única fonte de apoio. Diga com clareza quando está disponível e sugira envolver alguém de confiança ou um profissional."), P("Se a pessoa falar de perigo imediato ou não conseguir se manter em segurança, não assuma isso sozinho: se possível, procure os serviços locais de emergência ou crise. Não prometa guardar em segredo uma ameaça à vida."), TestsTab("Repetir PSS-10 é apenas uma referência geral de estresse percebido; não avalia seu apoio nem comprova o efeito do curso.", "pss10")], "Escolha um limite ou apoio adicional para não carregar essa situação sozinho.", "Quem também poderia apoiar você?")
            ]),
        new(
            CourseIds.TaskStart,
            "Começar uma tarefa que venho adiando",
            "Três passos: tornar o início menor, escolher um horário e continuar sem se culpar.",
            "Checklist", "who5", "WHO-5",
            [
                new("Escolher uma tarefa", 3, [P("Adiar algo costuma ter a ver com um começo pouco claro ou um sentimento desconfortável, não com preguiça. Dê nome à tarefa e ao primeiro passo visível."), TestsTab("WHO-5 é uma triagem geral de bem-estar das últimas duas semanas. Não mede esta habilidade nem comprova o efeito do curso.", "who5"), Crisis("Preciso de ajuda agora")], "Escolha uma tarefa e um passo inicial de até cinco minutos.", "O que deixaria o começo mais claro?"),
                new("Facilitar o início", 3, [P("Deixe o necessário preparado e escolha um horário. Comece por cinco minutos e depois decida se quer continuar.")], "Anote quando, onde e como vai começar.", "O que pode atrapalhar e como simplificar?"),
                new("Apoiar a continuação", 3, [P("Revise sem se culpar: o que ajudou, o que dificultou e o que é realista agora? Às vezes, vale ajustar a própria tarefa.")], "Guarde uma forma de começar que tenha ajudado.", "O que você aprendeu sobre como começa?")
            ]),
        new(
            CourseIds.FlexibleStandards,
            "O suficiente também pode ser bom",
            "Perceba quando padrões altos ajudam e quando dificultam concluir.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Ver o custo do perfeito", 3, [P("Padrões altos ajudam enquanto não tiram tempo demais, descanso ou a chance de terminar. Note uma regra que você impõe a si mesmo."), TestsTab("WHO-5 é uma triagem geral de bem-estar das últimas duas semanas. Não mede esta habilidade nem comprova o efeito do curso.", "who5"), Crisis("Preciso de ajuda agora")], "Escolha um exemplo em que um padrão esteja atrapalhando.", "O que essa regra oferece e o que custa?"),
                new("Definir o suficiente", 3, [P("Pergunte quem precisa do resultado e o que ele realmente precisa cumprir. Escolha dois ou três critérios em vez de aperfeiçoar sem fim.")], "Defina um limite realista para concluir uma tarefa.", "O que você pode parar de melhorar?"),
                new("Testar uma pequena mudança", 3, [P("Se for seguro para você, deixe uma pequena imperfeição ou pare quando o timer tocar. É um experimento, não uma obrigação de descuidar da qualidade.")], "Escolha um experimento gentil ou apenas observe a regra.", "O que você esperava e o que aconteceu?")
            ]),
        new(
            CourseIds.ThoughtLoops,
            "Quando os pensamentos ficam em círculo",
            "Note pensamentos repetidos e traga a atenção de volta ao que você escolhe fazer.",
            "Psychology", "gad7", "GAD-7",
            [
                new("Perceber o ciclo", 3, [P("Um pensamento repetido pode parecer uma tentativa de resolver algo, mas nem sempre traz uma resposta nova. Note quando ele volta e o que o inicia."), TestsTab("GAD-7 avalia a ansiedade geral das últimas duas semanas; não é diagnóstico nem teste desta habilidade.", "gad7"), Crisis("Preciso de ajuda agora")], "Perceba um momento em que um pensamento fica em círculo.", "O que costuma iniciar esse ciclo?"),
                new("Separar pensamento e fato", 3, [P("Dê um nome a ele como pensamento: “Percebo o pensamento de que…”. Isso não nega o problema; evita tratar uma previsão como fato.")], "Nomeie um pensamento de modo neutro, sem discutir com ele.", "O que muda quando você o chama de pensamento?"),
                new("Voltar ao que escolheu", 3, [P("Você não precisa expulsar o pensamento. Note-o e volte com gentileza à atividade; se precisar de um plano, escolha um horário e um passo.")], "Escolha uma ação pequena para os próximos dez minutos.", "Para onde você quer levar sua atenção?")
            ]),
        new(
            CourseIds.UncertainDecisions,
            "Decidir sem ter certeza completa",
            "Compare os fatos, o que importa para você e um próximo passo possível.",
            "Checklist", "gad7", "GAD-7",
            [
                new("Separar fatos e suposições", 3, [P("Em uma escolha difícil, talvez faltem informações. Anote o que sabe, o que supõe e o que ainda não pode saber."), TestsTab("GAD-7 avalia a ansiedade geral das últimas duas semanas; não é diagnóstico nem teste desta habilidade.", "gad7"), Crisis("Preciso de ajuda agora")], "Separe uma questão em fatos e suposições.", "Qual fato seria mais útil esclarecer?"),
                new("Nomear prioridades", 3, [P("Compare opções pelo que importa para você: segurança, tempo, relações, recursos ou valores. Talvez não exista uma escolha perfeita.")], "Escolha dois critérios importantes e compare as opções.", "O que você quer preservar acima de tudo?"),
                new("Escolher o próximo passo", 3, [P("Se possível, escolha um passo pequeno e reversível e uma data para rever a decisão. Assim você deixa espaço para novas informações.")], "Defina um passo e quando vai reavaliá-lo.", "Como você poderia conferir essa escolha depois?")
            ]),
        new(
            CourseIds.PauseBeforeReply,
            "Fazer uma pausa antes de responder",
            "Note a tensão, faça uma pausa e decida se responde agora.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Perceber a tensão cedo", 3, [P("Irritação ou preocupação pode aparecer no corpo ou no ritmo da fala antes de você pensar na resposta. Note seu sinal inicial."), TestsTab("PSS-10 avalia o estresse percebido no último mês. Não mede esta habilidade nem comprova o efeito do curso.", "pss10"), Crisis("Preciso de ajuda agora")], "Lembre-se de um sinal corporal ou de comportamento.", "Como você percebe que precisa desacelerar?"),
                new("Fazer uma pausa curta", 3, [P("Se for seguro, adie a resposta, sinta os pés no chão e nomeie o que está acontecendo. Você não precisa se obrigar a ficar calmo imediatamente.")], "Prepare uma frase: “Preciso de um pouco de tempo; respondo depois.”", "Que pausa seria realista para você?"),
                new("Responder com intenção", 3, [P("Escolha seu objetivo: esclarecer, pedir, estabelecer um limite ou encerrar a conversa. Se não for seguro, saia e procure apoio.")], "Prepare uma frase que expresse seu objetivo.", "O que você quer que a outra pessoa entenda?")
            ]),
        new(
            CourseIds.IrritationSignals,
            "Perceber a irritação mais cedo",
            "Reconheça sinais iniciais, reduza a tensão e escolha uma resposta segura.",
            "Forum", "pss10", "PSS-10",
            [
                new("Encontrar um sinal inicial", 3, [P("A irritação pode sinalizar tensão ou uma necessidade, mas não é uma ordem para agir. Note mudanças no corpo, nos pensamentos ou no comportamento."), TestsTab("PSS-10 avalia o estresse percebido no último mês. Não mede esta habilidade nem comprova o efeito do curso.", "pss10"), Crisis("Preciso de ajuda agora")], "Nomeie um sinal inicial.", "O que costuma acontecer antes de a irritação aumentar?"),
                new("Reduzir a tensão com segurança", 3, [P("Se puder, vá para um lugar seguro e desacelere a respiração ou observe o que está ao redor. Você não precisa continuar uma discussão.")], "Escolha uma forma segura de fazer uma pausa.", "Como vai saber que precisa parar?"),
                new("Escolher o que vem depois", 3, [P("Quando a intensidade diminuir, nomeie sua necessidade: tempo, clareza, ajuda ou um limite. Você pode voltar depois ou não, se não for seguro.")], "Prepare um pedido ou uma ação para outra vez.", "O que ajudaria você a não chegar ao limite?")
            ]),
        new(
            CourseIds.ConflictRepair,
            "Reconectar depois de uma discussão",
            "Assuma sua parte, peça desculpas sem pressionar e converse sobre o próximo passo.",
            "Forum", "who5", "WHO-5",
            [
                new("Descrever a ação, não rotular a pessoa", 3, [P("Depois de uma discussão, nomeie uma ação específica em vez de definir alguém como ruim. Retomar o contato só é uma opção se for seguro."), TestsTab("WHO-5 é uma triagem geral de bem-estar das últimas duas semanas. Não mede esta habilidade nem comprova o efeito do curso.", "who5"), Crisis("Preciso de ajuda agora")], "Descreva sua parte com um fato.", "O que você gostaria de esclarecer?"),
                new("Pedir desculpas com clareza", 3, [P("Um pedido de desculpas nomeia a ação e seu possível impacto, sem desculpas nem exigência de perdão. Você pode dizer o que tentará fazer diferente.")], "Escreva um pedido curto sem acrescentar “mas”.", "Pelo que você está disposto a se responsabilizar?"),
                new("Dar espaço para a resposta", 3, [P("Deixe a outra pessoa responder e estabelecer limites. A reconciliação não é garantida; às vezes, basta combinar um próximo passo prático.")], "Escolha um pedido ou limite para conversar.", "Que resultado seria aceitável e seguro?")
            ]),
        new(
            CourseIds.LifeTransitions,
            "Adaptar-se às mudanças no seu ritmo",
            "Mantenha apoios conhecidos, nomeie o que mudou e escolha um passo possível.",
            "TrackChanges", "pss10", "PSS-10",
            [
                new("Nomear o que mudou", 3, [P("Um novo trabalho, mudança de casa, estudo ou mudança na família pode afetar várias rotinas. Você não precisa se adaptar depressa."), TestsTab("PSS-10 avalia o estresse percebido no último mês. Não mede esta habilidade nem comprova o efeito do curso.", "pss10"), Crisis("Preciso de ajuda agora")], "Nomeie uma mudança e o efeito dela no seu dia.", "O que está mais difícil ou diferente agora?"),
                new("Manter um apoio conhecido", 3, [P("Preserve uma rotina simples que sustente seu ritmo: horário de refeição, caminhada curta, conversa ou ritual à noite. Adapte às novas condições.")], "Escolha um apoio conhecido para esta semana.", "O que pode continuar mesmo com a mudança?"),
                new("Dar o próximo passo", 3, [P("Divida a adaptação em perguntas pequenas: o que aprender, a quem pedir ajuda, o que pode esperar. Seu ritmo pode mudar.")], "Escolha uma pergunta ou ação para os próximos dias.", "Que apoio tornaria a mudança mais fácil?")
            ]),
        new(
            CourseIds.GriefAtYourPace,
            "Viver o luto no seu ritmo",
            "Sem prazos ou etapas obrigatórias: cuide de necessidades básicas e encontre apoio.",
            "Healing", "who5", "WHO-5",
            [
                new("Dar espaço ao que sente", 3, [P("Depois de uma perda, cada pessoa sente coisas diferentes. O luto não tem prazo obrigatório nem uma única forma correta de ser vivido."), TestsTab("WHO-5 é uma triagem geral de bem-estar das últimas duas semanas. Não mede esta habilidade nem comprova o efeito do curso.", "who5"), Crisis("Preciso de ajuda agora")], "Nomeie o que está mais difícil ou o que ainda não quer fazer.", "O que você gostaria de se permitir hoje?"),
                new("Tornar o dia possível", 3, [P("Em um dia difícil, escolha uma necessidade básica ou uma tarefa pequena. Você pode pedir a alguém próximo que fique com você ou ajude em algo prático.")], "Reduza uma tarefa a um passo possível.", "De que cuidado você precisa hoje?"),
                new("Não passar por isso sozinho", 3, [P("Se quiser, encontre uma forma de lembrar ou falar sobre a perda. Se o luto continuar dificultando a rotina por muito tempo, buscar ajuda profissional é uma opção.")], "Escolha uma pessoa ou serviço que poderia procurar.", "Que apoio seria acolhedor agora?")
            ]),
        new(
            CourseIds.ReturnToFocus,
            "Voltar ao foco depois de uma interrupção",
            "Registre a distração, escolha a próxima ação e retome com gentileza.",
            "TipsAndUpdates", "who5", "WHO-5",
            [
                new("Perceber a interrupção", 3, [P("Distrações fazem parte do trabalho. Note o que tirou sua atenção: notificação, pensamento novo, cansaço ou passo pouco claro."), TestsTab("WHO-5 é uma triagem geral de bem-estar das últimas duas semanas. Não mede esta habilidade nem comprova o efeito do curso.", "who5"), Crisis("Preciso de ajuda agora")], "Nomeie uma fonte frequente de interrupção.", "O que mais costuma interromper seu foco?"),
                new("Anotar e voltar", 3, [P("Anote brevemente a tarefa que distraiu você para não ter de mantê-la na cabeça. Depois, escolha uma ação para retomar a tarefa atual.")], "Faça uma anotação e escolha uma ação de cinco minutos.", "Qual primeiro passo levaria você de volta?"),
                new("Facilitar o ambiente", 3, [P("Remova uma distração opcional e decida o que fazer na próxima interrupção. Se o cansaço estiver forte, uma pausa pode ajudar mais que insistir.")], "Mude um ajuste no espaço ou nas notificações.", "O que ajuda você a recomeçar sem se culpar?")
            ]),
        new(
            CourseIds.StudyBlocks,
            "Estudar em blocos curtos",
            "Escolha uma meta de aprendizagem, um foco breve e uma pausa para recuperar.",
            "Checklist", "pss10", "PSS-10",
            [
                new("Definir uma meta de estudo", 3, [P("Escolha um resultado claro para um bloco: resolver um exercício, ler uma seção curta ou explicar um tema. A meta maior pode esperar."), TestsTab("PSS-10 avalia o estresse percebido no último mês. Não mede esta habilidade nem comprova o efeito do curso.", "pss10"), Crisis("Preciso de ajuda agora")], "Anote um resultado para uma sessão curta.", "Como saberá que esse bloco terminou?"),
                new("Encontrar seu ritmo", 3, [P("Escolha um tempo de foco e de pausa que combine com você. Um timer padrão é opcional; ajuste à sua atenção e saúde.")], "Experimente um bloco curto e depois uma pausa.", "Que ritmo pareceu possível?"),
                new("Conferir o que ficou", 3, [P("Depois da pausa, tente lembrar o principal sem olhar e então confira o material. Uma lacuna mostra o que rever, não o seu valor.")], "Nomeie três coisas de que se lembra.", "O que você poderia rever em seguida?")
            ]),
        new(
            CourseIds.BodyNeutrality,
            "Olhar para a aparência com mais neutralidade",
            "Reduza comparações, observe sem julgar e volte às atividades importantes.",
            "Healing", "who5", "WHO-5",
            [
                new("Notar a atenção à aparência", 3, [P("Muitas pessoas ficam insatisfeitas com a aparência às vezes, mas checar e comparar repetidamente pode consumir energia. Você não precisa amar cada traço."), TestsTab("WHO-5 é uma triagem geral de bem-estar das últimas duas semanas. Não mede esta habilidade nem comprova o efeito do curso.", "who5"), Crisis("Preciso de ajuda agora")], "Note quando pensamentos sobre aparência ocupam sua atenção.", "O que você adia por causa desses pensamentos?"),
                new("Experimentar um olhar neutro", 3, [P("Em vez de julgar, descreva o que percebe ou o que seu corpo permite fazer hoje. Você não precisa sentir gratidão ou satisfação.")], "Troque um julgamento por uma observação neutra.", "Que palavras parecem menos duras e mais precisas?"),
                new("Voltar ao que importa", 3, [P("Escolha uma atividade importante por outros motivos: vínculo, estudo, descanso ou lazer. Se a preocupação afetar alimentação, saúde ou rotina, um profissional pode ajudar.")], "Retome uma pequena atividade adiada.", "O que importa para você além da aparência?")
            ]),
        new(
            CourseIds.SelfWorth,
            "Seu valor vai além das conquistas",
            "Perceba seus papéis e qualidades fora dos resultados e escolha uma ação significativa.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Ver além dos resultados", 3, [P("Trabalho e sucesso são parte da vida, não medem todo o seu valor. Lembre-se de papéis, relações e qualidades importantes, mesmo sem produtividade."), TestsTab("WHO-5 é uma triagem geral de bem-estar das últimas duas semanas. Não mede esta habilidade nem comprova o efeito do curso.", "who5"), Crisis("Preciso de ajuda agora")], "Nomeie um papel ou qualidade importante para você.", "O que tem valor em você sem um resultado?"),
                new("Encontrar um exemplo concreto", 3, [P("Lembre-se de um pequeno gesto de gentileza, coragem, curiosidade ou confiança. Um exemplo basta; você não precisa provar que é sempre assim.")], "Encontre um exemplo recente.", "O que você costuma não perceber em si?"),
                new("Agir de acordo com o que importa", 3, [P("Escolha uma ação que expresse uma qualidade importante para você, sem depender de conquista ou elogio. Pode ser pequena.")], "Faça ou planeje uma ação assim.", "O que esse passo mostra sobre suas prioridades?")
            ]),
        new(
            CourseIds.SocialSteps,
            "Dar pequenos passos em situações sociais",
            "Escolha um contato seguro, reveja expectativas e avance no seu ritmo.",
            "Group", "gad7", "GAD-7",
            [
                new("Escolher uma situação possível", 3, [P("Se situações sociais preocupam você, comece por uma que pareça um pouco desafiadora e segura. Você pode recusar um passo que não combine com você."), TestsTab("GAD-7 avalia a ansiedade geral das últimas duas semanas; não é diagnóstico nem teste desta habilidade.", "gad7"), Crisis("Preciso de ajuda agora")], "Escolha um contato breve que seja importante.", "O que parece possível, em vez de perfeito?"),
                new("Rever uma expectativa", 3, [P("Antes do contato, anote o que teme e o que mais poderia acontecer. Você não precisa provar que o medo está errado; deixe espaço para outros resultados.")], "Anote uma expectativa e uma alternativa.", "O que você percebeu durante o contato?"),
                new("Aprender com a experiência", 3, [P("Depois, anote o que ajudou, o que foi difícil e qual próximo passo combina com você. Você escolhe o ritmo, as repetições e as pausas.")], "Escolha repetir, reduzir ou pausar o passo.", "O que ajudou você a se sentir mais seguro?")
            ]),
        new(
            CourseIds.AppointmentPreparation,
            "Preparar-se para uma consulta importante",
            "Reúna perguntas, defina sua prioridade e esclareça próximos passos com um profissional.",
            "Forum", "pss10", "PSS-10",
            [
                new("Nomear o principal", 3, [P("Antes da consulta, decida qual pergunta importa mais e o que quer conversar. Você não precisa se diagnosticar antes."), TestsTab("PSS-10 avalia o estresse percebido no último mês. Não mede esta habilidade nem comprova o efeito do curso.", "pss10"), Crisis("Preciso de ajuda agora")], "Escreva o tema principal em uma frase.", "O que não quer esquecer de perguntar?"),
                new("Preparar notas curtas", 3, [P("Se ajudar, anote quando a preocupação começou, o que mudou e quais remédios ou dúvidas importam. Você pode levar alguém se quiser.")], "Prepare até três perguntas ou observações.", "Que anotação facilitaria a conversa?"),
                new("Esclarecer o plano", 3, [P("Peça ao profissional que explique palavras pouco claras e o próximo passo. Você pode perguntar de novo ou dizer que ainda não está pronto para decidir.")], "Prepare uma frase para pedir clareza ou tempo.", "O que ajudaria você a entender o plano?")
            ]),
        new(
            CourseIds.WaitingForAnswer,
            "Passar melhor pela espera de uma resposta",
            "Limite as verificações, mantenha rotinas e escolha o que está ao seu alcance.",
            "Psychology", "gad7", "GAD-7",
            [
                new("Separar espera e controle", 3, [P("Esperar uma resposta pode ocupar a atenção, mesmo sem poder acelerar sua chegada. Separe o que você pode fazer do que não controla."), TestsTab("GAD-7 avalia a ansiedade geral das últimas duas semanas; não é diagnóstico nem teste desta habilidade.", "gad7"), Crisis("Preciso de ajuda agora")], "Anote uma coisa em cada grupo.", "O que você pode fazer e o que precisa esperar?"),
                new("Definir quando conferir", 3, [P("Escolha um horário razoável para verificar mensagens ou status de novo. Entre as verificações, retome uma tarefa comum ou descanse.")], "Defina o próximo horário para conferir.", "O que ajudaria a não verificar por impulso?"),
                new("Preparar-se para as duas opções", 3, [P("Escolha um pequeno próximo passo caso venha uma resposta ou haja atraso. Não é previsão; devolve opções enquanto você espera.")], "Defina uma data para perguntar novamente se necessário.", "Em que você quer se apoiar enquanto espera?")
            ]),
        new(
            CourseIds.AskForHelp,
            "Pedir ajuda concreta",
            "Nomeie do que precisa, a quem poderia pedir e qual pedido seria possível.",
            "Group", "who5", "WHO-5",
            [
                new("Identificar o que você precisa", 3, [P("Um pedido concreto é mais fácil de entender: tempo, conversa, informação ou ajuda em uma tarefa. Você não precisa dar conta de tudo sozinho."), TestsTab("WHO-5 é uma triagem geral de bem-estar das últimas duas semanas. Não mede esta habilidade nem comprova o efeito do curso.", "who5"), Crisis("Preciso de ajuda agora")], "Nomeie uma necessidade sem justificá-la.", "Que ajuda mudaria algo, mesmo que pouco?"),
                new("Escolher pessoa e palavras", 3, [P("Pense em quem poderia ajudar com isso. Um pedido breve, com ação e horário claros, facilita a resposta.")], "Escreva uma frase para pedir ajuda.", "A quem você poderia pedir e quando?"),
                new("Abrir espaço para respostas diferentes", 3, [P("A pessoa pode aceitar, sugerir outra coisa ou recusar. Sua necessidade continua importante; você pode procurar outra pessoa ou serviço.")], "Escolha uma alternativa de apoio.", "Como vai cuidar de si depois de pedir?")
            ]),
        new(
            CourseIds.CaregiverLimits,
            "Cuidar de alguém sem se esquecer de si",
            "Compartilhe tarefas, nomeie limites e encontre apoios adicionais.",
            "Group", "pss10", "PSS-10",
            [
                new("Perceber o volume do cuidado", 3, [P("Apoiar alguém pode envolver muitas tarefas invisíveis. Liste as principais e note quais realmente precisam da sua participação."), TestsTab("PSS-10 avalia o estresse percebido no último mês. Não mede esta habilidade nem comprova o efeito do curso.", "pss10"), Crisis("Preciso de ajuda agora")], "Nomeie uma tarefa que poderia ser conversada ou compartilhada.", "O que mais está esgotando você agora?"),
                new("Nomear um limite", 3, [P("Um limite não é abandonar alguém. É dizer com sinceridade que tempo, energia ou ajuda você pode oferecer com segurança.")], "Formule um limite para o apoio que oferece.", "Como dizê-lo com clareza e calma?"),
                new("Encontrar outros apoios", 3, [P("Pense em pessoas, serviços ou soluções práticas que possam dividir a carga. Se o cuidado não puder ser feito com segurança, busque ajuda profissional ou urgente.")], "Escolha um apoio adicional.", "Quem você poderia contatar esta semana?")
            ]),
        new(
            CourseIds.LowEnergyRoutine,
            "Um plano gentil para dias com pouca energia",
            "Mantenha o mínimo necessário, reduza o primeiro passo e inclua descanso.",
            "TipsAndUpdates", "who5", "WHO-5",
            [
                new("Escolher o mínimo", 3, [P("Em um dia de pouca energia, você não precisa cumprir seu plano habitual. Escolha uma tarefa necessária e o que pode esperar."), TestsTab("WHO-5 é uma triagem geral de bem-estar das últimas duas semanas. Não mede esta habilidade nem comprova o efeito do curso.", "who5"), Crisis("Preciso de ajuda agora")], "Reduza a lista a um item importante.", "O que realmente não pode esperar hoje?"),
                new("Reduzir o primeiro passo", 3, [P("Divida a tarefa em uma ação de dois minutos e deixe o necessário pronto. Se ainda for demais, peça ajuda.")], "Escolha o menor passo seguro.", "O que o deixaria mais fácil?"),
                new("Incluir recuperação", 3, [P("Planeje uma pausa curta sem precisar merecê-la. Se a falta de energia ou o desânimo dificultarem a vida por muito tempo, procure apoio profissional.")], "Escolha uma pausa simples ou alguém para contatar.", "O que ajudaria você a não passar por isso sozinho?")
            ]),
        new(
            CourseIds.AfterDifficultTalk,
            "Recuperar-se depois de uma conversa difícil",
            "Volte ao presente, separe fatos de suposições e escolha um próximo passo seguro.",
            "Psychology", "pss10", "PSS-10",
            [
                new("Diminuir a tensão", 3, [P("Depois de uma conversa difícil, o corpo pode precisar de tempo. Encontre um apoio, olhe ao redor e nomeie onde está. Você não precisa decidir agora quem tinha razão."), TestsTab("PSS-10 avalia o estresse percebido no último mês. Não mede esta habilidade nem comprova o efeito do curso.", "pss10"), Crisis("Preciso de ajuda agora")], "Faça uma pausa curta e observe o ambiente.", "O que ajuda você a se sentir aqui e agora?"),
                new("Separar palavras e conclusões", 3, [P("Anote separadamente o que foi dito ou feito e o que você supõe que significou. Isso não invalida seus sentimentos; ajuda a escolher o próximo passo.")], "Separe um fato de uma interpretação.", "O que você sabe e o que está supondo?"),
                new("Escolher se continua", 3, [P("Você pode esclarecer algo, pedir tempo ou não retomar o contato. Se houver ameaça ou controle, não volte à conversa sozinho.")], "Escolha uma opção segura para outra vez.", "De que limite ou apoio você precisa?")
            ]),
    ];
}
