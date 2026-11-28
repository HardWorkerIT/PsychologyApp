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
        new(
            ArticleIds.AskForHelpTask,
            "Pide ayuda con una parte concreta",
            "Describe la tarea para que sea fácil responder",
            "TipsAndUpdates",
            2,
            [
                P("Pedir ayuda puede resultar incómodo, sobre todo si estás acostumbrado a arreglártelas por tu cuenta o temes ser una carga. Una petición concreta reduce la incertidumbre y ayuda a entender qué necesitas. No tienes que demostrar que estás lo bastante cansado ni que te has ganado el apoyo."),
                H("Acota la petición"),
                P("Nombra una tarea, su alcance y un plazo útil: «¿Puedes revisar hoy el primer párrafo de este correo?». Di qué has hecho ya y pregunta si le viene bien. Deja espacio para que la persona diga que no o proponga algo más pequeño. Si necesitas pensar juntos una situación, explica cuánto tiempo pides aproximadamente."),
                H("Piensa en otra opción"),
                P("Si esa persona no puede ayudar, no significa necesariamente que te juzgue a ti o a la relación. Puedes reducir la tarea, aplazar el plazo o preguntar a alguien más. Si se trata de seguridad o una necesidad urgente, no te detengas ante una sola negativa: busca el apoyo adecuado.")
            ]),
        new(
            ArticleIds.MeaningfulActivity,
            "Elige una acción pequeña que te importe",
            "Conecta un paso con algo que valoras",
            "TipsAndUpdates",
            2,
            [
                P("Cuando tienes poca energía, puede desaparecer el sentido de una tarea grande. En vez de preguntarte solo «¿qué debería terminar?», prueba con «¿qué me importa en esta situación?». Puede ser cuidar, conectar con alguien, tener curiosidad, cumplir o descansar. Un valor no es una casilla ni una medida de productividad, sino una dirección para elegir qué hacer."),
                H("Haz visible ese valor"),
                P("Elige una acción de cinco o diez minutos relacionada: enviar un mensaje amable, abrir el documento necesario, regar una planta o acostarte antes. Reduce el paso lo suficiente para empezar sin esperar a sentir motivación. Si ahora lo más importante es recuperarte, descansar también puede ser una acción con sentido."),
                H("Observa la experiencia, no solo el resultado"),
                P("Después, fíjate en qué apareció: interés, cansancio, alivio o nada en particular. No tienes que forzar una sensación de satisfacción. Si la acción no era adecuada o no estaba disponible, ajústala o déjala para más tarde. El sentido no exige un gran resultado ni elimina las limitaciones reales.")
            ]),
        new(
            ArticleIds.FlexibleGoals,
            "Conserva la dirección y cambia el método",
            "Un objetivo puede adaptarse cuando cambian las circunstancias",
            "TipsAndUpdates",
            2,
            [
                P("A menudo hacemos un plan en unas condiciones y tenemos que llevarlo a cabo en otras. Si se ha vuelto inabarcable, es motivo para revisarlo, no para culparte. Separa tres cosas: la dirección que te importa, el objetivo concreto y el método para alcanzarlo. El sentido puede mantenerse aunque cambien el plazo o la cantidad de trabajo."),
                H("Elige un nivel viable"),
                P("Puedes definir tres versiones: un mínimo para los días difíciles, el paso habitual y algo más si tienes energía. Para preparar un examen, por ejemplo: abrir los apuntes y leer una página, repasar un tema o estudiar toda la sección. Elige un mínimo que te ayude a avanzar y no se convierta en un castigo."),
                H("Revisa plazos y acuerdos"),
                P("Si otras personas dependen del objetivo, avisa pronto del retraso y propón una fecha realista. Observa qué obstáculos se repiten: no saber cuál es el siguiente paso, falta de tiempo, cansancio o recursos insuficientes. Revisar el plan ayuda a responder a las condiciones; a veces también es razonable cambiar el objetivo o pedir ayuda.")
            ]),
        new(
            ArticleIds.CelebrateCompletion,
            "Reconoce un paso terminado antes de seguir",
            "Una pausa breve hace visible el esfuerzo",
            "TipsAndUpdates",
            2,
            [
                P("Al terminar algo, la atención suele saltar enseguida a lo que queda pendiente. Así, el día puede parecer una cadena continua de tareas sin acabar. Haz una pausa y nombra un hecho sin exagerarlo: «Envié el correo», «Pedí ayuda» o «Descansé cuando estaba cansado». No es un ritual obligatorio de gratitud ni una forma de fingir que todo va bien."),
                H("Observa qué te ayudó"),
                P("Si te sirve, añade una observación: qué paso funcionó, qué requirió esfuerzo o qué apoyo fue útil. Así, reconocer lo hecho aporta información para otra ocasión, en vez de convertirse en un juicio sobre tu valor. No compares tu ritmo con el de otras personas ni desprecies lo que hiciste porque aún quede más."),
                H("Elige la siguiente transición"),
                P("Después de la pausa, decide qué encaja ahora: continuar, cambiar de tarea, pedir apoyo o terminar por hoy. Acabar no siempre significa hacerlo todo a la perfección; a veces basta con detenerse en un punto acordado y seguro. En un día difícil, puedes reconocer el esfuerzo sin tener que sentir alegría.")
            ]),

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
        new(
            ArticleIds.ShameKindness,
            "Responde a la vergüenza sin humillarte",
            "Puedes reparar un error sin castigarte",
            "TipsAndUpdates",
            2,
            [
                H("Separa el sentimiento de los hechos"),
                P("La vergüenza puede convertir una acción concreta en un juicio sobre toda tu persona: «Me equivoqué» pasa a ser «Soy una mala persona». Describe la situación con precisión y sin etiquetas: qué dijiste o hiciste, qué ocurrió después y quién se vio afectado. Esto no elimina la responsabilidad; ayuda a ver qué se puede abordar."),
                H("Reconoce el impacto sin adivinar"),
                P("Si tus palabras o acciones afectaron a alguien, reconócelo de forma directa y breve. Puedes decir: «Te interrumpí y entiendo que pudo parecer que no te escuchaba». No hace falta empezar explicando tus intenciones ni pedir perdón de inmediato. Pregunta si quiere hablar de qué podría ayudar a reparar la situación y respeta su respuesta."),
                H("Elige una reparación realista"),
                P("Puede ser adecuado disculparte, corregir un error o cambiar una conducta concreta. Algunas consecuencias no pueden deshacerse enseguida; en ese caso, los cambios sostenidos importan. Elige un paso posible y no prometas lo que no puedes garantizar. Castigarte no recupera la confianza ni repara el daño."),
                H("Mantén el respeto por ti"),
                P("Prueba a hablarte como a una persona responsable que también merece respeto: «Lamento lo que hice. Puedo reconocerlo y decidir qué hacer ahora». Tratarte con amabilidad no es justificarte. Puede ayudarte a mantener la atención en la responsabilidad y en una acción concreta, en vez de repetir insultos contra ti."),
            ]),
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
        new(
            ArticleIds.AfterCrying,
            "Después de llorar, date tiempo",
            "Empieza por lo básico, no por buscar una explicación",
            "TipsAndUpdates",
            2,
            [
                P("Después de llorar intensamente, puedes sentir cansancio, temblor, vacío o alivio; cada persona reacciona de forma distinta. No tienes que explicar las lágrimas ni obligarte a calmarte. Comprueba lo inmediato: ¿estás en un lugar seguro? ¿Necesitas agua, abrigo, una postura cómoda o que alguien te acompañe? Elige solo lo que te venga bien."),
                H("Haz muy pequeño el siguiente paso"),
                P("Puedes lavarte la cara, beber agua, taparte con algo o simplemente sentarte. Si esas acciones no ayudan o te resultan incómodas, no tienes que hacerlas «bien». Aplaza las decisiones importantes hasta tener más energía. Si quieres, escribe a alguien de confianza: «Lo estoy pasando mal. ¿Puedes estar pendiente un rato?»"),
                H("Vuelve poco a poco a las actividades"),
                P("Cuando estés preparado, elige una tarea pequeña o descansa. Llorar no significa que seas débil ni que hayas vuelto al principio. Si llorar interfiere a menudo en tu vida, tu estado empeora o no puedes mantenerte a salvo, pide apoyo profesional; si el peligro es inmediato, busca ayuda urgente.")
            ]),

        new(
            ArticleIds.SpecificRequest,
            "Formula una petición concreta",
            "Contexto breve, una acción y un momento adecuado",
            "TipsAndUpdates",
            2,
            [
                P("Las indirectas y las explicaciones largas pueden ocultar qué estás pidiendo. Prueba una estructura sencilla: contexto breve, acción concreta y momento. Por ejemplo: «Quiero hablar del horario. ¿Tienes diez minutos hoy después de cenar?». No garantiza que acepten, pero permite responder con claridad."),
                H("Deja espacio para elegir"),
                P("Pregunta si ahora viene bien y acepta que te digan que no o propongan otro momento. Si no es urgente, ofrece dos opciones. No añadas amenazas ni culpa para obtener un sí. Si estás marcando un límite, explica también qué harás tú."),
                H("Aclara qué significa la respuesta"),
                P("Si la respuesta afirmativa es vaga, concreta la hora o el siguiente paso. Si aún no hay respuesta, acuerda cuándo volver a preguntarlo o decide qué puedes hacer por tu cuenta. Ante una situación insegura, una conversación normal puede no bastar: elige una vía más segura para conseguir apoyo.")
            ]),
        new(
            ArticleIds.ListenReflect,
            "Comprende primero y responde después",
            "Comprueba el sentido antes de aconsejar",
            "TipsAndUpdates",
            2,
            [
                P("En una conversación tensa es fácil preparar la respuesta mientras la otra persona sigue hablando. Reflejar brevemente lo que has oído ayuda a comprobar si entendiste y permite que te corrijan. No es una técnica para ganar una discusión, sino una forma de no responder a algo que la persona no dijo."),
                H("Resume una idea principal"),
                P("Elige una idea: «Si te he entendido bien, te molestó que los planes cambiaran sin avisarte». Luego para y deja que la otra persona aclare. No añadas enseguida una defensa, un diagnóstico o una solución. Si no estás seguro, pregunta qué se te ha escapado."),
                H("Pregunta qué ayudaría ahora"),
                P("Puedes preguntar: «¿Quieres que te escuche o pensamos juntos qué hacer?». Reflejar una idea no significa aceptar todas las valoraciones ni renunciar a tus límites. Si la conversación se vuelve insegura o demasiado intensa, haz una pausa y retómala solo en condiciones adecuadas.")
            ]),
        new(
            ArticleIds.BoundarySentence,
            "Un límite habla de lo que tú harás",
            "Di qué te parece aceptable y cómo actuarás",
            "TipsAndUpdates",
            2,
            [
                P("Un límite no sirve para obligar a otra persona a comportarse de cierta manera. Explica con claridad qué es aceptable para ti y qué harás si la situación continúa. Elige un episodio concreto en vez de explicar toda la relación. Si hablar directamente podría provocar amenazas o violencia, no ensayes a solas: piensa primero en tu seguridad y en el apoyo disponible."),
                H("Exprésalo brevemente y en primera persona"),
                P("Prueba esta estructura: «Cuando pasa X, me cuesta Y. Te pido Z; si continúa, haré W». Por ejemplo: «Puedo hablar de esto sin insultos. Si siguen, terminaré la llamada». Comprométete solo con una acción que dependa de ti y que puedas cumplir. No necesitas demostrar que tienes derecho a poner un límite ni conseguir que la otra persona esté de acuerdo."),
                H("Repítelo una vez y actúa"),
                P("Si te llevan a discutir si puedes poner un límite, repítelo con calma, sin añadir nuevas justificaciones. Después haz lo que dijiste, si es seguro. Puede que a alguien le moleste el límite y aun así sea importante. Si cambian las circunstancias, puedes revisarlo o pedir apoyo para mantenerlo.")
            ]),
        new(
            ArticleIds.NoWithoutEssay,
            "Puedes decir que no sin dar largas explicaciones",
            "Sé claro sin demostrar que tus motivos son suficientes",
            "TipsAndUpdates",
            2,
            [
                P("Decir que no puede decepcionar a alguien o provocar preguntas, y quizá temas que la relación empeore. Si negarte es seguro, basta con una frase clara. Puedes tener en cuenta a la otra persona y aun así rechazar la petición. Decide qué puedes ofrecer de verdad; no prometas algo que no quieres o no puedes hacer solo para aliviar la presión."),
                H("Elige una frase que te encaje"),
                P("Puedes decir: «Gracias por contar conmigo, pero esta vez no puedo», «Ahora mismo no tengo capacidad para esto» o «Ese momento no me viene bien». Si quieres, puedes proponer otra opción, pero no es obligatorio. Tampoco tienes que compartir todos tus motivos personales. Ser amable no significa ser ambiguo."),
                H("Responde a la insistencia"),
                P("Si la persona sigue preguntando, repite brevemente tu respuesta en vez de buscar un motivo nuevo cada vez. También puedes terminar la conversación o contestar más tarde. Si negarte directamente puede provocar amenazas, control o daño, prioriza tu seguridad: pide apoyo a alguien de confianza, elige una forma más segura de comunicarlo o aléjate si puedes.")
            ]),
        new(
            ArticleIds.DifficultTalkOpening,
            "Pon un objetivo pequeño a una conversación difícil",
            "Empieza por un hecho concreto y una petición",
            "TipsAndUpdates",
            2,
            [
                P("Un tema difícil puede convertirse enseguida en un juicio sobre toda la relación. Antes de hablar, anota un objetivo: ¿qué quieres aclarar, resolver o simplemente hacer saber? Después elige un episodio concreto y una petición. Si estás enfadado, agotado o tienes miedo, puedes esperar; no hace falta hablar de inmediato."),
                H("Describe lo ocurrido y su efecto"),
                P("Busca un momento en que ambos estén algo tranquilos y tengan tiempo. Explica qué observaste, cómo te afectó y qué cambio te gustaría probar. Por ejemplo: «Cuando los planes cambian a última hora, me cuesta organizar quién recoge a los niños. ¿Podemos avisarnos antes?». Evita atribuir intenciones con frases como «Siempre haces» o «No te importa»."),
                H("Deja espacio para responder"),
                P("Escucha cómo lo ha entendido la otra persona, aclara un malentendido o acuerden un siguiente paso posible. Si la conversación se calienta, pacta una pausa y cuándo retomarla. Si hablar directamente puede provocar violencia o represalias, no confíes en las técnicas de comunicación como protección: busca ayuda de alguien de confianza o de un servicio profesional.")
            ]),
        new(
            ArticleIds.RepairAfterConflict,
            "Retoma la conversación después de una discusión",
            "Comprueba si hay disposición y elige un punto para aclarar",
            "TipsAndUpdates",
            2,
            [
                P("Después de una discusión quizá quieras explicarlo todo enseguida o no volver a hablar del tema. Antes de intentar aclararlo, pregunta si la otra persona está dispuesta a hablar y comprueba también si tú te sientes preparado. La primera conversación puede tener un objetivo modesto: entender un episodio, no resolver toda la relación."),
                H("Céntrate en un momento concreto"),
                P("Describe lo ocurrido sin etiquetas ni suposiciones sobre las intenciones. Reconoce tu parte, si la hay, y pregunta cómo lo vio la otra persona. Escuchar su versión no significa estar de acuerdo automáticamente. Si las versiones difieren, aclara primero un hecho o el sentido de una frase, en vez de discutirlo todo a la vez."),
                H("Termina con cuidado"),
                P("Di qué ha quedado más claro y qué podría venir después: un pequeño acuerdo, otra conversación o tiempo para pensarlo. Si aumenta la tensión, acuerden una pausa. Si hay amenazas, intimidación o miedo, no busques reconciliarte a cualquier precio: termina la conversación, ve a un lugar seguro y pide apoyo.")
            ]),
        new(
            ArticleIds.ApologyResponsibility,
            "Discúlpate con responsabilidad y límites",
            "Nombra la acción concreta sin justificar su efecto",
            "TipsAndUpdates",
            2,
            [
                P("Una disculpa útil se centra en la acción y su efecto, no en demostrar que eres buena persona. Sé concreto: «Te interrumpí y no pudiste terminar». Reconoce el impacto y di que lo sientes sin añadir «pero tú también…». Puedes explicar tus intenciones aparte si la otra persona quiere escucharlo."),
                H("Propón una reparación realista"),
                P("Di qué intentarás hacer distinto la próxima vez y pregunta si alguna reparación pequeña serviría ahora. No prometas algo que no puedas cumplir. La otra persona no tiene que perdonarte ni tranquilizarte enseguida; dale tiempo y acepta su respuesta."),
                H("Responsabilizarte no exige renunciar a tu seguridad"),
                P("Puedes reconocer un error concreto y, a la vez, no aceptar insultos, presiones o acusaciones que consideras falsas. No uses la disculpa para conseguir perdón o retomar el contacto. Si la conversación deja de ser segura, termínala y guarda una distancia segura.")
            ]),
        new(
            ArticleIds.FeedbackAsInformation,
            "Separa los comentarios sobre tu trabajo de tu valor",
            "Busca información concreta, no una sentencia sobre ti",
            "TipsAndUpdates",
            2,
            [
                P("Un comentario sobre un resultado puede sonar como un juicio sobre toda tu persona, sobre todo si es inesperado o se expresa con dureza. Para y separa tres cosas: las palabras exactas, un hecho comprobable y la conclusión que sacaste sobre ti. «Al informe le falta un ejemplo» describe el trabajo; «no hago nada bien» es una generalización."),
                H("Aclara el comentario"),
                P("Si es vago, pide un ejemplo y pregunta qué cambio se podría observar. Elige un punto realista para probar en el próximo trabajo. No todas las formas de comunicar sirven: los insultos y la humillación no se vuelven constructivos por llamarlos comentarios."),
                H("Decide qué hacer después"),
                P("No tienes que responder de inmediato. Puedes anotar la parte útil, pensarla más tarde o consultar con alguien que conozca el contexto. Si el comentario contradice los hechos o un acuerdo, acláralo con calma. Un trabajo y una valoración no definen todas tus capacidades.")
            ]),
        new(
            ArticleIds.ReceiveNo,
            "Cuando alguien te dice que no",
            "Rechazar una petición no siempre es rechazarte",
            "TipsAndUpdates",
            2,
            [
                H("Aclara a qué se refiere la respuesta"),
                P("Un «no» puede referirse a una petición concreta, al momento o a una opción. No saques enseguida conclusiones sobre la relación o sobre tu valor si la persona no ha dicho eso. Si es apropiado, puedes preguntar con calma: «¿Quieres decir que ahora no te viene bien?»"),
                H("Respeta el límite"),
                P("Si la respuesta es clara, no conviertas la aclaración en presión. La otra persona puede negarse o no explicar el motivo. Tú puedes sentir decepción, hacer una pausa y decidir qué hacer después. Aceptar la respuesta no significa considerarla justa en todos los sentidos; significa no intentar conseguir el acuerdo presionando."),
                H("Busca otra opción"),
                P("Si la necesidad continúa, sepárala de esta fuente concreta de ayuda. Si la otra persona parece abierta, puedes preguntar una vez por otro momento o alternativa. Si no, piensa a quién más puedes acudir, qué parte puedes resolver por tu cuenta o si la tarea puede esperar."),
                H("Deja espacio a la decepción"),
                P("Nombra lo que sientes sin complicarlo: «Me decepciona; contaba con esa ayuda». No tienes que convencerte de que no importa ni calmarte enseguida. Cuando baje la primera reacción, revisa tus opciones y elige un paso. Que rechacen una petición no define tu valor."),
            ]),
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
        new(
            ArticleIds.AskSupport,
            "Pide apoyo diciendo qué te ayudaría",
            "Una petición concreta puede facilitar el comienzo",
            "TipsAndUpdates",
            2,
            [
                P("Pedir ayuda puede costar cuando ya lo estás pasando mal. Quizá temes que te rechacen, te juzguen o piensen que eres una carga. Empieza por identificar qué necesitas ahora: que te escuchen, pensar opciones juntos, ayuda práctica o simplemente no estar a solas. La petición puede ser pequeña y tener un límite de tiempo."),
                H("Di qué apoyo necesitas y cuándo"),
                P("Sé concreto: «Hoy ha sido difícil. ¿Puedes escucharme diez minutos sin dar consejos?» o «¿Me ayudas a pedir una cita? Me cuesta empezar». Pregunta si ahora le viene bien a la otra persona. Puede aceptar, decir que no o proponer otra opción. No necesitas contar toda la historia para justificar que pidas ayuda."),
                H("Si esta vez no puede"),
                P("Un no o un mal momento no siempre significa que no te valoren. Puedes preguntar a otra persona de confianza, buscar otro tipo de apoyo o hacer la petición más pequeña. Si hay peligro inmediato o no puedes mantenerte a salvo, no dependas de una sola persona cercana: recurre a servicios profesionales o de emergencia.")
            ]),
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
        new(
            ArticleIds.SmallConnection,
            "Empieza por un contacto pequeño",
            "No hace falta empezar con una conversación profunda",
            "TipsAndUpdates",
            2,
            [
                P("La soledad puede hacer que el primer paso parezca especialmente difícil. No tienes que volverte sociable de golpe ni encontrar enseguida una amistad íntima. Elige un contacto de poca presión: enviar una frase a alguien conocido, saludar a un vecino, estar cerca de otras personas en un lugar familiar o hablar de un tema neutral. Un paso pequeño es un intento, no un examen."),
                H("Adapta el contacto a tu energía"),
                P("Piensa qué suele resultarte más llevadero: un mensaje, una llamada breve, una actividad en grupo o simplemente un lugar público conocido. Puedes limitar el tiempo y pensar cómo irte si te cansas. Elige una persona y un entorno con menos presión. Si no recibes respuesta, no uses un solo momento para juzgar tu valor; prueba en otro momento o formato."),
                H("Observa qué te sienta bien"),
                P("Después, fíjate en qué fue cómodo, qué te quitó energía y cuánto tardaste en recuperarte. El objetivo no es contar conversaciones ni aguantar un entorno desagradable. Si la soledad interfiere durante mucho tiempo en tu vida o empeora tu bienestar, considera pedir apoyo a alguien de confianza o a un profesional.")
            ]),

        new(
            ArticleIds.OrientNow,
            "Comprueba dónde estás ahora",
            "Una forma suave de orientarte al presente",
            "TipsAndUpdates",
            2,
            [
                H("Oriéntate sin prisa"),
                P("Cuando la atención se va al pasado o a un futuro que preocupa, a veces ayuda notar lo que hay alrededor. No es una forma de obligarte a calmarte ni una prueba de concentración. El objetivo es más sencillo: observar algunos datos neutros del presente y después elegir dónde poner la atención."),
                H("Nombra datos sencillos"),
                P("Mantén los ojos abiertos si te resulta más cómodo. Mira alrededor y nombra el lugar donde estás, aproximadamente qué momento del día es y un objeto cercano. Puedes describir su color, forma o función. Después, observa otra referencia neutra: un sonido de fuera, una línea de la pared o la luz sobre una superficie. No hace falta buscarle un significado."),
                H("Adapta el ejercicio"),
                P("Elige solo observaciones que no te sobrecarguen. No tienes que enumerar muchos detalles, moverte, tocar nada ni prestar atención a la respiración. Puede bastar una frase: «Estoy aquí, es por la mañana y tengo una mesa delante». Si no te salen palabras, basta con mirar un objeto."),
                H("Comprueba si te viene bien"),
                P("Al cabo de unos segundos, pregúntate si todo se siente algo más claro, igual o más incómodo. Cualquier respuesta está bien. Si aumenta el malestar, para y elige algo que te resulte más seguro; puedes pedir a alguien de confianza que te acompañe. No tienes que conseguir calma ni continuar a la fuerza."),
            ]),
        new(
            ArticleIds.GroundingChoice,
            "Elige un anclaje que te venga bien",
            "No a todo el mundo le resulta cómodo enfocarse en el cuerpo",
            "TipsAndUpdates",
            2,
            [
                H("El anclaje es una opción, no una regla"),
                P("A menudo se llama anclaje a un ejercicio breve para notar el presente, pero no hay una única versión adecuada para todo el mundo. Algunas personas prefieren mirar objetos o escuchar un sonido; a otras les resulta incómodo centrarse en la respiración o el cuerpo. Puedes omitir cualquier método y parar cuando quieras."),
                H("Empieza por algo externo"),
                P("Elige un detalle sencillo cercano: nombra un color, busca un objeto con líneas rectas o describe para qué sirve. También puedes notar un sonido de fondo constante sin intentar averiguar de dónde viene. Quédate unos segundos con una sola referencia y después comprueba cómo te sientes."),
                H("Atiende al cuerpo solo si quieres"),
                P("Si te resulta cómodo, nota el apoyo de la silla, la posición de los pies o la tela de una manga. No hace falta recorrer todo el cuerpo, cambiar de postura ni cerrar los ojos. Si prestar atención al cuerpo trae dolor, entumecimiento, mucha tensión o recuerdos no deseados, déjalo y elige un objeto externo."),
                H("Conserva el derecho a cambiar"),
                P("Pregúntate: ¿esto es tolerable, neutro o me hace sentir peor? Si es tolerable, puedes seguir un poco. Si nada cambia, es información, no un fracaso. Si empeora, para. La meta no es garantizar alivio, sino elegir un apoyo adecuado sin presionarte."),
            ]),
        new(
            ArticleIds.AfterNightmare,
            "Después de una pesadilla, vuelve con calma al presente",
            "No tienes que interpretar ni repetir el sueño",
            "TipsAndUpdates",
            2,
            [
                P("Después de una pesadilla, el cuerpo puede seguir reaccionando como si el peligro continuara. No te exijas dormirte de inmediato ni entender el significado del sueño. Si te resulta cómodo, enciende una luz, mira alrededor y recuérdate: «Era un sueño; ahora estoy despierto». Puedes nombrar el lugar, la fecha de hoy o un objeto conocido. Si centrarte en el entorno o en el cuerpo aumenta el malestar, para y elige otra cosa."),
                H("Elige un paso tranquilo"),
                P("Siéntate cómodamente, bebe agua o haz algo tranquilo y conocido. Si ayuda, escribe a alguien de confianza; si no quieres despertar a nadie, puedes dejar una luz encendida. No tienes que anotar ni hablar del sueño durante la noche. Vuelve a la cama cuando te sientas preparado, sin seguir un horario rígido."),
                H("Si las pesadillas se repiten"),
                P("Observa solo lo que pueda servirte para hablar con un profesional, como la frecuencia y el efecto en el sueño y el día. No necesitas buscar por tu cuenta una explicación simbólica. Si las pesadillas alteran el descanso con frecuencia o se relacionan con una experiencia difícil, coméntalo con un profesional sanitario o de salud mental. Ante un peligro inmediato, prioriza la seguridad y la ayuda urgente.")
            ]),
        new(
            ArticleIds.AnniversaryReaction,
            "Una fecha difícil puede necesitar un plan más amable",
            "La reacción puede llegar antes, durante o después",
            "TipsAndUpdates",
            2,
            [
                P("Las fechas relacionadas con una pérdida, un cambio o un hecho doloroso pueden despertar reacciones distintas. El malestar puede aparecer antes, ese mismo día o después; algunas personas apenas notan una reacción. Ninguna de estas respuestas significa que estés afrontándolo «mal». No tienes que explicar a nadie por qué esa fecha es importante para ti."),
                H("Decide cómo quieres pasar el día"),
                P("Si puedes, deja menos compromisos y piensa de antemano a quién podrías escribir o llamar. Puedes recordar a alguien o algo a tu manera, hacer vida normal o no seguir ningún ritual. Prepara una alternativa por si el día se hace demasiado difícil: irte antes, hacer una pausa o pedir compañía."),
                H("Reserva tiempo para recuperarte"),
                P("Piensa qué te ayudaría después: una comida sencilla, dormir, una tarde libre o hablar con alguien cercano. No compares tus sentimientos con los de otras personas ni te obligues a conmemorar la fecha. Si el malestar afecta durante mucho tiempo a tu vida diaria, consulta con un profesional; si tu seguridad corre peligro inmediato, pide ayuda urgente.")
            ]),
        new(
            ArticleIds.PaceRecovery,
            "Recupérate a tu propio ritmo",
            "No conviertas el autocuidado en una maratón",
            "TipsAndUpdates",
            2,
            [
                H("Descansar no es otra tarea que completar"),
                P("Cuando las cosas cuestan, los consejos de autocuidado pueden convertirse en una larga lista de obligaciones. Si tienes poca energía, incluso una práctica útil puede sentirse como otra exigencia. Recuperarse no tiene que ser rápido ni igual cada día. Puedes elegir un apoyo pequeño o no añadir nada hoy."),
                H("Elige un mínimo posible"),
                P("Pregúntate qué está a tu alcance: beber agua, comer algo, apartar el móvil un momento, abrir una ventana o escribir a alguien de confianza. Elige una acción que encaje con tus circunstancias reales. No necesitas un temporizador ni una cuota si eso añade presión; los límites solo sirven si te ayudan a parar."),
                H("Observa el efecto sin ponerte nota"),
                P("Después, fíjate en qué cambió: ¿algo más fácil, igual o más difícil? No es una puntuación de tu disciplina. Si una práctica no te viene bien, déjala o elige otro tipo de apoyo. A veces lo útil es descubrir que necesitas silencio, comida, sueño, ayuda práctica o compañía."),
                H("Pide apoyo antes de agotarte"),
                P("Si durante un tiempo las tareas cotidianas siguen siendo muy difíciles, no hace falta esperar a poder con todo a solas. Cuéntale a alguien cercano qué se ha complicado o habla con un profesional sobre cómo te sientes. Pedir ayuda es un paso práctico, como descansar; no tienes que demostrar antes que lo intentaste todo."),
            ]),
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

        new(
            ArticleIds.BreathIsOptional,
            "La práctica de respiración es opcional",
            "No te obligues a cambiar la respiración",
            "TipsAndUpdates",
            2,
            [
                H("No tienes que centrarte en respirar"),
                P("Los ejercicios de respiración no son adecuados para todo el mundo ni hacen falta en cada momento difícil. Prestar atención a cada respiración puede aumentar la tensión o generar sensaciones desagradables. Puedes omitir la práctica, dejar que la respiración siga natural y elegir otro apoyo. Eso no significa que lo estés haciendo mal."),
                H("Si quieres probar"),
                P("Ponte cómodo y observa durante unos segundos tu respiración habitual, sin contar, retener el aire ni intentar inspirar más profundamente. Puedes fijarte en el movimiento de la ropa sobre el pecho solo si te resulta cómodo. Basta con probar un momento; no hay un ritmo ni una duración obligatorios."),
                H("Para si aparece malestar"),
                P("Si te mareas, aumenta la ansiedad, te falta el aire o te incomoda centrarte en respirar, detén el ejercicio y vuelve a tu respiración habitual. Cambia a una referencia externa, como un color u objeto. No intentes «corregir» la sensación respirando más hondo o reteniendo el aire."),
                H("Cuándo importa una valoración médica"),
                P("Esta práctica no identifica la causa de la falta de aire ni sustituye la atención médica. Una dificultad respiratoria nueva, importante o que empeora rápidamente requiere valoración; ante un empeoramiento grave y repentino o peligro inmediato, contacta con los servicios locales de emergencia. Si un profesional te indicó una técnica por motivos médicos, sigue sus instrucciones personalizadas."),
            ]),
        new(
            ArticleIds.GroundingCanChange,
            "Si el anclaje no ayuda",
            "Cambia de método o para",
            "TipsAndUpdates",
            2,
            [
                H("Que no funcione no es culpa tuya"),
                P("Puede que un ejercicio de anclaje no te venga bien ahora. No tiene por qué cambiar tu estado de ánimo enseguida, y no sentir alivio no significa que lo hayas hecho mal. A veces centrarse en sensaciones, respiración o recuerdos aumenta la ansiedad. Si ocurre, presta atención a tu respuesta en lugar de insistir."),
                H("Haz una pausa y vuelve a elegir"),
                P("Para si te sientes peor, mareado, desconectado o simplemente quieres parar. Abre los ojos si los tenías cerrados y mira un objeto neutro, solo si te resulta cómodo. No tienes que respirar hondo, contar sensaciones ni repetir pasos hasta obtener un resultado «correcto»."),
                H("Prueba una opción que requiera menos"),
                P("Si quieres continuar, elige una referencia externa más sencilla: lee un letrero, nombra un color o fíjate en dónde está la puerta. También puedes dejar los ejercicios y hacer una actividad cotidiana y tranquila. Evita probar varias técnicas seguidas si eso añade presión."),
                H("Cuándo puede ayudar otra persona"),
                P("Si te cuesta mantenerte a salvo por tu cuenta, contacta con alguien de confianza y dile qué necesitas: compañía, ayuda con algo práctico o apoyo para contactar con un profesional. Si hay peligro inmediato, llama a los servicios de emergencia locales. Puedes rechazar un ejercicio y seguir mereciendo apoyo."),
            ]),
        new(
            ArticleIds.MovementAnchor,
            "Usa el movimiento como apoyo",
            "Un movimiento pequeño puede devolverte opciones",
            "TipsAndUpdates",
            2,
            [
                H("Moverte es solo una opción"),
                P("Un movimiento pequeño puede servirte de apoyo si ahora resulta cómodo para tu cuerpo. No tiene que mejorar tu estado de ánimo ni parecer ejercicio. Puedes elegir una acción mínima, observar algo que se mueve o preferir un objeto quieto; todas son opciones válidas."),
                H("Elige una posición estable"),
                P("Primero asegúrate de estar sentado o de pie con seguridad, sin riesgo de perder el equilibrio. Si te resulta cómodo, abre y cierra los dedos despacio, gira suavemente las muñecas o nota el apoyo bajo los pies. Basta con un movimiento dentro de un rango cómodo; no necesitas estirarte, levantarte ni repetir un número concreto."),
                H("Observa cómo respondes"),
                P("Fíjate en lo que ocurre mientras te mueves. Si resulta neutro o agradable, puedes continuar unos segundos. Para si aparece dolor, mareo, debilidad o más ansiedad. No fuerces un síntoma por seguir una práctica; puedes cambiar a una referencia visual o pedir ayuda."),
                H("Termina sin juzgar el resultado"),
                P("Cuando quieras, deja de moverte y elige qué hacer después: descansar sentado, volver a una actividad habitual o contactar con alguien. No necesitas comparar tus movimientos actuales con los de antes. Si síntomas físicos nuevos o importantes dificultan el movimiento, consúltalo con un profesional sanitario."),
            ]),
        new(
            ArticleIds.SensesAnchor,
            "Un apoyo a través de los sentidos",
            "Elige una señal neutral de tu entorno",
            "TipsAndUpdates",
            2,
            [
                H("Una sola señal basta"),
                P("Cuando el entorno está lleno de estímulos, puedes elegir una sola señal neutral en vez de seguir una lista larga. Por ejemplo, observar un color, la forma de un objeto, un sonido constante o la temperatura del aire. No hace falta encontrar cinco cosas, cerrar los ojos ni usar todos los sentidos."),
                H("Elige algo tolerable"),
                P("La referencia debe resultarte suficientemente neutra. La luz intensa, el ruido, los olores o el contacto pueden distraerte o molestarte. Si una señal resulta desagradable, no te obligues a mantenerla. Puedes ir a un lugar más tranquilo, mirar un objeto familiar o dejar la práctica."),
                H("Adáptalo a lo que te resulta accesible"),
                P("Si mirar alrededor te cuesta, puedes nombrar mentalmente un objeto conocido o notar un sonido suave. Si el sonido distrae, elige una forma o un color. Si tienes limitaciones de visión, audición o movilidad, usa cualquier referencia accesible; no tienes que depender de la vista, el oído o el tacto en particular."),
                H("Comprueba si te viene bien ahora"),
                P("Quédate unos segundos con la referencia y pregúntate si te resulta más cómodo, igual o más difícil. No necesitas alcanzar un estado concreto. Si aumenta el malestar, cambia o para. Elegir otra señal no es un error: es una forma de respetar tus límites."),
            ]),
        MiniArticle(ArticleIds.EarlyStressSigns, "Observa las primeras señales de sobrecarga", "Notarlas antes te da más opciones", "Elige una señal temprana que hayas notado más de una vez, como tensión o menor atención. Anota brevemente cuándo suele aparecer y elige una respuesta: hacer una pausa, aclarar la tarea o pedir ayuda. Esto puede orientar tu planificación, pero no es un diagnóstico."),
        MiniArticle(ArticleIds.RelaxWithoutForce, "Relájate sin forzarte", "No tienes que alcanzar una calma total", "Elige una acción que requiera poca concentración: bajar los hombros, acomodarte o aflojar las manos. Deja la respiración natural. Un poco de comodidad basta; no fuerces al cuerpo a relajarse por completo. Si prestar atención al cuerpo aumenta el malestar, dirige la atención a algo del entorno."),
        MiniArticle(ArticleIds.BasicCareWithoutRules, "Cuidados básicos sin reglas estrictas", "Elige lo que necesitas ahora", "Elige una cosa que necesites durante la próxima hora y hazla pequeña: un vaso de agua, algo de comer, una prenda de abrigo o escribir a alguien. Si no está a tu alcance, nombra el obstáculo y pide ayuda concreta. No poder con todo a solas no es un fracaso personal."),
        new(
            ArticleIds.NewSymptomsCare,
            "Síntomas nuevos o poco habituales",
            "No te diagnostiques con un artículo",
            "TipsAndUpdates",
            2,
            [
                H("Valora primero la urgencia"),
                P("Un síntoma físico nuevo puede tener muchas causas y un artículo no puede determinar la tuya con fiabilidad. Si es intenso, empeora rápidamente o parece peligroso, no retrases la atención médica para hacer un ejercicio o buscar explicaciones en internet. Ante un peligro inmediato o un empeoramiento grave y repentino, contacta con los servicios de emergencia locales."),
                H("Anota lo que observas, si puedes hacerlo"),
                P("Para hablar con un profesional puede servir una nota breve: cuándo empezó, qué ha cambiado, con qué frecuencia ocurre y qué más has observado. Menciona los medicamentos y los cambios recientes si son relevantes. No tienes que buscar un diagnóstico por tu cuenta ni llevar un registro detallado si te supone demasiado esfuerzo."),
                H("Describe cómo afecta a tu día"),
                P("Fíjate en si el síntoma afecta al sueño, el movimiento, la alimentación, el trabajo o las actividades habituales. Explica qué te preocupa más y qué temes que pueda significar. Puedes preparar preguntas o pedir a alguien de confianza que te acompañe."),
                H("La autoayuda no sustituye una valoración médica"),
                P("Una actividad relajante puede acompañarte mientras organizas la atención, si te resulta cómoda, pero no identifica la causa del síntoma. Ante un empeoramiento repentino, dolor intenso, dificultad para respirar, pérdida del conocimiento u otra señal urgente, busca ayuda según las pautas locales. Si no sabes cuánta urgencia hay, contacta con un servicio sanitario y describe lo que ocurre."),
            ]),
        new(
            ArticleIds.FindTherapist,
            "Cómo elegir a un profesional para una primera cita",
            "Busca una forma de trabajo clara y segura",
            "TipsAndUpdates",
            2,
            [
                P("Empezar la búsqueda puede costar: los perfiles se parecen y no puedes saber de antemano si surgirá confianza. No hace falta encontrar a la persona perfecta a la primera. Comprueba primero aspectos prácticos: formación y habilitación pertinentes, experiencia con tu motivo de consulta, formato, coste y disponibilidad. Si la duda tiene que ver con la salud física o la medicación, pregunta qué profesional sanitario puede valorarla."),
                H("Haz preguntas prácticas"),
                P("Antes de reservar o en la primera cita, pregunta cómo suele organizarse el trabajo, cómo se acuerdan los objetivos y cómo puedes decir que el formato no te está ayudando. Confirma el coste, las cancelaciones, el contacto entre sesiones y cómo funciona la confidencialidad y cuáles son sus límites. No tienes que contar detalles personales por teléfono para conocer las condiciones."),
                H("Valora la colaboración con el tiempo"),
                P("Después de la cita, piensa si entendiste el proceso, pudiste preguntar y se respetaron tus límites. Sentirte incómodo al principio no demuestra por sí solo que el profesional no encaje; también importan la claridad y la seguridad. Si la relación de trabajo no mejora, puedes hablarlo o buscar a otra persona. Si hay peligro inmediato, no esperes a una cita ordinaria: pide ayuda urgente.")
            ]),
        new(
            ArticleIds.FirstAppointment,
            "En la primera cita basta con un ejemplo",
            "No tienes que contar toda tu historia perfectamente",
            "TipsAndUpdates",
            2,
            [
                P("Antes de la primera cita es fácil intentar preparar toda la historia y encontrar las palabras exactas. No es necesario. Si te ayuda, anota una situación reciente que muestre qué te preocupa y qué te gustaría cambiar. Puedes llevar la nota, leerla o pedir al profesional que te haga una pregunta cada vez."),
                H("Lleva las preguntas que te importan"),
                P("Puedes preguntar cómo serán las sesiones, qué es confidencial y en qué casos podrían compartir información, cómo se acuerdan los objetivos y qué hacer si empeoras entre citas. También puedes consultar el coste, la duración y las cancelaciones. No hace falta preguntarlo todo de una vez; empieza por lo más importante para ti."),
                H("Conserva la opción de parar"),
                P("Puedes decir que aún no quieres hablar de un tema, pedir que te expliquen una pregunta o hacer una pausa. La primera cita sirve para conocer el formato, no es una prueba de lo bien que cuentas tu historia. Después, piensa si te sentiste suficientemente seguro y si entendiste cómo se trabajaría. Puedes decidir más adelante si continúas.")
            ]),
        new(
            ArticleIds.DescribeSymptoms,
            "Describe lo que te ocurre con ejemplos reales",
            "Cuándo empezó, cómo se repite y cómo afecta tu día a día",
            "TipsAndUpdates",
            2,
            [
                P("No necesitas términos técnicos ni una explicación preparada para hablar de algo difícil. Empieza con un ejemplo reciente: qué pasaba, qué notaste y qué se volvió más difícil. Puedes decir «no estoy seguro» o «todavía no sé explicarlo mejor». La idea es comprenderlo juntos, no adivinar un diagnóstico de antemano."),
                H("Reúne algunos datos útiles"),
                P("Si lo recuerdas, anota cuándo empezó, con qué frecuencia ocurre, cuánto dura y en qué situaciones cambia. Cuenta cómo afecta al sueño, los estudios, el trabajo, las relaciones o el cuidado personal. Añade qué has probado y qué ayudó un poco o empeoró las cosas. No hace falta llevar un diario detallado si resulta agotador."),
                H("Prepara preguntas e información relevante"),
                P("Puedes anotar medicamentos, cambios de salud u otros detalles que quizá estén relacionados; si no lo sabes, pregunta al profesional qué información sirve. No cambies un tratamiento por lo que diga un artículo o cuestionario. Los síntomas físicos nuevos o intensos requieren valoración sanitaria; ante un peligro inmediato, busca ayuda urgente.")
            ]),
        new(
            ArticleIds.SelfHelpLimits,
            "Cuando la autoayuda no basta",
            "El apoyo profesional es un siguiente paso válido",
            "TipsAndUpdates",
            2,
            [
                H("Observa si la dificultad se mantiene"),
                P("La autoayuda puede servir para dificultades cotidianas, pero no tiene que resolverlo todo. El apoyo profesional puede ser útil si la situación afecta durante bastante tiempo al sueño, el trabajo, los estudios, las relaciones o el autocuidado; si empeora; o si cada vez dejas más actividades importantes. No hace falta esperar a que sea insoportable."),
                H("No necesitas tener un diagnóstico"),
                P("Basta con explicar qué ha cambiado y desde cuándo. Según lo que tengas disponible, puedes empezar por un profesional de atención primaria, un psicólogo u otro profesional cualificado. Si no sabes a quién acudir, pregunta a un servicio sanitario cuál podría ser el primer paso."),
                H("Prepara un resumen breve"),
                P("Antes de hablar, apunta algunos datos: qué te preocupa más, cuándo empezó, cómo afecta a tu vida diaria y qué has probado. Añade preguntas sobre las opciones de apoyo. No tienes que contarlo todo de una vez; puedes pedir que te expliquen los términos y acordar un siguiente paso."),
                H("Pedir ayuda ya es una acción"),
                P("No tienes que demostrar que te has esforzado bastante por tu cuenta. Si te cuesta pedir cita o iniciar la conversación, pide a alguien cercano que te ayude a encontrar un contacto o que te acompañe. Si hay peligro inmediato para ti o para otra persona, contacta con los servicios de emergencia locales."),
            ]),

        new(
            ArticleIds.ScreeningNotDiagnosis,
            "Un cuestionario no es un diagnóstico",
            "El resultado puede iniciar una conversación, no ponerte una etiqueta",
            "TipsAndUpdates",
            2,
            [
                H("Qué puede mostrar un resultado"),
                P("Un cuestionario reúne respuestas sobre cómo te has sentido durante un periodo concreto y ante unas preguntas determinadas. La puntuación puede sugerir temas para conversar, pero por sí sola no explica la causa de lo que sientes. Los acontecimientos recientes, la salud, el sueño y la interpretación de las preguntas pueden influir en las respuestas."),
                H("Qué no puede establecer una puntuación"),
                P("El resultado no confirma ni descarta un diagnóstico y no sustituye una conversación con un profesional. Los umbrales o colores pertenecen a esa herramienta; no son un juicio definitivo sobre ti. Una puntuación alta no define qué «te pasa», y una baja no invalida dificultades que afectan a tu vida."),
                H("Úsalo como nota para hablar"),
                P("Si el resultado te preocupa, guárdalo con la fecha y piensa qué ocurría durante ese periodo. Puedes anotar qué preguntas te llamaron la atención y qué quieres consultar con un profesional. No hace falta repetir el cuestionario muchas veces para obtener una cifra concreta."),
                H("No cambies la atención por una puntuación"),
                P("No empieces, suspendas ni cambies un tratamiento basándote solo en una puntuación de la aplicación. Consulta tus dudas con un profesional cualificado que pueda considerar las respuestas en contexto. Si tu estado empeora de repente o hay peligro inmediato, no esperes a repetir el cuestionario: busca ayuda urgente."),
            ]),
        MiniArticle(ArticleIds.SupportPlan, "Prepara un plan breve de apoyo", "Anota señales, pasos y contactos", "Escribe cómo notas que empeoras, qué suele ayudarte y a quién puedes avisar. Añade contactos profesionales y servicios locales de emergencia. El plan no sustituye la ayuda; indica a quién llamar cuando cuesta pensar. Comprueba antes si los contactos están disponibles en tu zona."),
        MiniArticle(ArticleIds.CrisisSteps, "Si ahora mismo no estás a salvo", "Conecta con ayuda en tiempo real", "Ve a un lugar más seguro si es posible y contacta con emergencias locales o alguien de confianza. Di brevemente qué ocurre y dónde estás. No te quedes a solas si hay peligro inmediato. Si te cuesta llamar, pide a alguien que te acompañe en la llamada."),
        MiniArticle(ArticleIds.MedicationWithClinician, "Consulta con un profesional las dudas sobre medicación", "No cambies una receta por tu cuenta", "Si te preocupa una medicación, anota el nombre, la pregunta y cualquier efecto no deseado y coméntalo con quien la recetó o con un farmacéutico. No empieces, suspendas ni cambies dosis basándote en una app o artículo. Revisa el prospecto o consulta a una farmacia; las indicaciones varían."),
        new(
            ArticleIds.DeadlineConversation,
            "Si no llegarás al plazo, avisa pronto",
            "Comparte los hechos, una estimación realista y opciones",
            "TipsAndUpdates",
            2,
            [
                P("Cuando un plazo corre peligro, la preocupación puede llevarte a callar hasta el final o a prometer más de lo que puedes cumplir. Un aviso breve resulta más útil cuando aún hay opciones. Antes de escribir, comprueba qué está terminado, qué falta y qué depende de ti o de circunstancias externas. No hace falta ocultar el retraso ni justificarte con una historia larga."),
                H("Propón opciones viables"),
                P("Explica la situación y una fecha realista: «El borrador está listo; revisaré todo en dos días». Propón alternativas: ampliar el plazo, reducir el alcance, entregar ahora una parte terminada o acordar una revisión intermedia. Si aún no puedes calcularlo bien, dilo y fija cuándo podrás dar una estimación mejor."),
                H("Confirma lo acordado"),
                P("Aclara qué opción se eligió, quién debe saberlo y cuándo informarás del avance. No prometas una fecha que dependa de dejar de dormir o abandonar otras necesidades importantes. Si los retrasos se repiten, revisa por separado la causa: el tamaño de la tarea, los recursos o prioridades poco claras. Así puedes ajustar la planificación sin culparte.")
            ]),
        new(
            ArticleIds.DifficultMessageReply,
            "Haz una pausa antes de responder a un mensaje difícil",
            "Decide primero qué quieres conseguir con tu respuesta",
            "TipsAndUpdates",
            2,
            [
                P("Un mensaje brusco o ambiguo puede hacer que quieras contestar de inmediato. Si no hay una necesidad práctica urgente, date tiempo. Separa las palabras exactas de lo que has supuesto sobre la intención: un texto puede sonar frío, pero por sí solo no siempre explica el motivo. Espera a saber qué quieres conseguir con la respuesta."),
                H("Elige el objetivo y el formato"),
                P("Puedes querer aclarar un hecho, marcar un límite, comunicar una decisión o aplazar la conversación. Escribe un borrador y quita lo que solo vaya a aumentar la discusión. Por ejemplo: «He visto tu mensaje. Mañana te respondo a esa pregunta» o «Puedo hablar de esto sin insultos». Para un tema complejo, quizá sea mejor llamar o hablar en persona que seguir escribiendo, si es seguro."),
                H("Cuídate y guarda lo importante"),
                P("Si el mensaje incluye amenazas, acoso o coacción, no tienes que responder ni mantener el contacto. Guarda la información que puedas necesitar, usa las opciones para bloquear o denunciar y pide apoyo. Si hay una amenaza inmediata, ve a un lugar más seguro y contacta con emergencias o con alguien de confianza.")
            ]),
        new(
            ArticleIds.CancelPlans,
            "Cancela los planes con claridad y cuidado",
            "Avisa pronto y comparte solo lo que quieras",
            "TipsAndUpdates",
            2,
            [
                P("A veces hay que cambiar los planes por salud, circunstancias o falta de energía. Avísale a la otra persona en cuanto puedas, sobre todo si ya cuenta con el encuentro. Basta una frase clara: «Hoy tengo que cancelar». Puedes reservarte el motivo; un mensaje breve no es descortés por no incluir una larga explicación."),
                H("Propón otra fecha si de verdad quieres"),
                P("Si realmente quieres veros más adelante, sugiere un día concreto o pregunta cuándo le viene bien. No prometas otra fecha por culpa si no sabes si podrás cumplirla. Reconoce el inconveniente práctico, si lo hay: «Sé que te habías reservado la tarde». La otra persona puede sentirse decepcionada o no querer cambiar la fecha."),
                H("Prioriza la seguridad y el bienestar"),
                P("Si cancelas porque la situación no es segura, no tienes que mantener el plan por comodidad de otra persona. Elige una forma de avisar que no aumente el riesgo; a veces es más seguro enviar un mensaje breve o pedir ayuda a alguien de confianza. Si cancelas a menudo y te preocupa, piensa sin reproches qué lo está dificultando.")
            ]),
    ];
}
