using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice.Catalog;

internal static class TechniqueCatalogContentEs
{
    internal static TheorySection[] Theory(string what, string when, string how, string example) =>
    [
        new("Qué es", what),
        new("Cuándo probarla", when),
        new("Cómo es la práctica", how),
        new("Ejemplo", example)
    ];

    /// <summary>Common topics for a "problem" field: a start to tap and then add a word or two, not a full answer.</summary>
    private static readonly string[] ProblemTopics =
        ["Una pelea con alguien cercano", "Algo en el trabajo", "Un conflicto con mi jefe", "Los estudios o un examen", "La salud", "El dinero", "La soledad", "Un fracaso", "Una ruptura", "La relación con mis padres", "Los hijos", "Una mudanza", "El futuro", "Las críticas hacia mí"];

    private static readonly string[] BackupOptions =
        ["Pedir ayuda", "Esperar y volver a intentarlo", "Buscar otro camino", "Exigirme menos", "Tomar un descanso", "Hablarlo con alguien cercano", "Ir a un especialista", "Buscar un trabajo extra", "Hacer un curso", "Dividir la tarea en pasos", "Aplazar la decisión", "Empezar por poco"];

    private static readonly string[] HarshThoughts =
        ["«Lo voy a arruinar todo»", "«Me van a juzgar»", "«No puedo con esto»", "«Nadie me necesita»", "«Es un desastre»", "«Nada va a salir bien»", "«Soy peor que los demás»", "«Todo siempre sale mal»", "«Es culpa mía»", "«Algo anda mal conmigo»", "«Esto nunca va a terminar»", "«Tengo que ser perfecto»"];

    internal static readonly BuiltInTechniqueDefinition Spin = new(
        "Práctica", "Poner nombre a lo que siento",
        [
            "1. Elige una situación cotidiana reciente que te haya molestado un poco",
            "2. Nombra la emoción principal",
            "3. Valora su intensidad ahora, de 0 a 10"
        ],
        "Anota brevemente la situación y la emoción, sin esperar alivio inmediato.",
        TechniqueUiKind.Entry, "Técnica n.º 1", "26.01.2023", "Poner nombre a lo que siento", "Observa qué ocurre ahora", "Momento difícil", "Equipo PsychologyApp", 5, "Autorenew",
        [
            new TechniqueEntrySeed("Situación", "Por ejemplo: un pequeño incidente en el trabajo. Evita detalles dolorosos.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Emoción principal", "Dolor, preocupación, enfado…", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("Intensidad ahora", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Anota la situación, la emoción y su intensidad ahora. Es una observación personal, no un tratamiento ni una promesa de que la emoción cambie enseguida.",
            "Para una situación cotidiana moderadamente molesta, si te sientes cómodo escribiendo sobre ella. No elijas un recuerdo traumático ni una crisis aguda.",
            "Describe solo lo necesario y valora la emoción ahora. Si aumenta el malestar, detente, mira a tu alrededor y elige una práctica más neutra. No hace falta repetirla.",
            "Situación: un compañero me interrumpió. Emoción: irritación. Intensidad ahora: 5 de 10."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Comparison = new(
        "Práctica", "Ampliar la perspectiva",
        [
            "1. Nombra lo que te cuesta ahora, sin restarle importancia",
            "2. ¿A qué áreas de tu vida afecta?",
            "3. ¿Qué más importa o también necesita atención?",
            "4. ¿De quién o de qué te gustaría ocuparte hoy?",
            "5. Anota qué observas sin decidir si el problema es pequeño o grande"
        ],
        "Este ejercicio permite nombrar distintas áreas de la vida; no determina la gravedad de un problema.",
        TechniqueUiKind.Entry, "Técnica n.º 2", "26.01.2023", "Ampliar la perspectiva", "Cuando una dificultad ocupa toda tu atención", "Tamaño del problema", string.Empty, 7, "CompareArrows",
        [
            new TechniqueEntrySeed("Qué está pasando", "¿Qué te resulta difícil ahora?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Áreas afectadas", "P. ej., trabajo, salud, relaciones", Suggestions: ["El trabajo", "La familia", "Los amigos", "La salud", "Los estudios", "El dinero", "Las relaciones", "El sueño", "El hogar", "Las aficiones", "El descanso", "Los planes"]),
            new TechniqueEntrySeed("Qué más importa", "¿Qué también necesita atención?", Suggestions: ["El trabajo", "La familia", "La salud", "Las relaciones", "El descanso", "Los hijos", "Los amigos", "Los estudios", "El sueño", "La tranquilidad", "El crecimiento personal", "Las tareas diarias"]),
            new TechniqueEntrySeed("De qué ocuparte", "¿Quién o qué necesita tu atención hoy?", Suggestions: ["La salud", "Las personas cercanas", "El sueño", "El descanso", "Un asunto laboral", "Una conversación", "Una tarea diaria", "Mis límites", "Aún no lo sé"]),
            new TechniqueEntrySeed("Qué observas", "No hace falta llegar a una conclusión positiva")
        ],
        Theory(
            "El ejercicio ayuda a nombrar otras necesidades y tareas sin quitar importancia a la dificultad.",
            "Cuando un tema ocupa casi toda tu atención y quieres reconocer otras necesidades o tareas.",
            "Escribe con tus palabras y no busques un giro positivo obligatorio. Si hace falta una acción práctica o atender a la seguridad, priorízala. Puedes dejar campos sin responder.",
            "Buscar trabajo afecta al dinero y al sueño; hoy también quiero atender a alguien cercano. Quizá elija un paso de búsqueda y pida apoyo. Eso no hace que la preocupación sea menos seria."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Polarity = new(
        "Práctica", "Polaridades",
        [
            "1. Escribe lo que te gusta de la situación",
            "2. Escribe lo que no te gusta",
            "3. Compara las parejas y fíjate en el equilibrio"
        ],
        "El método de las polaridades ayuda a ver los dos lados y a reducir la tensión interna.",
        TechniqueUiKind.Polarity, "Técnica n.º 3", "26.01.2023", "Polaridades", "Ver los dos lados de una situación", "Distintos lados", "Zivorad Slavinski", 5, "Contrast",
        null,
        Theory(
            "Toda situación tiene lados atractivos y desagradables. Nombrar ambos reduce la fijación en uno solo.",
            "Cuando solo ves lo negativo o solo lo positivo y te sientes atascado.",
            "Añade parejas de «me gusta / no me gusta» sobre un tema. Compara las listas sin juzgar qué es lo correcto.",
            "Trabajo: me gusta el sueldo, no me gusta el horario. Casa: me gusta lo acogedora, no me gusta el ruido de los vecinos."),
        "Lo que no te gusta", "Lo que te gusta");

    internal static readonly BuiltInTechniqueDefinition Paper = new(
        "Práctica", "Un pensamiento en papel",
        [
            "1. Escribe un pensamiento aquí o en una hoja",
            "2. Léelo una vez y nombra la emoción, si quieres",
            "3. Decide qué hacer con la hoja: guardarla, doblarla o romperla. También puedes no hacer nada"
        ],
        "Escribir permite observar cómo está formulado un pensamiento; no hace falta destruir la hoja ni esperar alivio.",
        TechniqueUiKind.Paper, "Técnica n.º 4", "26.01.2023", "Un pensamiento en papel", "Cuando un pensamiento vuelve una y otra vez", "Pensamientos", "Equipo PsychologyApp", 3, "Description",
        [new TechniqueEntrySeed("Pensamiento", "Por ejemplo: «Voy a arruinar la presentación».", Suggestions: HarshThoughts)],
        Theory(
            "Escribes un pensamiento para observar cómo está formulado. Es autoobservación, no un tratamiento ni una garantía de que cambie la emoción.",
            "Cuando un pensamiento se repite y te sientes cómodo escribiéndolo. Detente si te hace sentir peor.",
            "Escribe una frase y léela una vez. Guardar, apartar o romper la hoja es decisión tuya. No tienes que obligarte a estar tranquilo.",
            "Pensamiento: «Voy a arruinar la presentación». Puedes guardar la nota y revisar una diapositiva."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Future = new(
        "Práctica", "Mirar desde el futuro",
        [
            "1. Elige una dificultad cotidiana que puedas manejar",
            "2. Imagina que la miras desde el plazo que elijas: por ejemplo, dentro de uno o cinco años"
        ],
        "Valora la situación con cierta distancia temporal. Puede seguir siendo importante; no tienes que restarle valor.",
        TechniqueUiKind.Entry, "Técnica n.º 5", "30.01.2023", "Mirar desde el futuro", "Prueba otra perspectiva sin quitar importancia", "Tamaño del problema", "Equipo PsychologyApp", 2, "Schedule",
        [
            new TechniqueEntrySeed("Situación", "Por ejemplo: una dificultad manejable en el trabajo.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("¿Qué importancia tiene desde esa distancia?", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "La perspectiva temporal es una forma imaginada de mirar una situación. Su importancia puede seguir igual, y eso también está bien.",
            "Para una dificultad cotidiana manejable. No elijas un recuerdo traumático ni un problema urgente que requiera actuar.",
            "Elige un plazo, como uno o cinco años. Imagina que miras la situación desde entonces y valóralo. No hay una respuesta correcta; detente si el ejercicio no te sirve.",
            "Que no respondan a una invitación puede seguir importando dentro de un año. Hoy puedes preguntar o elegir otro paso."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Hack = new(
        "Práctica", "Pausa con detalles del entorno",
        [
            "1. Elige un objeto neutro cercano sin volver a un recuerdo doloroso",
            "2. Nombra tres detalles: color, forma y superficie",
            "3. Decide si quieres continuar o parar"
        ],
        "Una breve orientación hacia un objeto cercano, sin revivir un suceso doloroso.",
        TechniqueUiKind.Entry, "Técnica n.º 6", "30.01.2023", "Pausa con detalles del entorno", "Lleva la atención a lo que te rodea", "Momento difícil", "Equipo PsychologyApp", 3, "BlurOn",
        [new TechniqueEntrySeed("Objeto cercano", "Por ejemplo: una taza, una ventana o un libro.", Role: EntryFieldRole.None)],
        Theory(
            "Lleva la atención a un objeto neutro, aquí y ahora. Es un breve ejercicio de orientación, no un tratamiento ni un sustituto de la ayuda profesional.",
            "Cuando quieras centrarte un momento en lo que te rodea. No uses la práctica en lugar de pedir ayuda urgente.",
            "Nombra tres detalles del objeto. Si te sientes peor o incómodo, detente, mira a tu alrededor y elige otra acción.",
            "Por ejemplo: una taza — blanca, redonda y fresca al tacto."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Experience = new(
        "Práctica", "Modificación de la experiencia",
        [
            "1. Elige un ámbito para trabajar",
            "2. Describe tu actitud hacia él",
            "3. Nombra las creencias relacionadas",
            "4. ¿Cómo cambia la actitud al pensar en experiencias pasadas?",
            "5. Describe una experiencia negativa",
            "6. Valora la experiencia negativa (−10…10)",
            "7. ¿Qué experiencia positiva podría sustituirla?",
            "8. ¿Cómo cambiaría tu actitud con esa experiencia?",
            "9. Valora la nueva experiencia (−10…10)"
        ],
        "La EMO ayuda a sustituir una experiencia limitante por otra que te sostenga más.",
        TechniqueUiKind.Entry, "Técnica n.º 7", "08.02.2023", "Modificación de la experiencia", "Reescribir una experiencia limitante", "Momento difícil", "Filip Slavinski", 15, "Psychology",
        [
            new TechniqueEntrySeed("Ámbito", "Relaciones, trabajo, salud…", Suggestions: ["Las relaciones", "El trabajo", "La salud", "El dinero", "Hablar en público", "La familia", "Los estudios", "La apariencia", "La amistad", "La creatividad", "El deporte", "La carrera"]),
            new TechniqueEntrySeed("Actitud hacia el ámbito", "¿Cómo lo sientes ahora?", Suggestions: ["Ansiedad", "Inseguridad", "Irritación", "Indiferencia", "Interés", "Cansancio", "Miedo", "Vergüenza", "Esperanza", "Enfado", "Confusión", "La calma"]),
            new TechniqueEntrySeed("Creencias relacionadas", "P. ej., «No lo voy a lograr»", Suggestions: ["«No lo voy a lograr»", "«No soy suficiente»", "«No me van a aceptar»", "«Nada va a cambiar»", "«Tengo que ser perfecto»", "«No tengo suerte»", "«No me lo merezco»", "«Los demás son mejores»", "«No puedo equivocarme»", "«Ya soy mayor para esto»"]),
            new TechniqueEntrySeed("Actitud y experiencia pasada", "¿Qué cambia cuando recuerdas el pasado?", Suggestions: ["Se hace más pesado", "Se vuelve más tranquilo", "No cambia nada", "Surge el enfado", "Surge la tristeza", "Surge el miedo", "Recuerdo que salí adelante", "Quiero evitarlo"]),
            new TechniqueEntrySeed("Experiencia negativa", "Un episodio concreto o un patrón"),
            new TechniqueEntrySeed("Valoración de la experiencia negativa", "", EntryFieldKind.RatingNeg10To10),
            new TechniqueEntrySeed("Sustituto positivo", "¿Qué experiencia de apoyo es posible?", Suggestions: ["Una vez que lo logré", "Una vez que me apoyaron", "Una vez que salí adelante solo", "Una vez que me elogiaron", "Una vez que ayudé a alguien", "Una vez que aprendí algo nuevo", "Una vez que no me rendí", "Una vez que me aceptaron como soy"]),
            new TechniqueEntrySeed("Actitud con lo positivo", "¿Cómo cambiaría tu forma de ver el ámbito?", Suggestions: ["Aparece la esperanza", "Más calma", "Quiero volver a intentarlo", "Se vuelve interesante", "Aparece la confianza", "Se hace más ligero", "Siento fuerza", "Todavía cuesta creerlo"]),
            new TechniqueEntrySeed("Valoración de la nueva experiencia", "", EntryFieldKind.RatingNeg10To10)
        ],
        Theory(
            "Las creencias suelen apoyarse en una sola experiencia negativa muy viva. Sustituirla de forma consciente puede cambiar tu actitud.",
            "Cuando «siempre ha sido así» y el cambio parece imposible.",
            "Recorre los campos en orden. Compara las dos valoraciones: busca que la segunda sea más alta.",
            "Ámbito: hablar en público. Negativa: un examen suspendido (−8). Sustituto: una buena exposición (+6)."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Copied = new(
        "Práctica", "Observa el pensamiento",
        [
            "1. Escribe una frase breve que vuelve una y otra vez",
            "2. Léela una vez y pregúntate: ¿es un hecho, una predicción o una valoración?",
            "3. Si te resulta cómodo, comprueba un hecho. Para si aumenta el malestar"
        ],
        "Este ejercicio ayuda a observar cómo está formulado un pensamiento; repetirlo no garantiza que disminuya la ansiedad.",
        TechniqueUiKind.Copied, "Técnica n.º 8", "21.01.2025", "Observa el pensamiento", "Nombra una frase ansiosa sin discutir contigo", "Tamaño del problema", string.Empty, 2, "Repeat",
        [new TechniqueEntrySeed("Frase", "Tengo miedo de perder mi trabajo", Suggestions: HarshThoughts)],
        Theory(
            "Es una forma breve de observar las palabras de un pensamiento y comprobar en qué se basa. No hace falta decirlo en voz alta ni repetirlo.",
            "Cuando una frase vuelve a menudo y te apetece mirarla un momento. Sáltate el ejercicio si ahora te resulta demasiado abrumadora.",
            "Escribe el pensamiento en pocas palabras. Pregúntate qué sabes con certeza y qué es una predicción. No te obligues a creer una respuesta. Para si aumenta el malestar.",
            "Pensamiento: «Seguro que me irá mal en la reunión». Hecho: «Mañana tengo una reunión». El resultado aún no se conoce."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Extend = new(
        "Práctica", "Plan para la incertidumbre",
        [
            "1. Nombra la situación para la que buscas una alternativa",
            "2. Anota una opción realista y los recursos disponibles",
            "3. Elige el siguiente paso o cuándo retomar el plan"
        ],
        "Planificar puede aclarar las acciones disponibles; no garantiza un resultado ni alivio inmediato.",
        TechniqueUiKind.Entry, "Técnica n.º 9", "21.01.2025", "Plan para la incertidumbre", "Encontrar un siguiente paso práctico", "Tamaño del problema", string.Empty, 3, "Backup",
        [
            new TechniqueEntrySeed("Situación", "¿Qué podría no salir según lo previsto?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Opción práctica", "P. ej., aclarar un plazo o pedir ayuda", Suggestions: BackupOptions),
            new TechniqueEntrySeed("Recurso o apoyo", "¿A quién o a qué podrías recurrir?", Suggestions: BackupOptions),
            new TechniqueEntrySeed("Siguiente paso", "¿Qué puedes hacer ahora o cuándo retomarás el tema?", Suggestions: BackupOptions)
        ],
        Theory(
            "Planificar puede aclarar acciones posibles, pero no controla las decisiones de otras personas ni garantiza calma.",
            "Cuando hay una incertidumbre práctica concreta y quieres considerar una opción manejable.",
            "Separa los hechos conocidos de las preocupaciones. Elige un paso realista, un recurso o un momento para volver al tema. Si planificar te lleva a revisar una y otra vez todos los escenarios y aumenta el malestar, para.",
            "Si no recibes respuesta después de una entrevista, puedes elegir un momento razonable para preguntar y dedicarte mientras tanto a otras tareas. Eso no predice la decisión de la empresa."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Resize = new(
        "Práctica", "Observa la imagen desde cierta distancia",
        [
            "1. Nombra brevemente una situación cotidiana; no hacen falta recuerdos dolorosos",
            "2. Si te resulta cómodo, imagínala como una imagen quieta",
            "3. Puedes cambiar su tamaño o distancia, pero no fuerces el cambio"
        ],
        "Una visualización opcional para observar la atención; no cambia la situación ni promete alivio.",
        TechniqueUiKind.Entry, "Técnica n.º 10", "22.01.2025", "Observa la imagen desde cierta distancia", "Prueba la distancia solo si te resulta cómodo", "Tamaño del problema", string.Empty, 2, "ZoomOutMap",
        [new TechniqueEntrySeed("Lo que te preocupa", "P. ej., un conflicto que no te deja dormir", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem)],
        Theory(
            "Es un breve ejercicio de imaginación: puedes observar una imagen desde cierta distancia. Cada persona puede reaccionar de forma distinta y la situación no cambia por ello.",
            "Solo para una preocupación cotidiana manejable. No elijas un recuerdo doloroso; puedes saltarte el ejercicio.",
            "Imagina la situación sin añadir detalles. Cambia el tamaño o la distancia solo si te resulta cómodo. Si aumenta el malestar, para y observa la habitación a tu alrededor.",
            "Puedes imaginar una tarea como una nota sobre la mesa y decidir cuándo volver a ella. La imagen no tiene que hacerse más pequeña ni más tranquila."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Check = new(
        "Práctica", "Dirige la atención",
        [
            "1. Nombra el pensamiento recurrente en una frase breve, sin detalles",
            "2. Observa: «Estoy teniendo el pensamiento de que…»",
            "3. Si quieres, dirige la atención a un sonido u objeto neutro; el pensamiento puede quedarse"
        ],
        "Este ejercicio ayuda a elegir dónde poner la atención; no exige que los pensamientos desaparezcan.",
        TechniqueUiKind.Entry, "Técnica n.º 11", "22.01.2025", "Dirige la atención", "Observa el pensamiento y elige un foco neutro", "Tamaño del problema", string.Empty, 2, "FactCheck",
        [new TechniqueEntrySeed("Aquello a lo que le das vueltas", "¿Qué pensamiento vuelve una y otra vez?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem)],
        Theory(
            "Es una forma breve de observar un pensamiento recurrente y darle otra tarea a la atención. No hace falta suprimirlo ni conseguir calma.",
            "Cuando repites un tema en tu cabeza y te sientes cómodo probando un cambio breve. Si el pensamiento se refiere a un peligro real, atiende primero a la seguridad.",
            "Nombra el pensamiento en una frase y elige un sonido u objeto neutro de tu entorno. Para si aumenta el malestar. No lo uses en lugar de una acción médica o práctica necesaria.",
            "Pensamiento: «¿Y si estoy enfermo?». Puedes observarlo como un pensamiento y decidir si hace falta un paso real, como consultar a un profesional por un síntoma."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Observer = new(
        "Práctica", "Hablarse con distancia",
        [
            "1. Nombra la situación y la emoción en una frase; no hace falta detallar un suceso doloroso.",
            "2. Dirígete a ti por tu nombre o como «tú», en vez de usar solo «yo». Por ejemplo: «[Nombre], ¿qué está pasando ahora?»",
            "3. Escribe qué importa ahora y un siguiente paso seguro y realista. No justifiques el daño ni minimices el peligro.",
            "4. Valora tu tensión ahora. Puede bajar, quedarse igual o aumentar. Si te sientes peor, detente y elige otro apoyo."
        ],
        "Una adaptación breve del diálogo interno distanciado: dirígete a ti por tu nombre o como «tú» en vez de usar solo «yo». Puede darte espacio para reflexionar, pero no promete alivio inmediato.",
        TechniqueUiKind.Entry, "Técnica n.º 12", "12.06.2026", "Hablarse con distancia", "Háblate por tu nombre o como «tú» y elige un paso seguro", "Momento difícil", "Autocuidado", 1, "Visibility",
        [
            new TechniqueEntrySeed("Situación", "En breve: ¿qué está pasando ahora? No hace falta contar los detalles de un suceso doloroso.", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Sentimientos en primera persona", "¿Qué sientes? Basta con una frase breve.", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("Lo que ve el observador", "Dirígete a ti por tu nombre o como «tú»: ¿qué importa y cuál es un siguiente paso seguro?", Suggestions: ["[Nombre], ¿qué es importante para ti ahora?", "¿Cuál es un paso seguro y realista?", "¿Cómo puedes apoyarte?", "¿Qué le dirías a alguien cercano?", "Puedes responder más tarde, cuando lo veas más claro"]),
            new TechniqueEntrySeed("Tensión ahora", "Valórala al final; puede quedarse igual.", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "El diálogo interno distanciado consiste en usar tu nombre o «tú» en vez de solo «yo». Puede dejar espacio para reflexionar, pero no garantiza alivio inmediato.",
            "Pruébalo con una tensión emocional o social manejable y solo si estás a salvo. No lo uses para justificar un daño ni restar importancia a un peligro real.",
            "Nombra brevemente la emoción, háblate por tu nombre o como «tú» y pregúntate qué importa ahora y qué paso seguro es posible.",
            "En vez de «No puedo con esto»: «[Nombre], esto es difícil. ¿Cuál es un siguiente paso seguro para ti?»"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Anchor = new(
        "Práctica", "Recuerdo de apoyo",
        [
            "1. Recuerda un momento seguro en el que recibiste apoyo o superaste una dificultad",
            "2. Observa qué te ayudó y qué notabas en el cuerpo",
            "3. Si quieres, elige un gesto solo como recordatorio del recuerdo",
            "4. Valora cuánto te ayuda el recuerdo ahora (0 = nada, 10 = mucho); está bien elegir 0"
        ],
        "Un recuerdo puede traer a la mente fuentes de apoyo conocidas. La respuesta varía; un gesto es solo un recordatorio opcional, no una forma fiable de cambiar el estado.",
        TechniqueUiKind.Entry, "Técnica n.º 13", "12.06.2026", "Recuerdo de apoyo", "Recordar una experiencia de apoyo y reconocer recursos disponibles", "Momento difícil", "Recuerdo de apoyo", 4, "SelfImprovement",
        [
            new TechniqueEntrySeed("Recuerdo de recursos", "Elige un recuerdo que sea seguro para ti; si no encuentras uno, puedes omitir el ejercicio.", Suggestions: ["Una exposición que salió bien", "Unas vacaciones en el mar", "El abrazo de alguien cercano", "Terminar algo difícil", "Un paseo por la naturaleza", "Aprobar un examen", "El nacimiento de un hijo", "Ganar una competición", "Una tarde con amigos", "Un elogio de mi jefe", "El primer día en un trabajo nuevo", "Una mañana sin prisas"]),
            new TechniqueEntrySeed("Sensaciones del cuerpo", "¿Dónde lo sientes? Calor, ligereza, arraigo…", Suggestions: ["Calor en el pecho", "Ligereza", "Los hombros abiertos", "Respiración regular", "Piernas firmes", "Una sonrisa", "Un corazón tranquilo", "La espalda recta", "Energía en las manos", "El vientre relajado"]),
            new TechniqueEntrySeed("Gesto opcional para recordar", "Este gesto puede recordarte el recuerdo; puedes omitir este paso", Suggestions: ["Cerrar el puño", "Tocar la muñeca", "Unir el pulgar y el índice", "La mano en el corazón", "Una respiración profunda", "Apretar el lóbulo de la oreja", "Abrir los hombros", "Acariciar la palma"]),
            new TechniqueEntrySeed("Respuesta al recuerdo", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Este es un breve ejercicio de recuerdo. Su efecto y cualquier vínculo con un gesto no están garantizados.",
            "Cuando quieras recordar qué te ha ayudado antes. Elige solo un recuerdo seguro; detente si te hace sentir peor.",
            "Observa qué te ayudó entonces. El gesto es opcional y solo sirve de recordatorio; no tienes que obligarte a sentir calma.",
            "Recuerdo que un amigo me escuchó. Hablar me ayudó; ahora podría escribirle. Respuesta al recuerdo: 5 de 10."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Grounding = new(
        "Práctica", "Anclaje 5-4-3-2-1",
        [
            "1. Nombra 5 cosas que ves",
            "2. Nombra 4 cosas que sientes con el cuerpo",
            "3. Nombra 3 sonidos a tu alrededor",
            "4. Nombra 2 olores",
            "5. Nombra 1 sabor o una sensación agradable"
        ],
        "El anclaje sensorial lleva la atención de los pensamientos ansiosos al momento presente.",
        TechniqueUiKind.Entry, "Técnica n.º 14", "12.06.2026", "Anclaje 5-4-3-2-1", "Volver al presente a través de los sentidos", "Momento difícil", "Psique", 3, "Nature",
        [
            new TechniqueEntrySeed("5 cosas que veo", "P. ej., ventana, taza, libro, lámpara, mano", Suggestions: ["Ventana", "Mesa", "Teléfono", "Ordenador", "Portátil", "Pantalla", "Teclado", "Taza", "Lámpara", "Mano", "Puerta", "Libro", "Silla", "Pared", "Cuadro", "Planta", "Reloj", "Armario", "Cielo", "Coche"]),
            new TechniqueEntrySeed("4 cosas que siento con el cuerpo", "P. ej., la silla, el suelo, la ropa, la temperatura del aire", Suggestions: ["Silla", "El suelo bajo mis pies", "La ropa", "El fresco", "El calor", "El teléfono en la mano", "El respaldo de la silla", "La tela sobre la piel", "La respiración en el pecho", "El viento", "El ratón", "Las llaves", "La almohada", "El reloj en la muñeca"]),
            new TechniqueEntrySeed("3 sonidos", "P. ej., la calle, el reloj, tu respiración", Suggestions: ["La calle", "Reloj", "La respiración", "Voces", "La nevera", "El viento", "El silencio", "Ordenador", "Los coches", "Los pájaros", "La música", "El aire acondicionado", "Pasos", "La lluvia"]),
            new TechniqueEntrySeed("2 olores", "P. ej., café, aire fresco", Suggestions: ["Café", "Aire fresco", "Jabón", "Comida", "Perfume", "Casi nada", "Té", "Pan", "Libros", "Flores", "Crema de manos", "Madera"]),
            new TechniqueEntrySeed("1 sabor o una sensación agradable", "P. ej., agua en la boca, una tela suave", Suggestions: ["Agua", "Té", "Una tela suave", "Las palmas calientes", "La boca fresca", "Café", "Un chicle de menta", "Chocolate", "Una manzana", "Una manta calentita"])
        ],
        Theory(
            "Lleva la atención a lo que ves, oyes y sientes a tu alrededor.",
            "Cuando las preocupaciones ocupan tu atención y quieres centrarte en lo que te rodea.",
            "Empieza por lo que ves. Si no percibes un olor o un sabor, sigue adelante. Respira como de costumbre.",
            "Veo una taza y una lámpara. Siento el suelo bajo los pies. Oigo el tráfico de la calle."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Breathing = new(
        "Práctica", "Respiración guiada suave",
        [
            "1. Valora la tensión antes de empezar",
            "2. Siéntate cómodamente. Respira con suavidad, sin inspirar más profundamente de lo habitual",
            "3. Si te resulta cómodo, sigue el círculo: inspira unos 4 tiempos y espira unos 6. No retengas el aire",
            "4. Si el ritmo no te va bien, deja de contar o detén la práctica. Si te mareas o te falta el aire, vuelve a tu respiración natural",
            "5. Vuelve a valorar la tensión al terminar. Puede que no cambie; eso también es información útil"
        ],
        "Cuando sientas tensión, puedes probar un ritmo breve y suave, sin pausas. No es adecuado para todo el mundo: contar o centrarse en la respiración puede aumentar la incomodidad.",
        TechniqueUiKind.Entry, "Técnica n.º 15", "04.07.2026", "Respiración guiada suave", "Prueba un ritmo cómodo con una espiración algo más larga", "Momento difícil", "Psique", 3, "Air",
        [
            new TechniqueEntrySeed("Tensión antes", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notas", "¿Qué notaste? Cualquier reacción es válida.", Suggestions: ["El ritmo me resultó cómodo", "Contar me distrajo", "El ritmo era demasiado lento", "Me mareé", "Respirar me resultó incómodo", "Me sentí algo más tranquilo", "La tensión no cambió", "Me sentí más tenso", "Paré y observé lo que me rodeaba"]),
            new TechniqueEntrySeed("Tensión después", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Un ritmo breve y suave con una espiración algo más larga permite probar a acompañar la respiración cuando hay tensión. La respuesta varía y esta práctica no garantiza alivio.",
            "Cuando sientes tensión y te resulta cómodo centrarte en la respiración.",
            "Siéntate cómodamente. Respira con suavidad y no más profundamente de lo habitual. Durante cerca de un minuto, puedes seguir el círculo: inspira unos 4 tiempos y espira unos 6, sin pausas. Si el ritmo se siente forzado, vuelve a tu respiración natural. Para si aumenta la incomodidad y nombra algunos objetos que tengas alrededor.",
            "La tensión era 7/10. Al cabo de un minuto seguía en 7/10; contar se sentía forzado, así que paré y nombré cinco objetos a mi alrededor."
        ),
        null, null);

    internal static readonly BuiltInTechniqueDefinition SmallStep = new(
        "Práctica", "Un pequeño paso",
        [
            "1. Elige una actividad pequeña de autocuidado, interés, conexión o sensación de haber terminado algo",
            "2. Redúcela a un comienzo seguro de 2–5 minutos. No tienes que terminar toda la tarea",
            "3. Elige un momento concreto en las próximas 24 horas. Si ahora no es buen momento, elige descansar, pedir apoyo o dar un paso menor",
            "4. Valora si te parece posible: 0 — nada de confianza, 10 — total confianza. Si dudas, hazlo más pequeño"
        ],
        "Un breve plan de actividad inspirado en la activación conductual. Un paso pequeño puede ayudar a empezar, pero no garantiza mejor ánimo ni más energía.",
        TechniqueUiKind.Entry, "Técnica n.º 16", "04.07.2026", "Un pequeño paso", "Elige una actividad y haz posible el comienzo", "Momento difícil", "TCC", 5, "DirectionsWalk",
        [
            new TechniqueEntrySeed("¿Qué te dificulta empezar?", "Cansancio, ansiedad, soledad, demasiadas cosas?", Suggestions: ["Cansancio", "Ansiedad", "Soledad", "Demasiadas cosas por hacer", "Aburrimiento", "No sé por dónde empezar", "Necesito descansar", "Ahora no se dan las condiciones"], Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Una actividad pequeña para mí", "Autocuidado, interés, conexión o una tarea breve", Suggestions: ["Beber agua o comer algo", "Lavarme o vestirme", "Tomar aire 2 minutos", "Poner una canción que me gusta", "Escribir un mensaje a alguien cercano", "Dedicar 2 minutos a algo importante", "Guardar una cosa", "Pedir a alguien que me acompañe"]),
            new TechniqueEntrySeed("¿Cuándo lo intentarás?", "Un momento concreto en las próximas 24 horas", Suggestions: ["Ahora durante 2 minutos", "Después del desayuno", "Después de comer", "Al terminar el trabajo o el estudio", "A una hora que elija hoy", "Pedir a alguien cercano que me lo recuerde"]),
            new TechniqueEntrySeed("¿Qué tan posible te parece?", "0 — nada de confianza, 10 — total confianza", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "El bajo ánimo o la energía pueden dificultar el comienzo. Una actividad pequeña y planificada puede ayudar a ponerse en marcha; el efecto varía en cada persona.",
            "Cuando el ánimo o la energía dificultan empezar y hay una actividad segura y manejable. Descansar o pedir ayuda también puede ser un buen paso.",
            "Elige algo de autocuidado, interés, conexión o sensación de logro; reduce el comienzo a 2–5 minutos y ponle un momento dentro de las próximas 24 horas. Planificar no significa que ya lo hayas hecho. Si no te parece posible, hazlo más pequeño o pide apoyo.",
            "En vez de «ordenar toda la casa», lava una taza después de comer — o escribe a alguien cercano: «¿Tienes un minuto para hablar?»"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition ThoughtRecord = new(
        "Práctica", "Registro de pensamientos",
        [
            "1. Describe la situación sin juzgarla",
            "2. Escribe el pensamiento automático",
            "3. Nombra la emoción y valora su intensidad ahora",
            "4. Separa los hechos de las suposiciones y busca otra posibilidad",
            "5. Valora otra vez la emoción; puede seguir igual"
        ],
        "Separa la situación, el pensamiento y la emoción; luego contrasta la conclusión con los hechos. La emoción no tiene que disminuir.",
        TechniqueUiKind.Entry, "Técnica n.º 17", "04.07.2026", "Registro de pensamientos", "Distingue un hecho de una interpretación", "Momento difícil", "TCC", 7, "EditNote",
        [
            new TechniqueEntrySeed("Situación", "¿Qué pasó? ¿Dónde y cuándo? Solo lo necesario.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Pensamiento automático", "¿Qué pensaste en ese momento?", Suggestions: HarshThoughts),
            new TechniqueEntrySeed("Emoción antes", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Una mirada más ajustada", "¿Qué hechos la apoyan o la contradicen? ¿Qué más es posible?", Role: EntryFieldRole.Reframe),
            new TechniqueEntrySeed("Emoción después", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "El ejercicio separa un hecho de tu interpretación. No es un diagnóstico ni un tratamiento.",
            "Para una situación moderadamente desagradable, si ahora tienes energía para escribir. No elijas un recuerdo traumático ni una crisis aguda.",
            "Anota los hechos observables y luego el pensamiento. Busca una explicación que tenga en cuenta lo que sabes y lo que desconoces; no te fuerces a pensar en positivo. Si la valoración no cambia, no significa que lo hayas hecho mal.",
            "Situación: aún no hay respuesta a un mensaje. Pensamiento: «Nadie me necesita». Hecho: todavía no hay respuesta. Otra posibilidad: no sabes el motivo; quizá está ocupado."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition SelfCompassion = new(
        "Práctica", "Palabras amables para ti",
        [
            "1. Escribe qué te estás criticando",
            "2. Imagina que un amigo cercano dijera esto: ¿qué le dirías?",
            "3. Formula la misma frase de apoyo para ti",
            "4. Valora la calidez o el alivio"
        ],
        "La autocompasión reduce la autocrítica dura y ayuda a recuperarte después de un error.",
        TechniqueUiKind.Entry, "Técnica n.º 18", "04.07.2026", "Palabras amables para ti", "Suavizar la autocrítica con apoyo", "Momento difícil", "TCC", 5, "Favorite",
        [
            new TechniqueEntrySeed("Lo que te criticas", "¿Qué te dices o de qué te culpas?", Suggestions: ["Un error en el trabajo", "No lo terminé", "Le grité a alguien cercano", "Me comparo con los demás", "Lo vuelvo a dejar para después", "Mi apariencia", "Mi peso", "Dije algo que no debía", "No soy buen padre o madre", "Gano muy poco", "No cumplí una promesa", "Soy demasiado sensible"]),
            new TechniqueEntrySeed("Lo que le dirías a un amigo", "¿Cómo apoyarías a alguien cercano en esta situación?", Role: EntryFieldRole.Kindness),
            new TechniqueEntrySeed("Frase para ti", "La misma amabilidad, dirigida a ti", Role: EntryFieldRole.SelfKindness),
            new TechniqueEntrySeed("Calidez / alivio", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "La autocrítica rara vez motiva: más a menudo alimenta la vergüenza y la parálisis. La autocompasión no quita la responsabilidad, pero da apoyo.",
            "Después de un error, al compararte con otros o al sentir que no eres suficiente.",
            "Escribe la crítica y respóndete como lo harías con un amigo: con respeto y sin quitarle importancia.",
            "Crítica: otra vez lo arruiné todo. A un amigo: lo intentaste, tiene arreglo. A mí: puedo aprender de esto. Calidez: 3 → 6."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition BodyScan = new(
        "Práctica", "¿Dónde está en el cuerpo?",
        [
            "1. Valora tu tensión ahora",
            "2. Recorre despacio el cuerpo con la atención, de la cabeza a los pies",
            "3. Encuentra el lugar donde la sensación es más fuerte",
            "4. Descríbela: cómo es, grande o pequeña, cálida o fría",
            "5. Nombra el sentimiento que la acompaña",
            "6. Si quieres, observa qué ha cambiado o sigue igual. Puedes parar o dirigir la atención al entorno en cualquier momento."
        ],
        "El escaneo corporal invita a observar las sensaciones y emociones sin necesidad de cambiarlas.",
        TechniqueUiKind.Entry, "Técnica n.º 19", "16.10.2026", "¿Dónde está en el cuerpo?", "Observar las sensaciones sin necesidad de cambiarlas", "Momento difícil", "Mindfulness", 4, "Accessibility",
        [
            new TechniqueEntrySeed("Tensión ahora", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("¿En qué parte del cuerpo lo sientes?", "Por ejemplo: pecho, garganta, hombros", Suggestions: ["Cabeza", "Frente", "Ojos", "Mandíbula", "Garganta", "Cuello", "Hombros", "Pecho", "Corazón", "Estómago", "Espalda", "Zona lumbar", "Brazos", "Manos", "Piernas", "Todo el cuerpo"]),
            new TechniqueEntrySeed("¿Cómo es la sensación?", "Por ejemplo: opresión, pesadez, un nudo", Suggestions: ["Opresión", "Pesadez", "Un nudo", "Presión", "Tensión", "Calor", "Frío", "Temblor", "Hormigueo", "Palpitación", "Vacío", "Entumecimiento", "Dolor", "Difícil de describir"]),
            new TechniqueEntrySeed("¿Qué sentimiento la acompaña?", "Por ejemplo: ansiedad, dolor emocional, cansancio", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("Tensión después", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "El escaneo corporal puede servir para observar sensaciones y los sentimientos que quizá las acompañan. Notarlas no tiene por qué reducir la tensión; puede seguir igual. Esta práctica se utiliza en algunos programas de mindfulness.",
            "Cuando te sientes ansioso o pesado pero no sabes qué sientes exactamente; cuando el cuerpo está tenso tras una conversación o un día difícil. La práctica no explica enfermedades ni sustituye al médico: si una sensación es nueva, fuerte o no se va, consulta a un médico.",
            "Siéntate cómodamente, si te resulta agradable, y lleva poco a poco la atención a distintas partes del cuerpo. Describe una sensación con la mayor precisión posible; si te encaja, nombra también un sentimiento. No tienes que cambiar nada. Si mirar hacia dentro te resulta incómodo, abre los ojos, céntrate en objetos a tu alrededor o termina la práctica. Respira con normalidad.",
            "Tensión 6/10. Lugar: pecho. Sensación: opresión. Sentimiento: ansiedad antes de una conversación. Después, la tensión seguía en 6/10. Abrí los ojos y nombré objetos de la habitación. Ese también es un resultado válido."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Flashback = new(
        "Práctica", "Un recuerdo me ha desbordado",
        [
            "1. Valora lo fuerte que es",
            "2. Dite: «Esto es un recuerdo. Eso fue entonces, y ahora es hoy»",
            "3. Nombra dónde estás y qué momento del día es",
            "4. Siente el apoyo bajo los pies, aprieta y suelta los puños",
            "5. Nombra tres cosas que ves",
            "6. Cinco exhalaciones lentas, agua fría, y valora otra vez"
        ],
        "Ayuda ante un recuerdo intrusivo: volver del recuerdo al presente a través del tiempo, el lugar, el cuerpo y los sentidos.",
        TechniqueUiKind.Entry, "Técnica n.º 20", "16.10.2026", "Un recuerdo me ha desbordado", "Volver al presente cuando un recuerdo difícil te desborda", "Momento difícil", "Trauma", 3, "MyLocation",
        [
            new TechniqueEntrySeed("Lo fuerte que es", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Dónde estás y qué momento del día es", "Por ejemplo: en casa, por la noche", Suggestions: ["En casa", "En el trabajo", "En la calle", "En el transporte", "De visita", "Mañana", "Tarde", "Anochecer", "Noche"]),
            new TechniqueEntrySeed("Tres cosas que ves", "Por ejemplo: ventana, taza, lámpara", Suggestions: ["Ventana", "Mesa", "Teléfono", "Taza", "Lámpara", "Puerta", "Silla", "Pared", "Cuadro", "Planta", "Reloj", "Cielo"]),
            new TechniqueEntrySeed("Lo fuerte que es ahora", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Un recuerdo intrusivo (flashback) es un recuerdo de un trauma que se vive como si estuviera pasando de nuevo: con los mismos sentimientos y reacciones del cuerpo. El cerebro confunde «entonces» y «ahora». El tiempo, el lugar, el apoyo del cuerpo y lo que ves y oyes ayudan a volver al presente.",
            "Cuando el recuerdo de algo difícil te desborda, con imágenes que irrumpen y la sensación de «estoy otra vez allí». Los recuerdos intrusivos frecuentes son una señal habitual de reacción postraumática y responden bien al tratamiento con un especialista en trauma.",
            "No intentes trabajar el recuerdo: ahora la única tarea es volver. Dite dónde estás y qué día es, presiona los pies contra el suelo, nombra lo que ves, exhala despacio, usa el frío.",
            "Intensidad 8. «Eso fue entonces; ahora es 2026, estoy en casa, es de noche». Los pies en el suelo; veo una ventana, una taza, una lámpara. Agua fría. Ahora 4."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Nightmare = new(
        "Práctica", "Reescribir una pesadilla",
        [
            "1. Elige una pesadilla que se repite, no la más difícil para empezar",
            "2. Descríbela brevemente, sin detalles duros",
            "3. Decide qué cambias en ella: el final, el lugar, a ti mismo, a alguien cerca",
            "4. Escribe la nueva versión del sueño completa, hasta un final tranquilo",
            "5. Cada día, durante 10 a 20 minutos, imagina la nueva versión con detalle",
            "6. Tras una o dos semanas, mira cómo han cambiado las pesadillas"
        ],
        "Ensayo en imaginación: una pesadilla recurrente se reescribe estando despierto, y el cerebro empieza a soñar la nueva versión.",
        TechniqueUiKind.Entry, "Técnica n.º 21", "16.10.2026", "Reescribir una pesadilla", "Hacer que una pesadilla recurrente sea menos frecuente y menos intensa", "El sueño", "Trauma", 15, "NightsStay",
        [
            new TechniqueEntrySeed("Lo dura que es esta pesadilla", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("De qué trata la pesadilla, en pocas palabras", "Una o dos frases, sin detalles duros", Suggestions: ["Alguien me persigue", "No puedo escapar", "Estoy otra vez donde tuve miedo", "Pierdo a alguien cercano", "No puedo gritar", "Me caigo", "Me atacan", "Llego tarde y no lo consigo"]),
            new TechniqueEntrySeed("Lo que cambias", "Lo que quieras: es tu sueño", Suggestions: ["El final", "El lugar", "Me vuelvo más fuerte", "Aparece alguien que me ayuda", "Puedo hablar y gritar", "El peligro desaparece", "Todo se vuelve seguro", "Me doy cuenta de que es un sueño"]),
            new TechniqueEntrySeed("La nueva versión del sueño", "Descríbela completa, desde el principio hasta un final tranquilo", Suggestions: ["Me doy cuenta de que es un sueño", "Aparece alguien que me protege", "Me encuentro en un lugar seguro", "Me alejo con calma", "Todo termina bien"]),
            new TechniqueEntrySeed("Cuándo ensayaré la nueva versión", "Cada día, de 10 a 20 minutos", Suggestions: ["Por la mañana", "Durante el día, en un descanso", "Por la noche, un par de horas antes de dormir", "Cada día a la misma hora"]),
            new TechniqueEntrySeed("Lo dura que es ahora", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Las pesadillas que se repiten tras un trauma o un estrés se mantienen por costumbre: el cerebro reproduce la misma trama una y otra vez. En la terapia de ensayo en imaginación, la trama se reescribe estando despierto y la nueva versión se ensaya mentalmente cada día. Los estudios muestran que así las pesadillas se vuelven menos frecuentes e intensas y el sueño mejora.",
            "Con pesadillas que se repiten y te dan miedo a dormirte. Si la pesadilla repite directamente un trauma y hasta una descripción breve te provoca mucho horror, hazlo junto con un especialista en trauma.",
            "Empieza por una pesadilla más leve. No escribas con detalle las partes que dan miedo: con un par de frases basta. Cambia el sueño como quieras; la nueva versión no tiene que ser realista. Ensáyala durante el día, no justo antes de dormir, de 10 a 20 minutos al día.",
            "Pesadilla: alguien me persigue y no puedo escapar. Cambio: me doy cuenta de que es un sueño, me doy la vuelta y solo es una sombra; vuelvo a casa con calma. Lo ensayo cada tarde. Tras dos semanas, la pesadilla aparece menos."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Balloons = new(
        "Práctica", "Revienta los globos",
        [
            "1. Valora tu tensión antes del juego",
            "2. Empieza la ronda y toca los globos a tu ritmo; no hace falta acertarlos todos",
            "3. Respira como siempre. No tienes que acompasar la espiración a cada globo",
            "4. La ronda termina sola. Si el juego te frustra o te sientes peor, vuelve atrás",
            "5. Valora tu tensión después y anota lo que observaste. Que no cambie también es un resultado"
        ],
        "Un juego breve para las manos y la atención. Puede distraerte un momento, pero no tiene por qué cambiar cómo te sientes ni sustituye una solución o apoyo.",
        TechniqueUiKind.Entry, "Técnica n.º 22", "26.10.2026", "Revienta los globos", "Una pausa breve con un juego, si te apetece", "Momento difícil", "Psique", 3, "BubbleChart",
        [
            new TechniqueEntrySeed("Tensión antes", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notas", "¿Qué notaste, si acaso? Puedes dejarlo en blanco.", Suggestions: ["Un poco menos de tensión", "Sin cambios apreciables", "Más tensión", "Me distraje por un momento", "Noté los colores o el movimiento", "El juego me frustró", "No estoy seguro", "Otra cosa"]),
            new TechniqueEntrySeed("Tensión después", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Un juego breve puede ocupar por un momento las manos y la atención; el efecto varía. No garantiza reducir la ansiedad ni es un tratamiento.",
            "Cuando te apetece una pausa breve con un juego. No retrases por jugar una acción urgente ni la atención a la salud o la seguridad.",
            "Toca a un ritmo cómodo; no hace falta acertar a todos los globos. Respira con normalidad y no sincronices la respiración con cada globo. Después, compara tu valoración sin esperar un resultado concreto. Si hay un problema práctico que atender, vuelve al siguiente paso cuando estés listo.",
            "Después de una discusión, mi tensión estaba en 7/10 y siguió en 7/10 tras la ronda. Noté que seguía enfadado y decidí esperar antes de responder."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition CyclicSigh = new(
        "Práctica", "Suspiro cíclico",
        [
            "1. Valora tu tensión",
            "2. Inhala por la nariz y, al final, añade otra inhalación corta",
            "3. Exhala despacio por la boca, más tiempo del que inhalaste",
            "4. Respira al ritmo del círculo unos tres minutos",
            "5. Valora tu tensión después"
        ],
        "Dos inhalaciones suaves seguidas y una exhalación más larga marcan un ritmo respiratorio. No hace falta contener la respiración ni inhalar más profundamente de lo habitual.",
        TechniqueUiKind.Entry, "Técnica n.º 23", "26.10.2026", "Suspiro cíclico", "Una doble inhalación y una exhalación larga para calmar el cuerpo", "Momento difícil", "Psique", 3, "Air",
        [
            new TechniqueEntrySeed("Tensión antes", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notas", "¿Qué notaste?", Suggestions: ["Algo más tranquilo", "Sin cambios apreciables", "Más incómodo", "Me mareé", "Prefiero no valorarlo", "Otra cosa"]),
            new TechniqueEntrySeed("Tensión después", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "En un estudio aleatorizado con 111 participantes, el suspiro cíclico se practicó cinco minutos al día durante un mes. Las puntuaciones de estado de ánimo positivo mejoraron más que en el grupo de atención plena. Esto no demuestra que una sola práctica breve reduzca la tensión rápidamente ni que el efecto sea igual para todos.",
            "Puedes probarlo si centrarte en la respiración te resulta cómodo, por ejemplo, antes de una conversación o durante una pausa. Si te incomoda más, elige una práctica que centre la atención en el entorno.",
            "Respira con suavidad, sin intentar inhalar todo lo posible. Repite el ritmo solo mientras te resulte cómodo. Si te mareas o te sientes mal, para, siéntate en un lugar estable y vuelve a respirar con normalidad. Busca atención médica si los síntomas son intensos o persisten.",
            "Antes de una llamada noto tensión y pruebo unos ciclos suaves. Si no cambia nada o me siento peor, paro y vuelvo a respirar con normalidad."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition MuscleRelax = new(
        "Práctica", "Tensar y soltar",
        [
            "1. Valora tu tensión",
            "2. Tensa un grupo de músculos cinco segundos, a media fuerza",
            "3. Suelta y nota la relajación durante quince segundos",
            "4. Recorre cinco grupos: manos, hombros, cara, abdomen, piernas",
            "5. Valora tu tensión después"
        ],
        "Tensar primero los músculos y luego soltarlos ayuda al cuerpo a sentir qué es relajarse.",
        TechniqueUiKind.Entry, "Técnica n.º 24", "26.10.2026", "Tensar y soltar", "Una relajación muscular breve para un cuerpo tenso", "Momento difícil", "Psique", 4, "SelfImprovement",
        [
            new TechniqueEntrySeed("Tensión antes", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notas", "¿En qué parte del cuerpo te sientes más ligero?", Suggestions: ["Se relajaron mis hombros", "Se aflojó mi mandíbula", "Se calentaron mis manos", "Respiro mejor", "Me dio sueño", "Todavía queda algo de tensión", "No cambió nada"]),
            new TechniqueEntrySeed("Tensión después", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "La relajación muscular progresiva es una de las formas más estudiadas de reducir la ansiedad y la tensión. Tensar un músculo y luego soltarlo crea un contraste que ayuda a notar la relajación y, con el tiempo, a aprender a provocarla. No es un tratamiento, sino una habilidad que funciona mejor con la práctica.",
            "Cuando el cuerpo está tenso por el estrés, cuando cuesta quedarse quieto o dormirse. Va bien por la noche antes de dormir.",
            "Tensa a media fuerza, sin dolor. Si una parte del cuerpo duele o está lesionada, no la tenses: solo obsérvala. Al soltar, respira con calma y no te apresures a pasar al siguiente grupo.",
            "Tensión 7/10 por la noche después del trabajo, con los hombros encogidos. Cinco grupos: manos, hombros, cara, abdomen, piernas. Tensión 4/10, los hombros bajaron."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition BusyMind = new(
        "Práctica", "Pausa breve de atención",
        [
            "1. Valora tu tensión solo si te resulta útil ahora",
            "2. Elige una tarea neutra para unos 30–60 segundos",
            "3. Si la atención vuelve a la preocupación, no te critiques; puedes regresar con suavidad a la tarea una vez",
            "4. Termina y comprueba si necesitas un paso práctico o apoyo"
        ],
        "Una tarea neutra y breve puede cambiar la atención por un momento cuando los pensamientos parecen atascados. No elimina los pensamientos ni resuelve el problema.",
        TechniqueUiKind.Entry, "Técnica n.º 25", "26.10.2026", "Pausa breve de atención", "Un descanso temporal cuando los pensamientos se repiten", "Momento difícil", "Psique", 1, "Extension",
        [
            new TechniqueEntrySeed("Tensión antes", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notas", "¿Cómo fue esta pausa breve?", Suggestions: ["Cambié de foco un momento", "No cambió nada", "Me sentí más frustrado o tenso", "Ahora veo un siguiente paso", "Necesito apoyo", "Paré el ejercicio"]),
            new TechniqueEntrySeed("Tensión después", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Una tarea neutra y breve —por ejemplo, nombrar objetos de un color— a veces ayuda a atravesar un momento intenso. Es un cambio temporal de atención, no una forma de eliminar pensamientos; el efecto varía.",
            "Cuando los pensamientos repetidos ocupan tu atención y quieres una pausa breve. Si hay un problema urgente o una cuestión de seguridad o salud, atiéndela y busca ayuda adecuada.",
            "Elige una tarea sencilla durante 30–60 segundos; no necesitas concentrarte perfectamente. Después, decide si hay un paso práctico al que volver. Si te frustra o empeora cómo te sientes, para y elige otro enfoque.",
            "Después de una discusión, la conversación sigue repitiéndose en tu mente. Durante medio minuto, nombra cinco objetos a tu alrededor; luego decide si aclarar un hecho, descansar o pedir apoyo."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition ThoughtDefusion = new(
        "Práctica", "Tomar distancia de un pensamiento",
        [
            "1. Observa un pensamiento breve; escribirlo es opcional",
            "2. Di: «Estoy notando el pensamiento de que…»",
            "3. Mira un objeto frente a ti y siente el apoyo bajo tus pies",
            "4. Elige un pequeño paso siguiente o termina aquí"
        ],
        "Una habilidad breve de la terapia de aceptación y compromiso (ACT): observar un pensamiento como algo que hace la mente, no necesariamente como un hecho o una orden.",
        TechniqueUiKind.Entry, "Técnica n.º 26", "03.11.2026", "Tomar distancia de un pensamiento", "Una práctica breve para tomar distancia de un pensamiento preocupante", "Pensamientos", "Psique", 1, "FormatQuote",
        [
            new TechniqueEntrySeed("Pensamiento", "Opcional: puedes hacer la práctica en silencio", Suggestions: HarshThoughts)
        ],
        Theory(
            "Un pensamiento repetido puede ocupar toda la atención. En ACT, la desfusión consiste en notarlo sin discutir con él ni intentar apartarlo.",
            "Cuando una preocupación, una autocrítica o un miedo vuelve una y otra vez. No hace falta elegir un recuerdo angustiante.",
            "No tienes que escribir nada. Añade «Estoy notando el pensamiento de que…» antes del pensamiento, mira un objeto y siente el apoyo bajo tus pies. Si aumenta el malestar, para y nombra algunos objetos a tu alrededor.",
            "«Lo voy a estropear todo» pasa a ser «Estoy notando el pensamiento de que lo voy a estropear todo». Ves la taza frente a ti y decides responder un correo o hacer una pausa."),
        null, null);
}
