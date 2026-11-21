using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Articles;

public static partial class ArticleContent
{
    private static readonly Course[] CoursesFr =
    [
        new(
            CourseIds.Sleep,
            "Dormir sans somnifères",
            "Sept jours de thérapie cognitive et comportementale de l'insomnie, la façon la mieux étudiée de retrouver le sommeil",
            "Bedtime",
            "isi",
            "ISI-7",
            [
                new(
                    "Comment fonctionne le sommeil",
                    4,
                    [
                        P("Le sommeil ne s'« allume » pas par l'effort. Deux forces le préparent : la pression de sommeil, qui s'accumule toute la journée pendant l'éveil, et l'horloge interne, qui nous rend somnolents et éveillés aux mêmes heures chaque jour."),
                        P("Dans l'insomnie, les deux forces sont déréglées : on se couche plus tôt pour « rattraper », on reste longtemps éveillé, on fait la sieste, on se lève à des heures différentes. La pression de sommeil n'a pas le temps de s'accumuler, et l'horloge s'embrouille."),
                        Cycle("Le cercle de l'insomnie", "Une mauvaise nuit", "L'inquiétude : « je ne vais encore pas dormir »", "S'efforcer de s'endormir", "La tension éloigne le sommeil"),
                        P("Ce cours repose sur la thérapie cognitive et comportementale de l'insomnie (TCC-I). Les recommandations médicales la placent en premier, avant les somnifères : son effet dure après la fin du cours."),
                        Warning("Quand consulter d'abord un médecin"),
                        List(
                            "Ronflements forts, pauses respiratoires pendant le sommeil, forte somnolence dans la journée",
                            "Des sensations désagréables dans les jambes le soir qui donnent envie de bouger",
                            "Une insomnie accompagnée d'une humeur basse depuis plus de deux semaines",
                            "Vous conduisez ou utilisez des machines et êtes très somnolent dans la journée")
                    ],
                    "Chaque matin, notez : quand vous vous êtes couché, à peu près quand vous vous êtes endormi, combien de fois vous vous êtes réveillé, quand vous vous êtes levé et comment vous avez dormi de 0 à 10. Pas de montre la nuit, approximativement, au ressenti.",
                    "À quelle heure vous couchez-vous et vous levez-vous d'habitude ? Qu'est-ce qui gêne le plus votre sommeil ?"),
                new(
                    "Le lit est fait pour dormir",
                    4,
                    [
                        P("Si vous restez souvent éveillé au lit, vous y inquiétez ou y regardez votre téléphone, le cerveau associe le lit à l'éveil. C'est pourquoi on peut s'assoupir dans un fauteuil et être parfaitement réveillé dès qu'on s'allonge."),
                        H("Les règles qui rétablissent le lien"),
                        List(
                            "N'allez au lit que lorsque vous avez sommeil, pas simplement quand vous êtes fatigué",
                            "Si vous ne dormez pas depuis environ 20 minutes, levez-vous et faites quelque chose de calme sous une lumière douce. Revenez quand vous avez sommeil",
                            "Le lit sert uniquement au sommeil et à l'intimité : pas de téléphone, de séries ni de travail",
                            "Levez-vous à la même heure chaque jour, même après une mauvaise nuit et le week-end",
                            "Ne faites pas de sieste, et si vraiment il le faut, pas plus de 20 minutes et avant 15 h"),
                        Quiz("La nuit a été mauvaise. Que vaut-il mieux faire le matin ?", 1, "Une heure de lever fixe est le principal point d'ancrage du sommeil. Si vous faites la grasse matinée, la pression de sommeil sera plus faible le soir, et la nuit suivante sera difficile elle aussi.", "Faire la grasse matinée pour récupérer", "Se lever à l'heure habituelle", "Se lever, puis faire une bonne sieste dans la journée")
                    ],
                    "Choisissez une heure de lever que vous pouvez tenir les sept jours, et levez-vous à cette heure. Si vous ne dormez pas depuis environ 20 minutes, sortez du lit.",
                    "Quelle heure de lever avez-vous choisie ? Qu'est-ce qui a été difficile avec la règle « se lever si on ne dort pas » ?"),
                new(
                    "La fenêtre de sommeil",
                    5,
                    [
                        P("Plus on reste éveillé longtemps au lit, plus le sommeil devient léger et haché. Une technique appelée compression du sommeil aide : le temps passé au lit est rapproché du temps réellement dormi."),
                        H("Comment calculer la fenêtre"),
                        List(
                            "À partir de vos notes des derniers jours, calculez combien de temps vous dormez en moyenne",
                            "Ajoutez 30 minutes : c'est votre temps au lit, mais pas moins de six heures",
                            "Comptez à rebours depuis l'heure de lever choisie : cela donne votre heure de coucher",
                            "Ne vous couchez pas avant cette heure, même si vous en avez très envie"),
                        P("Les premiers jours, vous aurez sommeil : cela signifie que la pression de sommeil s'accumule. Au bout d'une semaine, si vous dormez la plupart du temps passé au lit, la fenêtre peut être allongée de 15 minutes."),
                        Warning("Attention"),
                        P("Ne compressez pas le sommeil si vous avez un trouble bipolaire ou une épilepsie, si vous êtes enceinte, ou si la somnolence rend la conduite ou le travail dangereux. Dans ces cas, parlez de votre sommeil avec un médecin.")
                    ],
                    "Calculez votre fenêtre de sommeil et respectez-la jusqu'à la fin du cours : pas de lit avant l'heure de coucher, lever à la même heure.",
                    "Quelle est votre fenêtre de sommeil ? Comment s'est passée la première nuit avec elle ?"),
                new(
                    "Une soirée qui prépare au sommeil",
                    4,
                    [
                        P("Le sommeil vient plus facilement quand le corps et l'esprit ont le temps de ralentir. L'heure avant le coucher est le pont entre la journée et le sommeil."),
                        H("Ce qui aide"),
                        List(
                            "Une heure avant le coucher : lumière douce et activités calmes sans écrans",
                            "Évitez le café, le thé fort et les boissons énergisantes pendant au moins 6 heures avant le coucher ; s’ils perturbent votre sommeil, arrêtez plus tôt",
                            "L'alcool aide à s'endormir mais rend le sommeil superficiel et réveille vers le matin",
                            "Un dîner copieux 2 à 3 heures avant le coucher",
                            "Le matin, la lumière du jour pendant au moins 15 minutes : elle règle l'horloge interne"),
                        P("Plan en une minute : choisissez quand commencera votre temps calme et une activité tranquille, par exemple lire quelques pages. Si vous n’avez pas une heure, prévoyez une version plus courte. Par exemple : « Après mes tâches du soir, je tamiserai la lumière et lirai un peu. »"),
                        H("Se détendre avant de dormir"),
                        P("Une respiration lente avec une longue expiration diminue l'activation. Essayez maintenant."),
                        Breathe("Inspirez sur 4, expirez sur 6")
                    ],
                    "Essayez votre plan ce soir : prenez si possible du temps pour une activité calme avant le coucher ; si vous n’avez pas une heure, utilisez la version courte. Gardez le téléphone hors du lit en conservant les alertes importantes.",
                    "Qu'avez-vous mis dans votre rituel du soir ? Qu'est-ce qui s'est révélé difficile ?"),
                new(
                    "Les pensées qui empêchent de dormir",
                    4,
                    [
                        P("L'esprit se met souvent à travailler justement au lit : dans la journée, il n'y avait pas de temps pour les pensées. Il aide donc de leur en donner plus tôt."),
                        H("Un temps pour les pensées"),
                        List(
                            "Le soir, deux heures environ avant le coucher, réservez 15 minutes",
                            "Écrivez tout ce qui vous préoccupe et, pour chaque point, une prochaine étape ou « rien à faire pour l'instant »",
                            "Si la pensée revient au lit, dites-vous : « je l'ai noté, je m'en occuperai demain »"),
                        Quiz("Au lit, vous pensez : « Si je ne dors pas, je vais tout rater demain. » Qu'est-ce qui est plus proche de la vérité ?", 1, "La pensée exagère. Après une mauvaise nuit, c'est plus dur, mais la plupart des gens accomplissent quand même leurs tâches. Plus la peur du lendemain est forte, plus il est difficile de s'endormir.", "C'est vrai, l'échec est inévitable", "Après une mauvaise nuit c'est plus dur, mais d'habitude je m'en sors pour l'essentiel", "Mieux vaut ne pas se coucher du tout"),
                        Practice(TechniqueId.ThoughtDefusion, "Prendre du recul sur une pensée")
                    ],
                    "Chaque soir, réservez 15 minutes pour écrire ce qui vous préoccupe, et n'emportez pas ces pensées au lit.",
                    "Quelles pensées viennent le plus souvent la nuit ? Les écrire vous a-t-il aidé ?"),
                new(
                    "Cesser de lutter contre le sommeil",
                    4,
                    [
                        P("Plus on essaie de dormir, pire c'est. Le sommeil est comme un oiseau farouche : il vient quand personne ne le poursuit."),
                        H("Ce qui aide à lâcher le contrôle"),
                        List(
                            "Mettez l'horloge hors de vue : compter « plus que cinq heures » réveille",
                            "Autorisez-vous à ne pas dormir : « je vais rester allongé et me reposer, le sommeil viendra quand il viendra »",
                            "Une mauvaise nuit n'est pas une catastrophe : le corps récupère même après un sommeil incomplet",
                            "N'annulez pas vos projets à cause d'une mauvaise nuit : ainsi l'insomnie ne dirige pas votre vie"),
                        P("Comparez vos notes des premiers jours avec aujourd'hui : comment ont changé le temps d'endormissement, le nombre de réveils et la note du sommeil ?")
                    ],
                    "Gardez l'horloge hors de vue la nuit. Après une mauvaise nuit, vivez la journée comme d'habitude.",
                    "Qu'est-ce qui a changé dans votre sommeil ces derniers jours, d'après vos notes ?"),
                new(
                    "Bilan et plan",
                    4,
                    [
                        P("En une semaine, vous avez parcouru le cœur de la TCC de l'insomnie. Le sommeil revient progressivement : beaucoup de personnes constatent une amélioration en deux à quatre semaines si elles respectent les règles."),
                        H("Ce qu'il faut continuer"),
                        List(
                            "Une seule heure de lever chaque jour",
                            "N'aller au lit qu'avec sommeil, et se lever si l'on ne dort pas",
                            "Si vous dormez la plus grande partie de la nuit, allonger la fenêtre de 15 minutes par semaine",
                            "Le rituel du soir et le temps pour les pensées"),
                        H("Si l'insomnie revient"),
                        P("Après un stress, une maladie ou un voyage, le sommeil peut de nouveau se dérégler. C'est normal : revenez aux règles de ce cours, et il se rétablira plus vite que la première fois."),
                        P("Refaites l'index ISI-7 et comparez avec votre résultat du début. S'il n'y a pas d'amélioration, consultez un médecin : il existe des spécialistes du sommeil qui pratiquent la TCC-I."),
                        TestsTab("Index ISI-7", "isi")
                    ],
                    "Écrivez votre plan pour le cas où le sommeil se dérèglerait de nouveau.",
                    "Qu'est-ce qui vous a le plus aidé dans le cours ? Qu'allez-vous continuer à faire ?")
            ]),
        new(
            CourseIds.Anxiety,
            "L'anxiété sous contrôle",
            "Six jours : comprendre comment fonctionne l'anxiété, calmer le corps, vérifier les pensées effrayantes et faire un premier pas vers la peur",
            "Psychology",
            "gad7",
            "GAD-7",
            [
                new(
                    "Comment fonctionne l'anxiété",
                    4,
                    [
                        P("L'anxiété est une alarme destinée à prévenir d'un danger. Les difficultés commencent quand elle sonne trop souvent, trop fort, et ne s'arrête pas pendant longtemps."),
                        Cycle("Le cercle de l'anxiété", "Une pensée effrayante", "L'anxiété dans le corps", "Évitement ou béquille", "Soulagement pour une minute", "Le cerveau retient : « c'était dangereux »"),
                        P("Ce qui entretient l'anxiété, ce n'est pas la peur elle-même, mais ce que nous faisons pour ne pas la ressentir : éviter, revérifier, chercher à être rassuré, ressasser. Pas à pas, le cours travaille chaque maillon de ce cercle."),
                        P("Au début du cours, il vaut la peine de remplir l'échelle GAD-7 : à la fin, vous comparerez le résultat."),
                        TestsTab("Échelle GAD-7", "gad7")
                    ],
                    "Trois fois aujourd'hui, quand vous vous sentez anxieux, notez : ce qui s'est passé, quelle était la pensée, ce que le corps ressentait et ce que vous avez fait.",
                    "Quand et où l'anxiété apparaît-elle le plus souvent ?"),
                new(
                    "Calmer le corps",
                    4,
                    [
                        P("Quand l'anxiété est forte, il est difficile de discuter avec ses pensées. D'abord, il aide de calmer le corps : une expiration lente active le système qui freine la réaction de lutte ou de fuite."),
                        Breathe("Inspirez sur 4, expirez sur 6"),
                        P("Si l'anxiété est forte et que tout semble irréel, ramenez votre attention au présent par les sens."),
                        Practice(TechniqueId.Grounding, "Ancrage 5-4-3-2-1"),
                        P("Important : la respiration n'est pas un moyen de se débarrasser de l'anxiété à tout prix. Elle aide à passer le pic, pas à éviter les situations.")
                    ],
                    "Deux fois par jour, deux minutes de respiration lente, même au calme : ainsi la compétence sera là quand vous en aurez besoin.",
                    "Qu'avez-vous remarqué dans votre corps en respirant lentement ?"),
                new(
                    "Vérifier une pensée effrayante",
                    5,
                    [
                        P("Les pensées anxieuses sonnent comme des faits : « je vais me ridiculiser », « il va arriver quelque chose de terrible ». Mais ce sont des prédictions, et on peut les vérifier."),
                        H("Les questions à poser à la pensée"),
                        List(
                            "Quels faits soutiennent cette pensée, et quels faits vont contre ?",
                            "Que s'est-il passé dans des cas semblables auparavant ?",
                            "Qu'est-ce qui est le plus probable, plutôt que le plus effrayant ?",
                            "Si le pire arrive, comment y ferai-je face ?",
                            "Que dirais-je à un ami qui aurait cette pensée ?"),
                        Quiz("« Je vais forcément tout rater. » Quel piège de pensée est-ce ?", 1, "C'est la prédiction de l'avenir : la pensée traite comme un fait ce qui n'est pas encore arrivé.", "La lecture de pensées", "La prédiction de l'avenir", "La disqualification du positif"),
                        Practice(TechniqueId.ThoughtRecord, "Journal des pensées")
                    ],
                    "Une fois aujourd'hui, vérifiez une pensée anxieuse avec le journal des pensées.",
                    "Quelle pensée avez-vous vérifiée ? Combien y croyiez-vous avant et après ?"),
                new(
                    "Le temps des soucis",
                    4,
                    [
                        P("S'inquiéter semble utile : « si je réfléchis davantage, je serai prêt ». En réalité, ressasser mène rarement à une solution et maintient l'anxiété élevée."),
                        Quiz("Comment distinguer résoudre et tourner en rond ?", 0, "Résoudre avance vers un pas : que puis-je faire, et quand. Tourner en rond produit de nouveaux « et si ».", "Résoudre finit par un pas, tourner en rond par un nouveau « et si »", "Tourner en rond prend plus de temps", "C'est impossible"),
                        H("Comment reporter les soucis"),
                        List(
                            "Choisissez 15 à 20 minutes par jour, pas avant le coucher",
                            "Quand un souci arrive à un autre moment, notez le sujet en une ligne et dites-vous : « j'y penserai pendant mon temps des soucis »",
                            "Pendant votre temps des soucis, parcourez la liste : prévoyez un pas pour ce que vous pouvez faire, lâchez ce que vous ne pouvez pas",
                            "Souvent, à l'heure prévue, le sujet ne semble plus important"),
                        Practice(TechniqueId.ThoughtDefusion, "Prendre du recul sur une pensée"),
                        P("Si vous rouvrez les nouvelles pour être rassuré, notez la question précise et demandez-vous s’il faut agir maintenant. Sinon, choisissez le moment de votre prochaine vérification."),
                        See(ArticleIds.NewsLoop, "Quand les nouvelles ne vous lâchent pas")
                    ],
                    "Fixez-vous un temps des soucis et reportez-y les pensées anxieuses.",
                    "Avez-vous réussi à reporter les soucis ? Que sont devenus les sujets à l'heure prévue ?"),
                new(
                    "Béquilles et évitement",
                    4,
                    [
                        P("Ce qui entretient le plus l'anxiété, c'est l'évitement. Il peut être ouvert (je n'y vais pas, je n'appelle pas) ou caché : des béquilles qui aident à traverser une situation."),
                        Check("Ai-je des béquilles ?", 2, "Vous avez plusieurs béquilles. Elles entretiennent la peur : le cerveau croit que tout s'est bien passé uniquement grâce à elles. Essayez d'en abandonner une dans une situation facile.", "Vous avez peu de béquilles. Remarquez aussi ce que vous évitez complètement.", "J'ai sur moi un comprimé, de l'eau ou un téléphone chargé « au cas où »", "Je ne vais dans les endroits difficiles qu'accompagné", "Je m'assois près de la sortie", "Je me distrais pour ne pas remarquer l'anxiété", "Je vérifie ou redemande de nombreuses fois"),
                        P("La sortie consiste à rencontrer progressivement ce qui fait peur et à se passer des béquilles. Le cerveau apprend alors par l'expérience que ce qu'on redoute n'arrive pas ou est supportable.")
                    ],
                    "Faites une liste de trois à cinq situations que vous évitez, de la plus facile à la plus difficile.",
                    "Quelle situation de la liste êtes-vous prêt à essayer en premier ?"),
                new(
                    "Le premier pas et un plan",
                    4,
                    [
                        P("Le moyen le plus efficace d'affaiblir l'anxiété est l'exposition : rencontrer progressivement la peur. Inutile d'aller tout de suite au plus effrayant : commencez par un pas facile et vérifiez une prédiction."),
                        List(
                            "Avant le pas, notez ce que vous craignez et à quel point vous êtes sûr que cela arrivera",
                            "Faites le pas sans béquilles et restez dans la situation jusqu'à avoir vérifié la prédiction",
                            "Ensuite, notez ce qui s'est réellement passé"),
                        Ladder("Échelle de la peur"),
                        H("Ce qu'il faut continuer"),
                        List(
                            "La respiration lente au pic de l'anxiété",
                            "La vérification des pensées et le temps des soucis",
                            "Des marches sur l'échelle de la peur tous les quelques jours"),
                        P("Refaites l'échelle GAD-7 et comparez avec le début. Si l'anxiété est forte ou gêne votre vie, consultez un psychothérapeute : la TCC de l'anxiété est bien étudiée."),
                        TestsTab("Échelle GAD-7", "gad7")
                    ],
                    "Faites le premier pas sur votre échelle de la peur et notez ce qui s'est passé.",
                    "Qu'aviez-vous prédit, et que s'est-il réellement passé ?")
            ]),
        new(
            CourseIds.Mood,
            "Sortir de l'apathie",
            "Six jours d'activation comportementale : de petits pas pour retrouver l'énergie et ce qui fait plaisir",
            "Cloud",
            "phq9",
            "PHQ-9",
            [
                new(
                    "Le cercle de l'inaction",
                    4,
                    [
                        P("Quand l'humeur est à zéro, il est naturel d'en faire moins : pas d'énergie, rien ne tente. Mais moins on en fait, moins il y a dans la vie de choses qui apportent de la joie et le sentiment « j'y suis arrivé », et l'humeur baisse encore."),
                        Cycle("Le cercle de l'inaction", "Pas d'énergie", "J'en fais moins", "Moins de joie et de réussites", "Encore moins d'énergie"),
                        P("L'activation comportementale brise ce cercle par l'autre bout : ne pas attendre d'en avoir envie, mais faire de petits pas après lesquels l'énergie et l'envie reviennent peu à peu. C'est l'une des méthodes d'aide les mieux étudiées contre la dépression."),
                        P("Remplissez l'échelle PHQ-9 au début du cours : à la fin, vous comparerez le résultat."),
                        TestsTab("Échelle PHQ-9", "phq9"),
                        Warning("Si des pensées de mort apparaissent"),
                        P("Si vous avez des pensées qu'il vaudrait mieux que vous ne soyez pas là, ne restez pas seul avec elles : ce cours ne remplace pas l'aide d'un spécialiste."),
                        Crisis("J'ai besoin d'aide maintenant")
                    ],
                    "Aujourd'hui et demain, notez ce que vous faites et évaluez votre humeur de 0 à 10 plusieurs fois par jour.",
                    "Comment se passent vos journées en ce moment ? Qu'avez-vous cessé de faire ces derniers temps ?"),
                new(
                    "Ce qui remonte l'humeur",
                    4,
                    [
                        P("Regardez vos observations : à quels moments l'humeur était-elle un peu plus haute ? Souvent, c'est quelque chose de petit : une conversation, une promenade, une douche, une tâche accomplie."),
                        H("Deux types d'activités utiles"),
                        List(
                            "Les agréables : ce qui apporte du plaisir, même faible — musique, bonne nourriture, soleil",
                            "Les « j'y suis arrivé » : ce qui laisse un sentiment d'accomplissement — faire la vaisselle, répondre à un e-mail"),
                        P("Dans la dépression, le plaisir des choses agréables est plus faible qu'avant. C'est normal : ce qui compte, c'est de faire, sans attendre la joie d'avant.")
                    ],
                    "Faites une liste de dix activités : cinq agréables et cinq « j'y suis arrivé ». Plus elles sont petites et simples, mieux c'est.",
                    "Qu'avez-vous mis dans votre liste ? Y a-t-il eu quelque chose qui a un peu remonté votre humeur ?"),
                new(
                    "De petits pas",
                    4,
                    [
                        P("Les grands projets font peur dans l'apathie et ne se réalisent pas. Il aide de découper : pas « ranger l'appartement » mais « enlever trois objets de la table »."),
                        List(
                            "Choisissez une activité de la liste pour aujourd'hui",
                            "Découpez-la jusqu'à un pas qui prend cinq minutes",
                            "Fixez un moment et un lieu : « après le petit-déjeuner, dans la cuisine »",
                            "Ensuite, notez comment votre humeur a changé"),
                        Practice(TechniqueId.SmallStep, "Un petit pas"),
                        P("Le but n’est pas de faire remonter l’humeur immédiatement. Si elle reste la même, notez si l’activité était faisable et ajustez le prochain pas."),
                        See(ArticleIds.SmallStepReview, "Quand un petit pas ne change pas l’humeur")
                    ],
                    "Chaque jour, faites une activité agréable et une activité « j'y suis arrivé » au moment prévu.",
                    "Qu'avez-vous réussi à faire ? Comment votre humeur a-t-elle changé ensuite ?"),
                new(
                    "« Je n'en ai pas envie »",
                    4,
                    [
                        P("Le principal obstacle est la pensée « je n'en ai pas envie, je le ferai quand j'aurai de l'énergie ». Dans l'apathie, l'envie vient après l'action, pas avant."),
                        Quiz("Pas d'énergie, et une promenade est prévue aujourd'hui. Que vaut-il mieux faire ?", 1, "Dans l'apathie, l'envie revient après l'action. Même cinq minutes envoient au corps et à l'humeur le signal « j'ai fait quelque chose ».", "Attendre d'en avoir envie", "Sortir au moins cinq minutes", "Reporter au week-end"),
                        H("D'autres pensées qui freinent"),
                        List(
                            "« Ça ne sert à rien » : vérifiez après coup — quelque chose a-t-il un peu changé ?",
                            "« C'est trop petit » : c'est justement de petits pas qu'est faite la sortie",
                            "« Avant, j'en faisais plus » : comparez-vous à hier, pas à vous d'avant"),
                        Practice(TechniqueId.SelfCompassion, "Des mots bienveillants pour soi")
                    ],
                    "Quand vous n'en avez pas envie, faites au moins une version de cinq minutes de ce que vous aviez prévu.",
                    "Quelle pensée vous empêche le plus souvent de commencer ? Qu'est-ce qui vous a aidé à la contourner ?"),
                new(
                    "Les gens autour de vous",
                    4,
                    [
                        P("Dans l'apathie, on veut se couper de tout le monde. Pourtant, le contact avec les autres est l'un des remèdes les plus puissants contre une humeur basse, même si en ce moment il n'apporte pas autant de joie qu'avant."),
                        List(
                            "Écrivez à une personne avec qui vous n'avez pas été en contact depuis un moment",
                            "Une courte rencontre ou un appel vaut mieux que rien",
                            "Vous n'êtes pas obligé de tout expliquer : « c'est difficile en ce moment, allons juste marcher »",
                            "Si l'énergie manque, choisissez des personnes avec qui c'est facile"),
                        Practice(TechniqueId.SmallStep, "Un petit pas"),
                        P("Vous n’avez pas à tout raconter : vous pouvez demander quelque chose de précis, comme être écouté, avoir de la compagnie ou de l’aide pour une tâche."),
                        See(ArticleIds.SupportRequest, "Comment demander du soutien")
                    ],
                    "Prenez contact avec au moins une personne dans les deux prochains jours.",
                    "Avec qui avez-vous pris contact ? Comment cela s'est-il passé ?"),
                new(
                    "Ce qui compte pour moi",
                    4,
                    [
                        P("Pour que les pas ne deviennent pas des corvées, il aide de les relier à ce qui compte pour vous : vos proches, la santé, le travail, la créativité, la nature."),
                        List(
                            "Choisissez un domaine qui compte pour vous",
                            "Réfléchissez à qui vous voulez être dans ce domaine",
                            "Choisissez un petit pas dans cette direction pour la semaine"),
                        H("Ce qu'il faut continuer"),
                        List(
                            "Chaque jour, une activité agréable et une « j'y suis arrivé »",
                            "De petits pas plutôt que de grands projets",
                            "Le contact avec les autres"),
                        P("Refaites l'échelle PHQ-9 et comparez avec le début. Si le résultat est élevé ou ne change pas, consultez un médecin ou un psychothérapeute : la dépression se soigne très bien."),
                        TestsTab("Échelle PHQ-9", "phq9"),
                        Crisis("J'ai besoin d'aide maintenant")
                    ],
                    "Faites un pas cette semaine dans un domaine qui compte pour vous.",
                    "Qu'est-ce qui compte pour vous ? Quel pas avez-vous choisi ?")
            ]),
        new(
            CourseIds.Trauma,
            "Après un traumatisme",
            "Cinq jours sur ce qu'on peut faire sans risque seul : comprendre sa réaction, faire face aux reviviscences et aux cauchemars, trouver un spécialiste",
            "Healing",
            "pcl5",
            "PCL-5",
            [
                new(
                    "Une réaction normale à un événement anormal",
                    4,
                    [
                        P("Après un événement difficile, presque tout le monde a des souvenirs envahissants, des cauchemars, de l'anxiété, de l'engourdissement, de l'irritabilité. Ce n'est pas une faiblesse, mais la réaction d'un cerveau qui essaie de vous protéger contre une répétition."),
                        P("Ce cours ne traitera pas le traumatisme : cela demande une thérapie avec un spécialiste. Il vous aidera à comprendre ce qui vous arrive, à faire face aux moments difficiles et à arriver préparé chez un spécialiste. Dans ce cours, vous n'avez pas besoin de vous rappeler ni de décrire l'événement lui-même."),
                        P("Remplissez l'échelle PCL-5 au début : à la fin, vous comparerez le résultat."),
                        TestsTab("Échelle PCL-5", "pcl5"),
                        Warning("Si le danger continue"),
                        P("Si vous êtes menacé en ce moment, ou si des pensées de vous faire du mal sont apparues, la sécurité passe en premier."),
                        Crisis("J'ai besoin d'aide maintenant")
                    ],
                    "Notez quand les choses deviennent plus difficiles dans la journée, sans détails de l'événement : l'heure, le lieu, ce qu'il y avait autour.",
                    "Lesquelles de ces réactions reconnaissez-vous chez vous ?"),
                new(
                    "Revenir au présent",
                    4,
                    [
                        P("Une reviviscence est un souvenir revécu comme s'il se produisait maintenant. Le moment, le lieu, l'appui du corps et les sens aident à revenir."),
                        Practice(TechniqueId.Flashback, "Un souvenir a pris le dessus"),
                        Practice(TechniqueId.Grounding, "Ancrage 5-4-3-2-1"),
                        H("Votre trousse d'ancrage"),
                        List(
                            "Une phrase : « C'est un souvenir. C'est un autre moment maintenant, je suis en sécurité »",
                            "Un objet à garder sur vous : un galet, une bague, quelque chose de parfumé",
                            "Une personne à qui vous pouvez écrire",
                            "Quelque chose de froid : de l'eau, de la glace"),
                        Breathe("L'expiration plus longue que l'inspiration"),
                        P("Si l’attention portée à la respiration ou au corps augmente le malaise, arrêtez-vous. Ouvrez les yeux, choisissez un objet neutre autour de vous ou passez l’exercice."),
                        See(ArticleIds.TraumaGrounding, "Quand l’ancrage augmente le malaise")
                    ],
                    "Préparez votre trousse d'ancrage et essayez la pratique « Un souvenir a pris le dessus » à un moment calme, pour la connaître à l'avance.",
                    "Qu'avez-vous mis dans votre trousse d'ancrage ?"),
                new(
                    "Le sommeil et les cauchemars",
                    4,
                    [
                        P("Après un traumatisme, le sommeil souffre souvent : on a du mal à s'endormir, le sommeil est léger, des cauchemars viennent. Le manque de sommeil rend les journées plus anxieuses et plus irritables."),
                        List(
                            "Une seule heure de lever chaque jour",
                            "De la lumière le matin, une soirée calme sans les informations",
                            "Si un cauchemar vous réveille : lumière, où suis-je et quel jour on est, de l'eau, des expirations lentes",
                            "L'alcool renforce les cauchemars en seconde partie de nuit"),
                        P("Un cauchemar récurrent peut être réécrit : la répétition d'imagerie mentale rend les cauchemars plus rares et plus faibles. Commencez par un plus léger."),
                        Practice(TechniqueId.Nightmare, "Réécrire un cauchemar")
                    ],
                    "Gardez une seule heure de lever. Si vous avez des cauchemars récurrents, essayez d'en réécrire un, en commençant par un plus léger.",
                    "Comment dormez-vous en ce moment ? Qu'est-ce qui aide après une nuit difficile ?"),
                new(
                    "Le soutien et les autres",
                    4,
                    [
                        P("Le traumatisme éloigne souvent des autres et de ce qui comptait avant. Le soutien des proches est l'un des facteurs les plus puissants de rétablissement."),
                        List(
                            "Vous n'êtes pas obligé de parler de l'événement : vous pouvez simplement être ensemble",
                            "Dites à vos proches comment vous aider dans un moment difficile",
                            "Ramenez peu à peu ce qui vous soutenait : promenades, mouvement, choses que vous aimiez",
                            "N'anesthésiez pas vos émotions avec l'alcool : cela gêne le rétablissement"),
                        P("Éviter ce qui rappelle l'événement est compréhensible, mais avec le temps cela rétrécit la vie et garde le traumatisme « brûlant ». Il vaut mieux y travailler avec un spécialiste que se forcer seul."),
                        P("Ce que l'événement a changé dans votre façon de penser à vous — la culpabilité, « quelque chose ne va pas chez moi », « on ne peut faire confiance à personne » — peut être travaillé dans le chat, sans raconter ce qui s'est passé."),
                        TraumaChat("Y travailler dans le chat"),
                        Practice(TechniqueId.SelfCompassion, "Des mots bienveillants pour soi")
                    ],
                    "Faites une chose qui vous soutenait autrefois, et passez du temps avec quelqu'un de confiance.",
                    "Qui et qu'est-ce qui vous soutient en ce moment ?"),
                new(
                    "Le chemin vers un spécialiste",
                    5,
                    [
                        P("Les symptômes post-traumatiques répondent bien à la psychothérapie centrée sur le traumatisme : exposition prolongée, thérapie cognitive, EMDR, exposition écrite. Elle demande généralement 8 à 16 séances."),
                        See(ArticleIds.TraumaTreatment, "Comment on soigne un traumatisme et comment choisir un spécialiste"),
                        H("Comment se préparer"),
                        List(
                            "Refaites l'échelle PCL-5 et comparez avec le début",
                            "Exportez un résumé de l'application pour le spécialiste : « Profil → Paramètres → Données et sauvegarde »",
                            "Notez vos questions : quelle méthode, combien de séances, comment les progrès seront mesurés",
                            "Vous n'êtes pas obligé de tout raconter sur l'événement au premier rendez-vous"),
                        TestsTab("Échelle PCL-5", "pcl5"),
                        Crisis("J'ai besoin d'aide maintenant")
                    ],
                    "Trouvez un ou deux spécialistes qui travaillent avec le traumatisme et prenez rendez-vous pour une consultation.",
                    "Qu'est-ce qui a été le plus utile dans le cours ? De quoi voulez-vous parler avec le spécialiste ?")
            ]),
        new(
            CourseIds.MoneyStress,
            "Inquiétudes d’argent : 14 jours de soutien",
            "Quatorze étapes courtes pour vérifier l’urgence, distinguer faits et scénarios et trouver du soutien. Le GAD-7 porte sur l’anxiété générale des deux dernières semaines, pas sur les finances ; une variation ne prouve pas l’effet du cours. Aucun conseil financier ou juridique.",
            "AccountBalanceWallet",
            "gad7",
            "GAD-7",
            [
                new(
                    "Une inquiétude",
                    4,
                    [P("Le GAD-7 porte sur les symptômes généraux d’anxiété des deux dernières semaines, pas sur l’argent. Décrivez une inquiétude sans montant, coordonnées ni nom."), TestsTab("Ouvrir le GAD-7 : anxiété générale des deux dernières semaines", "gad7"), See(ArticleIds.MoneyStress, "Inquiétudes d’argent : distinguer faits et scénarios")],
                    "Notez-la en termes généraux ou dites-la à voix basse.",
                    "Qu’est-ce qui ramène souvent votre attention vers elle ?"),
                new(
                    "Vérifier l’urgence",
                    4,
                    [P("Si la nourriture, le logement, des médicaments indispensables ou la sécurité sont menacés, cherchez une aide concrète aujourd’hui ; le cours peut attendre.")],
                    "Nommez un besoin pour aujourd’hui et une personne à contacter.",
                    "Qu’est-ce qui demande d’abord votre attention ?"),
                new(
                    "Faits et prédictions",
                    4,
                    [P("Séparez les faits connus, ce qui reste à vérifier et une crainte pour l’avenir. Reconnaître l’incertitude n’oblige pas à imaginer le pire."), Practice(TechniqueId.MoneyWorryPlan, "Faire le tri dans une inquiétude d’argent"), See(ArticleIds.MoneyStress, "Inquiétudes d’argent : distinguer faits et scénarios")],
                    "Essayez la pratique avec des notes générales.",
                    "Qu’avez-vous pu distinguer de la crainte ?"),
                new(
                    "Une question à vérifier",
                    4,
                    [P("Choisissez une question dont la réponse pourrait réduire l’incertitude. Pour une facture ou un service, utilisez un canal officiel connu.")],
                    "Notez une question et où vérifier la réponse en sécurité.",
                    "Qu’est-ce qui est plus clair ?"),
                new(
                    "Protéger ses données",
                    4,
                    [P("Ne partagez ni mots de passe, ni codes PIN ou de vérification, ni coordonnées complètes. Vérifiez autrement les demandes inattendues d’argent.")],
                    "Choisissez une règle de pause avant de partager des données ou de l’argent.",
                    "Quelle limite vous protège ?"),
                new(
                    "Demander une aide précise",
                    4,
                    [P("Le soutien peut être une présence, un appel à deux ou la recherche d’un service local, pas seulement de l’argent. L’autre personne peut accepter ou refuser."), See(ArticleIds.SupportRequest, "Comment demander du soutien")],
                    "Rédigez une demande pour une tâche et un moment, sans secret financier.",
                    "À qui pourriez-vous la demander ?"),
                new(
                    "Une étape à votre portée",
                    4,
                    [P("Choisissez une action sûre, réversible et dans votre contrôle. Pour une question financière ou juridique spécialisée, adressez-vous à un professionnel local qualifié."), Practice(TechniqueId.MoneyWorryPlan, "Faire le tri dans une inquiétude d’argent")],
                    "Choisissez une petite étape ou demandez du soutien.",
                    "Qu’est-ce qui vous évite de tout porter seul ?"),
                new(
                    "Une solution de repli",
                    4,
                    [P("Le plan est plus souple s’il prévoit une autre possibilité en cas de délai ou de refus. Elle n’a pas à tout résoudre.")],
                    "Nommez une autre possibilité et un contact d’aide.",
                    "Quelle option paraît réaliste ?"),
                new(
                    "Un temps pour revoir",
                    4,
                    [P("Sans urgence, fixez un court moment pour vérifier les informations, puis revenez à votre activité. Ne retardez pas une aide nécessaire.")],
                    "Choisissez un moment calme pour revoir le plan.",
                    "Qu’est-ce qui peut attendre ?"),
                new(
                    "Une aide concrète",
                    4,
                    [P("Votre région propose peut-être des services sociaux, communautaires ou de santé. Les possibilités varient ; l’application ne recommande pas de décision financière.")],
                    "Trouvez une source locale connue pour demander quelles aides existent.",
                    "Que souhaiteriez-vous demander ?"),
                new(
                    "Parler sans livrer de secrets",
                    4,
                    [P("Vous pouvez dire : je suis inquiet et j’aimerais que tu restes un peu avec moi. Il n’est pas nécessaire de partager montants ou coordonnées.")],
                    "Décidez à qui parler et de quoi, en termes généraux.",
                    "Quel soutien vous ferait du bien ?"),
                new(
                    "Prendre soin de soi",
                    4,
                    [P("Une pause, boire de l’eau, manger ou une activité apaisante ne règle pas le problème financier, mais peut aider à traverser la journée.")],
                    "Choisissez un geste de soin possible sans dépense.",
                    "Qu’est-ce qui offrirait un peu de répit ?"),
                new(
                    "Revoir ses limites",
                    4,
                    [P("Remarquez ce qui est clair, ce qui reste incertain et où vous avez besoin d’aide. Vous pouvez simplifier le plan.")],
                    "Gardez une prochaine étape et reportez le reste si c’est sûr.",
                    "Que n’avez-vous pas besoin de résoudre aujourd’hui ?"),
                new(
                    "Choisir la suite",
                    4,
                    [P("Après environ deux semaines, vous pouvez refaire le GAD-7. Il n’évalue pas les finances et ne prouve pas l’effet du cours. Si l’anxiété perturbe durablement votre quotidien, parlez-en à un professionnel."), TestsTab("Refaire le GAD-7 ; il n’évalue pas les finances et n’explique pas une variation", "gad7"), Crisis("J’ai besoin d’aide maintenant")],
                    "Choisissez un soutien ou une étape à poursuivre.",
                    "Que garderiez-vous ou discuteriez-vous ?")
            ]),

        new(CourseIds.ValuesAction, "De petits pas vers ce qui compte", "Cinq jours pour choisir une direction importante et essayer des actions à votre portée.", "TrackChanges", "who5", "WHO-5",
            [
                new("Trouver une direction", 3, [P("Une valeur décrit la personne que vous souhaitez être dans un domaine de votre vie, pas un résultat à atteindre une fois pour toutes."), See(ArticleIds.ValuesAction, "Les valeurs comme repère : choisir un petit pas")], "Nommez un domaine qui compte pour vous en ce moment.", "Qu’est-ce qui le rend important pour vous ?"),
                new("Réduire l’étape", 3, [P("Choisissez une action de quelques minutes. Elle doit être assez petite pour être essayée et assez importante pour rester votre choix.")], "Notez une action qui prend au maximum 5 à 10 minutes.", "Comment la rendre plus simple ou plus courte ?"),
                new("Prévoir un obstacle", 3, [P("Pensez à ce qui pourrait gêner et choisissez une solution de rechange. Un plan peut changer ; ce n’est pas un échec.")], "Complétez : « Si … me gêne, je peux essayer … ».", "Quelle option serait plus douce si vous avez moins d’énergie ?"),
                new("Essayer sans attendre le bon état d’esprit", 3, [P("Vous n’avez pas besoin de vous sentir sûr de vous ou motivé avant d’agir. Essayez un petit pas, observez ce qui se passe et arrêtez-vous ou simplifiez-le si c’est plus sûr.")], "Si cela ne présente pas de risque, essayez votre étape ou une version plus facile.", "Qu’avez-vous remarqué avant et après ?"),
                new("Revoir le plan", 3, [P("Évaluez si l’action vous convenait, sans vous juger. Répétez-la, adaptez-la ou choisissez une autre direction.")], "Notez ce que vous souhaitez refaire ou modifier cette semaine.", "Quelle action peut soutenir ce qui compte sans ajouter de pression ?")
            ]),


        new(CourseIds.ProblemPlanning, "Un plan pour les tâches à votre portée", "Découper un problème et revoir son plan", "Checklist", "gad7", "GAD-7",
            [
                new("Choisir un problème", 3, [P("Nommez d’abord un problème précis. Tout ne dépend pas de vous ; choisissez ce sur quoi vous pouvez agir."), See(ArticleIds.ProblemPlanning, "Un plan pour les tâches à votre portée")], "Notez un problème et ce qui dépend de vous.", "Sur quelle partie pouvez-vous agir ?"),
                new("Choisir une étape", 3, [P("Notez plusieurs options, même imparfaites. Choisissez une petite étape sûre."), See(ArticleIds.ProblemPlanning, "Un plan pour les tâches à votre portée")], "Notez deux options et choisissez une étape à votre portée.", "Quel obstacle pourrait surgir et quelle solution de rechange avez-vous ?"),
                new("Revoir le plan", 3, [P("Après l’essai, notez ce qui a aidé et ce qui était trop difficile. Vous pouvez adapter le plan ou demander du soutien."), See(ArticleIds.ProblemPlanning, "Un plan pour les tâches à votre portée")], "Essayez cette étape si elle est sûre et notez le résultat.", "Que garder, modifier ou discuter avec quelqu’un ?")
            ]),
        new(
            CourseIds.Overwhelm,
            "Moins de surcharge, une prochaine étape plus claire",
            "Cinq journées courtes pour trier l’urgence, réduire une tâche et trouver du soutien. Avancez à votre rythme.",
            "Checklist",
            "pss10",
            "PSS-10",
            [
                new("Sortir les tâches de sa tête", 4, [P("Une courte liste montre ce qui demande de l’attention. Quelques mots suffisent ; aucun détail privé n’est nécessaire."), H("Vérifier d’abord l’urgence"), Warning("Si la sécurité, la santé, l’alimentation, le logement ou les médicaments essentiels sont menacés, cherchez d’abord une aide pratique."), See(ArticleIds.Overwhelm, "Quand tout s’accumule : choisir la prochaine étape")], "Notez ce qui demande votre attention et marquez ce qui ne peut pas attendre sans risque.", "Qu’est-ce qui est plus clair après la liste ?"),
                new("Distinguer urgence et inquiétude", 4, [P("Une inquiétude intense mérite de l’attention, mais ne fixe pas seule l’ordre des tâches. Vérifiez les échéances, les conséquences et votre marge d’action."), Quiz("Qu’est-ce qui peut aider à choisir la première tâche ?", 1, "Les échéances et les conséquences aident à estimer l’urgence ; l’intensité de l’inquiétude ne suffit pas à classer une tâche en premier.", "Choisir l’inquiétude la plus forte", "Vérifier l’échéance et les conséquences", "Tout régler en même temps")], "Choisissez une tâche pour aujourd’hui et une autre qui peut attendre.", "Qu’est-ce qui ne peut vraiment pas être reporté ?"),
                new("Réduire la prochaine étape", 4, [P("Décrivez une action de quelques minutes. Si elle paraît encore trop grande, découpez-la davantage."), See(ArticleIds.Overwhelm, "Quand tout s’accumule : choisir la prochaine étape"), Practice(TechniqueId.ExternalOrientation, "Trois détails neutres")], "Nommez le début : ouvrir, appeler, demander ou rassembler un élément.", "Comment rendre cette étape plus facile ?"),
                new("Demander une aide à votre portée", 4, [P("Demander une action précise est plus clair que demander à quelqu’un de tout régler. La personne peut accepter, proposer autre chose ou refuser ; vous pourrez alors chercher un autre soutien."), List("Demander à quelqu’un de rester un moment", "Demander de vérifier un fait", "Demander de partager une tâche")], "Rédigez une demande courte et choisissez à qui l’adresser.", "Quelle réponse ou solution de rechange vous conviendrait ?"),
                new("Revoir le plan", 4, [P("Vérifiez si le plan correspond à votre situation actuelle, pas si vous avez été assez strict envers vous-même. Vous pouvez continuer, simplifier ou demander du soutien."), TestsTab("Si vous le souhaitez, repassez PSS-10. Il dépiste le stress perçu, sans poser de diagnostic ; un changement de score ne prouve pas que le cours l’a causé.", "pss10")], "Choisissez une étape à garder pour les prochains jours.", "Comment éviter que le plan devienne une pression supplémentaire ?")
            ]),

        new(
            CourseIds.NewsBoundaries,
            "Les informations à votre rythme",
            "Cinq jours pour consulter les fils moins par automatisme tout en gardant les alertes importantes.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Repérer l’habitude", 4, [P("Quand vous ouvrez le fil, demandez-vous : qu’est-ce que je veux savoir, et dois-je agir maintenant ?"), See(ArticleIds.NewsLoop, "Quand les nouvelles ne vous lâchent pas"), TestsTab("Le PSS-10 mesure le stress perçu au cours du dernier mois. C’est un outil de dépistage, pas un diagnostic.", "pss10")], "Repérez une fois ce qui a déclenché l’envie de consulter les nouvelles.", "Que cherchiez-vous à savoir ?"),
                new("Une question, une source", 4, [P("Formulez une question et choisissez une source fiable qui peut y répondre. Une fois la réponse trouvée, d’autres mises à jour n’apporteront peut-être rien d’utile."), Quiz("Vous avez trouvé la réponse. Que faire si aucune action urgente n’est nécessaire ?", 1, "Choisir quand consulter à nouveau peut interrompre l’actualisation automatique.", "Actualiser jusqu’à vous sentir calme", "Choisir le prochain moment de consultation et reprendre votre activité", "Vous interdire complètement les actualités")], "Choisissez une question et une source pour votre prochaine consultation.", "Comment saurez-vous que vous avez l’information nécessaire ?"),
                new("Garder les alertes importantes", 4, [P("Vous pouvez désactiver les notifications facultatives et garder celles qui concernent la sécurité, vos proches ou votre travail."), List("Garder les alertes des services essentiels", "Désactiver les notifications facultatives", "Demander à vos proches d’appeler en cas d’urgence")], "Ne modifiez les réglages que si cela vous est utile.", "Quelles alertes souhaitez-vous garder ?"),
                new("Préparer un plan de consultation", 4, [P("Choisissez un moment et une source adaptés. Aucune limite stricte n’est nécessaire : modifiez le plan si une information urgente ou un nouvel élément apparaît."), Practice(TechniqueId.NewsCheckPlan, "Planifier sa consultation des nouvelles")], "Remplissez le court plan ou réfléchissez-y simplement.", "Que ferez-vous après la consultation ?"),
                new("Faire le point sans se juger", 4, [P("Observez si cette routine vous convient mieux. Gardez-la, modifiez-la ou laissez-la de côté. Une évolution du PSS-10 ne prouve pas que le cours en est la cause."), Quiz("Que faire si une information importante pour la sécurité apparaît ?", 1, "Le plan ne doit pas vous empêcher de vérifier une information urgente ou de suivre les consignes officielles.", "Attendre le prochain créneau prévu", "Vérifier une source fiable et agir selon la situation", "Désactiver toutes les alertes"), TestsTab("Vous pouvez refaire le PSS-10 si vous le souhaitez. La comparaison des scores n’établit pas la cause d’un changement.", "pss10")], "Gardez un réglage qui vous convient.", "Quel rythme vous a semblé faisable ?")
            ]),
        new(
            CourseIds.HabitMaintenance,
            "Une habitude à laquelle revenir",
            "Cinq jours pour choisir un repère, faciliter le démarrage et reprendre doucement après une interruption.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Choisir une action", 4, [P("Commencez par une petite action qui dépend de vous et soutient le bien-être au quotidien. Ne choisissez pas plusieurs objectifs à la fois."), See(ArticleIds.HabitFormation, "Créer une habitude : un petit geste et un repère"), TestsTab("Le WHO-5 est un bref dépistage du bien-être des deux dernières semaines, pas un diagnostic ni une mesure de volonté.", "who5")], "Nommez une action que vous aimeriez répéter.", "Pourquoi cette étape vous convient-elle maintenant ?"),
                new("L’associer à un repère", 4, [P("Choisissez un événement régulier qui peut vous rappeler de commencer, par exemple après le petit-déjeuner ou en rentrant chez vous."), Practice(TechniqueId.ImplementationIntention, "Plan « si… alors… »"), Quiz("Quel plan sera plus facile à se rappeler au bon moment ?", 1, "Un repère précis et une petite action facilitent le début sans attendre d’être dans le bon état d’esprit.", "Je m’y mettrai plus longtemps un de ces jours", "Après le petit-déjeuner, j’écrirai une phrase", "Je commencerai quand je serai motivé")], "Complétez : Après …, je …", "Quel repère régulier existe déjà dans votre journée ?"),
                new("Faciliter le démarrage", 4, [P("Enlevez un petit obstacle : préparez ce qu’il faut, ouvrez le fichier ou choisissez un endroit. Le premier geste peut ne durer que quelques minutes."), List("Préparer ce qui sera nécessaire", "Réduire la durée ou la quantité", "Choisir un lieu ou un moment plus pratique")], "Facilitez le début d’un seul geste.", "Qu’est-ce qui gênait et qu’avez-vous modifié ?"),
                new("Prévoir la reprise", 4, [P("Un jour manqué indique ce qui s’est passé ; il ne prouve pas un échec. Inutile de doubler l’effort ou de se critiquer : vous pouvez reprendre à la prochaine occasion adaptée."), Practice(TechniqueId.HabitRestartPlan, "Reprendre en douceur"), Quiz("Vous avez manqué votre action habituelle. Qu’est-ce qui peut aider à reprendre sans pression ?", 1, "Un prochain repère adapté et une étape plus petite permettent de continuer sans punition ni rattrapage.", "Faire deux fois plus demain", "Reprendre au prochain repère et commencer petit", "Abandonner le plan pour toujours")], "Choisissez un repère de reprise et la version la plus simple de l’action.", "Comment continuer sans chercher à tout rattraper ?"),
                new("Garder ce qui convient", 4, [P("Considérez le plan comme une expérience : répétez-le, réduisez l’action, changez de repère ou faites une pause. Vous pouvez refaire le WHO-5 si vous le souhaitez ; une évolution du score ne prouve pas que le cours l’a causée."), TestsTab("Le WHO-5 est un dépistage du bien-être, pas un diagnostic. Comparer les scores n’établit pas la cause d’un changement.", "who5")], "Gardez un ajustement à essayer ensuite.", "Qu’est-ce qui était faisable et que souhaitez-vous changer ?")
            ]),
        new(
            CourseIds.FeedbackResponse,
            "Répondre à un retour sans s’autocritiquer",
            "Quatre courtes étapes : distinguer les faits des étiquettes, clarifier les attentes et choisir une réponse qui respecte vos limites.",
            "Forum", "who5", "WHO-5",
            [
                new("Repérer la première réaction", 4, [P("Les mots peuvent blesser. Vous n’avez pas à approuver, contester ou vous justifier tout de suite. Remarquez d’abord ce que vous avez entendu et ce que cela vous fait."), See(ArticleIds.Feedback, "Un retour sans étiquette"), TestsTab("Le WHO-5 porte sur le bien-être général des deux dernières semaines ; ce n’est ni un diagnostic ni une mesure de la façon dont vous avez reçu un retour.", "who5")], "Choisissez une phrase qui vous laisse le temps de réfléchir.", "Que pourriez-vous dire pour ne pas répondre à chaud ?"),
                new("Demander des précisions", 4, [P("Demander un exemple peut aider à comprendre ce qui pourrait changer. Clarifiez le délai, le critère ou la situation sans promettre d’accepter tout ce qui est dit."), Practice(TechniqueId.FeedbackReview, "Trier un retour")], "Notez une question qui clarifierait l’attente.", "Qu’est-ce qui reste trop vague ?"),
                new("Choisir la partie utile", 4, [P("Vous pouvez examiner un commentaire précis, clarifier ce qui est contesté et refuser une étiquette. Le but est de choisir la suite, pas de prouver votre valeur."), Warning("Menaces, humiliation, discrimination ou pression appellent des limites et du soutien, pas de l’autocritique.")], "Choisissez un point que vous voulez vérifier ou discuter.", "Que puis-je influencer et que ne suis-je pas obligé d’accepter ?"),
                new("Terminer par une suite calme", 4, [P("Convenez d’une action ou d’un moment pour en reparler. Sans accord possible, vous pouvez noter les faits et consulter une personne de confiance ou les règles de votre organisation."), Quiz("Quelle réponse aide le mieux à clarifier la suite ?", 1, "Une question précise clarifie les attentes ; une pause laisse le temps de choisir.", "Tout accepter pour terminer l’échange.", "Demander un exemple ou un critère et répondre plus tard.", "Décider qu’une erreur définit toute votre personne."), TestsTab("Une réaction forte ne prouve pas que les mots sont vrais. Le WHO-5 est un dépistage général du bien-être, pas un test sur les retours ; un changement de score ne prouve pas l’effet du cours.", "who5")], "Essayez une question ou une réponse qui respecte vos limites.", "Quelle petite étape choisissez-vous ?")
            ]),
        new(
            CourseIds.ConnectionWithoutPressure,
            "Créer du lien à votre rythme",
            "Cinq petits pas pour repérer le lien souhaité, choisir un format sûr et proposer un contact sans pression.",
            "Group", "who5", "WHO-5",
            [
                new("Nommer le type de lien souhaité", 4, [P("Parfois, on souhaite parler ; parfois partager une activité, profiter d’une présence calme ou recevoir une aide pratique. Vous n’avez pas à viser un nombre précis de contacts."), See(ArticleIds.Loneliness, "La solitude"), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines, pas une mesure de la solitude ni un diagnostic. Un changement de score ne prouve pas à lui seul l’effet du cours.", "who5")], "Choisissez un type de contact qui vous serait utile maintenant.", "Que signifie pour moi un lien confortable ?"),
                new("Choisir un format sûr", 4, [P("Pensez à la personne et au format les plus rassurants : à deux, en groupe, en ligne ou par un bref message. Une pause est possible ; ne contactez pas quelqu’un auprès de qui vous ne vous sentez pas en sécurité.")], "Nommez une personne, un groupe ou un format qui vous semble suffisamment sûr.", "Quel format me faciliterait le début ?"),
                new("Inviter sans pression", 4, [P("Une invitation brève et précise est plus facile à accepter ou à décliner. Laissez à l’autre le choix du moment ou du refus."), See(ArticleIds.SupportRequest, "Comment demander du soutien"), Practice(TechniqueId.ConnectionStepPlan, "Préparer un petit contact")], "Rédigez une invitation pour une courte promenade, une conversation ou une activité partagée.", "Comment laisser l’autre libre de choisir ?"),
                new("Garder de la souplesse", 4, [P("Commencez à un moment pratique, avec une façon simple de terminer. Si vous manquez d’énergie, réduisez ou reportez le plan. Une réponse ou son absence ne définit pas votre valeur."), Practice(TechniqueId.ConnectionStepPlan, "Préparer un petit contact")], "Choisissez un format simple et décidez quand vous pourriez terminer ou reporter.", "Comment me soutenir si le plan change ?"),
                new("Faire le point sans se juger", 4, [P("Remarquez si le contact vous semblait sûr et agréable, et si vous souhaitez répéter ou changer le format. Ne vous évaluez pas selon le nombre de messages ou la réponse d’autrui."), Quiz("Que peut-on observer après un petit contact ?", 0, "Il est utile d’observer le format et votre expérience. La réponse d’autrui ne mesure pas votre valeur.", "Était-ce sûr et agréable, et que pourrais-je adapter ?", "Combien de messages ai-je reçus en une heure ?", "L’absence de réponse prouve-t-elle que personne ne veut me voir ?"), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines, pas une mesure de la solitude ni un diagnostic. Un changement de score ne prouve pas à lui seul l’effet du cours.", "who5")], "Choisissez un format à essayer ou à ajuster.", "Quel petit pas me convient aujourd’hui ?")
            ]),
        new(
            CourseIds.Boundaries,
            "Communiquer ses limites",
            "Quatre étapes courtes pour repérer ses limites, les exprimer clairement et choisir une suite sûre.",
            "Forum", "who5", "WHO-5",
            [
                new("Ce qui compte pour moi", 4, [P("Communiquer avec assurance, c’est exprimer ses besoins clairement tout en respectant le droit de l’autre à répondre librement. Cela ne garantit pas un accord et n’est jamais une obligation."), H("Trois façons de répondre"), List("Se taire malgré son désaccord", "Mettre la pression ou insulter en retour", "Dire calmement sa position et sa demande"), Quiz("Quelle réponse est la plus affirmée ?", 2, "Une phrase claire et calme exprime votre position tout en laissant l’autre libre de répondre.", "Accepter alors que vous ne le souhaitez pas", "Parler plus fort jusqu’à obtenir un accord", "Dire : « Pas aujourd’hui. Peut-on en reparler un autre jour ? »"), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines, pas une mesure de l’affirmation de soi ni un diagnostic.", "who5"), Crisis("J'ai besoin d'aide maintenant")], "Repérez une situation sans danger où vous aimeriez poser une limite. Vous n’avez pas à agir tout de suite.", "Qu’est-ce qui compte pour vous dans cette situation ?"),
                new("Dire non simplement", 4, [P("Un refus peut être bref et poli. Vous n’avez pas à vous justifier longuement. Si cela vous convient, vous pouvez proposer une autre option, sans y être obligé."), List("« Je ne peux pas maintenant »", "« Je ne suis pas en mesure de m’en charger »", "« J’ai besoin d’y réfléchir. Je répondrai demain »"), P("Si la personne insiste, répétez calmement votre phrase principale. Vous n’avez pas à prouver que votre raison est valable.")], "Préparez un refus pour une situation quotidienne peu risquée.", "Quels mots vous semblent naturels ?"),
                new("Formuler une demande précise", 4, [P("Une demande précise est plus facile à comprendre qu’un sous-entendu ou un reproche. Nommez la situation, ce qui compte pour vous et une option réaliste."), Quiz("Quelle demande est la plus claire ?", 1, "Une demande précise décrit une action et un moment sans prêter d’intentions à l’autre.", "« Tu ne m’écoutes jamais »", "« Quand tu auras un moment, peux-tu m’écouter dix minutes ? »", "Ne rien dire et espérer que l’autre devine"), P("L’autre peut accepter, proposer un compromis ou refuser. Vous gardez le droit de demander et de choisir la suite.")], "Écrivez ou imaginez une demande en une phrase.", "Que pourriez-vous rendre plus précis ?"),
                new("Choisir une suite sûre", 4, [P("Commencez par une situation à faible risque et imaginez ce que vous pourriez faire selon la réponse. Vous pouvez reporter ou terminer la conversation, ou être accompagné."), P("Si parler franchement risque d’entraîner menaces, violence, punition ou contrôle accru, ne vous entraînez pas seul. Votre sécurité et le soutien passent d’abord."), TestsTab("Le WHO-5 mesure le bien-être général, pas la capacité à poser des limites. Une variation du score ne prouve pas un effet du cours.", "who5")], "Choisissez une étape sûre : dire votre phrase, chercher du soutien ou ne rien changer pour le moment.", "Quelle suite serait bienveillante envers vous ?")
            ]),
        new(
            CourseIds.WorkRecovery,
            "Récupérer après le travail",
            "Quatre jours pour repérer ce qui aide à décrocher, choisir un repos accessible et protéger du temps hors travail.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Ce qui m’aide à récupérer", 4, [P("Les façons de se reposer varient d’une personne à l’autre. La recherche étudie la possibilité de décrocher des pensées de travail, de se détendre, de faire une activité qui absorbe et de choisir son rythme ou son moment. Ce sont des options, pas une liste à suivre."), H("Quelques idées"), List("Une pause calme ou un repos tranquille", "Une activité prenante ou qui permet d’apprendre", "Du temps avec d’autres ou seul", "Un mouvement doux, s’il vous convient"), TestsTab("Le PSS-10 évalue le stress perçu au cours du dernier mois. Il ne diagnostique pas l’épuisement professionnel et ne mesure pas la récupération après le travail.", "pss10"), Crisis("J'ai besoin d'aide maintenant")], "Repérez une façon de vous reposer qui vous aide parfois ou vous semble accessible.", "Qu’est-ce qui vous aide à décrocher, même un peu ?"),
                new("Terminer la journée en douceur", 4, [P("Les tâches inachevées peuvent rester présentes à l’esprit. Si possible, choisissez un petit signal de fin de journée : fermer les onglets du travail, noter la première étape de demain ou vous changer."), P("Adaptez cela aux horaires décalés, aux astreintes et aux urgences. Gardez les alertes utiles pour votre sécurité ou votre travail.")], "Choisissez un signal bref de fin de travail adapté à votre emploi du temps.", "Qu’est-ce qui pourrait marquer le passage au temps personnel ?"),
                new("Choisir un repos sans objectif parfait", 4, [P("Le repos n’a pas besoin de devenir une tâche de plus. Demandez-vous si vous préférez le calme, la compagnie, une activité prenante ou ne rien faire."), List("Raccourcir une activité", "Choisir quelque chose qui demande peu de préparation", "Vous autoriser à changer d’avis"), P("La recherche observe des liens entre certaines expériences de récupération et le bien-être, sans garantir le même effet à chacun. Tenez compte de votre expérience.")], "Essayez une petite pause ou choisissez quand vous pourriez y revenir.", "Qu’est-ce qui vous a semblé agréable, neutre ou inadapté ?"),
                new("Protéger un temps personnel réaliste", 4, [P("Vous ne contrôlez pas forcément toutes les demandes. Si le travail empiète régulièrement sur le repos, vous pouvez discuter des priorités, des délais ou du soutien avec une personne responsable, un collègue ou un proche de confiance."), P("Si les conditions ne peuvent pas changer pour le moment, ce n’est pas un échec personnel. Choisissez seulement ce qui est possible : une pause, une activité courte ou l’heure du prochain contact professionnel."), TestsTab("Un nouveau PSS-10 reste un dépistage général du stress. La différence de score n’indique ni la cause du changement ni l’effet du cours.", "pss10")], "Gardez un petit ajustement que vous aimeriez essayer cette semaine.", "Que souhaitez-vous garder ou modifier ensuite ?")
            ]),
        new(
            CourseIds.SelfCompassion,
            "Se traiter avec douceur après une erreur",
            "Quatre étapes pour repérer l’autocritique, séparer le fait du jugement et choisir une réponse utile.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Repérer la voix critique", 4, [P("Après une erreur, l’autocritique peut transformer un geste en jugement sur toute votre personne. Inutile de la combattre ou de forcer des pensées positives : commencez par distinguer les faits de votre jugement."), H("Fait et étiquette"), List("J’ai oublié de répondre — un fait", "Je suis un ami déplorable — une étiquette", "Que puis-je réparer ? — une question"), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines. Il ne mesure pas l’autocompassion et ne prouve pas l’effet du cours.", "who5"), Crisis("J'ai besoin d'aide maintenant")], "Repérez une étiquette autocritique et décrivez les faits sans vous juger. Vous n’avez pas à écrire.", "Que s’est-il passé sans l’étiquette ?"),
                new("Se parler comme à un proche", 4, [P("Imaginez qu’un proche ait fait la même erreur. Se soutenir ne signifie pas tout excuser : cela aide à voir la situation dans son ensemble et à choisir la suite."), Quiz("Quelle réponse est à la fois bienveillante et honnête ?", 2, "Elle reconnaît l’erreur sans rabaisser la personne et cherche une action concrète.", "Vous ratez toujours tout", "Ce n’est pas important du tout", "Vous avez fait une erreur. Voyons ce qui peut être réparé")], "Dites-vous une phrase honnête sans vous rabaisser.", "Comment sonne cette phrase ?"),
                new("Réparer sans se punir", 4, [P("La bienveillance envers soi peut aller avec la responsabilité. Vous pouvez reconnaître les conséquences et réparer ce qui est possible sans faire d’une erreur un jugement sur toute votre personne."), List("Que s’est-il passé exactement ?", "Qui ou quoi a été touché ?", "Quelle petite action pourrait aider maintenant ?"), P("Tout ne peut pas être réparé tout de suite. Vous pouvez en tirer une leçon et demander conseil à une personne de confiance.")], "Choisissez une action réalisable pour réparer ou soutenir.", "Qu’est-ce qui dépend de vous maintenant ?"),
                new("Préparer une prochaine étape bienveillante", 4, [P("Préparez un plan simple pour la prochaine fois : repérer l’autocritique, faire une pause et choisir une action utile. Modifiez-le s’il ne vous convient pas."), TestsTab("Un nouveau WHO-5 reste un dépistage général du bien-être. Une différence de score ne mesure pas l’autocompassion et ne prouve pas l’effet du cours.", "who5")], "Gardez une phrase ou une action à laquelle revenir.", "Qu’aimeriez-vous essayer la prochaine fois ?")
            ]),
        new(
            CourseIds.SupportSomeone,
            "Soutenir un proche sans pression",
            "Quatre étapes pour demander, écouter, proposer une aide réaliste et chercher du renfort si nécessaire.",
            "Group", "pss10", "PSS-10",
            [
                new("Commencer par une question simple", 4, [P("Choisissez un moment et un lieu calmes, si cela est sûr. Demandez si la personne souhaite parler ; vous n’avez pas à deviner ni à insister."), List("Comment allez-vous en ce moment ?", "Souhaitez-vous parler ou préférez-vous simplement ma présence ?", "Puis-je faire quelque chose pour vous aider ?"), TestsTab("Le PSS-10 évalue le stress perçu du dernier mois. Il ne mesure pas la capacité à soutenir ni l’état d’une autre personne.", "pss10"), Crisis("J'ai besoin d'aide maintenant")], "Imaginez une question ouverte, sans pression. Vous n’avez pas à la poser tout de suite.", "Comment montrer que la personne peut refuser d’en parler ?"),
                new("Écouter sans chercher tout de suite à résoudre", 4, [P("Laissez la personne finir et acceptez les silences. Vérifiez que vous avez compris au lieu de conseiller, comparer ou poser un diagnostic trop vite."), Quiz("Quelle réponse laisse le plus de place à l’autre ?", 1, "Une question ouverte laisse la personne choisir ce qu’elle souhaite partager.", "Il suffit de penser à autre chose", "Qu’est-ce qui est le plus difficile en ce moment ?", "J’ai vécu la même chose, je sais ce qu’il faut faire")], "Reformulez ce que vous avez entendu, puis demandez si vous avez bien compris.", "Qu’est-ce qui change quand vous ne donnez pas vite un conseil ?"),
                new("Proposer un choix d’aide", 4, [P("L’aide peut être simple et concrète. Demandez ce qui serait le plus utile : écouter, aider pour une tâche ou chercher des informations ensemble. Ne proposez que ce que vous pouvez réellement faire."), List("Souhaitez-vous que je vous écoute ?", "Puis-je vous aider pour une chose précise ?", "Voulez-vous chercher ensemble à qui vous adresser ?"), P("Si la personne refuse, respectez sa réponse. Vous pouvez laisser la possibilité d’en reparler plus tard.")], "Avec son accord, proposez une aide concrète ou pensez à une option pour plus tard.", "Quelle aide est possible pour vous deux ?"),
                new("Chercher du renfort et garder ses limites", 4, [P("Vous pouvez être présent sans tout porter seul ni devenir l’unique soutien. Dites clairement quand vous êtes disponible et proposez de faire appel à une personne de confiance ou à un professionnel."), P("Si la personne parle d’un danger immédiat ou ne peut pas rester en sécurité, ne gérez pas cela seul : si possible, contactez les services d’urgence ou de crise locaux. Ne promettez pas de garder secrète une menace vitale."), TestsTab("Un nouveau PSS-10 donne seulement un repère général du stress perçu ; il n’évalue pas votre soutien et ne prouve pas l’effet du cours.", "pss10")], "Choisissez une limite ou un soutien supplémentaire pour ne pas porter cela seul.", "Qui pourrait aussi vous soutenir ?")
            ]),
        new(
            CourseIds.TaskStart,
            "Commencer une tâche repoussée",
            "Trois étapes : réduire le début, choisir un moment et continuer sans se blâmer.",
            "Checklist", "who5", "WHO-5",
            [
                new("Choisir une tâche", 3, [P("La procrastination vient souvent d’un début flou ou d’un ressenti désagréable, pas de la paresse. Nommez la tâche et le premier geste visible."), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines. Il ne mesure pas cette compétence ni l’effet du cours.", "who5"), Crisis("J'ai besoin d'aide maintenant")], "Choisissez une tâche et un premier geste de cinq minutes maximum.", "Qu’est-ce qui rendrait le début plus clair ?"),
                new("Faciliter le démarrage", 3, [P("Préparez le nécessaire et choisissez un moment. Commencez cinq minutes, puis décidez si vous continuez.")], "Notez quand, où et par quoi commencer.", "Qu’est-ce qui pourrait gêner et comment simplifier ?"),
                new("Soutenir la suite", 3, [P("Faites le point sans reproche : qu’est-ce qui a aidé, qu’est-ce qui a gêné, et quelle suite est réaliste ? Parfois, il faut revoir la tâche elle-même.")], "Gardez une méthode qui vous a aidé à démarrer.", "Qu’avez-vous appris sur votre façon de commencer ?")
            ]),
        new(
            CourseIds.FlexibleStandards,
            "Le suffisamment bien peut suffire",
            "Repérez quand des exigences élevées aident et quand elles empêchent de terminer.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Voir le coût du parfait", 3, [P("Des exigences élevées sont utiles tant qu’elles ne prennent pas trop de temps, de repos ou la possibilité de finir. Repérez une règle que vous vous imposez."), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines. Il ne mesure pas cette compétence ni l’effet du cours.", "who5"), Crisis("J'ai besoin d'aide maintenant")], "Choisissez un exemple où une exigence vous bloque.", "Qu’est-ce que cette règle vous apporte et vous coûte ?"),
                new("Définir le suffisant", 3, [P("Demandez-vous à qui sert le résultat et ce qu’il doit vraiment faire. Choisissez deux ou trois critères au lieu de le retoucher sans fin.")], "Fixez une limite de finition réaliste pour une tâche.", "Que pouvez-vous cesser d’améliorer ?"),
                new("Tester un petit écart", 3, [P("Si cela vous semble sûr, laissez une petite imperfection ou arrêtez-vous quand le minuteur sonne. C’est un essai, pas une obligation de négliger la qualité.")], "Choisissez un essai doux ou observez simplement la règle.", "Qu’attendiez-vous et que s’est-il passé ?")
            ]),
        new(
            CourseIds.ThoughtLoops,
            "Quand les pensées tournent en boucle",
            "Repérez une pensée répétitive et ramenez votre attention vers ce que vous choisissez de faire.",
            "Psychology", "gad7", "GAD-7",
            [
                new("Repérer la boucle", 3, [P("Une pensée répétée peut ressembler à une recherche de solution sans apporter de réponse nouvelle. Observez quand elle revient et ce qui la déclenche."), TestsTab("Le GAD-7 évalue l’anxiété générale des deux dernières semaines ; ce n’est ni un diagnostic ni un test de cette compétence.", "gad7"), Crisis("J'ai besoin d'aide maintenant")], "Repérez un moment où une pensée tourne en boucle.", "Qu’est-ce qui déclenche souvent cette boucle ?"),
                new("Séparer pensée et fait", 3, [P("Nommez-la comme une pensée : « Je remarque la pensée que… ». Cela ne nie pas le problème ; cela évite de prendre une prévision pour un fait.")], "Nommez une pensée de façon neutre, sans la combattre.", "Qu’est-ce qui change quand vous l’appelez une pensée ?"),
                new("Revenir à ce que vous avez choisi", 3, [P("Vous n’avez pas besoin de chasser la pensée. Remarquez-la, puis revenez doucement à votre activité ; si un plan est utile, choisissez un moment et une étape.")], "Choisissez une petite action pour les dix prochaines minutes.", "Où voulez-vous ramener votre attention ?")
            ]),
        new(
            CourseIds.UncertainDecisions,
            "Choisir sans certitude complète",
            "Comparez les faits, ce qui compte pour vous et une prochaine étape réaliste.",
            "Checklist", "gad7", "GAD-7",
            [
                new("Séparer faits et suppositions", 3, [P("Dans un choix difficile, certaines informations manquent. Notez ce que vous savez, ce que vous supposez et ce qui reste inconnu."), TestsTab("Le GAD-7 évalue l’anxiété générale des deux dernières semaines ; ce n’est ni un diagnostic ni un test de cette compétence.", "gad7"), Crisis("J'ai besoin d'aide maintenant")], "Classez une question entre faits et suppositions.", "Quel fait serait le plus utile à clarifier ?"),
                new("Nommer vos priorités", 3, [P("Comparez les options selon ce qui compte pour vous : sécurité, temps, relations, ressources ou valeurs. Il n’y a pas toujours de choix parfait.")], "Choisissez deux critères importants et comparez les options.", "Que souhaitez-vous surtout préserver ?"),
                new("Choisir une prochaine étape", 3, [P("Si possible, choisissez une petite étape réversible et une date pour la réexaminer. Vous pourrez ainsi tenir compte de nouvelles informations.")], "Fixez une étape et un moment pour la réévaluer.", "Comment pourrez-vous vérifier ce choix plus tard ?")
            ]),
        new(
            CourseIds.PauseBeforeReply,
            "Faire une pause avant de répondre",
            "Repérez la tension, faites une pause et décidez si vous répondez maintenant.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Repérer la tension tôt", 3, [P("L’irritation ou l’inquiétude peut se manifester dans le corps ou le débit de parole avant que la réponse soit réfléchie. Repérez votre signal précoce."), TestsTab("Le PSS-10 évalue le stress perçu du dernier mois. Il ne mesure pas cette compétence ni l’effet du cours.", "pss10"), Crisis("J'ai besoin d'aide maintenant")], "Rappelez-vous un signal corporel ou comportemental.", "Comment savez-vous qu’il faut ralentir ?"),
                new("Prendre une courte pause", 3, [P("Si c’est sûr, différez votre réponse, sentez vos pieds au sol et nommez ce qui se passe. Vous n’avez pas à vous calmer de force tout de suite.")], "Préparez une phrase : « J’ai besoin d’un peu de temps, je répondrai plus tard. »", "Quelle pause vous semble réaliste ?"),
                new("Répondre avec une intention", 3, [P("Choisissez votre but : clarifier, demander, poser une limite ou terminer l’échange. Si la situation est dangereuse, partez et cherchez du soutien.")], "Préparez une phrase qui exprime votre objectif.", "Que souhaitez-vous faire comprendre ?")
            ]),
        new(
            CourseIds.IrritationSignals,
            "Repérer l’irritation plus tôt",
            "Reconnaissez les premiers signes, réduisez la tension et choisissez une réaction sûre.",
            "Forum", "pss10", "PSS-10",
            [
                new("Trouver un signe précoce", 3, [P("L’irritation peut signaler une tension ou un besoin, mais ne dicte pas vos actes. Observez les changements dans votre corps, vos pensées ou votre comportement."), TestsTab("Le PSS-10 évalue le stress perçu du dernier mois. Il ne mesure pas cette compétence ni l’effet du cours.", "pss10"), Crisis("J'ai besoin d'aide maintenant")], "Nommez un signe précoce.", "Que se passe-t-il souvent avant que l’irritation monte ?"),
                new("Réduire la tension sans risque", 3, [P("Si possible, éloignez-vous vers un endroit sûr et ralentissez votre respiration ou observez ce qui vous entoure. Vous n’avez pas à rester dans une dispute.")], "Choisissez une façon sûre de faire une pause.", "Comment saurez-vous qu’une pause est nécessaire ?"),
                new("Choisir la suite", 3, [P("Quand la tension baisse, nommez votre besoin : temps, clarté, aide ou limite. Vous pouvez reprendre l’échange plus tard, ou pas si ce n’est pas sûr.")], "Préparez une demande ou une action pour la prochaine fois.", "Qu’est-ce qui pourrait vous éviter d’atteindre votre limite ?")
            ]),
        new(
            CourseIds.ConflictRepair,
            "Rétablir le lien après une dispute",
            "Reconnaissez votre part, présentez des excuses sans pression et discutez d’une suite.",
            "Forum", "who5", "WHO-5",
            [
                new("Décrire un acte, pas une personne", 3, [P("Après une dispute, nommez une action précise au lieu de qualifier toute la personne. Reprendre contact n’est possible que si cela est sûr."), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines. Il ne mesure pas cette compétence ni l’effet du cours.", "who5"), Crisis("J'ai besoin d'aide maintenant")], "Décrivez votre part avec un fait.", "Qu’aimeriez-vous clarifier ?"),
                new("Présenter des excuses précises", 3, [P("Des excuses nomment l’acte et son effet possible, sans justification ni demande de pardon. Vous pouvez dire ce que vous essaierez de changer.")], "Rédigez des excuses courtes sans ajouter « mais ».", "Pour quoi êtes-vous prêt à prendre votre part ?"),
                new("Laisser de la place à la réponse", 3, [P("Laissez à l’autre la possibilité de répondre et de poser ses limites. La réconciliation n’est pas garantie ; un accord pratique peut suffire.")], "Choisissez une demande ou une limite à discuter.", "Quel résultat serait acceptable et sûr ?")
            ]),
        new(
            CourseIds.LifeTransitions,
            "S’adapter au changement à son rythme",
            "Gardez des repères familiers, nommez le changement et choisissez une étape réaliste.",
            "TrackChanges", "pss10", "PSS-10",
            [
                new("Nommer ce qui a changé", 3, [P("Un nouveau travail, un déménagement, des études ou un changement familial peuvent toucher plusieurs habitudes. Vous n’avez pas à vous adapter vite."), TestsTab("Le PSS-10 évalue le stress perçu du dernier mois. Il ne mesure pas cette compétence ni l’effet du cours.", "pss10"), Crisis("J'ai besoin d'aide maintenant")], "Nommez un changement et son effet sur votre journée.", "Qu’est-ce qui est plus difficile ou différent ?"),
                new("Garder un repère familier", 3, [P("Conservez une habitude simple qui soutient votre rythme : repas, petite marche, conversation ou rituel du soir. Adaptez-la aux nouvelles conditions.")], "Choisissez un repère pour cette semaine.", "Que pouvez-vous garder malgré le changement ?"),
                new("Faire la prochaine étape", 3, [P("Découpez l’adaptation en petites questions : quoi apprendre, qui solliciter, que peut attendre. Votre rythme peut varier.")], "Choisissez une question ou une action pour les jours à venir.", "Quel soutien rendrait le changement plus facile ?")
            ]),
        new(
            CourseIds.GriefAtYourPace,
            "Traverser le deuil à son rythme",
            "Sans échéance ni étapes obligatoires : prendre soin des besoins essentiels et trouver du soutien.",
            "Healing", "who5", "WHO-5",
            [
                new("Faire une place aux émotions", 3, [P("Après une perte, chacun ressent les choses différemment. Le deuil n’a pas de calendrier obligatoire et il n’existe pas une seule bonne façon de le vivre."), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines. Il ne mesure pas cette compétence ni l’effet du cours.", "who5"), Crisis("J'ai besoin d'aide maintenant")], "Nommez ce qui est difficile ou ce que vous ne vous sentez pas prêt à faire.", "Que souhaitez-vous vous autoriser aujourd’hui ?"),
                new("Rendre la journée faisable", 3, [P("Un jour difficile, choisissez un besoin essentiel ou une petite tâche. Vous pouvez demander à un proche de rester près de vous ou d’aider concrètement.")], "Réduisez une tâche à une étape faisable.", "De quelle attention avez-vous besoin aujourd’hui ?"),
                new("Ne pas rester seul", 3, [P("Si vous le souhaitez, trouvez une façon de vous souvenir ou de parler de la perte. Si le deuil gêne durablement le quotidien, un soutien professionnel est possible.")], "Choisissez une personne ou un service à contacter.", "Quel soutien vous ferait du bien maintenant ?")
            ]),
        new(
            CourseIds.ReturnToFocus,
            "Revenir à sa tâche après une interruption",
            "Notez la distraction, choisissez la prochaine action et reprenez doucement.",
            "TipsAndUpdates", "who5", "WHO-5",
            [
                new("Repérer l’interruption", 3, [P("Être distrait fait partie du travail. Observez ce qui vous a interrompu : notification, nouvelle pensée, fatigue ou étape floue."), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines. Il ne mesure pas cette compétence ni l’effet du cours.", "who5"), Crisis("J'ai besoin d'aide maintenant")], "Nommez une source fréquente d’interruption.", "Qu’est-ce qui interrompt le plus votre concentration ?"),
                new("Noter puis revenir", 3, [P("Notez brièvement la tâche qui vous distrait pour ne pas la garder en tête. Choisissez ensuite une action pour reprendre la tâche actuelle.")], "Faites une note et choisissez une action de cinq minutes.", "Quelle première étape vous ferait revenir ?"),
                new("Faciliter l’environnement", 3, [P("Retirez une distraction facultative et décidez quoi faire lors de la prochaine interruption. En cas de grande fatigue, une pause peut aider davantage que l’effort.")], "Modifiez un réglage de votre espace ou des notifications.", "Qu’est-ce qui vous aide à reprendre sans reproche ?")
            ]),
        new(
            CourseIds.StudyBlocks,
            "Étudier par courtes séquences",
            "Choisissez un objectif d’apprentissage, un court temps de concentration et une pause.",
            "Checklist", "pss10", "PSS-10",
            [
                new("Fixer un objectif", 3, [P("Choisissez un résultat clair pour une séance : résoudre un exercice, lire une section ou expliquer un thème. Le grand objectif peut attendre."), TestsTab("Le PSS-10 évalue le stress perçu du dernier mois. Il ne mesure pas cette compétence ni l’effet du cours.", "pss10"), Crisis("J'ai besoin d'aide maintenant")], "Notez un résultat pour une courte séance.", "Comment saurez-vous qu’elle est terminée ?"),
                new("Trouver votre rythme", 3, [P("Choisissez une durée de concentration et de pause qui vous convient. Le minuteur classique est facultatif ; adaptez le rythme à votre attention et à votre santé.")], "Essayez une courte séquence suivie d’une pause.", "Quel rythme était faisable ?"),
                new("Vérifier ce qui reste", 3, [P("Après la pause, essayez de vous rappeler l’essentiel sans regarder, puis vérifiez le support. Un oubli indique quoi revoir, pas votre valeur.")], "Nommez trois choses retenues.", "Que pourriez-vous revoir ensuite ?")
            ]),
        new(
            CourseIds.BodyNeutrality,
            "Regarder son apparence plus neutralement",
            "Moins comparer, observer sans jugement et revenir aux activités qui comptent.",
            "Healing", "who5", "WHO-5",
            [
                new("Repérer l’attention portée à l’apparence", 3, [P("Beaucoup de personnes sont parfois insatisfaites de leur apparence, mais les vérifications et comparaisons répétées peuvent épuiser. Vous n’avez pas à aimer chaque détail."), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines. Il ne mesure pas cette compétence ni l’effet du cours.", "who5"), Crisis("J'ai besoin d'aide maintenant")], "Repérez quand les pensées sur l’apparence prennent votre attention.", "Que repoussez-vous à cause de ces pensées ?"),
                new("Essayer un regard neutre", 3, [P("Au lieu de juger, décrivez ce que vous remarquez ou ce que votre corps vous permet de faire aujourd’hui. Il n’est pas nécessaire d’être reconnaissant ou satisfait.")], "Remplacez un jugement par une observation neutre.", "Quels mots sont moins durs et plus justes ?"),
                new("Revenir à ce qui compte", 3, [P("Choisissez une activité importante pour d’autres raisons : lien, études, repos ou loisir. Si les préoccupations nuisent à l’alimentation, à la santé ou au quotidien, un professionnel peut aider.")], "Reprenez une petite activité reportée.", "Qu’est-ce qui compte pour vous au-delà de l’apparence ?")
            ]),
        new(
            CourseIds.SelfWorth,
            "Votre valeur dépasse vos réussites",
            "Repérez vos rôles et qualités au-delà des résultats, puis choisissez une action qui a du sens.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Voir au-delà des résultats", 3, [P("Le travail et la réussite ne résument pas votre valeur. Pensez aux rôles, aux liens et aux qualités qui comptent indépendamment de votre productivité."), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines. Il ne mesure pas cette compétence ni l’effet du cours.", "who5"), Crisis("J'ai besoin d'aide maintenant")], "Nommez un rôle ou une qualité importante.", "Qu’est-ce qui a de la valeur en vous sans résultat ?"),
                new("Trouver un exemple concret", 3, [P("Rappelez-vous un petit moment de gentillesse, de courage, de curiosité ou de fiabilité. Un seul exemple suffit ; vous n’avez rien à prouver.")], "Trouvez un exemple récent.", "Quel geste de votre part passe souvent inaperçu ?"),
                new("Agir selon ce qui compte", 3, [P("Choisissez une action qui exprime une qualité importante, sans dépendre d’une réussite ou d’un compliment. Elle peut être très petite.")], "Faites ou planifiez cette action.", "Que dit-elle de ce qui compte pour vous ?")
            ]),
        new(
            CourseIds.SocialSteps,
            "Faire de petits pas dans les situations sociales",
            "Choisissez un contact sûr, examinez vos attentes et avancez à votre rythme.",
            "Group", "gad7", "GAD-7",
            [
                new("Choisir une situation faisable", 3, [P("Si les situations sociales inquiètent, commencez par une situation légèrement difficile mais sûre. Vous pouvez refuser une étape qui ne vous convient pas."), TestsTab("Le GAD-7 évalue l’anxiété générale des deux dernières semaines ; ce n’est ni un diagnostic ni un test de cette compétence.", "gad7"), Crisis("J'ai besoin d'aide maintenant")], "Choisissez un bref contact qui compte pour vous.", "Qu’est-ce qui semble faisable plutôt que parfait ?"),
                new("Examiner vos attentes", 3, [P("Avant le contact, notez ce que vous craignez et ce qui pourrait aussi se passer. Vous n’avez pas à prouver que votre peur est fausse.")], "Notez une attente et une autre possibilité.", "Qu’avez-vous remarqué pendant le contact ?"),
                new("Apprendre de l’expérience", 3, [P("Après, notez ce qui a aidé, ce qui a été difficile et la suite qui vous convient. Vous choisissez le rythme, les répétitions et les pauses.")], "Choisissez de répéter, réduire ou suspendre l’étape.", "Qu’est-ce qui vous a aidé à vous sentir plus en sécurité ?")
            ]),
        new(
            CourseIds.AppointmentPreparation,
            "Préparer un rendez-vous important",
            "Rassemblez vos questions, précisez votre priorité et clarifiez la suite avec un professionnel.",
            "Forum", "pss10", "PSS-10",
            [
                new("Nommer l’essentiel", 3, [P("Avant le rendez-vous, décidez de la question la plus importante et de ce que vous souhaitez aborder. Vous n’avez pas à vous diagnostiquer."), TestsTab("Le PSS-10 évalue le stress perçu du dernier mois. Il ne mesure pas cette compétence ni l’effet du cours.", "pss10"), Crisis("J'ai besoin d'aide maintenant")], "Écrivez votre sujet principal en une phrase.", "Que ne voulez-vous pas oublier de demander ?"),
                new("Préparer de courtes notes", 3, [P("Si cela aide, notez le début du problème, les changements et les médicaments ou questions utiles. Vous pouvez venir avec un proche si vous le souhaitez.")], "Préparez jusqu’à trois questions ou observations.", "Quelles notes faciliteraient votre échange ?"),
                new("Clarifier le plan", 3, [P("Demandez au professionnel d’expliquer les mots inconnus et la prochaine étape. Vous pouvez demander à nouveau ou dire que vous n’êtes pas prêt à décider.")], "Préparez une phrase pour demander une précision ou du temps.", "Qu’est-ce qui vous aiderait à comprendre le plan ?")
            ]),
        new(
            CourseIds.WaitingForAnswer,
            "Traverser l’attente d’une réponse",
            "Limitez les vérifications, gardez vos habitudes et choisissez ce qui dépend de vous.",
            "Psychology", "gad7", "GAD-7",
            [
                new("Séparer attente et contrôle", 3, [P("Attendre une réponse peut prendre toute l’attention, même si vous ne pouvez pas l’accélérer. Séparez ce que vous pouvez faire de ce qui échappe à votre contrôle."), TestsTab("Le GAD-7 évalue l’anxiété générale des deux dernières semaines ; ce n’est ni un diagnostic ni un test de cette compétence.", "gad7"), Crisis("J'ai besoin d'aide maintenant")], "Notez un élément dans chaque catégorie.", "Que pouvez-vous faire et que faut-il attendre ?"),
                new("Fixer une heure pour vérifier", 3, [P("Choisissez une heure raisonnable pour consulter à nouveau vos messages ou le statut. Entre-temps, reprenez une tâche ordinaire ou reposez-vous.")], "Fixez le prochain moment de vérification.", "Qu’est-ce qui pourrait limiter les vérifications automatiques ?"),
                new("Préparer les deux possibilités", 3, [P("Choisissez une petite suite en cas de réponse comme de délai. Ce n’est pas une prédiction ; cela vous rend un choix pendant l’attente.")], "Fixez une date pour relancer si nécessaire.", "Sur quoi voulez-vous vous appuyer en attendant ?")
            ]),
        new(
            CourseIds.AskForHelp,
            "Demander une aide précise",
            "Nommez votre besoin, la personne à solliciter et une demande faisable.",
            "Group", "who5", "WHO-5",
            [
                new("Identifier votre besoin", 3, [P("Une demande concrète est plus facile à entendre : du temps, une conversation, une information ou de l’aide pour une tâche. Vous n’avez pas à tout gérer seul."), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines. Il ne mesure pas cette compétence ni l’effet du cours.", "who5"), Crisis("J'ai besoin d'aide maintenant")], "Nommez un besoin sans le justifier.", "Quelle aide changerait un peu la situation ?"),
                new("Choisir une personne et des mots", 3, [P("Pensez à qui pourrait aider pour ce besoin. Une demande brève, avec une action et un moment, facilite la réponse.")], "Rédigez une phrase pour demander de l’aide.", "Qui pourriez-vous solliciter, et quand ?"),
                new("Laisser place à différentes réponses", 3, [P("La personne peut accepter, proposer autre chose ou refuser. Votre besoin reste important ; vous pouvez solliciter quelqu’un d’autre ou un service.")], "Choisissez une autre ressource de soutien.", "Comment prendre soin de vous après la demande ?")
            ]),
        new(
            CourseIds.CaregiverLimits,
            "Aider un proche sans s’épuiser",
            "Partagez les tâches, nommez vos limites et cherchez d’autres soutiens.",
            "Group", "pss10", "PSS-10",
            [
                new("Voir l’ampleur de l’aide", 3, [P("Soutenir un proche peut inclure beaucoup de tâches invisibles. Listez les principales et demandez-vous lesquelles exigent vraiment votre présence."), TestsTab("Le PSS-10 évalue le stress perçu du dernier mois. Il ne mesure pas cette compétence ni l’effet du cours.", "pss10"), Crisis("J'ai besoin d'aide maintenant")], "Nommez une tâche à discuter ou à partager.", "Qu’est-ce qui vous épuise le plus en ce moment ?"),
                new("Nommer une limite", 3, [P("Une limite n’est pas abandonner quelqu’un. Elle décrit honnêtement le temps, l’énergie ou l’aide que vous pouvez offrir sans risque.")], "Formulez une limite dans votre soutien.", "Comment la dire clairement et calmement ?"),
                new("Trouver d’autres soutiens", 3, [P("Pensez aux personnes, services ou solutions pratiques qui pourraient partager la charge. Si l’aide ne peut pas être assurée sans risque, cherchez un soutien professionnel ou d’urgence.")], "Choisissez un soutien supplémentaire.", "Qui pourriez-vous contacter cette semaine ?")
            ]),
        new(
            CourseIds.LowEnergyRoutine,
            "Un programme doux pour les jours sans énergie",
            "Gardez le minimum nécessaire, réduisez le premier pas et prévoyez du repos.",
            "TipsAndUpdates", "who5", "WHO-5",
            [
                new("Choisir le minimum", 3, [P("Un jour où l’énergie manque, vous n’avez pas à suivre votre programme habituel. Choisissez une tâche nécessaire et ce qui peut attendre."), TestsTab("Le WHO-5 est un dépistage général du bien-être des deux dernières semaines. Il ne mesure pas cette compétence ni l’effet du cours.", "who5"), Crisis("J'ai besoin d'aide maintenant")], "Réduisez la liste à un point important.", "Qu’est-ce qui ne peut vraiment pas attendre aujourd’hui ?"),
                new("Réduire le premier pas", 3, [P("Découpez la tâche en action de deux minutes et préparez le nécessaire. Si c’est encore trop, demandez de l’aide.")], "Choisissez le plus petit pas sûr.", "Qu’est-ce qui le rendrait plus facile ?"),
                new("Inclure du repos", 3, [P("Prévoyez une courte pause sans devoir la mériter. Si le manque d’énergie ou le moral bas gêne durablement le quotidien, un soutien professionnel est possible.")], "Choisissez une pause simple ou une personne à contacter.", "Qu’est-ce qui vous aiderait à ne pas rester seul ?")
            ]),
        new(
            CourseIds.AfterDifficultTalk,
            "Se remettre après une conversation difficile",
            "Revenez au présent, séparez faits et suppositions, puis choisissez une suite sûre.",
            "Psychology", "pss10", "PSS-10",
            [
                new("Faire baisser la tension", 3, [P("Après une conversation difficile, le corps peut avoir besoin de temps. Trouvez un appui, regardez autour de vous et nommez l’endroit où vous êtes. Inutile de décider tout de suite qui a raison."), TestsTab("Le PSS-10 évalue le stress perçu du dernier mois. Il ne mesure pas cette compétence ni l’effet du cours.", "pss10"), Crisis("J'ai besoin d'aide maintenant")], "Faites une courte pause et observez ce qui vous entoure.", "Qu’est-ce qui vous aide à revenir ici et maintenant ?"),
                new("Séparer paroles et conclusions", 3, [P("Notez séparément ce qui a été dit ou fait et ce que vous supposez. Cela ne nie pas vos émotions ; cela aide à choisir la suite.")], "Séparez un fait et une interprétation.", "Que savez-vous et que supposez-vous ?"),
                new("Choisir si vous poursuivez", 3, [P("Vous pouvez clarifier, demander du temps ou ne pas reprendre contact. En cas de menace ou de contrôle, ne revenez pas seul à cette conversation.")], "Choisissez une option sûre pour la prochaine fois.", "De quelle limite ou de quel soutien avez-vous besoin ?")
            ]),
    ];
}
