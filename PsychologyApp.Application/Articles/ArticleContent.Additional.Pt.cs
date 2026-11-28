namespace PsychologyApp.Application.Articles;

public static partial class ArticleContent
{
    private static readonly Article[] AdditionalArticlesPt =
    [
        new(
            ArticleIds.CallNerves,
            "Nervosismo antes de uma ligação",
            "Prepare uma conversa, não uma atuação perfeita",
            "TipsAndUpdates",
            2,
            [
                P("Uma ligação pode dar ansiedade porque há muitas incertezas: quem vai atender, o que pode perguntar e como vai reagir. Escolha um objetivo prático, como marcar um horário, confirmar uma data ou transmitir uma informação. Isso basta; você não precisa ensaiar cada frase."),
                H("Tenha um apoio à mão"),
                P("Anote o nome da pessoa, seu objetivo e uma frase inicial: “Olá, estou ligando para perguntar sobre…”. Deixe datas e perguntas úteis por perto. Você pode pedir para repetirem algo. Se a conversa for difícil, pode dizer: “Preciso de um instante para pensar” ou combinar de continuar depois."),
                H("Depois da ligação"),
                P("Anote o que descobriu e se há um próximo passo. Não se avalie pela fluidez da conversa: pausas e nervosismo não tiram o propósito da ligação. Se não conseguir falar com a pessoa, escolha uma próxima opção: ligar mais tarde, escrever ou pedir ajuda. Se ligações frequentemente impedem tarefas importantes, considere conversar com um profissional adequado.")
            ]),
        new(
            ArticleIds.WaitingForReply,
            "Esperando uma resposta",
            "Lidar com a incerteza e escolher o próximo passo",
            "TipsAndUpdates",
            2,
            [
                P("Enquanto espera uma resposta, é fácil começar a imaginar: “Falei algo errado”, “Estão me ignorando” ou “É urgente”. Mas o silêncio, por si só, não explica por que alguém ainda não respondeu. A pessoa pode estar ocupada, longe do celular, pensando no que dizer ou sem querer responder naquele momento. Até saber mais, tente não tratar uma interpretação como fato."),
                H("Separe o fato da interpretação"),
                P("Por exemplo: a mensagem foi lida, mas não houve resposta. Os fatos são a confirmação de leitura e o horário. Pensar “a relação acabou” é uma explicação possível, não uma prova. Nomeie outras duas possibilidades, incluindo uma neutra. Você não precisa se convencer de que está tudo bem; basta reconhecer que ainda há pouca informação."),
                H("Veja se é preciso agir agora"),
                P("Existe um prazo, uma questão de segurança ou uma consequência que não pode esperar? Se sim, não dependa apenas da resposta no chat: use outro meio de contato adequado, procure alguém que possa ajudar ou, em perigo imediato, os serviços locais de emergência. Se não for urgente, decida quando vai conferir de novo. Não há um intervalo universal; considere a situação e os combinados que vocês fizeram."),
                H("Faça um plano em vez de conferir repetidamente"),
                List(
                    "Diga o que sabe sem tirar conclusões: “Ainda não recebi resposta”.",
                    "Pergunte a si mesmo de qual informação precisa e se há outra forma de obtê-la.",
                    "Escolha o próximo horário para conferir e deixe o chat fora de vista até lá.",
                    "Faça uma tarefa curta que não dependa de uma notificação."),
                P("Se a resposta é importante e o prazo combinado passou, você pode mandar uma mensagem breve, sem acusação: “Você consegue me dizer se poderá responder hoje? Se não, vou me organizar de outro jeito”. Assim, você comunica sua necessidade e deixa espaço para uma resposta sincera."),
                H("Quando isso se repete"),
                P("Observe o padrão, não apenas uma pausa. Em um momento tranquilo, conversem sobre quais prazos de resposta importam para cada um e o que fazer quando alguém não está disponível. Você pode decidir com base no que sabe. O silêncio de outra pessoa não define seu valor, e uma explicação neutra não obriga você a esperar indefinidamente.")
            ]),
        new(
            ArticleIds.AfterSocialEvent,
            "Depois do encontro: não repasse cada frase",
            "Reflita sem transformar a conversa em autocrítica",
            "TipsAndUpdates",
            2,
            [
                P("Depois de um encontro importante, a conversa pode voltar à mente repetidamente. É fácil focar nas pausas, nas frases desajeitadas ou na expressão de alguém e concluir que tudo correu mal. Mas a memória não é uma gravação completa: cansaço, ansiedade e o que parece importante agora influenciam o que fica em destaque."),
                H("Separe o que observou da conclusão"),
                P("Anote um momento específico: o que você realmente disse ou fez? Depois, registre separadamente o julgamento sobre si, como «sou sem graça» ou «ficaram decepcionados». Isso é uma interpretação. Que outras explicações são possíveis? A conversa pode ter terminado cedo, a outra pessoa podia estar com pressa ou o assunto era difícil. Você não precisa escolher a explicação mais positiva; apenas evite tratar a versão ansiosa como comprovada."),
                H("A conversa precisa de um próximo passo?"),
                P("Veja se há uma promessa concreta, uma pergunta ou um erro que realmente precisa de atenção. Se houver, anote a ação e quando voltará ao assunto, como esclarecer um detalhe amanhã. Se não houver, repassar a cena provavelmente não trará informação nova. Você pode dizer a si: «Já conferi o que podia; ainda não há fatos novos»."),
                H("Um jeito breve de encerrar o encontro"),
                List(
                    "Nomeie um momento neutro ou agradável, sem avaliar você por inteiro.",
                    "Se tiver uma pergunta, guarde-a para esclarecer com calma.",
                    "Escolha uma transição para o presente: água, silêncio, uma caminhada ou uma tarefa pequena.",
                    "Se o pensamento voltar, perceba-o e deixe a revisão para o horário escolhido."),
                P("O objetivo não é provar que o encontro foi perfeito. Basta perceber se resta alguma ação útil e permitir que o resto continue incerto. Se essas preocupações atrapalham com frequência suas relações ou seu descanso, converse com um profissional."),
            ]),
        new(
            ArticleIds.FearOfMistakes,
            "Um erro não é uma sentença",
            "Defina o que é bom o suficiente",
            "TipsAndUpdates",
            2,
            [
                P("O medo de errar pode transformar uma tarefa comum em uma prova: conferir tudo várias vezes, esperar ter certeza absoluta ou adiar o começo. A ideia não é tratar erros como algo sem importância. É decidir antes o que importa, qual risco precisa ser verificado e quando é razoável parar."),
                H("Defina o que é suficiente antes de começar"),
                P("Descreva o resultado de forma observável: enviar uma mensagem com as informações necessárias, preparar um rascunho ou cumprir os requisitos essenciais. Depois, pergunte quais seriam as consequências reais de um erro e qual conferência reduziria esse risco. Segurança, saúde, dinheiro e documentos importantes podem exigir regras específicas e revisão cuidadosa; o critério de «bom o suficiente» não substitui isso."),
                H("Quando o erro já aconteceu"),
                P("Separe o acontecimento de um julgamento sobre você. Em vez de «estraguei tudo», nomeie o fato: «o arquivo está com a data errada». Veja quem foi afetado, se é possível corrigir e quem precisa ser avisado. Assumir responsabilidade é dar um passo útil para reparar, não se punir sem parar."),
                H("Uma revisão breve sem se atacar"),
                List(
                    "O que aconteceu, descrito como fatos?",
                    "Qual foi o impacto real e o que ainda estou supondo?",
                    "Que passo pode corrigir ou limitar as consequências?",
                    "O que posso ajustar na próxima vez sem exigir perfeição?"),
                P("Se o medo de errar atrapalha com frequência o trabalho, os estudos ou as relações, considere conversar com um profissional. Isso não significa que há algo errado com você; pode ajudar a encontrar um apoio adequado."),
            ]),
        new(
            ArticleIds.ChangeAnxiety,
            "Quando mudanças preocupam",
            "Separe o que é conhecido, incerto e o que está ao seu alcance",
            "TipsAndUpdates",
            2,
            [
                P("Uma mudança pode preocupar mesmo quando é desejada: a rotina muda e o resultado não está claro. Planejar todas as possibilidades cansa sem tornar o futuro previsível. Separe o que você pode fazer agora das perguntas que ainda não têm resposta."),
                H("Use três colunas"),
                P("Anote o que sabe, o que não sabe e o que pode influenciar. A data da mudança pode estar definida, o trajeto ainda não, e hoje você pode reunir documentos. Investigue uma dúvida primeiro se a resposta mudar sua próxima decisão."),
                H("Escolha o próximo passo útil"),
                P("Que ação pequena ajudaria nas próximas 24 horas: confirmar um prazo, preparar algo, conversar com alguém envolvido ou reservar tempo para descansar? Se nada puder ser feito agora, marque um horário para retomar. Isso não promete um resultado, mas evita carregar a questão o dia inteiro."),
                List(
                    "Nomeie o que realmente mudou.",
                    "Escolha uma dúvida que afete uma decisão.",
                    "Defina uma ação ou quando vai conferir de novo.",
                    "Deixe o restante em aberto até surgirem novos dados."),
                P("Se a mudança envolve perigo ou consequências graves, confirme os fatos e procure pessoas ou serviços que possam ajudar."),
            ]),
        new(
            ArticleIds.WorryBeforeTask,
            "Antes de uma tarefa difícil",
            "Comece com uma etapa segura e limitada",
            "TipsAndUpdates",
            2,
            [
                P("Antes de uma tarefa importante, a ansiedade pode sugerir que você espere até ter certeza total ou um plano perfeito. Mas a confiança nem sempre vem antes do começo. Primeiro, identifique o que torna a tarefa difícil: resultado pouco claro, volume grande, falta de informação, possibilidade de erro ou uma conversa."),
                H("Escolha a primeira parte"),
                P("Defina uma etapa segura de 5 a 15 minutos: abrir o documento, reunir materiais, ler as instruções ou fazer uma pergunta para esclarecer algo. Decida antes onde vai parar. Se precisar de autorização, conhecimento ou acordo de alguém, não tente adivinhar: anote com quem pode confirmar."),
                H("Revise o plano, não o seu valor"),
                P("Depois da primeira etapa, veja o que ficou mais claro e o que continua desconhecido. Você pode continuar, pausar ou mudar o plano. Parar no ponto combinado também é cumprir o acordo consigo. Se a tarefa ainda parecer grande demais, divida-a em partes menores ou peça apoio, em vez de atribuir a dificuldade à falta de força de vontade.")
            ]),
        new(
            ArticleIds.AvoidedFirstStep,
            "Dê apenas o primeiro passo",
            "O começo pode levar dois minutos",
            "TipsAndUpdates",
            2,
            [
                P("Quando uma tarefa parece grande ou confusa, é fácil evitar tudo. Isso nem sempre é preguiça: talvez não esteja claro por onde começar, falte energia ou o custo de errar pareça alto demais. Você não precisa prometer que vai terminar. Torne o começo visível e limitado."),
                H("Transforme a meta em uma ação"),
                P("«Trabalhar no relatório» não diz o que fazer agora. «Abrir o arquivo e anotar três perguntas» diz. Um bom primeiro passo é breve, específico e possível neste momento. Se ainda parecer difícil, diminua: abrir o documento, encontrar a página certa ou escrever um título."),
                H("Remova um obstáculo"),
                P("Perceba o que mais atrapalha: não encontrar um arquivo, ter material demais, não saber como reconhecer que terminou ou se distrair com o celular. Remova apenas uma barreira. Organizar todo o processo pode virar mais uma forma de adiar."),
                H("Um teste, não uma promessa"),
                P("Marque cinco ou dez minutos e permita-se parar quando o tempo acabar. Depois, veja o que mudou: a tarefa ficou mais clara? Há energia para continuar? Você precisa de informação ou ajuda? Parar como planejado também é concluir uma etapa."),
                H("Um plano para os próximos minutos"),
                List(
                    "Escreva o resultado desejado em uma frase.",
                    "Escolha uma ação que possa ser vista ou conferida.",
                    "Prepare uma coisa necessária e remova um obstáculo.",
                    "Depois do início curto, escolha entre continuar, simplificar ou pedir ajuda."),
                P("Se até tarefas pequenas continuarem parecendo impossíveis por muito tempo e isso afetar o dia a dia, converse com alguém de confiança ou um profissional sobre a carga e o apoio disponível."),
            ]),
        new(
            ArticleIds.CheckingLoop,
            "Confira e pare",
            "Defina um objetivo sem pular verificações de segurança",
            "TipsAndUpdates",
            2,
            [
                P("Conferir repetidamente pode aliviar a preocupação por pouco tempo, até a dúvida voltar: «E se deixei algo passar?». Algumas checagens são obrigatórias. O objetivo não é parar de conferir tudo, mas distinguir uma checagem necessária da repetição sem motivo novo."),
                H("Antes de conferir"),
                P("Antes, defina o que precisa confirmar, qual fonte é confiável e o que indica que terminou. Para uma passagem, pode ser comparar data e destino com o documento oficial. Se uma regra exige segunda checagem, siga-a; um limite pessoal não substitui um procedimento obrigatório."),
                H("Quando a dúvida voltar"),
                P("Se a dúvida voltar, pergunte se mudaram as circunstâncias, surgiram dados ou exigências. Se sim, confira essa parte. Se não, registre que verificou conforme a regra escolhida e passe a outra atividade. Não é preciso esperar ficar totalmente calmo."),
                H("Uma conferência com limites claros"),
                List(
                    "Nomeie o objetivo.",
                    "Escolha uma fonte confiável e o número de checagens necessário.",
                    "Marque como concluído.",
                    "Confira de novo se surgirem fatos ou requisitos de segurança."),
                P("Se as checagens tomam muito tempo ou restringem sua vida, procure apoio profissional. Não omita verificações necessárias à segurança.")
            ]),
        new(
            ArticleIds.PublicPlaceAnxiety,
            "Ansiedade em um lugar movimentado",
            "Reduza a sobrecarga e mantenha opções",
            "TipsAndUpdates",
            2,
            [
                P("Barulho, proximidade, espera ou sentir que não pode sair podem aumentar a ansiedade. Você não precisa se obrigar a aguentar nem ver a saída como fracasso. Primeiro confira a situação e escolha um próximo passo adequado."),
                H("Encontre um apoio possível"),
                P("Se for possível, vá para um lugar mais silencioso e localize a saída. Você pode nomear objetos ou perceber os pés no chão. São opções, não um ritual; ignore o foco no corpo se for desconfortável."),
                H("Decida o próximo passo"),
                P("Pergunte a si: mudar de lugar ou ritmo ajudaria a ficar? Seria melhor pausar, remarcar ou ligar para alguém? Escolha um passo sem exigir calma imediata. Se houver perigo, peça ajuda para chegar a um local seguro."),
                H("Um plano breve"),
                List(
                    "Encontre um local seguro e localize a saída.",
                    "Reduza um estímulo, se possível.",
                    "Escolha ficar, pausar, sair ou pedir apoio.",
                    "Pare o exercício se aumentar o desconforto."),
                P("Se essas situações atrapalham sua vida com frequência, converse com um profissional. Em perigo imediato, contate os serviços de emergência.")
            ]),
        new(
            ArticleIds.MorningWorry,
            "Uma manhã sem lista de preocupações",
            "Escolha a prioridade de hoje e marque um momento para o restante",
            "TipsAndUpdates",
            2,
            [
                P("De manhã, todas as tarefas pendentes podem parecer urgentes. Rever mentalmente a semana aumenta a pressão e dificulta perceber o que precisa de atenção hoje. Um plano breve ajuda a escolher o próximo passo, sem tentar controlar tudo."),
                H("Separe o urgente do importante"),
                P("Anote o que preocupa e marque uma tarefa com prazo ou consequência real para hoje. Escolha o primeiro passo e um horário. Se depender de outra pessoa, registre quem contatar ou que ajuda pedir. Passe o restante para um momento específico."),
                H("Confira necessidades básicas"),
                P("Antes de exigir produtividade, pense no que ajudaria a começar: água, comida, medicamento prescrito, alguns minutos de calma ou roupa confortável. Reduza o plano se sua saúde ou situação mudar."),
                H("Um plano para os próximos minutos"),
                List(
                    "O que realmente precisa de ação hoje?",
                    "Qual é o menor próximo passo?",
                    "Quando volto às outras questões?",
                    "O que ajudaria meu corpo agora?"),
                P("Se a preocupação matinal atrapalha frequentemente as atividades ou o sono, converse com um profissional.")
            ]),
        new(
            ArticleIds.SensoryOverload,
            "Quando há sons e tarefas demais",
            "Reduza estímulos e recupere opções",
            "TipsAndUpdates",
            2,
            [
                P("Conversas, notificações, telas brilhantes e pedidos simultâneos podem sobrecarregar a atenção. Fica mais difícil acompanhar a fala ou continuar uma atividade. Isso sinaliza carga, não falta de esforço. Comece por uma mudança possível."),
                H("Reduza uma fonte de sobrecarga"),
                P("Vá a um lugar mais silencioso, desligue um aviso não essencial, diminua o brilho ou peça para falarem um de cada vez. Se não puder sair, reduza tarefas e peça que repitam uma instrução. Escolha ajustes seguros."),
                H("Mantenha a opção de parar"),
                P("Se um exercício de respiração, fechar os olhos ou focar no corpo piorar o desconforto, pare e escolha um ponto externo ou uma pausa. Você pode dizer: «Preciso de menos barulho; respondo depois»."),
                H("Plano para reduzir estímulos"),
                List(
                    "Perceba o estímulo mais difícil.",
                    "Mude um fator: som, luz, ritmo ou distância.",
                    "Adie uma decisão não essencial.",
                    "Peça ajuda se não puder sair ou pausar sozinho."),
                P("Se a sobrecarga surgir de repente com sintomas intensos ou você não conseguir ficar em segurança, procure ajuda.")
            ]),
        new(
            ArticleIds.EveningTension,
            "Encerre o dia com gentileza",
            "Deixe as tarefas inacabadas para amanhã sem planejar a noite toda",
            "TipsAndUpdates",
            2,
            [
                P("À noite, as tarefas inacabadas podem parecer prova de que o dia não foi bom o bastante. Tentar resolver tudo mentalmente antes de dormir pode prolongar o expediente. Uma anotação breve e uma transição clara ajudam a deixar as tarefas de lado por enquanto."),
                H("Feche as pendências"),
                P("Anote o que foi concluído, o que realmente precisa de uma próxima ação e o que pode esperar. Para uma tarefa importante, registre um primeiro passo concreto para amanhã e um horário aproximado. Se precisar conversar sobre um prazo ou pedir ajuda, anote com quem falar e quando. Não é necessário planejar a semana inteira."),
                H("Escolha um sinal de encerramento"),
                P("Guarde a anotação e feche a lista. Depois, escolha uma ação simples que marque o fim das tarefas de hoje: diminuir a luz, guardar os materiais, lavar o rosto ou sentar em silêncio. Isso não garante o sono, mas pode ajudar a parar de resolver pendências na cama.")
            ]),
        new(
            ArticleIds.AnxietyComedown,
            "Depois de uma onda de ansiedade",
            "Recupere a sensação de segurança antes de decidir se quer refletir",
            "TipsAndUpdates",
            2,
            [
                P("Depois de uma ansiedade intensa, pode surgir a vontade de entender a causa imediatamente e garantir que aquilo nunca se repita. Mas analisar tudo quando você está exausto pode aumentar a sobrecarga. Primeiro, confira se está em segurança e dê a si mesmo tempo para voltar ao seu ritmo."),
                H("Volte ao simples e conhecido"),
                P("Se estiver em segurança, escolha algo familiar e pouco exigente: sente-se, beba água, coma alguma coisa, aqueça-se ou vá para um lugar mais silencioso. Você não precisa fazer um exercício de respiração nem fechar os olhos. Se algo aumentar o desconforto, pare e escolha outra opção."),
                H("Reflita apenas sobre o que pode ajudar"),
                P("Mais tarde, quando estiver mais fácil se concentrar, anote o que estava acontecendo, o que ajudou um pouco e se existe uma questão prática para a próxima vez. Não é preciso encontrar uma única causa nem se culpar. Se houver algo a fazer, registre o próximo passo ou com quem conversar. Sintomas novos ou incomuns merecem avaliação profissional.")
            ]),
        new(
            ArticleIds.SafePractice,
            "Uma prática não é uma prova",
            "Adapte o exercício ou pare, mantendo o controle",
            "TipsAndUpdates",
            2,
            [
                P("Uma prática só é útil quando combina com você naquele momento. Completar todas as etapas a qualquer custo não é o objetivo. Você pode mudar o ritmo, pular uma parte ou encerrar o exercício; isso não significa que fez algo errado."),
                H("Mantenha suas opções"),
                P("Antes de começar, decida como pode parar e para onde pode voltar a atenção. Você pode manter os olhos abertos, encurtar o tempo, mudar de posição ou escolher um ponto externo para observar. Exercícios focados na respiração ou no corpo não servem para todo mundo: escolha uma alternativa que não aumente seu desconforto."),
                H("Se o desconforto aparecer"),
                P("Pare, retome a respiração natural e olhe ao redor. Se for seguro, mude de posição ou passe para uma atividade simples e conhecida. Você não precisa aguentar até o fim para provar nada. Se o desconforto continuar ou aumentar, procure apoio.")
            ]),

        new(
            ArticleIds.ThoughtLabel,
            "Dê um nome ao pensamento",
            "Perceba-o sem discutir",
            "TipsAndUpdates",
            2,
            [
                P("Um pensamento pode parecer muito convincente, sobretudo quando você está cansado ou ansioso. Experimente começar com: «Estou percebendo o pensamento de que…». Isso não prova que ele seja falso; ajuda a separar um evento mental de um fato confirmado e abre um pequeno espaço para escolher o que fazer."),
                H("Confira o que é conhecido"),
                P("Anote brevemente o que aconteceu e o que você concluiu. Pergunte: «O que observei diretamente? O que ainda é uma interpretação?». Não é necessário analisar todo pensamento nem convencer-se do contrário. Se ele envolve uma decisão importante, procure apenas informações que possam realmente mudar o próximo passo."),
                H("Volte a uma ação escolhida"),
                P("Escolha uma pequena ação ligada à sua tarefa ou aos seus valores: abrir um documento, fazer uma pergunta ou pausar. O pensamento pode continuar presente; você não precisa eliminá-lo primeiro. Se o exercício aumentar o desconforto, pare e escolha um apoio mais adequado para você.")
            ]),
        new(
            ArticleIds.MindReading,
            "Não tente adivinhar o que os outros pensam",
            "Separe observação de suposição",
            "TipsAndUpdates",
            2,
            [
                P("Quando alguém fica em silêncio ou responde brevemente, a mente pode completar a história: «Está com raiva» ou «Estraguei tudo». São possibilidades, mas não as únicas. Ajuda separar o que você realmente viu ou ouviu do significado que atribuiu àquilo."),
                H("Pergunte se isso for importante"),
                P("Se a relação e a questão importam, pergunte com calma e de forma concreta: «Entendi direito que…?» ou «Quando seria um bom momento para conversar?». Não exija resposta imediata se a pessoa estiver ocupada. Se esclarecer agora não ajudar, reconheça a dúvida e espere por mais informações."),
                H("Não transforme suposição em sentença"),
                P("Mantenha mais de uma explicação em aberto: a pessoa pode estar ocupada, cansada ou não ter visto a mensagem. Nenhuma precisa ser a correta. O objetivo não é trocar uma certeza por outra, mas não tratar uma suposição como prova. Depois, decida se há um próximo passo real ou se pode voltar às suas atividades.")
            ]),
        new(
            ArticleIds.WorstVsLikely,
            "O pior resultado não é o mais provável",
            "Prepare-se sem viver a situação antes da hora",
            "TipsAndUpdates",
            2,
            [
                P("A ansiedade pode mostrar o resultado mais difícil como se já estivesse prestes a acontecer. Em vez de discutir consigo, considere três possibilidades: um resultado difícil, um favorável e o mais plausível com base no que você sabe. Isso não é previsão nem promessa de que tudo dará certo; é uma forma de incluir mais de uma possibilidade."),
                H("Separe preparação de preocupação repetitiva"),
                P("Para o cenário mais plausível, escolha uma ação útil. Se o pior resultado tiver consequências graves, faça um plano breve e razoável: o que faria e quem poderia procurar? Não é preciso planejar em detalhes todos os cenários imaginados. Pergunte que informação nova mudaria sua avaliação e busque apenas essa informação."),
                H("Deixe a incerteza em aberto"),
                P("Se ajudar, anote um fato a favor e outro contra cada possibilidade. Se ainda não houver dados, marque como «desconhecido». Depois volte a algo que possa fazer agora. Diante de um risco real, aja com base nos fatos e procure ajuda prática; este exercício não substitui isso.")
            ]),
        new(
            ArticleIds.EvidenceAndUnknown,
            "O que sei e o que ainda não sei",
            "Não preencha uma lacuna com uma suposição ansiosa",
            "TipsAndUpdates",
            2,
            [
                P("Quando falta uma resposta, uma explicação ansiosa pode parecer um fato. Separar o que é conhecido do que ainda não se sabe não elimina a incerteza, mas ajuda a não decidir com base em uma suposição. Anote os fatos à parte das perguntas em aberto."),
                H("Pergunte o que pode ser descoberto"),
                P("Para cada dúvida, decida onde encontrar informação confiável, a quem perguntar ou quando voltar ao assunto. Busque apenas o que poderia mudar uma ação. Conferir repetidamente a mesma fonte geralmente não traz dados novos."),
                H("Deixe em aberto o que continua sem resposta"),
                P("Se não há resposta agora, anote «desconhecido por enquanto». Defina quando verificar novamente ou deixe a questão para depois. Em seguida, volte a algo que está ao seu alcance. A incerteza pode incomodar, mas nem sempre precisa ser resolvida de imediato.")
            ]),
        new(
            ArticleIds.NegativityFilter,
            "Perceba mais do que o que deu errado",
            "Acrescente mais um fato ao quadro",
            "TipsAndUpdates",
            2,
            [
                P("Depois de uma situação difícil, a atenção pode ficar presa aos erros e deixar de notar momentos neutros ou úteis. Isso não significa que você precise apresentar tudo de forma positiva. A ideia é apenas conferir se uma parte da história virou a história inteira."),
                H("Recupere um pouco do contexto"),
                P("Nomeie o que deu errado e acrescente outro fato relevante: o que você fez, o que transcorreu normalmente, quem ajudou ou o que aprendeu. Um detalhe neutro também conta. Você não precisa procurar elogios se isso não fizer sentido agora."),
                H("Use o quadro completo para decidir o próximo passo"),
                P("Pergunte se o fato acrescentado muda o que você precisa fazer. Se sim, escolha uma ação. Se não, reconheça a dificuldade sem transformar o episódio em um julgamento geral sobre si. Um momento bom não apaga o difícil, mas pode tornar a avaliação mais precisa.")
            ]),
        new(
            ArticleIds.ConversationReplay,
            "Pare de repassar a conversa sem parar",
            "Confira se há informação nova ou uma ação",
            "TipsAndUpdates",
            2,
            [
                P("Depois de uma conversa, é fácil repetir cada frase e imaginar o que a outra pessoa pensou. Uma revisão breve pode ajudar se levar a clareza ou a uma reparação. Repetir sem novos fatos costuma apenas cansar."),
                H("Separe uma conclusão do próximo passo"),
                P("Anote um fato concreto, um compromisso ou uma pergunta que realmente precise de resposta. Se quiser esclarecer ou corrigir algo, escolha uma mensagem curta e um momento adequado. Você não precisa enviar várias mensagens para alcançar certeza absoluta."),
                H("Se nada mudou, faça uma pausa"),
                P("Nomeie o que está acontecendo: «Estou repassando a conversa, mas não tenho informação nova». Passe a uma atividade que traga sua atenção ao presente. Se o assunto continuar importante, marque um momento para decidir com calma se precisa conversar. Não é necessário decidir agora.")
            ]),
        new(
            ArticleIds.DecisionFatigue,
            "Simplifique uma escolha pequena",
            "Decida antes o que é suficiente",
            "TipsAndUpdates",
            2,
            [
                P("Pequenas decisões se acumulam, principalmente quando cada uma exige comparar tudo de novo. Para escolhas repetidas, uma regra definida antes pode ajudar: tempo, orçamento ou qualidade. Isso não significa apressar decisões importantes; reserve um momento próprio para avaliá-las com calma."),
                H("Mantenha poucas opções"),
                P("Para uma escolha fácil de rever, fique com duas opções aceitáveis e compare-as usando um critério. Por exemplo: qual será mais fácil de manter nesta semana? Limitar opções protege sua atenção, não garante uma resposta perfeita."),
                H("Reavalie apenas se algo mudar"),
                P("Anote a escolha e o que faria você reconsiderá-la, como uma mudança nas circunstâncias ou um fato importante. Se nada mudou, experimente seguir sua decisão. Se ela afetar segurança, saúde ou um compromisso importante, uma regra simples não substitui uma verificação cuidadosa.")
            ]),
        new(
            ArticleIds.GoodEnough,
            "Bom o suficiente também é resultado",
            "Limite os retoques desnecessários",
            "TipsAndUpdates",
            2,
            [
                P("Quando uma tarefa importa, é compreensível querer conferi-la outra vez. Sem um limite claro, os ajustes podem continuar mesmo quando o resultado já é utilizável. Antes de começar, defina o que precisa estar pronto e onde você vai parar."),
                H("Defina um ponto de chegada"),
                P("Escolha dois ou três critérios observáveis e como conferi-los. Por exemplo, um e-mail deve comunicar o pedido, trazer a data certa e passar por uma revisão de erros evidentes. Depois, salve ou envie. Os critérios devem combinar com a tarefa, sem exigir perfeição em tudo."),
                H("Volte apenas por uma razão concreta"),
                P("Querer conferir mais uma vez não prova que existe um erro. Reabra o trabalho se encontrar um problema específico, receber informação nova ou precisar fazer uma mudança necessária. Assim você diferencia uma correção útil de ajustes sem fim em busca de uma certeza impossível.")
            ]),
        new(
            ArticleIds.ControlInfluence,
            "O que posso influenciar e o que não posso",
            "Concentre-se em uma ação disponível",
            "TipsAndUpdates",
            2,
            [
                P("Quando uma situação também depende de outras pessoas ou das circunstâncias, tentar controlar tudo pode esgotar. Separar o que está ao seu alcance não torna a situação justa nem remove restrições reais; ajuda a escolher onde investir energia."),
                H("Encontre sua margem de ação"),
                P("Pergunte: o que posso dizer, preparar, pedir ou decidir? Escolha um passo concreto. Para o que está fora do seu controle, considere um limite, apoio ou horário para verificar novamente. Às vezes, a ação possível é recusar, pedir ajuda ou comunicar um problema."),
                H("Não assuma a responsabilidade de outra pessoa"),
                P("Você pode fazer um pedido claro, mas não garantir a resposta. Perceba onde termina sua parte e não use a decisão alheia como medida do seu valor. Se houver perigo real ou violação de direitos, procure apoio prático; mudar sua perspectiva não é suficiente.")
            ]),
        new(
            ArticleIds.SelfTalkReset,
            "Mude o tom da conversa consigo",
            "Fale consigo com respeito e clareza",
            "TipsAndUpdates",
            2,
            [
                P("A autocrítica às vezes parece motivação: «se eu me cobrar bastante, vou me organizar». Mas insultos não explicam o que fazer em seguida. Falar consigo com respeito não significa justificar uma atitude nem ignorar suas consequências. Ajuda a descrever a situação com precisão e a continuar tendo opções."),
                H("Troque um rótulo por um fato observável"),
                P("Experimente trocar «sou irresponsável» por «perdi o prazo e ainda não avisei a equipe». A primeira frase julga seu caráter inteiro; a segunda nomeia um acontecimento e uma ação possível. Quanto mais específica a descrição, mais fácil escolher o próximo passo."),
                H("Uma frase para um momento difícil"),
                P("Use três partes: o que aconteceu, o que foi afetado e o que você fará agora. Por exemplo: «Respondi de forma ríspida, a conversa ficou tensa, então vou retomar o assunto e esclarecer o que eu quis dizer». Se você causou dano, reconhecer isso e tentar reparar importa mais do que tornar a frase positiva."),
                H("Confira se há honestidade e respeito"),
                List(
                    "Nomeie o fato sem «sempre» nem «nunca».",
                    "Perceba o sentimento ou a consequência sem tratá-los como prova de fracasso.",
                    "Escolha um passo possível: reparar, esclarecer, pedir desculpas ou buscar apoio.",
                    "Use consigo o tom que usaria com alguém querido, mantendo a honestidade."),
                P("Você não precisa acreditar de imediato em uma frase nova. Basta que ela seja mais precisa e útil. Se a autocrítica se tornar constante ou dolorosa, o apoio profissional pode ajudar."),
            ]),
        new(
            ArticleIds.WorryAboutWorry,
            "Preocupar-se por estar preocupado",
            "Não exija que a calma chegue imediatamente",
            "TipsAndUpdates",
            2,
            [
                P("Ao notar a ansiedade, pode surgir um segundo pensamento: «Eu não deveria reagir assim». Isso aumenta a pressão. A primeira reação já apareceu; você não precisa se criticar por isso também. O objetivo não é forçar a calma, mas escolher uma ação possível enquanto a ansiedade está presente."),
                H("Nomeie as duas reações"),
                P("Experimente perceber: «Estou ansioso e agora preocupado por estar ansioso». Não é preciso discutir com isso nem encontrar as palavras perfeitas. Depois, veja se existe uma ação prática: preparar-se, pedir apoio ou resolver uma questão específica."),
                H("Meça o avanço pelo passo escolhido"),
                P("Pergunte o que você queria fazer antes de a ansiedade aparecer e escolha uma versão menor desse passo. Depois, observe a ação ou a pausa, não o quanto se acalmou. Se a ansiedade costuma limitar sua vida diária, converse com um profissional de saúde mental.")
            ]),
        new(
            ArticleIds.CompareHighlightReel,
            "Não compare sua vida com a vitrine de alguém",
            "A rede mostra momentos escolhidos, não uma vida inteira",
            "TipsAndUpdates",
            2,
            [
                P("Publicações costumam mostrar um instante, não as preocupações, dúvidas e rotinas comuns de alguém. Comparar seu cotidiano com os melhores momentos de outra pessoa pode dar a impressão de que você está ficando para trás. Esse sentimento é real, mas não define seu valor nem conta a história inteira."),
                H("Perceba do que você sente falta"),
                P("Feche a publicação por um momento e pergunte o que está fazendo falta: descanso, companhia, dinheiro, reconhecimento ou tempo para algo importante. Você não precisa desvalorizar esse desejo. Está percebendo uma necessidade, não assumindo o compromisso de mudar toda a vida agora."),
                H("Dê um pequeno passo na sua direção"),
                P("Se puder, faça algo concreto: escreva para alguém próximo, planeje uma pausa ou retome seu projeto. Se nenhum passo estiver disponível agora, apenas reconheça isso. O sucesso de outra pessoa não elimina suas possibilidades; uma pausa na rede pode ajudar você a reencontrar seu próprio ritmo.")
            ]),
        new(
            ArticleIds.IntrusiveThoughts,
            "Um pensamento indesejado não é uma intenção",
            "Considere ações, contexto e segurança",
            "TipsAndUpdates",
            2,
            [
                P("Pensamentos podem ser perturbadores, assustadores ou contrários aos seus valores. A presença de um pensamento, por si só, não prova que você queira agir. Você não precisa testar sem parar se é uma «boa pessoa» nem buscar certeza completa repetidamente."),
                H("Evite alimentar o ciclo de checagem"),
                P("Se estiver em segurança, tente nomeá-lo brevemente como «um pensamento indesejado», sem analisá-lo outra vez e outra vez. Volte a uma atividade comum ou a um ponto externo de atenção. Se ele estiver ligado a uma intenção real, a um plano ou a um risco imediato para você ou outra pessoa, trate isso como uma questão de segurança: afaste-se de meios de causar dano e procure rapidamente alguém de confiança, um profissional ou o serviço de emergência."),
                H("Procure apoio se isso atrapalhar sua vida"),
                P("Se esses pensamentos assustam com frequência, tomam muito tempo ou interferem na vida diária, converse com um profissional de saúde mental. Você pode descrever a frequência, o impacto e o que ajuda, sem tentar fazer um autodiagnóstico.")
            ]),
        new(
            ArticleIds.OneThingAtATime,
            "Uma tarefa de cada vez",
            "Deixe o foco concreto e com um limite",
            "TipsAndUpdates",
            2,
            [
                P("Alternar entre mensagens, abas e tarefas pode parecer produtivo e, ao mesmo tempo, dificultar a percepção de que algo terminou. Você não precisa se concentrar o dia inteiro. Experimente um período curto com um resultado visível: revisar três linhas, responder a um e-mail ou ler algumas páginas."),
                H("Facilite a retomada"),
                P("Antes de começar, silencie apenas os avisos e feche apenas as janelas que costumam distrair, se isso for possível. Deixe uma nota “depois” por perto: registre novas tarefas em vez de mudar de foco na hora. Se interrupções forem inevitáveis, anote rapidamente onde parou e qual é a próxima ação."),
                H("Encerre o período com intenção"),
                P("Quando o timer tocar ou você alcançar o resultado escolhido, pare um instante e decida se continua, muda de tarefa ou descansa. Se a concentração não veio, diminua a etapa ou confira se cansaço, fome ou o ambiente estão atrapalhando. Não é uma competição de produtividade: é uma forma de reduzir a confusão mental e escolher o próximo passo com mais clareza.")
            ]),

        new(
            ArticleIds.MoodMovement,
            "Um pouco de movimento quando falta energia",
            "Experimente um passo leve, sem a cobrança de se animar",
            "TipsAndUpdates",
            2,
            [
                P("Quando falta energia, até um movimento comum pode parecer mais uma tarefa. Você não precisa se convencer de que uma caminhada curta vai melhorar o humor. Pode apenas observar o que parece possível agora e como se sente. O objetivo não é treinar, mas cuidar do contato com as necessidades do corpo."),
                H("Escolha uma opção possível"),
                P("Pode ser alongar-se sentado, ir até a janela, mudar de posição ou ficar alguns minutos ao ar livre. Escolha a duração e mantenha a liberdade de parar. Se tiver limitações de saúde, siga a orientação médica; o movimento não deve causar dor nem exigir que você force o corpo."),
                H("Observe sem se avaliar"),
                P("Depois, pergunte-se: algo ficou mais confortável, permaneceu igual ou cansou mais? Qualquer resposta é útil e não significa que você fez algo errado. Se o descanso for mais necessário, escolha descansar. Se a falta de energia persistir ou surgir de repente, considere conversar com um profissional de saúde.")
            ]),
        new(
            ArticleIds.PleasureMastery,
            "Prazer e sensação de conclusão",
            "Perceba diferentes formas de uma atividade ajudar",
            "TipsAndUpdates",
            2,
            [
                P("Algumas atividades são agradáveis enquanto acontecem; outras trazem uma sensação de conclusão ou conexão com algo importante. São experiências diferentes, e nenhuma precisa aparecer depois de cada tarefa. Quando estiver cansado, pode ser mais útil observar o efeito real da atividade do que esperar uma alegria imediata."),
                H("Planeje sem se sobrecarregar"),
                P("Escolha uma opção pequena que combine com o momento: para prazer, ouvir uma música ou tomar chá; para concluir algo, arrumar uma superfície ou responder a um e-mail; para conexão, escrever brevemente a alguém de confiança. Uma opção basta. Considere tempo, energia, acesso e vontade própria."),
                H("Observe a experiência com gentileza"),
                P("Depois, anote separadamente se foi agradável e se surgiu a sensação de “terminei algo”. Se nada mudou, isso não é fracasso nem motivo para se obrigar a repetir. Talvez você precise descansar, experimentar outro formato ou reduzir o passo. Essas observações ajudam a planejar de modo realista, não a medir seu valor.")
            ]),
        new(
            ArticleIds.EnergyBudget,
            "Distribua energia, não só o tempo",
            "Planeje a recuperação junto com as demandas",
            "TipsAndUpdates",
            2,
            [
                P("Duas tarefas com a mesma duração podem exigir esforços bem diferentes. Ao planejar, conte também deslocamentos, preparação, concentração e carga emocional. Uma agenda sem transições nem pausas pode ficar cheia demais, mesmo quando parece haver tempo livre."),
                H("Deixe uma margem"),
                P("Escolha uma tarefa importante e, se houver energia, uma pequena. Entre as tarefas exigentes, coloque uma pausa simples ou uma atividade mais leve. Não é necessário preencher todos os espaços livres. Se o plano depender de outras pessoas, mantenha uma alternativa ou pergunte o que é prioridade."),
                H("Ajuste com base no que percebeu"),
                P("No fim do dia, note quais itens exigiram mais energia do que o esperado e se houve tempo suficiente para se recuperar. Use isso como informação para o próximo plano, não como motivo de autocrítica. Em um dia imprevisível, reduza a lista ao que é mais importante e deixe o restante para depois.")
            ]),
        new(
            ArticleIds.RestBreak,
            "Faça uma pausa sem culpa",
            "O descanso pode ajudar na próxima escolha",
            "TipsAndUpdates",
            2,
            [
                P("Quando há muita coisa para fazer, descansar pode parecer uma recompensa que precisa ser merecida. Mas a pausa pode ser uma parte normal de administrar o esforço, não um sinal de fraqueza. Ela não precisa tornar você mais produtivo; pode apenas ajudar a perceber como está e decidir o que vem depois."),
                H("Escolha a pausa de acordo com o cansaço"),
                P("Se os olhos e a atenção estão cansados, alguns minutos de silêncio sem tela podem ajudar. Se o corpo está rígido, mude de posição ou alongue-se de leve, se isso for confortável. Se o barulho sobrecarrega, procure um lugar mais tranquilo. Água, comida, ar livre ou uma conversa com alguém de confiança podem ser melhores. Não existe uma única maneira: escolha algo seguro e disponível."),
                H("Não transforme a pausa em outra tarefa"),
                P("Escolha uma duração aproximada e uma atividade simples: sentar perto da janela por cinco minutos ou dar uma volta curta. Não é preciso avaliar se você está descansando direito. Depois, pode dar um próximo passo, adiar algo, pedir ajuda ou encerrar por hoje."),
                H("Quando não há espaço para descansar"),
                P("O cansaço que se repete nem sempre se resolve com um planejamento mais rígido. Veja se alguma tarefa pode ser reduzida, adiada ou dividida; se é possível conversar sobre prazos; e que apoio você pode pedir. Nem tudo depende apenas de disciplina pessoal."),
                H("Um plano gentil para a pausa"),
                List(
                    "Perceba o que está cansado: atenção, corpo ou emoções.",
                    "Escolha uma pausa curta que faça sentido agora.",
                    "Suspenda uma exigência pessoal enquanto descansa.",
                    "Depois decida o que realmente precisa continuar."),
                P("Se o cansaço persistir, atrapalhar atividades do dia a dia ou causar preocupação com a saúde, procure um profissional de saúde. Este artigo não substitui atendimento individual."),
            ]),
        new(
            ArticleIds.StartFriction,
            "Remova um obstáculo antes de começar",
            "Prepare o próximo passo, não o processo inteiro",
            "TipsAndUpdates",
            2,
            [
                P("Quando é difícil começar, “organize-se melhor” nem sempre esclarece o que está atrapalhando. Talvez a tarefa esteja pouco clara, o arquivo seja difícil de achar, faltem materiais ou o primeiro passo seja grande demais. Escolha um obstáculo específico para verificar, em vez de reorganizar o dia inteiro."),
                H("Facilite a entrada"),
                P("Se o objetivo não estiver claro, anote uma pergunta ou peça esclarecimentos. Se faltar preparação, abra o documento ou deixe os materiais à vista. Se o celular distrair, afaste-o por um período curto, se isso for possível. Não transforme a preparação em outra tarefa enorme."),
                H("Veja se ajudou"),
                P("Tente começar depois de mudar uma única condição e observe se ficou mais fácil. Se não, desfaça o que não ajudou e verifique outra causa. O obstáculo pode depender de outra pessoa: talvez você precise de acesso, uma decisão ou ajuda. Nesse caso, o próximo passo é fazer um pedido claro, não tentar superar tudo sozinho.")
            ]),
        new(
            ArticleIds.TransitionRitual,
            "Faça uma pausa ao trocar de tarefa",
            "Anote o que falta e nomeie o próximo passo",
            "TipsAndUpdates",
            2,
            [
                P("Depois de uma interrupção, pode ser difícil lembrar onde parou; o trabalho inacabado também continua ocupando a atenção. Uma transição curta ajuda a registrar isso e começar a próxima tarefa com mais calma. Não é um ritual obrigatório nem uma maneira de trabalhar sem descanso; é apenas um recurso opcional."),
                H("Feche a tarefa anterior"),
                P("Escreva em uma linha o que foi feito e o que falta. Salve o arquivo ou guarde os materiais em um lugar fácil de encontrar. Se estiver esperando uma resposta, anote de quem e quando vai conferir. Não é preciso arrumar todo o espaço."),
                H("Escolha o que vem agora"),
                P("Nomeie a primeira ação visível da próxima tarefa e deixe a anterior de lado. A transição pode levar menos de um minuto: salvar, anotar, nomear. Se a pausa aumentar a tensão ou se você precisar descansar, não se force a seguir o ritual. Depois de experimentá-lo, mantenha apenas as partes que realmente ajudam.")
            ]),
        new(
            ArticleIds.TaskActivation,
            "Quando é difícil começar",
            "Ligue uma ação bem pequena a um sinal conhecido",
            "TipsAndUpdates",
            2,
            [
                P("Esperar pela motivação pode adiar uma tarefa, mas você não precisa começar por todo o trabalho. Escolha uma ação que apenas abra a tarefa: abrir o documento, ler as instruções ou escrever um título. É um começo, não uma promessa de terminar tudo."),
                H("Use um sinal claro"),
                P("Ligue a ação a um momento comum: “Depois do café da manhã, vou abrir o arquivo e olhar a primeira linha”. Defina onde e quando, e remova um obstáculo antes. Se perder esse momento, escolha outro; um começo perdido não invalida o plano."),
                H("Decida depois de começar"),
                P("Após o pequeno passo, observe sua energia e escolha se continua um pouco, faz uma pausa ou para. O começo conta, não a quantidade concluída. Às vezes a tarefa não está clara, é grande demais ou exige apoio. Se isso atrapalhar a vida diária com frequência, considere conversar com um profissional adequado.")
            ]),
        new(
            ArticleIds.GentleRoutine,
            "Uma rotina flexível, não perfeita",
            "Mantenha um ponto estável, não um horário rígido",
            "TipsAndUpdates",
            2,
            [
                P("Uma rotina pode ajudar ao reduzir o número de decisões diárias. Mas um horário muito detalhado pode virar motivo de culpa quando algo muda. Escolha um ponto repetível — por exemplo, planejar depois do café da manhã — e deixe o restante do dia flexível."),
                H("Torne o hábito adaptável"),
                P("Associe a ação a um acontecimento, não só a um horário: abrir as cortinas ao acordar ou conferir uma mensagem depois do almoço. Prepare uma versão simples para dias difíceis: respirar uma vez perto da janela em vez de caminhar, ou anotar uma prioridade em vez de fazer uma lista inteira. O mínimo precisa ser realmente possível."),
                H("Retome sem se punir"),
                P("Se perder um dia, volte na próxima oportunidade adequada; não precisa compensar o que faltou. Se o hábito deixou de ajudar ou virou um peso, ajuste-o ou abandone-o. A rotina deve se adaptar à sua vida e às suas necessidades, não se tornar uma prova de disciplina.")
            ]),
        new(
            ArticleIds.WakeAtNight,
            "Se você acordar durante a noite",
            "Reduza a pressão e deixe o sono voltar no próprio ritmo",
            "TipsAndUpdates",
            2,
            [
                P("Acordar à noite não significa que o resto da noite está perdido. Olhar o relógio repetidamente e contar as horas pode aumentar a pressão. Se puder, evite conferir a hora e não exija adormecer imediatamente. Deixe o ambiente o mais calmo e seguro possível."),
                H("Escolha uma atividade tranquila"),
                P("Se ficar na cama for desagradável e o sono não voltar, você pode levantar por pouco tempo e fazer algo calmo com luz baixa. Volte quando sentir sono. Não precisa seguir uma orientação que cause desconforto; considere sua segurança, como está se sentindo e as recomendações médicas."),
                H("Deixe as preocupações de amanhã para amanhã"),
                P("Se os pensamentos sobre tarefas se repetirem, anote uma tarefa ou pergunta e retome pela manhã. Ao acordar, mantenha sua rotina habitual tanto quanto possível, sem se cobrar demais para compensar a noite. Se dificuldades de sono afetarem seu bem-estar ou o dia a dia de forma persistente, converse com um profissional de saúde.")
            ]),
        new(
            ArticleIds.SmallDayPlan,
            "Um plano diário com espaço",
            "Escolha o principal e deixe espaço para a vida",
            "TipsAndUpdates",
            2,
            [
                P("Um plano orienta quando considera sua energia real e deixa espaço para imprevistos. Uma lista longa raramente mostra quanto tempo deslocamentos, transições e descanso exigem. Comece perguntando: o que é realmente importante hoje e o que pode esperar sem consequências sérias?"),
                H("Faça um plano curto"),
                P("Anote uma tarefa principal, um pequeno passo cotidiano e uma pausa para comer ou se recuperar. Deixe um intervalo livre entre eles. Se uma tarefa estiver vaga, defina um resultado visível: não “resolver os papéis”, mas “encontrar o formulário necessário”. Guarde o restante em outra lista."),
                H("Revise o plano ao longo do dia"),
                P("Se as circunstâncias mudarem ou a energia diminuir, ajuste o plano: reduza uma etapa, adie um item ou peça ajuda. No fim do dia, pergunte se o plano ajudou a orientar você, não quantas tarefas concluiu. É um apoio que pode ser alterado, não uma promessa de fazer tudo.")
            ]),
        new(
            ArticleIds.AskForHelpTask,
            "Peça ajuda em uma parte específica",
            "Descreva a tarefa para facilitar a resposta",
            "TipsAndUpdates",
            2,
            [
                P("Pedir ajuda pode ser desconfortável, especialmente se você está acostumado a resolver tudo sozinho ou teme dar trabalho. Um pedido específico reduz a incerteza e ajuda a pessoa a entender o que é necessário. Você não precisa provar que está cansado o bastante nem que merece apoio."),
                H("Delimite o pedido"),
                P("Nomeie uma tarefa, o tamanho e um prazo útil: “Você pode revisar hoje o primeiro parágrafo deste e-mail?” Diga o que já fez e pergunte se o momento funciona. Deixe espaço para a pessoa recusar ou propor algo menor. Se precisa pensar junto, diga aproximadamente quanto tempo está pedindo."),
                H("Considere outra possibilidade"),
                P("Se a pessoa não puder ajudar, isso não significa necessariamente que ela esteja julgando você ou a relação. Talvez seja possível reduzir a tarefa, adiar o prazo ou pedir a outra pessoa. Se o assunto envolver segurança ou uma necessidade urgente, não pare diante de uma única recusa: procure apoio adequado.")
            ]),
        new(
            ArticleIds.MeaningfulActivity,
            "Escolha uma ação pequena que importa para você",
            "Ligue um passo a algo que você valoriza",
            "TipsAndUpdates",
            2,
            [
                P("Quando a energia está baixa, o sentido de uma tarefa grande pode desaparecer. Em vez de perguntar apenas “o que preciso terminar?”, experimente: “o que importa para mim nesta situação?”. Pode ser cuidado, conexão, curiosidade, responsabilidade ou descanso. Um valor não é um item da lista nem uma medida de produtividade; é uma direção que ajuda a escolher uma ação."),
                H("Transforme o valor em algo concreto"),
                P("Escolha uma ação de cinco a dez minutos nessa direção: enviar uma mensagem carinhosa, abrir o documento necessário, regar uma planta ou dormir mais cedo. Reduza o passo até conseguir começar sem esperar a motivação chegar. Se recuperar as forças for o mais importante agora, descansar também pode ser uma ação significativa."),
                H("Observe a experiência, não só o resultado"),
                P("Depois, perceba o que apareceu: interesse, cansaço, alívio ou nada especial. Você não precisa forçar uma sensação de satisfação. Se a ação não foi adequada ou não estava disponível, ajuste-a ou deixe para depois. O sentido não exige um grande resultado e não apaga limitações reais.")
            ]),
        new(
            ArticleIds.FlexibleGoals,
            "Mantenha a direção e ajuste o caminho",
            "Um objetivo pode se adaptar às mudanças das circunstâncias",
            "TipsAndUpdates",
            2,
            [
                P("Muitas vezes fazemos um plano em certas condições e precisamos executá-lo em outras. Se ele ficou inviável, isso é motivo para revisá-lo, não para se culpar. Separe três coisas: a direção que importa para você, o objetivo específico e a forma de alcançá-lo. O sentido pode continuar, mesmo que o prazo ou o volume de trabalho mudem."),
                H("Escolha um nível possível"),
                P("Você pode definir três versões: um mínimo para dias difíceis, o passo habitual e algo a mais se tiver disposição. Para estudar para uma prova, por exemplo: abrir o material e ler uma página, revisar um tema ou estudar toda a seção. Escolha um mínimo que ainda ajude a avançar, sem virar castigo."),
                H("Revise prazos e combinados"),
                P("Se outras pessoas dependem do objetivo, avise cedo sobre o atraso e sugira um novo prazo realista. Observe obstáculos que se repetem: próximo passo pouco claro, falta de tempo, cansaço ou recursos ausentes. Ajustar o plano ajuda a lidar com as condições; às vezes também é razoável mudar o objetivo ou pedir ajuda.")
            ]),
        new(
            ArticleIds.CelebrateCompletion,
            "Perceba um passo concluído antes de seguir",
            "Uma pausa breve torna o esforço visível",
            "TipsAndUpdates",
            2,
            [
                P("Depois de concluir algo, a atenção costuma pular direto para o que ainda falta. O dia pode parecer uma sequência interminável de tarefas pendentes. Faça uma pausa breve e nomeie um fato sem exagerar: “Enviei o e-mail”, “Pedi ajuda” ou “Descansei quando estava cansado”. Isso não é um ritual obrigatório de gratidão nem uma tentativa de fingir que tudo está bem."),
                H("Observe o que ajudou"),
                P("Se for útil, acrescente uma observação: que passo funcionou, o que exigiu esforço ou que apoio fez diferença. Assim, reconhecer o que fez vira informação para a próxima vez, não uma avaliação do seu valor. Não compare seu ritmo com o de outras pessoas nem diminua o que fez porque ainda há mais tarefas."),
                H("Escolha a próxima transição"),
                P("Depois da pausa, decida o que cabe agora: continuar, mudar de tarefa, pedir apoio ou parar por hoje. Concluir nem sempre significa fazer tudo com perfeição; às vezes basta parar em um ponto combinado e seguro. Em um dia difícil, você pode reconhecer o esforço sem precisar sentir alegria.")
            ]),

        new(
            ArticleIds.NameEmotion,
            "Dê um nome mais preciso ao sentimento",
            "Isso pode mostrar que tipo de apoio está faltando",
            "TipsAndUpdates",
            2,
            [
                P("“Não estou bem” comunica que algo está difícil, mas nem sempre indica o que pode ajudar. Se puder, acrescente um detalhe: preocupação, solidão, irritação, vergonha, mágoa ou cansaço. Não é preciso encontrar a palavra perfeita nem explicar o sentimento a alguém."),
                H("Separe o sentimento da situação"),
                P("Pergunte a si mesmo: o que aconteceu, o que estou sentindo e o que importa para mim agora? A raiva pode vir junto com o cansaço; a ansiedade, com a falta de informação. Anote o que percebe sem transformar isso em julgamento sobre si ou sobre as intenções de outra pessoa. Se não encontrar uma palavra, comece pelo que nota no corpo ou ao redor."),
                H("Escolha uma resposta pequena"),
                P("Pense se precisa de uma pausa, de clareza, de contato com alguém de confiança ou de um lugar mais seguro. Nomear um sentimento não obriga você a agir sob sua influência. Às vezes basta percebê-lo e adiar uma decisão. Se o sofrimento parecer insuportável ou você não conseguir se manter seguro, procure ajuda urgente.")
            ]),
        new(
            ArticleIds.MixedFeelings,
            "É possível sentir duas coisas diferentes ao mesmo tempo",
            "Reações contraditórias podem coexistir",
            "TipsAndUpdates",
            2,
            [
                P("Mudanças, relações próximas e decisões raramente trazem uma única reação. Você pode se animar com uma oportunidade e sentir tristeza pelo que ficou para trás; querer proximidade e também precisar de tempo sozinho. Sentimentos mistos não provam que você é incoerente ou escolheu errado."),
                H("Dê espaço aos dois lados"),
                P("Tente completar duas frases: “Fico contente porque…” e “Fico triste ou preocupado porque…”. Um lado não precisa anular o outro, e você não precisa decidir qual é o sentimento “verdadeiro”. Se os pensamentos estiverem confusos, escreva-os separadamente ou converse com alguém que não apresse uma conclusão."),
                H("Decida considerando valores e circunstâncias"),
                P("Sentimentos oferecem informações, e a decisão também pode considerar segurança, fatos, compromissos e o que importa para você. Escolha um próximo passo que não exija negar nenhum dos lados. Talvez ajude esperar, reunir informações ou conversar com alguém de confiança.")
            ]),
        new(
            ArticleIds.AngerPause,
            "Faça uma pausa antes de responder com raiva",
            "Reduza o risco primeiro e depois escolha as palavras",
            "TipsAndUpdates",
            2,
            [
                P("Quando a raiva aumenta, a atenção pode se estreitar e palavras ou ações podem intensificar a conversa. Se for seguro, pare de escrever ou proponha uma pausa breve: “Quero conversar sobre isso, mas preciso me acalmar. Volto ao assunto mais tarde”. Se estiver disposto, indique um horário realista para retomar."),
                H("Use a pausa para diminuir a tensão"),
                P("Vá para um lugar mais calmo, beba água ou faça por um tempo uma atividade neutra. Não envie mensagens para punir ou assustar a outra pessoa e não dirija se estiver muito agitado. Quando estiver mais calmo, separe os fatos das acusações e decida qual pedido ou limite deseja expressar."),
                H("A segurança é mais importante que a conversa"),
                P("Se houver risco de violência, ameaças ou perseguição, não tente resolver o conflito sozinho. Vá para um lugar seguro e procure alguém de confiança ou os serviços de emergência. Fazer uma pausa não obriga você a retomar a conversa; pode encerrá-la se continuar não for seguro.")
            ]),
        new(
            ArticleIds.ShameKindness,
            "Responda à vergonha sem se humilhar",
            "Você pode reparar um erro sem se punir",
            "TipsAndUpdates",
            2,
            [
                H("Separe o sentimento dos fatos"),
                P("A vergonha pode transformar uma atitude específica em um julgamento sobre toda a pessoa: “Cometi um erro” vira “Sou uma pessoa ruim”. Descreva a situação sem rótulos: o que você disse ou fez, o que aconteceu depois e quem foi afetado? Isso não elimina a responsabilidade; ajuda a identificar o que pode ser tratado."),
                H("Reconheça o impacto sem presumir"),
                P("Se suas palavras ou atitudes afetaram alguém, reconheça isso de forma direta e breve. Você pode dizer: “Eu interrompi você e entendo que isso pode ter parecido desrespeitoso.” Não é preciso começar explicando suas intenções nem pedir perdão. Pergunte se a pessoa aceita conversar sobre o que ajudaria a reparar a situação e respeite a resposta."),
                H("Escolha uma reparação possível"),
                P("Pode ser adequado pedir desculpas, corrigir um erro ou mudar um comportamento específico. Algumas consequências não podem ser desfeitas rapidamente; nesse caso, mudanças consistentes ao longo do tempo podem importar mais. Escolha um passo realista e não prometa o que não pode garantir. Punir-se não recupera a confiança nem repara o dano."),
                H("Preserve o respeito por si"),
                P("Tente falar consigo como falaria com alguém responsável que ainda merece respeito: “Lamento o que fiz. Posso reconhecer isso e decidir o que fazer agora.” Tratar-se com gentileza não é justificar o comportamento. Pode ajudar a manter o foco na responsabilidade e na ação, em vez de repetir insultos contra si."),
            ]),
        new(
            ArticleIds.GuiltRepair,
            "Culpa: reparar algo ou deixar passar",
            "Separe responsabilidade de autocobrança sem fim",
            "TipsAndUpdates",
            2,
            [
                P("A culpa pode indicar que você ultrapassou um limite importante ou causou dano. Mas sentir culpa não prova que tudo seja sua responsabilidade. Examine uma atitude específica em vez de condenar a pessoa inteira que você é."),
                H("Se você causou dano"),
                P("Nomeie o que aconteceu e o que pode ser reparado de forma realista. Se for adequado, peça desculpas de modo específico e sem justificativas, e pergunte o que a pessoa afetada deseja. Um pedido de desculpas não obriga a outra pessoa a perdoar nem a manter contato. Faça uma reparação razoável e mude o que estiver ao seu alcance."),
                H("Se não é sua responsabilidade ou você já reparou"),
                P("Veja se está assumindo os sentimentos, circunstâncias ou decisões de outra pessoa. Depois de uma reparação razoável, punir-se sem parar não ajuda quem foi ferido. Você pode reconhecer o arrependimento, aprender e escolher a próxima atitude. Uma situação complexa ou dolorosa pode ser conversada com um profissional.")
            ]),
        new(
            ArticleIds.EnvyInformation,
            "A inveja pode indicar o que você deseja",
            "Transforme comparação em uma direção própria",
            "TipsAndUpdates",
            2,
            [
                P("A inveja pode ser desconfortável e levar à autocrítica. Esse sentimento não determina se você é uma pessoa boa. Às vezes, aponta para um desejo que recebeu pouca atenção: mais liberdade, reconhecimento, proximidade ou tempo para algo importante."),
                H("Nomeie a necessidade por trás da comparação"),
                P("Pergunte o que exatamente inveja e que parte gostaria de ter na própria vida. Separe o valor desejado do caminho que outra pessoa escolheu. A autonomia pode ser importante para você mesmo que a trajetória dela não combine com a sua."),
                H("Dê um passo possível sem copiar"),
                P("Pense em uma ação para esta semana: pedir mais responsabilidade, escrever a alguém próximo ou reservar tempo para desenvolver uma habilidade. Talvez você perceba que o desejo vem mais da comparação do que dos seus valores; então pode deixá-lo de lado. A ideia não é se tornar outra pessoa, mas ouvir melhor sua própria direção.")
            ]),
        new(
            ArticleIds.AllowSadness,
            "A tristeza não precisa sumir agora",
            "Dê espaço ao sentimento e escolha apoio",
            "TipsAndUpdates",
            2,
            [
                P("Uma perda, separação, decepção ou cansaço podem vir acompanhados de tristeza. Você não precisa explicá-la imediatamente nem se obrigar a ficar bem. Pode reconhecer «está difícil agora», mesmo sem saber ainda o que fazer."),
                H("Escolha um apoio gentil"),
                P("Pergunte o que está disponível: ficar um pouco só, escrever a alguém próximo, comer, descansar ou fazer uma tarefa necessária. Não é preciso resolver tudo de uma vez. Ao pedir apoio, seja direto: «Não preciso de uma solução; pode ficar comigo?» ou «Pode me ajudar com uma tarefa específica?»."),
                H("Cuide de si sem exigir uma mudança no humor"),
                P("As necessidades básicas continuam importantes mesmo se a tristeza não mudar após um passo. Se ela continuar atrapalhando a vida ou ficar mais pesada, procure apoio profissional. Pedir ajuda não significa que você falhou; pode ser o próximo apoio possível.")
            ]),
        new(
            ArticleIds.Numbness,
            "Quando é difícil sentir alguma coisa",
            "Não se force a se abrir de uma vez",
            "TipsAndUpdates",
            2,
            [
                P("O entorpecimento ou a sensação de vazio podem causar estranhamento. Sozinhos, não explicam a causa. Você não precisa se obrigar a chorar, revisitar lembranças ou explicar tudo imediatamente. Comece por uma referência neutra e pelo que pode ajudar nos próximos minutos."),
                H("Confira necessidades simples"),
                P("Perceba onde está, que horas são e do que seu corpo pode precisar: água, comida, calor, descanso ou um lugar mais tranquilo. Escolha apenas o que estiver disponível. Você pode escrever a alguém próximo: «Não consigo encontrar as palavras agora; pode ficar em contato comigo um pouco?»."),
                H("Busque apoio se isso persistir"),
                P("Se o entorpecimento assusta, continua ou dificulta o autocuidado e as tarefas diárias, converse com um profissional. Não atribua automaticamente sintomas novos, intensos ou dolorosos ao estado emocional; procure avaliação médica quando necessário.")
            ]),
        new(
            ArticleIds.EmotionWave,
            "Um sentimento pode mudar, mesmo que não de imediato",
            "Observe sem cronômetro",
            "TipsAndUpdates",
            2,
            [
                P("Um sentimento intenso pode parecer permanente, sobretudo enquanto você está no meio dele. Ele pode mudar aos poucos, em ondas ou ainda não mudar. Você não precisa esperar que desapareça para cuidar de si ou escolher o próximo passo seguro."),
                H("Perceba sem exigir uma nota menor"),
                P("Se ajudar, dê um nome ao sentimento e avalie a intensidade de zero a dez. Isso não é uma prova; a nota não precisa cair. Você também pode notar onde está, o que aconteceu antes e o que oferece algum apoio agora."),
                H("Escolha algo para os próximos minutos"),
                P("Experimente um apoio simples: sentar, beber água, afastar-se do barulho ou falar com alguém de confiança. Mais tarde, você pode conferir de novo e comparar apenas com a própria experiência anterior. Se não mudou, isso não é fracasso; tente outro apoio ou procure ajuda se estiver difícil lidar.")
            ]),
        new(
            ArticleIds.BodyNoticingChoice,
            "Perceba o corpo em um ritmo confortável",
            "Um apoio externo também é válido",
            "TipsAndUpdates",
            2,
            [
                P("Prestar atenção à respiração e ao corpo ajuda algumas pessoas e aumenta o desconforto de outras. Você pode parar a observação corporal a qualquer momento. O objetivo não é encontrar a sensação certa, mas escolher uma forma segura e adequada de se orientar agora."),
                H("Faça uma checagem breve"),
                P("Se for confortável, perceba um detalhe neutro: os pés no chão, as costas apoiadas ou a temperatura do ar. Não é preciso mudar a respiração nem tentar relaxar. Fique com a observação apenas enquanto ela for adequada."),
                H("Mude o foco se o desconforto aumentar"),
                P("Se focar no corpo aumentar a ansiedade, abra os olhos e nomeie alguns objetos, suas cores ou formas. Você não precisa voltar às sensações corporais. Não atribua automaticamente sintomas novos, intensos ou dolorosos à ansiedade; converse com um profissional de saúde.")
            ]),
        new(
            ArticleIds.PauseBeforeReact,
            "Faça uma pausa entre impulso e resposta",
            "Primeiro veja se é seguro esperar",
            "TipsAndUpdates",
            2,
            [
                P("Uma emoção intensa pode levar você a enviar uma mensagem, aceitar ou recusar imediatamente. Uma pausa curta ajuda a conferir se a resposta combina com seu objetivo. Mas esperar nem sempre ajuda: se o atraso criar risco ou afetar algo importante, responda agora de forma breve e clara."),
                H("Salve um rascunho"),
                P("Defina o que deseja fazer: comunicar um fato, perguntar, estabelecer um limite ou combinar um horário. Se for seguro esperar, escreva um rascunho e deixe-o por alguns minutos. Depois retire acusações e frases que não ajudam no objetivo. Soltar o ar devagar pode criar uma pausa, mas não precisa mudar o sentimento."),
                H("Escolha uma resposta adequada ao contexto"),
                P("Releia a mensagem e confira se o pedido ou a informação está claro. Você pode responder brevemente, pedir tempo ou retomar a conversa depois. Se houver uma questão de segurança, prazo ou ajuda urgente, não use a pausa para evitar o assunto: comunique o necessário ou procure apoio.")
            ]),
        new(
            ArticleIds.EmotionalBoundary,
            "Os sentimentos dos outros não são seus para consertar",
            "Você pode se importar e manter limites",
            "TipsAndUpdates",
            2,
            [
                P("Quando alguém próximo sofre, é fácil sentir que você precisa encontrar uma solução ou eliminar todo o desconforto. Apoiar não significa assumir a responsabilidade pelos sentimentos e escolhas de outra pessoa. Seu cuidado pode ser acolhedor e ter limites ao mesmo tempo."),
                H("Pergunte que tipo de ajuda seria útil"),
                P("Pergunte: «Você quer que eu escute, ajude com algo específico ou pense com você nas opções?». Ofereça apenas o que pode fazer de verdade, como conversar por dez minutos ou ajudar em uma tarefa. Não prometa estar sempre disponível se não puder cumprir."),
                H("Explique seu limite com clareza"),
                P("Você pode dizer: «Eu me importo e posso conversar agora, mas não consigo resolver isso por você». Se não puder ajudar, indique outro recurso apenas se for adequado. Diante de perigo imediato, não dependa só do apoio pessoal: envolva alguém de confiança, um profissional ou o serviço de emergência.")
            ]),
        new(
            ArticleIds.SupportWithoutFixing,
            "Esteja presente sem resolver tudo",
            "Pergunte que apoio seria útil",
            "TipsAndUpdates",
            2,
            [
                P("Muitas pessoas dão conselhos por cuidado, mas em um momento difícil eles podem soar como pressão. Antes de sugerir uma solução, pergunte se a pessoa quer ser ouvida, ter companhia ou receber ajuda prática. Isso respeita a escolha dela e evita tentar resolver o problema errado."),
                H("Ofereça uma opção específica e limitada"),
                P("Pergunte: «Você quer que eu escute, fique com você ou ajude a pensar no próximo passo?». Se a pessoa escolher conversar, ouça sem interromper com conselhos nem exigir detalhes. Ofereça apenas o que pode cumprir: um tempo definido, uma ligação ou uma tarefa concreta."),
                H("Cuide da sua capacidade e da segurança"),
                P("Você pode se importar e dizer «agora não consigo». Não prometa segredo diante de uma ameaça imediata. Se a pessoa ou alguém próximo estiver em perigo, envolva alguém de confiança, um profissional ou o serviço de emergência; não seja a única fonte de apoio.")
            ]),
        new(
            ArticleIds.AfterCrying,
            "Depois de chorar, dê tempo a si mesmo",
            "Comece pelas necessidades simples, não por uma explicação",
            "TipsAndUpdates",
            2,
            [
                P("Depois de chorar muito, você pode sentir cansaço, tremor, vazio ou alívio; cada pessoa reage de um jeito. Não precisa explicar o choro nem se obrigar a se acalmar. Confira o que é mais imediato: você está em um lugar seguro? Precisa de água, de se aquecer, de uma posição confortável ou da presença de alguém? Escolha apenas o que fizer sentido para você."),
                H("Deixe o próximo passo bem pequeno"),
                P("Você pode lavar o rosto, beber água, se cobrir ou simplesmente sentar. Se essas ações não ajudarem ou forem desconfortáveis, não precisa fazê-las “do jeito certo”. Adie decisões importantes até ter mais disposição. Se quiser, escreva para alguém de confiança: “Está difícil agora. Você pode ficar disponível por um tempo?”"),
                H("Retome as atividades aos poucos"),
                P("Quando estiver pronto, escolha uma tarefa pequena ou descanse. Chorar não significa fraqueza nem que você voltou ao começo. Se isso atrapalha sua rotina com frequência, seu estado piora ou você não consegue se manter seguro, procure apoio profissional; diante de perigo imediato, busque ajuda urgente.")
            ]),

        new(
            ArticleIds.SpecificRequest,
            "Faça um pedido específico",
            "Contexto breve, uma ação e um momento adequado",
            "TipsAndUpdates",
            2,
            [
                P("Indiretas e explicações longas podem esconder o que você está pedindo. Experimente uma estrutura simples: contexto breve, ação concreta e momento. Por exemplo: “Quero conversar sobre a agenda. Você tem dez minutos hoje depois do jantar?” Isso não garante um sim, mas deixa claro o que a outra pessoa pode responder."),
                H("Deixe espaço para escolha"),
                P("Pergunte se agora é um bom momento e esteja aberto a um não ou a outra sugestão. Se não for urgente, ofereça duas opções. Não use ameaça ou culpa para conseguir concordância. Ao estabelecer um limite, diga também o que você fará."),
                H("Confira o que a resposta significa"),
                P("Se a resposta afirmativa for vaga, combine o horário ou o próximo passo. Se ainda não houver resposta, combinem quando retomar o assunto ou decida o que pode fazer por conta própria. Em uma situação insegura, uma conversa comum pode não bastar: escolha uma forma mais segura de conseguir apoio.")
            ]),
        new(
            ArticleIds.ListenReflect,
            "Entenda primeiro, responda depois",
            "Confira o sentido antes de oferecer um conselho",
            "TipsAndUpdates",
            2,
            [
                P("Em uma conversa tensa, é fácil preparar a resposta enquanto a outra pessoa ainda fala. Repetir brevemente o que você ouviu ajuda a conferir se entendeu e permite que a pessoa corrija. Não é uma técnica para vencer a discussão, mas uma forma de evitar responder a algo que não foi dito."),
                H("Resuma uma ideia principal"),
                P("Escolha uma ideia: “Se entendi bem, você ficou chateado porque os planos mudaram sem aviso?” Então pare e deixe a pessoa esclarecer. Não acrescente imediatamente uma defesa, um diagnóstico ou uma solução. Se estiver em dúvida, pergunte o que deixou passar."),
                H("Pergunte do que a pessoa precisa agora"),
                P("Você pode perguntar: “Você quer que eu apenas escute ou pensamos juntos no que fazer?” Mostrar que ouviu não significa concordar com todas as avaliações nem abandonar seus limites. Se a conversa ficar insegura ou intensa demais, faça uma pausa e retome apenas em condições adequadas.")
            ]),
        new(
            ArticleIds.BoundarySentence,
            "Um limite fala do que você fará",
            "Diga o que funciona para você e como vai agir",
            "TipsAndUpdates",
            2,
            [
                P("Um limite não serve para obrigar outra pessoa a agir de certo modo. Ele deixa claro o que é aceitável para você e o que fará se a situação continuar. Escolha um episódio específico em vez de explicar toda a relação. Se uma conversa direta puder levar a ameaças ou violência, não ensaie sozinho: pense primeiro na segurança e em quem pode apoiar você."),
                H("Seja breve e fale em primeira pessoa"),
                P("Use uma estrutura simples: “Quando acontece X, Y fica difícil para mim. Peço Z; se continuar, farei W.” Por exemplo: “Posso conversar sem insultos. Se continuarem, vou encerrar a ligação.” Prometa apenas uma ação que dependa de você e que possa cumprir. Não precisa provar que seu limite é válido nem convencer a outra pessoa a concordar."),
                H("Repita uma vez e aja"),
                P("Se tentarem transformar o limite em uma discussão sobre você ter ou não esse direito, repita-o com calma, sem novas justificativas. Depois faça o que disse, se for seguro. A outra pessoa pode não gostar do limite, e ele ainda pode ser importante. Se as circunstâncias mudarem, você pode ajustá-lo ou pedir apoio para mantê-lo.")
            ]),
        new(
            ArticleIds.NoWithoutEssay,
            "Você pode dizer não sem se justificar longamente",
            "Seja claro sem provar que seus motivos são suficientes",
            "TipsAndUpdates",
            2,
            [
                P("Dizer não pode decepcionar alguém ou gerar perguntas, e talvez você tema prejudicar a relação. Se recusar for seguro, uma frase clara basta. Você pode se importar com a outra pessoa e ainda assim negar o pedido. Decida o que realmente consegue oferecer; não prometa, sob pressão, algo que não pode ou não quer fazer."),
                H("Escolha palavras que combinem com você"),
                P("Você pode dizer: “Obrigado por pensar em mim, mas desta vez não posso”, “Agora não tenho disponibilidade para isso” ou “Esse horário não funciona para mim”. Se quiser, ofereça outra opção, mas isso não é obrigatório. Também não precisa contar todos os motivos pessoais. Ser gentil não exige ser vago."),
                H("Lide com a insistência"),
                P("Se a pessoa continuar perguntando, repita a resposta de forma breve em vez de inventar um novo motivo a cada vez. Você pode encerrar a conversa ou responder mais tarde. Se uma recusa direta puder levar a ameaças, controle ou dano, priorize sua segurança: envolva alguém de confiança, escolha uma forma mais segura de comunicar ou afaste-se, se puder.")
            ]),
        new(
            ArticleIds.DifficultTalkOpening,
            "Defina um objetivo pequeno para uma conversa difícil",
            "Comece com um episódio concreto e um pedido",
            "TipsAndUpdates",
            2,
            [
                P("Um assunto difícil pode virar rapidamente um julgamento sobre toda a relação. Antes de conversar, anote um objetivo: o que você quer esclarecer, resolver ou apenas comunicar? Depois escolha um episódio específico e um pedido. Se estiver com raiva, exausto ou com medo, você pode esperar; a conversa não precisa acontecer imediatamente."),
                H("Descreva o fato e o impacto"),
                P("Escolha um momento em que ambos estejam mais calmos e tenham tempo. Diga o que observou, como isso afetou você e que mudança gostaria de tentar. Por exemplo: “Quando os planos mudam em cima da hora, fica difícil organizar as caronas. Podemos avisar com antecedência?” Evite presumir intenções com frases como “Você sempre” ou “Você não se importa”."),
                H("Deixe espaço para a resposta"),
                P("Ouça como a outra pessoa entendeu, esclareça um mal-entendido ou combine um próximo passo viável. Se a tensão aumentar, combinem uma pausa e quando retomar. Se falar diretamente puder levar a violência ou retaliação, não trate técnicas de conversa como proteção: procure alguém de confiança ou um serviço profissional.")
            ]),
        new(
            ArticleIds.RepairAfterConflict,
            "Retome a conversa depois de uma discussão",
            "Verifique se a outra pessoa está disponível e escolha um ponto",
            "TipsAndUpdates",
            2,
            [
                P("Depois de uma discussão, você pode querer explicar tudo imediatamente ou nunca mais tocar no assunto. Antes de tentar esclarecer, pergunte se a outra pessoa está disposta a conversar e confira também se você está pronto. A primeira conversa pode ter um objetivo modesto: entender um episódio, não resolver toda a relação."),
                H("Fique em um momento específico"),
                P("Descreva o que aconteceu sem rótulos nem suposições sobre intenções. Nomeie sua parte, se houver, e pergunte como a outra pessoa viu a situação. Ouvir a versão dela não significa concordar automaticamente. Se as lembranças divergirem, esclareça um fato ou o sentido de uma frase, em vez de discutir tudo de uma vez."),
                H("Encerre com cuidado"),
                P("Diga o que ficou mais claro e qual pode ser o próximo passo: um pequeno acordo, outra conversa ou tempo para pensar. Se a tensão aumentar, combine uma pausa. Se houver ameaças, intimidação ou medo, não busque reconciliação a qualquer custo: encerre a conversa, vá para um lugar seguro e procure apoio.")
            ]),
        new(
            ArticleIds.ApologyResponsibility,
            "Peça desculpas com responsabilidade e limites",
            "Nomeie a ação concreta sem justificar o impacto",
            "TipsAndUpdates",
            2,
            [
                P("Um pedido de desculpas útil se concentra na ação e no impacto, não em provar que você é uma boa pessoa. Seja específico: “Interrompi você e não deixei terminar”. Reconheça o efeito e diga que sente muito, sem acrescentar “mas você também…”. Sua intenção pode ser explicada à parte, se a outra pessoa quiser ouvir."),
                H("Ofereça uma reparação realista"),
                P("Diga o que tentará fazer diferente na próxima vez e pergunte se um pequeno gesto ajudaria agora. Não prometa algo que não pode cumprir. A outra pessoa não precisa perdoar nem tranquilizar você imediatamente; dê tempo e aceite a resposta."),
                H("Responsabilidade não exige abrir mão da segurança"),
                P("Você pode reconhecer um erro específico e, ao mesmo tempo, recusar insultos, pressão ou acusações que considera falsas. Não use o pedido de desculpas para obter perdão ou retomar contato. Se a conversa ficar insegura, pare e mantenha uma distância segura.")
            ]),
        new(
            ArticleIds.FeedbackAsInformation,
            "Separe comentários sobre o trabalho do seu valor",
            "Procure informações concretas, não um veredito sobre você",
            "TipsAndUpdates",
            2,
            [
                P("Um comentário sobre um resultado pode parecer uma avaliação de quem você é por inteiro, sobretudo quando é inesperado ou dito com dureza. Faça uma pausa e separe três coisas: as palavras exatas, um fato verificável e a conclusão que você tirou sobre si. “Falta um exemplo no relatório” descreve o trabalho; “não faço nada direito” é uma generalização."),
                H("Esclareça o comentário"),
                P("Se ele for vago, peça um exemplo e pergunte que mudança seria observável. Escolha um ponto realista para testar no próximo trabalho. Nem todo modo de falar ajuda: insultos e humilhações não se tornam construtivos só por serem chamados de feedback."),
                H("Decida o próximo passo"),
                P("Você não precisa responder imediatamente. Pode anotar a parte útil, pensar mais tarde ou conversar com alguém que conheça o contexto. Se o comentário contrariar fatos ou acordos, esclareça com calma. Um trabalho e uma avaliação não definem todas as suas capacidades.")
            ]),
        new(
            ArticleIds.ReceiveNo,
            "Quando alguém diz não",
            "Recusar um pedido nem sempre é rejeitar você",
            "TipsAndUpdates",
            2,
            [
                H("Entenda a que a resposta se refere"),
                P("Um “não” pode se referir a um pedido específico, ao horário ou a uma opção. Não conclua depressa algo sobre a relação ou sobre seu valor se a pessoa não disse isso. Se for adequado, pergunte com calma: “Você quer dizer que agora não é possível?”"),
                H("Respeite o limite"),
                P("Se a recusa estiver clara, não transforme o pedido de esclarecimento em pressão. A outra pessoa pode recusar ou não explicar o motivo. Você pode se decepcionar, fazer uma pausa e decidir o próximo passo. Aceitar a resposta não significa considerá-la justa em todos os aspectos; significa não tentar obter concordância por pressão."),
                H("Encontre outra possibilidade"),
                P("Se a necessidade continua, separe-a desta fonte específica de ajuda. Se a pessoa parecer aberta, você pode perguntar uma vez sobre outro horário ou alternativa. Caso contrário, pense em quem mais poderia ajudar, que parte você consegue fazer ou se a tarefa pode esperar."),
                H("Dê espaço à decepção"),
                P("Nomeie o sentimento de forma simples: “Fiquei decepcionado; eu contava com essa ajuda.” Você não precisa se convencer de que isso não importa nem ficar calmo imediatamente. Quando a primeira reação diminuir, reveja as opções e escolha um próximo passo. A recusa de um pedido não define seu valor."),
            ]),
        new(
            ArticleIds.CheckAssumption,
            "Confira uma suposição com uma pergunta",
            "Esclareça o sentido antes de criar uma história",
            "TipsAndUpdates",
            2,
            [
                P("Uma mensagem ambígua deixa espaço para suposições: uma resposta curta pode parecer fria, e uma pausa, intencional. Mas um único sinal raramente mostra todo o contexto. Antes de concluir, separe o que observou do que interpretou."),
                H("Faça uma pergunta neutra"),
                P("Se a resposta importa, pergunte: «Entendi corretamente que…?» ou «Você quis dizer…?». Evite acusações e várias mensagens seguidas. Se não for urgente, dê tempo para a pessoa responder; escolha quando conferir de novo em vez de atualizar a conversa sem parar."),
                H("Veja se precisa mesmo esclarecer"),
                P("Se a resposta não mudaria sua atitude, você pode deixar a dúvida em aberto. Se mudaria, espere ou diga o que precisa saber e até quando. Se a conversa não for segura, escolha outro meio ou procure apoio. O objetivo é obter clareza útil, não certeza absoluta.")
            ]),
        new(
            ArticleIds.AskSupport,
            "Peça apoio dizendo o que ajudaria",
            "Um pedido concreto pode facilitar o começo",
            "TipsAndUpdates",
            2,
            [
                P("Pedir ajuda pode ser difícil quando você já está passando por um momento ruim. Talvez tema uma recusa, julgamento ou parecer um peso. Comece identificando o que ajudaria agora: ser ouvido, pensar nas opções junto com alguém, receber ajuda prática ou simplesmente não ficar sozinho. O pedido pode ser pequeno e ter um limite de tempo."),
                H("Diga que apoio precisa e por quanto tempo"),
                P("Seja específico: “Hoje foi difícil. Você pode me ouvir por dez minutos sem dar conselhos?” ou “Pode me ajudar a marcar uma consulta? Estou com dificuldade para começar.” Pergunte se agora é um bom momento. A pessoa pode aceitar, recusar ou sugerir outra opção. Você não precisa contar toda a história para justificar o pedido."),
                H("Se não der desta vez"),
                P("Uma recusa ou um horário ruim nem sempre significa que você não é importante. Considere procurar outra pessoa de confiança, escolher outro tipo de apoio ou fazer um pedido menor. Se houver perigo imediato ou você não conseguir se manter em segurança, não dependa apenas de uma pessoa próxima: procure apoio profissional ou de emergência.")
            ]),
        new(
            ArticleIds.ConflictNotFailure,
            "Um conflito nem sempre significa o fim da relação",
            "Observe como vocês se tratam",
            "TipsAndUpdates",
            2,
            [
                P("Diferenças podem existir mesmo em relações próximas. Importa não apenas o que é dito durante a discussão, mas também o que acontece depois: há escuta, responsabilidade e mudanças concretas? Um conflito isolado não responde a todas as perguntas sobre o futuro da relação."),
                H("Conversem sobre um assunto por vez"),
                P("Se ambos estiverem seguros e dispostos a conversar, escolham um episódio ou pedido específico. Descreva o que aconteceu, como isso afetou você e qual mudança concreta ajudaria. Pergunte como a outra pessoa viu a situação. Não é preciso concordar em tudo nem resolver tudo em uma conversa."),
                H("Não coloque reconciliação acima da segurança"),
                P("Respeito e responsabilidade precisam ser mútuos; não cabem só a você. Se houver ameaças, violência, controle ou medo pela sua segurança, procure proteção e apoio primeiro. Você não é obrigado a conversar para se reconciliar se isso não for seguro.")
            ]),
        new(
            ArticleIds.MakeExpectationsClear,
            "Fale das expectativas antes",
            "Não espere que a outra pessoa adivinhe",
            "TipsAndUpdates",
            2,
            [
                P("Conflitos do dia a dia às vezes surgem de ideias diferentes sobre prazos, papéis ou o que significa concluir uma tarefa, não necessariamente de más intenções. «Depois a gente faz» pode significar hoje para uma pessoa e na próxima semana para outra. Esclarecer antes mostra a diferença a tempo."),
                H("Combine detalhes concretos"),
                P("Antes de fazer algo em conjunto, conversem sobre quem fará o quê, até quando e o que conta como concluído. Confirme se entenderam o combinado da mesma forma, talvez resumindo por mensagem. Isso não garante concordância, mas deixa as expectativas visíveis."),
                H("Atualize o combinado quando os planos mudarem"),
                P("Se o prazo ou sua disponibilidade mudar, avise cedo e proponha outra opção. Conversem sobre o problema e o próximo passo, sem atribuir motivos. Se não chegarem a um acordo, definam o que cada um pode fazer separadamente e onde precisam de mais ajuda.")
            ]),
        new(
            ArticleIds.DigitalBoundaries,
            "Limites nas mensagens",
            "Notificações não precisam comandar seu dia",
            "TipsAndUpdates",
            2,
            [
                P("Alertas frequentes interrompem a atenção e podem criar a sensação de que você precisa responder na hora. Mas estar sempre disponível não é o mesmo que se importar. Você pode escolher uma rotina de comunicação compatível com suas responsabilidades e relações, desde que seja segura e prática."),
                H("Ajuste expectativas e notificações"),
                P("Escolha um horário para mensagens comuns e desligue sons ou prévias das que podem esperar. Se fizer sentido, conte às pessoas próximas quando costuma responder. Combine um meio claro e separado para urgências reais, para não perder mensagens importantes."),
                H("Deixe espaço para ajustar"),
                P("Experimente a rotina por alguns dias e veja se mensagens importantes continuam chegando e se fica mais fácil se concentrar. Se as circunstâncias mudarem, ajuste a regra. Não é proibir o contato, e sim responder com mais atenção sem estar disponível a cada minuto.")
            ]),
        new(
            ArticleIds.FamilyPressure,
            "Quando a família insiste com conselhos",
            "Agradeça e diga que você vai decidir",
            "TipsAndUpdates",
            2,
            [
                P("Um conselho pode vir de preocupação, mas a insistência repetida ainda cansa. Você pode reconhecer o cuidado de alguém sem aceitar que a pessoa decida por você. Uma frase curta costuma ser mais clara do que uma explicação longa que abre debate sobre cada ponto."),
                H("Prepare uma resposta tranquila"),
                P("Por exemplo: «Vejo que você está preocupado. Vou pensar e decidir». Se a conversa continuar, repita a frase, sugira falar disso depois ou mude de assunto. Você não precisa obter concordância para expressar sua decisão."),
                H("Considere a segurança primeiro"),
                P("Uma resposta direta não serve para toda relação. Se discordar puder trazer ameaças, violência, perda de moradia ou outro risco, não teste esse limite sozinho. Converse sobre um plano seguro com alguém de confiança ou um profissional e escolha um momento e uma forma de responder que reduzam o risco.")
            ]),
        new(
            ArticleIds.FriendshipInvitation,
            "Convide alguém sem fazer um grande plano",
            "Um convite pequeno é mais fácil de aceitar ou recusar",
            "TipsAndUpdates",
            2,
            [
                P("Organizar um grande programa pode parecer difícil. Um convite pequeno e concreto reduz a incerteza: ajuda a outra pessoa a imaginar o encontro e responder. Uma recusa ou agenda cheia indicam a disponibilidade atual dela, não seu valor."),
                H("Faça uma proposta simples"),
                P("Diga a atividade, o dia e a duração aproximada: «Quer caminhar vinte minutos na quinta depois do trabalho?». Acrescente que outro horário ou um não também estão bem. Você não precisa se desculpar pelo convite nem justificar por que quer encontrar a pessoa."),
                H("Deixe espaço para qualquer resposta"),
                P("Depois de enviar, espere em vez de mandar várias mensagens seguidas. Se a pessoa não puder, ofereça outra opção se ela demonstrar interesse ou deixe que tome a iniciativa. Se não houver resposta, volte aos seus planos e decida depois se quer tentar novamente.")
            ]),
        new(
            ArticleIds.SmallConnection,
            "Comece com um contato pequeno",
            "A conexão não precisa começar com uma conversa profunda",
            "TipsAndUpdates",
            2,
            [
                P("A solidão pode tornar o primeiro passo especialmente difícil. Você não precisa se tornar sociável de uma hora para outra nem encontrar logo uma amizade íntima. Escolha um contato com pouca pressão: mandar uma frase para alguém conhecido, cumprimentar um vizinho, ficar perto de pessoas em um lugar familiar ou conversar sobre um assunto neutro. Um passo pequeno é uma tentativa, não uma prova."),
                H("Ajuste o contato à sua disposição"),
                P("Pense no que costuma ser mais confortável: uma mensagem, uma ligação curta, uma atividade em grupo ou apenas um lugar público conhecido. Você pode limitar o tempo e planejar como sair se ficar cansado. Escolha uma pessoa e um ambiente com menos pressão. Se não houver resposta, não use um único momento para avaliar seu valor; tente em outra hora ou formato."),
                H("Perceba o que funciona para você"),
                P("Depois, observe o que foi confortável, o que consumiu energia e quanto tempo precisou para se recuperar. O objetivo não é contar conversas nem suportar um ambiente desagradável. Se a solidão interfere por muito tempo na sua vida ou seu bem-estar piora, considere buscar apoio de alguém de confiança ou de um profissional.")
            ]),

        new(
            ArticleIds.OrientNow,
            "Confira onde você está agora",
            "Uma forma gentil de se orientar no presente",
            "TipsAndUpdates",
            2,
            [
                H("Oriente-se sem pressa"),
                P("Quando a atenção é puxada para o passado ou para um futuro preocupante, às vezes ajuda perceber o que está ao redor. Isso não serve para obrigar você a se acalmar nem para testar sua concentração. O objetivo é simples: notar alguns fatos neutros do presente e depois escolher para onde direcionar a atenção."),
                H("Nomeie fatos simples"),
                P("Mantenha os olhos abertos se isso for mais confortável. Olhe ao redor e diga onde está, aproximadamente em que parte do dia e um objeto próximo. Você pode descrever a cor, o formato ou a função dele. Depois, note outro ponto neutro: um som do lado de fora, uma linha na parede ou a luz sobre uma superfície. Não é preciso encontrar um significado especial."),
                H("Adapte o exercício"),
                P("Escolha apenas observações que não sejam excessivas. Você não precisa listar muitos detalhes, se movimentar, tocar em algo ou prestar atenção à respiração. Uma frase pode bastar: “Estou aqui, é de manhã, há uma mesa à minha frente.” Se as palavras não vierem, apenas olhar para um objeto já basta."),
                H("Confira se funciona para você"),
                P("Depois de alguns segundos, pergunte a si mesmo se tudo parece um pouco mais claro, igual ou mais desconfortável. Qualquer resposta é válida. Se o desconforto aumentar, pare e escolha algo que pareça mais seguro; você pode pedir a alguém de confiança que fique com você. Não é preciso alcançar a calma nem continuar à força."),
            ]),
        new(
            ArticleIds.GroundingChoice,
            "Escolha um aterramento que combine com você",
            "Nem todos se sentem bem focando no corpo",
            "TipsAndUpdates",
            2,
            [
                H("Aterramento é uma escolha, não uma regra"),
                P("Aterramento costuma ser um exercício breve para perceber o presente, mas não existe uma forma única adequada para todos. Algumas pessoas preferem observar objetos ou ouvir um som; para outras, focar na respiração ou no corpo pode ser desconfortável. Você pode deixar qualquer método de lado e parar quando quiser."),
                H("Comece por algo externo"),
                P("Escolha um detalhe simples por perto: nomeie uma cor, encontre um objeto com linhas retas ou descreva para que ele serve. Outra opção é perceber um som constante ao fundo sem tentar descobrir de onde vem. Fique alguns segundos com um único ponto de apoio e depois confira como se sente."),
                H("Perceba o corpo apenas se quiser"),
                P("Se for confortável, note o apoio da cadeira, a posição dos pés ou o tecido da manga. Não é preciso percorrer o corpo todo, mudar de posição ou fechar os olhos. Se essa atenção trouxer dor, dormência, tensão intensa ou lembranças indesejadas, deixe-a de lado e escolha um objeto externo."),
                H("Mantenha a liberdade de mudar"),
                P("Pergunte a si mesmo: isso é tolerável, neutro ou está me deixando pior? Se for tolerável, você pode continuar por pouco tempo. Se nada mudar, isso é uma informação, não um fracasso. Se piorar, pare. A meta não é garantir alívio, mas encontrar um apoio adequado sem se pressionar."),
            ]),
        new(
            ArticleIds.AfterNightmare,
            "Depois de um pesadelo, volte com calma ao presente",
            "Não precisa interpretar nem reviver o sonho",
            "TipsAndUpdates",
            2,
            [
                P("Depois de um pesadelo, o corpo pode continuar reagindo como se o perigo ainda existisse. Não se exija dormir de novo imediatamente nem descobrir o significado do sonho. Se for confortável, acenda uma luz, olhe ao redor e lembre-se: “Foi um sonho; agora estou acordado.” Você pode dizer onde está, a data de hoje ou o nome de um objeto conhecido. Se prestar atenção ao ambiente ou ao corpo aumentar o mal-estar, pare e escolha outra coisa."),
                H("Escolha um próximo passo tranquilo"),
                P("Sente-se com conforto, beba água ou faça uma atividade calma e conhecida. Se ajudar, escreva para alguém de confiança; se não quiser acordar ninguém, deixe uma luz acesa. Não precisa anotar nem conversar sobre o sonho durante a noite. Volte para a cama quando estiver pronto, sem seguir um horário rígido."),
                H("Se os pesadelos se repetirem"),
                P("Observe apenas o que pode ajudar em uma conversa com um profissional, como a frequência e o efeito no sono e no dia. Não precisa buscar sozinho uma interpretação simbólica. Se os pesadelos atrapalharem o descanso com frequência ou estiverem ligados a uma experiência difícil, converse com um profissional de saúde. Em perigo imediato, priorize a segurança e a ajuda urgente.")
            ]),
        new(
            ArticleIds.AnniversaryReaction,
            "Uma data difícil pode pedir um plano mais leve",
            "A reação pode surgir antes, durante ou depois",
            "TipsAndUpdates",
            2,
            [
                P("Datas ligadas a uma perda, mudança ou acontecimento doloroso podem despertar reações diferentes. O desconforto pode surgir antes, no próprio dia ou depois; algumas pessoas quase não percebem uma reação. Nenhuma dessas respostas significa que você está lidando com isso “errado”. Você não precisa explicar a ninguém por que a data importa."),
                H("Decida como quer passar o dia"),
                P("Se for possível, reduza os compromissos e escolha com antecedência alguém para quem possa escrever ou ligar. Você pode lembrar da pessoa ou do acontecimento do seu jeito, manter a rotina ou não fazer nenhum ritual. Tenha uma alternativa caso fique difícil demais: sair mais cedo, fazer uma pausa ou pedir companhia."),
                H("Reserve tempo para se recuperar"),
                P("Pense no que ajudaria depois: uma refeição simples, dormir, uma noite livre ou conversar com alguém próximo. Não compare seus sentimentos com os de outras pessoas nem se obrigue a marcar a data. Se o sofrimento atrapalhar a vida diária por muito tempo, converse com um profissional; se houver perigo imediato, procure ajuda urgente.")
            ]),
        new(
            ArticleIds.PaceRecovery,
            "Recupere-se no seu ritmo",
            "Não transforme autocuidado em maratona",
            "TipsAndUpdates",
            2,
            [
                H("Descansar não é mais uma tarefa"),
                P("Quando tudo parece difícil, conselhos de autocuidado podem virar uma longa lista de obrigações. Com pouca energia, até uma prática útil pode parecer mais uma exigência. A recuperação não precisa ser rápida nem igual todos os dias. Você pode escolher um apoio pequeno ou não acrescentar nada hoje."),
                H("Escolha o mínimo possível"),
                P("Pergunte a si mesmo o que parece viável: beber água, comer, deixar o celular de lado por um momento, abrir a janela ou escrever para alguém de confiança. Escolha uma ação que caiba nas suas circunstâncias reais. Não precisa de cronômetro nem meta se isso trouxer pressão; um limite só ajuda quando facilita parar."),
                H("Observe o efeito sem se avaliar"),
                P("Depois, note o que mudou: ficou um pouco mais fácil, igual ou mais difícil? Isso não é uma nota para sua disciplina. Se uma prática não combinar com você, pare ou escolha outro tipo de apoio. Às vezes é útil perceber que você precisa de silêncio, comida, sono, ajuda prática ou companhia."),
                H("Peça apoio antes de se esgotar"),
                P("Se as tarefas do dia a dia continuarem difíceis por um tempo, não espere conseguir lidar com tudo sozinho. Conte a alguém próximo o que ficou complicado ou converse com um profissional sobre como você está. Pedir ajuda é um passo prático, como descansar; você não precisa provar que tentou tudo antes."),
            ]),
        MiniArticle(ArticleIds.SafetyFirst, "Segurança importa mais que o exercício", "A autoajuda não exige que você fique em perigo", "Se houver uma ameaça por perto, tente primeiro ir a um local mais seguro e falar com alguém que possa ajudar. Respiração e aterramento não substituem proteção, atendimento médico ou serviços de emergência. Se não conseguir sair por conta própria, peça a alguém próximo que chame ajuda."),
        new(
            ArticleIds.ChooseTrustedPerson,
            "Escolha alguém para pedir apoio",
            "Peça uma ajuda concreta e possível",
            "TipsAndUpdates",
            2,
            [
                P("Quando as coisas ficam difíceis, pode parecer necessário explicar tudo de uma vez. Mas o primeiro contato pode ser um pedido curto. Pense em alguém que costuma respeitar seus limites e ouvir com calma. Não precisa ser a pessoa mais próxima se essa relação não parecer segura."),
                H("Diga o que ajudaria"),
                P("Por exemplo: «Está difícil agora. Você pode conversar comigo por dez minutos?» ou «Pode me ajudar a decidir para quem ligar?». Se falar for difícil, envie um sinal curto combinado antes ou peça companhia sem perguntas. Veja se a pessoa pode falar neste momento."),
                H("Tenha outra opção em mente"),
                P("Alguém de confiança pode estar ocupado ou não saber como responder. Isso não significa que seu pedido foi errado. Pense em outra pessoa a quem recorrer ou em um serviço profissional local. Se houver perigo imediato, procure o serviço de emergência em vez de esperar a resposta de uma única pessoa.")
            ]),
        new(
            ArticleIds.AfterStressRecovery,
            "Depois de um evento estressante",
            "Dê tempo para voltar às tarefas comuns",
            "TipsAndUpdates",
            2,
            [
                P("Depois de um evento estressante, sua energia e concentração podem ficar limitadas. Você não precisa analisar tudo na hora nem voltar imediatamente ao ritmo habitual. Primeiro, veja do que precisa na próxima hora e qual tarefa realmente não pode esperar."),
                H("Comece com um apoio simples"),
                P("Escolha algo disponível: beber água, comer, trocar de roupa, ficar em silêncio ou escrever para alguém próximo. Se a lista de tarefas pesar, adie uma atividade não urgente para um horário específico. Não exija sentir melhora após cada passo."),
                H("Veja se precisa de apoio adicional"),
                P("Se os efeitos continuarem atrapalhando o sono, o trabalho, os estudos ou o dia a dia, converse com um profissional de saúde. Não atribua automaticamente sintomas físicos novos ou intensos ao estresse. Você pode pedir ajuda antes de chegar ao limite.")
            ]),
        MiniArticle(ArticleIds.FlashbackGrounding, "Quando o passado parece estar perto de novo", "Oriente-se no presente e mantenha suas escolhas", "Olhe ao redor e nomeie onde está e a data, se ajudar. Escolha um objeto visível ou fale com alguém próximo. Não se force a fechar os olhos, respirar fundo ou contar detalhes; se houver perigo, procure ajuda real. Você pode parar o exercício e procurar uma pessoa segura."),
        new(
            ArticleIds.RecoveryNotLinear,
            "A recuperação não é uma linha reta",
            "Um dia difícil não apaga o caminho percorrido",
            "TipsAndUpdates",
            2,
            [
                P("Sentimentos intensos podem voltar depois de um período mais tranquilo por cansaço, uma lembrança ou novas circunstâncias. Isso não prova que seus esforços desapareceram ou que você voltou ao começo. Em vez de julgar a si mesmo por inteiro, veja o que está acontecendo hoje e o que pode ajudar neste momento."),
                H("Torne o próximo passo possível"),
                P("Pergunte o que pode simplificar, adiar ou fazer com alguém hoje. Escolha uma necessidade básica e uma tarefa possível. Use algo que já ajudou apenas se ainda fizer sentido; você pode escolher outro caminho."),
                H("Peça apoio novamente se precisar"),
                P("Se a dificuldade aumentar, atrapalhar o dia a dia ou ficar difícil de manejar sozinho, procure alguém de confiança ou um profissional. Pedir apoio de novo faz parte do cuidado e não apaga seus avanços. Se houver perigo imediato, busque ajuda urgente.")
            ]),

        new(
            ArticleIds.BreathIsOptional,
            "A prática de respiração é opcional",
            "Não se force a mudar a respiração",
            "TipsAndUpdates",
            2,
            [
                H("Você não precisa focar na respiração"),
                P("Exercícios de respiração não servem para todo mundo nem são necessários em todo momento difícil. Prestar atenção em cada respiração pode aumentar a tensão ou trazer sensações desagradáveis. Você pode pular a prática, deixar a respiração natural e escolher outro apoio. Isso não significa que esteja fazendo algo errado."),
                H("Se quiser experimentar"),
                P("Encontre uma posição confortável e apenas perceba a respiração habitual por alguns segundos, sem contar, prender o ar ou tentar inspirar mais fundo. Você pode notar o movimento da roupa sobre o peito, apenas se isso for confortável. Uma tentativa breve basta; não há ritmo nem duração obrigatórios."),
                H("Pare se houver desconforto"),
                P("Se sentir tontura, mais ansiedade, falta de ar ou desconforto ao focar na respiração, pare o exercício e volte a respirar normalmente. Mude para um ponto externo, como uma cor ou um objeto. Não tente “corrigir” a sensação respirando mais fundo ou prendendo o ar."),
                H("Quando é importante buscar avaliação médica"),
                P("Esta prática não identifica a causa da falta de ar nem substitui atendimento. Falta de ar nova, intensa ou que piora rapidamente precisa de avaliação médica; diante de piora grave e repentina ou perigo imediato, contate o serviço de emergência local. Se um profissional recomendou uma técnica por motivo médico, siga as orientações individuais dele."),
            ]),
        new(
            ArticleIds.GroundingCanChange,
            "Se o aterramento não ajudar",
            "Mude de método ou pare",
            "TipsAndUpdates",
            2,
            [
                H("Não sentir efeito não é culpa sua"),
                P("Um exercício de aterramento talvez não combine com você neste momento. Ele não precisa mudar seu humor rapidamente, e não sentir alívio não significa que você fez algo errado. Focar em sensações, respiração ou lembranças às vezes aumenta a ansiedade. Se isso acontecer, considere sua reação em vez de insistir."),
                H("Pause e escolha novamente"),
                P("Pare se você se sentir pior, tonto, desconectado ou simplesmente quiser parar. Abra os olhos se estavam fechados e olhe para um objeto neutro, apenas se isso for confortável. Você não precisa respirar fundo, contar sensações ou repetir etapas até obter um resultado “certo”."),
                H("Tente uma opção mais simples"),
                P("Se quiser continuar, escolha um ponto externo mais simples: leia uma placa, nomeie uma cor ou perceba onde fica a porta. Você também pode deixar os exercícios de lado e fazer uma atividade cotidiana tranquila. Evite experimentar várias técnicas seguidas se isso aumentar a pressão."),
                H("Quando outra pessoa pode ajudar"),
                P("Se for difícil manter-se em segurança por conta própria, fale com alguém de confiança e diga o que ajudaria: companhia, apoio em uma tarefa prática ou ajuda para procurar um profissional. Em perigo imediato, contate os serviços de emergência locais. Você pode recusar um exercício e ainda assim merece apoio."),
            ]),
        new(
            ArticleIds.MovementAnchor,
            "Use o movimento como apoio",
            "Um movimento pequeno pode devolver escolhas",
            "TipsAndUpdates",
            2,
            [
                H("Mover-se é apenas uma opção"),
                P("Um movimento pequeno pode servir de apoio se estiver confortável para seu corpo agora. Não precisa melhorar seu humor nem parecer exercício. Você pode escolher uma ação mínima, observar algo se movendo ou preferir um objeto parado; todas são opções válidas."),
                H("Escolha uma posição estável"),
                P("Primeiro, confira se está sentado ou em pé com segurança, sem risco de perder o equilíbrio. Se for confortável, abra e feche os dedos devagar, gire suavemente os punhos ou note o apoio sob os pés. Um movimento dentro de um limite confortável basta; não é preciso se alongar, levantar ou repetir um número definido."),
                H("Observe sua resposta"),
                P("Perceba o que acontece enquanto se move. Se for neutro ou agradável, você pode continuar por alguns segundos. Pare se surgir dor, tontura, fraqueza ou mais ansiedade. Não force um sintoma por causa da prática; você pode escolher um ponto visual ou pedir ajuda."),
                H("Termine sem avaliar o resultado"),
                P("Quando quiser, pare o movimento e escolha o que fazer depois: ficar sentado, voltar a uma atividade habitual ou falar com alguém. Não precisa comparar como se move agora com o passado. Se sintomas físicos novos ou importantes dificultarem o movimento, converse com um profissional de saúde."),
            ]),
        new(
            ArticleIds.SensesAnchor,
            "Um apoio pelos sentidos",
            "Escolha um sinal neutro ao seu redor",
            "TipsAndUpdates",
            2,
            [
                H("Um sinal já basta"),
                P("Quando o ambiente oferece muitos estímulos, você pode escolher apenas um sinal neutro em vez de seguir uma lista longa. Por exemplo, notar uma cor, o formato de um objeto, um som constante ou a temperatura do ar. Não precisa encontrar cinco coisas, fechar os olhos ou usar todos os sentidos."),
                H("Escolha algo tolerável"),
                P("O ponto de apoio deve ser neutro o bastante para você. Luz forte, ruído, cheiros e toques podem distrair ou incomodar. Se um sinal for desagradável, não se force a permanecer nele. Você pode ir para um lugar mais silencioso, olhar um objeto familiar ou deixar a prática de lado."),
                H("Adapte ao que é acessível"),
                P("Se olhar ao redor for difícil, você pode nomear mentalmente um objeto conhecido ou notar um som baixo. Se o som distrair, escolha uma forma ou cor. Com limitações de visão, audição ou mobilidade, use qualquer referência acessível; não é necessário depender de um sentido específico."),
                H("Confira se serve agora"),
                P("Fique alguns segundos com o sinal escolhido e pergunte se está mais confortável, igual ou mais difícil. Não é preciso alcançar um estado específico. Se o desconforto aumentar, troque ou pare. Escolher outro sinal não é um erro; é respeitar seus limites."),
            ]),
        MiniArticle(ArticleIds.EarlyStressSigns, "Perceba sinais iniciais de sobrecarga", "Notá-los cedo abre mais opções", "Escolha um sinal inicial que você percebeu mais de uma vez, como tensão ou dificuldade de atenção. Anote brevemente em que situação ele aparece e escolha uma resposta: pausar, esclarecer a tarefa ou pedir ajuda. Isso pode orientar seu planejamento, mas não é um diagnóstico."),
        MiniArticle(ArticleIds.RelaxWithoutForce, "Relaxe sem esforço", "Você não precisa ficar totalmente calmo", "Escolha uma ação que exija pouca concentração: baixar os ombros, ficar mais confortável ou soltar as mãos. Deixe a respiração natural. Um pouco de conforto já basta; não force o corpo a relaxar por completo. Se prestar atenção ao corpo aumentar o desconforto, volte a atenção para algo ao redor."),
        MiniArticle(ArticleIds.BasicCareWithoutRules, "Cuidados básicos sem regras rígidas", "Escolha o que você precisa agora", "Escolha uma necessidade para a próxima hora e transforme-a em um gesto pequeno: um copo de água, um lanche, uma roupa quente ou uma mensagem. Se não estiver ao seu alcance, nomeie o obstáculo e peça ajuda concreta. Não conseguir resolver tudo sozinho não é fracasso pessoal."),
        new(
            ArticleIds.NewSymptomsCare,
            "Sintomas novos ou incomuns",
            "Não tente diagnosticar-se com um artigo",
            "TipsAndUpdates",
            2,
            [
                H("Avalie primeiro a urgência"),
                P("Um sintoma físico novo pode ter muitas causas, e um artigo não consegue identificar a sua com segurança. Se for intenso, estiver piorando rapidamente ou parecer perigoso, não adie o atendimento médico para fazer um exercício ou procurar explicações na internet. Em perigo imediato ou piora grave e repentina, contate o serviço de emergência local."),
                H("Anote o que percebeu, se for possível"),
                P("Uma nota breve pode ajudar na conversa com um profissional: quando começou, o que mudou, com que frequência acontece e o que mais você notou. Mencione medicamentos e mudanças recentes se forem relevantes. Você não precisa tentar chegar a um diagnóstico nem manter um registro detalhado se isso consumir energia demais."),
                H("Descreva o impacto no dia a dia"),
                P("Observe se o sintoma afeta o sono, os movimentos, a alimentação, o trabalho ou atividades habituais. Conte o que mais preocupa você e o que teme que possa significar. Você pode preparar perguntas ou pedir a alguém de confiança que acompanhe você."),
                H("Autoajuda não substitui avaliação médica"),
                P("Uma atividade tranquilizadora pode apoiar você enquanto organiza o atendimento, se for confortável, mas não identifica a causa do sintoma. Diante de piora repentina, dor intensa, dificuldade para respirar, perda de consciência ou outro sinal urgente, procure ajuda conforme as orientações locais. Se não souber o grau de urgência, contate um serviço de saúde e descreva o que está acontecendo."),
            ]),
        new(
            ArticleIds.FindTherapist,
            "Como escolher um profissional para a primeira conversa",
            "Busque um trabalho claro e seguro",
            "TipsAndUpdates",
            2,
            [
                P("Começar a busca pode ser difícil: os perfis parecem semelhantes e não dá para saber antes se haverá confiança. Você não precisa encontrar a pessoa perfeita na primeira tentativa. Confira primeiro o básico: formação e habilitação adequadas, experiência com sua questão, formato, custo e disponibilidade. Se a dúvida envolver saúde física ou medicamentos, pergunte qual profissional de saúde pode avaliá-la."),
                H("Faça perguntas práticas"),
                P("Antes de marcar ou na primeira conversa, pergunte como o trabalho costuma acontecer, como os objetivos são definidos e como pode dizer que o formato não está ajudando. Confirme custos, cancelamentos, contato entre consultas e como funciona a confidencialidade e seus limites. Você não precisa contar detalhes pessoais por telefone para saber as condições."),
                H("Avalie a relação de trabalho com o tempo"),
                P("Depois da conversa, pense se o processo ficou claro, se você conseguiu fazer perguntas e se seus limites foram respeitados. Sentir algum desconforto no primeiro encontro não prova, por si só, que o profissional não é adequado; clareza e segurança também importam. Se a relação não melhorar, você pode conversar sobre isso ou procurar outra pessoa. Em perigo imediato, não espere uma consulta marcada: busque ajuda urgente.")
            ]),
        new(
            ArticleIds.FirstAppointment,
            "Na primeira consulta, um exemplo já basta",
            "Você não precisa contar toda a história perfeitamente",
            "TipsAndUpdates",
            2,
            [
                P("Antes da primeira conversa, é fácil tentar preparar toda a história e encontrar as palavras certas. Isso não é necessário. Se ajudar, anote uma situação recente que mostre o que preocupa e o que você gostaria de mudar. Você pode levar a anotação, lê-la ou pedir ao profissional que faça uma pergunta de cada vez."),
                H("Leve as perguntas que importam"),
                P("Você pode perguntar como serão as sessões, o que é confidencial e em que situações informações podem ser compartilhadas, como os objetivos são combinados e o que fazer se seu estado piorar entre consultas. Também pode perguntar sobre custo, duração e cancelamentos. Não precisa perguntar tudo de uma vez; comece pelo mais importante."),
                H("Mantenha a opção de pausar"),
                P("Você pode dizer que ainda não está pronto para falar de um assunto, pedir que expliquem uma pergunta ou fazer uma pausa. A primeira consulta serve para conhecer o formato, não para testar se você conta bem sua história. Depois, pense se foi suficientemente segura e clara. Você pode decidir mais tarde se quer continuar.")
            ]),
        new(
            ArticleIds.DescribeSymptoms,
            "Descreva o que acontece com exemplos reais",
            "Quando começou, como se repete e como afeta o cotidiano",
            "TipsAndUpdates",
            2,
            [
                P("Você não precisa de termos técnicos nem de uma explicação pronta para falar de algo difícil. Comece com um exemplo recente: o que estava acontecendo, o que percebeu e o que ficou mais difícil. Pode dizer “não tenho certeza” ou “ainda não consigo explicar melhor”. O objetivo é compreender junto, não adivinhar um diagnóstico antes da conversa."),
                H("Reúna alguns pontos úteis"),
                P("Se lembrar, anote quando começou, com que frequência acontece, quanto dura e em quais situações muda. Conte como afeta o sono, os estudos, o trabalho, as relações ou o cuidado pessoal. Acrescente o que tentou e o que ajudou um pouco ou piorou. Não precisa manter um diário detalhado se isso for cansativo."),
                H("Prepare perguntas e informações relevantes"),
                P("Você pode anotar medicamentos, mudanças de saúde ou outros detalhes que pareçam relacionados; se não souber, pergunte ao profissional o que é útil. Não altere um tratamento com base em artigo ou questionário. Sintomas físicos novos ou intensos precisam de avaliação médica; em perigo imediato, procure ajuda urgente.")
            ]),
        new(
            ArticleIds.SelfHelpLimits,
            "Quando a autoajuda não é suficiente",
            "O apoio profissional é um próximo passo válido",
            "TipsAndUpdates",
            2,
            [
                H("Perceba quando a dificuldade persiste"),
                P("A autoajuda pode apoiar desafios do cotidiano, mas não precisa resolver tudo. O apoio profissional pode ser útil quando a situação afeta o sono, trabalho, estudo, relações ou autocuidado por bastante tempo; quando piora; ou quando você começa a abandonar atividades importantes. Não é preciso esperar até ficar insuportável."),
                H("Você não precisa ter um diagnóstico"),
                P("Basta descrever o que mudou e há quanto tempo isso acontece. Conforme as opções disponíveis, você pode começar com um profissional de atenção primária, psicólogo ou outro profissional qualificado. Se não souber a quem recorrer, pergunte a um serviço de saúde qual seria um primeiro passo."),
                H("Prepare um resumo curto"),
                P("Antes da conversa, anote alguns pontos: o que mais preocupa você, quando começou, como afeta o dia a dia e o que já tentou. Inclua perguntas sobre opções de apoio. Você não precisa contar tudo de uma vez; pode pedir explicações para termos desconhecidos e combinar um próximo passo."),
                H("Pedir ajuda já é uma ação"),
                P("Você não precisa provar que tentou o suficiente sozinho. Se marcar uma consulta ou iniciar a conversa parecer difícil, peça a alguém próximo que ajude a encontrar um contato ou fique com você. Se houver perigo imediato para você ou outra pessoa, contate o serviço de emergência local."),
            ]),

        new(
            ArticleIds.ScreeningNotDiagnosis,
            "Um questionário não é um diagnóstico",
            "O resultado pode iniciar uma conversa, não colocar um rótulo",
            "TipsAndUpdates",
            2,
            [
                H("O que um resultado pode mostrar"),
                P("Um questionário reúne respostas sobre experiências em um período definido e a perguntas específicas. A pontuação pode sugerir assuntos para conversar, mas não explica sozinha a causa do que você sente. Acontecimentos recentes, saúde, sono e a interpretação das perguntas podem influenciar as respostas."),
                H("O que a pontuação não determina"),
                P("O resultado não confirma nem descarta um diagnóstico e não substitui uma conversa com um profissional. Faixas ou cores pertencem àquela ferramenta e não são uma conclusão definitiva sobre você. Uma pontuação alta não define o que está “errado” com você; uma baixa não invalida dificuldades que afetam sua vida."),
                H("Use como anotação para conversar"),
                P("Se o resultado preocupar você, guarde-o com a data e pense no que estava acontecendo naquele período. Anote quais perguntas chamaram sua atenção e o que gostaria de perguntar a um profissional. Não é necessário repetir o questionário muitas vezes para obter um número específico."),
                H("Não mude o cuidado com base em uma pontuação"),
                P("Não comece, interrompa ou altere um tratamento somente por causa de uma pontuação no aplicativo. Converse com um profissional qualificado, que pode considerar as respostas no contexto. Se seu estado piorar de repente ou houver perigo imediato, não espere para refazer o questionário: procure ajuda urgente."),
            ]),
        MiniArticle(ArticleIds.SupportPlan, "Monte um plano breve de apoio", "Anote sinais, passos e contatos", "Escreva como percebe que as coisas pioram, o que costuma ajudar e a quem pode avisar. Acrescente contatos profissionais e serviços locais de emergência. O plano não substitui ajuda; indica quem procurar quando pensar fica difícil. Confira antes se os contatos estão disponíveis na sua região."),
        MiniArticle(ArticleIds.CrisisSteps, "Se você não está seguro agora", "Conecte-se a ajuda em tempo real", "Vá para um lugar mais seguro se puder e contate o serviço local de emergência ou alguém de confiança. Diga brevemente o que está acontecendo e onde está. Não fique sozinho se houver perigo imediato. Se ligar for difícil, peça que alguém acompanhe a chamada."),
        MiniArticle(ArticleIds.MedicationWithClinician, "Converse com um profissional sobre medicamentos", "Não altere uma receita por conta própria", "Se tiver dúvidas, anote o nome do medicamento, sua pergunta e qualquer efeito indesejado e fale com quem prescreveu ou com um farmacêutico. Não comece, interrompa nem mude a dose com base em um artigo ou aplicativo. Consulte a bula ou um farmacêutico; as orientações variam."),
        new(
            ArticleIds.DeadlineConversation,
            "Se o prazo estiver ameaçado, avise cedo",
            "Compartilhe os fatos, uma estimativa realista e opções",
            "TipsAndUpdates",
            2,
            [
                P("Quando um prazo corre risco, a preocupação pode levar você a ficar em silêncio ou prometer mais do que consegue entregar. Um aviso curto ajuda mais enquanto ainda há escolhas. Antes de falar, confira o que está pronto, o que falta e o que depende de você ou de fatores externos. Não precisa esconder o atraso nem se justificar com uma longa história."),
                H("Ofereça opções viáveis"),
                P("Diga os fatos e sua melhor estimativa: “O rascunho está pronto; a revisão levará mais dois dias.” Sugira alternativas: mudar o prazo, reduzir o escopo, enviar agora uma parte concluída ou combinar uma revisão intermediária. Se ainda não souber estimar, diga isso e informe quando poderá atualizar."),
                H("Confirme o combinado"),
                P("Confira qual opção foi escolhida, quem precisa saber e quando você dará notícias do andamento. Não prometa uma data que dependa de abrir mão do sono ou de outras necessidades importantes. Se os atrasos se repetirem, analise a causa separadamente: tamanho da tarefa, recursos ou prioridades pouco claras. Isso ajuda a planejar melhor sem transformar o problema em culpa pessoal.")
            ]),
        new(
            ArticleIds.DifficultMessageReply,
            "Faça uma pausa antes de responder a uma mensagem difícil",
            "Decida primeiro o que quer alcançar com a resposta",
            "TipsAndUpdates",
            2,
            [
                P("Uma mensagem ríspida ou ambígua pode dar vontade de responder na hora. Se não houver urgência prática, dê um tempo a si mesmo. Separe as palavras exatas da intenção que você imaginou: o texto pode parecer frio, mas sozinho nem sempre explica o motivo. Espere até saber o que quer que sua resposta faça."),
                H("Escolha o objetivo e o formato"),
                P("Você pode querer esclarecer um fato, estabelecer um limite, comunicar uma decisão ou adiar a conversa. Escreva um rascunho e retire o que só aumentaria a discussão. Por exemplo: “Vi sua mensagem. Respondo à pergunta amanhã” ou “Posso conversar sobre isso sem insultos”. Para um assunto complexo, uma ligação ou conversa presencial pode ser melhor que mensagens, se for seguro."),
                H("Proteja-se e guarde o que for importante"),
                P("Se a mensagem tiver ameaças, assédio ou coerção, você não precisa responder nem manter contato. Guarde informações necessárias, use opções de bloqueio ou denúncia e procure apoio. Se houver ameaça imediata, vá para um lugar seguro e contate os serviços de emergência ou alguém de confiança.")
            ]),
        new(
            ArticleIds.CancelPlans,
            "Cancele os planos com clareza e cuidado",
            "Avise cedo e compartilhe só o que quiser",
            "TipsAndUpdates",
            2,
            [
                P("Às vezes é preciso mudar os planos por saúde, circunstâncias ou falta de energia. Avise a outra pessoa assim que puder, especialmente se ela já estiver contando com o encontro. Uma frase clara basta: “Preciso cancelar hoje.” Você pode guardar o motivo para si; uma mensagem curta não é grosseira por não trazer uma longa explicação."),
                H("Sugira outra data se realmente quiser"),
                P("Se quiser mesmo se encontrar depois, proponha um dia específico ou pergunte o que funciona para a outra pessoa. Não prometa uma nova data por culpa se não souber se poderá cumprir. Reconheça um impacto prático, se houver: “Sei que você reservou a noite.” A outra pessoa pode ficar decepcionada ou não querer remarcar."),
                H("Priorize segurança e bem-estar"),
                P("Se você está cancelando porque a situação não parece segura, não precisa manter o plano para facilitar a vida de outra pessoa. Escolha uma forma de avisar que não aumente o risco; uma mensagem curta ou a ajuda de alguém de confiança pode ser mais segura. Se os cancelamentos forem frequentes e isso preocupar você, pense no que está dificultando sem se culpar.")
            ]),
    ];
}
