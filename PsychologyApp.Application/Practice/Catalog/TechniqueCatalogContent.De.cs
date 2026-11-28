using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice.Catalog;

internal static class TechniqueCatalogContentDe
{
    internal static TheorySection[] Theory(string what, string when, string how, string example) =>
    [
        new("Was es ist", what),
        new("Wann du es ausprobieren kannst", when),
        new("Wie die Übung abläuft", how),
        new("Beispiel", example)
    ];

    /// <summary>Common topics for a "problem" field: a start to tap and then add a word or two, not a full answer.</summary>
    private static readonly string[] ProblemTopics =
        ["Streit mit einem nahen Menschen", "Etwas auf der Arbeit", "Konflikt mit meinem Chef", "Studium oder eine Prüfung", "Gesundheit", "Geld", "Einsamkeit", "Ein Misserfolg", "Eine Trennung", "Beziehung zu meinen Eltern", "Kinder", "Ein Umzug", "Die Zukunft", "Kritik an mir"];

    private static readonly string[] BackupOptions =
        ["Um Hilfe bitten", "Abwarten und es erneut versuchen", "Einen anderen Weg finden", "Weniger von mir verlangen", "Eine Pause machen", "Mit einem nahen Menschen darüber reden", "Zu einer Fachperson gehen", "Einen Nebenjob finden", "Einen Kurs machen", "Die Aufgabe in Schritte teilen", "Die Entscheidung verschieben", "Klein anfangen"];

    private static readonly string[] HarshThoughts =
        ["„Ich mache alles kaputt“", "„Sie werden mich verurteilen“", "„Ich schaffe das nicht“", "„Niemand braucht mich“", "„Das ist eine Katastrophe“", "„Nichts wird klappen“", "„Ich bin schlechter als andere“", "„Immer geht alles schief“", "„Es ist meine Schuld“", "„Mit mir stimmt etwas nicht“", "„Das hört nie auf“", "„Ich muss perfekt sein“"];

    internal static readonly BuiltInTechniqueDefinition Spin = new(
        "Übung", "Ein Gefühl benennen",
        [
            "1. Wähle eine kürzlich erlebte, leicht belastende Alltagssituation",
            "2. Benenne das wichtigste Gefühl",
            "3. Bewerte, wie stark es sich jetzt anfühlt (0–10)"
        ],
        "Notiere kurz die Situation und das Gefühl, ohne sofortige Erleichterung zu erwarten.",
        TechniqueUiKind.Entry, "Technik Nr. 1", "26.01.2023", "Ein Gefühl benennen", "Nimm wahr, was gerade da ist", "Schwerer Moment", "Team PsychologyApp", 5, "Autorenew",
        [
            new TechniqueEntrySeed("Situation", "Zum Beispiel: ein kleiner Vorfall bei der Arbeit. Keine belastenden Einzelheiten.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Hauptgefühl", "Kränkung, Sorge, Wut…", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("Stärke des Gefühls jetzt", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Hier hältst du die Situation, das Gefühl und seine aktuelle Stärke fest. Das ist Selbstbeobachtung, keine Behandlung und kein Versprechen, dass sich das Gefühl sofort ändert.",
            "Für eine leicht unangenehme Alltagssituation, wenn es sich gut anfühlt, darüber zu schreiben. Wähle keine traumatische Erinnerung und keine akute Krise.",
            "Beschreibe nur das Nötige und bewerte das Gefühl jetzt. Wenn die Anspannung zunimmt, höre auf, schau dich um und wähle eine neutralere Übung. Wiederholen ist nicht nötig.",
            "Situation: Ein Kollege unterbrach mich. Gefühl: Ärger. Stärke jetzt: 5 von 10."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Comparison = new(
        "Übung", "Den größeren Zusammenhang sehen",
        [
            "1. Benenne, was gerade schwierig ist, ohne es kleinzureden",
            "2. Welche Lebensbereiche sind davon betroffen?",
            "3. Was ist daneben wichtig oder braucht ebenfalls Aufmerksamkeit?",
            "4. Um wen oder was möchtest du dich heute kümmern?",
            "5. Notiere, was dir auffällt, ohne das Problem als klein oder groß zu bewerten"
        ],
        "Die Übung macht verschiedene Lebensbereiche sichtbar; sie bewertet nicht, wie ernst ein Problem ist.",
        TechniqueUiKind.Entry, "Technik Nr. 2", "26.01.2023", "Den größeren Zusammenhang sehen", "Wenn eine Schwierigkeit deine ganze Aufmerksamkeit einnimmt", "Größe des Problems", string.Empty, 7, "CompareArrows",
        [
            new TechniqueEntrySeed("Was ist los", "Was ist gerade schwierig?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Betroffene Bereiche", "Zum Beispiel: Arbeit, Gesundheit, Beziehungen", Suggestions: ["Arbeit", "Familie", "Freunde", "Gesundheit", "Studium", "Geld", "Beziehungen", "Schlaf", "Zuhause", "Hobbys", "Erholung", "Pläne"]),
            new TechniqueEntrySeed("Was ist noch wichtig", "Was braucht ebenfalls Aufmerksamkeit?", Suggestions: ["Arbeit", "Familie", "Gesundheit", "Beziehungen", "Erholung", "Kinder", "Freunde", "Studium", "Schlaf", "Innere Ruhe", "Persönliche Entwicklung", "Alltag"]),
            new TechniqueEntrySeed("Worum du dich kümmern möchtest", "Wer oder was braucht heute deine Aufmerksamkeit?", Suggestions: ["Gesundheit", "Nahestehende", "Schlaf", "Erholung", "Ein Arbeitsthema", "Ein Gespräch", "Eine Alltagsaufgabe", "Eigene Grenzen", "Noch unklar"]),
            new TechniqueEntrySeed("Was fällt dir auf", "Du musst kein positives Fazit finden")
        ],
        Theory(
            "Die Übung hilft, weitere Bedürfnisse und Aufgaben zu benennen, ohne die Schwierigkeit selbst abzuwerten.",
            "Wenn ein Thema fast deine ganze Aufmerksamkeit einnimmt und du weitere Bedürfnisse oder Aufgaben festhalten möchtest.",
            "Schreibe in deinen eigenen Worten und suche nicht nach einer positiven Wendung. Wenn ein konkreter Schritt oder Sicherheit nötig ist, kümmere dich zuerst darum. Du kannst Felder überspringen.",
            "Die Jobsuche belastet Geld und Schlaf; zugleich braucht eine nahestehende Person heute Aufmerksamkeit. Vielleicht wählst du einen Schritt bei der Suche und bittest um Unterstützung. Das macht die Sorge nicht weniger ernst."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Polarity = new(
        "Übung", "Polaritäten",
        [
            "1. Schreib auf, was dir an der Situation gefällt",
            "2. Schreib auf, was dir nicht gefällt",
            "3. Vergleiche die Paare und bemerke das Gleichgewicht"
        ],
        "Die Polaritätenmethode hilft, beide Seiten zu sehen und innere Anspannung zu senken.",
        TechniqueUiKind.Polarity, "Technik Nr. 3", "26.01.2023", "Polaritäten", "Beide Seiten einer Situation sehen", "Verschiedene Seiten", "Zivorad Slavinski", 5, "Contrast",
        null,
        Theory(
            "Jede Situation hat angenehme und unangenehme Seiten. Beide zu benennen löst die einseitige Fixierung.",
            "Wenn du nur das Negative oder nur das Positive siehst und feststeckst.",
            "Füge zu einem Thema Paare aus „gefällt mir“ und „gefällt mir nicht“ hinzu. Vergleiche die Listen, ohne zu urteilen, was richtig ist.",
            "Arbeit: Das Gehalt gefällt mir, die Arbeitszeiten nicht. Zuhause: Die Gemütlichkeit gefällt mir, der Lärm der Nachbarn nicht."),
        "Was dir nicht gefällt", "Was dir gefällt");

    internal static readonly BuiltInTechniqueDefinition Paper = new(
        "Übung", "Ein Gedanke auf Papier",
        [
            "1. Schreibe einen Gedanken unten oder auf ein Blatt",
            "2. Lies ihn einmal und benenne, wenn du möchtest, das Gefühl",
            "3. Entscheide, was du mit dem Blatt machst: behalten, falten oder zerreißen. Du kannst auch nichts tun"
        ],
        "Beim Schreiben kannst du die Formulierung eines Gedankens bemerken; das Blatt muss nicht zerstört werden und Erleichterung ist nicht zu erwarten.",
        TechniqueUiKind.Paper, "Technik Nr. 4", "26.01.2023", "Ein Gedanke auf Papier", "Wenn ein Gedanke immer wiederkommt", "Gedanken", "Team PsychologyApp", 3, "Description",
        [new TechniqueEntrySeed("Gedanke", "Zum Beispiel: „Ich vermassle die Präsentation.“", Suggestions: HarshThoughts)],
        Theory(
            "Du schreibst einen Gedanken auf, um seine Formulierung wahrzunehmen. Das ist Selbstbeobachtung, keine Behandlung und keine Garantie, dass sich ein Gefühl ändert.",
            "Wenn ein Gedanke wiederkehrt und du dich mit dem Aufschreiben wohlfühlst. Hör auf, wenn es dir dadurch schlechter geht.",
            "Schreibe einen Satz auf und lies ihn einmal. Ob du das Blatt behältst, weglegst oder zerreißt, entscheidest du. Du musst dich nicht zur Ruhe zwingen.",
            "Gedanke: „Ich vermassle die Präsentation.“ Du könntest die Notiz behalten und eine Folie überprüfen."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Future = new(
        "Übung", "Blick aus der Zukunft",
        [
            "1. Wähle eine überschaubare Alltagsschwierigkeit",
            "2. Stell dir vor, du blickst aus einem selbst gewählten Zeitraum zurück — etwa einem oder fünf Jahren"
        ],
        "Bewerte die Situation mit zeitlichem Abstand. Sie kann wichtig bleiben; du musst sie nicht kleinreden.",
        TechniqueUiKind.Entry, "Technik Nr. 5", "30.01.2023", "Blick aus der Zukunft", "Eine weitere Perspektive einnehmen", "Umfang des Problems", "Team PsychologyApp", 2, "Schedule",
        [
            new TechniqueEntrySeed("Situation", "Zum Beispiel: eine überschaubare Schwierigkeit bei der Arbeit.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Wie wichtig wirkt es aus diesem Abstand?", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Der Blick aus der Zukunft ist eine vorgestellte Perspektive auf eine Situation. Ihre Bedeutung kann gleich bleiben — auch das ist in Ordnung.",
            "Für eine überschaubare Alltagsschwierigkeit. Wähle keine traumatische Erinnerung und kein dringendes Problem, das sofortiges Handeln erfordert.",
            "Wähle einen Zeitraum, etwa ein oder fünf Jahre. Stell dir vor, du betrachtest die Situation von dort aus, und bewerte sie. Es gibt keine richtige Zahl; hör auf, wenn die Übung nicht passt.",
            "Eine verpasste Einladung kann auch in einem Jahr noch wichtig sein. Heute kannst du nachfragen oder einen anderen nächsten Schritt wählen."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Hack = new(
        "Übung", "Pause mit Details",
        [
            "1. Wähle einen neutralen Gegenstand in deiner Nähe, ohne an eine belastende Erinnerung zurückzugehen",
            "2. Nenne drei Merkmale: Farbe, Form und Oberfläche",
            "3. Entscheide, ob du weitermachen oder aufhören möchtest"
        ],
        "Eine kurze Orientierung an einem Gegenstand in deiner Nähe, ohne ein schmerzhaftes Ereignis erneut aufzurufen.",
        TechniqueUiKind.Entry, "Technik Nr. 6", "30.01.2023", "Pause mit Details", "Richte die Aufmerksamkeit auf die Umgebung", "Schwerer Moment", "Team PsychologyApp", 3, "BlurOn",
        [new TechniqueEntrySeed("Gegenstand in der Nähe", "Zum Beispiel: eine Tasse, ein Fenster oder ein Buch.", Role: EntryFieldRole.None)],
        Theory(
            "Richte deine Aufmerksamkeit auf einen neutralen Gegenstand im Hier und Jetzt. Das ist eine kurze Orientierungsübung, keine Behandlung und kein Ersatz für professionelle Hilfe.",
            "Wenn du dich kurz auf deine Umgebung konzentrieren möchtest. Nutze die Übung nicht statt dringender Hilfe.",
            "Nenne drei Merkmale des Gegenstands. Wenn es dir schlechter oder unangenehm wird, höre auf, schau dich um und wähle etwas anderes.",
            "Zum Beispiel: eine Tasse — weiß, rund, kühl."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Experience = new(
        "Übung", "Erfahrung verändern",
        [
            "1. Wähle einen Bereich, an dem du arbeiten willst",
            "2. Beschreibe deine Haltung dazu",
            "3. Benenne die damit verbundenen Überzeugungen",
            "4. Wie verändert sich die Haltung, wenn du an frühere Erfahrungen denkst?",
            "5. Beschreibe eine negative Erfahrung",
            "6. Bewerte die negative Erfahrung (−10…10)",
            "7. Welche positive Erfahrung könnte sie ersetzen?",
            "8. Wie würde sich deine Haltung mit dieser Erfahrung verändern?",
            "9. Bewerte die neue Erfahrung (−10…10)"
        ],
        "EMO hilft, eine einschränkende Erfahrung durch eine unterstützendere zu ersetzen.",
        TechniqueUiKind.Entry, "Technik Nr. 7", "08.02.2023", "Erfahrung verändern", "Eine einschränkende Erfahrung umschreiben", "Schwerer Moment", "Filip Slavinski", 15, "Psychology",
        [
            new TechniqueEntrySeed("Bereich", "Beziehungen, Arbeit, Gesundheit…", Suggestions: ["Beziehungen", "Arbeit", "Gesundheit", "Geld", "Öffentliches Sprechen", "Familie", "Studium", "Aussehen", "Freundschaft", "Kreativität", "Sport", "Karriere"]),
            new TechniqueEntrySeed("Haltung zu diesem Bereich", "Wie empfindest du es jetzt?", Suggestions: ["Angst", "Selbstzweifel", "Gereiztheit", "Gleichgültigkeit", "Interesse", "Müdigkeit", "Furcht", "Scham", "Hoffnung", "Wut", "Verwirrung", "Ruhe"]),
            new TechniqueEntrySeed("Verbundene Überzeugungen", "Z. B. „Ich schaffe es nicht“", Suggestions: ["„Ich schaffe es nicht“", "„Ich bin nicht gut genug“", "„Man wird mich nicht akzeptieren“", "„Nichts wird sich ändern“", "„Ich muss perfekt sein“", "„Ich habe kein Glück“", "„Ich verdiene es nicht“", "„Andere sind besser“", "„Fehler sind verboten“", "„Dafür bin ich zu alt“"]),
            new TechniqueEntrySeed("Haltung und frühere Erfahrung", "Was verändert sich, wenn du an früher denkst?", Suggestions: ["Es wird schwerer", "Es wird ruhiger", "Nichts verändert sich", "Wut kommt hoch", "Traurigkeit kommt hoch", "Angst kommt hoch", "Ich erinnere mich, dass ich es geschafft habe", "Ich will es vermeiden"]),
            new TechniqueEntrySeed("Negative Erfahrung", "Eine bestimmte Situation oder ein Muster"),
            new TechniqueEntrySeed("Bewertung der negativen Erfahrung", "", EntryFieldKind.RatingNeg10To10),
            new TechniqueEntrySeed("Positiver Ersatz", "Welche unterstützende Erfahrung ist möglich?", Suggestions: ["Ein Mal, als es mir gelungen ist", "Ein Mal, als ich unterstützt wurde", "Ein Mal, als ich es allein geschafft habe", "Ein Mal, als ich gelobt wurde", "Ein Mal, als ich jemandem geholfen habe", "Ein Mal, als ich etwas Neues gelernt habe", "Ein Mal, als ich nicht aufgegeben habe", "Ein Mal, als ich so angenommen wurde, wie ich bin"]),
            new TechniqueEntrySeed("Haltung mit dem Positiven", "Wie würde sich dein Blick auf den Bereich verändern?", Suggestions: ["Hoffnung kommt auf", "Mehr Ruhe", "Ich will es noch einmal versuchen", "Es wird interessant", "Zuversicht kommt auf", "Es wird leichter", "Ich spüre Kraft", "Noch schwer zu glauben"]),
            new TechniqueEntrySeed("Bewertung der neuen Erfahrung", "", EntryFieldKind.RatingNeg10To10)
        ],
        Theory(
            "Überzeugungen beruhen oft auf einer einzigen eindrücklichen negativen Erfahrung. Ein bewusster Ersatz kann deine Haltung verändern.",
            "Wenn es „schon immer so war“ und Veränderung unmöglich scheint.",
            "Geh die Felder der Reihe nach durch. Vergleiche die beiden Bewertungen — die zweite sollte höher sein.",
            "Bereich: öffentliches Sprechen. Negativ: durchgefallene Prüfung (−8). Ersatz: ein gelungener Vortrag (+6)."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Copied = new(
        "Übung", "Den Gedanken wahrnehmen",
        [
            "1. Notiere einen kurzen Satz, der immer wiederkommt",
            "2. Lies ihn einmal und frage: Tatsache, Vorhersage oder Bewertung?",
            "3. Prüfe, wenn es sich gut anfühlt, eine Tatsache. Hör auf, wenn die Anspannung steigt"
        ],
        "Die Übung hilft, die Formulierung eines Gedankens anzuschauen; Wiederholen garantiert keine geringere Angst.",
        TechniqueUiKind.Copied, "Technik Nr. 8", "21.01.2025", "Den Gedanken wahrnehmen", "Einen Angstgedanken benennen, ohne mit dir zu streiten", "Größe des Problems", string.Empty, 2, "Repeat",
        [new TechniqueEntrySeed("Formulierung", "Ich habe Angst, meinen Job zu verlieren", Suggestions: HarshThoughts)],
        Theory(
            "Dies ist eine kurze Möglichkeit, die Worte eines Gedankens wahrzunehmen und zu prüfen, worauf er beruht. Du musst ihn weder laut sagen noch wiederholen.",
            "Wenn ein Satz immer wiederkommt und du ihn kurz betrachten möchtest. Lass die Übung aus, wenn der Gedanke gerade zu belastend ist.",
            "Schreib den Gedanken in wenigen Worten auf. Frage dich, was du sicher weißt und was eine Vorhersage ist. Zwing dich nicht, eine Antwort zu glauben. Hör auf, wenn die Anspannung steigt.",
            "Gedanke: „Ich werde das Gespräch sicher vermasseln.“ Tatsache: „Morgen habe ich ein Gespräch.“ Wie es ausgeht, ist noch offen."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Extend = new(
        "Übung", "Einen Plan für Unsicherheit machen",
        [
            "1. Benenne die Situation, für die du eine Alternative suchst",
            "2. Notiere eine realistische Möglichkeit und verfügbare Ressourcen",
            "3. Wähle einen nächsten Schritt oder einen Zeitpunkt zum Weiterplanen"
        ],
        "Ein Plan kann mögliche Handlungen sichtbar machen; er garantiert weder einen Ausgang noch sofortige Erleichterung.",
        TechniqueUiKind.Entry, "Technik Nr. 9", "21.01.2025", "Einen Plan für Unsicherheit machen", "Einen praktischen nächsten Schritt finden", "Größe des Problems", string.Empty, 3, "Backup",
        [
            new TechniqueEntrySeed("Situation", "Was könnte anders laufen als geplant?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Praktische Möglichkeit", "Zum Beispiel: eine Frist klären oder um Hilfe bitten", Suggestions: BackupOptions),
            new TechniqueEntrySeed("Ressource oder Unterstützung", "An wen oder was könntest du dich wenden?", Suggestions: BackupOptions),
            new TechniqueEntrySeed("Nächster Schritt", "Was kannst du jetzt tun oder wann willst du weiterplanen?", Suggestions: BackupOptions)
        ],
        Theory(
            "Planung kann mögliche Handlungen klären, aber weder Entscheidungen anderer steuern noch Ruhe garantieren.",
            "Wenn es eine konkrete praktische Unsicherheit gibt und du eine überschaubare Möglichkeit prüfen möchtest.",
            "Trenne bekannte Fakten von Befürchtungen. Finde einen realistischen Schritt, eine Ressource oder einen Zeitpunkt, an dem du zur Frage zurückkehrst. Wenn du dadurch alle Szenarien wiederholt prüfst und angespannter wirst, hör auf.",
            "Falls nach einem Gespräch keine Antwort kommt, kannst du einen passenden Zeitpunkt zum Nachfragen wählen und dich bis dahin anderen Aufgaben widmen. Das sagt nichts darüber aus, wie die Entscheidung ausfällt."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Resize = new(
        "Übung", "Das Bild aus Abstand betrachten",
        [
            "1. Benenne kurz eine Alltagssituation; belastende Erinnerungen brauchst du nicht",
            "2. Stell sie dir nur dann als stilles Bild vor, wenn es sich angenehm anfühlt",
            "3. Du kannst Größe oder Abstand verändern, musst das Bild aber nicht verändern"
        ],
        "Eine freiwillige Visualisierung, um die eigene Aufmerksamkeit wahrzunehmen; sie ändert die Situation nicht und verspricht keine Erleichterung.",
        TechniqueUiKind.Entry, "Technik Nr. 10", "22.01.2025", "Das Bild aus Abstand betrachten", "Abstand nur ausprobieren, wenn es sich gut anfühlt", "Größe des Problems", string.Empty, 2, "ZoomOutMap",
        [new TechniqueEntrySeed("Was dich belastet", "Z. B. ein Konflikt, der dich wach hält", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem)],
        Theory(
            "Dies ist eine kurze Vorstellungsübung: Du kannst ein Bild aus etwas Abstand betrachten. Menschen reagieren unterschiedlich; die Situation selbst ändert sich dadurch nicht.",
            "Nur bei einer überschaubaren Alltagssorge. Wähle keine belastende Erinnerung; du kannst die Übung auslassen.",
            "Stell dir die Situation ohne zusätzliche Details vor. Ändere Größe oder Abstand nur, wenn es sich gut anfühlt. Wenn die Anspannung steigt, hör auf und nimm den Raum um dich wahr.",
            "Du kannst dir eine Aufgabe als Notiz auf dem Tisch vorstellen und entscheiden, wann du zu ihr zurückkehrst. Das Bild muss weder kleiner noch ruhiger werden."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Check = new(
        "Übung", "Die Aufmerksamkeit umlenken",
        [
            "1. Benenne den wiederkehrenden Gedanken kurz und ohne Einzelheiten",
            "2. Bemerke: „Ich habe gerade den Gedanken, dass …“",
            "3. Richte die Aufmerksamkeit, wenn du möchtest, auf einen neutralen Ton oder Gegenstand; der Gedanke darf bleiben"
        ],
        "Die Übung hilft dir zu wählen, worauf du achtest; Gedanken müssen dabei nicht verschwinden.",
        TechniqueUiKind.Entry, "Technik Nr. 11", "22.01.2025", "Die Aufmerksamkeit umlenken", "Den Gedanken bemerken und einen neutralen Fokus wählen", "Größe des Problems", string.Empty, 2, "FactCheck",
        [new TechniqueEntrySeed("Worum deine Gedanken kreisen", "Welcher Gedanke kommt immer wieder?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem)],
        Theory(
            "Das ist eine kurze Möglichkeit, einen wiederkehrenden Gedanken zu bemerken und der Aufmerksamkeit eine andere Aufgabe zu geben. Du musst den Gedanken nicht unterdrücken oder ruhig werden.",
            "Wenn du ein Thema immer wieder durchgehst und eine kurze Umlenkung ausprobieren möchtest. Geht es um eine reale Gefahr, kümmere dich zuerst um die Sicherheit.",
            "Benenne den Gedanken in einem Satz und wähle dann einen neutralen Ton oder Gegenstand in deiner Umgebung. Hör auf, wenn die Anspannung steigt. Ersetze damit keine nötige medizinische oder praktische Handlung.",
            "Gedanke: „Was, wenn ich krank bin?“ Du kannst ihn als Gedanken bemerken und überlegen, ob ein konkreter Schritt nötig ist, etwa eine ärztliche Einschätzung zu einem Symptom."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Observer = new(
        "Übung", "Selbstgespräch mit Abstand",
        [
            "1. Benenne Situation und Gefühl in einem Satz; Details eines belastenden Ereignisses brauchst du nicht.",
            "2. Sprich dich mit deinem Namen oder mit „du“ statt nur mit „ich“ an. Zum Beispiel: „[Name], was passiert gerade?“",
            "3. Schreibe auf, was jetzt wichtig ist und welcher sichere, machbare Schritt möglich ist. Entschuldige keinen Schaden und spiele keine Gefahr herunter.",
            "4. Bewerte jetzt deine Anspannung. Sie kann sinken, gleich bleiben oder steigen. Wenn es dir schlechter geht, hör auf und wähle andere Unterstützung."
        ],
        "Eine kurze Variante des distanzierten Selbstgesprächs: Sprich dich mit deinem Namen oder mit „du“ statt nur mit „ich“ an. Das kann Raum zum Nachdenken schaffen, verspricht aber keine sofortige Erleichterung.",
        TechniqueUiKind.Entry, "Technik Nr. 12", "12.06.2026", "Selbstgespräch mit Abstand", "Sprich dich mit deinem Namen oder „du“ an und wähle einen sicheren Schritt", "Schwerer Moment", "Selbsthilfe", 1, "Visibility",
        [
            new TechniqueEntrySeed("Situation", "Kurz: Was geschieht gerade? Details eines belastenden Ereignisses sind nicht nötig.", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Gefühle in der Ich-Form", "Was fühlst du? Ein kurzer Satz genügt.", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("Was der Beobachter sieht", "Sprich dich mit deinem Namen oder „du“ an: Was ist jetzt wichtig, und welcher sichere Schritt ist möglich?", Suggestions: ["[Name], was ist dir gerade wichtig?", "Was ist ein sicherer, machbarer Schritt?", "Wie kannst du dich unterstützen?", "Was würdest du einem nahestehenden Menschen sagen?", "Du kannst später antworten, wenn es klarer ist"]),
            new TechniqueEntrySeed("Anspannung jetzt", "Bewerte sie am Ende; sie kann gleich bleiben.", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Beim distanzierten Selbstgespräch verwendest du deinen Namen oder „du“ statt nur „ich“. Das kann Raum zum Nachdenken schaffen, garantiert aber keine sofortige Erleichterung.",
            "Probiere es bei erträglichem emotionalem oder sozialem Stress und nur, wenn du gerade sicher bist. Nutze es nicht, um Schaden zu rechtfertigen oder Gefahr herunterzuspielen.",
            "Benenne das Gefühl kurz, sprich dich mit deinem Namen oder „du“ an und frage, was jetzt wichtig ist und welcher sichere Schritt möglich ist.",
            "Statt „Ich schaffe das nicht“: „[Name], das ist gerade schwer. Was ist ein sicherer nächster Schritt für dich?“"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Anchor = new(
        "Übung", "Erinnerung an Unterstützung",
        [
            "1. Erinnere dich an einen sicheren Moment, in dem du Unterstützung erlebt oder eine Schwierigkeit bewältigt hast",
            "2. Achte darauf, was geholfen hat und was du im Körper wahrgenommen hast",
            "3. Wenn du möchtest, wähle eine Geste nur als Erinnerung an dieses Erlebnis",
            "4. Bewerte, wie hilfreich die Erinnerung jetzt ist (0 = gar nicht, 10 = sehr); 0 ist in Ordnung"
        ],
        "Eine Erinnerung kann dich an vertraute Quellen der Unterstützung erinnern. Die Wirkung ist individuell; eine Geste ist nur ein freiwilliger Hinweis und verändert den Zustand nicht zuverlässig.",
        TechniqueUiKind.Entry, "Technik Nr. 13", "12.06.2026", "Erinnerung an Unterstützung", "Erinnere dich an Unterstützung und bemerke verfügbare Ressourcen", "Schwieriger Moment", "Erinnerungsübung", 4, "SelfImprovement",
        [
            new TechniqueEntrySeed("Ressourcenerinnerung", "Wähle nur eine Erinnerung, die sich sicher anfühlt; sonst kannst du die Übung auslassen.", Suggestions: ["Ein gelungener Vortrag", "Ein Urlaub am Meer", "Eine Umarmung von einem nahen Menschen", "Etwas Schweres geschafft", "Ein Spaziergang in der Natur", "Eine bestandene Prüfung", "Die Geburt eines Kindes", "Ein Sieg im Wettkampf", "Ein Abend mit Freunden", "Lob von meiner Chefin oder meinem Chef", "Der erste Tag in einem neuen Job", "Ein Morgen ohne Eile"]),
            new TechniqueEntrySeed("Körperempfindungen", "Wo spürst du es? Wärme, Leichtigkeit, Halt…", Suggestions: ["Wärme in der Brust", "Leichtigkeit", "Offene Schultern", "Gleichmäßiger Atem", "Feste Beine", "Ein Lächeln", "Ein ruhiges Herz", "Ein gerader Rücken", "Energie in den Händen", "Ein entspannter Bauch"]),
            new TechniqueEntrySeed("Freiwillige Erinnerungsgeste", "Diese Geste kann dich an die Erinnerung erinnern; du kannst den Schritt auslassen", Suggestions: ["Eine Faust ballen", "Das Handgelenk berühren", "Daumen und Zeigefinger zusammenführen", "Hand aufs Herz", "Ein tiefer Atemzug", "Ein Ohrläppchen drücken", "Die Schultern öffnen", "Über die Handfläche streichen"]),
            new TechniqueEntrySeed("Wirkung der Erinnerung", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Dies ist eine kurze Erinnerungsübung. Ihre Wirkung und eine Verbindung mit einer Geste sind nicht garantiert.",
            "Wenn du dich daran erinnern möchtest, was dir schon geholfen hat. Wähle nur eine sichere Erinnerung; höre auf, wenn es schwerer wird.",
            "Achte darauf, was damals geholfen hat. Eine Geste ist freiwillig und nur ein Hinweis; du musst dich nicht beruhigen.",
            "Ich erinnere mich daran, dass mir jemand zugehört hat. Das Gespräch half; ich könnte der Person jetzt schreiben. Wirkung: 5 von 10."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Grounding = new(
        "Übung", "Erdung 5-4-3-2-1",
        [
            "1. Nenne 5 Dinge, die du siehst",
            "2. Nenne 4 Dinge, die du mit dem Körper spürst",
            "3. Nenne 3 Geräusche um dich herum",
            "4. Nenne 2 Gerüche",
            "5. Nenne 1 Geschmack oder eine angenehme Empfindung"
        ],
        "Sinnliche Erdung lenkt die Aufmerksamkeit von ängstlichen Gedanken auf den gegenwärtigen Moment.",
        TechniqueUiKind.Entry, "Technik Nr. 14", "12.06.2026", "Erdung 5-4-3-2-1", "Über die Sinne in die Gegenwart zurückkehren", "Schwerer Moment", "Psyche", 3, "Nature",
        [
            new TechniqueEntrySeed("5 Dinge, die ich sehe", "Z. B. Fenster, Tasse, Buch, Lampe, Hand", Suggestions: ["Fenster", "Tisch", "Handy", "Computer", "Laptop", "Bildschirm", "Tastatur", "Tasse", "Lampe", "Hand", "Tür", "Buch", "Stuhl", "Wand", "Bild", "Pflanze", "Uhr", "Schrank", "Himmel", "Auto"]),
            new TechniqueEntrySeed("4 Dinge, die ich mit dem Körper spüre", "Z. B. Stuhl, Boden, Kleidung, Lufttemperatur", Suggestions: ["Stuhl", "Boden unter den Füßen", "Kleidung", "Kühle", "Wärme", "Handy in der Hand", "Stuhllehne", "Stoff auf der Haut", "Atem in der Brust", "Wind", "Computermaus", "Schlüssel", "Kissen", "Uhr am Handgelenk"]),
            new TechniqueEntrySeed("3 Geräusche", "Z. B. Straße, Uhr, dein Atem", Suggestions: ["Straße", "Uhr", "Atmen", "Stimmen", "Kühlschrank", "Wind", "Stille", "Computer", "Autos", "Vögel", "Musik", "Klimaanlage", "Schritte", "Regen"]),
            new TechniqueEntrySeed("2 Gerüche", "Z. B. Kaffee, frische Luft", Suggestions: ["Kaffee", "Frische Luft", "Seife", "Essen", "Parfüm", "Fast nichts", "Tee", "Brot", "Bücher", "Blumen", "Handcreme", "Holz"]),
            new TechniqueEntrySeed("1 Geschmack oder angenehme Empfindung", "Z. B. Wasser im Mund, weicher Stoff", Suggestions: ["Wasser", "Tee", "Weicher Stoff", "Warme Handflächen", "Frischer Mund", "Kaffee", "Minzkaugummi", "Schokolade", "Ein Apfel", "Eine warme Decke"])
        ],
        Theory(
            "Richte deine Aufmerksamkeit auf das, was du um dich herum siehst, hörst und spürst.",
            "Wenn Sorgen viel Raum einnehmen und du dich auf deine Umgebung konzentrieren möchtest.",
            "Beginne mit dem, was du siehst. Wenn du keinen Geruch oder Geschmack wahrnimmst, geh weiter. Atme wie gewohnt.",
            "Ich sehe eine Tasse und eine Lampe. Ich spüre den Boden unter den Füßen. Ich höre Verkehr draußen."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Breathing = new(
        "Übung", "Sanftes Atemtempo",
        [
            "1. Bewerte deine Anspannung vor der Übung",
            "2. Setz dich bequem hin. Atme sanft und nicht tiefer als sonst",
            "3. Wenn es angenehm ist, folge dem Kreis: etwa 4 Zählzeiten ein- und 6 ausatmen. Halte den Atem nicht an",
            "4. Wenn das Tempo nicht passt, lass das Zählen weg oder beende die Übung. Bei Schwindel oder Atemnot kehre zu deinem natürlichen Atem zurück",
            "5. Bewerte deine Anspannung danach erneut. Sie muss sich nicht verändert haben; auch das ist eine hilfreiche Beobachtung"
        ],
        "Bei Anspannung kannst du einen kurzen, sanften Rhythmus ohne Atempausen ausprobieren. Er passt nicht für alle: Zählen oder die Konzentration auf den Atem kann Unbehagen verstärken.",
        TechniqueUiKind.Entry, "Technik Nr. 15", "04.07.2026", "Sanftes Atemtempo", "Einen angenehmen Rhythmus mit etwas längerem Ausatmen probieren", "Schwerer Moment", "Psyche", 3, "Air",
        [
            new TechniqueEntrySeed("Anspannung vorher", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notizen", "Was hast du bemerkt? Jede Reaktion ist in Ordnung.", Suggestions: ["Das Tempo war angenehm", "Das Zählen lenkte mich ab", "Das Tempo war zu langsam", "Mir wurde schwindelig", "Das Atmen fühlte sich unangenehm an", "Ich wurde etwas ruhiger", "Keine Veränderung", "Ich wurde angespannter", "Ich brach ab und nahm meine Umgebung wahr"]),
            new TechniqueEntrySeed("Anspannung danach", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Ein kurzer, sanfter Rhythmus mit etwas längerem Ausatmen ist eine Möglichkeit, den Atem bei Anspannung zu begleiten. Die Reaktionen sind unterschiedlich; die Übung garantiert keine Erleichterung.",
            "Bei Anspannung, wenn es angenehm ist, auf den Atem zu achten.",
            "Setz dich bequem hin. Atme sanft und nicht tiefer als sonst. Etwa eine Minute lang kannst du dem Kreis folgen: ungefähr 4 Zählzeiten ein- und 6 ausatmen, ohne Pausen. Wenn sich das Tempo erzwungen anfühlt, atme wieder in deinem eigenen Rhythmus. Beende die Übung, wenn das Unbehagen zunimmt, und benenne einige Dinge in deiner Umgebung.",
            "Die Anspannung lag bei 7/10. Nach einer Minute war sie noch bei 7/10. Das Zählen fühlte sich erzwungen an; ich brach ab und benannte fünf Dinge um mich herum."
        ),
        null, null);

    internal static readonly BuiltInTechniqueDefinition SmallStep = new(
        "Übung", "Ein kleiner Schritt",
        [
            "1. Wähle eine kleine Aktivität für Selbstfürsorge, Interesse, Kontakt oder ein Gefühl des Abschlusses",
            "2. Mach daraus einen sicheren Anfang von 2–5 Minuten. Du musst nicht die ganze Aufgabe beenden",
            "3. Lege einen konkreten Zeitpunkt innerhalb der nächsten 24 Stunden fest. Wenn es jetzt nicht passt: Ruhe, Unterstützung oder einen kleineren Schritt wählen",
            "4. Bewerte, wie machbar es wirkt: 0 — gar nicht zuversichtlich, 10 — ganz sicher. Bei Zweifel: noch kleiner machen"
        ],
        "Ein kurzer Aktivitätsplan nach Grundideen der Verhaltensaktivierung. Ein kleiner Schritt kann den Anfang erleichtern, garantiert aber weder bessere Stimmung noch mehr Energie.",
        TechniqueUiKind.Entry, "Technik Nr. 16", "04.07.2026", "Ein kleiner Schritt", "Wähle eine Aktivität und mache den Anfang machbar", "Schwerer Moment", "KVT", 5, "DirectionsWalk",
        [
            new TechniqueEntrySeed("Was macht den Anfang schwer?", "Müdigkeit, Angst, Einsamkeit, zu viel zu tun?", Suggestions: ["Müdigkeit", "Angst", "Einsamkeit", "Zu viel zu tun", "Langeweile", "Ich weiß nicht, wo ich anfangen soll", "Ich brauche Ruhe", "Die Umstände passen gerade nicht"], Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Eine kleine Aktivität für mich", "Selbstfürsorge, Interesse, Kontakt oder eine kleine Aufgabe", Suggestions: ["Ein Glas Wasser trinken oder etwas essen", "Mich waschen oder anziehen", "Zwei Minuten an die frische Luft gehen", "Ein Lieblingslied hören", "Einer nahestehenden Person schreiben", "Zwei Minuten an etwas Wichtigem arbeiten", "Eine Sache wegräumen", "Jemanden bitten, bei mir zu bleiben"]),
            new TechniqueEntrySeed("Wann möchtest du es versuchen?", "Ein konkreter Zeitpunkt in den nächsten 24 Stunden", Suggestions: ["Jetzt für zwei Minuten", "Nach dem Frühstück", "Nach dem Mittagessen", "Nach Arbeit oder Lernen", "Heute zu einer gewählten Uhrzeit", "Eine nahestehende Person um Erinnerung bitten"]),
            new TechniqueEntrySeed("Wie machbar wirkt es?", "0 — gar nicht zuversichtlich, 10 — ganz sicher", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Wenig Energie oder gedrückte Stimmung können den Anfang erschweren. Eine kleine geplante Aktivität kann etwas Bewegung ermöglichen; die Wirkung ist individuell.",
            "Wenn Stimmung oder Energie den Start erschweren und eine sichere, machbare Aktivität möglich ist. Ruhe oder um Hilfe zu bitten kann ebenfalls ein guter Schritt sein.",
            "Wähle etwas für Selbstfürsorge, Interesse, Kontakt oder ein Gefühl des Abschlusses; reduziere den Anfang auf 2–5 Minuten und plane ihn innerhalb der nächsten 24 Stunden. Planen heißt noch nicht, dass du es getan hast. Wenn es nicht machbar wirkt, mach es kleiner oder bitte um Unterstützung.",
            "Nicht „die ganze Wohnung aufräumen“, sondern nach dem Mittagessen eine Tasse spülen — oder einer nahestehenden Person schreiben: „Hast du kurz Zeit zum Reden?“"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition ThoughtRecord = new(
        "Übung", "Gedankenprotokoll",
        [
            "1. Beschreibe die Situation ohne Bewertung",
            "2. Schreibe den automatischen Gedanken auf",
            "3. Benenne das Gefühl und bewerte es jetzt",
            "4. Trenne Fakten von Annahmen und finde eine weitere Möglichkeit",
            "5. Bewerte das Gefühl erneut — es kann gleich bleiben"
        ],
        "Trenne Situation, Gedanken und Gefühl und prüfe die Schlussfolgerung anhand der Fakten. Das Gefühl muss nicht nachlassen.",
        TechniqueUiKind.Entry, "Technik Nr. 17", "04.07.2026", "Gedankenprotokoll", "Fakt und Deutung unterscheiden", "Schwerer Moment", "KVT", 7, "EditNote",
        [
            new TechniqueEntrySeed("Situation", "Was ist passiert? Wo und wann? Nur das Nötige.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Automatischer Gedanke", "Was hast du in dem Moment gedacht?", Suggestions: HarshThoughts),
            new TechniqueEntrySeed("Gefühl vorher", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Genauere Sichtweise", "Welche Fakten sprechen dafür oder dagegen? Was ist noch möglich?", Role: EntryFieldRole.Reframe),
            new TechniqueEntrySeed("Gefühl danach", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Die Übung trennt ein Ereignis von deiner Deutung. Sie ist keine Diagnose und keine Behandlung.",
            "Für eine mäßig belastende Alltagssituation, wenn du gerade genug Kraft zum Schreiben hast. Wähle keine traumatische Erinnerung und keine akute Krise.",
            "Notiere beobachtbare Fakten und dann den Gedanken. Suche eine Erklärung, die Fakten und Unbekanntes berücksichtigt; zwing dich nicht zu einer positiven Sicht. Bleibt die Bewertung gleich, hast du nichts falsch gemacht.",
            "Situation: noch keine Antwort auf eine Nachricht. Gedanke: „Niemand braucht mich.“ Fakt: Eine Antwort steht noch aus. Möglichkeit: Der Grund ist unbekannt; die Person könnte beschäftigt sein."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition SelfCompassion = new(
        "Übung", "Freundliche Worte an dich selbst",
        [
            "1. Schreib auf, wofür du dich kritisierst",
            "2. Stell dir vor, ein enger Freund sagt das — was würdest du ihm antworten?",
            "3. Formuliere denselben unterstützenden Satz für dich selbst",
            "4. Bewerte Wärme oder Erleichterung"
        ],
        "Selbstmitgefühl mildert harte Selbstkritik und hilft, sich nach einem Fehler zu erholen.",
        TechniqueUiKind.Entry, "Technik Nr. 18", "04.07.2026", "Freundliche Worte an dich selbst", "Selbstkritik durch Unterstützung abmildern", "Schwerer Moment", "KVT", 5, "Favorite",
        [
            new TechniqueEntrySeed("Wofür du dich kritisierst", "Was sagst du dir, oder was wirfst du dir vor?", Suggestions: ["Ein Fehler auf der Arbeit", "Nicht fertig geworden", "Einen nahen Menschen angefahren", "Mich mit anderen vergleichen", "Schon wieder etwas aufgeschoben", "Mein Aussehen", "Mein Gewicht", "Das Falsche gesagt", "Kein guter Elternteil", "Zu wenig verdienen", "Ein Versprechen gebrochen", "Zu empfindlich"]),
            new TechniqueEntrySeed("Was du einem Freund sagen würdest", "Wie würdest du einen nahen Menschen in dieser Situation unterstützen?", Role: EntryFieldRole.Kindness),
            new TechniqueEntrySeed("Satz an dich selbst", "Dieselbe Freundlichkeit, an dich gerichtet", Role: EntryFieldRole.SelfKindness),
            new TechniqueEntrySeed("Wärme / Erleichterung", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Selbstkritik motiviert selten — öfter nährt sie Scham und Lähmung. Selbstmitgefühl nimmt die Verantwortung nicht weg, gibt aber Halt.",
            "Nach einem Fehler, beim Vergleichen mit anderen oder wenn du dich nicht gut genug fühlst.",
            "Schreib die Kritik auf und antworte dir dann wie einem Freund — respektvoll und ohne abzuwiegeln.",
            "Kritik: Ich habe wieder alles kaputt gemacht. An einen Freund: Du hast es versucht, das lässt sich reparieren. An mich: Ich kann daraus lernen. Wärme: 3 → 6."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition BodyScan = new(
        "Übung", "Wo sitzt es im Körper?",
        [
            "1. Bewerte deine Anspannung jetzt",
            "2. Lass deine Aufmerksamkeit langsam vom Kopf bis zu den Füßen durch den Körper wandern",
            "3. Finde die Stelle, an der die Empfindung am stärksten ist",
            "4. Beschreibe sie: wie sie ist, groß oder klein, warm oder kalt",
            "5. Benenne das Gefühl, das dazugehört",
            "6. Wenn du möchtest, nimm wahr, ob sich etwas verändert hat oder gleich geblieben ist. Du kannst jederzeit aufhören oder die Aufmerksamkeit nach außen richten."
        ],
        "Body-Scan: Nimm Körperempfindungen und Gefühle wahr, ohne sie verändern zu müssen.",
        TechniqueUiKind.Entry, "Technik Nr. 19", "16.10.2026", "Wo sitzt es im Körper?", "Körpersignale wahrnehmen, ohne sie verändern zu müssen", "Schwerer Moment", "Achtsamkeit", 4, "Accessibility",
        [
            new TechniqueEntrySeed("Anspannung jetzt", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Wo im Körper spürst du es?", "Zum Beispiel: Brust, Hals, Schultern", Suggestions: ["Kopf", "Stirn", "Augen", "Kiefer", "Hals", "Nacken", "Schultern", "Brust", "Herz", "Bauch", "Rücken", "Unterer Rücken", "Arme", "Hände", "Beine", "Der ganze Körper"]),
            new TechniqueEntrySeed("Wie fühlt sich die Empfindung an?", "Zum Beispiel: Enge, Schwere, ein Kloß", Suggestions: ["Enge", "Schwere", "Ein Kloß", "Druck", "Anspannung", "Hitze", "Kälte", "Zittern", "Kribbeln", "Pochen", "Leere", "Taubheit", "Schmerz", "Schwer zu beschreiben"]),
            new TechniqueEntrySeed("Welches Gefühl gehört dazu?", "Zum Beispiel: Angst, Kränkung, Müdigkeit", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("Anspannung danach", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Ein Body-Scan kann helfen, Körperempfindungen und damit verbundene Gefühle wahrzunehmen. Die Anspannung muss sich dadurch nicht verändern. Solche Übungen kommen in Achtsamkeitsprogrammen vor.",
            "Wenn du dich ängstlich oder schwer fühlst, aber nicht sagen kannst, was genau; wenn der Körper nach einem schweren Gespräch oder Tag angespannt ist. Die Übung erklärt keine Krankheiten und ersetzt keinen Arzt: Wenn eine Empfindung neu oder stark ist oder nicht vergeht, geh zu einer Ärztin oder einem Arzt.",
            "Setz dich bequem hin, wenn sich das gut anfühlt, und richte deine Aufmerksamkeit nach und nach auf verschiedene Körperbereiche. Beschreibe eine Empfindung möglichst konkret; wenn es passt, benenne auch ein Gefühl. Du musst nichts daran ändern. Wenn der Blick nach innen unangenehm wird, öffne die Augen, richte die Aufmerksamkeit auf Dinge um dich herum oder beende die Übung. Atme normal.",
            "Anspannung 6/10. Ort: Brust. Empfindung: Enge. Gefühl: Angst vor einem Gespräch. Danach blieb die Anspannung bei 6/10. Ich öffnete die Augen und benannte Dinge im Raum. Auch das ist ein gültiges Ergebnis."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Flashback = new(
        "Übung", "Eine Erinnerung hat mich überwältigt",
        [
            "1. Bewerte, wie stark es ist",
            "2. Sag dir: „Das ist eine Erinnerung. Das war damals, und jetzt ist heute“",
            "3. Benenne, wo du bist und welche Tageszeit es ist",
            "4. Spür den Halt unter den Füßen, ball die Fäuste und lass sie wieder los",
            "5. Nenne drei Dinge, die du siehst",
            "6. Fünf langsame Ausatmungen, kaltes Wasser, und dann erneut bewerten"
        ],
        "Hilfe bei einem Flashback: über Zeit, Ort, Körper und Sinne aus der Erinnerung in die Gegenwart zurückkommen.",
        TechniqueUiKind.Entry, "Technik Nr. 20", "16.10.2026", "Eine Erinnerung hat mich überwältigt", "In die Gegenwart zurückkommen, wenn eine schwere Erinnerung überwältigt", "Schwerer Moment", "Trauma", 3, "MyLocation",
        [
            new TechniqueEntrySeed("Wie stark es ist", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Wo du bist und welche Tageszeit", "Zum Beispiel: zu Hause, abends", Suggestions: ["Zu Hause", "Auf der Arbeit", "Draußen", "Unterwegs in Bus oder Bahn", "Zu Besuch", "Morgen", "Nachmittag", "Abend", "Nacht"]),
            new TechniqueEntrySeed("Drei Dinge, die du siehst", "Zum Beispiel: Fenster, Tasse, Lampe", Suggestions: ["Fenster", "Tisch", "Handy", "Tasse", "Lampe", "Tür", "Stuhl", "Wand", "Bild", "Pflanze", "Uhr", "Himmel"]),
            new TechniqueEntrySeed("Wie stark es jetzt ist", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Ein Flashback ist eine Traumaerinnerung, die so erlebt wird, als geschähe es wieder: mit denselben Gefühlen und Körperreaktionen. Das Gehirn verwechselt „damals“ und „jetzt“. Zeit, Ort, der Halt des Körpers und das, was du siehst und hörst, helfen dir zurück in die Gegenwart.",
            "Wenn die Erinnerung an ein schweres Ereignis überwältigt, mit aufblitzenden Bildern und dem Gefühl „ich bin wieder dort“. Häufige Flashbacks sind ein typisches Zeichen einer posttraumatischen Reaktion und lassen sich mit einer Traumafachperson gut behandeln.",
            "Versuch nicht, die Erinnerung aufzuarbeiten: Jetzt ist die einzige Aufgabe, zurückzukommen. Sag dir, wo du bist und welcher Tag ist, drück die Füße auf den Boden, benenne, was du siehst, atme langsam aus, nutze Kälte.",
            "Stärke 8. „Das war damals; jetzt ist 2026, ich bin zu Hause, es ist Abend.“ Füße auf dem Boden; ich sehe ein Fenster, eine Tasse, eine Lampe. Kaltes Wasser. Jetzt 4."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Nightmare = new(
        "Übung", "Einen Albtraum umschreiben",
        [
            "1. Wähle einen wiederkehrenden Albtraum, für den Anfang nicht den schwersten",
            "2. Beschreibe ihn kurz, ohne belastende Details",
            "3. Entscheide, was du daran änderst: das Ende, den Ort, dich selbst, jemanden in der Nähe",
            "4. Schreib die neue Version des Traums vollständig auf, bis zu einem ruhigen Ende",
            "5. Stell dir die neue Version jeden Tag 10 bis 20 Minuten lang genau vor",
            "6. Schau nach ein bis zwei Wochen, wie sich die Albträume verändert haben"
        ],
        "Imagery Rehearsal: Ein wiederkehrender Albtraum wird im Wachzustand umgeschrieben, und das Gehirn beginnt, die neue Version zu träumen.",
        TechniqueUiKind.Entry, "Technik Nr. 21", "16.10.2026", "Einen Albtraum umschreiben", "Einen wiederkehrenden Albtraum seltener und schwächer machen", "Schlaf", "Trauma", 15, "NightsStay",
        [
            new TechniqueEntrySeed("Wie belastend dieser Albtraum ist", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Worum es im Albtraum geht, kurz", "Ein oder zwei Sätze, ohne belastende Details", Suggestions: ["Jemand verfolgt mich", "Ich komme nicht weg", "Ich bin wieder dort, wo es beängstigend war", "Ich verliere einen nahen Menschen", "Ich kann nicht schreien", "Ich falle", "Ich werde angegriffen", "Ich bin zu spät und schaffe es nicht"]),
            new TechniqueEntrySeed("Was du änderst", "Alles, was du willst: Es ist dein Traum", Suggestions: ["Das Ende", "Der Ort", "Ich werde stärker", "Jemand kommt zu Hilfe", "Ich kann sprechen und rufen", "Die Gefahr verschwindet", "Alles wird sicher", "Ich merke, dass es ein Traum ist"]),
            new TechniqueEntrySeed("Die neue Version des Traums", "Beschreibe sie vollständig, vom Anfang bis zu einem ruhigen Ende", Suggestions: ["Ich merke, dass es ein Traum ist", "Jemand, der mich beschützt, taucht auf", "Ich bin an einem sicheren Ort", "Ich gehe ruhig weg", "Alles geht gut aus"]),
            new TechniqueEntrySeed("Wann ich die neue Version übe", "Jeden Tag, 10 bis 20 Minuten", Suggestions: ["Am Morgen", "Tagsüber, in einer Pause", "Abends, ein paar Stunden vor dem Schlafen", "Jeden Tag zur selben Zeit"]),
            new TechniqueEntrySeed("Wie belastend es jetzt ist", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Wiederkehrende Albträume nach Trauma oder Stress werden durch Gewohnheit aufrechterhalten: Das Gehirn spielt immer wieder dieselbe Handlung ab. In der Imagery Rehearsal Therapy wird die Handlung im Wachzustand umgeschrieben und die neue Version jeden Tag im Kopf geübt. Studien zeigen, dass Albträume dadurch seltener und schwächer werden und der Schlaf besser wird.",
            "Bei wiederkehrenden Albträumen, die dir Angst vor dem Einschlafen machen. Wenn der Albtraum ein Trauma direkt wiederholt und schon eine kurze Beschreibung starkes Entsetzen auslöst, mach die Übung gemeinsam mit einer Traumafachperson.",
            "Beginne mit einem leichteren Albtraum. Schreib die beängstigenden Teile nicht ausführlich auf: Ein paar Sätze reichen. Verändere den Traum, wie du willst; die neue Version muss nicht realistisch sein. Übe sie tagsüber, nicht direkt vor dem Schlafen, 10 bis 20 Minuten am Tag.",
            "Albtraum: Jemand verfolgt mich und ich komme nicht weg. Änderung: Ich merke, dass es ein Traum ist, drehe mich um, und es ist nur ein Schatten; ich gehe ruhig nach Hause. Ich übe es jeden Nachmittag. Nach zwei Wochen kommt der Albtraum seltener."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Balloons = new(
        "Übung", "Ballons platzen lassen",
        [
            "1. Bewerte deine Anspannung vor dem Spiel",
            "2. Starte die Runde und tippe in deinem Tempo; du musst nicht jeden Ballon treffen",
            "3. Atme wie gewohnt. Du musst das Ausatmen nicht auf jeden Knall abstimmen",
            "4. Die Runde endet von selbst. Wenn dich das Spiel frustriert oder es dir schlechter geht, geh zurück",
            "5. Bewerte danach deine Anspannung und notiere, was du bemerkt hast. Keine Veränderung ist auch ein Ergebnis"
        ],
        "Ein kurzes Spiel für Hände und Aufmerksamkeit. Es kann kurz ablenken, muss dein Befinden aber nicht verändern und ersetzt weder Problemlösung noch Unterstützung.",
        TechniqueUiKind.Entry, "Technik Nr. 22", "26.10.2026", "Ballons platzen lassen", "Eine kurze Spielpause nach Wunsch", "Schwerer Moment", "Psyche", 3, "BubbleChart",
        [
            new TechniqueEntrySeed("Anspannung vorher", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notizen", "Was ist dir aufgefallen? Du kannst das Feld leer lassen.", Suggestions: ["Etwas weniger angespannt", "Keine merkliche Veränderung", "Angespannter", "Kurz abgelenkt", "Farben oder Bewegung wahrgenommen", "Das Spiel war frustrierend", "Unsicher", "Anderes"]),
            new TechniqueEntrySeed("Anspannung danach", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Ein kurzes Spiel kann Hände und Aufmerksamkeit vorübergehend beschäftigen; die Wirkung ist individuell. Es senkt Angst nicht garantiert und ist keine Behandlung.",
            "Wenn sich eine kurze Spielpause gerade gut anfühlt. Dringende Schritte für Gesundheit oder Sicherheit sollten dadurch nicht aufgeschoben werden.",
            "Tippe in deinem Tempo; du musst nicht alle Ballons treffen. Atme normal und stimme den Atem nicht auf jeden Knall ab. Vergleiche danach deine Einschätzung, ohne ein bestimmtes Ergebnis zu erwarten. Wenn ein praktisches Problem einen Schritt braucht, kehre dazu zurück, sobald du bereit bist.",
            "Nach einem Streit lag meine Anspannung bei 7/10 und blieb nach der Runde bei 7/10. Ich bemerkte, dass ich noch wütend war, und wartete mit meiner Antwort."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition CyclicSigh = new(
        "Übung", "Zyklisches Seufzen",
        [
            "1. Bewerte deine Anspannung",
            "2. Atme durch die Nase ein und hänge am Ende noch einen kurzen Atemzug an",
            "3. Atme langsam durch den Mund aus, länger als du eingeatmet hast",
            "4. Atme etwa drei Minuten im Rhythmus des Kreises",
            "5. Bewerte deine Anspannung danach"
        ],
        "Zwei sanfte Atemzüge hintereinander und ein längeres Ausatmen geben dem Atem einen Rhythmus. Den Atem anzuhalten oder tiefer als sonst einzuatmen ist nicht nötig.",
        TechniqueUiKind.Entry, "Technik Nr. 23", "26.10.2026", "Zyklisches Seufzen", "Doppelt einatmen und lange ausatmen, um den Körper zu beruhigen", "Schwerer Moment", "Psyche", 3, "Air",
        [
            new TechniqueEntrySeed("Anspannung vorher", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notizen", "Was ist dir aufgefallen?", Suggestions: ["Etwas ruhiger", "Keine merkliche Veränderung", "Unangenehmer geworden", "Mir war schwindlig", "Ich möchte es nicht bewerten", "Anderes"]),
            new TechniqueEntrySeed("Anspannung danach", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "In einer randomisierten Studie mit 111 Teilnehmenden wurde zyklisches Seufzen fünf Minuten täglich über einen Monat geübt. Die Werte für positive Stimmung verbesserten sich stärker als in der Achtsamkeitsgruppe. Das belegt weder eine schnelle Wirkung einer einzelnen Übung noch einen gleichen Effekt bei allen.",
            "Du kannst es ausprobieren, wenn es sich angenehm anfühlt, den Atem zu beobachten – etwa vor einem Gespräch oder in einer kurzen Pause. Wird es dadurch unangenehmer, richte die Aufmerksamkeit lieber nach außen.",
            "Atme sanft und nicht so tief wie möglich. Wiederhole den Rhythmus nur, solange er angenehm ist. Bei Schwindel oder Unwohlsein brich ab, setz dich sicher hin und atme wie gewohnt. Hol medizinischen Rat, wenn die Beschwerden stark sind oder anhalten.",
            "Vor einem Anruf bemerke ich Anspannung und probiere ein paar sanfte Atemzüge. Ändert sich nichts oder wird es unangenehmer, höre ich auf und atme normal weiter."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition MuscleRelax = new(
        "Übung", "Anspannen und loslassen",
        [
            "1. Bewerte deine Anspannung",
            "2. Spanne eine Muskelgruppe fünf Sekunden an, etwa mit halber Kraft",
            "3. Lass los und spür fünfzehn Sekunden der Entspannung nach",
            "4. Geh fünf Gruppen durch: Hände, Schultern, Gesicht, Bauch, Beine",
            "5. Bewerte deine Anspannung danach"
        ],
        "Erst anspannen, dann loslassen: So spürt der Körper leichter, was Entspannung ist.",
        TechniqueUiKind.Entry, "Technik Nr. 24", "26.10.2026", "Anspannen und loslassen", "Eine kurze Muskelentspannung für einen verspannten Körper", "Schwerer Moment", "Psyche", 4, "SelfImprovement",
        [
            new TechniqueEntrySeed("Anspannung vorher", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notizen", "Wo im Körper fühlt es sich leichter an?", Suggestions: ["Meine Schultern haben sich entspannt", "Mein Kiefer hat sich gelöst", "Meine Hände wurden wärmer", "Das Atmen fällt leichter", "Ich bin müde geworden", "Etwas Anspannung ist noch da", "Nichts hat sich verändert"]),
            new TechniqueEntrySeed("Anspannung danach", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Die progressive Muskelentspannung gehört zu den am besten erforschten Methoden gegen Angst und Anspannung. Wenn du einen Muskel erst anspannst und dann loslässt, hilft der Kontrast, Entspannung zu bemerken und mit der Zeit selbst herbeizuführen. Es ist keine Behandlung, sondern eine Fähigkeit, die mit Übung besser wirkt.",
            "Wenn der Körper vom Stress verspannt ist, wenn es schwerfällt, still zu sitzen oder einzuschlafen. Passt gut abends vor dem Schlafen.",
            "Spanne etwa mit halber Kraft an, ohne Schmerz. Wenn eine Stelle schmerzt oder verletzt ist, spann sie nicht an, sondern nimm sie nur wahr. Atme beim Loslassen ruhig und eile nicht zur nächsten Gruppe.",
            "Anspannung 7/10 abends nach der Arbeit, die Schultern hochgezogen. Fünf Gruppen: Hände, Schultern, Gesicht, Bauch, Beine. Anspannung 4/10, die Schultern sind gesunken."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition BusyMind = new(
        "Übung", "Kurze Aufmerksamkeitslenkung",
        [
            "1. Bewerte deine Anspannung nur, wenn es dir gerade hilft",
            "2. Wähle eine neutrale Aufgabe für etwa 30–60 Sekunden",
            "3. Kehrt die Aufmerksamkeit zur Sorge zurück, mach dir keine Vorwürfe; du kannst einmal sanft zur Aufgabe zurückkehren",
            "4. Beende die Aufgabe und prüfe, ob ein konkreter Schritt oder Unterstützung nötig ist"
        ],
        "Eine kurze neutrale Aufgabe kann die Aufmerksamkeit einen Moment lang umlenken, wenn Gedanken festzustecken scheinen. Sie beseitigt keine Gedanken und löst das Problem nicht.",
        TechniqueUiKind.Entry, "Technik Nr. 25", "26.10.2026", "Kurze Aufmerksamkeitslenkung", "Eine kurze Pause bei wiederkehrenden Gedanken", "Schwerer Moment", "Psyche", 1, "Extension",
        [
            new TechniqueEntrySeed("Anspannung vorher", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notizen", "Wie war diese kurze Pause?", Suggestions: ["Kurz umgelenkt", "Nichts hat sich verändert", "Ich bin angespannter oder frustrierter", "Ich sehe jetzt einen nächsten Schritt", "Ich brauche Unterstützung", "Ich habe die Übung beendet"]),
            new TechniqueEntrySeed("Anspannung danach", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Eine kurze neutrale Aufgabe — zum Beispiel Gegenstände einer Farbe zu benennen — kann manchmal helfen, einen akuten Moment zu überstehen. Sie lenkt die Aufmerksamkeit vorübergehend um, beseitigt aber keine Gedanken; die Wirkung ist unterschiedlich.",
            "Wenn wiederkehrende Gedanken deine Aufmerksamkeit beanspruchen und du eine kurze Pause möchtest. Bei einem dringenden Problem oder einer Sicherheits- oder Gesundheitsfrage kümmere dich darum und suche passende Hilfe.",
            "Wähle eine einfache Aufgabe für 30–60 Sekunden; perfekte Konzentration ist nicht nötig. Prüfe danach, ob es einen konkreten nächsten Schritt gibt. Wenn die Aufgabe dich frustriert oder es dir schlechter geht, beende sie und wähle etwas anderes.",
            "Nach einem Streit läuft das Gespräch im Kopf weiter. Benenne eine halbe Minute lang fünf Gegenstände um dich herum und entscheide dann, ob du etwas klären, eine Pause machen oder Unterstützung holen möchtest."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition ThoughtDefusion = new(
        "Übung", "Abstand zu einem Gedanken",
        [
            "1. Bemerke einen kurzen Gedanken; aufschreiben ist optional",
            "2. Sage: „Ich bemerke den Gedanken, dass …“",
            "3. Nimm einen Gegenstand vor dir und den Halt unter deinen Füßen wahr",
            "4. Wähle einen kleinen nächsten Schritt oder beende die Übung hier"
        ],
        "Eine kurze Fertigkeit aus der Akzeptanz- und Commitmenttherapie (ACT): einen Gedanken als Vorgang des Geistes wahrnehmen, nicht unbedingt als Tatsache oder Befehl.",
        TechniqueUiKind.Entry, "Technik Nr. 26", "03.11.2026", "Abstand zu einem Gedanken", "Eine kurze Übung, um Abstand zu einem beunruhigenden Gedanken zu gewinnen", "Gedanken", "Psyche", 1, "FormatQuote",
        [
            new TechniqueEntrySeed("Gedanke", "Optional: Du kannst die Übung still machen", Suggestions: HarshThoughts)
        ],
        Theory(
            "Ein wiederkehrender Gedanke kann die ganze Aufmerksamkeit einnehmen. Bei der Defusion in ACT wird er bemerkt, ohne mit ihm zu streiten oder ihn wegzudrücken.",
            "Wenn sich eine Sorge, Selbstkritik oder Angst wiederholt. Du musst keine belastende Erinnerung wählen.",
            "Du musst nichts aufschreiben. Setze „Ich bemerke den Gedanken, dass …“ vor den Gedanken, schau auf einen Gegenstand und spüre den Halt unter deinen Füßen. Wenn das Unwohlsein zunimmt, stoppe und benenne einige Dinge in deiner Umgebung.",
            "Aus „Ich mache alles kaputt“ wird „Ich bemerke den Gedanken, dass ich alles kaputt mache“. Dann bemerkst du die Tasse vor dir und entscheidest, ob du eine E-Mail beantwortest oder kurz pausierst."),
        null, null);
}
