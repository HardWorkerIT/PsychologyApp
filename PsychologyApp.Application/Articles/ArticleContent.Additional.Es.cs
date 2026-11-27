namespace PsychologyApp.Application.Articles;

public static partial class ArticleContent
{
    private static readonly Article[] AdditionalArticlesEs =
    [
        new(
            ArticleIds.CallNerves,
            "Nervios antes de una llamada",
            "Prepara una conversación, no una actuación perfecta",
            "TipsAndUpdates",
            2,
            [
                P("Una llamada puede inquietar porque hay muchas incógnitas: quién responderá, qué preguntará y cómo reaccionará. Elige un objetivo práctico, como pedir una cita, confirmar una hora o transmitir información. Es suficiente; no hace falta preparar cada frase."),
                H("Ten una pequeña guía"),
                P("Anota el nombre de la persona, tu objetivo y una frase inicial: «Hola, llamo para consultar…». Ten a mano las fechas y preguntas necesarias. Puedes pedir que repitan algo. Si la conversación es difícil, puedes decir: «Necesito un momento para pensarlo» o proponer continuar más tarde."),
                H("Después de llamar"),
                P("Apunta qué has averiguado y si hace falta algún paso más. No te juzgues por lo fluida que fue la conversación: las pausas y los nervios no quitan valor a la llamada. Si no consigues contactar, elige una vía siguiente: volver a llamar, escribir o pedir apoyo. Si las llamadas dificultan con frecuencia asuntos importantes, puedes hablarlo con un profesional adecuado.")
            ]),
        new(
            ArticleIds.WaitingForReply,
            "Esperar una respuesta",
            "Tolerar la incertidumbre y elegir el siguiente paso",
            "TipsAndUpdates",
            2,
            [
                P("Al esperar una respuesta es fácil empezar a imaginar: «He dicho algo mal», «Me están ignorando» o «Esto es urgente». Pero el silencio, por sí solo, no explica por qué alguien no responde. Puede estar ocupado, lejos del móvil, pensando qué decir o no tener ganas de contestar todavía. Hasta saber más, intenta no tratar una explicación como si fuera un hecho."),
                H("Separa el hecho de la interpretación"),
                P("Por ejemplo, el mensaje aparece como leído, pero no hay respuesta. Los hechos son la confirmación de lectura y la hora. Pensar «la relación se ha acabado» es una interpretación posible, no una prueba. Nombra otras dos posibilidades, incluida una neutra. No tienes que convencerte de que todo va bien; basta con reconocer que aún tienes poca información."),
                H("Comprueba si hace falta actuar ahora"),
                P("¿Hay un plazo, una cuestión de seguridad o una consecuencia que no pueda esperar? Si es así, no dependas solo del chat: usa otro canal adecuado, contacta con alguien que pueda ayudarte o, si existe un peligro inmediato, con los servicios locales de emergencia. Si no es urgente, decide cuándo volverás a mirar. No hay un tiempo de espera universal: ten en cuenta la situación y los acuerdos que hayáis hecho."),
                H("Un plan en vez de comprobar una y otra vez"),
                List(
                    "Di lo que sabes sin sacar conclusiones: «Todavía no hay respuesta».",
                    "Pregúntate qué información necesitas realmente y si puedes conseguirla de otra forma.",
                    "Elige cuándo mirarás de nuevo y aparta el chat hasta entonces.",
                    "Haz una tarea breve que no dependa de recibir una notificación."),
                P("Si la respuesta es importante y ya ha pasado el plazo acordado, puedes enviar un único mensaje breve y sin reproches: «¿Puedes decirme si podrás responder hoy? Si no, buscaré otra opción». Así expresas lo que necesitas y dejas espacio para una respuesta sincera."),
                H("Si ocurre con frecuencia"),
                P("Fíjate en el patrón, no en una sola pausa. En un momento tranquilo podéis hablar de qué plazos de respuesta son importantes para cada uno y qué hacer cuando alguien no está disponible. Puedes decidir con la información que tienes. El silencio de otra persona no mide tu valor, y una explicación neutral no te obliga a esperar indefinidamente.")
            ]),
        new(
            ArticleIds.AfterSocialEvent,
            "Después de un encuentro: no repases cada frase",
            "Reflexiona sin convertir la conversación en una crítica hacia ti",
            "TipsAndUpdates",
            2,
            [
                P("Después de una reunión importante, la conversación puede volver una y otra vez a la mente. Es fácil fijarse en las pausas, las frases incómodas o la expresión de alguien y concluir que todo salió mal. Pero la memoria no es una grabación completa: el cansancio, la ansiedad y lo que ahora parece importante influyen en lo que recuerdas."),
                H("Separa lo observado de lo que interpretas"),
                P("Anota un momento concreto: ¿qué dijiste o hiciste realmente? Después escribe aparte la conclusión sobre ti, como «soy aburrido» o «se decepcionaron». Eso es una interpretación. ¿Qué otras explicaciones caben? Quizá la conversación terminó pronto, la otra persona tenía prisa o el tema era difícil. No tienes que elegir la explicación más positiva; basta con no tratar la versión ansiosa como si estuviera demostrada."),
                H("¿Hace falta dar algún paso?"),
                P("Comprueba si hay una promesa concreta, una pregunta o un error que realmente debas atender. Si lo hay, apunta qué harás y cuándo volverás al asunto: por ejemplo, aclarar un detalle mañana. Si no hay un paso así, repetir la escena probablemente no aporte información. Puedes decirte: «Ya he revisado lo que podía; todavía no hay datos nuevos»."),
                H("Una forma breve de cerrar el encuentro"),
                List(
                    "Nombra un momento neutro o agradable sin juzgarte por completo.",
                    "Si tienes una pregunta, guárdala para aclararla con calma.",
                    "Elige una transición al presente: agua, silencio, un paseo o una tarea pequeña.",
                    "Si vuelve el pensamiento, reconócelo y deja el repaso para el momento que elegiste."),
                P("El objetivo no es demostrar que el encuentro fue perfecto. Basta con decidir si queda una acción útil y permitir que lo demás siga siendo incierto. Si estas preocupaciones afectan a menudo a tus relaciones o al descanso, puedes hablarlo con un profesional."),
            ]),
        new(
            ArticleIds.FearOfMistakes,
            "Un error no es una sentencia",
            "Define qué significa suficientemente bien",
            "TipsAndUpdates",
            2,
            [
                P("El miedo a equivocarse puede convertir una tarea normal en un examen: revisar todo varias veces, esperar a tener plena seguridad o aplazar el comienzo. No se trata de restar importancia a los errores. Puede ayudar decidir de antemano qué importa, qué riesgo hay que comprobar y dónde está un punto razonable para parar."),
                H("Define de antemano qué es suficiente"),
                P("Describe el resultado de forma observable: enviar un mensaje con los datos necesarios, preparar un borrador o cumplir los requisitos esenciales. Después pregúntate qué consecuencia real tendría un error y qué comprobación reduciría ese riesgo. En temas de seguridad, salud, dinero o documentos importantes pueden aplicarse normas específicas y revisiones cuidadosas; el criterio de «suficientemente bien» no las sustituye."),
                H("Si el error ya ocurrió"),
                P("Separa el hecho de la valoración sobre ti. En vez de «lo he estropeado todo», nombra lo ocurrido: «el archivo tiene una fecha incorrecta». Averigua a quién afecta, si se puede corregir y a quién hay que avisar. Hacerse responsable significa dar un paso útil para reparar, no castigarse sin fin."),
                H("Un repaso breve sin atacarte"),
                List(
                    "¿Qué ocurrió, descrito como hechos?",
                    "¿Cuál es el impacto real y qué sigo suponiendo?",
                    "¿Qué paso puede corregir o limitar el efecto?",
                    "¿Qué puedo ajustar la próxima vez sin exigirme ser infalible?"),
                P("Si el miedo a equivocarte dificulta de forma habitual el trabajo, los estudios o las relaciones, puedes hablarlo con un profesional. No significa que haya algo mal en ti; puede servir para encontrar un apoyo adecuado."),
            ]),
        new(
            ArticleIds.ChangeAnxiety,
            "Cuando los cambios inquietan",
            "Separa lo conocido, lo incierto y lo que puedes influir",
            "TipsAndUpdates",
            2,
            [
                P("Un cambio puede inquietar incluso si lo deseas: cambia la rutina y el resultado no está claro. Planear todas las posibilidades agota sin hacer previsible el futuro. Separa lo que puedes hacer hoy de las preguntas que aún no tienen respuesta."),
                H("Usa tres columnas"),
                P("Anota qué sabes, qué no sabes y qué puedes influir. Por ejemplo, la fecha de una mudanza puede estar decidida, la ruta no, y hoy puedes reunir documentos. Investiga una duda primero si su respuesta cambiaría tu próxima decisión."),
                H("Elige el paso más próximo"),
                P("¿Qué acción pequeña ayudaría en las próximas 24 horas: confirmar un plazo, preparar algo, hablar con alguien implicado o reservar tiempo para descansar? Si ahora no puedes actuar, fija un momento para volver al tema. No garantiza el resultado, pero evita cargar con la pregunta todo el día."),
                List(
                    "Nombra qué ha cambiado de hecho.",
                    "Elige una pregunta que afecte a una decisión.",
                    "Define una acción o cuándo volverás a comprobarlo.",
                    "Deja lo demás pendiente hasta tener nuevos datos."),
                P("Si el cambio implica peligro o consecuencias graves, confirma los hechos y busca ayuda adecuada."),
            ]),
        new(
            ArticleIds.WorryBeforeTask,
            "Antes de una tarea difícil",
            "Empieza con un paso seguro y acotado",
            "TipsAndUpdates",
            2,
            [
                P("Antes de una tarea importante, la ansiedad puede decirte que esperes a tener plena seguridad o un plan perfecto. La disposición no siempre aparece antes de empezar. Primero identifica qué la hace difícil: un resultado poco claro, demasiado volumen, falta de información, la posibilidad de equivocarte o una conversación."),
                H("Elige la primera parte"),
                P("Escoge un paso seguro de 5 a 15 minutos: abrir un documento, reunir materiales, leer las instrucciones o hacer una pregunta para aclarar algo. Decide de antemano dónde pararás. Si necesitas permiso, conocimientos o el acuerdo de alguien, no lo adivines: anota a quién puedes preguntar."),
                H("Revisa el plan, no tu valor"),
                P("Después del primer paso, comprueba qué está más claro y qué sigue siendo una incógnita. Puedes continuar, hacer una pausa o cambiar el plan. Parar en el punto previsto también es respetar el acuerdo contigo. Si la tarea sigue siendo demasiado grande, divídela más o pide apoyo en vez de atribuir la dificultad a falta de voluntad.")
            ]),
        new(
            ArticleIds.AvoidedFirstStep,
            "Da solo el primer paso",
            "Empezar puede llevar dos minutos",
            "TipsAndUpdates",
            2,
            [
                P("Cuando una tarea parece grande o poco clara, es fácil evitarla entera. No siempre es pereza: quizá no sabes por dónde empezar, tienes poca energía o equivocarte parece demasiado costoso. No necesitas prometerte que lo terminarás todo. Haz que el comienzo sea visible y limitado."),
                H("Convierte el objetivo en una acción"),
                P("«Ponerme con el informe» no indica qué hacer ahora. «Abrir el archivo y anotar tres preguntas» sí. Un buen primer paso es breve, concreto y posible en este momento. Si todavía te bloquea, hazlo más pequeño: abrir el documento, encontrar la página o escribir un título."),
                H("Quita un obstáculo"),
                P("Observa qué estorba más: no encontrar un archivo, tener demasiados materiales, no saber cuándo estará terminado o las distracciones del móvil. Elimina solo una barrera. Organizar todo el proceso puede convertirse en otra manera de posponerlo."),
                H("Una prueba, no una promesa"),
                P("Pon un temporizador de cinco o diez minutos y permítete parar cuando suene. Después comprueba qué ha cambiado: ¿está más claro?, ¿tienes energía para seguir?, ¿necesitas información o ayuda? Parar según lo previsto también completa un paso."),
                H("Un plan para los próximos minutos"),
                List(
                    "Escribe el resultado deseado en una frase.",
                    "Elige una acción que puedas ver o comprobar.",
                    "Prepara una cosa necesaria y quita un obstáculo.",
                    "Después del inicio breve, decide si sigues, simplificas o pides ayuda."),
                P("Si incluso las tareas pequeñas siguen pareciendo inabordables durante mucho tiempo y esto afecta a tu día a día, habla con alguien de confianza o con un profesional sobre la carga y los apoyos disponibles."),
            ]),
        new(
            ArticleIds.CheckingLoop,
            "Comprueba y detente",
            "Define el objetivo sin omitir las medidas de seguridad necesarias",
            "TipsAndUpdates",
            2,
            [
                P("Comprobar repetidamente puede aliviar la inquietud un momento y después vuelve la duda: «¿Y si se me pasó algo?». Algunas comprobaciones son obligatorias. No se trata de dejar de revisar todo, sino de distinguir una revisión necesaria de repetirla sin motivos nuevos."),
                H("Antes de comprobar"),
                P("Antes, define qué necesitas confirmar, qué fuente es fiable y qué significará que has terminado. Para un billete, quizá baste con comparar fecha y destino con el documento oficial. Si una norma exige una segunda revisión, síguela: un límite personal no sustituye un procedimiento obligatorio."),
                H("Si vuelve la duda"),
                P("Si vuelve la duda, pregunta si cambiaron las circunstancias, hay datos nuevos o existe un requisito distinto. Si es así, revisa esa parte. Si no, anota que comprobaste según la regla elegida y sigue con otra cosa. No hace falta esperar a sentir calma total."),
                H("Una comprobación con límites claros"),
                List(
                    "Nombra el objetivo.",
                    "Elige una fuente fiable y el número de revisiones necesario.",
                    "Marca la tarea como terminada.",
                    "Vuelve a comprobar si aparecen datos o requisitos de seguridad nuevos."),
                P("Si las comprobaciones ocupan mucho tiempo o limitan tu vida, busca apoyo profesional. No omitas controles necesarios para la seguridad.")
            ]),
        new(
            ArticleIds.PublicPlaceAnxiety,
            "Ansiedad en un lugar concurrido",
            "Reduce la carga y conserva la posibilidad de elegir",
            "TipsAndUpdates",
            2,
            [
                P("El ruido, la cercanía, la espera o sentir que no puedes salir pueden aumentar la ansiedad. No tienes que obligarte a aguantar ni considerar que irte es fracasar. Primero observa la situación y elige un paso adecuado."),
                H("Encuentra un apoyo disponible"),
                P("Si puedes, ve a un lugar más tranquilo y localiza la salida. Puedes nombrar objetos o notar los pies en el suelo. Son opciones, no un ritual; omite la atención al cuerpo si te resulta incómoda."),
                H("Decide qué hacer ahora"),
                P("Pregúntate si cambiar de lugar o ritmo te permitiría quedarte. ¿Ayudaría una pausa, aplazar el plan o llamar a alguien? Elige un paso en vez de exigirte calma inmediata. Si hay peligro, pide ayuda para llegar a un sitio seguro."),
                H("Un plan breve"),
                List(
                    "Busca un sitio seguro y localiza la salida.",
                    "Reduce un estímulo si puedes.",
                    "Elige quedarte, pausar, salir o pedir apoyo.",
                    "Deja un ejercicio si aumenta el malestar."),
                P("Si estas situaciones interfieren a menudo con tu vida, háblalo con un profesional. Ante un peligro inmediato, contacta con emergencias.")
            ]),
        new(
            ArticleIds.MorningWorry,
            "Una mañana sin lista de preocupaciones",
            "Elige la prioridad de hoy y asigna un momento al resto",
            "TipsAndUpdates",
            2,
            [
                P("Por la mañana, todas las tareas pendientes pueden parecer urgentes. Repasar mentalmente la semana entera aumenta la carga y dificulta ver qué requiere atención hoy. Un plan breve ayuda a elegir el siguiente paso en vez de intentar controlarlo todo."),
                H("Separa lo urgente de lo importante"),
                P("Anota lo que te preocupa y marca una tarea con plazo o consecuencia real para hoy. Elige el primer paso y una hora. Si depende de otra persona, apunta a quién preguntar o qué apoyo pedir. Pasa el resto a un momento concreto."),
                H("Comprueba necesidades básicas"),
                P("Antes de exigirte rendir mucho, piensa qué facilitaría empezar: agua, comida, medicación prescrita, calma o ropa cómoda. Reduce el plan si cambia tu salud o situación."),
                H("Un plan para unos minutos"),
                List(
                    "¿Qué requiere realmente una acción hoy?",
                    "¿Cuál es el paso más pequeño?",
                    "¿Cuándo volveré a las otras cuestiones?",
                    "¿Qué me ayudaría físicamente ahora?"),
                P("Si la preocupación matutina altera a menudo tus actividades o el sueño, háblalo con un profesional.")
            ]),
        new(
            ArticleIds.SensoryOverload,
            "Cuando hay demasiados sonidos y tareas",
            "Reduce estímulos y recupera opciones",
            "TipsAndUpdates",
            2,
            [
                P("Las conversaciones, avisos, pantallas brillantes y peticiones simultáneas pueden sobrecargar la atención. Puede costar seguir lo que dicen o continuar una actividad habitual. Es una señal de carga, no de falta de esfuerzo. Empieza por un cambio posible."),
                H("Reduce una fuente de carga"),
                P("Ve a un lugar más tranquilo, silencia un aviso no esencial, baja el brillo o pide que hablen de uno en uno. Si no puedes salir, reduce tareas y pide que repitan una instrucción. Elige cambios seguros y realistas."),
                H("Conserva la opción de parar"),
                P("Si respirar de cierta forma, cerrar los ojos o centrarte en el cuerpo aumenta el malestar, para y elige un punto externo o una pausa. Puedes decir: «Necesito menos ruido; responderé después». No tienes que explicar más."),
                H("Plan para reducir estímulos"),
                List(
                    "Observa qué te afecta más.",
                    "Cambia un factor: sonido, luz, ritmo o distancia.",
                    "Aplaza una decisión no esencial.",
                    "Pide ayuda si no puedes salir o parar por tu cuenta."),
                P("Si aparece de repente con síntomas intensos o no puedes mantenerte a salvo, busca ayuda.")
            ]),
        new(
            ArticleIds.EveningTension,
            "Termina el día con suavidad",
            "Anota lo pendiente sin seguir planificando toda la noche",
            "TipsAndUpdates",
            2,
            [
                P("Por la noche, las tareas pendientes pueden parecer una prueba de que el día no fue suficiente. Intentar resolverlo todo mentalmente antes de dormir puede alargar la jornada. Una nota breve y una transición clara ayudan a dejar las tareas por ahora."),
                H("Cierra los asuntos abiertos"),
                P("Anota qué está hecho, qué necesita realmente un siguiente paso y qué puede esperar. Para una tarea importante, escribe el primer paso concreto para mañana y una hora aproximada. Si debes hablar de un plazo o pedir ayuda, apunta a quién y cuándo. No hace falta planificar toda la semana."),
                H("Elige una señal de cierre"),
                P("Guarda la nota y cierra la lista. Después elige una acción sencilla para marcar el final del día: bajar la luz, guardar los materiales, asearte o sentarte en silencio. No garantiza dormir, pero ayuda a no seguir resolviendo tareas en la cama."),
                H("Tres notas para la noche"),
                List(
                    "¿Qué he hecho ya hoy?",
                    "¿Qué tarea necesita un siguiente paso?",
                    "¿Qué puede esperar al momento previsto?"),
                P("Si la preocupación interfiere habitualmente con el sueño, consulta con un profesional sanitario.")
            ]),
        new(
            ArticleIds.AnxietyComedown,
            "Después de un pico de ansiedad",
            "Recupera seguridad y apoyo antes de decidir si analizarlo",
            "TipsAndUpdates",
            2,
            [
                P("Después de una ansiedad intensa quizá quieras entender enseguida la causa y evitar que vuelva. Pero analizarlo estando agotado puede añadir carga. Primero comprueba que estás a salvo y date tiempo para recuperar tu ritmo habitual."),
                H("Vuelve a condiciones sencillas"),
                P("Si estás a salvo, elige algo familiar y poco exigente: sentarte, beber agua, comer, abrigarte o ir a un lugar tranquilo. No tienes que hacer un ejercicio de respiración ni cerrar los ojos. Deja cualquier cosa que aumente el malestar y prueba otra opción."),
                H("Analiza solo lo que pueda ayudar"),
                P("Más tarde, cuando te resulte más fácil concentrarte, anota qué ocurría, qué ayudó aunque fuera un poco y si queda una cuestión práctica para otra ocasión. No tienes que encontrar una única causa ni culparte. Si hace falta actuar, escribe el siguiente paso o con quién hablarlo."),
                H("Una recuperación gradual"),
                List(
                    "Comprueba que estás en un lugar seguro.",
                    "Elige una necesidad sencilla o una actividad conocida.",
                    "Aplaza el análisis si añade tensión.",
                    "Vuelve poco a poco a las tareas habituales."),
                P("Si estos episodios se repiten, afectan mucho a tu vida o incluyen síntomas intensos, busca ayuda profesional.")
            ]),
        new(
            ArticleIds.SafePractice,
            "La práctica no es un examen",
            "Puedes adaptar el ejercicio o parar y conservar el control",
            "TipsAndUpdates",
            2,
            [
                P("Una práctica solo es útil si encaja contigo en ese momento. Completar todos los pasos a cualquier precio no es el objetivo. Puedes cambiar el ritmo, omitir una parte o terminar."),
                H("Conserva opciones antes de empezar"),
                P("Decide cómo pararás y hacia dónde llevarás la atención. Puedes mantener los ojos abiertos, acortar el tiempo, cambiar de postura o elegir un punto externo. Los ejercicios de respiración y atención corporal no sirven a todo el mundo; elige algo que no aumente el malestar."),
                H("Si aparece incomodidad"),
                P("Detente, vuelve a tu respiración natural y mira alrededor. Si es seguro, cambia de postura o pasa a una actividad sencilla y conocida. No tienes que aguantar para terminar. Si el malestar persiste o aumenta, pide apoyo."),
                H("Comprueba antes de practicar"),
                List(
                    "¿Este ejercicio me encaja ahora?",
                    "¿Cómo sabré que debo parar?",
                    "¿Qué haré en su lugar si me incomoda?"),
                P("La práctica no sustituye la ayuda profesional ni la asistencia urgente ante un peligro inmediato.")
            ]),

        new(
            ArticleIds.ThoughtLabel,
            "Ponle nombre al pensamiento",
            "Obsérvalo sin discutir con él",
            "TipsAndUpdates",
            2,
            [
                P("Un pensamiento puede parecer muy convincente, sobre todo cuando estás cansado o con ansiedad. Prueba a anteponer: «Estoy notando el pensamiento de que…». No demuestra que sea falso; separa un evento mental de un hecho comprobado y puede dejar un pequeño espacio para elegir qué hacer."),
                H("Comprueba qué sabes"),
                P("Anota brevemente qué ocurrió y qué interpretaste. Pregúntate: «¿Qué observé directamente? ¿Qué sigue siendo una interpretación?». No hace falta analizar cada pensamiento ni convencerte de lo contrario. Si se refiere a una decisión importante, busca solo información que pueda cambiar de verdad el siguiente paso."),
                H("Vuelve a una acción elegida"),
                P("Elige una acción pequeña relacionada con tu tarea o tus valores: abrir un documento, hacer una pregunta o parar un momento. El pensamiento puede seguir ahí; no tienes que eliminarlo antes. Si el ejercicio aumenta tu malestar, detente y elige un apoyo que te resulte más adecuado.")
            ]),
        new(
            ArticleIds.MindReading,
            "No adivines lo que piensan los demás",
            "Separa lo que observaste de lo que supones",
            "TipsAndUpdates",
            2,
            [
                P("Cuando alguien guarda silencio o responde brevemente, la mente puede completar la historia: «Está enfadado» o «Lo he estropeado». Son posibilidades, pero no las únicas. Ayuda separar lo que realmente viste u oíste del significado que le atribuiste."),
                H("Acláralo si merece la pena"),
                P("Si la relación y la pregunta importan, pregunta con calma y de forma concreta: «¿He entendido bien que…?» o «¿Cuándo te vendría bien hablar?». No exijas una respuesta inmediata si la otra persona está ocupada. Si aclararlo ahora no aporta, reconoce la duda y espera a tener más información."),
                H("No conviertas una suposición en sentencia"),
                P("Mantén abiertas varias explicaciones: quizá la persona está ocupada, cansada o no ha visto el mensaje. Ninguna tiene por qué ser la correcta. El objetivo no es sustituir una certeza por otra, sino no tratar una suposición como prueba. Después decide si hace falta un paso concreto o puedes volver a tus asuntos.")
            ]),
        new(
            ArticleIds.WorstVsLikely,
            "Lo peor no es lo más probable",
            "Prepárate sin vivirlo por adelantado",
            "TipsAndUpdates",
            2,
            [
                P("La ansiedad puede presentar el resultado más difícil como si ya estuviera a punto de ocurrir. En vez de discutir contigo, considera tres opciones: un resultado difícil, uno favorable y el más plausible según los datos disponibles. No es una predicción ni una promesa de que todo saldrá bien; permite incluir más de una posibilidad."),
                H("Distingue prepararte de darle vueltas"),
                P("Para el resultado más plausible, elige un paso útil. Si el peor resultado tendría consecuencias serias, prepara un plan breve y razonable: qué harías y a quién acudirías. No necesitas planear en detalle cada escenario imaginado. Pregúntate qué información nueva cambiaría tu valoración y busca solo esa información."),
                H("Deja abierta la incertidumbre"),
                P("Si te ayuda, anota un dato a favor y otro en contra de cada opción. Si aún no hay datos, escribe «no lo sé». Después vuelve a algo que sí puedas hacer ahora. Ante un peligro real, actúa según los hechos y busca ayuda práctica; este ejercicio no la sustituye.")
            ]),
        new(
            ArticleIds.EvidenceAndUnknown,
            "Lo que sé y lo que todavía no",
            "No llenes un vacío con una suposición ansiosa",
            "TipsAndUpdates",
            2,
            [
                P("Cuando falta una respuesta, una explicación ansiosa puede parecer un hecho. Separar lo que sabes de lo que desconoces no elimina la incertidumbre, pero ayuda a no tomar decisiones basadas en una suposición. Anota los hechos por un lado y las preguntas abiertas por otro."),
                H("Pregunta qué puedes averiguar"),
                P("Para cada duda, decide dónde obtener información fiable, a quién preguntar o cuándo volver a revisarla. Busca solo lo que pueda cambiar una acción. Comprobar una y otra vez la misma fuente no suele aportar datos nuevos."),
                H("Deja abierta la pregunta abierta"),
                P("Si ahora no hay respuesta, escribe «aún no lo sé». Elige cuándo comprobarlo de nuevo o deja la pregunta para más adelante. Después vuelve a algo que sí esté a tu alcance. La incertidumbre puede incomodar, pero no siempre hace falta resolverla de inmediato.")
            ]),
        new(
            ArticleIds.NegativityFilter,
            "Fíjate en algo más que lo que salió mal",
            "Añade otro dato a la imagen",
            "TipsAndUpdates",
            2,
            [
                P("Después de un momento difícil, la atención puede quedarse en los errores y pasar por alto lo neutral o útil. Esto no significa que debas presentar la situación de forma más positiva. Se trata de comprobar si una parte de la historia se ha convertido en toda la historia."),
                H("Recupera algo de contexto"),
                P("Nombra qué salió mal y añade otro dato relevante: qué hiciste, qué transcurrió con normalidad, quién te ayudó o qué aprendiste. Un detalle neutral también cuenta. No tienes que buscar elogios si ahora no te encajan."),
                H("Usa la imagen completa para el siguiente paso"),
                P("Pregúntate si el dato añadido cambia lo que necesitas hacer. Si sí, elige una acción. Si no, puedes reconocer la dificultad sin emitir un juicio sobre toda tu persona. Un momento bueno no borra uno difícil, pero puede hacer la valoración más precisa.")
            ]),
        new(
            ArticleIds.ConversationReplay,
            "Deja de repetir la conversación sin parar",
            "Comprueba si hay datos nuevos o una acción",
            "TipsAndUpdates",
            2,
            [
                P("Después de hablar con alguien, es fácil repasar cada frase e imaginar qué pensó. Un repaso breve puede servir si aporta claridad o permite reparar algo. Repetirlo sin datos nuevos suele agotarte."),
                H("Separa la conclusión del siguiente paso"),
                P("Anota un hecho, compromiso o pregunta concreta que realmente necesite respuesta. Si quieres aclarar o corregir algo, elige un mensaje breve y un momento adecuado. No necesitas enviar varios mensajes para alcanzar una certeza absoluta."),
                H("Si no hay nada nuevo, haz una pausa"),
                P("Ponle nombre: «Estoy repitiendo la conversación, pero no tengo datos nuevos». Pasa a una actividad que te devuelva al presente. Si el asunto sigue siendo importante, fija un momento para decidir con calma si hace falta hablarlo. No tienes que decidirlo ahora.")
            ]),
        new(
            ArticleIds.DecisionFatigue,
            "Simplifica una decisión pequeña",
            "Decide de antemano qué es suficiente",
            "TipsAndUpdates",
            2,
            [
                P("Las decisiones pequeñas se acumulan, sobre todo cuando cada una exige comparar desde cero. Para las elecciones repetidas puede servir una regla previa: tiempo, presupuesto o calidad. Esto no significa apresurarse con decisiones importantes; puedes reservarles un momento aparte y valorarlas con calma."),
                H("Reduce el número de opciones"),
                P("Para una decisión que puedas revisar fácilmente, conserva dos opciones aceptables y compáralas con un criterio. Por ejemplo: ¿cuál será más fácil de mantener esta semana? Limitar opciones protege tu atención; no pretende encontrar una respuesta perfecta."),
                H("Reconsidera solo si algo cambia"),
                P("Anota la opción elegida y qué te haría revisarla, como un cambio en las circunstancias o un dato importante. Si nada ha cambiado, prueba a seguir tu decisión. Si afecta a la seguridad, la salud o un compromiso importante, no sustituyas una comprobación necesaria por una regla rápida.")
            ]),
        new(
            ArticleIds.GoodEnough,
            "Suficientemente bien también es un resultado",
            "Limita los retoques innecesarios",
            "TipsAndUpdates",
            2,
            [
                P("Cuando una tarea importa, es comprensible querer revisarla otra vez. Sin un punto final, las correcciones pueden continuar aunque el resultado ya sirva. Antes de empezar, define qué debe cumplir y cuándo vas a parar."),
                H("Fija una línea de llegada"),
                P("Elige dos o tres requisitos observables y cómo comprobarlos. Por ejemplo, un correo debe expresar la petición, incluir la fecha correcta y pasar una revisión de erratas evidentes. Después, guárdalo o envíalo. Los criterios deben encajar con la tarea, sin exigir perfección en todo."),
                H("Vuelve solo por una razón concreta"),
                P("Querer comprobar de nuevo no demuestra que exista un error. Reabre el trabajo si encuentras un problema específico, recibes información nueva o hace falta un cambio obligatorio. Así puedes distinguir una corrección útil de retocar sin fin buscando una seguridad imposible.")
            ]),
        new(
            ArticleIds.ControlInfluence,
            "Lo que puedo influir y lo que no",
            "Enfócate en una acción disponible",
            "TipsAndUpdates",
            2,
            [
                P("Cuando una situación también depende de otras personas o de las circunstancias, intentar controlarlo todo puede agotarte. Separar lo que está en tu mano no vuelve justa la situación ni elimina las limitaciones reales, pero ayuda a decidir dónde poner energía."),
                H("Encuentra tu margen de acción"),
                P("Pregúntate: ¿qué puedo decir, preparar, pedir o decidir? Elige un paso concreto. Para lo que queda fuera, piensa en un límite, apoyo o momento para volver a comprobar. A veces, el paso posible es negarte, pedir ayuda o comunicar un problema."),
                H("No cargues con la responsabilidad ajena"),
                P("Puedes formular una petición clara, pero no garantizar la respuesta. Observa dónde termina tu parte y no conviertas la decisión de otra persona en una medida de tu valor. Si hay un peligro real o una vulneración de derechos, busca apoyo práctico; no basta con cambiar de perspectiva.")
            ]),
        new(
            ArticleIds.SelfTalkReset,
            "Cambia el tono de tu diálogo interno",
            "Háblate con respeto y de forma concreta",
            "TipsAndUpdates",
            2,
            [
                P("A veces la autocrítica se disfraza de motivación: «si me exijo más, espabilaré». Pero insultarte no explica qué hacer después. Hablarte con respeto no significa justificar una conducta ni ignorar sus consecuencias. Ayuda a describir la situación con precisión y a conservar la posibilidad de actuar."),
                H("Cambia una etiqueta por un hecho observable"),
                P("Prueba a cambiar «soy irresponsable» por «no cumplí el plazo y todavía no he avisado al equipo». La primera frase juzga todo tu carácter; la segunda nombra un hecho y una acción que puedes abordar. Cuanto más concreta sea la descripción, más fácil será elegir el siguiente paso."),
                H("Una frase para un momento difícil"),
                P("Usa tres partes: qué ocurrió, a qué afectó y qué harás ahora. Por ejemplo: «Respondí de forma brusca, la conversación se tensó, así que volveré al tema y aclararé lo que quería decir». Si has hecho daño, reconocerlo e intentar repararlo importa más que hacer que la frase suene positiva."),
                H("Comprueba que haya honestidad y respeto"),
                List(
                    "Nombra el hecho sin «siempre» ni «nunca».",
                    "Reconoce una emoción o consecuencia sin tratarla como prueba de que eres un fracaso.",
                    "Elige un paso posible: reparar, aclarar, disculparte o pedir apoyo.",
                    "Háblate como hablarías a alguien querido, sin dejar de ser sincero."),
                P("No tienes que creer enseguida una frase nueva. Basta con que sea más precisa y útil. Si la autocrítica se vuelve constante o dolorosa, puede ayudar el apoyo profesional."),
            ]),
        new(
            ArticleIds.WorryAboutWorry,
            "Preocuparte por estar preocupado",
            "No te exijas calmarte enseguida",
            "TipsAndUpdates",
            2,
            [
                P("Al notar ansiedad puede aparecer un segundo pensamiento: «No debería reaccionar así». Eso puede añadir presión. La primera reacción ya está ahí; no tienes que reprochártela también. El objetivo no es forzarte a sentir calma, sino elegir una acción manejable mientras la ansiedad está presente."),
                H("Pon nombre a las dos reacciones"),
                P("Prueba a notar: «Siento ansiedad y ahora me preocupa sentir ansiedad». No hace falta discutir con ello ni encontrar las palabras perfectas. Después comprueba si hay una razón práctica para actuar: prepararte, pedir apoyo o resolver una cuestión concreta."),
                H("Mide el avance por el paso elegido"),
                P("Pregúntate qué querías hacer antes de que apareciera la ansiedad y elige una versión más pequeña. Después fíjate en la acción o la pausa, no en cuánto te has calmado. Si la ansiedad limita a menudo tu vida diaria, puedes hablarlo con un profesional.")
            ]),
        new(
            ArticleIds.CompareHighlightReel,
            "No compares tu vida con el escaparate de otra persona",
            "Una publicación muestra momentos elegidos, no una vida entera",
            "TipsAndUpdates",
            2,
            [
                P("Las publicaciones suelen enseñar un instante, no las preocupaciones, dudas y rutinas normales de alguien. Comparar tu día a día con los mejores momentos ajenos puede hacerte sentir que vas tarde. Esa sensación es real, pero no determina tu valor ni cuenta toda la historia."),
                H("Identifica qué estás echando de menos"),
                P("Cierra la publicación un momento y pregúntate qué te falta ahora: descanso, compañía, dinero, reconocimiento o tiempo para algo importante. No tienes que quitar importancia a ese deseo. Estás identificando una necesidad, no comprometiéndote a cambiar toda tu vida de inmediato."),
                H("Da un paso pequeño hacia tu propia vida"),
                P("Si puedes, haz algo concreto: escribe a alguien cercano, reserva un rato de descanso o vuelve a tu propio proyecto. Si ahora no puedes dar ese paso, simplemente reconócelo. El éxito de otra persona no elimina tus posibilidades; alejarte un rato de la pantalla puede ayudarte a recuperar tu ritmo.")
            ]),
        new(
            ArticleIds.IntrusiveThoughts,
            "Un pensamiento no deseado no es una intención",
            "Ten en cuenta las acciones, el contexto y la seguridad",
            "TipsAndUpdates",
            2,
            [
                P("A veces aparecen pensamientos perturbadores, aterradores o contrarios a tus valores. Tener un pensamiento no demuestra por sí solo que quieras llevarlo a cabo. No tienes que comprobar sin parar si eres una «buena persona» ni buscar una certeza completa una y otra vez."),
                H("Evita alimentar las comprobaciones"),
                P("Si estás a salvo, prueba a etiquetarlo brevemente como «un pensamiento no deseado», sin analizarlo repetidamente. Vuelve a una actividad cotidiana o a un punto externo de atención. Si está relacionado con una intención real, un plan o un riesgo inmediato para ti u otra persona, trátalo como una cuestión de seguridad: aléjate de los medios de daño y contacta urgentemente con alguien de confianza, un profesional o emergencias."),
                H("Busca apoyo si interfiere en tu vida"),
                P("Si estos pensamientos te asustan con frecuencia, consumen mucho tiempo o interfieren en tu vida diaria, coméntalo con un profesional de salud mental. Puedes explicar la frecuencia, el impacto y qué te ayuda, sin intentar diagnosticarte.")
            ]),
        new(
            ArticleIds.OneThingAtATime,
            "Una tarea cada vez",
            "Haz que el foco sea concreto y limitado",
            "TipsAndUpdates",
            2,
            [
                P("Cambiar entre mensajes, pestañas y tareas puede dar sensación de actividad y, a la vez, dificultar que notes cuándo terminas algo. No hace falta concentrarse todo el día. Prueba un bloque corto con un resultado visible: revisar tres líneas, responder un correo o leer unas páginas."),
                H("Facilita la vuelta"),
                P("Antes de empezar, silencia solo los avisos y cierra solo las ventanas que suelen distraerte, si es posible. Ten cerca una nota de «después»: apunta las tareas nuevas en vez de cambiar enseguida. Si las interrupciones son inevitables, deja una indicación breve de dónde paraste y qué toca hacer después."),
                H("Cierra el bloque con intención"),
                P("Cuando suene el temporizador o alcances el resultado elegido, para un momento y decide si sigues, cambias de tarea o descansas. Si no lograste concentrarte, reduce el paso o comprueba si influyen el cansancio, el hambre o el entorno. No es una competición de productividad: es una forma de reducir el ruido mental y elegir con más claridad.")
            ]),

        new(
            ArticleIds.MoodMovement,
            "Un poco de movimiento cuando falta energía",
            "Prueba un paso suave sin exigirte animarte",
            "TipsAndUpdates",
            2,
            [
                P("Cuando falta energía, hasta un movimiento cotidiano puede parecer otra obligación. No necesitas convencerte de que un paseo breve mejorará el ánimo. Puedes comprobar qué acción te resulta posible y cómo te sienta. El objetivo no es entrenar, sino atender con cuidado a las necesidades del cuerpo."),
                H("Elige algo asumible"),
                P("Puedes estirarte sentado, acercarte a una ventana, cambiar de postura o salir unos minutos. Decide tú la duración y deja abierta la posibilidad de parar. Si tienes limitaciones de salud, sigue las recomendaciones médicas; el movimiento no debe doler ni exigirte forzarte."),
                H("Observa sin ponerte nota"),
                P("Después, pregúntate si algo resulta más cómodo, sigue igual o te cansa más. Cualquier respuesta es útil y no significa que hayas hecho algo mal. Si ahora necesitas descanso, elígelo. Si la falta de energía persiste o aparece de forma repentina, considera comentarlo con un profesional de salud.")
            ]),
        new(
            ArticleIds.PleasureMastery,
            "Disfrute y sensación de haber terminado",
            "Observa de qué distintas maneras puede ayudarte una actividad",
            "TipsAndUpdates",
            2,
            [
                P("Algunas actividades resultan agradables mientras las haces; otras dan sensación de cierre o te conectan con algo importante. Son experiencias distintas y ninguna tiene que aparecer después de cada tarea. Cuando estás cansado, puede ser más útil observar el efecto real que esperar una alegría inmediata."),
                H("Planifica sin sobrecargarte"),
                P("Elige una opción pequeña que encaje: para disfrutar, escuchar una canción o tomar un té; para cerrar algo, ordenar una superficie o responder un correo; para conectar, escribir brevemente a alguien de confianza. Basta con una. Ten en cuenta el tiempo, la energía, el acceso y tus ganas reales."),
                H("Revisa la experiencia con amabilidad"),
                P("Después, anota por separado si fue agradable y si sentiste «he terminado algo». Si nada cambió, no es un fracaso ni un motivo para obligarte a repetirlo. Quizá necesitas descanso, otro formato o un paso menor. Lo observado sirve para hacer planes más realistas, no para medir tu valor.")
            ]),
        new(
            ArticleIds.EnergyBudget,
            "Distribuye la energía, no solo el tiempo",
            "Reserva espacio para recuperarte junto a las obligaciones",
            "TipsAndUpdates",
            2,
            [
                P("Dos tareas de la misma duración pueden requerir esfuerzos muy distintos. Al planificar, cuenta también los desplazamientos, la preparación, la concentración y la carga emocional. Un horario sin transiciones ni pausas puede estar demasiado lleno aunque el calendario parezca libre."),
                H("Deja un margen"),
                P("Elige una tarea importante y, si tienes capacidad, otra pequeña. Entre las más exigentes, coloca una pausa sencilla o algo más ligero. No hace falta ocupar cada hueco. Si dependes de otras personas para organizarte, conserva una alternativa o pregunta qué tareas tienen prioridad."),
                H("Ajusta según lo que observes"),
                P("Al final del día, fíjate en qué tareas exigieron más energía de la prevista y si hubo tiempo suficiente para recuperarte. Usa esa información para el siguiente plan, no para criticarte. En un día imprevisible, reduce la lista a lo más importante y aplaza lo demás.")
            ]),
        new(
            ArticleIds.RestBreak,
            "Descansa sin sentir culpa",
            "El descanso puede ayudarte a elegir lo siguiente",
            "TipsAndUpdates",
            2,
            [
                P("Cuando hay mucho que hacer, el descanso puede parecer un premio que primero hay que ganarse. Sin embargo, una pausa puede ser una parte normal de gestionar el esfuerzo, no una señal de debilidad. No tiene que hacerte más productivo: puede darte un momento para notar cómo estás y decidir qué viene después."),
                H("Adapta la pausa al tipo de cansancio"),
                P("Si tienes cansados los ojos y la atención, quizá te ayuden unos minutos de silencio sin pantalla. Si el cuerpo está rígido, cambia de postura o estira suavemente si te resulta cómodo. Si te abruman los sonidos, busca un lugar más tranquilo. Tal vez encajen mejor beber agua, comer algo, salir al aire o hablar con alguien de confianza. No hay una fórmula universal: elige algo seguro y disponible."),
                H("No conviertas la pausa en otra tarea"),
                P("Elige una duración aproximada y una actividad sencilla: sentarte cinco minutos junto a la ventana o dar un paseo corto. No hace falta evaluar si estás descansando bien. Al terminar, puedes dar un paso, aplazar algo, pedir ayuda o parar por hoy."),
                H("Cuando nunca hay sitio para descansar"),
                P("El agotamiento persistente no siempre se soluciona con una planificación más estricta. Mira si puedes reducir, mover o dividir alguna tarea; hablar de plazos; o pedir apoyo. No todo depende únicamente de la disciplina personal."),
                H("Un plan amable para la pausa"),
                List(
                    "Observa qué está cansado: la atención, el cuerpo o las emociones.",
                    "Elige una pausa breve que encaje ahora.",
                    "Deja en suspenso una exigencia hacia ti mientras descansas.",
                    "Después decide qué necesita continuar de verdad."),
                P("Si el cansancio dura, interfiere con tus actividades cotidianas o te preocupa por tu salud, consulta a un profesional sanitario. Este artículo no sustituye una atención individual."),
            ]),
        new(
            ArticleIds.StartFriction,
            "Quita un obstáculo antes de empezar",
            "Prepara el siguiente paso, no todo el proceso",
            "TipsAndUpdates",
            2,
            [
                P("Cuando cuesta empezar, «organízate mejor» no siempre aclara qué lo impide. Quizá la tarea no está clara, cuesta encontrar el archivo, faltan materiales o el primer paso es demasiado grande. Elige un obstáculo concreto que puedas comprobar en vez de reorganizar todo el día."),
                H("Facilita la entrada"),
                P("Si no está claro el objetivo, anota una pregunta o pide que lo aclaren. Si falta preparación, abre el documento o deja el material a la vista. Si te distrae el móvil, apártalo durante un bloque corto cuando sea posible. No conviertas la preparación en otra tarea enorme."),
                H("Comprueba si ayudó"),
                P("Prueba a empezar después de cambiar una sola condición y observa si resulta más fácil. Si no, deshaz lo que no sirvió y comprueba otra causa posible. El obstáculo quizá dependa de otra persona: puede que necesites acceso, una decisión o ayuda. Entonces el siguiente paso es hacer una petición clara, no intentar resolverlo todo a solas.")
            ]),
        new(
            ArticleIds.TransitionRitual,
            "Haz una pausa al cambiar de tarea",
            "Anota lo pendiente y nombra el siguiente paso",
            "TipsAndUpdates",
            2,
            [
                P("Después de una interrupción puede costar recordar dónde lo dejaste, mientras lo pendiente sigue ocupando atención. Una transición breve ayuda a anotarlo y empezar lo siguiente con más calma. No es un ritual obligatorio ni una forma de trabajar sin descansos; es una ayuda opcional."),
                H("Cierra la tarea anterior"),
                P("Escribe en una línea qué has hecho y qué queda. Guarda el archivo o deja los materiales en un sitio fácil de encontrar. Si esperas una respuesta, anota de quién y cuándo volverás a comprobarlo. No hace falta ordenar todo el espacio."),
                H("Elige qué viene ahora"),
                P("Nombra la primera acción visible de la siguiente tarea y deja a un lado la anterior. La transición puede durar menos de un minuto: guardar, anotar, nombrar. Si la pausa aumenta la tensión o necesitas descansar, no te obligues a seguirla. Tras probarla unas veces, conserva solo lo que realmente te ayude.")
            ]),
        new(
            ArticleIds.TaskActivation,
            "Cuando cuesta empezar",
            "Une una acción mínima a una señal habitual",
            "TipsAndUpdates",
            2,
            [
                P("Esperar a tener motivación puede aplazar una tarea, pero no tienes que empezar por todo el trabajo. Elige una acción que simplemente la abra: abrir el documento, leer las instrucciones o escribir un título. Es un comienzo, no una promesa de terminarlo todo."),
                H("Usa una señal clara"),
                P("Vincula la acción a un momento cotidiano: «Después de desayunar, abriré el archivo y miraré la primera línea». Decide dónde y cuándo, y quita antes un obstáculo. Si se te pasa ese momento, elige otro; un comienzo perdido no invalida el plan."),
                H("Decide después de empezar"),
                P("Tras ese pequeño paso, observa tus fuerzas y decide si continúas un poco, haces una pausa o paras. Cuenta haber empezado, no cuánto terminaste. A veces la dificultad indica que la tarea no está clara, es demasiado grande o hace falta apoyo. Si afecta a menudo a tu vida diaria, puedes comentarlo con un profesional adecuado.")
            ]),
        new(
            ArticleIds.GentleRoutine,
            "Una rutina flexible, no perfecta",
            "Conserva un punto estable, no un horario rígido",
            "TipsAndUpdates",
            2,
            [
                P("Una rutina puede aliviarte al evitar que tengas que decidirlo todo cada día. Pero un horario detallado puede convertirse en motivo de culpa cuando algo cambia. Elige un punto repetible —por ejemplo, planear después del desayuno— y deja que el resto del día sea flexible."),
                H("Haz que el hábito sea adaptable"),
                P("Vincula la acción a un momento, no solo a una hora: abrir las cortinas al levantarte o revisar un mensaje después de comer. Prepara una versión sencilla para un día difícil: respirar una vez junto a la ventana en vez de salir a caminar, o anotar una prioridad en vez de hacer una lista completa. El mínimo debe ser realmente posible."),
                H("Vuelve sin castigarte"),
                P("Si un día no lo haces, retómalo en la siguiente ocasión adecuada; no necesitas recuperar lo perdido. Si ya no te ayuda o se ha vuelto una carga, cámbialo o déjalo. La rutina debe adaptarse a tu vida y necesidades, no convertirse en un examen de disciplina.")
            ]),
        new(
            ArticleIds.WakeAtNight,
            "Si te despiertas durante la noche",
            "Reduce la presión y deja que el sueño vuelva a su ritmo",
            "TipsAndUpdates",
            2,
            [
                P("Despertarte de noche no significa que el resto de la noche esté perdido. Mirar la hora repetidamente y contar las horas puede añadir presión. Si puedes, evita mirar el reloj y no te exijas dormirte de inmediato. Procura que el entorno sea tan tranquilo y seguro como te resulte posible."),
                H("Elige una actividad tranquila"),
                P("Si estar en la cama resulta desagradable y no vuelve el sueño, puedes levantarte un rato y hacer algo tranquilo con luz tenue. Vuelve cuando tengas sueño. No tienes que seguir una recomendación que te incomode: ten en cuenta la seguridad, cómo te encuentras y las indicaciones de tu profesional de salud."),
                H("Deja para mañana las preocupaciones de mañana"),
                P("Si se repiten los pensamientos sobre tareas, anota una tarea o una pregunta y déjala para la mañana. Al levantarte, mantén tu rutina habitual en la medida de lo posible, sin imponerte demasiado para compensar la noche. Si los problemas de sueño afectan de manera persistente a tu bienestar o vida diaria, coméntalo con un profesional sanitario.")
            ]),
        new(
            ArticleIds.SmallDayPlan,
            "Un plan diario con margen",
            "Elige lo importante y deja espacio para la vida",
            "TipsAndUpdates",
            2,
            [
                P("Un plan orienta cuando tiene en cuenta tu energía real y deja sitio a los imprevistos. Una lista larga no suele mostrar cuánto tiempo ocupan los desplazamientos, las transiciones y el descanso. Empieza por preguntar: ¿qué es realmente importante hoy y qué puede esperar sin consecuencias graves?"),
                H("Haz un plan breve"),
                P("Anota una tarea principal, un pequeño paso cotidiano y una pausa para comer o recuperarte. Deja un intervalo libre entre ellos. Si una tarea es vaga, define un resultado visible: no «ocuparme de los papeles», sino «encontrar el formulario que necesito». Guarda lo demás en otra lista."),
                H("Revisa el plan durante el día"),
                P("Si cambian las circunstancias o baja tu energía, ajusta el plan: reduce un paso, aplaza una tarea o pide ayuda. Al final, pregúntate si el plan te orientó, no cuántas casillas marcaste. Es un apoyo que puedes cambiar, no una promesa de hacerlo todo.")
            ]),
        MiniArticle(ArticleIds.AskForHelpTask, "Pide ayuda con una parte concreta", "Una petición clara deja menos lugar a las suposiciones", "Di qué resultado necesitas, qué parte y para cuándo; por ejemplo: «¿Puedes revisar estas dos páginas antes del almuerzo?» Explica qué está hecho y cuánto tiempo puede llevar. Pregunta si ese volumen le viene bien. Si no, propone una parte menor, otro plazo o pregunta quién más podría ayudar."),
        MiniArticle(ArticleIds.MeaningfulActivity, "Una actividad que te importa", "Conecta un paso pequeño con un valor", "Pregúntate qué importa aquí: cuidar, tener curiosidad, cumplir o descansar. Elige una acción pequeña en esa dirección. No necesita cambiar toda la situación para tener sentido. El sentido también puede estar en cuidar de tu yo futuro."),
        MiniArticle(ArticleIds.FlexibleGoals, "Cambia el plan sin abandonar el objetivo", "Adapta el paso a la energía de hoy", "Si el plan original es demasiado grande, decide qué importa más: el objetivo, el plazo o el método. Conserva un siguiente paso manejable; por ejemplo, prepara un borrador en vez de buscar la perfección, o trabaja diez minutos en lugar de una hora. Si el plazo ya no es realista, avisa a quienes afecta y propone una nueva fecha. Revisar el plan responde a las condiciones actuales; no significa renunciar al objetivo."),
        MiniArticle(ArticleIds.CelebrateCompletion, "Reconoce lo que ya hiciste", "La mente suele saltar a la siguiente tarea", "Al terminar, nombra brevemente qué hiciste y cuánto esfuerzo te llevó. No necesitas una recompensa; basta con reconocerlo. Así ves también lo terminado, no solo lo pendiente. Si te ayuda, anota qué facilitó terminar: el momento, el apoyo o una pausa."),

        new(
            ArticleIds.NameEmotion,
            "Pon un nombre más preciso a lo que sientes",
            "Puede ayudarte a ver qué apoyo necesitas",
            "TipsAndUpdates",
            2,
            [
                P("«Me siento mal» transmite que algo cuesta, pero no siempre indica qué podría ayudar. Si puedes, añade un matiz: preocupación, soledad, irritación, vergüenza, dolor o cansancio. No necesitas encontrar la palabra perfecta ni explicárselo a nadie."),
                H("Separa la emoción de la situación"),
                P("Pregúntate: ¿qué ha pasado, qué siento ahora y qué me importa? El enfado puede convivir con el agotamiento; la ansiedad, con la falta de información. Anota lo que observas sin convertirlo en un juicio sobre ti o sobre las intenciones de otra persona. Si no encuentras una palabra, empieza por lo que notas en el cuerpo o alrededor."),
                H("Elige una respuesta pequeña"),
                P("Piensa si necesitas una pausa, más claridad, contactar con alguien de confianza o ir a un lugar más seguro. Poner nombre a una emoción no obliga a actuar de inmediato bajo su influencia. A veces basta con reconocerla y aplazar una decisión. Si el malestar es insoportable o no puedes mantenerte a salvo, pide ayuda urgente.")
            ]),
        new(
            ArticleIds.MixedFeelings,
            "Puedes sentir dos cosas distintas a la vez",
            "Las reacciones contradictorias pueden coexistir",
            "TipsAndUpdates",
            2,
            [
                P("Los cambios, las relaciones cercanas y las decisiones rara vez provocan una sola reacción. Puedes ilusionarte por una oportunidad y sentir tristeza por lo que dejas atrás; querer compañía y necesitar tiempo a solas. Tener sentimientos mezclados no demuestra que seas incoherente ni que hayas elegido mal."),
                H("Deja espacio para ambas partes"),
                P("Prueba a completar dos frases: «Me alegra porque…» y «Me entristece o preocupa porque…». No hace falta que una parte anule la otra ni decidir cuál es la emoción «verdadera». Si tienes las ideas enredadas, escríbelas por separado o habla con alguien que no te apresure a decidir."),
                H("Decide teniendo en cuenta tus valores y circunstancias"),
                P("Las emociones aportan información, pero también puedes considerar la seguridad, los hechos, los compromisos y lo que te importa. Elige un siguiente paso que no te obligue a negar ninguna parte. Quizá te ayude esperar, reunir información o hablar de la decisión con alguien de confianza.")
            ]),
        new(
            ArticleIds.AngerPause,
            "Haz una pausa antes de responder con enfado",
            "Reduce primero el riesgo y luego decide qué decir",
            "TipsAndUpdates",
            2,
            [
                P("Cuando aparece el enfado, la atención puede estrecharse y las palabras o acciones pueden intensificar la conversación. Si es seguro, deja de escribir o propone una pausa breve: «Quiero hablarlo, pero necesito calmarme. Volveré al tema más tarde». Si estás dispuesto, indica un momento realista para retomarlo."),
                H("Usa la pausa para bajar la intensidad"),
                P("Ve a un lugar más tranquilo, bebe agua o cambia por un rato a una actividad neutral. No envíes mensajes para castigar o asustar a la otra persona ni conduzcas si estás muy alterado. Cuando estés más tranquilo, separa lo ocurrido de las acusaciones y decide qué petición o límite quieres expresar."),
                H("La seguridad importa más que la conversación"),
                P("Si hay riesgo de violencia, amenazas o persecución, no intentes resolver el conflicto a solas. Ve a un lugar seguro, contacta con alguien de confianza o con los servicios de emergencia. Hacer una pausa no te obliga a retomar la conversación; puedes terminarla si continuar no es seguro.")
            ]),
        MiniArticle(ArticleIds.ShameKindness, "Responde a la vergüenza sin humillarte", "Puedes reparar un error sin castigarte", "Dite: «Ahora siento vergüenza, pero este sentimiento no me describe por completo». Separa la acción de tu identidad: qué pasó y si algo puede repararse. Elige la respuesta que ofrecerías a alguien cercano. Si tu conducta afectó a alguien, reconoce el impacto y pregunta qué ayudaría a repararlo."),
        new(
            ArticleIds.GuiltRepair,
            "Culpa: reparar algo o dejarla ir",
            "Separa la responsabilidad del reproche interminable",
            "TipsAndUpdates",
            2,
            [
                P("La culpa puede señalar que cruzaste un límite propio o hiciste daño. Pero sentir culpa no demuestra que seas responsable de todo. Examina una acción concreta en lugar de emitir un juicio sobre toda tu persona."),
                H("Si hiciste daño"),
                P("Nombra lo que ocurrió y qué se puede reparar de forma realista. Si corresponde, ofrece una disculpa concreta y sin excusas, y pregunta qué desea la persona afectada. Disculparte no obliga a la otra persona a perdonarte ni a mantener el contacto. Da un paso razonable y cambia lo que esté en tu mano."),
                H("Si no te corresponde o ya reparaste lo posible"),
                P("Comprueba si estás cargando con los sentimientos, circunstancias o decisiones de otra persona. Una vez hecha una reparación razonable, castigarte sin fin no ayuda a quien sufrió. Puedes reconocer el arrepentimiento, aprender y elegir tu siguiente conducta. Si la situación es compleja o dolorosa, puedes comentarla con un profesional.")
            ]),
        new(
            ArticleIds.EnvyInformation,
            "La envidia puede señalar lo que deseas",
            "Convierte la comparación en una dirección propia",
            "TipsAndUpdates",
            2,
            [
                P("La envidia puede resultar incómoda y llevarte a juzgarte. Ese sentimiento no determina si eres buena persona. A veces señala un deseo que no has atendido: más libertad, reconocimiento, cercanía o tiempo para algo importante."),
                H("Nombra la necesidad detrás de la comparación"),
                P("Pregúntate qué envidias exactamente y qué parte querrías de verdad para tu vida. Separa el valor que deseas de la manera en que otra persona lo busca. Puede importarte la autonomía aunque su camino para conseguirla no encaje contigo."),
                H("Da un paso manejable sin imitar"),
                P("Piensa en una acción para esta semana: pedir más responsabilidad, escribir a alguien cercano o reservar tiempo para practicar una habilidad. Quizá descubras que el deseo nació de la comparación y no de tus valores; puedes dejarlo pasar. No se trata de convertirte en otra persona, sino de escuchar con más claridad tu propia dirección.")
            ]),
        new(
            ArticleIds.AllowSadness,
            "La tristeza no tiene que desaparecer enseguida",
            "Dale espacio al sentimiento y elige apoyo",
            "TipsAndUpdates",
            2,
            [
                P("Una pérdida, una ruptura, una decepción o el cansancio pueden venir acompañados de tristeza. No tienes que explicarla enseguida ni obligarte a estar animado. Puedes reconocer «ahora mismo esto es difícil», aunque aún no sepas qué hacer."),
                H("Elige un apoyo amable"),
                P("Pregúntate qué tienes disponible: un rato a solas, escribir a alguien cercano, comer, descansar o hacer una tarea necesaria. No tienes que hacerlo todo de una vez. Si pides apoyo, puedes ser claro: «No necesito soluciones, ¿puedes estar conmigo?» o «¿Me ayudas con una tarea concreta?»."),
                H("Cuídate sin exigir que cambie el ánimo"),
                P("Las necesidades básicas importan aunque la tristeza no cambie después de un paso. Si sigue interfiriendo en tu vida o se hace más pesada, busca apoyo profesional. Pedir ayuda no significa que hayas fracasado; puede ser una forma posible de recibir apoyo.")
            ]),
        new(
            ArticleIds.Numbness,
            "Cuando cuesta sentir algo",
            "No te obligues a abrirte enseguida",
            "TipsAndUpdates",
            2,
            [
                P("El entumecimiento o la sensación de vacío pueden desconcertar. Por sí solos no explican su causa. No tienes que forzarte a llorar, volver a recuerdos ni explicar todo enseguida. Empieza por un punto de referencia neutral y por lo que podría ayudarte durante los próximos minutos."),
                H("Comprueba necesidades sencillas"),
                P("Fíjate en dónde estás, qué hora es y qué puede necesitar tu cuerpo: agua, comida, abrigo, descanso o un lugar más tranquilo. Elige solo lo que esté a tu alcance. Puedes escribir a alguien cercano: «Ahora no encuentro las palabras; ¿puedes quedarte en contacto un rato?»."),
                H("Busca apoyo si persiste"),
                P("Si el entumecimiento te asusta, dura o dificulta cuidarte y hacer tareas cotidianas, coméntalo con un profesional. No atribuyas automáticamente a un estado emocional los síntomas nuevos, intensos o dolorosos; busca una valoración médica cuando corresponda.")
            ]),
        new(
            ArticleIds.EmotionWave,
            "Una emoción puede cambiar, aunque no enseguida",
            "Obsérvala sin cronómetro",
            "TipsAndUpdates",
            2,
            [
                P("Una emoción intensa puede parecer permanente, sobre todo mientras estás en medio de ella. Puede cambiar poco a poco, por oleadas o seguir igual de momento. No tienes que esperar a que desaparezca para cuidarte o elegir un siguiente paso seguro."),
                H("Obsérvala sin exigirte una cifra menor"),
                P("Si te sirve, nombra la emoción y valora su intensidad de cero a diez. No es un examen: no tienes que reducir la cifra. También puedes notar dónde estás, qué ocurrió antes y qué te ofrece algo de apoyo ahora."),
                H("Elige algo para los próximos minutos"),
                P("Prueba un apoyo sencillo: sentarte, beber agua, alejarte del ruido o contactar con alguien de confianza. Más tarde puedes observar de nuevo y comparar solo con tu experiencia anterior. Si sigue igual, no es un fracaso; prueba otro apoyo o busca ayuda si te cuesta afrontarlo.")
            ]),
        new(
            ArticleIds.BodyNoticingChoice,
            "Observa tu cuerpo a un ritmo cómodo",
            "También puedes elegir un apoyo externo",
            "TipsAndUpdates",
            2,
            [
                P("Prestar atención a la respiración y al cuerpo ayuda a algunas personas y aumenta el malestar de otras. Puedes detener la observación corporal en cualquier momento. No se trata de encontrar la sensación correcta, sino de elegir una forma segura y adecuada de orientarte ahora."),
                H("Haz una comprobación breve"),
                P("Si te resulta cómodo, nota un detalle neutral: los pies en el suelo, la espalda apoyada o la temperatura del aire. No tienes que cambiar la respiración ni conseguir relajarte. Quédate con la observación solo mientras te resulte bien."),
                H("Cambia el foco si aumenta el malestar"),
                P("Si centrarte en el cuerpo aumenta la ansiedad, abre los ojos y nombra algunos objetos, sus colores o formas. No tienes que volver a las sensaciones corporales. No atribuyas automáticamente a la ansiedad síntomas nuevos, intensos o dolorosos; consúltalos con un profesional de salud.")
            ]),
        new(
            ArticleIds.PauseBeforeReact,
            "Haz una pausa entre el impulso y la respuesta",
            "Primero decide si es seguro esperar",
            "TipsAndUpdates",
            2,
            [
                P("Una emoción intensa puede empujarte a enviar un mensaje, aceptar o negarte de inmediato. Una pausa breve permite comprobar si tu respuesta encaja con lo que quieres conseguir. Pero esperar no siempre ayuda: si retrasa algo importante o crea un riesgo, responde ahora de forma breve y clara."),
                H("Guarda un borrador"),
                P("Aclara tu objetivo: comunicar un hecho, hacer una pregunta, poner un límite o acordar un momento. Si es seguro esperar, escribe un borrador y déjalo unos minutos. Después quita los reproches y las frases que no ayudan al objetivo. Soltar el aire despacio puede darte una pausa, pero no tiene que cambiar lo que sientes."),
                H("Elige según la situación"),
                P("Relee el mensaje y comprueba si queda claro qué pides o comunicas. Puedes responder brevemente, pedir tiempo o retomar la conversación después. Si hay un tema de seguridad, un plazo o una necesidad urgente de ayuda, no uses la pausa para evitarlo: comunica lo necesario o busca apoyo.")
            ]),
        new(
            ArticleIds.EmotionalBoundary,
            "No te toca arreglar los sentimientos de otras personas",
            "Puedes acompañar y mantener tus límites",
            "TipsAndUpdates",
            2,
            [
                P("Cuando alguien cercano lo pasa mal, es fácil sentir que debes encontrar una solución o quitarle todo el malestar. Apoyar no significa hacerte responsable de los sentimientos y decisiones de otra persona. Tu cuidado puede ser cálido y tener límites a la vez."),
                H("Pregunta qué ayuda necesita"),
                P("Puedes preguntar: «¿Quieres que te escuche, que te ayude con algo concreto o que pensemos en opciones?». Ofrece solo lo que realmente puedes hacer, como hablar diez minutos o ayudar con una tarea. No prometas estar siempre disponible si no puedes cumplirlo."),
                H("Expresa tu límite con claridad"),
                P("Puedes decir: «Me importas y puedo hablar ahora, pero no puedo resolverlo por ti». Si no puedes ayudar, sugiere otro recurso solo si procede. Si hay peligro inmediato, no dependas únicamente del apoyo personal: contacta con alguien de confianza, un profesional o emergencias.")
            ]),
        new(
            ArticleIds.SupportWithoutFixing,
            "Acompaña sin arreglarlo todo",
            "Pregunta qué tipo de apoyo hace falta",
            "TipsAndUpdates",
            2,
            [
                P("Muchas personas aconsejan porque se preocupan, pero en un momento difícil el consejo puede sentirse como presión. Antes de proponer una solución, pregunta si la persona quiere que la escuches, que estés presente o recibir ayuda práctica. Así respetas su elección y reduces el riesgo de resolver otra cosa."),
                H("Ofrece una opción concreta y limitada"),
                P("Pregunta: «¿Quieres que te escuche, que me quede contigo o que pensemos en el siguiente paso?». Si elige hablar, escucha sin interrumpir con consejos ni exigir detalles. Ofrece solo lo que puedas cumplir: un tiempo concreto, una llamada o una tarea específica."),
                H("Cuida tu capacidad y la seguridad"),
                P("Puedes preocuparte y decir «ahora no puedo». No prometas guardar en secreto una amenaza inmediata. Si la persona u otra está en peligro, contacta con un adulto de confianza, un profesional o emergencias; no te conviertas en la única fuente de apoyo.")
            ]),
        MiniArticle(ArticleIds.AfterCrying, "Después de llorar", "Cuida el próximo minuto", "No tienes que explicar las lágrimas enseguida. Elige algo sencillo: beber agua, lavarte la cara o sentarte en un lugar cómodo; también puedes pedir a alguien que te acompañe. No te exijas calmarte al instante. Puedes aplazar una tarea grande. Si estás en peligro o no puedes mantenerte a salvo, busca ayuda urgente ahora."),

        MiniArticle(ArticleIds.SpecificRequest, "Pide algo concreto", "Una petición clara deja espacio para responder", "Formula la petición en una frase: contexto breve, acción y momento. Por ejemplo: «Quiero hablar de esto; ¿tienes diez minutos después de cenar?» No necesitas justificarte durante mucho tiempo; deja claro qué pides. Da espacio para responder y, si ayuda, ofrece otra opción."),
        MiniArticle(ArticleIds.ListenReflect, "Primero comprende y después responde", "Una breve comprobación puede reducir la tensión", "Resume la idea principal con tus palabras y pregunta: «¿Te he entendido bien?» Espera a que te corrijan antes de aconsejar o responder al fondo. Pregunta si le viene bien escuchar un consejo. Mostrar que has escuchado no significa estar de acuerdo. Si la conversación se tensa demasiado, propón una pausa y acuerden cuándo retomarla."),
        MiniArticle(ArticleIds.BoundarySentence, "Una frase para marcar un límite", "Una respuesta breve suele ser más clara que una defensa larga", "Di qué te parece bien y qué harás: «Quiero hablar con calma; si seguimos en este tono, terminaré la conversación y la retomaremos más tarde». Habla de tu propia acción, no de controlar a la otra persona. Si decirlo directamente puede aumentar el peligro, aléjate y busca ayuda."),
        MiniArticle(ArticleIds.NoWithoutEssay, "Puedes decir que no sin dar una explicación larga", "Elige una frase amable y clara", "Si es seguro negarte, responde brevemente: «Gracias, pero no puedo» o «No me viene bien». No tienes que ofrecer alternativas ni explicar motivos personales. Si la otra persona insiste, repite la respuesta una vez y termina la conversación si es seguro. Si negarte puede ponerte en riesgo, prioriza alejarte y buscar apoyo."),
        MiniArticle(ArticleIds.DifficultTalkOpening, "Empieza una conversación difícil con un objetivo", "Habla de un episodio y una petición", "Antes de hablar, anota un objetivo y una petición. En un momento tranquilo, describe lo ocurrido y cómo te afectó, sin juzgar el carácter de la otra persona: «Me cuesta planificar cuando los planes cambian sin avisar; ¿podemos avisarnos antes?» No empieces si no es seguro. Si aumenta la tensión, pausa y acuerda cuándo retomarlo solo si es seguro."),
        MiniArticle(ArticleIds.RepairAfterConflict, "Retoma la conversación después de una discusión", "Da un pequeño paso hacia la claridad", "Primero pregunta si la otra persona está preparada para hablar. Céntrate en un episodio: reconoce tu parte y pregunta cómo lo vivió. Elige un punto que aclarar; no hace falta resolver todo el conflicto ahora. Si aparecen amenazas o miedo, termina la conversación y busca apoyo."),
        MiniArticle(ArticleIds.ApologyResponsibility, "Discúlpate sin renunciar a tus límites", "Nombra la acción y lo que cambiarás", "Nombra la acción y su efecto: «Te interrumpí y no pudiste terminar. Lo siento». Di qué harás distinto y pregunta si ayudaría reparar algo. Reconocer una acción no significa aceptar todas las acusaciones ni renunciar a tu seguridad. La otra persona puede necesitar tiempo."),
        MiniArticle(ArticleIds.FeedbackAsInformation, "Separa una crítica de tu valor", "Aclara qué puedes aprovechar", "Si el comentario es vago, pide un ejemplo concreto y un cambio observable. Elige como máximo un punto para probar. Una valoración sobre un resultado no juzga toda tu persona. No tienes que aceptar insultos o humillaciones como críticas útiles. Separa el hecho de la conclusión: «al informe le falta un ejemplo» es concreto; «no valgo para nada» es una generalización. Si ahora te cuesta, vuelve al comentario más tarde."),
        MiniArticle(ArticleIds.ReceiveNo, "Cuando alguien te dice que no", "Rechazar una petición no siempre es rechazarte", "Pregúntate a qué se refiere el no: a esta petición, a este momento o a esta opción. Si te sirve, pregunta una vez por una alternativa; después decide a quién más acudir o qué puedes hacer tú. Puedes sentir decepción sin convertir la respuesta en un juicio sobre tu valor."),
        new(
            ArticleIds.CheckAssumption,
            "Comprueba una suposición con una pregunta",
            "Aclara el sentido antes de construir una historia",
            "TipsAndUpdates",
            2,
            [
                P("Un mensaje ambiguo deja espacio a las suposiciones: una respuesta breve puede parecer fría y una pausa, intencionada. Pero una sola señal rara vez muestra todo el contexto. Antes de sacar conclusiones, separa lo que observaste de lo que interpretaste."),
                H("Haz una pregunta neutral"),
                P("Si la respuesta importa, pregunta: «¿Entendí bien que…?» o «¿Querías decir…?». Evita acusaciones y no envíes varios mensajes seguidos. Si no es urgente, dale tiempo a la otra persona; decide cuándo volver a mirar en vez de actualizar el chat sin parar."),
                H("Decide si necesitas más claridad"),
                P("Si aclararlo no cambiaría lo que vas a hacer, puedes dejar la duda abierta. Si sí cambia algo, espera la respuesta o explica qué necesitas saber y para cuándo. Si la conversación no es segura, elige otra vía o busca apoyo. El objetivo es obtener claridad útil, no certeza absoluta.")
            ]),
        MiniArticle(ArticleIds.AskSupport, "Pedir apoyo es una habilidad", "Di qué te ayudaría", "Di qué tipo de apoyo necesitas: que te escuchen, pensar juntos en opciones o hacer algo en compañía. Por ejemplo: «Hoy ha sido difícil. ¿Puedes escucharme diez minutos sin dar consejos?» Pregunta si le viene bien ahora. Si no, acuerda otro momento o contacta con otra persona de confianza."),
        MiniArticle(ArticleIds.SupportWithoutFixing, "Acompaña sin arreglarlo todo", "Pregunta qué tipo de apoyo hace falta", "Prueba: «¿Quieres que te escuche, que me quede contigo o que pensemos en el siguiente paso?» No prometas lo que no puedes cumplir. El apoyo respeta las decisiones de la otra persona y tus límites. Ante un peligro inmediato, escuchar quizá no sea suficiente."),
        new(
            ArticleIds.ConflictNotFailure,
            "Un desacuerdo no siempre significa que la relación terminó",
            "Fíjate en cómo se tratan",
            "TipsAndUpdates",
            2,
            [
                P("Puede haber diferencias incluso en relaciones cercanas. Importa lo que se dice durante el desacuerdo, pero también lo que ocurre después: si hay escucha, responsabilidad y cambios concretos. Una discusión aislada no responde por sí sola a todas las preguntas sobre el futuro de la relación."),
                H("Hablad de un asunto cada vez"),
                P("Si ambos estáis a salvo y queréis hablar, elegid un episodio o una petición concreta. Describe qué ocurrió, cómo te afectó y qué cambio específico ayudaría. Pregunta cómo lo vivió la otra persona. No hace falta estar de acuerdo en todo ni resolverlo en una sola conversación."),
                H("No pongas la reconciliación por encima de la seguridad"),
                P("El respeto y la responsabilidad deben ser mutuos; no dependen solo de ti. Si hay amenazas, violencia, control o miedo por tu seguridad, busca primero protección y apoyo. No estás obligado a tener una conversación de reconciliación si no es segura.")
            ]),
        new(
            ArticleIds.MakeExpectationsClear,
            "Expresa las expectativas con antelación",
            "No esperes que la otra persona lo adivine",
            "TipsAndUpdates",
            2,
            [
                P("Algunos conflictos cotidianos nacen de distintas ideas sobre plazos, funciones o qué significa terminar, no necesariamente de malas intenciones. «Lo hacemos luego» puede significar hoy para una persona y la semana que viene para otra. Aclararlo antes permite ver la diferencia a tiempo."),
                H("Acordad detalles concretos"),
                P("Antes de hacer algo juntos, hablad de quién hará qué, para cuándo y qué cuenta como terminado. Comprueba que entendisteis el acuerdo de la misma manera, incluso resumiéndolo por mensaje si ayuda. La claridad no garantiza el acuerdo, pero hace visibles las expectativas."),
                H("Actualizad el acuerdo si cambian los planes"),
                P("Si cambian el plazo o tus posibilidades, avisa pronto y propone otra opción. Habla del problema y del siguiente paso sin atribuir motivos. Si no lográis acordarlo, decide qué puedes hacer por tu cuenta y dónde necesitas más apoyo.")
            ]),
        new(
            ArticleIds.DigitalBoundaries,
            "Límites en los mensajes",
            "Las notificaciones no tienen que dirigir tu día",
            "TipsAndUpdates",
            2,
            [
                P("Las alertas frecuentes interrumpen la atención y pueden hacerte sentir que debes contestar enseguida. Pero estar siempre disponible no es lo mismo que preocuparte por los demás. Puedes elegir una rutina de comunicación que encaje con tus responsabilidades y relaciones, si es segura y práctica."),
                H("Ajusta expectativas y avisos"),
                P("Elige un horario para los mensajes habituales y desactiva sonidos o vistas previas de los que pueden esperar. Si te conviene, cuenta a la gente cercana cuándo sueles responder. Acuerda otro modo claro de contacto para urgencias reales, para no perder mensajes importantes."),
                H("Deja espacio para cambiar la rutina"),
                P("Prueba el horario unos días y comprueba si siguen llegando los mensajes importantes y te concentras mejor. Si cambian las circunstancias, ajusta la regla. No es prohibir el contacto, sino responder con más atención sin estar disponible cada minuto.")
            ]),
        new(
            ArticleIds.FamilyPressure,
            "Cuando la familia insiste con sus consejos",
            "Agradece y di que decidirás",
            "TipsAndUpdates",
            2,
            [
                P("Un consejo puede nacer del cariño, pero la insistencia repetida también cansa. Puedes reconocer la preocupación de alguien sin aceptar que decida por ti. Una frase breve suele ser más clara que una explicación larga que abre un debate sobre cada punto."),
                H("Prepara una respuesta tranquila"),
                P("Por ejemplo: «Veo que te preocupa. Lo pensaré y decidiré». Si la conversación continúa, repite la frase, propón hablarlo más tarde o cambia de tema. No necesitas que estén de acuerdo para expresar tu decisión."),
                H("Valora primero la seguridad"),
                P("Una respuesta directa no encaja en todas las relaciones. Si discrepar puede provocar amenazas, violencia, pérdida de vivienda u otro riesgo, no pongas a prueba el límite a solas. Habla de un plan seguro con alguien de confianza o un profesional y elige un momento y una forma de responder que reduzcan el riesgo.")
            ]),
        new(
            ArticleIds.FriendshipInvitation,
            "Invita a alguien sin organizar un gran plan",
            "Una invitación pequeña es más fácil de aceptar o rechazar",
            "TipsAndUpdates",
            2,
            [
                P("Organizar un plan grande puede parecer difícil. Una invitación concreta y sencilla reduce la incertidumbre: ayuda a la otra persona a imaginar el encuentro y responder. Un no o tener la agenda llena refleja su disponibilidad ahora, no tu valor."),
                H("Haz una propuesta sencilla"),
                P("Di la actividad, el día y una duración aproximada: «¿Te apetece pasear veinte minutos el jueves después del trabajo?». Añade que otro momento o un no están bien. No tienes que disculparte por invitar ni justificar por qué quieres quedar."),
                H("Deja espacio para cualquier respuesta"),
                P("Después de enviarla, espera en vez de mandar varios mensajes seguidos. Si no puede, puedes proponer una alternativa si muestra interés o dejar que la iniciativa pase a esa persona. Si no responde, vuelve a tus planes y decide más adelante si quieres intentarlo otra vez.")
            ]),
        MiniArticle(ArticleIds.SmallConnection, "Un contacto pequeño también cuenta", "No tienes que empezar con una conversación profunda", "Si te sientes solo, elige una forma fácil de estar con gente: un mensaje breve, un sitio conocido o una charla neutral. Para cuando sea suficiente. El objetivo es probar conexión, no obligarte a socializar. Un mensaje breve o estar en un lugar compartido puede bastar."),

        MiniArticle(ArticleIds.OrientNow, "Comprueba dónde estás ahora", "Una forma suave de orientarte al presente", "Mira alrededor y nombra el lugar, el momento del día y algunos detalles neutros, como objetos o sonidos. Mantén los ojos abiertos y ve a tu ritmo. No necesitas recordar detalles del suceso. Si aumenta la ansiedad, para; puedes elegir un objeto neutro o pedir a alguien de confianza que se quede contigo."),
        MiniArticle(ArticleIds.GroundingChoice, "Elige un anclaje que te venga bien", "No a todo el mundo le resulta cómodo enfocarse en el cuerpo", "Puedes nombrar colores, describir un objeto, notar la silla o escuchar un sonido constante. Elige algo tolerable ahora. Si te hace sentir peor, para y prueba otra cosa. Si resulta neutral, repite el ancla; no exijas alivio inmediato."),
        MiniArticle(ArticleIds.AfterNightmare, "Después de una pesadilla", "Recuerda que el sueño ya terminó", "Enciende una luz suave, mira alrededor y nombra señales de que estás en tu habitación. No tienes que recordar el sueño en detalle. Si las pesadillas se repiten o alteran el sueño, coméntalo con un profesional sanitario. Cuando te hayas orientado, elige una actividad tranquila y conocida en vez de intentar interpretar el sueño. Si te asusta quedarte a solas, despierta o contacta con alguien de confianza."),
        MiniArticle(ArticleIds.AnniversaryReaction, "Fechas difíciles y aniversarios", "La reacción puede llegar antes o después", "Si una fecha te recuerda un hecho difícil, deja menos tareas y elige apoyo con antelación. Puedes conmemorarla a tu manera o no hacerlo. Sentir mucho no significa volver al principio. Si el malestar suele empezar antes, reserva también tiempo para recuperarte después de la fecha."),
        MiniArticle(ArticleIds.PaceRecovery, "Recupérate a tu propio ritmo", "No conviertas el autocuidado en una maratón", "Elige una práctica y pon un límite antes de empezar, como tres minutos o un solo paso. Si aumenta la tensión, para y elige algo más cómodo. Después, anota brevemente: ¿más fácil, igual o más difícil? Deja que eso guíe el siguiente paso, no el ritmo de otras personas."),
        MiniArticle(ArticleIds.SafetyFirst, "La seguridad importa más que el ejercicio", "La autoayuda no exige quedarse en peligro", "Si hay una amenaza cerca, intenta llegar primero a un lugar más seguro y contactar con alguien que pueda ayudarte. Respirar o anclarte no sustituye la protección, la atención médica ni los servicios de emergencia. Si no puedes alejarte por tu cuenta, pide a alguien cercano que llame a emergencias."),
        new(
            ArticleIds.ChooseTrustedPerson,
            "Elige a alguien a quien pedir apoyo",
            "Pide una ayuda concreta y manejable",
            "TipsAndUpdates",
            2,
            [
                P("Cuando las cosas van mal, puede parecer que tienes que explicarlo todo de una vez. Para empezar basta con una petición breve. Piensa en alguien que suele respetar tus límites y puede escucharte con calma. No tiene que ser la persona más cercana si esa relación no te resulta segura."),
                H("Di qué te ayudaría"),
                P("Por ejemplo: «Lo estoy pasando mal. ¿Puedes hablar conmigo diez minutos?» o «¿Me ayudas a decidir a quién llamar?». Si hablar cuesta, envía una señal breve acordada previamente o pide compañía sin preguntas. Comprueba si a esa persona le viene bien ahora."),
                H("Ten preparada otra opción"),
                P("Alguien de confianza puede estar ocupado o no saber qué decir. Eso no significa que hayas pedido algo mal. Piensa antes en otra persona a quien contactar o en un servicio profesional local. Si hay peligro inmediato, contacta con emergencias en vez de esperar la respuesta de una sola persona.")
            ]),
        new(
            ArticleIds.AfterStressRecovery,
            "Después de un evento estresante",
            "Date tiempo para volver a las tareas habituales",
            "TipsAndUpdates",
            2,
            [
                P("Después de un evento estresante, quizá tengas menos energía y concentración. No hace falta analizarlo todo enseguida ni recuperar de inmediato tu ritmo habitual. Primero comprueba qué necesitas durante la próxima hora y qué tarea realmente no puede esperar."),
                H("Empieza por un apoyo sencillo"),
                P("Elige algo a tu alcance: beber agua, comer, cambiarte de ropa, estar un rato en silencio o escribir a alguien cercano. Si la lista de tareas pesa, aplaza una que no sea urgente hasta una hora concreta. No te exijas sentirte mejor después de cada paso."),
                H("Valora si necesitas más apoyo"),
                P("Si las consecuencias siguen interfiriendo en el sueño, el trabajo, los estudios o la vida diaria, habla con un profesional de salud. No atribuyas automáticamente al estrés síntomas físicos nuevos o intensos. Puedes pedir ayuda antes de llegar al límite.")
            ]),
        MiniArticle(ArticleIds.FlashbackGrounding, "Cuando el pasado parece estar cerca otra vez", "Oriéntate al presente y conserva la capacidad de elegir", "Mira alrededor y nombra dónde estás y la fecha si ayuda. Elige un objeto visible o contacta con alguien cercano. No te obligues a cerrar los ojos, respirar hondo o contar detalles; si hay peligro, busca ayuda real. Puedes parar el ejercicio y acercarte a una persona segura."),
        new(
            ArticleIds.RecoveryNotLinear,
            "La recuperación no es una línea recta",
            "Un día difícil no borra lo que has avanzado",
            "TipsAndUpdates",
            2,
            [
                P("Las emociones intensas pueden volver tras un periodo tranquilo por cansancio, un recuerdo o nuevas circunstancias. Eso no demuestra que tus esfuerzos hayan desaparecido ni que vuelvas al principio. En vez de juzgarte por completo, mira qué ocurre hoy y qué podría ayudarte en este tramo."),
                H("Haz que el siguiente paso sea posible"),
                P("Pregúntate qué puedes simplificar, aplazar o hacer con alguien hoy. Elige una necesidad básica y una tarea manejable. Recurre a algo que ya te ayudó solo si aún te sirve; tienes derecho a probar otra opción."),
                H("Vuelve a pedir apoyo si hace falta"),
                P("Si la carga aumenta, interfiere en tu vida diaria o cuesta manejarla a solas, contacta con alguien de confianza o un profesional. Pedir apoyo otra vez forma parte del cuidado, no borra tus avances. Si hay peligro inmediato, busca ayuda urgente.")
            ]),

        MiniArticle(ArticleIds.BreathIsOptional, "La práctica de respiración es opcional", "No te obligues a cambiar la respiración", "Si enfocarte en la respiración resulta desagradable, deja que siga natural y elige un apoyo externo: color, sonido u objeto. Estas prácticas no son adecuadas para todo el mundo y no sustituyen la atención ante falta de aire importante o síntomas nuevos. Si contar respiraciones te inquieta, elige un sonido externo."),
        MiniArticle(ArticleIds.GroundingCanChange, "Si el anclaje no ayuda", "Cambia de método o para", "Si el ejercicio no ayuda o te hace sentir peor, para. Si quieres, prueba una vez con un apoyo externo sencillo, como mirar un objeto. Si tampoco sirve, contacta con alguien o elige un apoyo que requiera menos concentración."),
        MiniArticle(ArticleIds.MovementAnchor, "Usa el movimiento como apoyo", "Un movimiento pequeño puede devolverte opciones", "Si es cómodo y seguro, abre y cierra las manos despacio o cambia el peso de un pie a otro. También puedes observar un objeto en movimiento. No fuerces si duele; elige un objeto quieto si te conviene más. Si estás sentado, puedes apoyar suavemente los pies en el suelo."),
        MiniArticle(ArticleIds.SensesAnchor, "Un apoyo a través de los sentidos", "Elige una señal neutral de tu entorno", "Nombra un color, la temperatura del aire o un sonido constante que no te moleste. No hace falta encontrar cinco cosas ni cerrar los ojos. Una señal neutral puede bastar; cambia si resulta desagradable. Si el sonido distrae, elige un color; si mirar alrededor cansa, nota el apoyo bajo tus pies."),
        MiniArticle(ArticleIds.EarlyStressSigns, "Observa las primeras señales de sobrecarga", "Notarlas antes te da más opciones", "Elige una señal temprana que hayas notado más de una vez, como tensión o menor atención. Anota brevemente cuándo suele aparecer y elige una respuesta: hacer una pausa, aclarar la tarea o pedir ayuda. Esto puede orientar tu planificación, pero no es un diagnóstico."),
        MiniArticle(ArticleIds.RelaxWithoutForce, "Relájate sin forzarte", "No tienes que alcanzar una calma total", "Elige una acción que requiera poca concentración: bajar los hombros, acomodarte o aflojar las manos. Deja la respiración natural. Un poco de comodidad basta; no fuerces al cuerpo a relajarse por completo. Si prestar atención al cuerpo aumenta el malestar, dirige la atención a algo del entorno."),
        MiniArticle(ArticleIds.BasicCareWithoutRules, "Cuidados básicos sin reglas estrictas", "Elige lo que necesitas ahora", "Elige una cosa que necesites durante la próxima hora y hazla pequeña: un vaso de agua, algo de comer, una prenda de abrigo o escribir a alguien. Si no está a tu alcance, nombra el obstáculo y pide ayuda concreta. No poder con todo a solas no es un fracaso personal."),
        MiniArticle(ArticleIds.NewSymptomsCare, "Síntomas nuevos o poco habituales", "No te diagnostiques con un artículo", "Si los síntomas físicos son nuevos, intensos o cambian rápidamente, consulta con un profesional sanitario. Ante señales de emergencia, llama a los servicios locales. Una práctica de autoayuda no debe retrasar una valoración médica. Anota cuándo empezó, pero no esperes si el síntoma es intenso."),
        MiniArticle(ArticleIds.FindTherapist, "Cómo buscar un profesional", "Busca una relación de trabajo adecuada, no una descripción perfecta", "Pregunta por la formación, la experiencia con tu tema, el formato, el coste y la confidencialidad. En la primera cita, pregunta cómo se trabajará y cómo sabrás si ayuda. Puedes buscar a otra persona si no encaja. Confirma también cómo se manejan las cancelaciones y qué hacer si tu estado empeora entre sesiones."),
        MiniArticle(ArticleIds.FirstAppointment, "La primera cita", "No necesitas preparar una historia perfecta", "Lleva un ejemplo reciente y tres preguntas: ¿Cómo serán las sesiones? ¿Qué será confidencial? ¿Por dónde podríamos empezar? Puedes decir que te cuesta explicarlo, pedir una pausa o dejar una pregunta sin responder. No tienes que decidir de inmediato si continuar."),
        MiniArticle(ArticleIds.DescribeSymptoms, "Cómo describir lo que te pasa", "Un ejemplo real ayuda más que los términos perfectos", "Cuenta cuándo empezó, con qué frecuencia sucede y qué cambia en tu vida diaria. Si cuesta hablar, lleva una nota o enséñala. No tienes que adivinar un diagnóstico para pedir ayuda. Un ejemplo reciente de tu día puede facilitar la explicación."),
        MiniArticle(ArticleIds.SelfHelpLimits, "Cuando la autoayuda no basta", "El apoyo profesional es un siguiente paso válido", "Si tu estado altera durante mucho tiempo el sueño, el trabajo, el estudio o el autocuidado, empeora o los ejercicios no ayudan, contacta con un profesional sanitario o psicólogo. No tienes que demostrar que ya lo resolviste por tu cuenta. Puedes pedir ayuda antes de que la situación sea insoportable."),

        MiniArticle(ArticleIds.ScreeningNotDiagnosis, "Un cuestionario no es un diagnóstico", "El resultado puede iniciar una conversación, no ponerte una etiqueta", "Las respuestas reflejan un periodo concreto y dependen de las circunstancias. Enseña el resultado a un profesional si te preocupa. No cambies un tratamiento ni tomes decisiones importantes basándote solo en una puntuación. El cuestionario ayuda a preparar preguntas, pero no sustituye una evaluación."),
        MiniArticle(ArticleIds.SupportPlan, "Prepara un plan breve de apoyo", "Anota señales, pasos y contactos", "Escribe cómo notas que empeoras, qué suele ayudarte y a quién puedes avisar. Añade contactos profesionales y servicios locales de emergencia. El plan no sustituye la ayuda; indica a quién llamar cuando cuesta pensar. Comprueba antes si los contactos están disponibles en tu zona."),
        MiniArticle(ArticleIds.CrisisSteps, "Si ahora mismo no estás a salvo", "Conecta con ayuda en tiempo real", "Ve a un lugar más seguro si es posible y contacta con emergencias locales o alguien de confianza. Di brevemente qué ocurre y dónde estás. No te quedes a solas si hay peligro inmediato. Si te cuesta llamar, pide a alguien que te acompañe en la llamada."),
        MiniArticle(ArticleIds.MedicationWithClinician, "Consulta con un profesional las dudas sobre medicación", "No cambies una receta por tu cuenta", "Si te preocupa una medicación, anota el nombre, la pregunta y cualquier efecto no deseado y coméntalo con quien la recetó o con un farmacéutico. No empieces, suspendas ni cambies dosis basándote en una app o artículo. Revisa el prospecto o consulta a una farmacia; las indicaciones varían."),
        MiniArticle(ArticleIds.DeadlineConversation, "Si no llegas a la fecha límite", "Habla del plazo mientras haya opciones", "Revisa qué está terminado y cuánto falta de verdad. Avisa cuanto antes a quienes afecte, con los datos y una fecha realista. Propón opciones: ampliar el plazo, reducir el alcance o entregar ahora una parte terminada. Por ejemplo: «Los apartados 1 y 2 estarán el viernes; el resto, el martes. ¿Qué opción te viene mejor?». No prometas una fecha que dependa de exigirte más de la cuenta y confirma lo acordado."),
        MiniArticle(ArticleIds.DifficultMessageReply, "Antes de responder a un mensaje difícil", "Elige primero el objetivo de tu respuesta", "Si no es urgente, espera a que baje la primera ola de emoción. Separa las palabras exactas del significado que les has atribuido. Elige un objetivo: aclarar, marcar un límite, comunicar una decisión o aplazar la conversación. Puedes escribir: «Volveré a este tema esta tarde». Si hace falta responder ya, comparte solo la información necesaria y deja lo demás para después."),
        MiniArticle(ArticleIds.CancelPlans, "Si tienes que cancelar un plan", "Sé claro y propone otra fecha si quieres", "Avisa cuanto antes de que los planes han cambiado. Comparte solo la razón que quieras contar; no hace falta dar una explicación larga. Si te apetece veros, propón un día o una hora concretos. Reconoce el efecto que puede tener la cancelación y deja que la otra persona diga que no. Si cancelas por seguridad o por cómo te encuentras, atiende eso primero."),
    ];
}
