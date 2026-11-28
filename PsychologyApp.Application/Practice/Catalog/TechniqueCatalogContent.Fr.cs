using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice.Catalog;

internal static class TechniqueCatalogContentFr
{
    internal static TheorySection[] Theory(string what, string when, string how, string example) =>
    [
        new("Ce que c'est", what),
        new("Quand l’essayer", when),
        new("Comment se déroule la pratique", how),
        new("Exemple", example)
    ];

    /// <summary>Common topics for a "problem" field: a start to tap and then add a word or two, not a full answer.</summary>
    private static readonly string[] ProblemTopics =
        ["Une dispute avec un proche", "Quelque chose au travail", "Un conflit avec mon chef", "Les études ou un examen", "La santé", "L'argent", "La solitude", "Un échec", "Une rupture", "La relation avec mes parents", "Les enfants", "Un déménagement", "L'avenir", "Les critiques à mon égard"];

    private static readonly string[] BackupOptions =
        ["Demander de l'aide", "Attendre et réessayer", "Trouver un autre moyen", "Être moins exigeant·e envers moi", "Faire une pause", "En parler à un proche", "Consulter un spécialiste", "Trouver un travail d'appoint", "Suivre une formation", "Découper la tâche en étapes", "Reporter la décision", "Commencer petit"];

    private static readonly string[] HarshThoughts =
        ["« Je vais tout gâcher »", "« On va me juger »", "« Je n'y arrive pas »", "« Personne n'a besoin de moi »", "« C'est une catastrophe »", "« Rien ne va marcher »", "« Je suis moins bien que les autres »", "« Tout va toujours de travers »", "« C'est de ma faute »", "« Quelque chose ne va pas chez moi »", "« Ça ne finira jamais »", "« Je dois être parfait·e »"];

    internal static readonly BuiltInTechniqueDefinition Spin = new(
        "Pratique", "Nommer ce que je ressens",
        [
            "1. Choisissez une situation récente du quotidien, légèrement désagréable",
            "2. Nommez l’émotion principale",
            "3. Évaluez son intensité maintenant, de 0 à 10"
        ],
        "Notez brièvement la situation et l’émotion, sans attendre un soulagement immédiat.",
        TechniqueUiKind.Entry, "Technique n° 1", "26.01.2023", "Nommer ce que je ressens", "Repérer ce qui se passe maintenant", "Moment difficile", "Équipe PsychologyApp", 5, "Autorenew",
        [
            new TechniqueEntrySeed("Situation", "Par exemple : un petit incident au travail. Évitez les détails éprouvants.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Émotion principale", "Peine, inquiétude, colère…", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("Intensité maintenant", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Vous notez la situation, l’émotion et son intensité actuelle. C’est une observation de soi, pas un traitement ni la promesse que l’émotion changera immédiatement.",
            "Pour une situation quotidienne modérément désagréable, si écrire à son sujet vous convient. Ne choisissez pas un souvenir traumatique ni une crise aiguë.",
            "Décrivez seulement le nécessaire et évaluez l’émotion maintenant. Si la détresse augmente, arrêtez, regardez autour de vous et choisissez une pratique plus neutre. Il n’est pas nécessaire de recommencer.",
            "Situation : un collègue m’a interrompu·e. Émotion : irritation. Intensité actuelle : 5 sur 10."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Comparison = new(
        "Pratique", "Voir le contexte plus large",
        [
            "1. Nommez ce qui est difficile sans le minimiser",
            "2. Quels domaines de votre vie sont concernés ?",
            "3. Qu'est-ce qui compte aussi ou demande de l'attention ?",
            "4. De qui ou de quoi aimeriez-vous prendre soin aujourd'hui ?",
            "5. Notez vos observations sans juger le problème petit ou grand"
        ],
        "Cet exercice permet de nommer différents domaines de vie ; il ne détermine pas la gravité d'un problème.",
        TechniqueUiKind.Entry, "Technique n° 2", "26.01.2023", "Voir le contexte plus large", "Quand une difficulté prend toute votre attention", "Ampleur du problème", string.Empty, 7, "CompareArrows",
        [
            new TechniqueEntrySeed("Ce qui se passe", "Qu'est-ce qui est difficile en ce moment ?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Domaines concernés", "Par ex. travail, santé, relations", Suggestions: ["Le travail", "La famille", "Les amis", "La santé", "Les études", "L'argent", "Les relations", "Le sommeil", "Le foyer", "Les loisirs", "Le repos", "Les projets"]),
            new TechniqueEntrySeed("Ce qui compte aussi", "Qu'est-ce qui demande également de l'attention ?", Suggestions: ["Le travail", "La famille", "La santé", "Les relations", "Le repos", "Les enfants", "Les amis", "Les études", "Le sommeil", "La tranquillité d'esprit", "Le développement personnel", "Le quotidien"]),
            new TechniqueEntrySeed("Prendre soin de", "Qui ou quoi a besoin de votre attention aujourd'hui ?", Suggestions: ["La santé", "Mes proches", "Le sommeil", "Le repos", "Un sujet professionnel", "Une conversation", "Une tâche quotidienne", "Mes limites", "Je ne sais pas encore"]),
            new TechniqueEntrySeed("Ce que vous remarquez", "Aucune conclusion positive n'est nécessaire")
        ],
        Theory(
            "L'exercice aide à nommer d'autres besoins et tâches sans minimiser la difficulté elle-même.",
            "Quand un sujet occupe presque toute votre attention et que vous souhaitez reconnaître d'autres besoins ou tâches.",
            "Écrivez avec vos propres mots, sans chercher un dénouement positif obligatoire. Si une action pratique ou une question de sécurité demande une réponse, traitez-la d'abord. Vous pouvez laisser des champs vides.",
            "La recherche d'emploi affecte l'argent et le sommeil ; aujourd'hui, un proche a aussi besoin d'attention. Vous pourriez choisir une démarche et demander du soutien. Cela ne rend pas la difficulté moins sérieuse."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Polarity = new(
        "Pratique", "Polarités",
        [
            "1. Écrivez ce qui vous plaît dans la situation",
            "2. Écrivez ce qui vous déplaît",
            "3. Comparez les paires et remarquez l'équilibre"
        ],
        "La méthode des polarités aide à voir les deux côtés et à réduire la tension intérieure.",
        TechniqueUiKind.Polarity, "Technique n° 3", "26.01.2023", "Polarités", "Voir les deux côtés d'une situation", "Différents côtés", "Zivorad Slavinski", 5, "Contrast",
        null,
        Theory(
            "Toute situation a des côtés attirants et désagréables. Les nommer tous les deux réduit la fixation sur un seul.",
            "Quand vous ne voyez que le négatif ou que le positif et vous sentez bloqué·e.",
            "Ajoutez des paires « me plaît / me déplaît » sur un thème. Comparez les listes sans juger qui a raison.",
            "Travail : le salaire me plaît, les horaires me déplaisent. Maison : le confort me plaît, le bruit des voisins me déplaît."),
        "Ce qui vous déplaît", "Ce qui vous plaît");

    internal static readonly BuiltInTechniqueDefinition Paper = new(
        "Pratique", "Une pensée sur papier",
        [
            "1. Écrivez une pensée ci-dessous ou sur une feuille",
            "2. Lisez-la une fois et nommez l’émotion, si vous le souhaitez",
            "3. Choisissez quoi faire de la feuille : la garder, la plier ou la déchirer. Vous pouvez aussi ne rien faire"
        ],
        "L’écriture permet de remarquer la formulation d’une pensée ; il n’est pas nécessaire de détruire la feuille ni d’attendre un soulagement.",
        TechniqueUiKind.Paper, "Technique n° 4", "26.01.2023", "Une pensée sur papier", "Quand une pensée revient souvent", "Pensées", "Équipe PsychologyApp", 3, "Description",
        [new TechniqueEntrySeed("Pensée", "Par exemple : « Je vais rater la présentation. »", Suggestions: HarshThoughts)],
        Theory(
            "Vous écrivez une pensée pour en observer la formulation. C’est une observation de soi, pas un traitement ni une garantie que l’émotion changera.",
            "Quand une pensée revient et que l’écriture vous convient. Arrêtez si cela vous met plus mal à l’aise.",
            "Écrivez une phrase et lisez-la une fois. Garder, ranger ou déchirer la feuille est votre choix. Vous n’avez pas à vous forcer à vous calmer.",
            "Pensée : « Je vais rater la présentation. » Vous pouvez garder la note et vérifier une diapositive."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Future = new(
        "Pratique", "Prendre du recul dans le temps",
        [
            "1. Choisissez une difficulté quotidienne que vous pouvez gérer",
            "2. Imaginez que vous la regardez depuis une date de votre choix — dans un an ou cinq ans, par exemple"
        ],
        "Évaluez la situation avec une distance dans le temps. Elle peut rester importante ; vous n’avez pas à la minimiser.",
        TechniqueUiKind.Entry, "Technique n° 5", "30.01.2023", "Prendre du recul dans le temps", "Changer de perspective sans minimiser", "Ampleur du problème", "Équipe PsychologyApp", 2, "Schedule",
        [
            new TechniqueEntrySeed("Situation", "Par exemple : une difficulté professionnelle gérable.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Quelle importance depuis cette distance ?", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "La perspective temporelle est une façon imaginée de regarder une situation. Son importance peut rester la même, et c’est acceptable.",
            "Pour une difficulté quotidienne gérable. Ne choisissez pas un souvenir traumatique ni un problème urgent qui demande une action.",
            "Choisissez une échéance, par exemple dans un an ou cinq ans. Imaginez regarder la situation depuis ce moment et donnez une note. Il n’y a pas de bonne réponse ; arrêtez si l’exercice ne vous convient pas.",
            "Une invitation manquée peut encore compter dans un an. Aujourd’hui, vous pouvez demander des précisions ou choisir une autre étape."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Hack = new(
        "Pratique", "Pause avec les détails autour",
        [
            "1. Choisissez un objet neutre près de vous, sans revenir à un souvenir éprouvant",
            "2. Nommez trois détails : sa couleur, sa forme et sa surface",
            "3. Décidez si vous souhaitez continuer ou vous arrêter"
        ],
        "Un bref exercice d’orientation vers un objet proche, sans revivre un événement douloureux.",
        TechniqueUiKind.Entry, "Technique n° 6", "30.01.2023", "Pause avec les détails autour", "Ramener l’attention vers l’environnement", "Moment difficile", "Équipe PsychologyApp", 3, "BlurOn",
        [new TechniqueEntrySeed("Objet à proximité", "Par exemple : une tasse, une fenêtre ou un livre.", Role: EntryFieldRole.None)],
        Theory(
            "Portez votre attention sur un objet neutre, ici et maintenant. C’est un bref exercice d’orientation, pas un traitement ni un remplacement d’un accompagnement professionnel.",
            "Quand vous souhaitez vous concentrer un instant sur votre environnement. Ne l’utilisez pas à la place d’une aide urgente.",
            "Nommez trois détails de l’objet. Si vous vous sentez plus mal ou mal à l’aise, arrêtez, regardez autour de vous et choisissez une autre action.",
            "Par exemple : une tasse — blanche, ronde, fraîche au toucher."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Experience = new(
        "Pratique", "Modification de l'expérience",
        [
            "1. Choisissez un domaine à travailler",
            "2. Décrivez votre attitude à son égard",
            "3. Nommez les croyances associées",
            "4. Comment l'attitude change-t-elle quand vous pensez à une expérience passée ?",
            "5. Décrivez une expérience négative",
            "6. Évaluez l'expérience négative (−10…10)",
            "7. Quelle expérience positive pourrait la remplacer ?",
            "8. Comment votre attitude changerait-elle avec cette expérience ?",
            "9. Évaluez la nouvelle expérience (−10…10)"
        ],
        "L'EMO aide à remplacer une expérience limitante par une expérience plus soutenante.",
        TechniqueUiKind.Entry, "Technique n° 7", "08.02.2023", "Modification de l'expérience", "Réécrire une expérience limitante", "Moment difficile", "Filip Slavinski", 15, "Psychology",
        [
            new TechniqueEntrySeed("Domaine", "Relations, travail, santé…", Suggestions: ["Les relations", "Le travail", "La santé", "L'argent", "Parler en public", "La famille", "Les études", "L'apparence", "L'amitié", "La créativité", "Le sport", "La carrière"]),
            new TechniqueEntrySeed("Attitude envers ce domaine", "Qu'en ressentez-vous maintenant ?", Suggestions: ["Anxiété", "Doute de soi", "Irritation", "Indifférence", "Intérêt", "Fatigue", "Peur", "Honte", "Espoir", "Colère", "Confusion", "Le calme"]),
            new TechniqueEntrySeed("Croyances associées", "Par ex. « Je n'y arriverai pas »", Suggestions: ["« Je n'y arriverai pas »", "« Je ne suis pas assez bien »", "« On ne m'acceptera pas »", "« Rien ne changera »", "« Je dois être parfait·e »", "« Je n'ai pas de chance »", "« Je ne le mérite pas »", "« Les autres sont meilleurs »", "« L'erreur est interdite »", "« Je suis trop vieux·vieille pour ça »"]),
            new TechniqueEntrySeed("Attitude et expérience passée", "Qu'est-ce qui change quand vous repensez au passé ?", Suggestions: ["C'est plus lourd", "C'est plus calme", "Rien ne change", "La colère monte", "La tristesse monte", "La peur monte", "Je me souviens que j'ai fait face", "J'ai envie de l'éviter"]),
            new TechniqueEntrySeed("Expérience négative", "Un épisode précis ou un schéma"),
            new TechniqueEntrySeed("Note de l'expérience négative", "", EntryFieldKind.RatingNeg10To10),
            new TechniqueEntrySeed("Remplacement positif", "Quelle expérience soutenante est possible ?", Suggestions: ["Une fois où j'ai réussi", "Une fois où on m'a soutenu·e", "Une fois où je m'en suis sorti·e seul·e", "Une fois où on m'a félicité·e", "Une fois où j'ai aidé quelqu'un", "Une fois où j'ai appris quelque chose de nouveau", "Une fois où je n'ai pas abandonné", "Une fois où on m'a accepté·e tel·le que je suis"]),
            new TechniqueEntrySeed("Attitude avec le positif", "Comment votre regard sur ce domaine changerait-il ?", Suggestions: ["L'espoir apparaît", "Plus de calme", "J'ai envie de réessayer", "Ça devient intéressant", "La confiance apparaît", "C'est plus léger", "Je sens de la force", "Encore difficile à croire"]),
            new TechniqueEntrySeed("Note de la nouvelle expérience", "", EntryFieldKind.RatingNeg10To10)
        ],
        Theory(
            "Les croyances reposent souvent sur une seule expérience négative marquante. Un remplacement conscient peut faire évoluer votre attitude.",
            "Quand « ça a toujours été comme ça » et que le changement semble impossible.",
            "Remplissez les champs dans l'ordre. Comparez les deux notes — visez une seconde note plus haute.",
            "Domaine : parler en public. Négatif : examen raté (−8). Remplacement : une intervention réussie (+6)."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Copied = new(
        "Pratique", "Observer la pensée",
        [
            "1. Écrivez une courte phrase qui revient souvent",
            "2. Lisez-la une fois et demandez-vous : fait, prévision ou jugement ?",
            "3. Si cela vous convient, vérifiez un fait. Arrêtez si la détresse augmente"
        ],
        "Cet exercice aide à observer la formulation d'une pensée ; la répétition ne garantit pas une baisse de l'anxiété.",
        TechniqueUiKind.Copied, "Technique n° 8", "21.01.2025", "Observer la pensée", "Nommer une phrase anxieuse sans se disputer avec soi-même", "Ampleur du problème", string.Empty, 2, "Repeat",
        [new TechniqueEntrySeed("Formulation", "J'ai peur de perdre mon travail", Suggestions: HarshThoughts)],
        Theory(
            "C'est une façon brève d'observer les mots d'une pensée et de vérifier sur quoi elle repose. Inutile de la dire à voix haute ou de la répéter.",
            "Quand une phrase revient souvent et que vous souhaitez la regarder un instant. Évitez l'exercice si cette pensée est trop pénible maintenant.",
            "Écrivez la pensée en quelques mots. Demandez-vous ce que vous savez avec certitude et ce qui est une prévision. Ne vous forcez pas à croire une réponse. Arrêtez si la détresse augmente.",
            "Pensée : « Je vais forcément échouer à la réunion. » Fait : « J'ai une réunion demain. » La suite est encore inconnue."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Extend = new(
        "Pratique", "Préparer un plan face à l'incertitude",
        [
            "1. Nommez la situation pour laquelle vous cherchez une autre option",
            "2. Notez une possibilité réaliste et les ressources disponibles",
            "3. Choisissez une prochaine étape ou un moment pour y revenir"
        ],
        "Un plan peut clarifier les actions possibles ; il ne garantit ni le résultat ni un soulagement immédiat.",
        TechniqueUiKind.Entry, "Technique n° 9", "21.01.2025", "Préparer un plan face à l'incertitude", "Trouver une prochaine étape concrète", "Ampleur du problème", string.Empty, 3, "Backup",
        [
            new TechniqueEntrySeed("Situation", "Qu'est-ce qui pourrait ne pas se passer comme prévu ?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Option pratique", "Par ex. vérifier un délai ou demander de l'aide", Suggestions: BackupOptions),
            new TechniqueEntrySeed("Ressource ou soutien", "À qui ou à quoi pourriez-vous faire appel ?", Suggestions: BackupOptions),
            new TechniqueEntrySeed("Prochaine étape", "Que pouvez-vous faire maintenant ou quand y revenir ?", Suggestions: BackupOptions)
        ],
        Theory(
            "Planifier peut clarifier les actions possibles, sans contrôler les décisions d'autrui ni garantir le calme.",
            "Quand une incertitude pratique précise vous amène à envisager une option réalisable.",
            "Séparez les faits connus des inquiétudes. Choisissez une étape réaliste, une ressource ou un moment pour reprendre la réflexion. Si vous recommencez à vérifier tous les scénarios et que la détresse augmente, arrêtez-vous.",
            "Sans réponse après un entretien, vous pouvez choisir un moment raisonnable pour relancer et vous consacrer à d'autres tâches d'ici là. Cela ne prédit pas la décision de l'employeur."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Resize = new(
        "Pratique", "Observer l'image à distance",
        [
            "1. Nommez brièvement une situation ordinaire ; aucun souvenir pénible n'est nécessaire",
            "2. Si cela vous convient, imaginez-la comme une image immobile",
            "3. Vous pouvez en modifier la taille ou la distance, sans forcer le changement"
        ],
        "Une visualisation facultative pour observer son attention ; elle ne change pas la situation et ne promet pas de soulagement.",
        TechniqueUiKind.Entry, "Technique n° 10", "22.01.2025", "Observer l'image à distance", "Essayer de prendre du recul seulement si cela vous convient", "Ampleur du problème", string.Empty, 2, "ZoomOutMap",
        [new TechniqueEntrySeed("Ce qui vous préoccupe", "Par ex. un conflit qui vous empêche de dormir", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem)],
        Theory(
            "C'est un bref exercice d'imagination : vous pouvez observer une image à distance. Les réactions varient d'une personne à l'autre ; la situation elle-même ne change pas.",
            "Uniquement pour une préoccupation quotidienne gérable. Ne choisissez pas un souvenir pénible ; vous pouvez passer l'exercice.",
            "Imaginez la situation sans ajouter de détails. Modifiez la taille ou la distance seulement si cela vous convient. Si la détresse augmente, arrêtez et observez la pièce autour de vous.",
            "Vous pouvez imaginer une tâche sous forme de note posée sur une table et décider quand y revenir. L'image n'a pas besoin de devenir plus petite ou plus calme."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Check = new(
        "Pratique", "Déplacer l'attention",
        [
            "1. Nommez la pensée récurrente en quelques mots, sans détails",
            "2. Remarquez : « J'ai la pensée que… »",
            "3. Si vous le souhaitez, portez votre attention sur un son ou un objet neutre ; la pensée peut rester"
        ],
        "Cet exercice aide à choisir où porter son attention ; il n'exige pas que les pensées disparaissent.",
        TechniqueUiKind.Entry, "Technique n° 11", "22.01.2025", "Déplacer l'attention", "Observer la pensée et choisir un point d'attention neutre", "Ampleur du problème", string.Empty, 2, "FactCheck",
        [new TechniqueEntrySeed("Ce sur quoi vous tournez en boucle", "Quelle pensée revient sans cesse ?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem)],
        Theory(
            "C'est une façon brève de remarquer une pensée récurrente et de donner une autre tâche à l'attention. Inutile de la supprimer ou de chercher à se calmer.",
            "Quand vous repassez un sujet en boucle et que vous souhaitez essayer un bref déplacement. S'il s'agit d'un danger réel, veillez d'abord à votre sécurité.",
            "Nommez la pensée en une phrase et choisissez un son ou un objet neutre autour de vous. Arrêtez si la détresse augmente. Ne remplacez pas ainsi une démarche médicale ou pratique nécessaire.",
            "Pensée : « Et si j'étais malade ? » Vous pouvez la remarquer comme une pensée et décider si une démarche concrète est nécessaire, par exemple consulter pour un symptôme."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Observer = new(
        "Pratique", "Dialogue intérieur avec recul",
        [
            "1. Nommez la situation et l’émotion en une phrase ; inutile de détailler un événement pénible.",
            "2. Adressez-vous à vous-même par votre prénom ou avec « tu », plutôt qu’uniquement avec « je ». Par exemple : « [Prénom], que se passe-t-il maintenant ? »",
            "3. Écrivez ce qui compte maintenant et une prochaine étape réaliste et sûre. Ne justifiez pas un tort et ne minimisez pas un danger.",
            "4. Évaluez votre tension maintenant. Elle peut diminuer, rester stable ou augmenter. Si vous vous sentez plus mal, arrêtez et choisissez un autre soutien."
        ],
        "Une courte adaptation du dialogue intérieur distancié : s’adresser à soi par son prénom ou avec « tu » plutôt qu’uniquement avec « je ». Cela peut laisser un peu d’espace pour réfléchir, sans promettre un soulagement immédiat.",
        TechniqueUiKind.Entry, "Technique n° 12", "12.06.2026", "Dialogue intérieur avec recul", "Adressez-vous à vous-même par votre prénom ou « tu », puis choisissez une étape sûre", "Moment difficile", "Aide personnelle", 1, "Visibility",
        [
            new TechniqueEntrySeed("Situation", "En bref : que se passe-t-il maintenant ? Il n’est pas nécessaire de raconter un événement pénible.", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Sentiments à la première personne", "Que ressentez-vous ? Une courte phrase suffit.", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("Ce que voit l'observateur", "Adressez-vous à vous-même par votre prénom ou « tu » : qu’est-ce qui compte, et quelle étape sûre est possible ?", Suggestions: ["[Prénom], qu’est-ce qui compte pour toi maintenant ?", "Quelle étape est sûre et réaliste ?", "Comment peux-tu te soutenir ?", "Que dirais-tu à un proche ?", "Tu peux répondre plus tard, quand ce sera plus clair"]),
            new TechniqueEntrySeed("Tension maintenant", "Évaluez-la à la fin ; elle peut rester identique.", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Le dialogue intérieur distancié consiste à utiliser son prénom ou « tu » plutôt que seulement « je ». Cela peut créer un peu d’espace pour réfléchir, sans garantir un soulagement immédiat.",
            "Essayez en cas de tension émotionnelle ou sociale supportable, uniquement si vous êtes en sécurité. Ne l’utilisez pas pour justifier un tort ou minimiser un danger réel.",
            "Nommez brièvement l’émotion, adressez-vous à vous-même par votre prénom ou « tu », puis demandez-vous ce qui compte maintenant et quelle étape sûre est possible.",
            "Au lieu de « Je n’y arriverai pas » : « [Prénom], c’est difficile en ce moment. Quelle est la prochaine étape sûre pour toi ? »"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Anchor = new(
        "Pratique", "Souvenir de soutien",
        [
            "1. Rappelez-vous un moment sûr où vous avez reçu du soutien ou surmonté une difficulté",
            "2. Remarquez ce qui vous a aidé et ce que vous perceviez dans votre corps",
            "3. Si vous le souhaitez, choisissez un geste uniquement comme rappel de ce souvenir",
            "4. Évaluez l’aide que ce souvenir vous apporte maintenant (0 = aucune, 10 = beaucoup) ; 0 convient aussi"
        ],
        "Un souvenir peut rappeler des sources de soutien déjà connues. La réponse varie ; un geste n’est qu’un rappel facultatif et ne change pas l’état de façon fiable.",
        TechniqueUiKind.Entry, "Technique n° 13", "12.06.2026", "Souvenir de soutien", "Se rappeler une expérience de soutien et repérer des ressources accessibles", "Moment difficile", "Souvenir de soutien", 4, "SelfImprovement",
        [
            new TechniqueEntrySeed("Souvenir ressource", "Choisissez un souvenir qui vous semble sûr ; sinon, vous pouvez passer l’exercice.", Suggestions: ["Une intervention réussie", "Des vacances à la mer", "L’étreinte d’un proche", "Avoir terminé quelque chose de difficile", "Une promenade dans la nature", "Un examen réussi", "La naissance d’un enfant", "Une victoire en compétition", "Une soirée entre amis", "Les félicitations de mon chef", "Le premier jour dans un nouveau travail", "Un matin sans se presser"]),
            new TechniqueEntrySeed("Sensations du corps", "Où le ressentez-vous ? Chaleur, légèreté, ancrage…", Suggestions: ["De la chaleur dans la poitrine", "De la légèreté", "Les épaules ouvertes", "Une respiration régulière", "Des jambes solides", "Un sourire", "Un cœur calme", "Le dos droit", "De l'énergie dans les mains", "Le ventre détendu"]),
            new TechniqueEntrySeed("Geste de rappel facultatif", "Ce geste peut rappeler le souvenir ; vous pouvez passer cette étape", Suggestions: ["Serrer le poing", "Toucher le poignet", "Joindre le pouce et l’index", "La main sur le cœur", "Une inspiration profonde", "Pincer le lobe de l’oreille", "Ouvrir les épaules", "Caresser ma paume"]),
            new TechniqueEntrySeed("Réponse au souvenir", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Il s’agit d’un bref exercice de rappel. Son effet et tout lien avec un geste ne sont pas garantis.",
            "Pour vous rappeler ce qui vous a déjà aidé. Choisissez un souvenir sûr ; arrêtez si cela devient plus difficile.",
            "Remarquez ce qui vous a aidé. Le geste est facultatif et sert seulement de rappel ; vous n’avez pas à vous forcer à vous calmer.",
            "Je me rappelle qu’un ami m’a écouté·e. En parler m’a aidé·e ; je pourrais lui écrire. Effet du souvenir : 5 sur 10."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Grounding = new(
        "Pratique", "Ancrage 5-4-3-2-1",
        [
            "1. Nommez 5 choses que vous voyez",
            "2. Nommez 4 choses que vous sentez avec votre corps",
            "3. Nommez 3 sons autour de vous",
            "4. Nommez 2 odeurs",
            "5. Nommez 1 goût ou une sensation agréable"
        ],
        "L'ancrage sensoriel déplace l'attention des pensées anxieuses vers le moment présent.",
        TechniqueUiKind.Entry, "Technique n° 14", "12.06.2026", "Ancrage 5-4-3-2-1", "Revenir au présent par les sens", "Moment difficile", "Psyché", 3, "Nature",
        [
            new TechniqueEntrySeed("5 choses que je vois", "Par ex. fenêtre, tasse, livre, lampe, main", Suggestions: ["Fenêtre", "Table", "Téléphone", "Ordinateur", "Ordinateur portable", "Écran", "Clavier", "Tasse", "Lampe", "Main", "Porte", "Livre", "Chaise", "Mur", "Tableau", "Plante", "Horloge", "Armoire", "Ciel", "Voiture"]),
            new TechniqueEntrySeed("4 choses que je sens avec mon corps", "Par ex. la chaise, le sol, les vêtements, la température de l'air", Suggestions: ["Chaise", "Le sol sous mes pieds", "Les vêtements", "La fraîcheur", "La chaleur", "Le téléphone dans ma main", "Le dossier de la chaise", "Le tissu sur ma peau", "Le souffle dans ma poitrine", "Le vent", "La souris", "Les clés", "L'oreiller", "La montre à mon poignet"]),
            new TechniqueEntrySeed("3 sons", "Par ex. la rue, l'horloge, votre respiration", Suggestions: ["La rue", "Horloge", "La respiration", "Des voix", "Le frigo", "Le vent", "Le silence", "Ordinateur", "Les voitures", "Les oiseaux", "La musique", "La climatisation", "Des pas", "La pluie"]),
            new TechniqueEntrySeed("2 odeurs", "Par ex. le café, l'air frais", Suggestions: ["Le café", "L'air frais", "Le savon", "La nourriture", "Le parfum", "Presque rien", "Le thé", "Le pain", "Les livres", "Les fleurs", "La crème pour les mains", "Le bois"]),
            new TechniqueEntrySeed("1 goût ou une sensation agréable", "Par ex. l'eau dans la bouche, un tissu doux", Suggestions: ["L'eau", "Le thé", "Un tissu doux", "Les paumes chaudes", "La bouche fraîche", "Le café", "Un chewing-gum à la menthe", "Du chocolat", "Une pomme", "Une couverture chaude"])
        ],
        Theory(
            "Portez attention à ce que vous voyez, entendez et ressentez autour de vous.",
            "Quand les inquiétudes accaparent votre attention et que vous voulez vous concentrer sur ce qui vous entoure.",
            "Commencez par ce que vous voyez. Si vous ne percevez ni odeur ni goût, passez à la suite. Respirez comme d’habitude.",
            "Je vois une tasse et une lampe. Je sens le sol sous mes pieds. J’entends la circulation dehors."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Breathing = new(
        "Pratique", "Respiration guidée en douceur",
        [
            "1. Évaluez votre tension avant de commencer",
            "2. Installez-vous confortablement. Respirez doucement, sans inspirer plus profondément que d'habitude",
            "3. Si cela vous convient, suivez le cercle : inspirez environ 4 temps et expirez environ 6. Ne retenez pas votre souffle",
            "4. Si le rythme ne vous convient pas, cessez de compter ou arrêtez. En cas de vertige ou d'essoufflement, reprenez votre respiration naturelle",
            "5. Évaluez de nouveau votre tension après. Elle peut rester la même ; c'est aussi une information utile"
        ],
        "En cas de tension, vous pouvez essayer un rythme bref et doux, sans pause respiratoire. Cela ne convient pas à tout le monde : compter ou se concentrer sur le souffle peut accentuer l'inconfort.",
        TechniqueUiKind.Entry, "Technique n° 15", "04.07.2026", "Respiration guidée en douceur", "Essayer un rythme confortable avec une expiration un peu plus longue", "Moment difficile", "Psyché", 3, "Air",
        [
            new TechniqueEntrySeed("Tension avant", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notes", "Qu'avez-vous remarqué ? Toutes les réactions sont possibles.", Suggestions: ["Le rythme était confortable", "Compter me distrayait", "Le rythme était trop lent", "J'ai eu des vertiges", "La respiration était inconfortable", "Je me suis senti·e un peu plus calme", "La tension n'a pas changé", "Je me suis senti·e plus tendu·e", "J'ai arrêté et observé ce qui m'entourait"]),
            new TechniqueEntrySeed("Tension après", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Un rythme bref et doux, avec une expiration un peu plus longue, permet d'essayer d'accompagner le souffle en cas de tension. Les réactions varient ; cette pratique ne garantit pas de soulagement.",
            "En cas de tension, si se concentrer sur le souffle vous convient.",
            "Installez-vous confortablement. Respirez doucement, sans inspirer plus profondément que d'habitude. Pendant environ une minute, vous pouvez suivre le cercle : inspirez environ 4 temps et expirez environ 6, sans pause. Si le rythme semble forcé, reprenez votre respiration naturelle. Arrêtez si l'inconfort augmente et nommez quelques objets autour de vous.",
            "La tension était de 7/10. Après une minute, elle était toujours de 7/10 ; compter me semblait forcé, alors j'ai arrêté et nommé cinq objets autour de moi."
        ),
        null, null);

    internal static readonly BuiltInTechniqueDefinition SmallStep = new(
        "Pratique", "Un petit pas",
        [
            "1. Choisissez une petite activité de soin de soi, d’intérêt, de lien social ou donnant un sentiment d’accomplissement",
            "2. Réduisez-la à un début sûr de 2–5 minutes. Vous n’avez pas à terminer toute la tâche",
            "3. Choisissez un moment précis dans les prochaines 24 heures. Si ce n’est pas le bon moment, choisissez le repos, du soutien ou une étape plus petite",
            "4. Évaluez si cela vous semble faisable : 0 — pas du tout confiant, 10 — tout à fait confiant. En cas de doute, réduisez encore"
        ],
        "Un bref plan d’activité inspiré des principes de l’activation comportementale. Un petit pas peut aider à commencer, sans garantir une meilleure humeur ou plus d’énergie.",
        TechniqueUiKind.Entry, "Technique n° 16", "04.07.2026", "Un petit pas", "Choisissez une activité et rendez le début faisable", "Moment difficile", "TCC", 5, "DirectionsWalk",
        [
            new TechniqueEntrySeed("Qu’est-ce qui rend le début difficile ?", "Fatigue, anxiété, solitude, trop de choses à faire ?", Suggestions: ["Fatigue", "Anxiété", "Solitude", "Trop de choses à faire", "Ennui", "Je ne sais pas par où commencer", "J’ai besoin de repos", "Les conditions ne sont pas réunies"], Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Une petite activité pour moi", "Prendre soin de soi, intérêt, lien social ou petite tâche", Suggestions: ["Boire de l’eau ou manger un peu", "Me laver ou m’habiller", "Prendre l’air deux minutes", "Écouter une chanson que j’aime", "Envoyer un message à un proche", "Consacrer deux minutes à quelque chose d’important", "Ranger un objet", "Demander à quelqu’un de rester avec moi"]),
            new TechniqueEntrySeed("Quand allez-vous essayer ?", "Un moment précis dans les prochaines 24 heures", Suggestions: ["Maintenant, deux minutes", "Après le petit-déjeuner", "Après le déjeuner", "Après le travail ou les études", "À l’heure que je choisis aujourd’hui", "Demander à un proche de me le rappeler"]),
            new TechniqueEntrySeed("Cela semble-t-il faisable ?", "0 — pas du tout confiant, 10 — tout à fait confiant", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Un moral bas ou peu d’énergie peuvent rendre le début difficile. Une petite activité planifiée peut aider à se remettre en mouvement ; l’effet varie selon les personnes.",
            "Quand le moral ou l’énergie compliquent le démarrage et qu’une activité sûre et faisable est possible. Se reposer ou demander de l’aide peut aussi être un bon pas.",
            "Choisissez une activité de soin de soi, d’intérêt, de lien social ou donnant un sentiment d’accomplissement ; réduisez le début à 2–5 minutes et prévoyez-le dans les prochaines 24 heures. Prévoir ne signifie pas avoir déjà fait. Si cela ne semble pas faisable, réduisez l’étape ou demandez du soutien.",
            "Au lieu de « ranger tout l’appartement », lavez une tasse après le déjeuner — ou écrivez à un proche : « As-tu une minute pour parler ? »"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition ThoughtRecord = new(
        "Pratique", "Journal des pensées",
        [
            "1. Décrivez la situation sans la juger",
            "2. Écrivez la pensée automatique",
            "3. Nommez l’émotion et évaluez-la maintenant",
            "4. Distinguez les faits des suppositions et trouvez une autre possibilité",
            "5. Évaluez de nouveau l’émotion — elle peut rester identique"
        ],
        "Séparez la situation, la pensée et l’émotion, puis vérifiez la conclusion à partir des faits. L’émotion n’a pas à s’apaiser.",
        TechniqueUiKind.Entry, "Technique n° 17", "04.07.2026", "Journal des pensées", "Distinguer un fait d’une interprétation", "Moment difficile", "TCC", 7, "EditNote",
        [
            new TechniqueEntrySeed("Situation", "Que s’est-il passé ? Où et quand ? L’essentiel seulement.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Pensée automatique", "Qu’avez-vous pensé à ce moment-là ?", Suggestions: HarshThoughts),
            new TechniqueEntrySeed("Émotion avant", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Point de vue plus juste", "Quels faits la soutiennent ou la contredisent ? Qu’est-ce qui est aussi possible ?", Role: EntryFieldRole.Reframe),
            new TechniqueEntrySeed("Émotion après", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "L’exercice distingue un événement de votre interprétation. Ce n’est ni un diagnostic ni un traitement.",
            "Pour une situation modérément désagréable, si vous avez l’énergie d’écrire maintenant. Ne choisissez pas un souvenir traumatique ni une crise aiguë.",
            "Notez les faits observables, puis la pensée. Cherchez une explication qui tient compte des faits et de ce que vous ignorez ; ne forcez pas une vision positive. Une note inchangée ne signifie pas que vous avez mal fait.",
            "Situation : pas encore de réponse à un message. Pensée : « Personne n’a besoin de moi. » Fait : la réponse n’est pas arrivée. Autre possibilité : la raison est inconnue ; la personne est peut-être occupée."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition SelfCompassion = new(
        "Pratique", "Des mots bienveillants pour soi",
        [
            "1. Écrivez ce que vous vous reprochez",
            "2. Imaginez qu'un ami proche dise cela — que lui répondriez-vous ?",
            "3. Formulez la même phrase de soutien pour vous-même",
            "4. Évaluez la chaleur ou le soulagement"
        ],
        "L'autocompassion réduit l'autocritique sévère et aide à se relever après une erreur.",
        TechniqueUiKind.Entry, "Technique n° 18", "04.07.2026", "Des mots bienveillants pour soi", "Adoucir l'autocritique par le soutien", "Moment difficile", "TCC", 5, "Favorite",
        [
            new TechniqueEntrySeed("Ce que vous vous reprochez", "Que vous dites-vous ou que vous reprochez-vous ?", Suggestions: ["Une erreur au travail", "Je n'ai pas fini", "Je me suis emporté·e contre un proche", "Je me compare aux autres", "Je repousse encore les choses", "Mon apparence", "Mon poids", "J'ai dit ce qu'il ne fallait pas", "Pas un assez bon parent", "Je gagne trop peu", "Je n'ai pas tenu une promesse", "Trop sensible"]),
            new TechniqueEntrySeed("Ce que vous diriez à un ami", "Comment soutiendriez-vous un proche dans cette situation ?", Role: EntryFieldRole.Kindness),
            new TechniqueEntrySeed("Phrase pour vous-même", "La même bienveillance, tournée vers vous", Role: EntryFieldRole.SelfKindness),
            new TechniqueEntrySeed("Chaleur / soulagement", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "L'autocritique motive rarement — elle nourrit plus souvent la honte et la paralysie. L'autocompassion n'enlève pas la responsabilité, elle apporte un soutien.",
            "Après une erreur, en vous comparant aux autres ou en vous sentant pas assez bien.",
            "Écrivez la critique, puis répondez-vous comme à un ami — avec respect et sans minimiser.",
            "Critique : j'ai encore tout gâché. À un ami : tu as essayé, ça se répare. À moi : je peux en tirer une leçon. Chaleur : 3 → 6."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition BodyScan = new(
        "Pratique", "Où est-ce dans le corps ?",
        [
            "1. Évaluez votre tension maintenant",
            "2. Déplacez lentement votre attention dans le corps, de la tête aux pieds",
            "3. Trouvez l'endroit où la sensation est la plus forte",
            "4. Décrivez-la : à quoi elle ressemble, grande ou petite, chaude ou froide",
            "5. Nommez le sentiment qui l'accompagne",
            "6. Si vous le souhaitez, observez ce qui a changé ou ce qui est resté pareil. Vous pouvez arrêter ou porter votre attention sur l’environnement à tout moment."
        ],
        "Le scan corporel invite à observer les sensations et les émotions sans devoir les changer.",
        TechniqueUiKind.Entry, "Technique n° 19", "16.10.2026", "Où est-ce dans le corps ?", "Observer les sensations sans chercher à les changer", "Moment difficile", "Pleine conscience", 4, "Accessibility",
        [
            new TechniqueEntrySeed("Tension maintenant", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Où le ressentez-vous dans le corps ?", "Par exemple : poitrine, gorge, épaules", Suggestions: ["Tête", "Front", "Yeux", "Mâchoire", "Gorge", "Cou", "Épaules", "Poitrine", "Cœur", "Ventre", "Dos", "Bas du dos", "Bras", "Mains", "Jambes", "Tout le corps"]),
            new TechniqueEntrySeed("À quoi ressemble la sensation ?", "Par exemple : serrement, lourdeur, une boule", Suggestions: ["Serrement", "Lourdeur", "Une boule", "Pression", "Tension", "Chaleur", "Froid", "Tremblement", "Picotements", "Pulsations", "Vide", "Engourdissement", "Douleur", "Difficile à décrire"]),
            new TechniqueEntrySeed("Quel sentiment l'accompagne ?", "Par exemple : anxiété, blessure, fatigue", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("Tension après", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Le scan corporel peut servir à remarquer des sensations et les sentiments qui peuvent les accompagner. Les remarquer ne fait pas nécessairement baisser la tension : elle peut rester la même. Cette pratique est utilisée dans certains programmes de pleine conscience.",
            "Quand vous vous sentez anxieux·se ou lourd·e sans savoir exactement ce que vous ressentez ; quand le corps est tendu après une conversation ou une journée difficile. La pratique n'explique pas les maladies et ne remplace pas un médecin : si une sensation est nouvelle, forte ou ne passe pas, consultez un médecin.",
            "Installez-vous confortablement si cela vous convient et portez peu à peu votre attention sur différentes parties du corps. Décrivez une sensation aussi précisément que possible ; si cela vous parle, nommez aussi un sentiment. Vous n’avez rien à changer. Si cette attention vers l’intérieur devient inconfortable, ouvrez les yeux, regardez des objets autour de vous ou arrêtez la pratique. Respirez normalement.",
            "Tension 6/10. Endroit : poitrine. Sensation : serrement. Sentiment : anxiété avant une conversation. Après, la tension était toujours à 6/10. J’ai ouvert les yeux et nommé des objets dans la pièce. C’est aussi un résultat valable."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Flashback = new(
        "Pratique", "Un souvenir a pris le dessus",
        [
            "1. Évaluez son intensité",
            "2. Dites-vous : « C'est un souvenir. C'était avant, et maintenant c'est aujourd'hui »",
            "3. Nommez où vous êtes et quel moment de la journée il est",
            "4. Sentez l'appui sous vos pieds, serrez et relâchez les poings",
            "5. Nommez trois choses que vous voyez",
            "6. Cinq expirations lentes, de l'eau froide, puis évaluez de nouveau"
        ],
        "Aide en cas de flash-back : revenir du souvenir au présent par le temps, le lieu, le corps et les sens.",
        TechniqueUiKind.Entry, "Technique n° 20", "16.10.2026", "Un souvenir a pris le dessus", "Revenir au présent quand un souvenir difficile prend le dessus", "Moment difficile", "Traumatisme", 3, "MyLocation",
        [
            new TechniqueEntrySeed("Son intensité", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Où vous êtes et le moment de la journée", "Par exemple : à la maison, le soir", Suggestions: ["À la maison", "Au travail", "Dehors", "Dans les transports", "Chez quelqu'un", "Matin", "Après-midi", "Soir", "Nuit"]),
            new TechniqueEntrySeed("Trois choses que vous voyez", "Par exemple : fenêtre, tasse, lampe", Suggestions: ["Fenêtre", "Table", "Téléphone", "Tasse", "Lampe", "Porte", "Chaise", "Mur", "Tableau", "Plante", "Horloge", "Ciel"]),
            new TechniqueEntrySeed("Son intensité maintenant", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Un flash-back est un souvenir de traumatisme vécu comme s'il se reproduisait : avec les mêmes sentiments et les mêmes réactions du corps. Le cerveau confond « avant » et « maintenant ». Le temps, le lieu, l'appui du corps et ce que vous voyez et entendez aident à revenir au présent.",
            "Quand le souvenir d'un événement difficile prend le dessus, avec des images qui surgissent et la sensation « j'y suis de nouveau ». Des flash-back fréquents sont un signe courant de réaction post-traumatique, et ils se soignent bien avec un spécialiste du traumatisme.",
            "N'essayez pas de travailler le souvenir : pour l'instant, la seule tâche est de revenir. Dites-vous où vous êtes et quel jour on est, appuyez vos pieds au sol, nommez ce que vous voyez, expirez lentement, utilisez le froid.",
            "Intensité 8. « C'était avant ; maintenant on est en 2026, je suis chez moi, c'est le soir. » Les pieds au sol ; je vois une fenêtre, une tasse, une lampe. De l'eau froide. Maintenant 4."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Nightmare = new(
        "Pratique", "Réécrire un cauchemar",
        [
            "1. Choisissez un cauchemar récurrent, pas le plus difficile pour commencer",
            "2. Décrivez-le brièvement, sans détails pénibles",
            "3. Décidez ce que vous y changez : la fin, le lieu, vous-même, quelqu'un à côté",
            "4. Écrivez la nouvelle version du rêve en entier, jusqu'à une fin calme",
            "5. Chaque jour, pendant 10 à 20 minutes, imaginez la nouvelle version en détail",
            "6. Au bout d'une ou deux semaines, voyez comment les cauchemars ont changé"
        ],
        "Répétition par imagerie mentale : un cauchemar récurrent est réécrit à l'état de veille, et le cerveau commence à rêver la nouvelle version.",
        TechniqueUiKind.Entry, "Technique n° 21", "16.10.2026", "Réécrire un cauchemar", "Rendre un cauchemar récurrent plus rare et plus faible", "Le sommeil", "Traumatisme", 15, "NightsStay",
        [
            new TechniqueEntrySeed("À quel point ce cauchemar est pénible", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("De quoi parle le cauchemar, en bref", "Une ou deux phrases, sans détails pénibles", Suggestions: ["Quelqu'un me poursuit", "Je n'arrive pas à m'enfuir", "Je suis de retour là où j'ai eu peur", "Je perds un proche", "Je n'arrive pas à crier", "Je tombe", "On m'attaque", "Je suis en retard et je n'y arrive pas"]),
            new TechniqueEntrySeed("Ce que vous changez", "Tout ce que vous voulez : c'est votre rêve", Suggestions: ["La fin", "Le lieu", "Je deviens plus fort·e", "Quelqu'un vient m'aider", "Je peux parler et crier", "Le danger disparaît", "Tout devient sûr", "Je remarque que c'est un rêve"]),
            new TechniqueEntrySeed("La nouvelle version du rêve", "Décrivez-la en entier, du début jusqu'à une fin calme", Suggestions: ["Je remarque que c'est un rêve", "Quelqu'un qui me protège apparaît", "Je me retrouve dans un endroit sûr", "Je m'éloigne calmement", "Tout finit bien"]),
            new TechniqueEntrySeed("Quand je répéterai la nouvelle version", "Chaque jour, 10 à 20 minutes", Suggestions: ["Le matin", "Dans la journée, pendant une pause", "Le soir, deux heures avant de dormir", "Chaque jour à la même heure"]),
            new TechniqueEntrySeed("À quel point c'est pénible maintenant", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Les cauchemars récurrents après un traumatisme ou un stress sont entretenus par l'habitude : le cerveau rejoue le même scénario encore et encore. Dans la thérapie par répétition d'imagerie mentale, le scénario est réécrit à l'état de veille, et la nouvelle version est répétée mentalement chaque jour. Les recherches montrent que cela rend les cauchemars plus rares et plus faibles, et le sommeil meilleur.",
            "En cas de cauchemars récurrents qui donnent peur de s'endormir. Si le cauchemar rejoue directement un traumatisme et que même une courte description provoque une forte terreur, faites-le avec un spécialiste du traumatisme.",
            "Commencez par un cauchemar plus léger. N'écrivez pas en détail les passages effrayants : deux phrases suffisent. Changez le rêve comme vous le souhaitez ; la nouvelle version n'a pas besoin d'être réaliste. Répétez-la dans la journée, pas juste avant de dormir, 10 à 20 minutes par jour.",
            "Cauchemar : quelqu'un me poursuit et je n'arrive pas à m'enfuir. Changement : je remarque que c'est un rêve, je me retourne, et ce n'est qu'une ombre ; je rentre calmement chez moi. Je le répète chaque après-midi. Au bout de deux semaines, le cauchemar revient moins souvent."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Balloons = new(
        "Pratique", "Éclate les ballons",
        [
            "1. Évaluez votre tension avant le jeu",
            "2. Commencez la manche et touchez les ballons à votre rythme ; inutile de tous les éclater",
            "3. Respirez comme d’habitude. Vous n’avez pas à synchroniser votre expiration avec chaque éclatement",
            "4. La manche se termine d’elle-même. Si le jeu vous agace ou aggrave votre état, revenez en arrière",
            "5. Réévaluez votre tension et notez ce que vous avez remarqué. L’absence de changement est aussi un résultat"
        ],
        "Un jeu bref pour occuper les mains et l’attention. Il peut détourner l’attention un instant, sans devoir changer votre état ni remplacer une action ou du soutien.",
        TechniqueUiKind.Entry, "Technique n° 22", "26.10.2026", "Éclate les ballons", "Une courte pause ludique, si vous le souhaitez", "Moment difficile", "Psyché", 3, "BubbleChart",
        [
            new TechniqueEntrySeed("Tension avant", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notes", "Qu’avez-vous remarqué, le cas échéant ? Vous pouvez laisser vide.", Suggestions: ["Un peu moins de tension", "Pas de changement notable", "Plus de tension", "Mon attention a changé un instant", "J’ai remarqué les couleurs ou le mouvement", "Le jeu m’a agacé", "Je ne sais pas", "Autre"]),
            new TechniqueEntrySeed("Tension après", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Un petit jeu peut occuper brièvement les mains et l’attention ; son effet varie. Il ne garantit pas une baisse de l’anxiété et ne constitue pas un traitement.",
            "Quand une courte pause ludique vous convient. Ne retardez pas une action urgente liée à la santé ou à la sécurité pour jouer.",
            "Touchez les ballons à votre rythme ; inutile de tous les éclater. Respirez normalement, sans synchroniser votre souffle avec chaque éclatement. Après la manche, comparez votre évaluation sans attendre un résultat précis. Si un problème concret demande une action, reprenez l’étape suivante lorsque vous serez prêt.",
            "Après une dispute, ma tension était à 7/10 et est restée à 7/10 après la manche. J’ai remarqué que j’étais encore en colère et j’ai choisi d’attendre avant de répondre."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition CyclicSigh = new(
        "Pratique", "Soupir cyclique",
        [
            "1. Évaluez votre tension",
            "2. Inspirez par le nez, puis ajoutez une petite inspiration à la fin",
            "3. Expirez lentement par la bouche, plus longtemps que l'inspiration",
            "4. Respirez au rythme du cercle pendant environ trois minutes",
            "5. Évaluez votre tension après"
        ],
        "Deux inspirations douces de suite, suivies d’une expiration plus longue, donnent un rythme au souffle. Il n’est pas nécessaire de retenir son souffle ni d’inspirer plus profondément que d’habitude.",
        TechniqueUiKind.Entry, "Technique n° 23", "26.10.2026", "Soupir cyclique", "Une double inspiration et une longue expiration pour apaiser le corps", "Moment difficile", "Psyché", 3, "Air",
        [
            new TechniqueEntrySeed("Tension avant", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notes", "Qu’avez-vous remarqué ?", Suggestions: ["Un peu plus calme", "Pas de changement notable", "Plus inconfortable", "J’ai eu des vertiges", "Je préfère ne pas évaluer", "Autre"]),
            new TechniqueEntrySeed("Tension après", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Dans une étude randomisée menée auprès de 111 participants, le soupir cyclique a été pratiqué cinq minutes par jour pendant un mois. Les scores d’humeur positive ont davantage progressé que dans le groupe de pleine conscience. Cela ne prouve pas qu’une séance courte réduise rapidement la tension ni que chacun réagisse de la même façon.",
            "Vous pouvez essayer si l’attention au souffle vous convient, par exemple avant une conversation ou pendant une courte pause. Si cela vous met plus mal à l’aise, choisissez un exercice tourné vers l’environnement.",
            "Respirez doucement, sans chercher à inspirer au maximum. Répétez le rythme seulement tant qu’il vous convient. En cas de vertige ou de malaise, arrêtez, asseyez-vous de façon stable et reprenez votre respiration habituelle. Demandez un avis médical si les symptômes sont importants ou persistent.",
            "Avant un appel, je remarque une tension et essaie quelques cycles doux. Si rien ne change ou si je me sens moins bien, j’arrête et respire normalement."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition MuscleRelax = new(
        "Pratique", "Contracter et relâcher",
        [
            "1. Évaluez votre tension",
            "2. Contractez un groupe de muscles pendant cinq secondes, à moitié de votre force",
            "3. Relâchez et observez la détente pendant quinze secondes",
            "4. Passez par cinq groupes : mains, épaules, visage, ventre, jambes",
            "5. Évaluez votre tension après"
        ],
        "Contracter d'abord les muscles puis les relâcher aide le corps à sentir ce qu'est la détente.",
        TechniqueUiKind.Entry, "Technique n° 24", "26.10.2026", "Contracter et relâcher", "Une courte relaxation musculaire pour un corps crispé", "Moment difficile", "Psyché", 4, "SelfImprovement",
        [
            new TechniqueEntrySeed("Tension avant", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notes", "Où dans votre corps est-ce plus léger ?", Suggestions: ["Mes épaules se sont détendues", "Ma mâchoire s'est desserrée", "Mes mains se sont réchauffées", "Je respire plus facilement", "J'ai envie de dormir", "Il reste un peu de tension", "Rien n'a changé"]),
            new TechniqueEntrySeed("Tension après", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "La relaxation musculaire progressive est l'un des moyens les mieux étudiés pour réduire l'anxiété et la tension. Contracter un muscle puis le relâcher crée un contraste qui aide à remarquer la détente et, avec le temps, à apprendre à la provoquer. Ce n'est pas un traitement mais une compétence qui fonctionne mieux avec la pratique.",
            "Quand le corps est crispé par le stress, qu'il est difficile de rester assis ou de s'endormir. Convient bien le soir avant de dormir.",
            "Contractez à moitié de votre force, sans douleur. Si une partie du corps est douloureuse ou blessée, ne la contractez pas, observez-la simplement. Pendant le relâchement, respirez calmement et ne vous pressez pas de passer au groupe suivant.",
            "Tension 7/10 le soir après le travail, les épaules remontées. Cinq groupes : mains, épaules, visage, ventre, jambes. Tension 4/10, mes épaules sont descendues."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition BusyMind = new(
        "Pratique", "Brève pause de l’attention",
        [
            "1. Évaluez votre tension seulement si cela vous est utile maintenant",
            "2. Choisissez une tâche neutre pour environ 30 à 60 secondes",
            "3. Si votre attention revient à l’inquiétude, ne vous critiquez pas ; vous pouvez revenir doucement à la tâche une fois",
            "4. Arrêtez-vous et vérifiez si une action concrète ou du soutien est nécessaire"
        ],
        "Une courte tâche neutre peut déplacer l’attention un instant quand les pensées semblent bloquées. Elle ne supprime pas les pensées et ne résout pas le problème.",
        TechniqueUiKind.Entry, "Technique n° 25", "26.10.2026", "Brève pause de l’attention", "Une pause temporaire quand les pensées se répètent", "Moment difficile", "Psyché", 1, "Extension",
        [
            new TechniqueEntrySeed("Tension avant", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notes", "Comment s’est passée cette courte pause ?", Suggestions: ["Mon attention a changé un instant", "Rien n’a changé", "Je me suis senti·e plus tendu·e ou frustré·e", "Je vois une prochaine étape", "J’ai besoin de soutien", "J’ai arrêté l’exercice"]),
            new TechniqueEntrySeed("Tension après", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Une courte tâche neutre — comme nommer des objets d’une même couleur — peut parfois aider à traverser un moment intense. Elle déplace temporairement l’attention sans supprimer les pensées ; ses effets varient.",
            "Quand des pensées répétitives captent votre attention et que vous souhaitez une brève pause. En cas de problème urgent ou de question de sécurité ou de santé, agissez et demandez une aide adaptée.",
            "Choisissez une tâche simple pendant 30 à 60 secondes ; une concentration parfaite n’est pas nécessaire. Ensuite, voyez s’il y a une action concrète à reprendre. Si la tâche vous frustre ou aggrave votre état, arrêtez et choisissez une autre approche.",
            "Après une dispute, la conversation tourne encore dans votre tête. Pendant une demi-minute, nommez cinq objets autour de vous, puis décidez s’il faut clarifier un fait, faire une pause ou demander du soutien."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition ThoughtDefusion = new(
        "Pratique", "Prendre du recul sur une pensée",
        [
            "1. Repérez une pensée courte ; l’écrire est facultatif",
            "2. Dites : « Je remarque la pensée que… »",
            "3. Regardez un objet devant vous et sentez l’appui sous vos pieds",
            "4. Choisissez une petite prochaine action ou arrêtez-vous ici"
        ],
        "Un exercice bref de thérapie d’acceptation et d’engagement (ACT) : voir une pensée comme une activité de l’esprit, pas forcément comme un fait ou un ordre.",
        TechniqueUiKind.Entry, "Technique n° 26", "03.11.2026", "Prendre du recul sur une pensée", "Un exercice bref pour prendre du recul face à une pensée inquiétante", "Pensées", "Psyché", 1, "FormatQuote",
        [
            new TechniqueEntrySeed("Pensée", "Facultatif : vous pouvez faire l’exercice en silence", Suggestions: HarshThoughts)
        ],
        Theory(
            "Une pensée répétitive peut accaparer toute l’attention. En ACT, la défusion consiste à la remarquer sans la contester ni essayer de la chasser.",
            "Quand une inquiétude, une autocritique ou une peur revient en boucle. Il n’est pas nécessaire de choisir un souvenir pénible.",
            "Vous n’avez rien à écrire. Ajoutez « Je remarque la pensée que… » avant la pensée, regardez un objet et sentez l’appui sous vos pieds. Si le malaise augmente, arrêtez et nommez quelques objets autour de vous.",
            "« Je vais tout gâcher » devient « Je remarque la pensée que je vais tout gâcher ». Vous remarquez la tasse devant vous et choisissez de répondre à un courriel ou de faire une pause."),
        null, null);
}
