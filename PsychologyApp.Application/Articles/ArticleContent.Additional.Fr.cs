namespace PsychologyApp.Application.Articles;

public static partial class ArticleContent
{
    private static readonly Article[] AdditionalArticlesFr =
    [
        new(
            ArticleIds.CallNerves,
            "Le stress avant un appel",
            "Préparez un échange, pas une performance parfaite",
            "TipsAndUpdates",
            2,
            [
                P("Un appel peut inquiéter parce que beaucoup de choses sont inconnues : qui répondra, quelles questions seront posées, quelle sera la réaction ? Choisissez un objectif pratique, comme prendre rendez-vous, vérifier un horaire ou transmettre une information. Cela suffit ; vous n’avez pas à prévoir chaque phrase."),
                H("Gardez un repère à portée de main"),
                P("Notez le nom de la personne, votre objectif et une phrase d’ouverture : « Bonjour, j’appelle pour me renseigner sur… ». Préparez les dates et questions utiles. Vous pouvez demander à votre interlocuteur de répéter. Pour un échange difficile, vous pouvez dire : « J’ai besoin d’un instant pour réfléchir » ou proposer de reprendre plus tard."),
                H("Après l’appel"),
                P("Notez ce que vous avez appris et la suite éventuelle. Ne vous jugez pas selon la fluidité de vos paroles : les pauses et le stress n’enlèvent rien au but de l’appel. Si vous n’avez pas réussi à joindre la personne, choisissez une prochaine voie : rappeler, écrire ou demander de l’aide. Si les appels vous empêchent souvent d’avancer sur des sujets importants, vous pouvez en parler à un professionnel adapté.")
            ]),
        new(
            ArticleIds.WaitingForReply,
            "En attendant une réponse",
            "Supporter l’incertitude et choisir la suite",
            "TipsAndUpdates",
            2,
            [
                P("En attendant une réponse, les suppositions arrivent vite : « J’ai dit quelque chose de travers », « On m’ignore » ou « C’est urgent ». Pourtant, le silence ne dit pas à lui seul pourquoi la personne ne répond pas. Elle peut être occupée, loin de son téléphone, en train de réfléchir ou ne pas vouloir répondre pour le moment. Tant que vous n’en savez pas plus, évitez de prendre une interprétation pour un fait."),
                H("Distinguer le fait de l’interprétation"),
                P("Par exemple, votre message est marqué comme lu, mais vous n’avez pas de réponse. Les faits sont l’indication de lecture et l’heure. « La relation est finie » est une explication possible, pas une preuve. Essayez d’en nommer deux autres, dont une neutre. Il ne s’agit pas de vous convaincre que tout va bien, mais de reconnaître que vous manquez encore d’informations."),
                H("Vérifier s’il faut agir maintenant"),
                P("Y a-t-il une échéance, un enjeu de sécurité ou une conséquence qui ne peut pas attendre ? Si oui, ne dépendez pas uniquement d’une réponse dans le chat : utilisez un autre moyen de contact adapté, appelez une personne qui peut aider ou, en cas de danger immédiat, les secours locaux. Si ce n’est pas urgent, choisissez quand consulter le message à nouveau. Il n’existe pas de délai universel : tenez compte de la situation et de vos accords."),
                H("Un plan plutôt que des vérifications répétées"),
                List(
                    "Dites ce que vous savez sans l’interpréter : « Je n’ai pas encore de réponse ».",
                    "Demandez-vous quelle information vous est réellement nécessaire et si vous pouvez l’obtenir autrement.",
                    "Choisissez l’heure de la prochaine vérification, puis éloignez le chat.",
                    "Faites une petite tâche qui ne dépend pas d’une notification."),
                P("Si la réponse compte et que le délai convenu est passé, vous pouvez envoyer une seule relance courte, sans reproche : « Peux-tu me dire si tu pourras répondre aujourd’hui ? Sinon, je vais m’organiser autrement. » Votre besoin est clair, tout en laissant la place à une réponse honnête."),
                H("Si cela se répète"),
                P("Observez la tendance plutôt qu’un seul silence. À un moment calme, discutez des délais qui comptent pour chacun et de ce que vous ferez si l’un de vous est indisponible. Vous pouvez décider à partir des informations disponibles. Le silence d’une autre personne ne mesure pas votre valeur ; une explication neutre ne vous oblige pas à attendre sans fin.")
            ]),
        new(
            ArticleIds.AfterSocialEvent,
            "Après une rencontre : ne pas repasser chaque phrase",
            "Faire le point sans transformer l’échange en autocritique",
            "TipsAndUpdates",
            2,
            [
                P("Après une rencontre importante, la conversation peut revenir sans cesse à l’esprit. On remarque facilement les silences, les phrases maladroites ou l’expression de l’autre, puis on conclut que tout s’est mal passé. Pourtant, la mémoire n’est pas un enregistrement complet : la fatigue, l’anxiété et ce qui semble important sur le moment influencent les souvenirs."),
                H("Distinguer ce qui s’est passé de ce que vous en concluez"),
                P("Notez un moment précis : qu’avez-vous réellement dit ou fait ? Puis écrivez séparément le jugement sur vous, par exemple « je suis ennuyeux » ou « ils ont été déçus ». C’est une interprétation. Quelles autres explications sont possibles ? La conversation a peut-être simplement été courte, la personne était pressée ou le sujet était difficile. Vous n’avez pas à choisir l’explication la plus positive ; évitez seulement de prendre la version anxieuse pour une certitude."),
                H("Faut-il donner une suite à l’échange ?"),
                P("Voyez s’il reste une promesse précise, une question ou une erreur qui demande vraiment votre attention. Si oui, notez l’action et le moment où vous y reviendrez, par exemple clarifier un détail demain. Sinon, repasser la scène ajoutera probablement peu d’informations. Vous pouvez vous dire : « J’ai vérifié ce que je pouvais ; il n’y a pas de nouvel élément pour l’instant. »"),
                H("Clore la rencontre en quelques gestes"),
                List(
                    "Nommez un moment neutre ou agréable sans vous juger dans votre ensemble.",
                    "Gardez une question pour une clarification au calme.",
                    "Choisissez un retour au présent : boire de l’eau, rester au calme, marcher ou faire une petite tâche.",
                    "Si la pensée revient, remarquez-la et reportez le bilan au moment choisi."),
                P("Le but n’est pas de vous prouver que la rencontre était parfaite. Il suffit de voir s’il reste une action utile et de laisser le reste incertain. Si ces inquiétudes gênent souvent vos relations ou votre repos, vous pouvez en parler à un professionnel."),
            ]),
        new(
            ArticleIds.FearOfMistakes,
            "Une erreur n’est pas un verdict",
            "Définissez ce qui est suffisamment bien",
            "TipsAndUpdates",
            2,
            [
                P("La peur de se tromper peut transformer une tâche ordinaire en examen : tout vérifier plusieurs fois, attendre une certitude totale ou repousser le début. Il ne s’agit pas de minimiser les erreurs. Il est plus utile de décider à l’avance ce qui compte, quel risque vérifier et à quel moment s’arrêter raisonnablement."),
                H("Définir ce qui suffit avant de commencer"),
                P("Décrivez le résultat de façon observable : envoyer un message avec les informations nécessaires, préparer un brouillon ou respecter les exigences essentielles. Demandez-vous ensuite quelles seraient les conséquences concrètes d’une erreur et quelle vérification réduirait ce risque. La sécurité, la santé, l’argent et les documents importants peuvent exiger des règles précises et un contrôle attentif ; le principe du « suffisamment bien » ne les remplace pas."),
                H("Quand l’erreur a déjà eu lieu"),
                P("Séparez l’événement d’un jugement sur vous. Au lieu de « j’ai tout gâché », nommez le fait : « le document comporte une date erronée ». Voyez qui est concerné, si une correction est possible et qui doit être informé. Assumer sa responsabilité consiste à faire un geste utile pour réparer, pas à se punir sans fin."),
                H("Faire le point sans s’attaquer"),
                List(
                    "Que s’est-il passé, en restant aux faits ?",
                    "Quel est l’impact réel et qu’est-ce que je suppose encore ?",
                    "Quelle action pourrait corriger ou limiter les conséquences ?",
                    "Que puis-je ajuster la prochaine fois sans exiger l’absence d’erreur ?"),
                P("Si la peur de se tromper gêne régulièrement le travail, les études ou les relations, vous pouvez en parler à un professionnel. Cela ne signifie pas qu’il y a quelque chose qui ne va pas chez vous ; cela peut aider à trouver un soutien adapté."),
            ]),
        new(
            ArticleIds.ChangeAnxiety,
            "Quand le changement inquiète",
            "Distinguer le connu, l’inconnu et ce qui dépend de vous",
            "TipsAndUpdates",
            2,
            [
                P("Un changement peut inquiéter même s’il est souhaité : les habitudes bougent et le résultat reste incertain. Tout planifier épuise sans rendre l’avenir prévisible. Séparez ce que vous pouvez faire maintenant des questions encore sans réponse."),
                H("Trois colonnes"),
                P("Notez ce qui est connu, ce qui ne l’est pas et ce que vous pouvez influencer. La date d’un déménagement peut être fixée, le trajet reste à préciser, et vous pouvez réunir les documents aujourd’hui. Cherchez une réponse d’abord si elle peut changer votre prochaine décision."),
                H("Choisir le prochain petit pas"),
                P("Quelle action aiderait dans les prochaines 24 heures : confirmer un délai, préparer un objet, parler à une personne concernée ou réserver du temps pour souffler ? Si rien n’est possible maintenant, choisissez un moment pour reprendre la question. Cela ne garantit pas l’issue, mais évite de la porter toute la journée."),
                List(
                    "Nommez ce qui a réellement changé.",
                    "Choisissez une question qui influence une décision.",
                    "Fixez une action ou un moment pour vérifier à nouveau.",
                    "Laissez le reste en attente de nouvelles informations."),
                P("Si le changement implique un danger ou des conséquences graves, vérifiez les faits et contactez des personnes ou services capables d’aider."),
            ]),
        new(
            ArticleIds.WorryBeforeTask,
            "Avant une tâche difficile",
            "Commencez par une étape sûre et limitée",
            "TipsAndUpdates",
            2,
            [
                P("Avant une tâche importante, l’anxiété peut vous dire d’attendre une confiance totale ou un plan parfait. Pourtant, on ne se sent pas toujours prêt avant de commencer. Repérez d’abord ce qui rend la tâche difficile : résultat incertain, trop grande ampleur, information manquante, risque d’erreur ou conversation à mener."),
                H("Choisissez la première partie"),
                P("Prenez une étape sûre de 5 à 15 minutes : ouvrir un document, rassembler le matériel, lire les consignes ou poser une question précise. Décidez à l’avance où vous arrêterez. Si une autorisation, un savoir-faire ou l’accord de quelqu’un est nécessaire, ne devinez pas : notez à qui demander."),
                H("Examinez le plan, pas votre valeur"),
                P("Après cette étape, vérifiez ce qui est plus clair et ce qui reste inconnu. Vous pouvez poursuivre, faire une pause ou ajuster le plan. S’arrêter au point prévu fait aussi partie de l’engagement pris avec vous-même. Si la tâche reste trop lourde, découpez-la davantage ou demandez du soutien plutôt que d’y voir un manque de volonté.")
            ]),
        new(
            ArticleIds.AvoidedFirstStep,
            "Faites seulement le premier pas",
            "Le démarrage peut durer deux minutes",
            "TipsAndUpdates",
            2,
            [
                P("Quand une tâche semble grande ou floue, on peut finir par l’éviter entièrement. Ce n’est pas toujours de la paresse : le début n’est peut-être pas clair, l’énergie manque ou le prix d’une erreur paraît trop élevé. Vous n’avez pas à vous promettre de tout terminer. Rendez le commencement visible et limité."),
                H("Transformer un objectif en action"),
                P("« M’occuper du rapport » ne dit pas quoi faire concrètement. « Ouvrir le fichier et noter trois questions », si. Un bon premier pas est court, précis et réalisable maintenant. S’il reste difficile, réduisez-le : ouvrir le document, trouver la bonne page ou écrire un titre."),
                H("Écarter un obstacle"),
                P("Repérez ce qui gêne le plus : un fichier introuvable, trop de matériel, un résultat attendu flou ou les distractions du téléphone. Écartez un seul obstacle. Organiser tout le processus peut devenir une nouvelle façon de remettre la tâche à plus tard."),
                H("Un essai, pas une promesse"),
                P("Réglez un minuteur sur cinq ou dix minutes et autorisez-vous à vous arrêter ensuite. Regardez ce qui a changé : la tâche est-elle plus claire ? Avez-vous l’énergie de continuer ? Faut-il une information ou de l’aide ? S’arrêter comme prévu, c’est aussi terminer une étape."),
                H("Un plan pour les prochaines minutes"),
                List(
                    "Écrivez le résultat souhaité en une phrase.",
                    "Choisissez une action que vous pouvez voir ou vérifier.",
                    "Préparez un élément utile et écartez un obstacle.",
                    "Après ce court démarrage, choisissez de continuer, simplifier ou demander de l’aide."),
                P("Si même les petites tâches restent longtemps insurmontables et perturbent votre quotidien, parlez de votre charge et des soutiens possibles à une personne de confiance ou à un professionnel."),
            ]),
        new(
            ArticleIds.CheckingLoop,
            "Vérifier puis s’arrêter",
            "Définir un but sans négliger les contrôles de sécurité nécessaires",
            "TipsAndUpdates",
            2,
            [
                P("Les vérifications répétées apaisent parfois brièvement, puis le doute revient : « Et si j’avais oublié quelque chose ? » Certains contrôles sont obligatoires. Il ne s’agit pas de tout laisser sans vérification, mais de distinguer une vérification utile d’une répétition sans raison nouvelle."),
                H("Avant de vérifier"),
                P("Avant, précisez ce qu’il faut confirmer, la source fiable et le signe que c’est terminé. Pour un billet, comparez la date et la destination au document officiel. Si une règle exige un second contrôle, respectez-la : une limite personnelle ne remplace pas une procédure obligatoire."),
                H("Quand le doute revient"),
                P("Si le doute revient, demandez-vous si les circonstances, les informations ou les exigences ont changé. Si oui, vérifiez le point concerné. Sinon, notez que vous avez vérifié selon la règle choisie et passez à autre chose. Inutile d’attendre un calme total."),
                H("Une vérification avec des limites"),
                List(
                    "Nommez son objectif.",
                    "Choisissez une source fiable et le nombre de contrôles requis.",
                    "Notez que c’est terminé.",
                    "Recommencez si de nouveaux faits ou impératifs de sécurité apparaissent."),
                P("Si les vérifications prennent beaucoup de temps ou limitent votre vie, demandez un soutien professionnel. Ne supprimez pas les contrôles nécessaires à la sécurité.")
            ]),
        new(
            ArticleIds.PublicPlaceAnxiety,
            "Anxiété dans un lieu fréquenté",
            "Réduire la charge et garder la possibilité de choisir",
            "TipsAndUpdates",
            2,
            [
                P("Le bruit, la proximité, l’attente ou l’impression de ne pas pouvoir partir peuvent augmenter l’anxiété. Vous n’avez pas à vous forcer à tenir ni à voir un départ comme un échec. Vérifiez d’abord la situation et choisissez une suite adaptée."),
                H("Trouver un repère accessible"),
                P("Si possible, rapprochez-vous d’un endroit plus calme et repérez la sortie. Vous pouvez nommer des objets ou sentir vos pieds au sol. Ce sont des options, pas un rituel ; évitez l’attention au corps si elle est inconfortable."),
                H("Choisir la suite"),
                P("Demandez-vous si changer de place ou de rythme vous aiderait. Une pause, un report ou un appel serait-il préférable ? Choisissez un pas sans exiger un calme immédiat. En cas de danger, demandez de l’aide pour rejoindre un lieu sûr."),
                H("Un plan bref"),
                List(
                    "Trouvez un endroit sûr et repérez la sortie.",
                    "Réduisez un stimulus si possible.",
                    "Choisissez de rester, faire une pause, partir ou demander du soutien.",
                    "Arrêtez un exercice qui augmente l’inconfort."),
                P("Si ces situations gênent souvent votre quotidien, parlez-en à un professionnel. En cas de danger immédiat, contactez les secours.")
            ]),
        new(
            ArticleIds.MorningWorry,
            "Un matin sans liste d’inquiétudes",
            "Choisir la priorité du jour et réserver un moment au reste",
            "TipsAndUpdates",
            2,
            [
                P("Le matin, toutes les tâches en attente peuvent sembler urgentes. Revoir toute la semaine augmente la charge et masque ce qui demande vraiment votre attention aujourd’hui. Un plan bref aide à choisir la suite plutôt qu’à tout contrôler."),
                H("Distinguer l’urgent de l’important"),
                P("Notez vos préoccupations et marquez une tâche avec une échéance ou conséquence réelle aujourd’hui. Choisissez la première action et son heure. Si elle dépend d’autrui, notez qui contacter ou quelle aide demander. Reportez les autres questions à un moment précis."),
                H("Vérifier les besoins de base"),
                P("Avant d’exiger une grande productivité, demandez-vous ce qui faciliterait le début : eau, nourriture, traitement prescrit, calme ou vêtements confortables. Réduisez le plan si votre état change."),
                H("Un plan pour les prochaines minutes"),
                List(
                    "Quelle chose nécessite vraiment une action aujourd’hui ?",
                    "Quel est le plus petit prochain pas ?",
                    "Quand reviendrai-je aux autres questions ?",
                    "De quoi mon corps a-t-il besoin maintenant ?"),
                P("Si l’inquiétude matinale perturbe souvent vos activités ou votre sommeil, vous pouvez en parler à un professionnel.")
            ]),
        new(
            ArticleIds.SensoryOverload,
            "Quand les sons et les tâches deviennent trop nombreux",
            "Réduire les stimuli et retrouver des choix",
            "TipsAndUpdates",
            2,
            [
                P("Les conversations, notifications, écrans lumineux et demandes simultanés peuvent surcharger l’attention. Il devient plus difficile de suivre une conversation ou de poursuivre une activité. C’est un signe de charge, pas un manque d’effort. Changez une chose accessible."),
                H("Réduire une source de charge"),
                P("Allez dans un endroit plus calme, coupez une notification non essentielle, baissez la luminosité ou demandez à parler à tour de rôle. Si vous ne pouvez pas partir, réduisez les tâches et demandez que l’on répète une consigne. Choisissez un ajustement sûr."),
                H("Garder la possibilité de s’arrêter"),
                P("Si la respiration, les yeux fermés ou l’attention au corps accentuent l’inconfort, arrêtez et choisissez un repère extérieur ou une pause. Vous pouvez dire : « J’ai besoin de moins de bruit, je répondrai plus tard. »"),
                H("Un plan pour réduire les stimuli"),
                List(
                    "Repérez le stimulus le plus difficile.",
                    "Modifiez un facteur : son, lumière, rythme ou distance.",
                    "Reportez une décision non essentielle.",
                    "Demandez de l’aide si vous ne pouvez pas faire une pause seul."),
                P("Si la surcharge apparaît brutalement avec des symptômes importants ou si vous ne pouvez rester en sécurité, demandez de l’aide.")
            ]),
        new(
            ArticleIds.EveningTension,
            "Terminer la journée en douceur",
            "Noter ce qui reste au lieu de continuer à planifier la nuit",
            "TipsAndUpdates",
            2,
            [
                P("Le soir, les tâches inachevées peuvent donner l’impression que la journée n’a pas été suffisante. Essayer de tout résoudre mentalement avant de dormir prolonge parfois le travail. Une note courte et une transition claire peuvent aider à poser les tâches pour aujourd’hui."),
                H("Fermer les tâches en suspens"),
                P("Notez ce qui est fait, ce qui demande vraiment une prochaine action et ce qui peut attendre. Pour une tâche importante, écrivez le premier geste concret pour demain et une heure approximative. S’il faut parler d’un délai ou demander de l’aide, notez à qui et quand. Inutile de planifier toute la semaine."),
                H("Choisir un signal de fin"),
                P("Enregistrez la note et fermez la liste. Choisissez ensuite un geste simple qui marque la fin des tâches : baisser la lumière, ranger le matériel, vous laver ou vous asseoir au calme. Cela ne garantit pas le sommeil, mais peut éviter de continuer à travailler dans le lit."),
                H("Trois notes du soir"),
                List(
                    "Qu’ai-je déjà fait aujourd’hui ?",
                    "Quelle tâche demande une prochaine étape ?",
                    "Qu’est-ce qui peut attendre le moment prévu ?"),
                P("Si les inquiétudes perturbent régulièrement votre sommeil, parlez-en à un professionnel de santé.")
            ]),
        new(
            ArticleIds.AnxietyComedown,
            "Après une montée d’anxiété",
            "Retrouver sécurité et appui avant de décider s’il faut analyser",
            "TipsAndUpdates",
            2,
            [
                P("Après une forte anxiété, vous pouvez vouloir comprendre la cause immédiatement et éviter que cela recommence. Pourtant, analyser en étant épuisé peut ajouter de la charge. Vérifiez d’abord votre sécurité et laissez-vous revenir à votre rythme habituel."),
                H("Revenir à des choses simples"),
                P("Si vous êtes en sécurité, choisissez une activité familière et peu exigeante : vous asseoir, boire de l’eau, manger, vous réchauffer ou aller dans un endroit plus calme. Vous n’avez pas besoin de faire un exercice respiratoire ni de fermer les yeux. Arrêtez ce qui augmente l’inconfort."),
                H("Réfléchir seulement à ce qui peut aider"),
                P("Plus tard, lorsque vous vous concentrez mieux, notez ce qui se passait, ce qui a aidé un peu et s’il reste une question pratique pour la prochaine fois. Inutile de trouver une cause unique ou de vous accuser. S’il faut agir, écrivez la prochaine étape ou la personne à qui en parler."),
                H("Reprendre doucement"),
                List(
                    "Vérifiez que vous êtes dans un lieu sûr.",
                    "Choisissez un besoin simple ou une activité familière.",
                    "Reportez l’analyse si elle ajoute de la tension.",
                    "Reprenez progressivement les tâches habituelles."),
                P("Si ces épisodes se répètent, gênent beaucoup votre vie ou s’accompagnent de symptômes importants, demandez un soutien professionnel.")
            ]),
        new(
            ArticleIds.SafePractice,
            "La pratique n’est pas un examen",
            "Vous pouvez adapter l’exercice ou l’arrêter tout en gardant le contrôle",
            "TipsAndUpdates",
            2,
            [
                P("Une pratique n’est utile que si elle vous convient à ce moment-là. Tout faire à tout prix n’est pas le but. Vous pouvez changer le rythme, sauter une étape ou arrêter."),
                H("Garder des choix avant de commencer"),
                P("Décidez comment vous arrêter et où porter votre attention. Vous pouvez garder les yeux ouverts, raccourcir la durée, changer de position ou choisir un repère extérieur. Les exercices de respiration et d’attention au corps ne conviennent pas à tout le monde ; évitez ce qui augmente l’inconfort."),
                H("Si l’inconfort apparaît"),
                P("Arrêtez, reprenez votre respiration naturelle et regardez autour de vous. Si c’est sûr, changez de position ou passez à une activité simple et familière. Vous n’avez pas à tenir jusqu’au bout. Si l’inconfort persiste ou augmente, demandez du soutien."),
                H("Avant de pratiquer"),
                List(
                    "Cet exercice me convient-il maintenant ?",
                    "Comment saurai-je qu’il faut arrêter ?",
                    "Que choisirai-je à la place s’il me gêne ?"),
                P("Une pratique ne remplace pas un accompagnement professionnel ni une aide urgente en cas de danger immédiat.")
            ]),

        new(
            ArticleIds.ThoughtLabel,
            "Donnez un nom à la pensée",
            "Remarquez-la sans la contredire",
            "TipsAndUpdates",
            2,
            [
                P("Une pensée peut sembler très convaincante, surtout quand vous êtes fatigué ou inquiet. Essayez de la précéder par : « Je remarque la pensée que… ». Cela ne prouve pas qu’elle est fausse ; cela distingue un événement mental d’un fait établi et peut laisser un peu d’espace pour choisir la suite."),
                H("Vérifiez ce qui est connu"),
                P("Notez brièvement ce qui s’est passé et ce que vous en avez déduit. Demandez-vous : « Qu’ai-je directement observé ? Qu’est-ce qui reste une interprétation ? ». Inutile d’analyser chaque pensée ou de vous convaincre du contraire. Pour une décision importante, cherchez seulement les informations susceptibles de changer la prochaine étape."),
                H("Revenez à une action choisie"),
                P("Choisissez une petite action liée à votre tâche ou à vos valeurs : ouvrir un document, poser une question ou faire une pause. La pensée peut rester présente ; vous n’avez pas à l’éliminer d’abord. Si l’exercice augmente votre malaise, arrêtez et choisissez un soutien plus adapté.")
            ]),
        new(
            ArticleIds.MindReading,
            "Ne devinez pas les pensées des autres",
            "Séparez l’observation de l’interprétation",
            "TipsAndUpdates",
            2,
            [
                P("Quand quelqu’un se tait ou répond brièvement, l’esprit peut inventer une explication : « Cette personne est fâchée » ou « J’ai tout gâché ». Ce sont des possibilités, mais pas les seules. Séparez ce que vous avez réellement vu ou entendu du sens que vous lui avez donné."),
                H("Demandez une précision si c’est utile"),
                P("Si la relation et la question comptent, posez calmement une question concrète : « Ai-je bien compris que… ? » ou « Quand serait-il possible d’en parler ? ». N’exigez pas une réponse immédiate si la personne est occupée. Si la clarification n’est pas utile maintenant, reconnaissez l’incertitude et attendez d’autres éléments."),
                H("Ne transformez pas une supposition en verdict"),
                P("Gardez plusieurs explications en tête : la personne est peut-être occupée, fatiguée ou n’a pas vu le message. Aucune n’est forcément vraie. Le but n’est pas de remplacer une certitude par une autre, mais de ne pas prendre une supposition pour une preuve. Décidez ensuite si une action est nécessaire ou si vous pouvez reprendre vos activités.")
            ]),
        new(
            ArticleIds.WorstVsLikely,
            "Le pire n’est pas le plus probable",
            "Préparez-vous sans le vivre à l’avance",
            "TipsAndUpdates",
            2,
            [
                P("L’inquiétude peut présenter l’issue la plus difficile comme si elle était imminente. Au lieu de vous contredire, envisagez trois possibilités : une issue difficile, une favorable et la plus plausible au vu des faits connus. Ce n’est ni une prédiction ni la promesse que tout ira bien ; cela redonne une place à plusieurs possibilités."),
                H("Distinguez préparation et rumination"),
                P("Pour l’issue la plus plausible, choisissez une étape utile. Si la pire aurait de graves conséquences, préparez un plan bref et raisonnable : que feriez-vous et qui contacteriez-vous ? Inutile de planifier chaque scénario imaginé en détail. Demandez-vous quelle nouvelle information pourrait changer votre appréciation et cherchez seulement celle-là."),
                H("Laissez l’incertitude ouverte"),
                P("Si cela aide, notez un élément pour et un élément contre chaque possibilité. En l’absence d’information, écrivez « inconnu ». Puis revenez à une action possible maintenant. Face à un danger réel, réagissez aux faits et demandez une aide concrète ; cet exercice ne la remplace pas.")
            ]),
        new(
            ArticleIds.EvidenceAndUnknown,
            "Ce que je sais et ce qui reste incertain",
            "Ne remplissez pas un vide par une inquiétude",
            "TipsAndUpdates",
            2,
            [
                P("Quand une réponse manque, une explication inquiète peut sembler certaine. Séparer les faits des inconnues ne supprime pas l’incertitude, mais évite de construire une décision sur une supposition. Notez les faits à part des questions ouvertes."),
                H("Demandez-vous ce que vous pouvez vérifier"),
                P("Pour chaque question, choisissez où trouver une information fiable, qui interroger ou quand y revenir. Cherchez uniquement les informations susceptibles de changer une action. Vérifier plusieurs fois la même source n’apporte généralement pas de nouvel élément."),
                H("Laissez les questions ouvertes en suspens"),
                P("S’il n’y a pas de réponse pour l’instant, notez « inconnu pour le moment ». Choisissez quand vérifier à nouveau ou mettez la question de côté. Revenez ensuite à une activité accessible. L’incertitude est inconfortable, mais elle n’a pas toujours besoin d’être résolue immédiatement.")
            ]),
        new(
            ArticleIds.NegativityFilter,
            "Remarquez autre chose que ce qui a échoué",
            "Ajoutez un fait au tableau",
            "TipsAndUpdates",
            2,
            [
                P("Après un moment difficile, l’attention peut se fixer sur les erreurs et oublier les instants neutres ou utiles. Cela ne veut pas dire qu’il faut embellir la situation. Il s’agit seulement de vérifier si une partie de l’histoire a pris toute la place."),
                H("Rétablissez le contexte"),
                P("Nommez ce qui s’est mal passé, puis ajoutez un fait pertinent : ce que vous avez fait, ce qui s’est déroulé normalement, qui vous a aidé ou ce que vous avez appris. Un détail neutre compte aussi. Inutile de chercher des compliments si cela sonne faux aujourd’hui."),
                H("Utilisez ce tableau pour la suite"),
                P("Demandez-vous si le fait ajouté change la prochaine action. Si oui, choisissez-la. Sinon, reconnaissez la difficulté sans en faire un jugement général sur vous-même. Un moment positif n’annule pas une journée difficile ; il peut rendre votre évaluation plus juste.")
            ]),
        new(
            ArticleIds.ConversationReplay,
            "Arrêtez de rejouer la conversation sans fin",
            "Vérifiez s’il y a une information nouvelle ou une action",
            "TipsAndUpdates",
            2,
            [
                P("Après un échange, on peut repasser chaque phrase et deviner ce que l’autre a pensé. Un bref retour peut aider s’il mène à une clarification ou à une réparation. Sans nouvel élément, la répétition ne fait souvent que fatiguer."),
                H("Séparez la conclusion de la prochaine étape"),
                P("Notez un fait précis, un engagement ou une question qui demande vraiment une réponse. Si vous souhaitez clarifier ou corriger quelque chose, choisissez un message court et un moment adapté. Il n’est pas nécessaire d’envoyer plusieurs messages pour obtenir une certitude absolue."),
                H("S’il n’y a rien de nouveau, faites une pause"),
                P("Dites-vous : « Je repasse la conversation, mais je n’ai pas de nouvel élément ». Passez à une activité qui ramène votre attention au présent. Si le sujet reste important, fixez un moment pour décider calmement s’il faut en parler. Vous n’avez pas à décider maintenant.")
            ]),
        new(
            ArticleIds.DecisionFatigue,
            "Simplifiez un petit choix",
            "Décidez à l’avance de ce qui suffit",
            "TipsAndUpdates",
            2,
            [
                P("Les petites décisions s’accumulent, surtout lorsqu’il faut tout comparer à nouveau. Pour les choix répétitifs, une règle définie à l’avance peut aider : durée, budget ou critère de qualité. Cela ne signifie pas qu’il faut précipiter les décisions importantes ; réservez-leur un moment distinct."),
                H("Réduisez le nombre d’options"),
                P("Pour un choix facile à réviser, gardez deux options acceptables et comparez-les selon un critère. Par exemple : laquelle sera la plus simple à suivre cette semaine ? Limiter les options protège votre attention ; cela ne garantit pas une réponse parfaite."),
                H("Revenez sur le choix seulement si la situation change"),
                P("Notez votre décision et ce qui vous ferait la réexaminer, par exemple un changement de circonstances ou un fait important. Si rien n’a changé, essayez de vous y tenir. Si le choix concerne la sécurité, la santé ou un engagement majeur, une règle rapide ne remplace pas une vérification sérieuse.")
            ]),
        new(
            ArticleIds.GoodEnough,
            "Suffisamment bien, c’est déjà un résultat",
            "Limitez les retouches inutiles",
            "TipsAndUpdates",
            2,
            [
                P("Quand une tâche compte, vouloir la vérifier encore est compréhensible. Sans limite claire, les retouches peuvent continuer même lorsque le résultat est déjà utilisable. Avant de commencer, définissez ce qui doit être respecté et votre point d’arrêt."),
                H("Définissez une fin observable"),
                P("Choisissez deux ou trois critères vérifiables et la manière de les contrôler. Un e-mail doit, par exemple, exprimer la demande, contenir la bonne date et être relu une fois pour les fautes évidentes. Ensuite, enregistrez-le ou envoyez-le. Les critères doivent correspondre à la tâche, sans exiger la perfection partout."),
                H("Ne revenez au résultat que pour une raison précise"),
                P("L’envie de vérifier encore ne prouve pas qu’il y a une erreur. Rouvrez le travail si vous repérez un problème concret, recevez une information nouvelle ou devez effectuer une modification nécessaire. Vous distinguerez ainsi une correction utile d’une retouche sans fin à la recherche d’une certitude impossible.")
            ]),
        new(
            ArticleIds.ControlInfluence,
            "Ce que je peux influencer et ce qui m’échappe",
            "Concentrez-vous sur une action accessible",
            "TipsAndUpdates",
            2,
            [
                P("Quand une situation dépend aussi d’autres personnes ou des circonstances, essayer de tout contrôler peut épuiser. Distinguer votre marge d’action du reste ne rend pas la situation juste et n’efface pas les contraintes réelles. Cela aide à placer votre énergie au bon endroit."),
                H("Trouvez votre marge de manœuvre"),
                P("Demandez-vous : que puis-je dire, préparer, demander ou décider ? Choisissez une étape concrète. Pour ce qui vous échappe, pensez à une limite, à un soutien ou à un moment pour vérifier à nouveau. Parfois, l’action possible consiste à refuser, demander de l’aide ou signaler un problème."),
                H("Ne prenez pas la responsabilité d’autrui"),
                P("Vous pouvez formuler une demande clairement, sans garantir la réponse. Repérez où votre rôle s’arrête et ne faites pas de la décision d’une autre personne une mesure de votre valeur. En cas de danger réel ou d’atteinte à vos droits, cherchez un soutien concret plutôt que de compter uniquement sur un changement de perspective.")
            ]),
        new(
            ArticleIds.SelfTalkReset,
            "Changez le ton de votre dialogue intérieur",
            "Soyez respectueux et précis avec vous-même",
            "TipsAndUpdates",
            2,
            [
                P("L’autocritique prend parfois la forme d’une motivation : « si je me parle durement, je vais me reprendre ». Pourtant, les insultes n’indiquent pas quoi faire ensuite. Se parler avec respect ne signifie pas excuser une action ni ignorer ses conséquences. Cela aide à décrire la situation avec précision et à garder une marge d’action."),
                H("Remplacer une étiquette par un fait observable"),
                P("Essayez de remplacer « je suis irresponsable » par « j’ai dépassé le délai et je n’ai pas encore prévenu l’équipe ». La première phrase juge toute votre personnalité ; la seconde nomme un événement et une action possible. Plus la description est précise, plus le prochain pas devient clair."),
                H("Une phrase pour un moment difficile"),
                P("Utilisez trois éléments : ce qui s’est passé, ce que cela a affecté et ce que vous allez faire maintenant. Par exemple : « J’ai répondu sèchement, la conversation s’est tendue ; je vais y revenir pour expliquer ce que je voulais dire. » Si vous avez fait du mal, le reconnaître et tenter de réparer compte davantage qu’une formulation positive."),
                H("Vérifier qu’il y a respect et honnêteté"),
                List(
                    "Nommez le fait sans « toujours » ni « jamais ».",
                    "Notez une émotion ou une conséquence sans en faire la preuve de votre échec.",
                    "Choisissez une action possible : réparer, clarifier, présenter des excuses ou demander du soutien.",
                    "Parlez-vous comme à une personne qui vous est chère, tout en restant honnête."),
                P("Vous n’avez pas besoin de croire tout de suite une nouvelle phrase. Il suffit qu’elle soit plus exacte et utile. Si l’autocritique devient constante ou douloureuse, un soutien professionnel peut aider."),
            ]),
        new(
            ArticleIds.WorryAboutWorry,
            "S’inquiéter de son inquiétude",
            "Ne vous obligez pas à vous calmer immédiatement",
            "TipsAndUpdates",
            2,
            [
                P("Quand vous remarquez de l’anxiété, une seconde pensée peut apparaître : « Je ne devrais pas réagir ainsi ». Elle peut ajouter de la pression. La première réaction est déjà là ; inutile de vous la reprocher. Le but n’est pas de forcer le calme, mais de choisir une action accessible malgré l’inquiétude."),
                H("Nommez les deux réactions"),
                P("Essayez de remarquer : « Je suis anxieux et je m’inquiète maintenant de l’être ». Inutile de débattre avec cette pensée ou de trouver les mots parfaits. Vérifiez ensuite s’il existe une action pratique à faire : vous préparer, demander du soutien ou clarifier une question précise."),
                H("Mesurez le progrès à l’action choisie"),
                P("Demandez-vous ce que vous vouliez faire avant l’apparition de l’anxiété et choisissez-en une version plus petite. Ensuite, remarquez l’action ou la pause, pas votre degré de calme. Si l’anxiété limite souvent votre quotidien, vous pouvez en parler à un professionnel.")
            ]),
        new(
            ArticleIds.CompareHighlightReel,
            "Ne comparez pas votre vie à une vitrine",
            "Un fil montre des moments choisis, pas une vie entière",
            "TipsAndUpdates",
            2,
            [
                P("Les publications montrent souvent un instant, pas les soucis, les doutes et les habitudes ordinaires d’une personne. Comparer votre quotidien aux moments forts des autres peut donner l’impression d’être en retard. Ce ressenti existe, mais il ne définit pas votre valeur et ne raconte pas toute l’histoire."),
                H("Nommez ce qui vous manque"),
                P("Fermez la publication un instant et demandez-vous ce qui vous manque : du repos, du lien, de l’argent, de la reconnaissance ou du temps pour quelque chose d’important. Vous n’avez pas à minimiser ce désir. Vous repérez un besoin sans devoir changer toute votre vie immédiatement."),
                H("Faites un petit pas vers votre propre vie"),
                P("Si possible, faites quelque chose de concret : écrire à un proche, prévoir un moment de repos ou reprendre votre projet. Si aucun pas n’est possible maintenant, reconnaissez-le simplement. La réussite de quelqu’un ne vous retire pas vos possibilités ; une pause du fil peut vous aider à retrouver votre rythme.")
            ]),
        new(
            ArticleIds.IntrusiveThoughts,
            "Une pensée indésirable n’est pas une intention",
            "Tenez compte des actes, du contexte et de la sécurité",
            "TipsAndUpdates",
            2,
            [
                P("Certaines pensées peuvent être perturbantes, effrayantes ou contraires à vos valeurs. Leur présence ne prouve pas à elle seule que vous voulez agir. Vous n’avez pas à tester sans fin si vous êtes une « bonne personne » ni à rechercher une certitude complète."),
                H("Évitez d’alimenter les vérifications"),
                P("Si vous êtes en sécurité, nommez brièvement la pensée comme indésirable sans la réanalyser. Revenez à une activité ordinaire ou à un repère extérieur. Si elle correspond à une intention réelle, à un plan ou à un danger immédiat pour vous ou quelqu’un d’autre, il s’agit d’une question de sécurité : éloignez-vous des moyens de faire du mal et contactez rapidement un proche de confiance, un professionnel ou les services d’urgence."),
                H("Cherchez du soutien si cela perturbe votre quotidien"),
                P("Si ces pensées vous effraient souvent, prennent beaucoup de temps ou gênent votre vie quotidienne, parlez-en à un professionnel de santé mentale. Vous pouvez décrire leur fréquence, leurs effets et ce qui vous aide sans essayer de vous diagnostiquer.")
            ]),
        new(
            ArticleIds.OneThingAtATime,
            "Une tâche à la fois",
            "Rendez votre concentration concrète et limitée",
            "TipsAndUpdates",
            2,
            [
                P("Passer des messages aux onglets puis aux tâches peut donner une impression d’activité, tout en rendant les achèvements moins visibles. Il n’est pas nécessaire de rester concentré toute la journée. Essayez un bloc court avec un résultat observable : vérifier trois lignes, répondre à un courriel ou lire quelques pages."),
                H("Facilitez la reprise"),
                P("Avant de commencer, désactivez seulement les alertes et fermez seulement les fenêtres qui vous détournent souvent de votre tâche, si c’est possible. Gardez une note « plus tard » : écrivez-y les nouvelles tâches plutôt que de changer aussitôt d’activité. Si les interruptions sont inévitables, notez brièvement où vous en étiez et la prochaine action."),
                H("Terminez le bloc consciemment"),
                P("À la fin du minuteur ou une fois le résultat atteint, faites une pause et choisissez de continuer, de changer de tâche ou de vous reposer. Si la concentration n’est pas venue, réduisez l’étape ou vérifiez si la fatigue, la faim ou le cadre vous gênent. Il ne s’agit pas d’une course à la productivité, mais de réduire le bruit mental et de choisir plus clairement la suite.")
            ]),

        new(
            ArticleIds.MoodMovement,
            "Un peu de mouvement quand l’énergie manque",
            "Essayez un geste doux sans vous obliger à vous dynamiser",
            "TipsAndUpdates",
            2,
            [
                P("Quand l’énergie manque, même un mouvement ordinaire peut sembler être une tâche de plus. Vous n’avez pas à vous convaincre qu’une courte promenade améliorera votre humeur. Vous pouvez simplement voir ce qui vous paraît possible et comment vous le vivez. Le but n’est pas de vous entraîner, mais de prendre soin des besoins de votre corps."),
                H("Choisissez une option accessible"),
                P("Vous pouvez vous étirer assis, aller jusqu’à une fenêtre, changer de position ou sortir quelques minutes. Choisissez vous-même la durée et gardez la possibilité de vous arrêter. En cas de problème de santé, suivez les conseils médicaux ; le mouvement ne doit pas provoquer de douleur ni vous obliger à forcer."),
                H("Observez sans vous noter"),
                P("Demandez-vous ensuite si quelque chose est plus confortable, inchangé ou plus fatigant. Toute réponse est utile et ne signifie pas que vous avez mal fait. Si le repos vous convient mieux, choisissez-le. Si le manque d’énergie persiste ou survient brutalement, vous pouvez en parler à un professionnel de santé.")
            ]),
        new(
            ArticleIds.PleasureMastery,
            "Plaisir et sentiment d’accomplissement",
            "Observez comment différentes activités peuvent vous soutenir",
            "TipsAndUpdates",
            2,
            [
                P("Certaines activités sont agréables sur le moment ; d’autres donnent une impression d’achèvement ou de lien avec ce qui compte. Ce sont des expériences différentes, et aucune n’a à suivre chaque tâche. Quand vous êtes fatigué, observez plutôt l’effet réel d’une activité que d’attendre une joie immédiate."),
                H("Prévoyez sans vous surcharger"),
                P("Choisissez une petite option adaptée : pour le plaisir, écouter une chanson ou boire un thé ; pour achever, ranger une surface ou répondre à un courriel ; pour le lien, écrire brièvement à une personne de confiance. Un seul choix suffit. Tenez compte du temps, de l’énergie, de l’accès et de votre envie réelle."),
                H("Faites le point avec douceur"),
                P("Notez séparément si l’activité était agréable et si vous avez ressenti « j’ai terminé quelque chose ». Si rien n’a changé, ce n’est pas un échec et vous n’avez pas à vous forcer à recommencer. Il vous faut peut-être du repos, un autre format ou une étape plus petite. Ces observations servent à rendre vos plans réalistes, pas à mesurer votre valeur.")
            ]),
        new(
            ArticleIds.EnergyBudget,
            "Répartissez aussi votre énergie",
            "Prévoyez du temps de récupération avec les obligations",
            "TipsAndUpdates",
            2,
            [
                P("Deux tâches de même durée peuvent demander des efforts très différents. Pour planifier, comptez aussi les déplacements, la préparation, la concentration et la charge émotionnelle. Un agenda sans transitions ni pauses peut être trop dense même s’il semble y avoir du temps libre."),
                H("Gardez une marge"),
                P("Choisissez une tâche importante et, si vous en avez la capacité, une petite autre. Intercalez une pause simple ou une activité légère entre les tâches exigeantes. Vous n’avez pas à remplir chaque créneau. Si votre programme dépend d’autres personnes, gardez une autre possibilité ou demandez ce qui est prioritaire."),
                H("Ajustez selon votre expérience"),
                P("En fin de journée, repérez les tâches qui ont demandé plus d’énergie que prévu et vérifiez si vous avez pu récupérer. Utilisez ces observations pour organiser la suite, sans vous critiquer. Lors d’une journée imprévisible, réduisez la liste à l’essentiel et reportez le reste.")
            ]),
        new(
            ArticleIds.RestBreak,
            "Faire une pause sans culpabiliser",
            "Le repos aide à choisir la suite",
            "TipsAndUpdates",
            2,
            [
                P("Quand les tâches s’accumulent, le repos peut ressembler à une récompense qu’il faudrait d’abord mériter. Pourtant, une pause peut faire partie d’une gestion ordinaire de l’effort et ne signifie pas que vous êtes faible. Elle n’a pas besoin de vous rendre plus productif : elle peut simplement vous aider à remarquer votre état et à choisir la suite."),
                H("Adapter la pause à la fatigue"),
                P("Si vos yeux et votre attention sont fatigués, quelques minutes de calme sans écran peuvent convenir. Si votre corps est raide, changez de position ou étirez-vous doucement si cela vous convient. Si le bruit vous surcharge, trouvez un endroit plus tranquille. De l’eau, un repas, de l’air ou une conversation avec un proche peuvent mieux vous aider. Il n’y a pas de méthode universelle : choisissez quelque chose de sûr et accessible."),
                H("Ne pas transformer la pause en tâche"),
                P("Choisissez une durée approximative et une activité simple : rester cinq minutes près d’une fenêtre ou marcher un peu. Inutile d’évaluer si vous vous reposez correctement. Ensuite, vous pouvez avancer d’un pas, reporter une tâche, demander de l’aide ou vous arrêter pour aujourd’hui."),
                H("Quand il n’y a jamais de place pour souffler"),
                P("Un épuisement qui revient ne se règle pas toujours avec une organisation plus stricte. Voyez si certaines tâches peuvent être réduites, déplacées ou partagées, si un délai peut être discuté et quel soutien demander. Tout ne dépend pas uniquement de la discipline personnelle."),
                H("Un plan de pause doux"),
                List(
                    "Repérez ce qui est fatigué : attention, corps ou émotions.",
                    "Choisissez une courte pause adaptée au moment.",
                    "Mettez de côté une exigence envers vous-même pendant ce temps.",
                    "Après, décidez de ce qui doit vraiment continuer."),
                P("Si la fatigue dure, gêne vos activités quotidiennes ou vous inquiète pour votre santé, adressez-vous à un professionnel de santé. Cet article ne remplace pas un accompagnement individuel."),
            ]),
        new(
            ArticleIds.StartFriction,
            "Retirez un obstacle avant de commencer",
            "Préparez la prochaine étape, pas tout le processus",
            "TipsAndUpdates",
            2,
            [
                P("Quand commencer est difficile, « mieux s’organiser » n’explique pas toujours ce qui bloque. La tâche est peut-être floue, le fichier introuvable, le matériel absent ou la première étape trop grande. Choisissez un obstacle précis à vérifier plutôt que de réorganiser toute votre journée."),
                H("Facilitez le premier pas"),
                P("Si l’objectif n’est pas clair, notez une question ou demandez une précision. Si la préparation manque, ouvrez le document ou placez le matériel en vue. Si le téléphone vous détourne, éloignez-le pendant un court moment si c’est possible. Évitez de transformer la préparation en une nouvelle grande tâche."),
                H("Vérifiez si cela aide"),
                P("Essayez de commencer après avoir modifié une seule condition et observez si c’est plus facile. Sinon, revenez sur ce qui n’a pas aidé et examinez une autre cause. L’obstacle peut dépendre d’autrui : il vous faut peut-être un accès, une décision ou de l’aide. La prochaine étape est alors une demande claire, pas de tout surmonter seul.")
            ]),
        new(
            ArticleIds.TransitionRitual,
            "Faites une pause entre deux tâches",
            "Notez ce qui reste et nommez la prochaine étape",
            "TipsAndUpdates",
            2,
            [
                P("Après une interruption, il peut être difficile de se rappeler où vous en étiez ; le travail inachevé continue aussi de retenir l’attention. Une transition courte peut garder cette information et rendre le prochain départ plus calme. Ce n’est ni un rituel obligatoire ni une façon de travailler sans repos, seulement un repère facultatif."),
                H("Terminez la tâche précédente"),
                P("Écrivez en une ligne ce qui est fait et ce qui reste. Enregistrez le fichier ou rangez le matériel à un endroit facile à retrouver. Si vous attendez une réponse, notez de qui et quand vous vérifierez. Il n’est pas nécessaire de ranger tout l’espace."),
                H("Choisissez la suite"),
                P("Nommez la première action visible de la prochaine tâche, puis mettez la précédente de côté. La transition peut durer moins d’une minute : enregistrer, noter, nommer. Si la pause accroît votre tension ou si vous avez besoin de repos, ne vous forcez pas. Après quelques essais, gardez seulement ce qui vous aide vraiment.")
            ]),
        new(
            ArticleIds.TaskActivation,
            "Quand commencer est difficile",
            "Reliez une action minuscule à un repère habituel",
            "TipsAndUpdates",
            2,
            [
                P("Attendre la motivation peut repousser une tâche, mais vous n’avez pas à commencer par tout son contenu. Choisissez une action qui ouvre simplement la voie : ouvrir le document, lire la consigne ou écrire un titre. C’est un début, pas une promesse de tout terminer."),
                H("Utilisez un repère clair"),
                P("Reliez l’action à un moment ordinaire : « Après le petit-déjeuner, j’ouvrirai le fichier et regarderai la première ligne. » Précisez où et quand, puis retirez un obstacle à l’avance. Si vous manquez ce moment, choisissez-en un autre ; un départ manqué n’annule pas le plan."),
                H("Décidez après avoir commencé"),
                P("Après cette petite étape, vérifiez votre énergie et choisissez de continuer un peu, de faire une pause ou de vous arrêter. Le fait d’avoir commencé compte, pas la quantité terminée. La tâche est parfois floue, trop grande ou nécessite du soutien. Si cette difficulté gêne souvent votre quotidien, vous pouvez en parler à un professionnel adapté.")
            ]),
        new(
            ArticleIds.GentleRoutine,
            "Une routine souple, pas parfaite",
            "Gardez un repère stable, pas un horaire rigide",
            "TipsAndUpdates",
            2,
            [
                P("Une routine peut alléger la journée en évitant de tout décider à nouveau. Mais un programme très détaillé peut devenir une source de culpabilité dès qu’un imprévu survient. Choisissez un repère répétable — par exemple planifier après le petit-déjeuner — et laissez le reste de la journée flexible."),
                H("Rendez l’habitude adaptable"),
                P("Reliez l’action à un événement, pas seulement à une heure : ouvrir les volets au réveil ou consulter un message après le déjeuner. Prévoyez une version simple pour les jours difficiles : respirer une fois près de la fenêtre au lieu de marcher, ou noter une priorité plutôt qu’une liste complète. Le minimum doit être réellement faisable."),
                H("Reprenez sans vous punir"),
                P("Si vous manquez une journée, reprenez à la prochaine occasion adaptée, sans devoir rattraper. Si l’habitude ne vous aide plus ou vous pèse, modifiez-la ou abandonnez-la. Une routine doit s’adapter à votre vie et à vos besoins, pas devenir une épreuve de discipline.")
            ]),
        new(
            ArticleIds.WakeAtNight,
            "Si vous vous réveillez la nuit",
            "Relâchez la pression et laissez le sommeil revenir à son rythme",
            "TipsAndUpdates",
            2,
            [
                P("Un réveil nocturne ne signifie pas que le reste de la nuit est perdu. Vérifier souvent l’heure et compter les heures peut ajouter de la pression. Si vous le pouvez, évitez l’horloge et ne vous exigez pas de vous rendormir immédiatement. Rendez l’environnement aussi calme et sûr que possible."),
                H("Choisissez une activité calme"),
                P("Si rester au lit devient désagréable et que le sommeil ne revient pas, vous pouvez vous lever un moment et faire quelque chose de tranquille sous une lumière douce. Retournez au lit lorsque vous somnolez. Ne suivez pas une recommandation qui vous met mal à l’aise ; tenez compte de votre sécurité, de votre état et des conseils médicaux."),
                H("Mettez les soucis de demain de côté"),
                P("Si les tâches reviennent en boucle, notez-en une ou écrivez une question, puis reprenez-la le matin. Le lendemain, gardez autant que possible votre rythme habituel sans vous imposer trop pour compenser la nuit. Si les troubles du sommeil affectent durablement votre bien-être ou votre quotidien, parlez-en à un professionnel de santé.")
            ]),
        new(
            ArticleIds.SmallDayPlan,
            "Un programme de journée avec de la marge",
            "Choisissez l’essentiel et laissez de la place à la vie",
            "TipsAndUpdates",
            2,
            [
                P("Un programme peut orienter la journée s’il tient compte de votre énergie réelle et des imprévus. Une longue liste montre rarement le temps pris par les trajets, les transitions et le repos. Commencez par demander : qu’est-ce qui compte vraiment aujourd’hui, et que peut-on reporter sans conséquence grave ?"),
                H("Gardez un plan court"),
                P("Notez une tâche principale, un petit geste du quotidien et une pause pour manger ou récupérer. Laissez un créneau libre entre eux. Si une tâche est vague, définissez un résultat visible : non pas « m’occuper des papiers », mais « trouver le formulaire nécessaire ». Gardez le reste sur une autre liste."),
                H("Révisez le programme au fil de la journée"),
                P("Si les circonstances changent ou si votre énergie baisse, adaptez-le : réduisez une étape, reportez une tâche ou demandez de l’aide. Le soir, demandez-vous si le programme vous a guidé, pas combien de cases vous avez cochées. C’est un soutien modifiable, pas une promesse de tout faire.")
            ]),
        MiniArticle(ArticleIds.AskForHelpTask, "Demandez de l’aide pour une partie précise", "Une demande claire évite les devinettes", "Nommez le résultat, la partie concernée et le délai : « Peux-tu relire ces deux pages avant midi ? » Précisez ce qui est déjà fait et le temps que cela prendra environ. Demandez si cette quantité convient. Sinon, proposez une partie plus petite, un autre délai ou demandez qui pourrait vous aider."),
        MiniArticle(ArticleIds.MeaningfulActivity, "Une activité qui a du sens pour vous", "Reliez un petit geste à une valeur", "Demandez-vous ce qui compte ici : le soin, la curiosité, la fiabilité ou le repos. Choisissez une petite action dans cette direction. Elle peut avoir du sens sans tout changer d’un coup. Le sens peut aussi venir du soin que vous apportez à votre avenir."),
        MiniArticle(ArticleIds.FlexibleGoals, "Modifier le plan sans abandonner le but", "Adaptez le pas à votre énergie du jour", "Si le plan initial est trop ambitieux, décidez ce qui compte le plus : l’objectif, l’échéance ou la méthode. Gardez une prochaine étape réalisable — par exemple, préparer un brouillon au lieu de le perfectionner, ou y consacrer dix minutes plutôt qu’une heure. Si l’échéance n’est plus réaliste, prévenez les personnes concernées et proposez un nouveau délai. Adapter le plan, c’est tenir compte de la situation actuelle, pas abandonner l’objectif."),
        MiniArticle(ArticleIds.CelebrateCompletion, "Remarquez ce qui est déjà fait", "L’esprit passe souvent à la tâche suivante", "Après avoir terminé, nommez brièvement ce que vous avez fait et l’effort fourni. Pas besoin de récompense : constater le fait suffit. Vous verrez aussi les tâches accomplies, pas seulement celles qui restent. Si cela vous aide, notez ce qui a facilité la tâche : le bon moment, du soutien ou une pause."),

        new(
            ArticleIds.NameEmotion,
            "Nommez le sentiment plus précisément",
            "Cela peut aider à voir le soutien qui vous manque",
            "TipsAndUpdates",
            2,
            [
                P("« Je ne vais pas bien » exprime une difficulté, sans toujours indiquer ce qui pourrait aider. Si vous le pouvez, ajoutez une nuance : inquiet, seul, irrité, honteux, blessé ou épuisé. Vous n’avez pas besoin du mot parfait ni d’expliquer votre sentiment à qui que ce soit."),
                H("Distinguez le sentiment de la situation"),
                P("Demandez-vous : que s’est-il passé, qu’est-ce que je ressens et qu’est-ce qui compte pour moi ? La colère peut coexister avec la fatigue, l’anxiété avec un manque d’informations. Notez ce que vous observez sans en faire un jugement sur vous ou sur les intentions d’autrui. Si aucun mot ne vient, partez de ce que vous remarquez dans votre corps ou autour de vous."),
                H("Choisissez une petite réponse"),
                P("Demandez-vous si vous avez besoin d’une pause, de clarté, d’un contact de confiance ou d’un endroit plus sûr. Nommer un sentiment ne vous oblige pas à agir sous son influence. Parfois, le reconnaître et reporter une décision suffit. Si la détresse est insupportable ou si vous ne pouvez pas rester en sécurité, demandez une aide urgente.")
            ]),
        new(
            ArticleIds.MixedFeelings,
            "Vous pouvez ressentir deux choses différentes à la fois",
            "Des réactions contradictoires peuvent coexister",
            "TipsAndUpdates",
            2,
            [
                P("Les changements, les relations proches et les décisions suscitent rarement une seule réaction. Vous pouvez vous réjouir d’une possibilité et être triste de ce que vous laissez derrière ; souhaiter de la proximité et avoir aussi besoin de solitude. Des sentiments mêlés ne prouvent ni incohérence ni mauvais choix."),
                H("Faites une place aux deux côtés"),
                P("Essayez de compléter deux phrases : « Je me réjouis parce que… » et « Je suis triste ou inquiet parce que… ». Aucun côté n’a besoin d’annuler l’autre, et vous n’avez pas à décider lequel est le sentiment « vrai ». Si vos idées s’emmêlent, écrivez-les séparément ou parlez à quelqu’un qui ne vous presse pas de conclure."),
                H("Décidez en tenant compte de vos valeurs et du contexte"),
                P("Les sentiments donnent des indications ; vous pouvez aussi considérer la sécurité, les faits, les engagements et ce qui compte pour vous. Choisissez une prochaine étape qui ne vous oblige pas à nier l’un des côtés. Attendre, recueillir des informations ou en parler à une personne de confiance peut aider.")
            ]),
        new(
            ArticleIds.AngerPause,
            "Faites une pause avant de répondre sous le coup de la colère",
            "Réduisez d’abord le risque, puis choisissez vos mots",
            "TipsAndUpdates",
            2,
            [
                P("Quand la colère monte, l’attention peut se rétrécir et les paroles ou les gestes aggraver l’échange. Si c’est sûr, arrêtez d’écrire ou proposez une courte pause : « Je veux en parler, mais j’ai besoin de me calmer. Je reprendrai plus tard. » Donnez un moment réaliste pour revenir au sujet si vous le souhaitez."),
                H("Utilisez la pause pour faire baisser la tension"),
                P("Éloignez-vous vers un lieu plus calme, buvez de l’eau ou faites brièvement une activité neutre. N’envoyez pas de messages pour punir ou effrayer l’autre, et ne conduisez pas si vous êtes trop agité. Une fois plus calme, distinguez les faits des reproches et choisissez la demande ou la limite à exprimer."),
                H("La sécurité prime sur la conversation"),
                P("S’il existe un risque de violence, de menaces ou de harcèlement, n’essayez pas de régler le conflit seul. Allez dans un lieu sûr et contactez une personne de confiance ou les services d’urgence. Une pause ne vous oblige pas à reprendre la conversation ; vous pouvez y mettre fin si la poursuivre n’est pas sûre.")
            ]),
        MiniArticle(ArticleIds.ShameKindness, "Répondre à la honte sans vous humilier", "Réparez une erreur sans vous punir", "Dites-vous : « J’ai honte maintenant, mais ce sentiment ne résume pas qui je suis ». Séparez l’acte de votre identité : que s’est-il passé et peut-on réparer ? Choisissez la réponse que vous offririez à un proche. Si votre geste a fait du mal à quelqu’un, reconnaissez son effet et demandez ce qui pourrait aider à réparer."),
        new(
            ArticleIds.GuiltRepair,
            "Culpabilité : réparer ou laisser partir",
            "Distinguez responsabilité et reproches sans fin",
            "TipsAndUpdates",
            2,
            [
                P("La culpabilité peut signaler que vous avez franchi une limite importante ou blessé quelqu’un. Mais ce sentiment ne prouve pas que tout est de votre faute. Examinez un acte précis plutôt que de condamner toute votre personne."),
                H("Si vous avez causé du tort"),
                P("Nommez ce qui s’est passé et ce qui peut être réparé concrètement. Si cela convient, présentez des excuses précises, sans justification, et demandez ce que souhaite la personne concernée. S’excuser ne l’oblige ni à pardonner immédiatement ni à maintenir le contact. Faites un pas raisonnable et changez ce qui dépend de vous."),
                H("Si la responsabilité n’est pas la vôtre ou si vous avez réparé"),
                P("Vérifiez si vous portez les émotions, les circonstances ou les décisions d’autrui. Après une réparation raisonnable, vous punir sans fin n’aide pas la personne blessée. Vous pouvez reconnaître votre regret, en tirer une leçon et choisir la suite. Une situation complexe ou douloureuse peut se discuter avec un professionnel.")
            ]),
        new(
            ArticleIds.EnvyInformation,
            "L’envie peut indiquer ce que vous désirez",
            "Transformez la comparaison en direction personnelle",
            "TipsAndUpdates",
            2,
            [
                P("L’envie est parfois inconfortable et peut vous pousser à vous juger. Ce sentiment ne détermine pas si vous êtes une bonne personne. Il peut signaler un désir auquel vous avez peu prêté attention : plus de liberté, de reconnaissance, de proximité ou de temps pour quelque chose d’important."),
                H("Nommez le besoin derrière la comparaison"),
                P("Demandez-vous ce qui vous fait envie précisément et quelle part vous souhaitez vraiment dans votre vie. Séparez la valeur recherchée de la manière dont l’autre la poursuit. L’autonomie peut compter pour vous sans que son parcours vous convienne."),
                H("Faites un petit pas sans imiter"),
                P("Envisagez une action cette semaine : demander davantage de responsabilités, écrire à un proche ou réserver du temps pour développer une compétence. Vous découvrirez peut-être que le désir vient surtout de la comparaison, pas de vos valeurs ; vous pouvez alors le laisser partir. Il ne s’agit pas de devenir quelqu’un d’autre, mais d’écouter votre propre direction.")
            ]),
        new(
            ArticleIds.AllowSadness,
            "La tristesse n’a pas à disparaître tout de suite",
            "Accueillez-la et choisissez un soutien",
            "TipsAndUpdates",
            2,
            [
                P("Une perte, une séparation, une déception ou la fatigue peuvent s’accompagner de tristesse. Inutile de l’expliquer immédiatement ou de vous forcer à aller bien. Vous pouvez reconnaître « c’est difficile en ce moment », même sans savoir encore quoi faire."),
                H("Choisissez un soutien doux"),
                P("Demandez-vous ce qui est accessible : un moment seul, un message à un proche, manger, vous reposer ou faire une petite tâche nécessaire. Vous n’avez pas à tout faire d’un coup. Pour demander du soutien, dites clairement : « Je n’ai pas besoin de solution, peux-tu rester avec moi ? » ou « Peux-tu m’aider pour une tâche précise ? »."),
                H("Prenez soin de vous sans exiger un changement d’humeur"),
                P("Les besoins de base comptent même si la tristesse persiste après un premier pas. Si elle gêne durablement votre quotidien ou s’intensifie, demandez un soutien professionnel. Demander de l’aide ne signifie pas avoir échoué ; c’est parfois le prochain appui accessible.")
            ]),
        new(
            ArticleIds.Numbness,
            "Quand il est difficile de ressentir",
            "Ne vous forcez pas à vous ouvrir d’un coup",
            "TipsAndUpdates",
            2,
            [
                P("L’engourdissement ou le vide intérieur peuvent déstabiliser. À eux seuls, ils n’expliquent pas leur cause. Vous n’avez pas à vous forcer à pleurer, à revisiter des souvenirs ou à tout expliquer immédiatement. Commencez par un repère neutre et par ce qui pourrait vous aider dans les prochaines minutes."),
                H("Vérifiez les besoins simples"),
                P("Remarquez où vous êtes, l’heure et ce dont votre corps pourrait avoir besoin : eau, nourriture, chaleur, repos ou un endroit plus calme. Choisissez seulement ce qui est accessible. Vous pouvez écrire à un proche : « Je ne trouve pas les mots, peux-tu rester un peu en contact ? »."),
                H("Demandez du soutien si cela persiste"),
                P("Si l’engourdissement vous inquiète, dure ou gêne les soins et les tâches quotidiennes, parlez-en à un professionnel. N’attribuez pas automatiquement des symptômes nouveaux, intenses ou douloureux à un état émotionnel ; demandez un avis médical si nécessaire.")
            ]),
        new(
            ArticleIds.EmotionWave,
            "Une émotion peut changer, pas forcément tout de suite",
            "Observez-la sans chronomètre",
            "TipsAndUpdates",
            2,
            [
                P("Une émotion forte peut sembler permanente, surtout quand vous êtes en plein dedans. Elle peut changer progressivement, par vagues ou pas encore. Vous n’avez pas à attendre qu’elle disparaisse pour prendre soin de vous ou choisir une prochaine étape sûre."),
                H("Remarquez-la sans exiger un chiffre plus bas"),
                P("Si cela vous aide, nommez l’émotion et évaluez son intensité de zéro à dix. Ce n’est pas un examen : le chiffre n’a pas à diminuer. Vous pouvez aussi remarquer où vous êtes, ce qui s’est passé avant et ce qui vous soutient un peu maintenant."),
                H("Choisissez une action pour les prochaines minutes"),
                P("Essayez un appui simple : vous asseoir, boire de l’eau, vous éloigner du bruit ou contacter une personne de confiance. Plus tard, vous pourrez refaire le point en comparant uniquement avec votre propre ressenti. Si rien n’a changé, ce n’est pas un échec ; essayez un autre soutien ou demandez de l’aide si c’est difficile à traverser.")
            ]),
        new(
            ArticleIds.BodyNoticingChoice,
            "Écoutez votre corps à votre rythme",
            "Un repère extérieur convient aussi",
            "TipsAndUpdates",
            2,
            [
                P("L’attention à la respiration et au corps aide certaines personnes, mais augmente le malaise chez d’autres. Vous pouvez arrêter l’observation à tout moment. Le but n’est pas de trouver la bonne sensation, mais de choisir une orientation sûre et adaptée à maintenant."),
                H("Faites un bref point de repère"),
                P("Si cela vous convient, remarquez un détail neutre : les pieds au sol, le dos soutenu ou la température de l’air. Vous n’avez pas à modifier votre respiration ni à vous détendre. Restez avec l’observation uniquement tant qu’elle vous convient."),
                H("Changez de repère si le malaise augmente"),
                P("Si vous concentrer sur votre corps augmente l’anxiété, ouvrez les yeux et nommez quelques objets, leurs couleurs ou leurs formes. Vous n’avez pas à revenir aux sensations corporelles. N’attribuez pas automatiquement des symptômes nouveaux, intenses ou douloureux à l’anxiété ; demandez un avis médical.")
            ]),
        new(
            ArticleIds.PauseBeforeReact,
            "Une pause entre l’impulsion et la réponse",
            "Vérifiez d’abord si attendre est sans danger",
            "TipsAndUpdates",
            2,
            [
                P("Une émotion forte peut pousser à envoyer un message, accepter ou refuser immédiatement. Une courte pause permet de vérifier si la réponse sert votre objectif. Mais attendre n’est pas toujours utile : si le délai crée un risque ou concerne quelque chose d’important, répondez maintenant, brièvement et clairement."),
                H("Gardez un brouillon"),
                P("Précisez votre objectif : transmettre un fait, poser une question, poser une limite ou convenir d’un moment. Si attendre est sans danger, écrivez un brouillon et laissez-le quelques minutes. Retirez ensuite les reproches et les phrases qui n’aident pas. Expirer lentement peut créer une pause, sans forcément changer votre émotion."),
                H("Choisissez une réponse adaptée au contexte"),
                P("Relisez le message : votre demande ou l’information est-elle claire ? Vous pouvez répondre brièvement, demander du temps ou reprendre la discussion plus tard. Si la sécurité, une échéance ou une aide urgente est en jeu, ne vous servez pas de la pause pour éviter la situation ; dites ce qui est nécessaire ou demandez du soutien.")
            ]),
        new(
            ArticleIds.EmotionalBoundary,
            "Les émotions des autres ne sont pas à réparer par vous",
            "Vous pouvez écouter tout en gardant vos limites",
            "TipsAndUpdates",
            2,
            [
                P("Quand un proche va mal, on peut se sentir obligé de trouver une solution ou de faire disparaître sa détresse. Soutenir ne signifie pas être responsable des émotions et des choix d’autrui. Votre présence peut être chaleureuse et limitée à la fois."),
                H("Demandez quel soutien serait utile"),
                P("Demandez : « Tu veux que j’écoute, que je t’aide pour une chose précise ou qu’on réfléchisse aux options ? ». Proposez seulement ce que vous pouvez réellement faire, comme parler dix minutes ou aider pour une tâche. Ne promettez pas une disponibilité constante si elle n’est pas possible."),
                H("Exprimez clairement votre limite"),
                P("Vous pouvez dire : « Je tiens à toi et je peux parler maintenant, mais je ne peux pas régler ça à ta place. » Si vous ne pouvez pas aider, proposez une autre ressource seulement si cela convient. En cas de danger immédiat, ne comptez pas uniquement sur le soutien personnel : contactez un proche, un professionnel ou les services d’urgence.")
            ]),
        new(
            ArticleIds.SupportWithoutFixing,
            "Être présent sans tout résoudre",
            "Demandez quel soutien serait utile",
            "TipsAndUpdates",
            2,
            [
                P("Les conseils viennent souvent d’une bonne intention, mais peuvent ressembler à une pression dans un moment difficile. Avant de proposer une solution, demandez si la personne souhaite être écoutée, accompagnée ou aidée concrètement. Vous respecterez ainsi son choix et éviterez de répondre à côté de son besoin."),
                H("Proposez une aide concrète et limitée"),
                P("Demandez : « Tu veux que j’écoute, que je reste avec toi ou qu’on réfléchisse à la suite ? ». Si la personne choisit de parler, écoutez sans interrompre par des conseils ni exiger des détails. Proposez uniquement ce que vous pouvez tenir : un temps donné, un appel ou une tâche précise."),
                H("Préservez vos capacités et la sécurité"),
                P("Vous pouvez vous soucier de la personne et dire « pas maintenant ». Ne promettez pas de garder le secret face à une menace immédiate. Si quelqu’un est en danger, contactez un adulte de confiance, un professionnel ou les services d’urgence ; ne restez pas son seul soutien.")
            ]),
        MiniArticle(ArticleIds.AfterCrying, "Après avoir pleuré", "Prenez soin de la minute qui vient", "Vous n’avez pas à expliquer vos larmes tout de suite. Choisissez une chose simple : boire de l’eau, vous laver le visage ou vous asseoir confortablement ; vous pouvez aussi demander à quelqu’un de rester avec vous. Ne vous obligez pas à vous calmer instantanément. Une tâche importante peut attendre. Si vous êtes en danger ou ne pouvez pas rester en sécurité, demandez une aide urgente maintenant."),

        MiniArticle(ArticleIds.SpecificRequest, "Demandez quelque chose de précis", "Une demande claire laisse la place à une réponse", "Formulez votre demande en une phrase : bref contexte, action et moment. Par exemple : « J’aimerais en parler ; as-tu dix minutes après le dîner ? » Vous n’avez pas besoin de vous justifier longuement. Laissez la place à une réponse et proposez une autre option si cela peut aider."),
        MiniArticle(ArticleIds.ListenReflect, "Comprendre d’abord, répondre ensuite", "Une brève reformulation peut réduire la tension", "Résumez l’idée principale avec vos mots et demandez : « Ai-je bien compris ? » Attendez une correction avant de conseiller ou de répondre sur le fond. Demandez si la personne souhaite entendre un conseil. Montrer que vous avez écouté ne signifie pas que vous êtes d’accord. Si l’échange devient trop tendu, proposez une pause et convenez du moment où vous reprendrez la discussion."),
        MiniArticle(ArticleIds.BoundarySentence, "Une phrase pour poser une limite", "Une réponse courte est souvent plus claire qu’une longue défense", "Dites ce qui vous convient et ce que vous ferez : « Je veux parler calmement; si le ton ne change pas, j’arrêterai la conversation et nous reprendrons plus tard. » Parlez de votre propre action plutôt que de chercher à contrôler l’autre. Si le dire directement risque d’aggraver le danger, éloignez-vous et demandez de l’aide."),
        MiniArticle(ArticleIds.NoWithoutEssay, "Vous pouvez dire non sans long discours", "Choisissez une formule polie et claire", "Si vous pouvez le faire sans danger, répondez brièvement : « Merci, mais je ne peux pas » ou « Cela ne me convient pas ». Vous n’avez pas à proposer une autre option ni à donner des raisons personnelles. Si la personne insiste, répétez votre réponse une fois et mettez fin à l’échange si c’est sûr. Si un refus direct vous met en danger, éloignez-vous et cherchez du soutien."),
        MiniArticle(ArticleIds.DifficultTalkOpening, "Commencez une conversation difficile par un objectif", "Parlez d’un fait et d’une demande", "Avant l’échange, notez un objectif et une demande. À un moment calme, décrivez la situation et son effet sans juger la personnalité : « Quand les plans changent sans prévenir, j’ai du mal à m’organiser; pouvons-nous nous prévenir plus tôt ? » Ne commencez pas si ce n’est pas sûr. Si la tension monte, faites une pause et fixez un moment de reprise seulement si c’est sûr."),
        MiniArticle(ArticleIds.RepairAfterConflict, "Reprendre après une dispute", "Faites un petit pas vers la clarté", "Demandez d’abord si l’autre personne est prête à parler. Restez sur un épisode : nommez votre part et demandez comment elle a vécu la situation. Choisissez un seul point à clarifier; vous n’avez pas à tout régler maintenant. Si des menaces ou de la peur apparaissent, arrêtez l’échange et cherchez du soutien."),
        MiniArticle(ArticleIds.ApologyResponsibility, "S’excuser sans renoncer à ses limites", "Nommez l’acte et ce que vous changerez", "Nommez l’acte et son effet : « Je t’ai interrompu et tu n’as pas pu finir. Je suis désolé. » Dites ce que vous ferez autrement et demandez si une réparation serait utile. Reconnaître un geste ne signifie pas accepter toutes les accusations ni renoncer à votre sécurité. L’autre personne peut avoir besoin de temps."),
        MiniArticle(ArticleIds.FeedbackAsInformation, "Séparez un retour de votre valeur", "Précisez ce qui peut vous être utile", "Si le retour est vague, demandez un exemple concret et un changement observable. Choisissez au plus un point à essayer. Un retour sur un résultat ne juge pas toute votre personne. Vous n’avez pas à prendre des insultes ou humiliations pour des critiques utiles. Séparez le fait de la conclusion : « il manque un exemple au rapport » est concret ; « je ne vaux rien » est une généralisation. Si c’est difficile sur le moment, reprenez le retour plus tard."),
        MiniArticle(ArticleIds.ReceiveNo, "Quand quelqu’un répond non", "Un refus à une demande n’est pas toujours un rejet de vous", "Demandez-vous à quoi s’applique le non : à cette demande, à ce moment ou à cette option. Si cela vous aide, demandez une fois s’il existe une autre possibilité; choisissez ensuite qui contacter ou quoi faire vous-même. Vous pouvez être déçu sans conclure que votre valeur est en cause."),
        new(
            ArticleIds.CheckAssumption,
            "Vérifiez une supposition par une question",
            "Clarifiez avant de construire une histoire",
            "TipsAndUpdates",
            2,
            [
                P("Un message ambigu laisse place aux suppositions : une réponse brève peut sembler froide, une pause volontaire. Pourtant, un seul signe montre rarement tout le contexte. Avant de conclure, distinguez ce que vous avez observé de votre interprétation."),
                H("Posez une question neutre"),
                P("Si la réponse compte, demandez : « Ai-je bien compris que… ? » ou « Tu voulais dire… ? ». Évitez les accusations et les séries de messages. Si ce n’est pas urgent, laissez à l’autre le temps de répondre ; choisissez quand consulter à nouveau au lieu d’actualiser sans cesse."),
                H("Voyez si une précision est vraiment nécessaire"),
                P("Si la réponse ne changerait pas votre action, vous pouvez laisser la question ouverte. Si elle compte, attendez ou dites ce que vous devez savoir et pour quand. Si l’échange n’est pas sûr, choisissez un autre moyen ou demandez du soutien. Le but est une clarté utile, pas une certitude absolue.")
            ]),
        MiniArticle(ArticleIds.AskSupport, "Demander du soutien s’apprend", "Dites ce qui vous aiderait", "Dites le soutien que vous souhaitez : être écouté, réfléchir aux options ensemble ou faire quelque chose à deux. Par exemple : « La journée a été difficile. Peux-tu m’écouter dix minutes sans me conseiller ? » Demandez si le moment convient. Sinon, proposez un autre moment ou contactez une personne de confiance."),
        MiniArticle(ArticleIds.SupportWithoutFixing, "Être présent sans tout résoudre", "Demandez quel soutien serait utile", "Essayez : « Tu veux que j’écoute, que je reste avec toi ou qu’on réfléchisse à la suite ? » Ne promettez pas ce que vous ne pouvez pas tenir. Le soutien respecte le choix de l’autre et vos limites. Face à un danger immédiat, écouter ne suffit peut-être pas."),
        new(
            ArticleIds.ConflictNotFailure,
            "Un désaccord ne signifie pas toujours la fin d’une relation",
            "Observez la manière dont vous vous traitez",
            "TipsAndUpdates",
            2,
            [
                P("Des différences existent même dans les relations proches. Ce qui compte n’est pas seulement ce qui se dit pendant le désaccord, mais aussi après : chacun écoute-t-il, prend-il sa part de responsabilité et change-t-il quelque chose concrètement ? Un conflit isolé ne répond pas à toutes les questions sur l’avenir de la relation."),
                H("Discutez d’un sujet à la fois"),
                P("Si vous êtes tous deux en sécurité et prêts à parler, choisissez un événement ou une demande précise. Décrivez ce qui s’est passé, son effet sur vous et le changement concret qui aiderait. Demandez comment l’autre l’a vécu. Tout n’a pas à être résolu en une conversation."),
                H("Ne faites pas passer la réconciliation avant la sécurité"),
                P("Le respect et la responsabilité doivent être réciproques ; ils ne reposent pas uniquement sur vous. En cas de menaces, de violence, de contrôle ou de peur pour votre sécurité, cherchez d’abord protection et soutien. Vous n’êtes pas obligé d’avoir une discussion de réconciliation si elle n’est pas sûre.")
            ]),
        new(
            ArticleIds.MakeExpectationsClear,
            "Exprimez vos attentes à l’avance",
            "N’attendez pas que l’autre devine",
            "TipsAndUpdates",
            2,
            [
                P("Les conflits du quotidien viennent parfois d’idées différentes sur les délais, les rôles ou le résultat attendu, pas forcément d’une mauvaise intention. « On le fera plus tard » peut signifier aujourd’hui pour l’un et la semaine prochaine pour l’autre. Clarifier tôt permet de voir l’écart avant qu’il devienne un reproche."),
                H("Convenez de détails concrets"),
                P("Avant un projet commun, parlez de qui fait quoi, pour quand et de ce qui signifie que c’est terminé. Vérifiez que vous avez compris l’accord de la même façon, éventuellement en le résumant par message. Cela ne garantit pas l’accord, mais rend les attentes visibles."),
                H("Actualisez l’accord si les plans changent"),
                P("Si le délai ou vos possibilités changent, prévenez l’autre tôt et proposez une option nouvelle. Parlez du problème et de la prochaine étape sans attribuer d’intentions. Si aucun accord n’est possible, voyez ce que vous pouvez faire séparément et où une aide supplémentaire est nécessaire.")
            ]),
        new(
            ArticleIds.DigitalBoundaries,
            "Poser des limites dans les messages",
            "Les notifications n’ont pas à diriger la journée",
            "TipsAndUpdates",
            2,
            [
                P("Les alertes fréquentes interrompent l’attention et donnent l’impression qu’il faut répondre tout de suite. Pourtant, être toujours disponible n’est pas la même chose que se soucier des autres. Vous pouvez choisir une routine adaptée à vos responsabilités et à vos relations, si elle est sûre et réaliste."),
                H("Réglez les attentes et les notifications"),
                P("Choisissez des horaires pour les messages courants et désactivez les sons ou aperçus de ceux qui peuvent attendre. Si cela vous convient, dites à vos proches quand vous répondez généralement. Prévoyez un moyen de contact distinct pour les urgences réelles, afin de ne pas manquer l’essentiel."),
                H("Laissez la règle évoluer"),
                P("Essayez cette routine quelques jours et vérifiez que les messages importants arrivent toujours et que vous vous concentrez mieux. Si la situation change, ajustez-la. Il ne s’agit pas d’interdire les échanges, mais de répondre plus attentivement sans être disponible à chaque minute.")
            ]),
        new(
            ArticleIds.FamilyPressure,
            "Quand la famille insiste avec des conseils",
            "Remerciez et dites que vous déciderez",
            "TipsAndUpdates",
            2,
            [
                P("Un conseil peut venir d’une intention bienveillante, mais l’insistance répétée fatigue. Vous pouvez reconnaître l’inquiétude d’un proche sans lui laisser prendre la décision. Une phrase courte est souvent plus claire qu’une longue explication qui ouvre un débat sur chaque argument."),
                H("Préparez une réponse calme"),
                P("Par exemple : « Je vois que tu t’inquiètes. Je vais y réfléchir et décider. » Si le sujet revient, répétez la phrase, proposez d’en reparler plus tard ou changez de sujet. Vous n’avez pas besoin d’obtenir l’accord pour exprimer votre décision."),
                H("Pensez d’abord à votre sécurité"),
                P("Une réponse directe ne convient pas à toutes les relations. Si un désaccord risque de provoquer des menaces, de la violence, une perte de logement ou un autre danger, ne testez pas cette limite seul. Préparez un plan sûr avec une personne de confiance ou un professionnel et choisissez un moment et une façon de répondre qui réduisent le risque.")
            ]),
        new(
            ArticleIds.FriendshipInvitation,
            "Proposer un moment sans grand programme",
            "Une petite invitation est plus facile à accepter ou à refuser",
            "TipsAndUpdates",
            2,
            [
                P("Organiser un grand projet peut sembler compliqué. Une invitation précise et simple réduit l’incertitude : l’autre peut imaginer la rencontre et répondre plus facilement. Un refus ou un emploi du temps chargé indiquent sa disponibilité actuelle, pas votre valeur."),
                H("Faites une proposition simple"),
                P("Précisez l’activité, le jour et la durée approximative : « Ça te dirait une promenade de vingt minutes jeudi après le travail ? » Ajoutez qu’un autre moment ou un refus convient. Inutile de vous excuser d’inviter ou de justifier votre envie de voir la personne."),
                H("Laissez une place à chaque réponse"),
                P("Après l’envoi, attendez au lieu d’envoyer plusieurs relances. Si la personne ne peut pas, proposez un autre moment si elle semble intéressée, ou laissez-la reprendre l’initiative. Sans réponse, revenez à vos activités et décidez plus tard si vous souhaitez réessayer.")
            ]),
        MiniArticle(ArticleIds.SmallConnection, "Un petit contact compte aussi", "Pas besoin de commencer par une conversation profonde", "Si vous vous sentez seul, choisissez une façon simple d’être avec des gens : un message bref, un lieu familier ou une conversation neutre. Arrêtez quand cela suffit. Le but est d’essayer, pas de vous forcer à être sociable. Un bref message ou un lieu partagé peut suffire."),

        MiniArticle(ArticleIds.OrientNow, "Vérifiez où vous êtes maintenant", "Une façon douce de revenir au présent", "Regardez autour de vous et nommez le lieu, le moment de la journée et quelques détails neutres, comme des objets ou des sons. Gardez les yeux ouverts et allez à votre rythme. Vous n’avez pas à vous rappeler les détails de l’événement. Si l’anxiété augmente, arrêtez-vous ; vous pouvez choisir un objet neutre ou demander à une personne de confiance de rester avec vous."),
        MiniArticle(ArticleIds.GroundingChoice, "Choisissez un ancrage qui vous convient", "Se concentrer sur le corps ne convient pas à tout le monde", "Nommez des couleurs, décrivez un objet, sentez la chaise ou écoutez un son régulier. Choisissez un élément supportable maintenant. S’il vous met mal à l’aise, arrêtez et essayez autre chose. Si l’ancrage reste neutre, répétez-le sans exiger un soulagement immédiat."),
        MiniArticle(ArticleIds.AfterNightmare, "Après un rêve pénible", "Rappelez-vous que le rêve est terminé", "Allumez une lumière douce, regardez autour et nommez quelques signes que vous êtes dans votre chambre. Inutile de vous souvenir du rêve en détail. Si les cauchemars reviennent ou perturbent le sommeil, parlez-en à un professionnel de santé. Une fois orienté, choisissez une activité calme et familière plutôt que de chercher un sens au rêve. Si la solitude vous inquiète, réveillez ou contactez une personne de confiance."),
        MiniArticle(ArticleIds.AnniversaryReaction, "Dates difficiles et anniversaires", "La réaction peut survenir avant ou après la date", "Si une date rappelle un événement pénible, prévoyez moins de tâches et choisissez un soutien à l’avance. Vous pouvez marquer la journée à votre façon ou pas du tout. Des émotions fortes ne signifient pas un retour au début. Si le malaise commence souvent à l’avance, prévoyez aussi du temps pour récupérer après cette date."),
        MiniArticle(ArticleIds.PaceRecovery, "Récupérez à votre rythme", "Ne transformez pas le soin de soi en marathon", "Choisissez une pratique et fixez une limite avant de commencer, par exemple trois minutes ou une étape. Si la tension augmente, arrêtez et choisissez quelque chose de plus confortable. Ensuite, notez brièvement : plus facile, pareil ou plus difficile ? Laissez ce constat guider la suite, pas le rythme des autres."),
        MiniArticle(ArticleIds.SafetyFirst, "La sécurité passe avant l’exercice", "L’auto-aide ne demande pas de rester en danger", "S’il y a une menace, essayez d’abord d’aller dans un endroit plus sûr et contactez quelqu’un qui peut aider. La respiration et l’ancrage ne remplacent ni la protection, ni les soins médicaux, ni les urgences. Si vous ne pouvez pas partir seul, demandez à une personne précise d’appeler les secours."),
        new(
            ArticleIds.ChooseTrustedPerson,
            "Choisissez une personne à contacter",
            "Demandez une aide précise et accessible",
            "TipsAndUpdates",
            2,
            [
                P("Quand tout est difficile, on peut croire qu’il faut tout expliquer d’un coup. Pour un premier contact, une demande brève suffit. Pensez à quelqu’un qui respecte généralement vos limites et peut écouter calmement. Ce n’est pas forcément la personne la plus proche si cette relation ne vous semble pas sûre."),
                H("Dites ce qui vous aiderait"),
                P("Par exemple : « C’est difficile en ce moment. Tu pourrais parler avec moi dix minutes ? » ou « Tu peux m’aider à décider qui appeler ? ». Si parler est difficile, envoyez un signal bref convenu à l’avance ou demandez une présence sans questions. Vérifiez si le moment convient à la personne."),
                H("Prévoyez une autre possibilité"),
                P("Une personne de confiance peut être occupée ou ne pas savoir quoi répondre. Cela ne signifie pas que votre demande était mauvaise. Pensez à quelqu’un d’autre ou à un service professionnel local. En cas de danger immédiat, contactez les urgences au lieu d’attendre la réponse d’une seule personne.")
            ]),
        new(
            ArticleIds.AfterStressRecovery,
            "Après un événement stressant",
            "Laissez-vous le temps de reprendre les activités ordinaires",
            "TipsAndUpdates",
            2,
            [
                P("Après un événement stressant, votre énergie et votre attention peuvent être limitées. Vous n’avez pas à tout analyser immédiatement ni à retrouver tout de suite votre rythme habituel. Vérifiez d’abord ce dont vous avez besoin pour l’heure qui vient et ce qui ne peut vraiment pas attendre."),
                H("Commencez par un appui simple"),
                P("Choisissez quelque chose d’accessible : boire de l’eau, manger, vous changer, rester un moment au calme ou écrire à un proche. Si la liste pèse, reportez une tâche non urgente à une heure précise. N’exigez pas de vous sentir mieux après chaque étape."),
                H("Voyez si un soutien supplémentaire serait utile"),
                P("Si les effets perturbent encore le sommeil, le travail, les études ou le quotidien, parlez-en à un professionnel de santé. N’attribuez pas automatiquement des symptômes physiques nouveaux ou intenses au stress. Vous pouvez demander de l’aide avant d’être à bout.")
            ]),
        MiniArticle(ArticleIds.FlashbackGrounding, "Quand le passé semble proche", "Revenez au présent en gardant le choix", "Regardez autour et nommez le lieu et la date si cela aide. Choisissez un objet visible ou contactez quelqu’un près de vous. Ne vous forcez pas à fermer les yeux, respirer profondément ou raconter les détails; cherchez de l’aide réelle en cas de danger. Vous pouvez arrêter l’exercice et rejoindre une personne sûre."),
        new(
            ArticleIds.RecoveryNotLinear,
            "La récupération n’est pas linéaire",
            "Une journée difficile n’efface pas votre chemin",
            "TipsAndUpdates",
            2,
            [
                P("Des émotions fortes peuvent revenir après une période plus calme à cause de la fatigue, d’un rappel ou de nouvelles circonstances. Cela ne prouve pas que vos efforts ont disparu ni que vous êtes revenu au début. Au lieu de vous juger dans votre ensemble, regardez ce qui se passe aujourd’hui et ce qui pourrait vous aider à traverser ce moment."),
                H("Rendez la prochaine étape faisable"),
                P("Demandez-vous ce que vous pouvez simplifier, reporter ou faire avec quelqu’un aujourd’hui. Choisissez un besoin de base et une tâche abordable. Réutilisez ce qui vous a aidé seulement si cela vous convient encore ; vous pouvez essayer autrement."),
                H("Redemandez du soutien si nécessaire"),
                P("Si la difficulté augmente, perturbe votre quotidien ou devient difficile à gérer seul, contactez une personne de confiance ou un professionnel. Demander à nouveau de l’aide fait partie du soin de soi et n’annule pas les progrès. En cas de danger immédiat, cherchez une aide urgente.")
            ]),

        MiniArticle(ArticleIds.BreathIsOptional, "L’exercice de respiration est facultatif", "Ne vous forcez pas à changer votre souffle", "Si vous concentrer sur le souffle est désagréable, laissez-le naturel et choisissez un repère extérieur : couleur, son ou objet. La respiration ne convient pas à tout le monde et ne remplace pas des soins pour un essoufflement important ou un symptôme nouveau. Si compter les respirations vous inquiète, choisissez un son extérieur."),
        MiniArticle(ArticleIds.GroundingCanChange, "Si l’ancrage n’aide pas", "Changez de méthode ou arrêtez", "Si l’exercice n’aide pas ou augmente le malaise, arrêtez-le. Si vous le souhaitez, essayez une fois un repère extérieur simple, comme regarder un objet. Si cela ne suffit pas, contactez quelqu’un ou choisissez un soutien qui demande moins de concentration."),
        MiniArticle(ArticleIds.MovementAnchor, "Le mouvement comme ancrage", "Un petit geste peut rendre un choix", "Si c’est confortable et sûr, ouvrez et fermez lentement les mains ou déplacez votre poids. Vous pouvez aussi regarder un objet bouger. Ne forcez pas malgré la douleur; choisissez un objet immobile si c’est mieux. Assis, vous pouvez poser doucement les pieds au sol."),
        MiniArticle(ArticleIds.SensesAnchor, "Un repère par les sens", "Choisissez un signal neutre autour de vous", "Nommez une couleur, la température de l’air ou un son régulier qui ne vous dérange pas. Inutile de trouver cinq choses ou de fermer les yeux. Un signal neutre suffit parfois; changez-en s’il est désagréable. Si le son vous distrait, choisissez une couleur ; si regarder autour vous fatigue, sentez l’appui sous vos pieds."),
        MiniArticle(ArticleIds.EarlyStressSigns, "Repérez les premiers signes de surcharge", "Les voir tôt ouvre davantage d’options", "Choisissez un signe précoce que vous avez remarqué plusieurs fois, comme la tension ou une attention plus courte. Notez brièvement dans quel contexte il apparaît, puis choisissez une réponse : pause, clarification ou demande d’aide. Cela peut guider votre organisation, sans constituer un diagnostic."),
        MiniArticle(ArticleIds.RelaxWithoutForce, "Se détendre sans effort", "Vous n’avez pas à devenir parfaitement calme", "Choisissez un geste qui demande peu de concentration : baisser les épaules, vous installer mieux ou desserrer les mains. Laissez la respiration naturelle. Un peu de confort suffit; ne forcez pas votre corps à se relâcher entièrement. Si l’attention portée au corps accroît l’inconfort, tournez-vous vers un repère extérieur."),
        MiniArticle(ArticleIds.BasicCareWithoutRules, "Prendre soin de soi sans règles strictes", "Choisissez ce qui manque maintenant", "Choisissez un besoin pour l’heure qui vient et réduisez-le à un petit geste : un verre d’eau, une collation, un vêtement chaud ou un message. S’il est inaccessible, nommez l’obstacle et demandez une aide précise. Ne pas tout gérer seul n’est pas un échec personnel."),
        MiniArticle(ArticleIds.NewSymptomsCare, "Symptômes nouveaux ou inhabituels", "Ne posez pas un diagnostic à partir d’un article", "Si des symptômes physiques sont nouveaux, intenses ou évoluent vite, contactez un professionnel de santé. En cas de signes d’urgence, appelez les services locaux. Un exercice d’auto-aide ne doit pas retarder une évaluation médicale. Notez le début du symptôme, mais n’attendez pas s’il est intense."),
        MiniArticle(ArticleIds.FindTherapist, "Comment chercher un professionnel", "Cherchez une bonne relation de travail, pas une description parfaite", "Demandez la formation, l’expérience sur votre sujet, le format, le coût et la confidentialité. Lors du premier rendez-vous, demandez comment le travail se déroule et comment en évaluer l’utilité. Vous pouvez chercher quelqu’un d’autre si le contact ne convient pas. Précisez aussi les règles d’annulation et la marche à suivre si votre état s’aggrave entre les rendez-vous."),
        MiniArticle(ArticleIds.FirstAppointment, "Le premier rendez-vous", "Vous n’avez pas à préparer un récit parfait", "Apportez un exemple récent et trois questions : comment se passent les séances, qu’est-ce qui reste confidentiel, par quoi commencer ? Vous pouvez dire que c’est difficile à expliquer, demander une pause ou laisser une question sans réponse. Vous n’avez pas à décider tout de suite de poursuivre."),
        MiniArticle(ArticleIds.DescribeSymptoms, "Décrire ce qui se passe", "Un exemple concret vaut mieux que des termes parfaits", "Dites quand cela a commencé, à quelle fréquence et ce qui change au quotidien. Si parler est difficile, apportez une note. Vous n’avez pas à deviner un diagnostic pour demander de l’aide. Un exemple récent de votre quotidien peut faciliter l’explication."),
        MiniArticle(ArticleIds.SelfHelpLimits, "Quand l’auto-aide ne suffit pas", "Le soutien professionnel est une prochaine étape valable", "Si votre état perturbe durablement le sommeil, le travail, les études ou les soins personnels, s’aggrave ou résiste aux exercices, contactez un professionnel de santé ou un psychologue. Pas besoin de prouver que vous avez tout essayé seul. Vous pouvez demander de l’aide avant que la situation devienne insupportable."),

        MiniArticle(ArticleIds.ScreeningNotDiagnosis, "Un questionnaire n’est pas un diagnostic", "Un résultat peut ouvrir une discussion, pas vous étiqueter", "Les réponses reflètent une période précise et dépendent aussi des circonstances. Montrez le résultat à un professionnel s’il vous inquiète. Ne modifiez pas un traitement et ne prenez pas de décision majeure à partir d’un score seul. Le questionnaire aide à préparer des questions, sans remplacer une évaluation."),
        MiniArticle(ArticleIds.SupportPlan, "Préparez un petit plan de soutien", "Notez les signes, les étapes et les contacts", "Notez comment vous voyez que cela devient difficile, ce qui aide habituellement et à qui en parler. Ajoutez les contacts professionnels et les urgences locales. Le plan ne remplace pas l’aide; il indique qui joindre quand penser devient difficile. Vérifiez à l’avance que les contacts sont joignables dans votre région."),
        MiniArticle(ArticleIds.CrisisSteps, "Si vous n’êtes pas en sécurité maintenant", "Contactez une aide en direct", "Allez dans un lieu plus sûr si possible et contactez les services d’urgence locaux ou une personne de confiance. Dites brièvement ce qui se passe et où vous êtes. Ne restez pas seul en cas de danger immédiat. Si appeler est difficile, demandez à quelqu’un de rester avec vous."),
        MiniArticle(ArticleIds.MedicationWithClinician, "Parlez des médicaments avec un professionnel", "Ne changez pas seul une prescription", "En cas de doute, notez le nom du médicament, votre question et tout effet indésirable, puis parlez-en au prescripteur ou au pharmacien. Ne commencez, n’arrêtez et ne modifiez pas une dose sur la foi d’un article ou d’une application. Consultez la notice ou demandez à un pharmacien ; les consignes varient."),
        MiniArticle(ArticleIds.DeadlineConversation, "Si vous risquez de ne pas tenir le délai", "Parlez-en tant qu’il reste des options", "Vérifiez ce qui est terminé et ce qu’il reste réellement. Prévenez au plus tôt les personnes concernées, avec des faits et une date réaliste. Proposez des options : décaler l’échéance, réduire le périmètre ou envoyer une partie déjà terminée. Par exemple : « Les parties 1 et 2 seront prêtes vendredi, le reste mardi. Quelle option vous convient ? » Ne promettez pas une date qui dépend d’un effort excessif et confirmez l’accord."),
        MiniArticle(ArticleIds.DifficultMessageReply, "Avant de répondre à un message difficile", "Choisissez d’abord le but de votre réponse", "Si ce n’est pas urgent, attendez que la première vague d’émotion retombe. Distinguez les mots exacts de l’interprétation que vous en faites. Choisissez un objectif : demander une précision, poser une limite, communiquer une décision ou reporter la conversation. Vous pouvez écrire : « Je vous répondrai à ce sujet ce soir. » Si une réponse est nécessaire tout de suite, donnez seulement les informations utiles et gardez le reste pour plus tard."),
        MiniArticle(ArticleIds.CancelPlans, "Si vous devez annuler une sortie", "Soyez clair et proposez une autre date si vous le souhaitez", "Prévenez dès que possible que vos plans ont changé. Ne partagez que la raison que vous souhaitez expliquer ; un long justificatif n’est pas nécessaire. Si vous souhaitez toujours voir la personne, proposez un jour ou une heure précis. Reconnaissez les conséquences de l’annulation et laissez-lui la possibilité de refuser. Si cela concerne votre sécurité ou votre état, prenez d’abord soin de vous."),
    ];
}
