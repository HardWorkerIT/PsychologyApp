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
        new(
            ArticleIds.AskForHelpTask,
            "Demandez de l’aide pour une partie précise",
            "Décrivez la tâche pour faciliter la réponse",
            "TipsAndUpdates",
            2,
            [
                P("Demander de l’aide peut être gênant, surtout si vous avez l’habitude de vous débrouiller seul ou craignez d’être un poids. Une demande précise réduit l’incertitude et aide l’autre à comprendre votre besoin. Vous n’avez pas à prouver que vous êtes assez épuisé ni que vous méritez de l’aide."),
                H("Limitez la demande"),
                P("Nommez une tâche, son ampleur et un délai utile : « Peux-tu relire aujourd’hui le premier paragraphe de ce courriel ? » Dites ce qui est déjà fait et demandez si le moment convient. Laissez la possibilité de refuser ou de proposer moins. Si vous souhaitez réfléchir à deux, indiquez le temps approximatif demandé."),
                H("Envisagez une autre possibilité"),
                P("Si la personne ne peut pas aider, cela ne signifie pas forcément qu’elle vous juge ou juge votre relation. Vous pouvez réduire la tâche, reporter le délai ou demander à quelqu’un d’autre. Pour une question de sécurité ou un besoin urgent, ne vous arrêtez pas à un seul refus : cherchez un soutien adapté.")
            ]),
        new(
            ArticleIds.MeaningfulActivity,
            "Choisissez une petite action qui compte pour vous",
            "Reliez un geste à ce qui a de la valeur à vos yeux",
            "TipsAndUpdates",
            2,
            [
                P("Quand l’énergie manque, le sens d’une tâche importante peut disparaître. Au lieu de vous demander seulement « Qu’est-ce que je devrais finir ? », essayez : « Qu’est-ce qui compte pour moi dans cette situation ? » Cela peut être le soin, le lien, la curiosité, la fiabilité ou le repos. Une valeur n’est ni une case à cocher ni une mesure de productivité; c’est une direction pour choisir une action."),
                H("Rendez cette valeur concrète"),
                P("Choisissez une action de cinq à dix minutes dans cette direction : envoyer un message chaleureux, ouvrir le document nécessaire, arroser une plante ou vous coucher plus tôt. Réduisez le geste pour pouvoir commencer sans attendre la motivation. Si le repos est prioritaire aujourd’hui, il peut lui aussi être une action qui a du sens."),
                H("Observez l’expérience, pas seulement le résultat"),
                P("Ensuite, remarquez ce qui était présent : intérêt, fatigue, soulagement ou rien de particulier. Vous n’avez pas à forcer un sentiment de satisfaction. Si l’action ne convenait pas ou était inaccessible, adaptez-la ou reportez-la. Le sens n’exige pas un grand résultat et n’efface pas les contraintes réelles.")
            ]),
        new(
            ArticleIds.FlexibleGoals,
            "Gardez le cap et changez de méthode",
            "Un objectif peut s’adapter aux nouvelles circonstances",
            "TipsAndUpdates",
            2,
            [
                P("On prépare souvent un plan dans certaines conditions, puis on doit l’appliquer dans d’autres. S’il est devenu impossible à tenir, c’est une raison de le revoir, pas de vous blâmer. Distinguez la direction qui vous importe, l’objectif précis et la manière de l’atteindre. Le sens peut rester le même même si le délai ou le volume de travail change."),
                H("Choisissez un niveau réaliste"),
                P("Vous pouvez prévoir trois versions : un minimum pour les jours difficiles, l’étape habituelle et un complément si vous avez de l’énergie. Pour préparer un examen, cela peut être ouvrir vos notes et lire une page, revoir un sujet ou travailler toute la partie. Choisissez un minimum qui aide à avancer sans devenir une punition."),
                H("Réexaminez les délais et les accords"),
                P("Si d’autres personnes dépendent de l’objectif, prévenez-les tôt du retard et proposez une nouvelle échéance réaliste. Repérez les obstacles récurrents : prochaine étape floue, manque de temps, fatigue ou ressources indisponibles. Adapter le plan permet de tenir compte des conditions; il peut aussi être raisonnable de modifier l’objectif ou de demander de l’aide.")
            ]),
        new(
            ArticleIds.CelebrateCompletion,
            "Remarquez une étape terminée avant de passer à la suite",
            "Une courte pause rend l’effort visible",
            "TipsAndUpdates",
            2,
            [
                P("Après avoir terminé quelque chose, l’attention passe souvent aussitôt à ce qui reste. La journée peut alors sembler n’être qu’une suite de tâches inachevées. Faites une brève pause et nommez un fait sans l’exagérer : « J’ai envoyé le message », « J’ai demandé de l’aide » ou « Je me suis reposé quand j’étais épuisé ». Ce n’est ni un rituel obligatoire de gratitude ni une façon de prétendre que tout va bien."),
                H("Repérez ce qui vous a aidé"),
                P("Si cela vous est utile, ajoutez une observation : quelle étape a fonctionné, qu’est-ce qui a demandé un effort et quel soutien a compté ? Reconnaître l’action devient ainsi une information pour la prochaine fois, pas un jugement sur votre valeur. Ne comparez pas votre rythme à celui des autres et ne minimisez pas ce que vous avez fait parce qu’il reste du travail."),
                H("Choisissez la transition suivante"),
                P("Après la pause, décidez de ce qui convient : continuer, changer de tâche, demander du soutien ou vous arrêter pour aujourd’hui. Terminer ne signifie pas toujours tout faire parfaitement; il peut suffire de s’arrêter à une étape prévue et sûre. Une journée difficile permet de reconnaître l’effort sans devoir ressentir de la joie.")
            ]),

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
        new(
            ArticleIds.ShameKindness,
            "Répondre à la honte sans vous humilier",
            "Réparez une erreur sans vous punir",
            "TipsAndUpdates",
            2,
            [
                H("Distinguez le sentiment des faits"),
                P("La honte transforme parfois un acte précis en jugement sur toute la personne : « J’ai fait une erreur » devient « Je suis mauvais ». Décrivez la situation concrètement et sans étiquette : qu’avez-vous dit ou fait, que s’est-il passé ensuite et qui a été concerné ? Cela n’efface pas la responsabilité, mais aide à voir ce qui peut être traité."),
                H("Reconnaissez l’effet sans supposer"),
                P("Si vos paroles ou vos actes ont touché quelqu’un, reconnaissez-le directement et brièvement. Vous pouvez dire : « Je t’ai interrompu et je comprends que tu aies pu te sentir écarté. » Il n’est pas nécessaire de commencer par expliquer vos intentions ou de réclamer le pardon. Demandez si la personne souhaite parler de ce qui pourrait aider à réparer, puis respectez sa réponse."),
                H("Choisissez une réparation réaliste"),
                P("Présenter des excuses, corriger une erreur ou changer un comportement précis peut être approprié. Certaines conséquences ne peuvent pas être annulées rapidement ; les changements dans le temps comptent alors davantage. Choisissez une étape possible et ne promettez pas l’impossible. Vous punir ne rétablit pas la confiance et ne répare pas le tort."),
                H("Gardez le respect de vous-même"),
                P("Essayez de vous parler comme à une personne responsable qui mérite aussi le respect : « Je regrette ce que j’ai fait. Je peux le reconnaître et décider de la suite. » La bienveillance envers soi ne justifie pas l’acte. Elle aide à rester tourné vers la responsabilité et l’action plutôt que vers des reproches sans fin."),
            ]),
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
        new(
            ArticleIds.AfterCrying,
            "Après avoir pleuré, laissez-vous du temps",
            "Commencez par les besoins simples, pas par une explication",
            "TipsAndUpdates",
            2,
            [
                P("Après avoir beaucoup pleuré, vous pouvez vous sentir épuisé, trembler, vous sentir vide ou soulagé; chacun réagit différemment. Vous n’avez pas à expliquer vos larmes ni à vous forcer à vous calmer. Vérifiez la situation immédiate : êtes-vous en sécurité ? Avez-vous besoin d’eau, de chaleur, d’une position confortable ou de la présence de quelqu’un ? Choisissez seulement ce qui vous convient."),
                H("Réduisez le prochain pas"),
                P("Vous pouvez vous laver le visage, boire un peu d’eau, vous couvrir ou simplement vous asseoir. Si ces gestes ne vous aident pas ou vous déplaisent, vous n’avez pas à les faire « correctement ». Reportez les grandes décisions jusqu’à ce que vous ayez plus d’énergie. Si vous le souhaitez, écrivez à une personne de confiance : « C’est difficile en ce moment. Peux-tu rester joignable un peu ? »"),
                H("Reprenez les activités progressivement"),
                P("Quand vous vous sentirez prêt, choisissez une petite tâche ou reposez-vous. Pleurer ne signifie pas que vous êtes faible ou revenu au début. Si les pleurs perturbent souvent votre quotidien, que votre état se dégrade ou que vous ne pouvez pas rester en sécurité, demandez un soutien professionnel; en cas de danger immédiat, sollicitez une aide urgente.")
            ]),

        new(
            ArticleIds.SpecificRequest,
            "Formulez une demande précise",
            "Un bref contexte, une action et un moment adapté",
            "TipsAndUpdates",
            2,
            [
                P("Les sous-entendus et les longues explications peuvent cacher ce que vous demandez. Essayez une structure simple : bref contexte, action précise et moment. Par exemple : « J’aimerais parler de l’organisation. As-tu dix minutes après le dîner ? » Cela ne garantit pas un oui, mais permet à l’autre de répondre clairement."),
                H("Laissez le choix"),
                P("Demandez si le moment convient et acceptez un refus ou une autre proposition. Si ce n’est pas urgent, proposez deux options. N’utilisez ni menace ni culpabilité pour obtenir un accord. Si vous posez une limite, dites aussi ce que vous ferez de votre côté."),
                H("Vérifiez le sens de la réponse"),
                P("Si l’accord est vague, précisez l’heure ou l’étape suivante. Sans réponse pour l’instant, convenez d’un moment pour revenir à la question ou voyez ce que vous pouvez faire seul. Dans une situation dangereuse, une conversation ordinaire peut ne pas suffire : choisissez un moyen plus sûr d’obtenir du soutien.")
            ]),
        new(
            ArticleIds.ListenReflect,
            "Comprendre d’abord, répondre ensuite",
            "Vérifiez le sens avant de proposer un conseil",
            "TipsAndUpdates",
            2,
            [
                P("Dans un échange tendu, il est facile de préparer sa réponse pendant que l’autre parle encore. Reformuler brièvement ce que vous avez entendu permet de vérifier votre compréhension et lui donne la possibilité de corriger. Ce n’est pas une manière de gagner une dispute, mais d’éviter de répondre à des propos qui n’ont pas été tenus."),
                H("Résumez une idée principale"),
                P("Choisissez une idée : « Si j’ai bien compris, tu as été contrarié par le changement de programme sans prévenir ? » Puis arrêtez-vous et laissez l’autre préciser. N’ajoutez pas immédiatement une défense, un diagnostic ou une solution. Si vous hésitez, demandez ce qui vous a échappé."),
                H("Demandez ce qui aiderait maintenant"),
                P("Vous pouvez demander : « Tu préfères que je t’écoute ou qu’on réfléchisse ensemble à la suite ? » Reformuler ne signifie pas accepter toutes les conclusions ni abandonner vos limites. Si l’échange devient dangereux ou trop intense, faites une pause et ne le reprenez que dans des conditions adaptées.")
            ]),
        new(
            ArticleIds.BoundarySentence,
            "Une limite porte sur ce que vous ferez",
            "Dites ce qui vous convient et comment vous agirez",
            "TipsAndUpdates",
            2,
            [
                P("Une limite ne sert pas à obliger l’autre à se comporter autrement. Elle indique clairement ce qui vous convient et ce que vous ferez si la situation continue. Choisissez un épisode précis plutôt que de raconter toute la relation. Si une parole directe risque d’entraîner des menaces ou de la violence, ne vous entraînez pas seul : pensez d’abord à votre sécurité et au soutien possible."),
                H("Soyez bref et parlez en votre nom"),
                P("Vous pouvez suivre cette structure : « Quand X se produit, Y est difficile pour moi. Je demande Z; si cela continue, je ferai W. » Par exemple : « Je veux bien en parler sans insultes. Si elles continuent, je mettrai fin à l’appel. » N’annoncez qu’une action qui dépend de vous et que vous pourrez tenir. Vous n’avez pas à prouver que votre limite est légitime ni à obtenir l’accord de l’autre."),
                H("Répétez une fois, puis agissez"),
                P("Si l’on vous entraîne dans un débat sur votre droit à poser une limite, répétez-la calmement, sans nouvelles justifications. Puis faites ce que vous avez annoncé, si c’est sûr. Une limite peut déplaire à quelqu’un tout en restant importante. Si les circonstances changent, vous pouvez l’ajuster ou demander de l’aide pour la faire respecter.")
            ]),
        new(
            ArticleIds.NoWithoutEssay,
            "Vous pouvez dire non sans longue justification",
            "Soyez clair sans devoir prouver que vos raisons suffisent",
            "TipsAndUpdates",
            2,
            [
                P("Un refus peut décevoir ou susciter des questions, et vous pouvez craindre qu’il abîme la relation. Si dire non est sans danger, une phrase claire suffit. Vous pouvez tenir à l’autre tout en refusant sa demande. Décidez de ce que vous pouvez réellement proposer; ne promettez pas sous pression une chose que vous ne pouvez pas ou ne voulez pas faire."),
                H("Choisissez une formule qui vous ressemble"),
                P("Vous pouvez dire : « Merci d’avoir pensé à moi, mais je ne peux pas cette fois », « Je n’ai pas la disponibilité pour cela en ce moment » ou « Ce moment ne me convient pas ». Vous pouvez proposer une autre option si vous le souhaitez, mais ce n’est pas obligatoire. Vous n’avez pas non plus à révéler toutes vos raisons personnelles. Être aimable ne signifie pas être vague."),
                H("Répondez à l’insistance"),
                P("Si la personne insiste, répétez brièvement votre réponse au lieu de trouver une nouvelle justification à chaque fois. Vous pouvez mettre fin à l’échange ou répondre plus tard. Si un refus direct risque d’entraîner des menaces, du contrôle ou un préjudice, privilégiez votre sécurité : faites appel à une personne de confiance, choisissez un mode de communication plus sûr ou éloignez-vous si possible.")
            ]),
        new(
            ArticleIds.DifficultTalkOpening,
            "Donnez un objectif modeste à une conversation difficile",
            "Commencez par un fait précis et une demande",
            "TipsAndUpdates",
            2,
            [
                P("Un sujet difficile peut vite devenir un jugement sur toute la relation. Avant de parler, notez un objectif : que souhaitez-vous clarifier, résoudre ou simplement faire savoir ? Choisissez ensuite un événement précis et une demande. Si vous êtes en colère, épuisé ou inquiet, vous pouvez attendre; la conversation n’a pas besoin d’avoir lieu tout de suite."),
                H("Décrivez le fait et son effet"),
                P("Choisissez un moment où vous êtes tous les deux assez calmes et disponibles. Dites ce que vous avez observé, son effet sur vous et le changement que vous aimeriez essayer. Par exemple : « Quand les plans changent au dernier moment, j’ai du mal à organiser les trajets. Pourrions-nous nous prévenir plus tôt ? » Évitez les suppositions sur les intentions comme « tu fais toujours » ou « tu t’en fiches »."),
                H("Laissez une place à la réponse"),
                P("Écoutez comment l’autre a compris, clarifiez un malentendu ou convenez d’une prochaine étape réaliste. Si la tension monte, prévoyez une pause et un moment pour reprendre. Si parler directement risque d’entraîner violence ou représailles, ne comptez pas sur des techniques de communication pour vous protéger : demandez de l’aide à une personne de confiance ou à un service professionnel.")
            ]),
        new(
            ArticleIds.RepairAfterConflict,
            "Reprendre après une dispute",
            "Vérifiez la disponibilité de l’autre et choisissez un point",
            "TipsAndUpdates",
            2,
            [
                P("Après une dispute, vous pouvez vouloir tout expliquer immédiatement ou ne plus jamais en parler. Avant de chercher à clarifier, demandez si l’autre personne est prête à discuter et vérifiez aussi votre propre disponibilité. Le premier échange peut avoir un objectif modeste : comprendre un épisode, pas résoudre toute la relation."),
                H("Restez sur un moment précis"),
                P("Décrivez ce qui s’est passé sans étiquettes ni suppositions sur les intentions. Nommez votre part, s’il y en a une, et demandez comment l’autre a vécu la situation. Écouter son point de vue ne signifie pas être automatiquement d’accord. Si vos souvenirs diffèrent, clarifiez un fait ou le sens d’une phrase avant de débattre de tout."),
                H("Terminez avec précaution"),
                P("Dites ce qui est plus clair et ce qui pourrait suivre : un petit accord, une autre conversation ou du temps pour réfléchir. Si la tension monte, convenez d’une pause. En cas de menaces, d’intimidation ou de peur, ne cherchez pas la réconciliation à tout prix : arrêtez l’échange, mettez-vous en sécurité et demandez du soutien.")
            ]),
        new(
            ArticleIds.ApologyResponsibility,
            "Présentez des excuses avec responsabilité et limites",
            "Nommez l’acte précis sans en justifier l’impact",
            "TipsAndUpdates",
            2,
            [
                P("Des excuses utiles portent sur l’acte et ses effets, pas sur la preuve que vous êtes une bonne personne. Soyez précis : « Je t’ai interrompu et tu n’as pas pu finir. » Reconnaissez l’effet et dites que vous le regrettez, sans ajouter « mais toi aussi… ». Vous pouvez expliquer votre intention séparément si l’autre personne le souhaite."),
                H("Proposez une réparation réaliste"),
                P("Dites ce que vous essaierez de faire autrement la prochaine fois et demandez si un petit geste pourrait aider maintenant. Ne promettez rien que vous ne puissiez tenir. L’autre personne n’est pas obligée de pardonner ou de vous rassurer tout de suite ; laissez-lui du temps et acceptez sa réponse."),
                H("La responsabilité n’exige pas de renoncer à votre sécurité"),
                P("Vous pouvez reconnaître une erreur précise tout en refusant les insultes, la pression ou les accusations que vous estimez fausses. N’utilisez pas vos excuses pour obtenir le pardon ou reprendre contact. Si l’échange devient dangereux, arrêtez-le et gardez une distance sûre.")
            ]),
        new(
            ArticleIds.FeedbackAsInformation,
            "Séparez un retour sur le travail de votre valeur",
            "Cherchez des éléments précis, pas un verdict sur vous",
            "TipsAndUpdates",
            2,
            [
                P("Une remarque sur un résultat peut sembler juger toute votre personne, surtout si elle est inattendue ou formulée durement. Faites une pause et distinguez trois éléments : les mots exacts, un fait vérifiable et la conclusion que vous en tirez sur vous. « Il manque un exemple au rapport » décrit le travail ; « je suis incapable » est une généralisation."),
                H("Demandez une précision"),
                P("Si le retour est vague, demandez un exemple et quel changement serait observable. Choisissez un seul point réaliste à essayer dans le prochain travail. La manière de s’exprimer n’est pas toujours utile : les insultes et l’humiliation ne deviennent pas constructives parce qu’on les appelle des retours."),
                H("Choisissez la suite"),
                P("Vous n’avez pas à répondre immédiatement. Notez l’élément utile, réfléchissez-y plus tard ou demandez l’avis d’une personne qui connaît le contexte. Si le retour contredit des faits ou un accord, clarifiez-le calmement. Un travail et une évaluation ne définissent pas toutes vos capacités.")
            ]),
        new(
            ArticleIds.ReceiveNo,
            "Quand quelqu’un répond non",
            "Un refus à une demande n’est pas toujours un rejet de vous",
            "TipsAndUpdates",
            2,
            [
                H("Précisez à quoi s’applique la réponse"),
                P("Un non peut concerner une demande précise, le moment choisi ou une option. Ne tirez pas trop vite de conclusion sur la relation ou votre valeur si la personne ne l’a pas dit. Si le contexte s’y prête, vous pouvez demander calmement : « Tu veux dire que ce n’est pas possible maintenant ? »"),
                H("Respectez la limite"),
                P("Si le refus est clair, ne transformez pas la demande de précision en pression. L’autre personne peut refuser ou ne pas expliquer pourquoi. Vous pouvez être déçu, faire une pause et décider de la suite. Accepter la réponse ne signifie pas la trouver juste à tous égards ; cela signifie ne pas obtenir un accord par la pression."),
                H("Cherchez une autre voie"),
                P("Si le besoin demeure, distinguez-le de cette source d’aide particulière. Si la personne semble disposée à en parler, vous pouvez demander une fois s’il existe un autre moment ou une autre option. Sinon, voyez qui d’autre contacter, quelle partie vous pouvez faire vous-même ou si la tâche peut attendre."),
                H("Faites une place à la déception"),
                P("Nommez simplement ce que vous ressentez : « Je suis déçu, je comptais sur cette aide. » Vous n’avez pas à vous convaincre que cela ne compte pas ni à retrouver immédiatement votre calme. Quand la première réaction s’apaise, examinez les possibilités et choisissez une étape. Le refus d’une demande ne définit pas votre valeur."),
            ]),
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
        new(
            ArticleIds.AskSupport,
            "Demandez du soutien en précisant ce qui vous aiderait",
            "Une demande concrète facilite le premier pas",
            "TipsAndUpdates",
            2,
            [
                P("Demander de l’aide peut être difficile quand on traverse déjà une période pénible. Vous pouvez craindre un refus, un jugement ou de devenir un poids. Commencez par repérer ce qui vous aiderait maintenant : être écouté, réfléchir ensemble, recevoir une aide pratique ou ne pas rester seul. La demande peut être modeste et limitée dans le temps."),
                H("Précisez l’aide et sa durée"),
                P("Dites par exemple : « La journée a été difficile. Peux-tu m’écouter dix minutes sans me conseiller ? » ou « Peux-tu m’aider à prendre un rendez-vous ? J’ai du mal à commencer. » Demandez si le moment convient. L’autre peut accepter, refuser ou proposer autre chose. Vous n’avez pas à raconter toute votre histoire pour avoir le droit de demander."),
                H("Si ce n’est pas possible cette fois"),
                P("Un refus ou un mauvais moment ne signifie pas forcément que vous ne comptez pas. Vous pouvez demander à une autre personne de confiance, choisir une autre forme de soutien ou réduire la demande. En cas de danger immédiat ou si vous ne pouvez pas assurer votre sécurité, ne comptez pas sur un seul proche : contactez aussi une aide d’urgence ou professionnelle.")
            ]),
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
        new(
            ArticleIds.SmallConnection,
            "Commencez par un contact modeste",
            "Le lien ne commence pas forcément par une conversation profonde",
            "TipsAndUpdates",
            2,
            [
                P("La solitude peut rendre le premier pas particulièrement difficile. Vous n’avez pas à devenir sociable du jour au lendemain ni à trouver tout de suite un ami proche. Choisissez un contact peu exigeant : envoyer un mot à une connaissance, saluer un voisin, être près d’autres personnes dans un lieu familier ou parler d’un sujet neutre. Un petit pas est un essai, pas un examen."),
                H("Adaptez le contact à votre énergie"),
                P("Pensez à ce qui vous semble généralement le plus facile : un message, un bref appel, une activité de groupe ou simplement un lieu public familier. Vous pouvez limiter la durée et prévoir comment partir si vous vous fatiguez. Choisissez une personne et un cadre peu pressants. Sans réponse, ne tirez pas de conclusion sur votre valeur à partir d’un seul moment; essayez à un autre moment ou sous une autre forme."),
                H("Repérez ce qui vous convient"),
                P("Après coup, remarquez ce qui était confortable, ce qui vous a coûté de l’énergie et le temps de récupération nécessaire. Le but n’est pas de compter les échanges ni de supporter un environnement pénible. Si la solitude perturbe durablement votre quotidien ou que votre état se dégrade, demandez du soutien à une personne de confiance ou à un professionnel.")
            ]),

        new(
            ArticleIds.OrientNow,
            "Vérifiez où vous êtes maintenant",
            "Une façon douce de revenir au présent",
            "TipsAndUpdates",
            2,
            [
                H("S’orienter sans se presser"),
                P("Quand l’attention est entraînée vers le passé ou un avenir inquiétant, il peut parfois être utile de remarquer ce qui vous entoure. Il ne s’agit pas de vous forcer à vous calmer ni de tester votre concentration. L’objectif est plus modeste : relever quelques faits neutres du présent, puis choisir où porter votre attention."),
                H("Nommer des faits simples"),
                P("Gardez les yeux ouverts si cela vous convient mieux. Regardez autour de vous et nommez le lieu où vous êtes, le moment approximatif de la journée et un objet proche. Vous pouvez en décrire la couleur, la forme ou l’usage. Repérez ensuite un autre élément neutre : un bruit dehors, une ligne sur le mur ou la lumière sur une surface. Aucun sens particulier n’est à trouver."),
                H("Adaptez l’exercice"),
                P("Choisissez seulement des observations qui ne vous submergent pas. Vous n’avez pas à énumérer beaucoup de détails, bouger, toucher un objet ni suivre votre respiration. Une phrase peut suffire : « Je suis ici, c’est le matin, une table est devant moi. » Si les mots ne viennent pas, regarder un objet suffit."),
                H("Vérifier si cela vous convient"),
                P("Après quelques secondes, demandez-vous si tout paraît un peu plus clair, inchangé ou plus inconfortable. Toutes les réponses sont valables. Si le malaise augmente, arrêtez-vous et choisissez quelque chose de plus sûr pour vous ; vous pouvez demander à une personne de confiance de rester avec vous. Vous n’avez pas à obtenir le calme ni à continuer de force."),
            ]),
        new(
            ArticleIds.GroundingChoice,
            "Choisissez un ancrage qui vous convient",
            "Se concentrer sur le corps ne convient pas à tout le monde",
            "TipsAndUpdates",
            2,
            [
                H("L’ancrage est un choix, pas une règle"),
                P("Le mot « ancrage » désigne souvent un exercice bref pour remarquer le présent, mais il n’existe pas de méthode adaptée à tout le monde. Certaines personnes préfèrent regarder des objets ou écouter un son ; se concentrer sur la respiration ou le corps peut être inconfortable pour d’autres. Vous pouvez écarter toute méthode et vous arrêter à tout moment."),
                H("Commencez par un élément extérieur"),
                P("Choisissez un détail simple à proximité : nommez une couleur, trouvez un objet aux lignes droites ou décrivez son utilité. Vous pouvez aussi écouter un bruit de fond régulier sans chercher à en trouver la source. Restez quelques secondes avec un seul repère, puis vérifiez comment vous vous sentez."),
                H("Les sensations corporelles, seulement si vous le souhaitez"),
                P("Si cela vous convient, remarquez le soutien de la chaise, la position de vos pieds ou le tissu d’une manche. Il n’est pas nécessaire de parcourir tout le corps, de changer de posture ou de fermer les yeux. Si cette attention provoque douleur, engourdissement, forte tension ou souvenirs indésirables, laissez-la et choisissez un objet extérieur."),
                H("Gardez la liberté de changer"),
                P("Demandez-vous : est-ce supportable, neutre ou plus difficile ? Si c’est supportable, vous pouvez continuer un peu. Si rien ne change, c’est une information, pas un échec. Si cela empire, arrêtez-vous. Le but n’est pas de garantir un soulagement, mais de trouver un soutien qui vous convient sans vous mettre la pression."),
            ]),
        new(
            ArticleIds.AfterNightmare,
            "Après un cauchemar, revenez doucement au présent",
            "Inutile d’interpréter ou de repasser le rêve",
            "TipsAndUpdates",
            2,
            [
                P("Après un cauchemar, le corps peut continuer à réagir comme si le danger persistait. Ne vous exigez pas de vous rendormir immédiatement ni de comprendre le sens du rêve. Si cela vous convient, allumez une lumière, regardez autour de vous et rappelez-vous : « C’était un rêve; je suis réveillé maintenant. » Vous pouvez nommer le lieu, la date du jour ou un objet familier. Si l’attention portée à l’environnement ou au corps augmente votre détresse, arrêtez et choisissez autre chose."),
                H("Choisissez une étape calme"),
                P("Asseyez-vous confortablement, buvez de l’eau ou faites une activité calme et familière. Si cela aide, écrivez à une personne de confiance; si vous ne voulez réveiller personne, laissez une lumière allumée. Vous n’avez pas à noter ou à raconter le rêve pendant la nuit. Retournez au lit quand vous vous sentirez prêt, sans suivre un horaire strict."),
                H("Si les cauchemars reviennent"),
                P("Repérez seulement ce qui pourrait aider lors d’un échange avec un professionnel, comme leur fréquence et leurs effets sur le sommeil et la journée. Vous n’avez pas à chercher seul une interprétation symbolique. S’ils perturbent régulièrement le repos ou sont liés à une expérience pénible, parlez-en à un professionnel de santé ou de santé mentale. En cas de danger immédiat, privilégiez d’abord la sécurité et l’aide urgente.")
            ]),
        new(
            ArticleIds.AnniversaryReaction,
            "Une date difficile peut demander un programme plus doux",
            "La réaction peut venir avant, pendant ou après",
            "TipsAndUpdates",
            2,
            [
                P("Les dates liées à une perte, un changement ou un événement douloureux peuvent provoquer des réactions diverses. Le malaise peut apparaître avant, le jour même ou après; certaines personnes ressentent peu de choses. Aucune de ces réactions ne signifie que vous vivez cela « mal ». Vous n’avez pas à expliquer aux autres pourquoi cette date compte pour vous."),
                H("Décidez comment vous souhaitez vivre cette journée"),
                P("Si possible, prévoyez moins d’obligations et choisissez à l’avance une personne à appeler ou à qui écrire. Vous pouvez vous souvenir à votre manière, garder vos habitudes ou ne suivre aucun rituel. Prévoyez une autre option si la journée devient trop difficile : partir plus tôt, faire une pause ou demander à quelqu’un de rester avec vous."),
                H("Gardez du temps pour récupérer"),
                P("Pensez à ce qui pourrait aider ensuite : un repas simple, du sommeil, une soirée libre ou parler à un proche. Ne comparez pas vos émotions à celles des autres et ne vous forcez pas à commémorer. Si la détresse perturbe durablement votre quotidien, parlez-en à un professionnel; si votre sécurité est immédiatement menacée, demandez une aide urgente.")
            ]),
        new(
            ArticleIds.PaceRecovery,
            "Récupérez à votre rythme",
            "Ne transformez pas le soin de soi en marathon",
            "TipsAndUpdates",
            2,
            [
                H("Le repos n’est pas une tâche de plus"),
                P("Quand tout devient difficile, les conseils de soin de soi peuvent former une longue liste d’obligations. Si votre énergie est basse, même une pratique utile peut sembler imposée. Le rétablissement n’a pas à être rapide ni identique chaque jour. Vous pouvez choisir un petit soutien, ou ne rien ajouter aujourd’hui."),
                H("Choisissez un minimum faisable"),
                P("Demandez-vous ce qui est possible : boire de l’eau, manger, poser brièvement le téléphone, ouvrir une fenêtre ou écrire à une personne de confiance. Choisissez une action adaptée à votre situation réelle. N’imposez ni minuteur ni quota si cela ajoute de la pression ; une limite n’est utile que si elle aide à s’arrêter."),
                H("Observez l’effet sans vous noter"),
                P("Ensuite, remarquez ce qui a changé : un peu plus facile, pareil ou plus difficile ? Ce n’est pas une note de discipline. Si une pratique ne vous convient pas, arrêtez-la ou choisissez un autre soutien. Il est parfois utile de découvrir que vous avez besoin de calme, de nourriture, de sommeil, d’aide pratique ou de présence."),
                H("Demandez de l’aide avant l’épuisement"),
                P("Si les tâches quotidiennes restent difficiles pendant un certain temps, vous n’avez pas à attendre de pouvoir tout gérer seul. Dites à un proche ce qui est devenu compliqué ou parlez de votre état à un professionnel. Demander de l’aide est une démarche concrète, comme se reposer ; vous n’avez pas à prouver que vous avez tout essayé."),
            ]),
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

        new(
            ArticleIds.BreathIsOptional,
            "L’exercice de respiration est facultatif",
            "Ne vous forcez pas à changer votre souffle",
            "TipsAndUpdates",
            2,
            [
                H("Vous n’avez pas à vous concentrer sur le souffle"),
                P("Les exercices de respiration ne conviennent pas à tout le monde et ne sont pas nécessaires à chaque moment difficile. Se concentrer sur chaque respiration peut augmenter la tension ou des sensations désagréables. Vous pouvez laisser cet exercice, respirer naturellement et choisir un autre repère. Cela ne signifie pas que vous faites mal."),
                H("Si vous souhaitez essayer"),
                P("Installez-vous confortablement et remarquez simplement votre respiration habituelle pendant quelques secondes, sans compter, retenir l’air ni chercher à inspirer plus profondément. Vous pouvez observer le mouvement d’un vêtement sur la poitrine uniquement si cela vous convient. Un essai bref suffit ; aucun rythme ni durée ne sont imposés."),
                H("Arrêtez en cas d’inconfort"),
                P("Si vous avez des vertiges, si l’anxiété augmente, si vous manquez d’air ou si cette attention vous gêne, arrêtez l’exercice et reprenez votre respiration habituelle. Choisissez un repère extérieur, comme une couleur ou un objet. N’essayez pas de « corriger » la sensation en respirant plus profondément ou en retenant votre souffle."),
                H("Quand une évaluation médicale est importante"),
                P("Cet exercice ne détermine pas la cause d’un essoufflement et ne remplace pas des soins. Un essoufflement nouveau, important ou qui s’aggrave rapidement nécessite une évaluation médicale ; en cas d’aggravation grave et soudaine ou de danger immédiat, contactez les urgences locales. Si un professionnel vous a conseillé une technique pour une raison médicale, suivez ses indications personnalisées."),
            ]),
        new(
            ArticleIds.GroundingCanChange,
            "Si l’ancrage n’aide pas",
            "Changez de méthode ou arrêtez",
            "TipsAndUpdates",
            2,
            [
                H("L’absence d’effet n’est pas votre faute"),
                P("Un exercice d’ancrage peut ne pas vous convenir maintenant. Il n’est pas censé modifier rapidement votre humeur, et ne pas ressentir de soulagement ne signifie pas que vous l’avez mal fait. Se concentrer sur les sensations, la respiration ou des souvenirs peut parfois renforcer l’anxiété. Dans ce cas, prenez en compte votre réaction au lieu d’insister."),
                H("Faites une pause et choisissez à nouveau"),
                P("Arrêtez-vous si vous vous sentez plus mal, étourdi, détaché ou si vous souhaitez simplement arrêter. Rouvrez les yeux s’ils étaient fermés et regardez un objet neutre, seulement si cela vous convient. Vous n’avez pas à respirer profondément, compter les sensations ou répéter les étapes jusqu’à obtenir un résultat « correct »."),
                H("Essayez une option moins exigeante"),
                P("Si vous souhaitez continuer, choisissez un repère extérieur plus simple : lisez une inscription, nommez une couleur ou repérez la porte. Vous pouvez aussi mettre les exercices de côté et faire une activité ordinaire et calme. Évitez d’enchaîner plusieurs techniques si cela ajoute de la pression."),
                H("Quand une autre personne peut aider"),
                P("S’il vous est difficile de rester en sécurité seul, contactez une personne de confiance et dites-lui ce qui vous aiderait : sa présence, une aide pratique ou un soutien pour joindre un professionnel. En cas de danger immédiat, contactez les services d’urgence locaux. Vous pouvez refuser un exercice et avoir tout de même droit à de l’aide."),
            ]),
        new(
            ArticleIds.MovementAnchor,
            "Le mouvement comme ancrage",
            "Un petit geste peut rendre un choix",
            "TipsAndUpdates",
            2,
            [
                H("Le mouvement est une possibilité parmi d’autres"),
                P("Un petit mouvement peut servir de repère s’il est confortable pour votre corps maintenant. Il n’a pas à améliorer votre humeur ni à ressembler à un exercice. Vous pouvez choisir un geste minime, observer un mouvement autour de vous ou préférer un objet immobile ; toutes ces options se valent."),
                H("Choisissez une position stable"),
                P("Vérifiez d’abord que vous êtes assis ou debout en sécurité, sans risque de perdre l’équilibre. Si cela vous convient, ouvrez et fermez lentement les doigts, tournez doucement les poignets ou remarquez l’appui sous vos pieds. Un seul geste dans une amplitude confortable suffit ; pas besoin de vous étirer, de vous lever ou de répéter un nombre défini."),
                H("Observez votre réaction"),
                P("Remarquez ce qui se passe pendant le geste. S’il est neutre ou agréable, vous pouvez continuer quelques secondes. Arrêtez en cas de douleur, vertige, faiblesse ou anxiété accrue. Ne forcez pas un symptôme pour suivre une pratique ; vous pouvez choisir un repère visuel ou demander de l’aide."),
                H("Terminez sans noter le résultat"),
                P("Quand vous le souhaitez, arrêtez le mouvement et choisissez la suite : rester assis, reprendre une activité habituelle ou contacter quelqu’un. Inutile de comparer vos mouvements actuels à ceux d’avant. Si des symptômes physiques nouveaux ou importants gênent vos mouvements, parlez-en à un professionnel de santé."),
            ]),
        new(
            ArticleIds.SensesAnchor,
            "Un repère par les sens",
            "Choisissez un signal neutre autour de vous",
            "TipsAndUpdates",
            2,
            [
                H("Un seul signal suffit"),
                P("Quand l’environnement est chargé, vous pouvez choisir un seul signal neutre au lieu de suivre une longue liste. Par exemple, remarquer une couleur, la forme d’un objet, un son régulier ou la température de l’air. Inutile de trouver cinq choses, de fermer les yeux ou de solliciter tous vos sens."),
                H("Choisissez quelque chose de supportable"),
                P("Le repère doit être suffisamment neutre pour vous. Une lumière vive, le bruit, les odeurs ou le toucher peuvent distraire ou irriter. Si un signal est désagréable, ne vous forcez pas à le garder. Vous pouvez rejoindre un endroit plus calme, regarder un objet familier ou laisser l’exercice."),
                H("Adaptez-le à ce qui vous est accessible"),
                P("Si regarder autour de vous est difficile, vous pouvez nommer mentalement un objet familier ou remarquer un son discret. Si les sons distraient, choisissez une forme ou une couleur. En cas de limitations visuelles, auditives ou motrices, utilisez tout repère accessible ; aucun sens particulier n’est obligatoire."),
                H("Vérifiez si cela vous convient maintenant"),
                P("Restez quelques secondes avec le repère choisi et demandez-vous si c’est plus confortable, pareil ou plus difficile. Vous n’avez pas à atteindre un état particulier. Si le malaise augmente, changez ou arrêtez. Choisir un autre signal n’est pas une erreur, c’est respecter vos limites."),
            ]),
        MiniArticle(ArticleIds.EarlyStressSigns, "Repérez les premiers signes de surcharge", "Les voir tôt ouvre davantage d’options", "Choisissez un signe précoce que vous avez remarqué plusieurs fois, comme la tension ou une attention plus courte. Notez brièvement dans quel contexte il apparaît, puis choisissez une réponse : pause, clarification ou demande d’aide. Cela peut guider votre organisation, sans constituer un diagnostic."),
        MiniArticle(ArticleIds.RelaxWithoutForce, "Se détendre sans effort", "Vous n’avez pas à devenir parfaitement calme", "Choisissez un geste qui demande peu de concentration : baisser les épaules, vous installer mieux ou desserrer les mains. Laissez la respiration naturelle. Un peu de confort suffit; ne forcez pas votre corps à se relâcher entièrement. Si l’attention portée au corps accroît l’inconfort, tournez-vous vers un repère extérieur."),
        MiniArticle(ArticleIds.BasicCareWithoutRules, "Prendre soin de soi sans règles strictes", "Choisissez ce qui manque maintenant", "Choisissez un besoin pour l’heure qui vient et réduisez-le à un petit geste : un verre d’eau, une collation, un vêtement chaud ou un message. S’il est inaccessible, nommez l’obstacle et demandez une aide précise. Ne pas tout gérer seul n’est pas un échec personnel."),
        new(
            ArticleIds.NewSymptomsCare,
            "Symptômes nouveaux ou inhabituels",
            "Ne posez pas un diagnostic à partir d’un article",
            "TipsAndUpdates",
            2,
            [
                H("Évaluez d’abord l’urgence"),
                P("Un nouveau symptôme physique peut avoir de nombreuses causes ; un article ne peut pas déterminer la vôtre de façon fiable. S’il est intense, s’aggrave rapidement ou vous semble dangereux, ne retardez pas les soins pour faire un exercice ou chercher une explication en ligne. En cas de danger immédiat ou d’aggravation grave et soudaine, contactez les services d’urgence locaux."),
                H("Notez vos observations si vous le pouvez"),
                P("Une courte note peut aider lors d’un échange avec un professionnel : quand le symptôme a commencé, ce qui a changé, sa fréquence et ce que vous avez remarqué d’autre. Mentionnez les médicaments et les changements récents s’ils sont concernés. Vous n’avez pas à chercher vous-même un diagnostic ni à tenir un relevé détaillé si cela vous coûte trop."),
                H("Décrivez les effets sur votre quotidien"),
                P("Remarquez si le symptôme gêne le sommeil, les mouvements, l’alimentation, le travail ou les activités habituelles. Dites ce qui vous inquiète le plus et ce que vous craignez. Vous pouvez préparer des questions ou demander à une personne de confiance de vous accompagner."),
                H("L’auto-aide ne remplace pas une évaluation médicale"),
                P("Une activité apaisante peut vous soutenir pendant que vous organisez les soins, si elle vous convient, mais elle ne détermine pas la cause du symptôme. En cas d’aggravation soudaine, de douleur intense, de difficulté à respirer, de perte de connaissance ou d’un autre signe urgent, suivez les consignes locales et demandez de l’aide rapidement. En cas de doute sur l’urgence, contactez un service médical et décrivez la situation."),
            ]),
        new(
            ArticleIds.FindTherapist,
            "Choisir un professionnel pour un premier rendez-vous",
            "Cherchez un cadre de travail clair et sûr",
            "TipsAndUpdates",
            2,
            [
                P("La recherche peut être difficile : les profils se ressemblent et vous ne pouvez pas savoir à l’avance si la confiance s’installera. Vous n’avez pas à trouver la personne parfaite du premier coup. Vérifiez d’abord des éléments pratiques : formation et habilitation adaptées, expérience de votre sujet, format, coût et disponibilité. Si votre question concerne la santé physique ou les médicaments, demandez quel professionnel de santé peut l’évaluer."),
                H("Posez des questions pratiques"),
                P("Avant de prendre rendez-vous ou lors de la première rencontre, demandez comment le travail se déroule, comment les objectifs sont définis et comment signaler qu’un format ne vous aide pas. Précisez le coût, les annulations, les échanges entre séances et le fonctionnement de la confidentialité, y compris ses limites. Vous n’avez pas à raconter des détails personnels au téléphone pour connaître les conditions."),
                H("Évaluez la relation de travail avec le temps"),
                P("Après le rendez-vous, demandez-vous si le déroulement était clair, si vous avez pu poser des questions et si vos limites ont été respectées. Une gêne au premier échange ne prouve pas à elle seule que le professionnel ne vous convient pas; la clarté et la sécurité comptent aussi. Si la relation ne s’améliore pas, vous pouvez en parler ou chercher quelqu’un d’autre. En cas de danger immédiat, n’attendez pas un rendez-vous ordinaire : demandez une aide urgente.")
            ]),
        new(
            ArticleIds.FirstAppointment,
            "Un exemple suffit pour le premier rendez-vous",
            "Vous n’avez pas à raconter toute votre histoire parfaitement",
            "TipsAndUpdates",
            2,
            [
                P("Avant un premier rendez-vous, on peut essayer de préparer toute son histoire et de trouver les mots exacts. Ce n’est pas nécessaire. Si cela vous aide, notez une situation récente qui montre ce qui vous préoccupe et ce que vous aimeriez voir changer. Vous pouvez apporter la note, la lire ou demander au professionnel de poser une question à la fois."),
                H("Apportez les questions qui comptent pour vous"),
                P("Vous pouvez demander comment se passent les séances, ce qui est confidentiel et dans quels cas des informations peuvent être partagées, comment les objectifs sont définis et quoi faire si votre état s’aggrave entre deux rendez-vous. Vous pouvez aussi demander le coût, la durée et les règles d’annulation. Il n’est pas nécessaire de tout demander d’un coup."),
                H("Gardez la possibilité de faire une pause"),
                P("Vous pouvez dire que vous n’êtes pas prêt à parler d’un sujet, demander qu’une question soit expliquée ou faire une pause. Le premier rendez-vous sert à découvrir le cadre, ce n’est pas une épreuve de récit. Ensuite, demandez-vous si vous vous êtes senti suffisamment en sécurité et si le fonctionnement était clair. Vous pourrez décider plus tard de poursuivre ou non.")
            ]),
        new(
            ArticleIds.DescribeSymptoms,
            "Décrivez ce qui se passe avec des exemples concrets",
            "Le début, la répétition et l’impact au quotidien sont utiles",
            "TipsAndUpdates",
            2,
            [
                P("Vous n’avez pas besoin de termes spécialisés ni d’une explication toute prête pour parler d’une expérience difficile. Commencez par un exemple récent : ce qui se passait, ce que vous avez remarqué et ce qui est devenu plus difficile. Vous pouvez dire « je ne sais pas » ou « je n’arrive pas encore à mieux le décrire ». Le but est de comprendre ensemble, pas de deviner un diagnostic à l’avance."),
                H("Rassemblez quelques repères utiles"),
                P("Si vous vous en souvenez, notez quand cela a commencé, à quelle fréquence cela arrive, combien de temps cela dure et dans quelles circonstances cela change. Décrivez les effets sur le sommeil, les études, le travail, les relations ou les soins personnels. Ajoutez ce que vous avez essayé et ce qui a un peu aidé ou empiré les choses. Un journal détaillé n’est pas nécessaire s’il vous fatigue."),
                H("Préparez des questions et les informations utiles"),
                P("Vous pouvez noter les médicaments, changements de santé ou autres éléments qui vous semblent liés; en cas de doute, demandez au professionnel ce qui est utile. Ne modifiez pas un traitement à partir d’un article ou d’un questionnaire. Des symptômes physiques nouveaux ou intenses justifient une évaluation médicale; face à un danger immédiat, demandez une aide urgente.")
            ]),
        new(
            ArticleIds.SelfHelpLimits,
            "Quand l’auto-aide ne suffit pas",
            "Le soutien professionnel est une prochaine étape valable",
            "TipsAndUpdates",
            2,
            [
                H("Repérez ce qui dure"),
                P("L’auto-aide peut soutenir face aux difficultés du quotidien, sans devoir tout résoudre. Un soutien professionnel peut être utile si la situation perturbe durablement le sommeil, le travail, les études, les relations ou les soins personnels, si elle s’aggrave ou si vous renoncez de plus en plus à des activités importantes. Inutile d’attendre que cela devienne insupportable."),
                H("Pas besoin d’avoir déjà un diagnostic"),
                P("Il suffit de décrire ce qui a changé et depuis quand. Selon les possibilités autour de vous, vous pouvez commencer par un médecin généraliste, un psychologue ou un autre professionnel qualifié. Si vous ne savez pas vers qui vous tourner, demandez à un service de santé de vous indiquer une première étape."),
                H("Préparez un résumé bref"),
                P("Avant l’échange, notez quelques éléments : ce qui vous préoccupe le plus, quand cela a commencé, les effets sur votre quotidien et ce que vous avez déjà essayé. Ajoutez vos questions sur les aides possibles. Vous n’avez pas à tout raconter d’un coup ; vous pouvez demander qu’on explique les termes et convenir d’une prochaine étape."),
                H("Demander de l’aide est déjà une action"),
                P("Vous n’avez pas à prouver que vous avez suffisamment essayé seul. Si prendre rendez-vous ou commencer la discussion est difficile, demandez à un proche de chercher un contact ou de rester avec vous. En cas de danger immédiat pour vous ou quelqu’un d’autre, contactez les services d’urgence locaux."),
            ]),

        new(
            ArticleIds.ScreeningNotDiagnosis,
            "Un questionnaire n’est pas un diagnostic",
            "Un résultat peut ouvrir une discussion, pas vous étiqueter",
            "TipsAndUpdates",
            2,
            [
                H("Ce qu’un résultat peut indiquer"),
                P("Un questionnaire rassemble des réponses sur une période définie et à partir de questions précises. Le score peut suggérer des sujets à aborder, mais ne suffit pas à expliquer la cause de votre état. Les événements récents, la santé, le sommeil et la compréhension des formulations peuvent influencer les réponses."),
                H("Ce qu’un score ne permet pas d’établir"),
                P("Un résultat ne confirme ni n’exclut un diagnostic et ne remplace pas un échange avec un professionnel. Les seuils ou couleurs appartiennent à l’outil concerné ; ils ne constituent pas un jugement définitif sur vous. Un score élevé ne dit pas ce qui « ne va pas » chez vous, et un score faible n’annule pas les difficultés qui affectent votre vie."),
                H("En faire une note pour en parler"),
                P("Si le résultat vous inquiète, conservez-le avec sa date et pensez à ce qui se passait à ce moment-là. Notez les questions qui vous ont particulièrement parlé et ce que vous voudriez demander à un professionnel. Inutile de refaire le questionnaire à répétition pour obtenir un chiffre souhaité."),
                H("Ne modifiez pas les soins d’après un seul score"),
                P("Ne commencez, n’arrêtez ni ne modifiez un traitement sur la seule base d’un score de l’application. Parlez-en avec un professionnel qualifié qui pourra considérer vos réponses dans leur contexte. Si votre état s’aggrave brusquement ou s’il existe un danger immédiat, n’attendez pas de repasser le questionnaire : demandez une aide urgente."),
            ]),
        MiniArticle(ArticleIds.SupportPlan, "Préparez un petit plan de soutien", "Notez les signes, les étapes et les contacts", "Notez comment vous voyez que cela devient difficile, ce qui aide habituellement et à qui en parler. Ajoutez les contacts professionnels et les urgences locales. Le plan ne remplace pas l’aide; il indique qui joindre quand penser devient difficile. Vérifiez à l’avance que les contacts sont joignables dans votre région."),
        MiniArticle(ArticleIds.CrisisSteps, "Si vous n’êtes pas en sécurité maintenant", "Contactez une aide en direct", "Allez dans un lieu plus sûr si possible et contactez les services d’urgence locaux ou une personne de confiance. Dites brièvement ce qui se passe et où vous êtes. Ne restez pas seul en cas de danger immédiat. Si appeler est difficile, demandez à quelqu’un de rester avec vous."),
        MiniArticle(ArticleIds.MedicationWithClinician, "Parlez des médicaments avec un professionnel", "Ne changez pas seul une prescription", "En cas de doute, notez le nom du médicament, votre question et tout effet indésirable, puis parlez-en au prescripteur ou au pharmacien. Ne commencez, n’arrêtez et ne modifiez pas une dose sur la foi d’un article ou d’une application. Consultez la notice ou demandez à un pharmacien ; les consignes varient."),
        new(
            ArticleIds.DeadlineConversation,
            "Si vous risquez de manquer le délai, prévenez tôt",
            "Donnez les faits, une estimation réaliste et des options",
            "TipsAndUpdates",
            2,
            [
                P("Quand un délai est menacé, l’inquiétude peut pousser à se taire jusqu’au dernier moment ou à promettre l’impossible. Une courte mise à jour est plus utile tant qu’il reste des choix. Avant de prévenir, vérifiez ce qui est terminé, ce qu’il reste et ce qui dépend de vous ou de facteurs extérieurs. Vous n’avez pas à cacher le retard ni à vous justifier par un long récit."),
                H("Proposez des options réalisables"),
                P("Indiquez les faits et une estimation réaliste : « Le brouillon est prêt; la relecture prendra deux jours de plus. » Proposez de décaler l’échéance, de réduire le périmètre, d’envoyer une partie terminée ou de faire un point intermédiaire. Si l’estimation reste incertaine, précisez-le et indiquez quand vous pourrez la confirmer."),
                H("Confirmez l’accord"),
                P("Vérifiez l’option retenue, les personnes à informer et la date du prochain point. Ne promettez pas un délai qui exige de sacrifier le sommeil ou d’autres besoins essentiels. Si les retards se répètent, examinez séparément la cause : volume, ressources ou priorités peu claires. Cela permet d’ajuster le travail sans vous accuser.")
            ]),
        new(
            ArticleIds.DifficultMessageReply,
            "Faites une pause avant de répondre à un message difficile",
            "Décidez d’abord du but de votre réponse",
            "TipsAndUpdates",
            2,
            [
                P("Un message abrupt ou ambigu peut donner envie de répondre tout de suite. S’il n’y a pas d’urgence pratique, prenez le temps. Distinguez les mots exacts de l’intention que vous leur prêtez : un texte peut sembler froid sans expliquer à lui seul pourquoi. Attendez de savoir ce que vous voulez obtenir avant d’écrire."),
                H("Choisissez un objectif et un format"),
                P("Vous pouvez vouloir clarifier un fait, poser une limite, communiquer une décision ou reporter la conversation. Rédigez un brouillon puis retirez ce qui ne ferait qu’envenimer l’échange. Par exemple : « J’ai vu ton message. Je répondrai à la question demain » ou « Je veux bien en parler sans insultes ». Pour un sujet complexe, un appel ou une rencontre peut être préférable aux messages, si c’est sûr."),
                H("Protégez-vous et gardez les éléments utiles"),
                P("Si le message contient des menaces, du harcèlement ou de la contrainte, vous n’êtes pas obligé de répondre ni de maintenir le contact. Conservez les éléments utiles, utilisez les fonctions de blocage ou de signalement et demandez du soutien. En cas de menace immédiate, mettez-vous à l’abri et contactez les secours ou une personne de confiance.")
            ]),
        new(
            ArticleIds.CancelPlans,
            "Annulez un rendez-vous clairement et avec tact",
            "Prévenez tôt et ne partagez que ce que vous souhaitez",
            "TipsAndUpdates",
            2,
            [
                P("Il faut parfois changer ses plans pour des raisons de santé, de circonstances ou d’énergie. Prévenez l’autre personne dès que possible, surtout si elle compte déjà sur cette rencontre. Une phrase claire suffit : « Je dois annuler aujourd’hui. » Vous pouvez garder la raison privée; un message bref n’est pas impoli parce qu’il n’est pas accompagné d’une longue justification."),
                H("Proposez une autre date si vous le souhaitez vraiment"),
                P("Si vous souhaitez vraiment vous voir plus tard, proposez un jour précis ou demandez ce qui convient. Ne promettez pas une nouvelle date par culpabilité si vous ne savez pas si vous pourrez la tenir. Reconnaissez une contrainte pratique, par exemple : « Je sais que tu avais réservé ta soirée. » L’autre personne peut être déçue ou refuser de reporter."),
                H("Faites passer la sécurité et le bien-être d’abord"),
                P("Si vous annulez parce qu’une situation ne vous semble pas sûre, vous n’avez pas à maintenir le rendez-vous par commodité pour l’autre. Choisissez un moyen d’avertir qui n’augmente pas le risque; un message court ou l’aide d’une personne de confiance peut être plus sûr. Si vous annulez souvent et que cela vous préoccupe, réfléchissez sans vous blâmer à ce qui complique les plans.")
            ]),
    ];
}
