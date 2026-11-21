using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Articles;

public static partial class ArticleContent
{
    private static readonly Course[] CoursesDe =
    [
        new(
            CourseIds.Sleep,
            "Schlafen ohne Tabletten",
            "Sieben Tage kognitive Verhaltenstherapie bei Schlaflosigkeit, der am besten untersuchte Weg zurück zum Schlaf",
            "Bedtime",
            "isi",
            "ISI-7",
            [
                new(
                    "Wie Schlaf funktioniert",
                    4,
                    [
                        P("Schlaf lässt sich nicht durch Anstrengung „einschalten“. Zwei Kräfte bereiten ihn vor: der Schlafdruck, der sich den ganzen Tag über im Wachsein aufbaut, und die innere Uhr, die uns jeden Tag zu denselben Zeiten müde und wach macht."),
                        P("Bei Schlaflosigkeit geraten beide Kräfte durcheinander: Man geht früher ins Bett, um „nachzuholen“, liegt lange wach, schläft tagsüber, steht zu unterschiedlichen Zeiten auf. Der Schlafdruck hat keine Zeit, sich aufzubauen, und die Uhr kommt durcheinander."),
                        Cycle("Der Kreislauf der Schlaflosigkeit", "Eine schlechte Nacht", "Sorge: „Ich werde wieder nicht schlafen“", "Krampfhaft versuchen einzuschlafen", "Anspannung vertreibt den Schlaf"),
                        P("Dieser Kurs beruht auf der kognitiven Verhaltenstherapie bei Schlaflosigkeit (KVT-I). Medizinische Leitlinien empfehlen sie an erster Stelle, noch vor Schlaftabletten: Ihre Wirkung hält nach dem Kurs an."),
                        Warning("Wann du zuerst zum Arzt gehen solltest"),
                        List(
                            "Lautes Schnarchen, Atempausen im Schlaf, starke Tagesmüdigkeit",
                            "Unangenehme Empfindungen in den Beinen am Abend, die dich dazu bringen, dich zu bewegen",
                            "Schlaflosigkeit zusammen mit gedrückter Stimmung seit mehr als zwei Wochen",
                            "Du fährst Auto oder bedienst Maschinen und bist tagsüber sehr müde")
                    ],
                    "Notiere jeden Morgen: wann du ins Bett gegangen bist, ungefähr wann du eingeschlafen bist, wie oft du aufgewacht bist, wann du aufgestanden bist und wie du von 0 bis 10 geschlafen hast. Nachts keine Uhr, ungefähr, nach Gefühl.",
                    "Wann gehst du gewöhnlich ins Bett und stehst auf? Was stört deinen Schlaf am meisten?"),
                new(
                    "Das Bett ist zum Schlafen da",
                    4,
                    [
                        P("Wenn du oft wach im Bett liegst, dir dort Sorgen machst oder aufs Handy schaust, verbindet das Gehirn das Bett mit Wachsein. Deshalb kannst du im Sessel einnicken und hellwach sein, sobald du dich hinlegst."),
                        H("Regeln, die die Verbindung wiederherstellen"),
                        List(
                            "Geh nur ins Bett, wenn du schläfrig bist, nicht einfach müde",
                            "Wenn du etwa 20 Minuten nicht schlafen kannst, steh auf und tu bei gedämpftem Licht etwas Ruhiges. Komm zurück, wenn du schläfrig bist",
                            "Das Bett ist nur für Schlaf und Intimität: kein Handy, keine Serien, keine Arbeit",
                            "Steh jeden Tag zur gleichen Zeit auf, auch nach einer schlechten Nacht und am Wochenende",
                            "Mach keinen Mittagsschlaf, und wenn es wirklich sein muss, nicht länger als 20 Minuten und vor 15 Uhr"),
                        Quiz("Die Nacht war schlecht. Was ist morgens besser?", 1, "Eine feste Aufstehzeit ist der wichtigste Anker des Schlafs. Wenn du ausschläfst, ist der Schlafdruck am Abend geringer, und auch die nächste Nacht wird schwer.", "Ausschlafen, um sich zu erholen", "Zur gewohnten Zeit aufstehen", "Aufstehen und tagsüber einen ausgiebigen Mittagsschlaf machen")
                    ],
                    "Wähle eine Aufstehzeit, die du an allen sieben Tagen einhalten kannst, und steh zu dieser Zeit auf. Wenn du etwa 20 Minuten nicht schlafen kannst, steh auf.",
                    "Welche Aufstehzeit hast du gewählt? Was war an der Regel „aufstehen, wenn du nicht schlafen kannst“ schwer?"),
                new(
                    "Das Schlaffenster",
                    5,
                    [
                        P("Je länger man wach im Bett liegt, desto flacher und unterbrochener wird der Schlaf. Eine Technik namens Schlafkompression hilft: Die Zeit im Bett wird an die tatsächliche Schlafdauer angenähert."),
                        H("Wie du das Fenster berechnest"),
                        List(
                            "Berechne aus deinen Notizen der letzten Tage, wie lange du im Durchschnitt schläfst",
                            "Rechne 30 Minuten dazu: Das ist deine Zeit im Bett, aber nicht weniger als sechs Stunden",
                            "Zähle sie von deiner gewählten Aufstehzeit zurück: So ergibt sich deine Zubettgehzeit",
                            "Geh nicht vor dieser Zeit ins Bett, auch wenn du es sehr möchtest"),
                        P("In den ersten Tagen wirst du müde sein: Das heißt, der Schlafdruck baut sich auf. Wenn du nach einer Woche die meiste Zeit im Bett schläfst, kann das Fenster um 15 Minuten verlängert werden."),
                        Warning("Vorsicht"),
                        P("Komprimiere den Schlaf nicht, wenn du eine bipolare Störung oder Epilepsie hast, schwanger bist oder wenn Müdigkeit das Autofahren oder die Arbeit gefährlich macht. Besprich deinen Schlaf in diesen Fällen mit einer Ärztin oder einem Arzt.")
                    ],
                    "Berechne dein Schlaffenster und halte es bis zum Ende des Kurses ein: nicht vor deiner Zubettgehzeit ins Bett, zur gleichen Zeit aufstehen.",
                    "Wie sieht dein Schlaffenster aus? Wie lief die erste Nacht damit?"),
                new(
                    "Ein Abend, der auf den Schlaf vorbereitet",
                    4,
                    [
                        P("Schlaf kommt leichter, wenn Körper und Geist Zeit haben, langsamer zu werden. Die Stunde vor dem Schlafengehen ist die Brücke vom Tag zum Schlaf."),
                        H("Was hilft"),
                        List(
                            "Eine Stunde vor dem Schlafengehen: gedämpftes Licht und ruhige Tätigkeiten ohne Bildschirme",
                            "Verzichte mindestens 6 Stunden vor dem Schlafengehen auf Kaffee, starken Tee und Energydrinks; wenn sie deinen Schlaf stören, hör früher damit auf",
                            "Alkohol hilft beim Einschlafen, macht den Schlaf aber flach und weckt gegen Morgen",
                            "Ein schweres Abendessen 2–3 Stunden vor dem Schlafengehen",
                            "Morgens mindestens 15 Minuten Tageslicht: Es stellt die innere Uhr"),
                        P("Ein-Minuten-Plan: Wähle, wann deine Ruhephase beginnt, und eine ruhige Tätigkeit, zum Beispiel ein paar Seiten lesen. Wenn keine Stunde frei ist, wähle vorher eine kürzere Variante. Zum Beispiel: „Nach meinen Abendaufgaben dimme ich das Licht und lese ein wenig.“"),
                        H("Entspannen vor dem Schlafen"),
                        P("Langsames Atmen mit langer Ausatmung senkt die Anspannung. Probier es jetzt."),
                        Breathe("Auf 4 einatmen, auf 6 ausatmen")
                    ],
                    "Probiere deinen Plan heute Abend: Nimm dir nach Möglichkeit Zeit für ruhige Tätigkeiten vor dem Schlafen; wenn keine Stunde frei ist, nutze die kurze Variante. Leg das Handy aus dem Bett und lass wichtige Benachrichtigungen aktiv.",
                    "Was gehört zu deinem Abendritual? Was hat sich als schwer erwiesen?"),
                new(
                    "Gedanken, die wach halten",
                    4,
                    [
                        P("Der Kopf fängt oft gerade im Bett an zu arbeiten: Tagsüber war keine Zeit für Gedanken. Deshalb hilft es, ihnen früher Zeit zu geben."),
                        H("Zeit für Gedanken"),
                        List(
                            "Nimm dir abends, ein paar Stunden vor dem Schlafengehen, 15 Minuten",
                            "Schreib alles auf, was dich beschäftigt, und zu jedem Punkt einen nächsten Schritt oder „im Moment kann ich nichts tun“",
                            "Wenn der Gedanke im Bett zurückkommt, sag dir: „Das habe ich aufgeschrieben, darum kümmere ich mich morgen“"),
                        Quiz("Im Bett denkst du: „Wenn ich nicht schlafe, vermassle ich morgen alles.“ Was ist näher an der Wahrheit?", 1, "Der Gedanke übertreibt. Nach einer schlechten Nacht ist es schwerer, aber die meisten Menschen erledigen ihre Aufgaben trotzdem. Je stärker die Angst vor morgen, desto schwerer ist das Einschlafen.", "Es stimmt, das Scheitern ist unvermeidlich", "Nach einer schlechten Nacht ist es schwerer, aber das Wichtigste schaffe ich meistens", "Besser gar nicht ins Bett gehen"),
                        Practice(TechniqueId.ThoughtDefusion, "Abstand zu einem Gedanken")
                    ],
                    "Nimm dir jeden Abend 15 Minuten, um aufzuschreiben, was dich beschäftigt, und nimm diese Gedanken nicht mit ins Bett.",
                    "Welche Gedanken kommen nachts am häufigsten? Hat das Aufschreiben geholfen?"),
                new(
                    "Aufhören, gegen den Schlaf zu kämpfen",
                    4,
                    [
                        P("Je mehr du versuchst zu schlafen, desto schlechter klappt es. Der Schlaf ist wie ein scheuer Vogel: Er kommt, wenn niemand ihn jagt."),
                        H("Was hilft, die Kontrolle loszulassen"),
                        List(
                            "Stell die Uhr außer Sichtweite: „Noch fünf Stunden“ zu zählen macht wach",
                            "Erlaube dir, nicht zu schlafen: „Ich liege hier und ruhe mich aus, der Schlaf kommt, wann er kommt“",
                            "Eine schlechte Nacht ist keine Katastrophe: Der Körper erholt sich auch nach unvollständigem Schlaf",
                            "Sag wegen einer schlechten Nacht keine Pläne ab: So bestimmt die Schlaflosigkeit nicht dein Leben"),
                        P("Vergleiche deine Notizen der ersten Tage mit jetzt: Wie haben sich die Einschlafzeit, die Zahl der Aufwachphasen und die Bewertung des Schlafs verändert?")
                    ],
                    "Halte die Uhr nachts außer Sichtweite. Lebe den Tag nach einer schlechten Nacht wie gewohnt.",
                    "Was hat sich laut deinen Notizen in diesen Tagen an deinem Schlaf verändert?"),
                new(
                    "Bilanz und Plan",
                    4,
                    [
                        P("In einer Woche hast du den Kern der KVT bei Schlaflosigkeit durchlaufen. Der Schlaf erholt sich allmählich: Viele Menschen bemerken in zwei bis vier Wochen eine Besserung, wenn sie sich an die Regeln halten."),
                        H("Was du beibehalten solltest"),
                        List(
                            "Eine Aufstehzeit an jedem Tag",
                            "Nur schläfrig ins Bett gehen und aufstehen, wenn du nicht schlafen kannst",
                            "Wenn du den größten Teil der Nacht schläfst, das Fenster um 15 Minuten pro Woche verlängern",
                            "Das Abendritual und die Zeit für Gedanken"),
                        H("Wenn die Schlaflosigkeit zurückkommt"),
                        P("Nach Stress, Krankheit oder Reisen kann der Schlaf wieder aus dem Takt geraten. Das ist normal: Kehr zu den Regeln dieses Kurses zurück, und er erholt sich schneller als beim ersten Mal."),
                        P("Mach den ISI-7-Index noch einmal und vergleiche ihn mit deinem Ergebnis vom Anfang. Wenn es keine Besserung gibt, geh zu einer Ärztin oder einem Arzt: Es gibt Schlafspezialisten, die KVT-I anbieten."),
                        TestsTab("ISI-7-Index", "isi")
                    ],
                    "Schreib deinen Plan auf, falls der Schlaf wieder aus dem Takt gerät.",
                    "Was hat dir im Kurs am meisten geholfen? Was wirst du beibehalten?")
            ]),
        new(
            CourseIds.Anxiety,
            "Angst im Griff",
            "Sechs Tage: verstehen, wie Angst funktioniert, den Körper beruhigen, beängstigende Gedanken prüfen und einen ersten Schritt auf die Angst zu machen",
            "Psychology",
            "gad7",
            "GAD-7",
            [
                new(
                    "Wie Angst funktioniert",
                    4,
                    [
                        P("Angst ist ein Alarm, der vor Gefahr warnen soll. Schwierig wird es, wenn er zu oft, zu laut losgeht und lange nicht verstummt."),
                        Cycle("Der Angstkreislauf", "Ein beängstigender Gedanke", "Angst im Körper", "Vermeiden oder ein Sicherheitsnetz", "Erleichterung für einen Moment", "Das Gehirn lernt: „Es war gefährlich“"),
                        P("Die Angst wird nicht von der Furcht selbst am Leben gehalten, sondern von dem, was wir tun, um sie nicht zu spüren: meiden, nachprüfen, uns rückversichern, Gedanken wälzen. Schritt für Schritt bearbeitet der Kurs jedes Glied dieses Kreislaufs."),
                        P("Zu Beginn des Kurses lohnt es sich, die Skala GAD-7 auszufüllen: Am Ende vergleichst du das Ergebnis."),
                        TestsTab("Skala GAD-7", "gad7")
                    ],
                    "Achte heute dreimal, wenn du Angst spürst, darauf: was passiert ist, was der Gedanke war, was der Körper gespürt hat und was du getan hast.",
                    "Wann und wo zeigt sich die Angst am häufigsten?"),
                new(
                    "Den Körper beruhigen",
                    4,
                    [
                        P("Wenn die Angst stark ist, kann man schwer mit Gedanken streiten. Zuerst hilft es, den Körper zu beruhigen: Eine langsame Ausatmung aktiviert das System, das die Kampf-oder-Flucht-Reaktion bremst."),
                        Breathe("Auf 4 einatmen, auf 6 ausatmen"),
                        P("Wenn die Angst stark ist und sich alles unwirklich anfühlt, hol deine Aufmerksamkeit über die Sinne in die Gegenwart zurück."),
                        Practice(TechniqueId.Grounding, "Erdung 5-4-3-2-1"),
                        P("Wichtig: Atmen ist kein Mittel, die Angst um jeden Preis loszuwerden. Es hilft, den Höhepunkt zu überstehen, nicht, Situationen zu meiden.")
                    ],
                    "Zweimal am Tag zwei Minuten langsam atmen, auch wenn du ruhig bist: So ist die Fähigkeit da, wenn du sie brauchst.",
                    "Was hast du in deinem Körper bemerkt, als du langsam geatmet hast?"),
                new(
                    "Einen beängstigenden Gedanken prüfen",
                    5,
                    [
                        P("Ängstliche Gedanken klingen wie Tatsachen: „Ich blamiere mich“, „es passiert etwas Schreckliches“. Aber es sind Vorhersagen, und man kann sie prüfen."),
                        H("Fragen an den Gedanken"),
                        List(
                            "Welche Fakten sprechen für diesen Gedanken, und welche dagegen?",
                            "Was ist in ähnlichen Fällen früher passiert?",
                            "Was ist am wahrscheinlichsten, und nicht am beängstigendsten?",
                            "Wenn das Schlimmste eintritt, wie werde ich damit fertig?",
                            "Was würde ich einem Freund mit diesem Gedanken sagen?"),
                        Quiz("„Ich werde es bestimmt vermasseln.“ Welche Denkfalle ist das?", 1, "Das ist Wahrsagen: Der Gedanke behandelt etwas, das noch nicht passiert ist, als Tatsache.", "Gedankenlesen", "Wahrsagen", "Das Positive abwerten"),
                        Practice(TechniqueId.ThoughtRecord, "Gedankenprotokoll")
                    ],
                    "Prüfe heute einmal einen ängstlichen Gedanken mit einem Gedankenprotokoll.",
                    "Welchen Gedanken hast du geprüft? Wie sehr hast du ihm vorher und nachher geglaubt?"),
                new(
                    "Sorgenzeit",
                    4,
                    [
                        P("Sich Sorgen zu machen fühlt sich nützlich an: „Wenn ich mehr nachdenke, bin ich vorbereitet.“ Tatsächlich führt Grübeln selten zu einer Lösung und hält die Angst hoch."),
                        Quiz("Wie unterscheidest du Lösen vom Kreisen?", 0, "Lösen bewegt sich auf einen Schritt zu: Was kann ich tun, und wann. Kreisen bringt neue „Was, wenn“ hervor.", "Lösen endet mit einem Schritt, Kreisen mit einem neuen „Was, wenn“", "Kreisen dauert länger", "Gar nicht"),
                        H("Wie du Sorgen verschiebst"),
                        List(
                            "Wähle 15–20 Minuten am Tag, nicht vor dem Schlafengehen",
                            "Wenn eine Sorge zu einer anderen Zeit kommt, schreib das Thema in einer Zeile auf und sag dir: „Darüber denke ich in meiner Sorgenzeit nach“",
                            "Geh in deiner Sorgenzeit die Liste durch: Plane einen Schritt für das, was du tun kannst, lass los, was du nicht tun kannst",
                            "Oft wirkt das Thema zur vereinbarten Zeit nicht mehr wichtig"),
                        Practice(TechniqueId.ThoughtDefusion, "Abstand zu einem Gedanken"),
                        P("Wenn du die Nachrichten aus Unsicherheit immer wieder öffnest, notiere deine konkrete Frage und überlege, ob du jetzt handeln musst. Wenn nicht, lege fest, wann du wieder nachsiehst."),
                        See(ArticleIds.NewsLoop, "Wenn Nachrichten nicht loslassen")
                    ],
                    "Leg dir eine Sorgenzeit fest und verschiebe ängstliche Gedanken auf sie.",
                    "Ist es dir gelungen, Sorgen zu verschieben? Was ist mit den Themen bis zur vereinbarten Zeit passiert?"),
                new(
                    "Sicherheitsnetze und Vermeidung",
                    4,
                    [
                        P("Am stärksten hält die Vermeidung die Angst am Leben. Sie kann offen sein (ich gehe nicht hin, ich rufe nicht an) oder versteckt: Sicherheitsnetze, mit denen man eine Situation übersteht."),
                        Check("Habe ich Sicherheitsnetze?", 2, "Du hast mehrere Sicherheitsnetze. Sie halten die Angst am Leben: Das Gehirn glaubt, alles sei nur dank ihnen gut gegangen. Versuch, in einer leichten Situation auf eines zu verzichten.", "Du hast wenige Sicherheitsnetze. Achte auch darauf, was du ganz meidest.", "Ich habe „für alle Fälle“ eine Tablette, Wasser oder ein geladenes Handy dabei", "Ich gehe nur in Begleitung an schwierige Orte", "Ich setze mich in die Nähe des Ausgangs", "Ich lenke mich ab, um die Angst nicht zu bemerken", "Ich prüfe oder frage viele Male nach"),
                        P("Der Ausweg ist, dem Gefürchteten schrittweise zu begegnen und auf Sicherheitsnetze zu verzichten. Dann lernt das Gehirn aus Erfahrung, dass das Befürchtete nicht eintritt oder erträglich ist.")
                    ],
                    "Mach eine Liste von drei bis fünf Situationen, die du meidest, von der leichtesten bis zur schwierigsten.",
                    "Welche Situation von der Liste bist du bereit, als Erstes zu versuchen?"),
                new(
                    "Der erste Schritt und ein Plan",
                    4,
                    [
                        P("Der wirksamste Weg, Angst zu schwächen, ist die Exposition: der Angst schrittweise begegnen. Du musst nicht gleich zum Beängstigendsten gehen: Fang mit einem leichten Schritt an und prüfe eine Vorhersage."),
                        List(
                            "Schreib vor dem Schritt auf, was du befürchtest und wie sicher du bist, dass es eintritt",
                            "Mach den Schritt ohne Sicherheitsnetze und bleib in der Situation, bis du die Vorhersage geprüft hast",
                            "Schreib danach auf, was wirklich passiert ist"),
                        Ladder("Angstleiter"),
                        H("Was du beibehalten solltest"),
                        List(
                            "Langsames Atmen auf dem Höhepunkt der Angst",
                            "Gedanken prüfen und die Sorgenzeit",
                            "Alle paar Tage Schritte auf der Angstleiter"),
                        P("Füll die Skala GAD-7 noch einmal aus und vergleiche mit dem Anfang. Wenn die Angst stark ist oder dein Leben stört, wende dich an eine Psychotherapeutin: KVT bei Angst ist gut untersucht."),
                        TestsTab("Skala GAD-7", "gad7")
                    ],
                    "Mach den ersten Schritt auf deiner Angstleiter und schreib auf, was passiert ist.",
                    "Was hattest du vorhergesagt, und was ist wirklich passiert?")
            ]),
        new(
            CourseIds.Mood,
            "Raus aus der Antriebslosigkeit",
            "Sechs Tage Verhaltensaktivierung: kleine Schritte, um Kraft und das, was Freude macht, zurückzuholen",
            "Cloud",
            "phq9",
            "PHQ-9",
            [
                new(
                    "Der Kreislauf der Untätigkeit",
                    4,
                    [
                        P("Wenn die Stimmung bei null ist, ist es natürlich, weniger zu tun: keine Kraft, nichts reizt. Aber je weniger wir tun, desto weniger gibt es im Leben, was Freude und das Gefühl „ich habe es geschafft“ bringt, und die Stimmung sinkt noch tiefer."),
                        Cycle("Der Kreislauf der Untätigkeit", "Keine Kraft", "Ich tue weniger", "Weniger Freude und Erfolge", "Noch weniger Kraft"),
                        P("Verhaltensaktivierung durchbricht diesen Kreislauf von der anderen Seite: nicht warten, bis du Lust hast, sondern kleine Schritte machen, nach denen Kraft und Lust allmählich zurückkehren. Sie ist eine der am besten untersuchten Hilfen bei Depression."),
                        P("Füll zu Beginn des Kurses die Skala PHQ-9 aus: Am Ende vergleichst du das Ergebnis."),
                        TestsTab("Skala PHQ-9", "phq9"),
                        Warning("Wenn Gedanken an den Tod auftauchen"),
                        P("Wenn du Gedanken hast, dass es besser wäre, wenn es dich nicht gäbe, bleib damit nicht allein: Dieser Kurs ersetzt nicht die Hilfe einer Fachperson."),
                        Crisis("Ich brauche jetzt Hilfe")
                    ],
                    "Achte heute und morgen darauf, was du tust, und bewerte deine Stimmung mehrmals am Tag von 0 bis 10.",
                    "Wie verlaufen deine Tage gerade? Was hast du in letzter Zeit aufgehört zu tun?"),
                new(
                    "Was die Stimmung hebt",
                    4,
                    [
                        P("Schau dir deine Beobachtungen an: In welchen Momenten war die Stimmung etwas besser? Oft ist es etwas Kleines: ein Gespräch, ein Spaziergang, eine Dusche, eine erledigte Aufgabe."),
                        H("Zwei Arten nützlicher Tätigkeiten"),
                        List(
                            "Angenehme: was Freude bringt, auch wenn sie schwach ist — Musik, gutes Essen, Sonne",
                            "„Ich habe es geschafft“-Tätigkeiten: was ein Gefühl des Erreichten hinterlässt — abwaschen, eine E-Mail beantworten"),
                        P("Bei Depression ist die Freude an angenehmen Dingen schwächer als früher. Das ist normal: Wichtig ist, es zu tun, und nicht auf die alte Freude zu warten.")
                    ],
                    "Mach eine Liste mit zehn Tätigkeiten: fünf angenehmen und fünf „Ich habe es geschafft“. Je kleiner und einfacher, desto besser.",
                    "Was steht auf deiner Liste? Gab es etwas, das deine Stimmung ein wenig gehoben hat?"),
                new(
                    "Kleine Schritte",
                    4,
                    [
                        P("Große Pläne schrecken in der Antriebslosigkeit ab und werden nicht umgesetzt. Es hilft, Dinge zu zerlegen: nicht „die Wohnung putzen“, sondern „drei Sachen vom Tisch räumen“."),
                        List(
                            "Wähle für heute eine Tätigkeit von der Liste",
                            "Zerlege sie bis zu einem Schritt, der fünf Minuten dauert",
                            "Leg Zeit und Ort fest: „nach dem Frühstück, in der Küche“",
                            "Notiere danach, wie sich deine Stimmung verändert hat"),
                        Practice(TechniqueId.SmallStep, "Ein kleiner Schritt"),
                        P("Das Ziel ist nicht, dass sich die Stimmung sofort hebt. Bleibt sie gleich, achte darauf, wie machbar die Tätigkeit war, und passe den nächsten Schritt an."),
                        See(ArticleIds.SmallStepReview, "Wenn ein kleiner Schritt die Stimmung nicht hebt")
                    ],
                    "Mach jeden Tag zur festgelegten Zeit eine angenehme Tätigkeit und eine „Ich habe es geschafft“-Tätigkeit.",
                    "Was hast du geschafft? Wie hat sich deine Stimmung danach verändert?"),
                new(
                    "„Ich habe keine Lust“",
                    4,
                    [
                        P("Das Haupthindernis ist der Gedanke „Ich habe keine Lust, ich mache es, wenn ich Kraft habe“. In der Antriebslosigkeit kommt die Lust nach dem Handeln, nicht davor."),
                        Quiz("Keine Kraft, und für heute ist ein Spaziergang geplant. Was ist besser?", 1, "In der Antriebslosigkeit kommt die Lust nach dem Handeln zurück. Selbst fünf Minuten geben Körper und Stimmung das Signal „ich habe etwas getan“.", "Warten, bis ich Lust habe", "Mindestens fünf Minuten hinausgehen", "Aufs Wochenende verschieben"),
                        H("Andere bremsende Gedanken"),
                        List(
                            "„Es bringt nichts“: Prüf hinterher — ist irgendetwas auch nur ein bisschen anders?",
                            "„Das ist zu wenig“: Genau aus kleinen Schritten besteht der Weg hinaus",
                            "„Früher habe ich mehr geschafft“: Vergleich dich mit gestern, nicht mit deinem früheren Ich"),
                        Practice(TechniqueId.SelfCompassion, "Freundliche Worte an dich selbst")
                    ],
                    "Wenn du keine Lust hast, mach wenigstens eine Fünf-Minuten-Version dessen, was du geplant hast.",
                    "Welcher Gedanke hält dich am häufigsten vom Anfangen ab? Was hat dir geholfen, ihn zu umgehen?"),
                new(
                    "Die Menschen um dich herum",
                    4,
                    [
                        P("In der Antriebslosigkeit möchte man sich von allen abschotten. Doch der Kontakt mit Menschen ist eines der stärksten Mittel gegen gedrückte Stimmung, auch wenn er gerade nicht so viel Freude macht wie früher."),
                        List(
                            "Schreib einem Menschen, mit dem du eine Weile keinen Kontakt hattest",
                            "Ein kurzes Treffen oder ein Anruf ist besser als keines",
                            "Du musst nicht alles erklären: „Es ist gerade schwer, lass uns einfach spazieren gehen“",
                            "Wenn die Kraft fehlt, wähle Menschen, mit denen es leicht ist"),
                        Practice(TechniqueId.SmallStep, "Ein kleiner Schritt"),
                        P("Du musst nicht alles erzählen: Bitte konkret um etwas, etwa Zuhören, Gesellschaft oder Hilfe bei einer Aufgabe."),
                        See(ArticleIds.SupportRequest, "Um Unterstützung bitten")
                    ],
                    "Melde dich in den nächsten zwei Tagen bei mindestens einem Menschen.",
                    "Bei wem hast du dich gemeldet? Wie war es?"),
                new(
                    "Was mir wichtig ist",
                    4,
                    [
                        P("Damit die Schritte nicht zur Pflicht werden, hilft es, sie mit dem zu verbinden, was dir wichtig ist: nahestehende Menschen, Gesundheit, Arbeit, Kreativität, Natur."),
                        List(
                            "Wähle einen Bereich, der dir wichtig ist",
                            "Überleg, wer du in diesem Bereich sein möchtest",
                            "Wähle für die Woche einen kleinen Schritt in diese Richtung"),
                        H("Was du beibehalten solltest"),
                        List(
                            "Jeden Tag eine angenehme und eine „Ich habe es geschafft“-Tätigkeit",
                            "Kleine Schritte statt großer Pläne",
                            "Kontakt mit Menschen"),
                        P("Füll die Skala PHQ-9 noch einmal aus und vergleiche mit dem Anfang. Wenn das Ergebnis hoch ist oder sich nicht verändert, wende dich an eine Ärztin oder Psychotherapeutin: Depression lässt sich sehr gut behandeln."),
                        TestsTab("Skala PHQ-9", "phq9"),
                        Crisis("Ich brauche jetzt Hilfe")
                    ],
                    "Mach diese Woche einen Schritt in einem Bereich, der dir wichtig ist.",
                    "Was ist dir wichtig? Welchen Schritt hast du gewählt?")
            ]),
        new(
            CourseIds.Trauma,
            "Nach einem Trauma",
            "Fünf Tage über das, was man sicher allein tun kann: die eigene Reaktion verstehen, mit Flashbacks und Albträumen zurechtkommen, eine Fachperson finden",
            "Healing",
            "pcl5",
            "PCL-5",
            [
                new(
                    "Eine normale Reaktion auf ein unnormales Ereignis",
                    4,
                    [
                        P("Nach einem schweren Ereignis haben fast alle aufdringliche Erinnerungen, Albträume, Angst, Taubheit, Reizbarkeit. Das ist keine Schwäche, sondern die Reaktion eines Gehirns, das dich davor schützen will, dass es wieder passiert."),
                        P("Dieser Kurs verarbeitet das Trauma nicht: Das braucht eine Therapie mit einer Fachperson. Er hilft dir zu verstehen, was mit dir passiert, mit schweren Momenten zurechtzukommen und vorbereitet zu einer Fachperson zu gehen. Du musst dich in diesem Kurs nicht an das Ereignis selbst erinnern oder es beschreiben."),
                        P("Füll zu Beginn die Skala PCL-5 aus: Am Ende vergleichst du das Ergebnis."),
                        TestsTab("Skala PCL-5", "pcl5"),
                        Warning("Wenn die Gefahr andauert"),
                        P("Wenn du gerade bedroht wirst oder Gedanken aufgetaucht sind, dir etwas anzutun, kommt die Sicherheit zuerst."),
                        Crisis("Ich brauche jetzt Hilfe")
                    ],
                    "Achte darauf, wann es im Laufe des Tages schwerer wird, ohne Details des Ereignisses: die Zeit, der Ort, was um dich herum war.",
                    "Welche dieser Reaktionen erkennst du bei dir?"),
                new(
                    "In die Gegenwart zurückkommen",
                    4,
                    [
                        P("Ein Flashback ist eine Erinnerung, die erlebt wird, als geschähe sie jetzt. Zeit, Ort, der Halt des Körpers und die Sinne helfen zurückzukommen."),
                        Practice(TechniqueId.Flashback, "Eine Erinnerung hat mich überwältigt"),
                        Practice(TechniqueId.Grounding, "Erdung 5-4-3-2-1"),
                        H("Dein eigenes Erdungsset"),
                        List(
                            "Ein Satz: „Das ist eine Erinnerung. Jetzt ist eine andere Zeit, ich bin sicher“",
                            "Etwas, das du bei dir trägst: ein Kiesel, ein Ring, etwas mit einem Duft",
                            "Ein Mensch, dem du schreiben kannst",
                            "Etwas Kaltes: Wasser, Eis"),
                        Breathe("Die Ausatmung länger als die Einatmung"),
                        P("Wenn die Aufmerksamkeit auf Atem oder Körper die Belastung verstärkt, hör auf. Öffne die Augen, wähle einen neutralen Gegenstand in deiner Nähe oder lass die Übung aus."),
                        See(ArticleIds.TraumaGrounding, "Wenn Erdung die Belastung verstärkt")
                    ],
                    "Stell dein Erdungsset zusammen und probier die Übung „Eine Erinnerung hat mich überwältigt“ in einem ruhigen Moment aus, damit du sie vorher kennst.",
                    "Was gehört zu deinem Erdungsset?"),
                new(
                    "Schlaf und Albträume",
                    4,
                    [
                        P("Nach einem Trauma leidet der Schlaf oft: Das Einschlafen fällt schwer, der Schlaf ist flach, Albträume kommen. Schlafmangel macht die Tage ängstlicher und gereizter."),
                        List(
                            "Eine Aufstehzeit an jedem Tag",
                            "Licht am Morgen, ein ruhiger Abend ohne Nachrichten",
                            "Wenn dich ein Albtraum weckt: Licht, wo bin ich und welcher Tag ist heute, Wasser, langsame Ausatmungen",
                            "Alkohol verstärkt Albträume in der zweiten Nachthälfte"),
                        P("Ein wiederkehrender Albtraum lässt sich umschreiben: Imagery Rehearsal macht Albträume seltener und schwächer. Fang mit einem leichteren an."),
                        Practice(TechniqueId.Nightmare, "Einen Albtraum umschreiben")
                    ],
                    "Halte eine feste Aufstehzeit ein. Wenn du wiederkehrende Albträume hast, versuch einen davon umzuschreiben, angefangen mit einem leichteren.",
                    "Wie schläfst du gerade? Was hilft nach einer schweren Nacht?"),
                new(
                    "Unterstützung und Menschen",
                    4,
                    [
                        P("Ein Trauma entfernt Menschen oft von anderen und von dem, was früher wichtig war. Die Unterstützung nahestehender Menschen ist einer der stärksten Faktoren der Erholung."),
                        List(
                            "Du musst nicht über das Ereignis sprechen: Ihr könnt einfach zusammen sein",
                            "Sag deinen Angehörigen, wie sie dir in einem schweren Moment helfen können",
                            "Hol allmählich zurück, was dir Halt gab: Spaziergänge, Bewegung, Dinge, die du gern gemacht hast",
                            "Betäube Gefühle nicht mit Alkohol: Er behindert die Erholung"),
                        P("Erinnerungsreize zu meiden ist verständlich, aber mit der Zeit engt es das Leben ein und hält das Trauma „heiß“. Daran arbeitest du besser mit einer Fachperson, als dich allein zu zwingen."),
                        P("Was das Ereignis an deinem Denken über dich verändert hat — Schuld, „mit mir stimmt etwas nicht“, „man kann niemandem trauen“ —, lässt sich im Chat bearbeiten, ohne zu erzählen, was passiert ist."),
                        TraumaChat("Im Chat daran arbeiten"),
                        Practice(TechniqueId.SelfCompassion, "Freundliche Worte an dich selbst")
                    ],
                    "Tu eine Sache, die dir früher Halt gegeben hat, und verbring Zeit mit jemandem, dem du vertraust.",
                    "Wer und was gibt dir gerade Halt?"),
                new(
                    "Der Weg zu einer Fachperson",
                    5,
                    [
                        P("Posttraumatische Symptome sprechen gut auf traumafokussierte Psychotherapie an: prolongierte Exposition, kognitive Therapie, EMDR, schriftliche Exposition. Sie braucht meist 8–16 Sitzungen."),
                        See(ArticleIds.TraumaTreatment, "Wie Trauma behandelt wird und wie du eine Fachperson auswählst"),
                        H("Wie du dich vorbereitest"),
                        List(
                            "Füll die Skala PCL-5 noch einmal aus und vergleiche mit dem Anfang",
                            "Exportiere eine Zusammenfassung aus der App für die Fachperson: „Profil → Optionen → Daten und Sicherung“",
                            "Schreib deine Fragen auf: welche Methode, wie viele Sitzungen, wie der Fortschritt gemessen wird",
                            "Du musst beim ersten Treffen nicht alles über das Ereignis erzählen"),
                        TestsTab("Skala PCL-5", "pcl5"),
                        Crisis("Ich brauche jetzt Hilfe")
                    ],
                    "Such dir ein oder zwei Fachpersonen, die mit Trauma arbeiten, und vereinbare einen Beratungstermin.",
                    "Was war im Kurs am nützlichsten? Worüber möchtest du mit der Fachperson sprechen?")
            ]),
        new(
            CourseIds.MoneyStress,
            "Geldsorgen: 14 Tage Unterstützung",
            "Vierzehn kurze Schritte zu Dringlichkeit, Fakten und Unterstützung. Der GAD-7 erfasst allgemeine Angst der letzten zwei Wochen, nicht Finanzen; eine Veränderung beweist keine Kurswirkung. Keine Finanz- oder Rechtsberatung.",
            "AccountBalanceWallet",
            "gad7",
            "GAD-7",
            [
                new(
                    "Eine Sorge",
                    4,
                    [P("Der GAD-7 erfasst allgemeine Angstsymptome der letzten zwei Wochen, nicht Geldsorgen. Beschreiben Sie eine Sorge ohne Beträge, Kontodaten oder Namen."), TestsTab("GAD-7 öffnen: allgemeine Angst der letzten zwei Wochen", "gad7"), See(ArticleIds.MoneyStress, "Geldsorgen: Fakten und Befürchtungen unterscheiden")],
                    "Notieren Sie sie allgemein oder sprechen Sie sie leise aus.",
                    "Was lenkt Ihre Aufmerksamkeit am häufigsten dorthin?"),
                new(
                    "Zuerst die Dringlichkeit",
                    4,
                    [P("Sind Nahrung, Unterkunft, notwendige Medikamente oder Sicherheit gefährdet, suchen Sie heute konkrete Hilfe; der Kurs kann warten.")],
                    "Benennen Sie einen Bedarf für heute und eine Person, die Sie kontaktieren könnten.",
                    "Was braucht zuerst Aufmerksamkeit?"),
                new(
                    "Fakten und Vorhersagen",
                    4,
                    [P("Trennen Sie bekannte Fakten, offene Fragen und eine Befürchtung. Sie können Ungewissheit anerkennen, ohne sie mit dem schlimmsten Ausgang zu füllen."), Practice(TechniqueId.MoneyWorryPlan, "Geldsorgen ordnen"), See(ArticleIds.MoneyStress, "Geldsorgen: Fakten und Befürchtungen unterscheiden")],
                    "Probieren Sie die Übung mit allgemeinen Notizen.",
                    "Was konnten Sie von der Befürchtung trennen?"),
                new(
                    "Eine Frage überprüfen",
                    4,
                    [P("Wählen Sie eine Frage, deren Antwort Unklarheit verringern könnte. Nutzen Sie bei Rechnungen oder Diensten einen bekannten offiziellen Kanal.")],
                    "Notieren Sie eine Frage und einen sicheren Prüfweg.",
                    "Was ist jetzt klarer?"),
                new(
                    "Persönliche Daten schützen",
                    4,
                    [P("Teilen Sie keine Passwörter, PINs, Bestätigungscodes oder vollständigen Kontodaten. Prüfen Sie unerwartete Überweisungsbitten auf anderem Weg.")],
                    "Legen Sie eine Pause fest, bevor Sie Daten teilen oder Geld senden.",
                    "Welche Grenze gibt mehr Sicherheit?"),
                new(
                    "Konkret um Hilfe bitten",
                    4,
                    [P("Unterstützung muss kein Geld sein: Begleitung, gemeinsam telefonieren oder eine lokale Stelle suchen. Die andere Person kann zustimmen oder ablehnen."), See(ArticleIds.SupportRequest, "Um Unterstützung bitten")],
                    "Formulieren Sie eine Bitte um eine Aufgabe zu einer bestimmten Zeit, ohne Finanzgeheimnisse.",
                    "Wen könnten Sie fragen?"),
                new(
                    "Ein machbarer Schritt",
                    4,
                    [P("Wählen Sie eine sichere, überprüfbare Handlung in Ihrem Einfluss. Für Finanz- oder Rechtsfragen ist eine qualifizierte lokale Fachperson zuständig."), Practice(TechniqueId.MoneyWorryPlan, "Geldsorgen ordnen")],
                    "Wählen Sie einen kleinen umkehrbaren Schritt oder bitten Sie um Hilfe.",
                    "Was hilft, nicht alles auf einmal zu übernehmen?"),
                new(
                    "Eine Ausweichmöglichkeit",
                    4,
                    [P("Ein Plan ist flexibler, wenn es bei Verzögerung oder Absage eine weitere Möglichkeit gibt. Sie muss nicht alles lösen.")],
                    "Benennen Sie eine Alternative und einen Kontakt für Unterstützung.",
                    "Welche Möglichkeit ist realistisch?"),
                new(
                    "Zeit zum Überprüfen",
                    4,
                    [P("Wenn nichts dringend ist, legen Sie eine kurze Zeit für Informationssuche fest und kehren danach zur aktuellen Aufgabe zurück. Notwendige Hilfe nicht aufschieben.")],
                    "Wählen Sie eine ruhige Zeit für die Planprüfung.",
                    "Was kann warten?"),
                new(
                    "Praktische Unterstützung",
                    4,
                    [P("In Ihrer Region gibt es vielleicht soziale, gemeinschaftliche oder medizinische Angebote. Möglichkeiten unterscheiden sich; die App empfiehlt keine Finanzentscheidungen.")],
                    "Fragen Sie eine bekannte lokale Stelle nach verfügbaren Hilfen.",
                    "Was möchten Sie fragen?"),
                new(
                    "Sprechen ohne Geheimnisse",
                    4,
                    [P("Sie können sagen: Ich bin besorgt und möchte, dass du eine Weile bei mir bleibst. Beträge und Kontodaten müssen Sie nicht teilen.")],
                    "Überlegen Sie, was Sie allgemein erzählen möchten.",
                    "Welche Unterstützung wünschen Sie sich?"),
                new(
                    "Sich selbst unterstützen",
                    4,
                    [P("Pause, Wasser, Essen oder eine vertraute beruhigende Tätigkeit lösen kein Geldproblem, können aber durch den heutigen Tag helfen.")],
                    "Wählen Sie eine verfügbare Selbstfürsorge ohne zusätzliche Ausgaben.",
                    "Was könnte etwas Entlastung geben?"),
                new(
                    "Grenzen überprüfen",
                    4,
                    [P("Achten Sie darauf, was klarer ist, was offen bleibt und wo Hilfe nötig ist. Sie können den Plan vereinfachen.")],
                    "Behalten Sie einen nächsten Schritt; legen Sie anderes sicher beiseite.",
                    "Was muss heute nicht gelöst werden?"),
                new(
                    "Weiteren Schritt wählen",
                    4,
                    [P("Nach etwa zwei Wochen können Sie den GAD-7 wiederholen. Er bewertet keine Finanzen und beweist keine Kurswirkung. Wenn Angst den Alltag anhaltend stört, besprechen Sie Hilfe mit einer Fachperson."), TestsTab("GAD-7 wiederholen; der Wert bewertet keine Finanzen und erklärt keine Veränderung", "gad7"), Crisis("Ich brauche jetzt Hilfe")],
                    "Wählen Sie eine Unterstützung oder einen Schritt für danach.",
                    "Was möchten Sie beibehalten oder besprechen?")
            ]),

        new(CourseIds.ValuesAction, "Kleine Schritte zu dem, was zählt", "Fünf Tage, um eine wichtige Richtung zu wählen und machbare Schritte auszuprobieren.", "TrackChanges", "who5", "WHO-5",
            [
                new("Eine Richtung finden", 3, [P("Ein Wert beschreibt, wie Sie in einem Lebensbereich sein möchten, nicht ein Ergebnis, das Sie einmal für immer erreichen müssen."), See(ArticleIds.ValuesAction, "Werte als Orientierung: ein machbarer Schritt")], "Nennen Sie einen Lebensbereich, der Ihnen gerade wichtig ist.", "Was macht ihn für Sie wichtig?"),
                new("Den Schritt verkleinern", 3, [P("Wählen Sie eine Handlung für ein paar Minuten. Sie soll klein genug zum Ausprobieren und bedeutsam genug für Ihre eigene Entscheidung sein.")], "Notieren Sie eine Handlung, die höchstens 5–10 Minuten dauert.", "Wie können Sie sie einfacher oder kürzer machen?"),
                new("Ein Hindernis einplanen", 3, [P("Überlegen Sie, was dazwischenkommen könnte, und wählen Sie eine Alternative. Ein Plan darf sich ändern; das ist kein Scheitern.")], "Vervollständigen Sie: „Wenn … im Weg steht, kann ich … versuchen.“", "Was wäre eine freundlichere Alternative, wenn Sie weniger Kraft haben?"),
                new("Ohne passende Stimmung beginnen", 3, [P("Sie müssen sich nicht erst sicher oder motiviert fühlen. Probieren Sie einen kleinen Schritt aus, achten Sie auf Ihre Reaktion und hören Sie auf oder vereinfachen Sie ihn, wenn das sicherer ist.")], "Wenn es sicher ist, probieren Sie den Schritt oder eine leichtere Variante.", "Was ist Ihnen davor und danach aufgefallen?"),
                new("Den Plan überprüfen", 3, [P("Bewerten Sie, ob die Handlung gepasst hat, statt sich selbst zu beurteilen. Wiederholen Sie sie, passen Sie sie an oder wählen Sie eine andere Richtung.")], "Notieren Sie, was Sie diese Woche wiederholen oder ändern möchten.", "Welche Handlung unterstützt das Wichtige, ohne zusätzlichen Druck?")
            ]),


        new(CourseIds.ProblemPlanning, "Ein Plan für machbare Aufgaben", "Ein Problem in Schritte teilen und den Plan überprüfen", "Checklist", "gad7", "GAD-7",
            [
                new("Ein Problem wählen", 3, [P("Benennen Sie zuerst ein konkretes Problem. Nicht alles liegt in Ihrer Hand; wählen Sie, was Sie beeinflussen können."), See(ArticleIds.ProblemPlanning, "Ein Plan für machbare Aufgaben")], "Notieren Sie ein Problem und was Sie beeinflussen können.", "Welchen Teil der Situation können Sie beeinflussen?"),
                new("Einen Schritt wählen", 3, [P("Schreiben Sie mehrere Möglichkeiten auf, auch wenn keine perfekt erscheint. Wählen Sie einen kleinen, sicheren Schritt."), See(ArticleIds.ProblemPlanning, "Ein Plan für machbare Aufgaben")], "Notieren Sie zwei Möglichkeiten und wählen Sie einen machbaren Schritt.", "Was könnte im Weg stehen und was wäre eine Alternative?"),
                new("Den Plan überprüfen", 3, [P("Achten Sie danach darauf, was geholfen hat und was zu schwierig war. Sie können den Plan anpassen oder Unterstützung suchen."), See(ArticleIds.ProblemPlanning, "Ein Plan für machbare Aufgaben")], "Probieren Sie den Schritt aus, wenn es sicher ist, und notieren Sie das Ergebnis.", "Was möchten Sie beibehalten, ändern oder mit jemandem besprechen?")
            ]),
        new(
            CourseIds.Overwhelm,
            "Weniger Überforderung, ein klarer nächster Schritt",
            "Fünf kurze Tage: Dringendes sortieren, Aufgaben verkleinern und Unterstützung finden. Sie bestimmen das Tempo.",
            "Checklist",
            "pss10",
            "PSS-10",
            [
                new("Aufgaben aus dem Kopf holen", 4, [P("Eine kurze Liste zeigt, was gerade Aufmerksamkeit verlangt. Stichworte reichen; private Einzelheiten sind nicht nötig."), H("Dringlichkeit zuerst prüfen"), Warning("Wenn Sicherheit, Gesundheit, Essen, Wohnen oder notwendige Medikamente bedroht sind, suchen Sie zuerst praktische Hilfe."), See(ArticleIds.Overwhelm, "Wenn alles zu viel wird: den nächsten Schritt wählen")], "Notieren Sie, was Aufmerksamkeit braucht, und markieren Sie nur, was nicht sicher warten kann.", "Was wurde durch die Liste klarer?"),
                new("Dringlichkeit von Sorge trennen", 4, [P("Starke Sorge verdient Aufmerksamkeit, bestimmt aber nicht allein die Reihenfolge. Prüfen Sie Fristen, Folgen und Ihren Einfluss."), Quiz("Was hilft, die erste Aufgabe zu wählen?", 1, "Fristen und Folgen helfen bei der Einschätzung; die Lautstärke der Sorge macht eine Aufgabe nicht automatisch zur ersten.", "Die lauteste Sorge wählen", "Frist und Folgen prüfen", "Alles auf einmal lösen")], "Wählen Sie eine Aufgabe für heute und eine, die warten kann.", "Was kann wirklich nicht verschoben werden?"),
                new("Den nächsten Schritt verkleinern", 4, [P("Beschreiben Sie eine Handlung, die nur einige Minuten dauert. Fühlt sie sich noch zu groß an, teilen Sie sie weiter auf."), See(ArticleIds.Overwhelm, "Wenn alles zu viel wird: den nächsten Schritt wählen"), Practice(TechniqueId.ExternalOrientation, "Drei neutrale Details")], "Benennen Sie den Anfang: öffnen, anrufen, nachfragen oder einen Punkt sammeln.", "Wie lässt sich dieser Schritt leichter machen?"),
                new("Um machbare Hilfe bitten", 4, [P("Die Bitte um eine konkrete Handlung ist klarer als die Bitte, alles zu lösen. Die andere Person kann zustimmen, etwas anderes vorschlagen oder ablehnen; dann können Sie weitere Unterstützung suchen."), List("Bitten, kurz dabeizubleiben", "Um Hilfe bei einer konkreten Information bitten", "Eine Aufgabe gemeinsam erledigen")], "Formulieren Sie eine kurze Bitte und überlegen Sie, wen Sie fragen könnten.", "Welche Antwort oder Alternative wäre hilfreich?"),
                new("Den Plan überprüfen", 4, [P("Prüfen Sie, ob der Plan zu Ihren jetzigen Umständen passt, nicht ob Sie streng genug mit sich waren. Sie können weitermachen, vereinfachen oder Unterstützung suchen."), TestsTab("Wenn Sie möchten, wiederholen Sie PSS-10. Es erfasst wahrgenommenen Stress, ist keine Diagnose; eine Veränderung beweist nicht, dass der Kurs sie verursacht hat.", "pss10")], "Wählen Sie einen Schritt, den Sie in den nächsten Tagen beibehalten möchten.", "Wie bleibt der Plan frei von zusätzlichem Druck?")
            ]),

        new(
            CourseIds.NewsBoundaries,
            "Nachrichten zu Ihrer Zeit",
            "Fünf Tage, um seltener aus Gewohnheit in Feeds zu schauen und wichtige Meldungen zu behalten.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Die Gewohnheit bemerken", 4, [P("Wenn Sie zum Feed greifen, fragen Sie sich: Was möchte ich wissen, und muss ich jetzt handeln?"), See(ArticleIds.NewsLoop, "Wenn Nachrichten nicht loslassen"), TestsTab("Der PSS-10 erfasst wahrgenommenen Stress im letzten Monat. Er ist ein Screening, keine Diagnose.", "pss10")], "Bemerken Sie einmal, was den Wunsch ausgelöst hat, Nachrichten zu prüfen.", "Was wollten Sie herausfinden?"),
                new("Eine Frage, eine Quelle", 4, [P("Formulieren Sie eine Frage und wählen Sie eine zuverlässige Quelle, die sie beantworten kann. Wenn Sie die Antwort haben, bringen weitere Meldungen vielleicht keine hilfreichen Informationen."), Quiz("Sie haben die gesuchte Antwort gefunden. Was können Sie tun, wenn kein dringender Schritt nötig ist?", 1, "Ein Zeitpunkt für die nächste Prüfung kann das automatische Aktualisieren unterbrechen.", "Weiter aktualisieren, bis Sie sich ruhig fühlen", "Eine Zeit für die nächste Prüfung festlegen und zur Aufgabe zurückkehren", "Sich Nachrichten vollständig verbieten")], "Wählen Sie eine Frage und eine Quelle für die nächste Prüfung.", "Woran erkennen Sie, dass Sie genug wissen?"),
                new("Wichtige Meldungen behalten", 4, [P("Sie können optionale Benachrichtigungen ausschalten und Meldungen zu Sicherheit, Familie oder Arbeit behalten."), List("Meldungen wichtiger Stellen behalten", "Optionale Benachrichtigungen ausschalten", "Nahestehende bitten, bei Dringendem anzurufen")], "Prüfen Sie Einstellungen nur, wenn es für Sie hilfreich ist.", "Welche Meldungen möchten Sie behalten?"),
                new("Einen Prüfplan erstellen", 4, [P("Wählen Sie einen passenden Zeitpunkt und eine Quelle. Es ist keine strenge Begrenzung nötig: Passen Sie den Plan an, wenn Dringendes oder neue Umstände eintreten."), Practice(TechniqueId.NewsCheckPlan, "Nachrichtenprüfung planen")], "Füllen Sie den kurzen Plan aus oder gehen Sie ihn gedanklich durch.", "Was möchten Sie nach der Prüfung tun?"),
                new("Ohne Selbstkritik zurückblicken", 4, [P("Beobachten Sie, ob sich die gewählte Routine für Sie besser anfühlt. Behalten Sie sie bei, ändern Sie sie oder lassen Sie sie weg. Eine Veränderung des PSS-10 beweist nicht, dass der Kurs sie verursacht hat."), Quiz("Was tun Sie, wenn eine sicherheitsrelevante Information auftaucht?", 1, "Der Plan darf Sie nicht davon abhalten, Dringendes zu prüfen oder offiziellen Anweisungen zu folgen.", "Bis zum geplanten Zeitpunkt warten", "Eine zuverlässige Quelle prüfen und passend handeln", "Alle Meldungen ausschalten"), TestsTab("Sie können den PSS-10 bei Bedarf wiederholen. Ein Punktevergleich zeigt nicht die Ursache einer Veränderung.", "pss10")], "Behalten Sie eine Einstellung bei, die zu Ihnen passt.", "Welche Routine war machbar?")
            ]),
        new(
            CourseIds.HabitMaintenance,
            "Eine Gewohnheit, zu der Sie zurückfinden",
            "Fünf Tage: einen Auslöser wählen, den Anfang erleichtern und nach einer Pause freundlich neu beginnen.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Eine Handlung auswählen", 4, [P("Beginnen Sie mit einer kleinen Handlung, die in Ihrer Hand liegt und das Wohlbefinden im Alltag unterstützt. Wählen Sie nicht mehrere Ziele auf einmal."), See(ArticleIds.HabitFormation, "Eine neue Gewohnheit: eine kleine Handlung und ein Auslöser"), TestsTab("Der WHO-5 ist ein kurzes Screening des Wohlbefindens in den letzten zwei Wochen, keine Diagnose und kein Maß für Willenskraft.", "who5")], "Nennen Sie eine Handlung, die Sie wiederholen möchten.", "Warum passt dieser Schritt gerade jetzt?"),
                new("An einen Auslöser knüpfen", 4, [P("Wählen Sie ein regelmäßiges Ereignis, das an den Anfang erinnert, etwa nach dem Frühstück oder wenn Sie nach Hause kommen."), Practice(TechniqueId.ImplementationIntention, "Wenn-dann-Plan"), Quiz("Welcher Plan ist im passenden Moment leichter zu erinnern?", 1, "Ein konkreter Auslöser und eine kleine Handlung erleichtern den Anfang, ohne auf die richtige Stimmung zu warten.", "Irgendwann werde ich mich länger damit befassen", "Nach dem Frühstück schreibe ich einen Satz", "Ich beginne, wenn ich motiviert bin")], "Vervollständigen Sie: Nach … werde ich …", "Welcher regelmäßige Auslöser ist schon in Ihrem Tag vorhanden?"),
                new("Den Anfang erleichtern", 4, [P("Beseitigen Sie ein kleines Hindernis: Legen Sie etwas bereit, öffnen Sie die Datei oder wählen Sie einen Ort. Der erste Schritt darf nur ein paar Minuten dauern."), List("Benötigtes vorbereiten", "Dauer oder Umfang verkleinern", "Einen bequemeren Ort oder Zeitpunkt wählen")], "Machen Sie den Beginn um einen Schritt einfacher.", "Was hat gestört und was haben Sie verändert?"),
                new("Die Rückkehr planen", 4, [P("Ein ausgelassener Tag zeigt, was passiert ist; er beweist kein Scheitern. Sie müssen weder doppelt so viel tun noch sich kritisieren. Sie können bei der nächsten passenden Gelegenheit weitermachen."), Practice(TechniqueId.HabitRestartPlan, "Sanft neu beginnen"), Quiz("Sie haben Ihre übliche Handlung ausgelassen. Was kann die Rückkehr erleichtern?", 1, "Der nächste passende Auslöser und ein kleinerer Schritt helfen ohne Strafe oder Nachholen.", "Morgen die doppelte Menge schaffen", "Beim nächsten Auslöser klein anfangen", "Den Plan endgültig aufgeben")], "Wählen Sie einen Auslöser und die einfachste Version der Handlung.", "Wie können Sie weitermachen, ohne alles nachzuholen?"),
                new("Beibehalten, was passt", 4, [P("Betrachten Sie den Plan als Experiment: Wiederholen Sie ihn, verkleinern Sie den Schritt, ändern Sie den Auslöser oder pausieren Sie. Sie können den WHO-5 auf Wunsch wiederholen; eine Punktänderung allein beweist keine Wirkung des Kurses."), TestsTab("Der WHO-5 ist ein Screening des Wohlbefindens, keine Diagnose. Ein Vergleich zeigt nicht, warum sich Werte geändert haben.", "who5")], "Behalten Sie eine Anpassung bei, die Sie als Nächstes testen möchten.", "Was war machbar und was möchten Sie ändern?")
            ]),
        new(
            CourseIds.FeedbackResponse,
            "Rückmeldung ohne Selbstkritik beantworten",
            "Vier kurze Einheiten: Fakten von Etiketten trennen, Erwartungen klären und eine Antwort wählen, die Ihre Grenzen achtet.",
            "Forum", "who5", "WHO-5",
            [
                new("Die erste Reaktion bemerken", 4, [P("Worte können treffen. Sie müssen nicht sofort zustimmen, streiten oder sich rechtfertigen. Nehmen Sie zuerst wahr, was Sie gehört haben und wie es auf Sie wirkt."), See(ArticleIds.Feedback, "Rückmeldung ohne Etiketten"), TestsTab("WHO-5 erfasst das allgemeine Wohlbefinden der letzten zwei Wochen; es ist keine Diagnose und misst nicht, wie gut Sie Rückmeldung angenommen haben.", "who5")], "Wählen Sie einen Satz, der Ihnen Zeit zum Nachdenken gibt.", "Was könnten Sie sagen, um nicht im Affekt zu antworten?"),
                new("Nach Konkretem fragen", 4, [P("Ein Beispiel kann zeigen, was sich tatsächlich ändern lässt. Fragen Sie nach Frist, Maßstab oder Situation, ohne allem Gesagten zuzustimmen."), Practice(TechniqueId.FeedbackReview, "Rückmeldung sortieren")], "Notieren Sie eine Frage, die die Erwartung klärt.", "Was ist hier noch zu ungenau?"),
                new("Den hilfreichen Teil wählen", 4, [P("Sie können einen konkreten Hinweis prüfen, Unklares nachfragen und ein Etikett zurückweisen. Es geht um Ihren nächsten Schritt, nicht darum, Ihren Wert zu beweisen."), Warning("Drohungen, Demütigung, Diskriminierung oder Druck verlangen Grenzen und Unterstützung statt Selbstkritik.")], "Wählen Sie einen Punkt, den Sie prüfen oder besprechen möchten.", "Was kann ich beeinflussen und was muss ich nicht annehmen?"),
                new("Ruhig abschließen", 4, [P("Vereinbaren Sie einen nächsten Schritt oder einen Zeitpunkt zur Rückschau. Wenn keine Einigung möglich ist, halten Sie Fakten fest und fragen Sie eine Vertrauensperson oder die zuständige Stelle."), Quiz("Welche Antwort klärt am besten, was als Nächstes zu tun ist?", 1, "Eine konkrete Frage klärt Erwartungen; eine Pause lässt Raum für eine passende Antwort.", "Alles zustimmen, damit das Gespräch endet.", "Nach Beispiel oder Maßstab fragen und später antworten.", "Annehmen, dass ein Fehler den ganzen Menschen beschreibt."), TestsTab("Eine starke Reaktion beweist nicht, dass Worte wahr sind. WHO-5 ist ein allgemeines Wohlbefindens-Screening, kein Feedback-Test; veränderte Werte beweisen keine Kurswirkung.", "who5")], "Probieren Sie eine Frage oder Antwort, die Ihre Grenzen achtet.", "Welchen kleinen Schritt wählen Sie?")
            ]),
        new(
            CourseIds.ConnectionWithoutPressure,
            "Kontakt im eigenen Tempo",
            "Fünf kleine Schritte: herausfinden, welche Verbindung Ihnen fehlt, ein sicheres Format wählen und ohne Druck einladen.",
            "Group", "who5", "WHO-5",
            [
                new("Die gewünschte Verbindung benennen", 4, [P("Manchmal hilft ein Gespräch, manchmal eine gemeinsame Aktivität, ruhige Gesellschaft oder praktische Hilfe. Sie müssen keine bestimmte Zahl an Kontakten erreichen."), See(ArticleIds.Loneliness, "Einsamkeit"), TestsTab("WHO-5 ist ein allgemeines Screening des Wohlbefindens der letzten zwei Wochen, kein Einsamkeitsmaß und keine Diagnose. Eine Veränderung beweist für sich allein keine Kurswirkung.", "who5")], "Wählen Sie eine Art von Kontakt, die jetzt hilfreich wäre.", "Was bedeutet angenehmer Kontakt für mich?"),
                new("Ein sicheres Format wählen", 4, [P("Überlegen Sie, mit wem und wie es sich sicherer anfühlt: zu zweit, in einer Gruppe, online oder mit einer kurzen Nachricht. Eine Pause ist möglich; kontaktieren Sie niemanden, bei dem Sie sich unsicher fühlen.")], "Nennen Sie eine Person, Gruppe oder ein Format, das sicher genug wirkt.", "In welchem Format fällt mir der Anfang leichter?"),
                new("Ohne Druck einladen", 4, [P("Eine kurze, konkrete Einladung lässt sich leichter annehmen oder ablehnen. Lassen Sie der anderen Person die Wahl von Zeit oder Absage."), See(ArticleIds.SupportRequest, "Um Unterstützung bitten"), Practice(TechniqueId.ConnectionStepPlan, "Einen kleinen Kontakt planen")], "Formulieren Sie eine Einladung zu einem kurzen Spaziergang, Gespräch oder gemeinsamen Tun.", "Wie lasse ich der anderen Person die freie Wahl?"),
                new("Spielraum lassen", 4, [P("Beginnen Sie zu einer passenden Zeit und mit einer einfachen Möglichkeit aufzuhören. Bei wenig Kraft kann der Plan kleiner werden oder verschoben werden. Eine Antwort oder keine Antwort bestimmt nicht Ihren Wert."), Practice(TechniqueId.ConnectionStepPlan, "Einen kleinen Kontakt planen")], "Wählen Sie ein einfaches Format und einen Zeitpunkt zum Beenden oder Verschieben.", "Wie unterstütze ich mich, wenn sich Pläne ändern?"),
                new("Ohne Selbsturteil zurückblicken", 4, [P("Achten Sie darauf, ob es sich sicher und passend anfühlte und ob Sie das Format wiederholen oder ändern möchten. Bewerten Sie sich nicht nach Nachrichten oder der Reaktion anderer."), Quiz("Was ist nach einem kleinen Kontakt hilfreich zu bemerken?", 0, "Hilfreich ist, das Format und das eigene Erleben zu prüfen. Die Reaktion anderer misst nicht Ihren Wert.", "War es sicher und angenehm, und was könnte ich anpassen?", "Wie viele Nachrichten habe ich in einer Stunde erhalten?", "Beweist eine ausbleibende Antwort, dass mich niemand sehen möchte?"), TestsTab("WHO-5 ist ein allgemeines Screening des Wohlbefindens der letzten zwei Wochen, kein Einsamkeitsmaß und keine Diagnose. Eine Veränderung beweist für sich allein keine Kurswirkung.", "who5")], "Wählen Sie ein Format, das Sie ausprobieren oder anpassen möchten.", "Welcher kleine Schritt passt jetzt?")
            ]),
        new(
            CourseIds.Boundaries,
            "Grenzen klar kommunizieren",
            "Vier kurze Schritte, um eigene Grenzen zu erkennen, sie klar auszudrücken und einen sicheren nächsten Schritt zu wählen.",
            "Forum", "who5", "WHO-5",
            [
                new("Was ist mir wichtig?", 4, [P("Selbstsicher zu kommunizieren heißt, eigene Bedürfnisse klar auszusprechen und zugleich das Recht der anderen Person auf eine eigene Antwort zu respektieren. Es garantiert keine Zustimmung und ist keine Pflicht."), H("Drei Möglichkeiten zu antworten"), List("Schweigen, obwohl Sie anderer Meinung sind", "Mit Druck oder Beleidigungen reagieren", "Ruhig die eigene Position und Bitte nennen"), Quiz("Welche Antwort ist selbstsicher?", 2, "Eine klare, ruhige Aussage zeigt Ihre Haltung und lässt der anderen Person Raum zu antworten.", "Zustimmen, obwohl Sie es nicht möchten", "Lauter werden, bis die Person zustimmt", "Sagen: „Heute kann ich nicht. Können wir einen anderen Tag besprechen?“"), TestsTab("WHO-5 ist ein allgemeiner Wohlbefindens-Screeningtest für die letzten zwei Wochen, kein Test für Selbstsicherheit und keine Diagnose.", "who5"), Crisis("Ich brauche jetzt Hilfe")], "Bemerken Sie eine sichere Situation, in der Sie eine Grenze benennen möchten. Sie müssen noch nichts tun.", "Was ist Ihnen in dieser Situation wichtig?"),
                new("Klar und kurz Nein sagen", 4, [P("Eine Absage darf kurz und höflich sein. Sie müssen sie nicht ausführlich erklären. Wenn es für Sie passt, können Sie eine Alternative anbieten, müssen es aber nicht."), List("„Jetzt schaffe ich es nicht“", "„Das kann ich nicht übernehmen“", "„Ich muss erst nachdenken. Ich antworte morgen“"), P("Wenn jemand weiter drängt, wiederholen Sie ruhig Ihren wichtigsten Satz. Sie müssen nicht beweisen, dass Ihr Grund gut genug ist.")], "Bereiten Sie eine Absage für eine alltägliche Situation mit geringem Risiko vor.", "Welche Worte klingen für Sie natürlich?"),
                new("Eine konkrete Bitte formulieren", 4, [P("Eine konkrete Bitte ist leichter zu verstehen als ein Hinweis oder Vorwurf. Nennen Sie die Situation, was Ihnen wichtig ist, und eine machbare Möglichkeit."), Quiz("Welche Bitte ist klarer?", 1, "Eine konkrete Bitte beschreibt eine Handlung und einen Zeitpunkt, ohne die Absichten der anderen Person zu unterstellen.", "„Du hörst mir nie zu“", "„Wenn du kurz Zeit hast, hör mir bitte zehn Minuten zu“", "Nichts sagen und hoffen, dass die Person es errät"), P("Die andere Person kann zustimmen, einen Kompromiss vorschlagen oder ablehnen. Sie dürfen trotzdem bitten und Ihren nächsten Schritt wählen.")], "Schreiben oder überlegen Sie eine kurze Bitte.", "Was könnten Sie konkreter formulieren?"),
                new("Einen sicheren nächsten Schritt wählen", 4, [P("Beginnen Sie mit einer Situation mit geringerem Risiko und überlegen Sie vorher, was Sie bei verschiedenen Antworten tun könnten. Sie dürfen ein Gespräch verschieben, beenden oder mit Unterstützung führen."), P("Wenn Direktheit zu Drohungen, Gewalt, Bestrafung oder stärkerer Kontrolle führen könnte, üben Sie nicht allein. Ihre Sicherheit und Unterstützung haben Vorrang."), TestsTab("WHO-5 misst das allgemeine Wohlbefinden, nicht die Fähigkeit, Grenzen zu setzen. Eine Veränderung des Werts beweist keine Kurswirkung.", "who5")], "Wählen Sie einen sicheren Schritt: den Satz sagen, Unterstützung suchen oder vorerst nichts ändern.", "Was wäre ein fürsorglicher nächster Schritt für Sie?")
            ]),
        new(
            CourseIds.WorkRecovery,
            "Nach der Arbeit erholen",
            "Vier Tage, um zu entdecken, was beim Abschalten hilft, eine machbare Pause zu wählen und private Zeit zu schützen.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Was mir beim Erholen hilft", 4, [P("Verschiedenen Menschen helfen unterschiedliche Pausen. Die Forschung untersucht, Abstand zu Arbeitsgedanken zu gewinnen, sich zu entspannen, sich mit etwas Interessantem zu beschäftigen und Zeit oder Tempo selbst zu wählen. Das sind Möglichkeiten, keine Checkliste."), H("Ideen zum Ausprobieren"), List("Eine ruhige Pause oder Erholung", "Eine Tätigkeit, die fesselt oder etwas Neues vermittelt", "Zeit mit anderen oder für sich", "Sanfte Bewegung, wenn sie zu Ihnen passt"), TestsTab("PSS-10 erfasst den wahrgenommenen Stress des vergangenen Monats. Der Test diagnostiziert kein Burnout und misst keine Erholung von der Arbeit.", "pss10"), Crisis("Ich brauche jetzt Hilfe")], "Bemerken Sie eine Art der Pause, die manchmal hilft oder machbar wirkt.", "Was hilft Ihnen, sich wenigstens ein wenig umzustellen?"),
                new("Den Arbeitstag sanft beenden", 4, [P("Offene Aufgaben können die Aufmerksamkeit weiter beanspruchen. Wenn möglich, wählen Sie ein kleines Signal für das Arbeitsende: Arbeitstabs schließen, den ersten Schritt für morgen notieren oder sich umziehen."), P("Passen Sie das an Schichtarbeit, Bereitschaft und dringende Aufgaben an. Lassen Sie Benachrichtigungen aktiv, die für Sicherheit oder Arbeit nötig sind.")], "Wählen Sie ein kurzes Ende-des-Arbeitstags-Signal, das in Ihren Tagesplan passt.", "Woran könnten Sie den Wechsel in Ihre freie Zeit merken?"),
                new("Pause ohne perfekten Plan wählen", 4, [P("Erholung muss keine weitere Aufgabe sein. Fragen Sie sich, ob gerade Ruhe, Gesellschaft, eine interessante Tätigkeit oder Nichtstun besser passt."), List("Eine Tätigkeit verkürzen", "Etwas ohne viel Vorbereitung wählen", "Sich erlauben, die Meinung zu ändern"), P("Studien finden Zusammenhänge zwischen manchen Erholungserfahrungen und Wohlbefinden, versprechen aber nicht dieselbe Wirkung für alle. Achten Sie auf Ihre eigene Erfahrung.")], "Probieren Sie eine kleine Erholungspause oder wählen Sie, wann Sie darauf zurückkommen.", "Was war angenehm, neutral oder unpassend?"),
                new("Machbare freie Zeit schützen", 4, [P("Nicht jede Belastung lässt sich selbst steuern. Wenn die Arbeit regelmäßig in die Ruhezeit hineinreicht, können Sie Prioritäten, Fristen oder Unterstützung mit einer Führungskraft, Kollegin oder Vertrauensperson besprechen."), P("Wenn sich die Bedingungen noch nicht ändern lassen, ist das kein persönliches Versagen. Wählen Sie nur, was erreichbar ist, etwa eine Pause, eine kurze Tätigkeit oder den Zeitpunkt des nächsten Arbeitskontakts."), TestsTab("Ein wiederholter PSS-10 ist nur ein allgemeines Stress-Screening. Ein Unterschied beweist weder die Ursache noch die Wirkung dieses Kurses.", "pss10")], "Behalten Sie eine kleine Anpassung, die Sie diese Woche ausprobieren möchten.", "Was möchten Sie beibehalten oder als Nächstes ändern?")
            ]),
        new(
            CourseIds.SelfCompassion,
            "Nach einem Fehler freundlicher zu sich sein",
            "Vier kurze Schritte: Selbstkritik bemerken, Tatsache und Urteil trennen und hilfreich reagieren.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Die innere Kritik bemerken", 4, [P("Nach einem Fehler macht die innere Kritik oft aus einer Handlung ein Urteil über die ganze Person. Sie müssen nicht sofort positiv denken: Trennen Sie zuerst das Ereignis von der Bewertung."), H("Tatsache und Urteil"), List("„Ich habe vergessen zu antworten“ — Tatsache", "„Ich bin ein schrecklicher Freund“ — Urteil", "„Was könnte ich jetzt klären?“ — Frage"), TestsTab("WHO-5 ist ein allgemeines Screening des Wohlbefindens der letzten zwei Wochen. Es misst kein Selbstmitgefühl und belegt keine Kurswirkung.", "who5"), Crisis("Ich brauche jetzt Hilfe")], "Bemerken Sie ein selbstkritisches Etikett und beschreiben Sie das Ereignis ohne Bewertung. Aufschreiben ist nicht nötig.", "Was ist passiert, wenn das Etikett wegfällt?"),
                new("Mit sich wie mit einem Freund sprechen", 4, [P("Stellen Sie sich vor, einem nahestehenden Menschen wäre derselbe Fehler passiert. Unterstützung heißt nicht, alles zu entschuldigen; sie hilft, die ganze Situation zu sehen und einen nächsten Schritt zu wählen."), Quiz("Welche Antwort ist freundlich und ehrlich?", 2, "Sie erkennt den Fehler an, ohne die Person abzuwerten, und sucht einen konkreten Schritt.", "„Du machst immer alles falsch“", "„Das ist völlig egal“", "„Da ist ein Fehler passiert. Was lässt sich jetzt verbessern?“")], "Sagen Sie sich einen ehrlichen Satz, der Sie nicht abwertet.", "Wie klingt dieser Satz?"),
                new("Etwas wiedergutmachen statt sich bestrafen", 4, [P("Freundlichkeit zu sich selbst und Verantwortung passen zusammen. Sie können Folgen anerkennen und einen möglichen Teil korrigieren, ohne einen Fehler zum Urteil über Ihre ganze Person zu machen."), List("Was ist genau passiert?", "Wen oder was hat es betroffen?", "Welcher kleine Schritt hilft jetzt?"), P("Nicht alles lässt sich sofort korrigieren. Dann können Sie etwas daraus lernen und eine vertraute Person um Rat bitten.")], "Wählen Sie eine machbare Handlung zur Korrektur oder Unterstützung.", "Was liegt jetzt in Ihrer Hand?"),
                new("Einen freundlichen nächsten Schritt planen", 4, [P("Machen Sie einen kurzen Plan für den nächsten Fehler: Kritik bemerken, kurz innehalten und eine hilfreiche Handlung wählen. Sie dürfen den Plan ändern, wenn er nicht passt."), TestsTab("Ein erneuter WHO-5 zeigt nur allgemeines Wohlbefinden. Eine Punktedifferenz misst kein Selbstmitgefühl und belegt keine Kurswirkung.", "who5")], "Merken Sie sich einen Satz oder eine Handlung, zu der Sie zurückkehren möchten.", "Was möchten Sie beim nächsten Mal ausprobieren?")
            ]),
        new(
            CourseIds.SupportSomeone,
            "Jemanden ohne Druck unterstützen",
            "Vier Schritte: fragen, zuhören, konkrete Hilfe anbieten und bei Gefahr weitere Unterstützung holen.",
            "Group", "pss10", "PSS-10",
            [
                new("Mit einer einfachen Frage beginnen", 4, [P("Wählen Sie einen ruhigen Moment und Ort, wenn das sicher ist. Fragen Sie, ob die Person reden möchte; Sie müssen nichts erraten und nicht drängen."), List("„Wie geht es dir gerade?“", "„Möchtest du erzählen oder lieber einfach zusammen sein?“", "„Gibt es etwas, wobei ich helfen kann?“"), TestsTab("PSS-10 erfasst den wahrgenommenen Stress des letzten Monats. Der Test misst keine Unterstützungskompetenz und beurteilt nicht den Zustand einer anderen Person.", "pss10"), Crisis("Ich brauche jetzt Hilfe")], "Überlegen Sie sich eine offene, nicht drängende Frage. Sie müssen sie nicht sofort stellen.", "Wie zeigen Sie, dass ein Nein zum Gespräch in Ordnung ist?"),
                new("Zuhören, ohne alles lösen zu wollen", 4, [P("Lassen Sie die Person ausreden und Pausen zu. Fragen Sie nach, ob Sie sie richtig verstanden haben, statt sofort zu raten, zu vergleichen oder eine Diagnose zu stellen."), Quiz("Welche Antwort lässt der Person mehr Raum?", 1, "Eine offene Frage lässt die Person selbst wählen, was sie erzählen möchte.", "„Du musst dich einfach ablenken“", "„Was ist gerade am schwierigsten für dich?“", "„Das kenne ich, ich weiß genau, was du tun musst“")], "Fassen Sie erst in eigenen Worten zusammen, was Sie gehört haben, und fragen Sie, ob es stimmt.", "Was verändert sich, wenn Sie nicht sofort einen Rat geben?"),
                new("Hilfe zur Auswahl anbieten", 4, [P("Unterstützung kann einfach und konkret sein. Fragen Sie, was gerade hilfreicher wäre: zuhören, bei einer Aufgabe helfen oder gemeinsam Informationen suchen. Bieten Sie nur an, was Sie wirklich tun können."), List("„Möchtest du, dass ich zuhöre?“", "„Soll ich bei einer konkreten Sache helfen?“", "„Sollen wir gemeinsam überlegen, an wen du dich wenden kannst?“"), P("Wenn die Person ablehnt, respektieren Sie das. Sie können anbieten, später wieder darüber zu sprechen.")], "Bieten Sie mit Einverständnis eine konkrete Hilfe an oder überlegen Sie, was Sie künftig anbieten könnten.", "Welche Hilfe ist für Sie beide machbar?"),
                new("Weitere Hilfe holen und Grenzen wahren", 4, [P("Sie können da sein, müssen aber nicht allein helfen oder die einzige Stütze sein. Sagen Sie ehrlich, wann Sie erreichbar sind, und schlagen Sie eine vertraute Person oder Fachkraft vor."), P("Wenn die Person von unmittelbarer Gefahr spricht oder nicht sicher bleiben kann, tragen Sie das nicht allein: Holen Sie, wenn möglich, örtliche Notfall- oder Krisenhilfe dazu. Versprechen Sie nicht, eine Lebensgefahr geheim zu halten."), TestsTab("Ein erneuter PSS-10 ist nur ein allgemeiner Hinweis auf wahrgenommenen Stress, keine Bewertung Ihrer Unterstützung und kein Nachweis einer Kurswirkung.", "pss10")], "Wählen Sie eine Grenze oder zusätzliche Unterstützung, damit Sie mit der Belastung nicht allein bleiben.", "An wen können Sie sich selbst wenden?")
            ]),
        new(
            CourseIds.TaskStart,
            "Eine aufgeschobene Aufgabe beginnen",
            "Drei Schritte: den Anfang verkleinern, eine Zeit wählen und ohne Vorwürfe weitermachen.",
            "Checklist", "who5", "WHO-5",
            [
                new("Eine Aufgabe wählen", 3, [P("Aufschieben hängt oft mit einem unklaren Anfang oder einem unangenehmen Gefühl zusammen, nicht mit Faulheit. Benennen Sie die Aufgabe und den ersten sichtbaren Schritt."), TestsTab("WHO-5 ist ein allgemeines Screening des Wohlbefindens der letzten zwei Wochen. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "who5"), Crisis("Ich brauche jetzt Hilfe")], "Wählen Sie eine Aufgabe und einen Schritt von höchstens fünf Minuten.", "Was würde den Anfang klarer machen?"),
                new("Den Start erleichtern", 3, [P("Legen Sie Benötigtes bereit und wählen Sie eine Zeit. Beginnen Sie fünf Minuten und entscheiden Sie dann, ob Sie weitermachen.")], "Notieren Sie, wann, wo und womit Sie anfangen.", "Was könnte stören und wie lässt sich der Schritt vereinfachen?"),
                new("Den nächsten Schritt stützen", 3, [P("Schauen Sie ohne Vorwürfe zurück: Was half, was stand im Weg, und was ist jetzt realistisch? Manchmal sollte die Aufgabe selbst angepasst werden.")], "Merken Sie sich einen hilfreichen Start-Trick.", "Was haben Sie über Ihren Start gelernt?")
            ]),
        new(
            CourseIds.FlexibleStandards,
            "Gut genug darf genügen",
            "Erkennen Sie, wann hohe Ansprüche helfen und wann sie das Fertigwerden erschweren.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Den Preis des Perfekten sehen", 3, [P("Hohe Ansprüche helfen, solange sie nicht zu viel Zeit, Erholung oder die Möglichkeit zum Abschluss kosten. Bemerken Sie eine Regel, die Sie sich setzen."), TestsTab("WHO-5 ist ein allgemeines Screening des Wohlbefindens der letzten zwei Wochen. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "who5"), Crisis("Ich brauche jetzt Hilfe")], "Wählen Sie ein Beispiel, bei dem ein Anspruch im Weg steht.", "Was gibt Ihnen diese Regel, und was kostet sie?"),
                new("Genug definieren", 3, [P("Fragen Sie, für wen das Ergebnis ist und was es wirklich leisten muss. Wählen Sie zwei oder drei Qualitätskriterien statt endlos zu feilen.")], "Setzen Sie für eine Aufgabe eine realistische Grenze zum Fertigwerden.", "Was müssen Sie nicht weiter verbessern?"),
                new("Ein kleines Experiment testen", 3, [P("Wenn es sich sicher anfühlt, lassen Sie eine kleine Unvollkommenheit stehen oder beenden Sie die Arbeit nach einem Timer. Das ist ein Versuch, kein Verzicht auf Qualität.")], "Wählen Sie einen sanften Versuch oder beobachten Sie nur die Regel.", "Was erwarteten Sie, und was geschah?")
            ]),
        new(
            CourseIds.ThoughtLoops,
            "Wenn Gedanken im Kreis laufen",
            "Bemerken Sie wiederkehrende Gedanken und richten Sie Ihre Aufmerksamkeit wieder auf das, was Sie wählen.",
            "Psychology", "gad7", "GAD-7",
            [
                new("Die Schleife bemerken", 3, [P("Wiederkehrende Gedanken fühlen sich manchmal wie Problemlösen an, bringen aber nicht immer eine neue Antwort. Achten Sie darauf, wann sie kommen und was sie auslöst."), TestsTab("GAD-7 erfasst allgemeine Angst der letzten zwei Wochen; es ist weder Diagnose noch Test dieser Kursfähigkeit.", "gad7"), Crisis("Ich brauche jetzt Hilfe")], "Bemerken Sie einen Moment, in dem ein Gedanke kreist.", "Was löst die Schleife oft aus?"),
                new("Gedanke und Tatsache trennen", 3, [P("Benennen Sie ihn als Gedanken: „Ich bemerke den Gedanken, dass …“. Das wertet das Problem nicht ab, sondern macht eine Vorhersage nicht zur Tatsache.")], "Benennen Sie einen Gedanken neutral, ohne mit ihm zu streiten.", "Was verändert sich, wenn es als Gedanke klingt?"),
                new("Zur gewählten Sache zurückkehren", 3, [P("Sie müssen den Gedanken nicht verdrängen. Bemerken Sie ihn und kehren Sie sanft zu Ihrer Tätigkeit zurück. Wenn ein Plan nötig ist, wählen Sie eine Zeit und einen Schritt.")], "Wählen Sie eine kleine Tätigkeit für die nächsten zehn Minuten.", "Worauf möchten Sie Ihre Aufmerksamkeit richten?")
            ]),
        new(
            CourseIds.UncertainDecisions,
            "Ohne volle Sicherheit entscheiden",
            "Vergleichen Sie Fakten, Ihre Prioritäten und einen machbaren nächsten Schritt.",
            "Checklist", "gad7", "GAD-7",
            [
                new("Fakten und Vermutungen trennen", 3, [P("Bei einer schwierigen Wahl fehlen vielleicht Informationen. Notieren Sie, was Sie wissen, was Sie vermuten und was noch nicht feststellbar ist."), TestsTab("GAD-7 erfasst allgemeine Angst der letzten zwei Wochen; es ist weder Diagnose noch Test dieser Kursfähigkeit.", "gad7"), Crisis("Ich brauche jetzt Hilfe")], "Ordnen Sie eine Frage in Fakten und Vermutungen.", "Welche Tatsache wäre am hilfreichsten zu klären?"),
                new("Prioritäten benennen", 3, [P("Vergleichen Sie Optionen nach dem, was Ihnen wichtig ist: Sicherheit, Zeit, Beziehungen, Ressourcen oder Werte. Vielleicht gibt es keine perfekte Wahl.")], "Wählen Sie zwei wichtige Kriterien und vergleichen Sie die Optionen.", "Was möchten Sie vor allem bewahren?"),
                new("Einen nächsten Schritt wählen", 3, [P("Wenn möglich, wählen Sie einen kleinen, umkehrbaren Schritt und einen Termin zur Überprüfung. So bleibt Platz für neue Informationen.")], "Legen Sie einen Schritt und einen Prüftermin fest.", "Wie können Sie die Wahl später überprüfen?")
            ]),
        new(
            CourseIds.PauseBeforeReply,
            "Vor dem Antworten innehalten",
            "Bemerken Sie Spannung, machen Sie eine Pause und entscheiden Sie, ob Sie jetzt antworten.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Spannung früh bemerken", 3, [P("Ärger oder Sorge zeigen sich oft im Körper oder Sprechtempo, bevor eine Antwort durchdacht ist. Achten Sie auf Ihr frühes Signal."), TestsTab("PSS-10 erfasst den wahrgenommenen Stress des letzten Monats. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "pss10"), Crisis("Ich brauche jetzt Hilfe")], "Erinnern Sie sich an ein körperliches oder verhaltensbezogenes Signal.", "Woran merken Sie, dass Sie langsamer werden sollten?"),
                new("Eine kurze Pause nehmen", 3, [P("Wenn es sicher ist, verschieben Sie die Antwort, spüren Sie den Boden unter den Füßen und benennen Sie, was gerade passiert. Sie müssen sich nicht sofort beruhigen.")], "Bereiten Sie vor: „Ich brauche etwas Zeit und antworte später.“", "Welche Pause ist für Sie realistisch?"),
                new("Mit Absicht antworten", 3, [P("Wählen Sie Ihr Ziel: klären, bitten, eine Grenze setzen oder das Gespräch beenden. Wenn es unsicher ist, gehen Sie und suchen Unterstützung.")], "Bereiten Sie einen Satz vor, der Ihr Ziel ausdrückt.", "Was soll die andere Person verstehen?")
            ]),
        new(
            CourseIds.IrritationSignals,
            "Reizbarkeit früh bemerken",
            "Erkennen Sie frühe Signale, senken Sie die Spannung und wählen Sie eine sichere Reaktion.",
            "Forum", "pss10", "PSS-10",
            [
                new("Ein frühes Signal finden", 3, [P("Reizbarkeit kann auf Spannung oder ein Bedürfnis hinweisen, ist aber kein Handlungsbefehl. Achten Sie auf Veränderungen in Körper, Gedanken oder Verhalten."), TestsTab("PSS-10 erfasst den wahrgenommenen Stress des letzten Monats. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "pss10"), Crisis("Ich brauche jetzt Hilfe")], "Benennen Sie ein frühes Signal.", "Was passiert oft, bevor die Reizbarkeit steigt?"),
                new("Die Spannung sicher senken", 3, [P("Wenn möglich, gehen Sie an einen sicheren Ort und verlangsamen Sie den Atem oder nehmen Sie Ihre Umgebung wahr. Sie müssen nicht im Streit bleiben.")], "Wählen Sie eine sichere Möglichkeit für eine Pause.", "Woran merken Sie, dass eine Pause nötig ist?"),
                new("Den nächsten Schritt wählen", 3, [P("Wenn die Spannung sinkt, benennen Sie Ihr Bedürfnis: Zeit, Klarheit, Hilfe oder eine Grenze. Sie können später zurückkommen oder es lassen, wenn es unsicher ist.")], "Bereiten Sie eine Bitte oder Handlung vor.", "Was könnte helfen, Ihre Grenze nicht zu erreichen?")
            ]),
        new(
            CourseIds.ConflictRepair,
            "Nach einem Streit wieder Kontakt aufnehmen",
            "Übernehmen Sie Ihren Anteil, entschuldigen Sie sich ohne Druck und besprechen Sie einen nächsten Schritt.",
            "Forum", "who5", "WHO-5",
            [
                new("Handlung statt Etikett benennen", 3, [P("Benennen Sie nach einem Streit eine konkrete Handlung, statt sich oder andere als schlecht abzustempeln. Kontakt aufzunehmen ist nur eine Möglichkeit, wenn es sicher ist."), TestsTab("WHO-5 ist ein allgemeines Screening des Wohlbefindens der letzten zwei Wochen. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "who5"), Crisis("Ich brauche jetzt Hilfe")], "Beschreiben Sie Ihren Anteil in einem sachlichen Satz.", "Was möchten Sie klären?"),
                new("Konkret um Entschuldigung bitten", 3, [P("Eine Entschuldigung nennt Handlung und mögliche Wirkung, ohne Ausrede oder Forderung nach Vergebung. Sie können sagen, was Sie künftig anders versuchen.")], "Schreiben Sie eine kurze Entschuldigung ohne „aber“.", "Wofür möchten Sie Verantwortung übernehmen?"),
                new("Raum für eine Antwort lassen", 3, [P("Geben Sie der anderen Person Raum zu antworten und eigene Grenzen zu nennen. Versöhnung ist nicht garantiert; manchmal reicht ein praktischer nächster Schritt.")], "Wählen Sie eine Bitte oder Grenze zum Besprechen.", "Welches Ergebnis wäre annehmbar und sicher?")
            ]),
        new(
            CourseIds.LifeTransitions,
            "Sich im eigenen Tempo an Veränderung gewöhnen",
            "Behalten Sie vertraute Stützen, benennen Sie die Veränderung und wählen Sie einen machbaren Schritt.",
            "TrackChanges", "pss10", "PSS-10",
            [
                new("Benennen, was sich verändert hat", 3, [P("Ein neuer Job, Umzug, Studium oder eine Veränderung in der Familie kann mehrere Routinen zugleich betreffen. Sie müssen sich nicht schnell anpassen."), TestsTab("PSS-10 erfasst den wahrgenommenen Stress des letzten Monats. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "pss10"), Crisis("Ich brauche jetzt Hilfe")], "Benennen Sie eine Veränderung und ihre Wirkung auf den Tag.", "Was ist jetzt schwieriger oder anders?"),
                new("Eine vertraute Stütze behalten", 3, [P("Behalten Sie eine einfache Gewohnheit bei, die Ihren Rhythmus trägt: Essenszeit, kurzer Spaziergang, Gespräch oder Abendroutine. Passen Sie sie an.")], "Wählen Sie eine vertraute Stütze für diese Woche.", "Was kann trotz Veränderung bleiben?"),
                new("Den nächsten Schritt machen", 3, [P("Teilen Sie die Anpassung in kleine Fragen: Was müssen Sie wissen, wen können Sie fragen, was kann warten? Ihr Tempo darf wechseln.")], "Wählen Sie eine Frage oder Handlung für die nächsten Tage.", "Welche Unterstützung könnte helfen?")
            ]),
        new(
            CourseIds.GriefAtYourPace,
            "In Ihrem Tempo trauern",
            "Ohne Fristen und vorgeschriebene Phasen: Grundbedürfnisse versorgen und Unterstützung finden.",
            "Healing", "who5", "WHO-5",
            [
                new("Gefühlen Raum geben", 3, [P("Nach einem Verlust erleben Menschen unterschiedliche Gefühle auf unterschiedliche Weise. Es gibt keinen vorgeschriebenen Zeitplan und kein richtiges Trauern."), TestsTab("WHO-5 ist ein allgemeines Screening des Wohlbefindens der letzten zwei Wochen. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "who5"), Crisis("Ich brauche jetzt Hilfe")], "Benennen Sie, was gerade schwer ist oder wozu Sie nicht bereit sind.", "Was möchten Sie sich heute erlauben?"),
                new("Den Tag machbar halten", 3, [P("Wählen Sie an einem schweren Tag ein Grundbedürfnis oder eine kleine Aufgabe. Sie können eine vertraute Person um Gesellschaft oder praktische Hilfe bitten.")], "Verkleinern Sie eine Aufgabe zu einem machbaren Schritt.", "Welche Fürsorge brauchen Sie heute?"),
                new("Nicht allein damit bleiben", 3, [P("Wenn Sie möchten, finden Sie eine Art, sich zu erinnern oder über den Verlust zu sprechen. Wenn Trauer den Alltag länger stark erschwert, ist professionelle Unterstützung möglich.")], "Wählen Sie eine Person oder Stelle, die Sie kontaktieren könnten.", "Welche Unterstützung wäre jetzt behutsam?")
            ]),
        new(
            CourseIds.ReturnToFocus,
            "Nach einer Unterbrechung zum Fokus zurückfinden",
            "Halten Sie die Ablenkung fest, wählen Sie die nächste Handlung und beginnen Sie sanft erneut.",
            "TipsAndUpdates", "who5", "WHO-5",
            [
                new("Die Unterbrechung bemerken", 3, [P("Abgelenkt zu werden gehört zum Arbeiten dazu. Achten Sie darauf, was Sie weggezogen hat: Benachrichtigung, neuer Gedanke, Müdigkeit oder unklarer Schritt."), TestsTab("WHO-5 ist ein allgemeines Screening des Wohlbefindens der letzten zwei Wochen. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "who5"), Crisis("Ich brauche jetzt Hilfe")], "Benennen Sie eine häufige Ablenkung.", "Was unterbricht Ihren Fokus am häufigsten?"),
                new("Notieren und zurückkehren", 3, [P("Notieren Sie die ablenkende Aufgabe kurz, damit Sie sie nicht im Kopf behalten müssen. Formulieren Sie dann einen nächsten Schritt für die aktuelle Aufgabe.")], "Machen Sie eine Notiz und wählen Sie einen Fünf-Minuten-Schritt.", "Was bringt Sie zurück?"),
                new("Die Umgebung erleichtern", 3, [P("Entfernen Sie eine optionale Störung und entscheiden Sie, was Sie beim nächsten Unterbrechen tun. Bei starker Müdigkeit kann eine Pause hilfreicher sein als Durchhalten.")], "Ändern Sie eine Einstellung am Arbeitsplatz oder bei Benachrichtigungen.", "Was hilft ohne Selbstvorwürfe?")
            ]),
        new(
            CourseIds.StudyBlocks,
            "In kurzen Einheiten lernen",
            "Wählen Sie ein Lernziel, einen kurzen Fokusblock und eine Erholungspause.",
            "Checklist", "pss10", "PSS-10",
            [
                new("Ein Lernziel setzen", 3, [P("Wählen Sie ein klares Ergebnis für einen Lernblock: eine Aufgabe lösen, einen kurzen Abschnitt lesen oder ein Thema erklären. Das große Ziel kann warten."), TestsTab("PSS-10 erfasst den wahrgenommenen Stress des letzten Monats. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "pss10"), Crisis("Ich brauche jetzt Hilfe")], "Notieren Sie ein Ergebnis für eine kurze Einheit.", "Woran merken Sie, dass sie beendet ist?"),
                new("Den eigenen Rhythmus finden", 3, [P("Wählen Sie eine Dauer für Fokus und Pause, die zu Ihnen passt. Ein Standardtimer ist optional; richten Sie sich nach Aufmerksamkeit und Gesundheit.")], "Probieren Sie einen kurzen Block mit Pause.", "Welcher Rhythmus war machbar?"),
                new("Erinnerung überprüfen", 3, [P("Versuchen Sie nach der Pause, das Wichtigste ohne Vorlage zu erinnern, und prüfen Sie dann den Stoff. Eine Lücke zeigt, was Sie wiederholen können.")], "Nennen Sie drei Dinge, an die Sie sich erinnern.", "Was könnten Sie als Nächstes wiederholen?")
            ]),
        new(
            CourseIds.BodyNeutrality,
            "Die eigene Erscheinung neutraler betrachten",
            "Weniger vergleichen, neutral wahrnehmen und zu wichtigen Tätigkeiten zurückkehren.",
            "Healing", "who5", "WHO-5",
            [
                new("Aufmerksamkeit auf das Aussehen bemerken", 3, [P("Viele Menschen sind zeitweise unzufrieden mit ihrem Aussehen. Häufiges Prüfen und Vergleichen kann viel Kraft kosten. Sie müssen nicht jedes Merkmal lieben."), TestsTab("WHO-5 ist ein allgemeines Screening des Wohlbefindens der letzten zwei Wochen. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "who5"), Crisis("Ich brauche jetzt Hilfe")], "Bemerken Sie, wann Gedanken über Ihr Aussehen Aufmerksamkeit binden.", "Was schieben Sie deshalb auf?"),
                new("Eine neutrale Sicht versuchen", 3, [P("Beschreiben Sie neutral, was Sie bemerken, oder was Ihr Körper Ihnen heute ermöglicht. Sie müssen weder dankbar noch zufrieden sein.")], "Ersetzen Sie eine Bewertung durch eine neutrale Beobachtung.", "Welche Worte sind weniger hart und genauer?"),
                new("Zu Wichtigem zurückkehren", 3, [P("Wählen Sie eine Tätigkeit, die aus anderen Gründen wichtig ist: Kontakt, Lernen, Ruhe oder Hobby. Wenn Körpergedanken Essen, Gesundheit oder Alltag stören, ist Fachhilfe möglich.")], "Kehren Sie zu einer kleinen aufgeschobenen Tätigkeit zurück.", "Was ist Ihnen außer dem Aussehen wichtig?")
            ]),
        new(
            CourseIds.SelfWorth,
            "Mehr wert als die eigenen Erfolge",
            "Erkennen Sie Rollen und Qualitäten jenseits von Ergebnissen und wählen Sie eine bedeutsame Handlung.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Über Ergebnisse hinausblicken", 3, [P("Arbeit und Erfolg sind Teile des Lebens, aber nicht Ihr ganzer Wert. Denken Sie an Rollen, Beziehungen und Eigenschaften, die unabhängig von Leistung wichtig sind."), TestsTab("WHO-5 ist ein allgemeines Screening des Wohlbefindens der letzten zwei Wochen. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "who5"), Crisis("Ich brauche jetzt Hilfe")], "Benennen Sie eine wichtige Rolle oder Qualität.", "Was ist an Ihnen wertvoll, auch ohne Ergebnis?"),
                new("Ein konkretes Beispiel finden", 3, [P("Erinnern Sie sich an einen kleinen Moment von Freundlichkeit, Mut, Neugier oder Verlässlichkeit. Sie müssen nicht beweisen, dass Sie immer so sind.")], "Finden Sie ein aktuelles Beispiel.", "Was übersehen Sie an sich selbst oft?"),
                new("Nach Wichtigem handeln", 3, [P("Wählen Sie eine Handlung, die eine Ihnen wichtige Qualität ausdrückt und nicht von Leistung oder Lob abhängt. Sie darf klein sein.")], "Tun oder planen Sie eine solche Handlung.", "Was sagt dieser Schritt über Ihre Prioritäten?")
            ]),
        new(
            CourseIds.SocialSteps,
            "Kleine Schritte in sozialen Situationen",
            "Wählen Sie einen sicheren Kontakt, prüfen Sie Erwartungen und gehen Sie in Ihrem Tempo vor.",
            "Group", "gad7", "GAD-7",
            [
                new("Eine machbare Situation wählen", 3, [P("Wenn soziale Situationen beunruhigen, beginnen Sie mit einer, die etwas herausfordernd und sicher wirkt. Sie dürfen einen unpassenden Schritt ablehnen."), TestsTab("GAD-7 erfasst allgemeine Angst der letzten zwei Wochen; es ist weder Diagnose noch Test dieser Kursfähigkeit.", "gad7"), Crisis("Ich brauche jetzt Hilfe")], "Wählen Sie einen kurzen Kontakt, der Ihnen wichtig ist.", "Was wirkt machbar statt perfekt?"),
                new("Eine Erwartung überprüfen", 3, [P("Notieren Sie vor dem Kontakt Ihre Sorge und was sonst geschehen könnte. Sie müssen die Sorge nicht widerlegen; lassen Sie Raum für andere Ausgänge.")], "Notieren Sie eine Erwartung und eine Alternative.", "Was haben Sie während des Kontakts bemerkt?"),
                new("Aus der Erfahrung lernen", 3, [P("Halten Sie danach fest, was half, was schwierig war und welcher nächste Schritt passt. Tempo, Wiederholung und Pausen bestimmen Sie.")], "Wählen Sie: wiederholen, verkleinern oder pausieren.", "Was gab Ihnen mehr Sicherheit?")
            ]),
        new(
            CourseIds.AppointmentPreparation,
            "Einen wichtigen Termin vorbereiten",
            "Sammeln Sie Fragen, benennen Sie Ihr Anliegen und klären Sie nächste Schritte mit einer Fachperson.",
            "Forum", "pss10", "PSS-10",
            [
                new("Das Wichtigste benennen", 3, [P("Entscheiden Sie vor dem Termin, welche Frage am wichtigsten ist und was Sie besprechen möchten. Sie müssen sich nicht selbst diagnostizieren."), TestsTab("PSS-10 erfasst den wahrgenommenen Stress des letzten Monats. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "pss10"), Crisis("Ich brauche jetzt Hilfe")], "Schreiben Sie das Hauptthema in einem Satz auf.", "Was sollten Sie unbedingt fragen?"),
                new("Kurze Notizen vorbereiten", 3, [P("Wenn es hilft, notieren Sie Beginn und Veränderungen der Beschwerden sowie wichtige Medikamente oder Fragen. Sie können auf Wunsch jemanden mitbringen.")], "Bereiten Sie bis zu drei Fragen oder Beobachtungen vor.", "Welche Notiz hilft Ihnen beim Gespräch?"),
                new("Den Plan klären", 3, [P("Bitten Sie die Fachperson, unklare Begriffe und den nächsten Schritt zu erklären. Sie dürfen nachfragen oder sagen, dass Sie noch nicht entscheiden möchten.")], "Bereiten Sie eine Bitte um Erklärung oder Zeit vor.", "Was hilft Ihnen, den Plan zu verstehen?")
            ]),
        new(
            CourseIds.WaitingForAnswer,
            "Die Wartezeit auf eine Antwort überstehen",
            "Begrenzen Sie das Nachsehen, behalten Sie Routinen bei und wählen Sie, was Sie beeinflussen können.",
            "Psychology", "gad7", "GAD-7",
            [
                new("Warten und Kontrolle trennen", 3, [P("Das Warten auf eine Antwort kann viel Aufmerksamkeit binden, auch wenn Sie sie nicht beschleunigen können. Trennen Sie Beeinflussbares von Nichtbeeinflussbarem."), TestsTab("GAD-7 erfasst allgemeine Angst der letzten zwei Wochen; es ist weder Diagnose noch Test dieser Kursfähigkeit.", "gad7"), Crisis("Ich brauche jetzt Hilfe")], "Notieren Sie je einen Punkt in beiden Gruppen.", "Was können Sie tun, was muss warten?"),
                new("Eine Zeit zum Nachsehen festlegen", 3, [P("Wählen Sie eine angemessene Zeit, um Nachrichten oder Status erneut zu prüfen. Dazwischen kehren Sie zu einer gewöhnlichen Aufgabe oder Pause zurück.")], "Legen Sie die nächste Prüfzeit fest.", "Was hilft gegen automatisches Nachsehen?"),
                new("Auf beide Ausgänge vorbereiten", 3, [P("Wählen Sie einen kleinen nächsten Schritt für eine Antwort und für eine Verzögerung. Das ist keine Vorhersage, sondern gibt Ihnen während des Wartens eine Wahl.")], "Legen Sie bei Bedarf einen Termin zum Nachfragen fest.", "Woran möchten Sie sich beim Warten halten?")
            ]),
        new(
            CourseIds.AskForHelp,
            "Konkret um Hilfe bitten",
            "Benennen Sie Ihren Bedarf, eine mögliche Ansprechperson und eine machbare Bitte.",
            "Group", "who5", "WHO-5",
            [
                new("Den Bedarf erkennen", 3, [P("Eine konkrete Bitte ist leichter zu verstehen: Zeit, ein Gespräch, Information oder Hilfe bei einer Aufgabe. Sie müssen nicht alles allein schaffen."), TestsTab("WHO-5 ist ein allgemeines Screening des Wohlbefindens der letzten zwei Wochen. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "who5"), Crisis("Ich brauche jetzt Hilfe")], "Benennen Sie einen Bedarf ohne Begründung.", "Welche Hilfe würde etwas erleichtern?"),
                new("Person und Worte wählen", 3, [P("Überlegen Sie, wer genau dabei helfen könnte. Eine kurze Bitte mit konkreter Handlung und Zeit erleichtert die Antwort.")], "Formulieren Sie einen Satz mit Ihrer Bitte.", "Wen könnten Sie wann fragen?"),
                new("Verschiedene Antworten zulassen", 3, [P("Die Person kann zustimmen, etwas anderes anbieten oder ablehnen. Ihr Bedarf bleibt wichtig; Sie können jemand anderen oder eine Stelle anfragen.")], "Wählen Sie eine Ersatzmöglichkeit für Unterstützung.", "Wie sorgen Sie nach der Bitte für sich?")
            ]),
        new(
            CourseIds.CaregiverLimits,
            "Jemanden unterstützen, ohne sich selbst zu verlieren",
            "Teilen Sie Aufgaben, benennen Sie Grenzen und finden Sie zusätzliche Unterstützung.",
            "Group", "pss10", "PSS-10",
            [
                new("Den Umfang der Fürsorge sehen", 3, [P("Unterstützung besteht oft aus vielen unsichtbaren Aufgaben. Listen Sie die wichtigsten auf und überlegen Sie, was wirklich Ihre Beteiligung braucht."), TestsTab("PSS-10 erfasst den wahrgenommenen Stress des letzten Monats. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "pss10"), Crisis("Ich brauche jetzt Hilfe")], "Benennen Sie eine Aufgabe, die besprochen oder geteilt werden kann.", "Was erschöpft Sie gerade am meisten?"),
                new("Eine Grenze benennen", 3, [P("Eine Grenze bedeutet nicht, jemanden im Stich zu lassen. Sie beschreibt ehrlich, welche Zeit, Kraft oder Hilfe Sie sicher anbieten können.")], "Formulieren Sie eine Grenze für Ihre Unterstützung.", "Wie können Sie sie klar und ruhig sagen?"),
                new("Weitere Unterstützung finden", 3, [P("Überlegen Sie, welche Menschen, Dienste oder praktischen Änderungen die Last teilen könnten. Wenn Versorgung nicht sicher möglich ist, holen Sie professionelle oder Notfallhilfe.")], "Wählen Sie eine zusätzliche Unterstützung.", "Wen könnten Sie diese Woche kontaktieren?")
            ]),
        new(
            CourseIds.LowEnergyRoutine,
            "Ein sanfter Plan für kraftarme Tage",
            "Behalten Sie das Nötigste, verkleinern Sie den ersten Schritt und planen Sie Erholung ein.",
            "TipsAndUpdates", "who5", "WHO-5",
            [
                new("Das Minimum wählen", 3, [P("An einem kraftarmen Tag müssen Sie Ihren normalen Plan nicht erfüllen. Wählen Sie eine notwendige Aufgabe und was warten kann."), TestsTab("WHO-5 ist ein allgemeines Screening des Wohlbefindens der letzten zwei Wochen. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "who5"), Crisis("Ich brauche jetzt Hilfe")], "Kürzen Sie die Liste auf einen wichtigen Punkt.", "Was kann heute wirklich nicht warten?"),
                new("Den ersten Schritt verkleinern", 3, [P("Teilen Sie die Aufgabe in eine Zwei-Minuten-Handlung und legen Sie Benötigtes bereit. Wenn auch das zu viel ist, bitten Sie um Hilfe.")], "Wählen Sie den kleinsten sicheren Schritt.", "Was würde ihn leichter machen?"),
                new("Erholung einplanen", 3, [P("Planen Sie eine kurze Pause, ohne sie erst verdienen zu müssen. Wenn geringe Kraft oder Stimmung länger den Alltag stören, ist professionelle Unterstützung möglich.")], "Wählen Sie eine Pause oder eine Person zum Kontakt.", "Was hilft Ihnen, damit nicht allein zu bleiben?")
            ]),
        new(
            CourseIds.AfterDifficultTalk,
            "Nach einem schwierigen Gespräch wieder zur Ruhe kommen",
            "Kehren Sie ins Hier und Jetzt zurück, trennen Sie Fakten von Vermutungen und wählen Sie einen sicheren Schritt.",
            "Psychology", "pss10", "PSS-10",
            [
                new("Die Spannung senken", 3, [P("Nach einem schwierigen Gespräch braucht der Körper vielleicht Zeit. Spüren Sie eine Stütze, sehen Sie sich um und benennen Sie Ihren Ort. Sie müssen noch nicht entscheiden, wer recht hatte."), TestsTab("PSS-10 erfasst den wahrgenommenen Stress des letzten Monats. Es misst weder die Fähigkeit dieses Kurses noch dessen Wirkung.", "pss10"), Crisis("Ich brauche jetzt Hilfe")], "Machen Sie eine kurze Pause und nehmen Sie die Umgebung wahr.", "Was hilft Ihnen, sich hier und jetzt zu fühlen?"),
                new("Worte von Schlüssen trennen", 3, [P("Notieren Sie getrennt, was gesagt oder getan wurde und was Sie daraus schließen. Das wertet Gefühle nicht ab, sondern hilft bei der nächsten Wahl.")], "Trennen Sie eine Tatsache von einer Deutung.", "Was wissen Sie, was vermuten Sie?"),
                new("Über die Fortsetzung entscheiden", 3, [P("Sie können etwas klären, um Zeit bitten oder den Kontakt nicht fortsetzen. Bei Drohungen oder Kontrolle kehren Sie nicht allein zum Gespräch zurück.")], "Wählen Sie eine sichere Möglichkeit für das nächste Mal.", "Welche Grenze oder Unterstützung brauchen Sie?")
            ]),
    ];
}
