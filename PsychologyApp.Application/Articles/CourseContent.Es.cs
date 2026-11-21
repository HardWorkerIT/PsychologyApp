using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Articles;

public static partial class ArticleContent
{
    private static readonly Course[] CoursesEs =
    [
        new(
            CourseIds.Sleep,
            "Dormir sin pastillas",
            "Siete días de terapia cognitivo-conductual del insomnio, la forma mejor estudiada de recuperar el sueño",
            "Bedtime",
            "isi",
            "ISI-7",
            [
                new(
                    "Cómo funciona el sueño",
                    4,
                    [
                        P("El sueño no se «enciende» a base de esfuerzo. Lo preparan dos fuerzas: la presión de sueño, que se acumula durante todo el día mientras estás despierto, y el reloj interno, que nos da sueño y nos despierta a las mismas horas cada día."),
                        P("En el insomnio, las dos fuerzas se desajustan: la persona se acuesta antes para «recuperar», pasa mucho rato despierta, duerme siesta, se levanta a horas distintas. La presión de sueño no tiene tiempo de acumularse y el reloj se confunde."),
                        Cycle("El ciclo del insomnio", "Una mala noche", "Preocupación: «otra vez no voy a dormir»", "Esforzarse por dormir", "La tensión aleja el sueño"),
                        P("Este curso se basa en la terapia cognitivo-conductual del insomnio (TCC-I). Las guías médicas la recomiendan en primer lugar, antes que las pastillas para dormir: su efecto dura después de terminar el curso."),
                        Warning("Cuándo consultar primero a un médico"),
                        List(
                            "Ronquidos fuertes, pausas en la respiración durante el sueño, mucho sueño durante el día",
                            "Sensaciones desagradables en las piernas por la tarde que te obligan a moverte",
                            "Insomnio junto con ánimo bajo durante más de dos semanas",
                            "Conduces o manejas maquinaria y tienes mucho sueño durante el día")
                    ],
                    "Cada mañana apunta: cuándo te acostaste, más o menos cuándo te dormiste, cuántas veces te despertaste, cuándo te levantaste y cómo dormiste de 0 a 10. Sin mirar el reloj por la noche, aproximadamente, a ojo.",
                    "¿A qué hora sueles acostarte y levantarte? ¿Qué es lo que más estorba tu sueño?"),
                new(
                    "La cama es para dormir",
                    4,
                    [
                        P("Si a menudo te quedas despierto en la cama, te preocupas o miras el móvil ahí, el cerebro asocia la cama con estar despierto. Por eso puedes dormirte en un sillón y estar completamente despierto en cuanto te acuestas."),
                        H("Reglas que recuperan la asociación"),
                        List(
                            "Acuéstate solo cuando tengas sueño, no simplemente cansancio",
                            "Si llevas unos 20 minutos sin dormir, levántate y haz algo tranquilo con luz tenue. Vuelve cuando tengas sueño",
                            "La cama es solo para dormir y la intimidad: sin móvil, sin series y sin trabajo",
                            "Levántate a la misma hora cada día, incluso después de una mala noche y los fines de semana",
                            "No duermas siesta y, si de verdad lo necesitas, no más de 20 minutos y antes de las 15:00"),
                        Quiz("La noche fue mala. ¿Qué es mejor por la mañana?", 1, "Una hora fija para levantarse es el ancla principal del sueño. Si te quedas en la cama más tiempo, por la noche habrá menos presión de sueño y la noche siguiente también será difícil.", "Quedarse durmiendo para recuperarse", "Levantarse a la hora de siempre", "Levantarse y echar una buena siesta durante el día")
                    ],
                    "Elige una hora para levantarte que puedas mantener los siete días y levántate a esa hora. Si llevas unos 20 minutos sin dormir, sal de la cama.",
                    "¿Qué hora de levantarte elegiste? ¿Qué te costó de la regla «levantarse si no duermes»?"),
                new(
                    "La ventana de sueño",
                    5,
                    [
                        P("Cuanto más tiempo pasa una persona despierta en la cama, más ligero y entrecortado se vuelve el sueño. Ayuda una técnica llamada compresión del sueño: el tiempo en la cama se acerca a lo que realmente duermes."),
                        H("Cómo calcular la ventana"),
                        List(
                            "Con tus notas de los últimos días, calcula cuánto duermes de media",
                            "Suma 30 minutos: ese es tu tiempo en la cama, pero nunca menos de seis horas",
                            "Cuéntalo hacia atrás desde la hora de levantarte que elegiste: así obtienes tu hora de acostarte",
                            "No te acuestes antes de esa hora, aunque tengas muchas ganas"),
                        P("Los primeros días tendrás sueño: significa que la presión de sueño se está acumulando. Pasada una semana, si duermes la mayor parte del tiempo en la cama, la ventana se puede ampliar 15 minutos."),
                        Warning("Ten cuidado"),
                        P("No comprimas el sueño si tienes trastorno bipolar o epilepsia, si estás embarazada o si el sueño hace que conducir o trabajar sea peligroso. En estos casos, habla del sueño con un médico.")
                    ],
                    "Calcula tu ventana de sueño y mantenla hasta el final del curso: nada de cama antes de tu hora de acostarte, levantarse a la misma hora.",
                    "¿Cuál es tu ventana de sueño? ¿Cómo fue la primera noche con ella?"),
                new(
                    "Una tarde que prepara para dormir",
                    4,
                    [
                        P("El sueño llega con más facilidad cuando el cuerpo y la mente tienen tiempo de bajar el ritmo. La hora antes de acostarse es el puente entre el día y el sueño."),
                        H("Qué ayuda"),
                        List(
                            "Una hora antes de acostarte: luz tenue y actividades tranquilas sin pantallas",
                            "Evita el café, el té fuerte y las bebidas energéticas al menos 6 horas antes de acostarte; si afectan a tu sueño, prueba a dejarlos antes",
                            "El alcohol ayuda a dormirse pero hace el sueño superficial y despierta de madrugada",
                            "Una cena pesada 2–3 horas antes de acostarte",
                            "Por la mañana, luz del día durante al menos 15 minutos: ajusta el reloj interno"),
                        P("Plan de un minuto: elige cuándo empezarás a desconectar y una actividad tranquila, como leer unas páginas. Si no dispones de una hora, elige antes una versión más corta. Por ejemplo: «Después de mis tareas de la tarde, bajaré la luz y leeré un poco»."),
                        H("Relajarse antes de dormir"),
                        P("La respiración lenta con una exhalación larga baja la activación. Pruébalo ahora."),
                        Breathe("Inhala contando 4, exhala contando 6")
                    ],
                    "Prueba tu plan esta noche: reserva tiempo para actividades tranquilas antes de acostarte cuando puedas y usa la versión corta si no tienes una hora. Deja el móvil fuera de la cama manteniendo los avisos importantes.",
                    "¿Qué incluiste en tu ritual de la tarde? ¿Qué resultó difícil?"),
                new(
                    "Pensamientos que no dejan dormir",
                    4,
                    [
                        P("La mente suele ponerse a trabajar justo en la cama: durante el día no hubo tiempo para pensar. Por eso ayuda darles tiempo antes."),
                        H("Un tiempo para los pensamientos"),
                        List(
                            "Por la tarde, un par de horas antes de acostarte, reserva 15 minutos",
                            "Escribe todo lo que te preocupa y, para cada punto, un próximo paso o «por ahora no puedo hacer nada»",
                            "Si el pensamiento vuelve en la cama, dite: «ya lo he apuntado, me ocuparé de ello mañana»"),
                        Quiz("En la cama piensas: «Si no duermo, mañana me saldrá todo mal.» ¿Qué se acerca más a la verdad?", 1, "El pensamiento exagera. Después de una mala noche cuesta más, pero la mayoría de las personas sacan adelante sus tareas. Cuanto mayor es el miedo al día siguiente, más cuesta dormirse.", "Es verdad, el fracaso es inevitable", "Después de una mala noche cuesta más, pero normalmente saco adelante lo principal", "Mejor no acostarse"),
                        Practice(TechniqueId.ThoughtDefusion, "Tomar distancia de un pensamiento")
                    ],
                    "Cada tarde, reserva 15 minutos para escribir lo que te preocupa, y no te lleves esos pensamientos a la cama.",
                    "¿Qué pensamientos aparecen con más frecuencia por la noche? ¿Te ayudó escribirlos?"),
                new(
                    "Dejar de luchar contra el sueño",
                    4,
                    [
                        P("Cuanto más intentas dormir, peor sale. El sueño es como un pájaro tímido: llega cuando nadie lo persigue."),
                        H("Qué ayuda a soltar el control"),
                        List(
                            "Pon el reloj fuera de la vista: contar «quedan cinco horas» despierta",
                            "Permítete no dormir: «me quedo aquí tumbado descansando, el sueño vendrá cuando venga»",
                            "Una mala noche no es una catástrofe: el cuerpo se recupera incluso con un sueño incompleto",
                            "No canceles planes por una mala noche: así el insomnio no dirige tu vida"),
                        P("Compara tus notas de los primeros días con las de ahora: ¿cómo han cambiado el tiempo que tardas en dormirte, el número de despertares y la valoración del sueño?")
                    ],
                    "Por la noche, mantén el reloj fuera de la vista. Después de una mala noche, vive el día como siempre.",
                    "Según tus notas, ¿qué ha cambiado en tu sueño en estos días?"),
                new(
                    "Resumen y plan",
                    4,
                    [
                        P("En una semana has recorrido el núcleo de la TCC del insomnio. El sueño se recupera poco a poco: muchas personas notan una mejora en dos a cuatro semanas si mantienen las reglas."),
                        H("Qué seguir haciendo"),
                        List(
                            "Una misma hora de levantarse cada día",
                            "Acostarse solo con sueño y levantarse si no duermes",
                            "Si duermes la mayor parte de la noche, ampliar la ventana 15 minutos por semana",
                            "El ritual de la tarde y el tiempo para los pensamientos"),
                        H("Si el insomnio vuelve"),
                        P("Después de estrés, una enfermedad o un viaje, el sueño puede volver a desajustarse. Es normal: vuelve a las reglas de este curso y se recuperará más rápido que la primera vez."),
                        P("Vuelve a hacer el índice ISI-7 y compáralo con tu resultado del principio. Si no hay mejora, consulta a un médico: hay especialistas en sueño que aplican la TCC-I."),
                        TestsTab("Índice ISI-7", "isi")
                    ],
                    "Escribe tu plan para si el sueño vuelve a desajustarse.",
                    "¿Qué te ayudó más del curso? ¿Qué vas a seguir haciendo?")
            ]),
        new(
            CourseIds.Anxiety,
            "La ansiedad bajo control",
            "Seis días: entender cómo funciona la ansiedad, calmar el cuerpo, comprobar los pensamientos que asustan y dar un primer paso hacia el miedo",
            "Psychology",
            "gad7",
            "GAD-7",
            [
                new(
                    "Cómo funciona la ansiedad",
                    4,
                    [
                        P("La ansiedad es una alarma pensada para avisar del peligro. El problema empieza cuando suena demasiado a menudo, demasiado fuerte y tarda mucho en apagarse."),
                        Cycle("El ciclo de la ansiedad", "Un pensamiento que asusta", "Ansiedad en el cuerpo", "Evitación o una muleta", "Alivio por un momento", "El cerebro aprende: «era peligroso»"),
                        P("Lo que mantiene la ansiedad no es el miedo en sí, sino lo que hacemos para no sentirlo: evitar, volver a comprobar, buscar que nos tranquilicen, darle vueltas a los pensamientos. Paso a paso, el curso trabaja cada eslabón de este ciclo."),
                        P("Al principio del curso vale la pena hacer la escala GAD-7: al final compararás el resultado."),
                        TestsTab("Escala GAD-7", "gad7")
                    ],
                    "Hoy, tres veces, cuando sientas ansiedad, fíjate en: qué pasó, cuál fue el pensamiento, qué sintió el cuerpo y qué hiciste.",
                    "¿Cuándo y dónde aparece la ansiedad con más frecuencia?"),
                new(
                    "Calmar el cuerpo",
                    4,
                    [
                        P("Cuando la ansiedad es alta, cuesta discutir con los pensamientos. Primero ayuda calmar el cuerpo: una exhalación lenta activa el sistema que frena la reacción de lucha o huida."),
                        Breathe("Inhala contando 4, exhala contando 6"),
                        P("Si la ansiedad es fuerte y todo parece irreal, devuelve la atención al presente a través de los sentidos."),
                        Practice(TechniqueId.Grounding, "Anclaje 5-4-3-2-1"),
                        P("Importante: la respiración no es una forma de librarse de la ansiedad a toda costa. Ayuda a atravesar el pico, no a evitar situaciones.")
                    ],
                    "Dos veces al día, dos minutos de respiración lenta, incluso estando tranquilo: así la habilidad estará ahí cuando la necesites.",
                    "¿Qué notaste en el cuerpo al respirar despacio?"),
                new(
                    "Comprobar un pensamiento que asusta",
                    5,
                    [
                        P("Los pensamientos ansiosos suenan a hechos: «voy a hacer el ridículo», «va a pasar algo terrible». Pero son predicciones, y se pueden comprobar."),
                        H("Preguntas para hacerle al pensamiento"),
                        List(
                            "¿Qué hechos apoyan este pensamiento y cuáles van en contra?",
                            "¿Qué pasó en casos parecidos antes?",
                            "¿Qué es lo más probable, en lugar de lo más aterrador?",
                            "Si pasa lo peor, ¿cómo lo afrontaré?",
                            "¿Qué le diría a un amigo con este pensamiento?"),
                        Quiz("«Seguro que lo voy a estropear.» ¿Qué trampa del pensamiento es?", 1, "Es adivinar el futuro: el pensamiento trata como un hecho algo que todavía no ha pasado.", "Leer la mente", "Adivinar el futuro", "Descalificar lo positivo"),
                        Practice(TechniqueId.ThoughtRecord, "Registro de pensamientos")
                    ],
                    "Hoy, una vez, comprueba un pensamiento ansioso con un registro de pensamientos.",
                    "¿Qué pensamiento comprobaste? ¿Cuánto lo creías antes y después?"),
                new(
                    "El tiempo para preocuparse",
                    4,
                    [
                        P("Preocuparse parece útil: «si pienso más, estaré preparado». En realidad, darle vueltas rara vez lleva a una solución y mantiene alta la ansiedad."),
                        Quiz("¿Cómo distinguir resolver de dar vueltas?", 0, "Resolver avanza hacia un paso: qué puedo hacer y cuándo. Dar vueltas produce nuevos «y si».", "Resolver termina en un paso; dar vueltas, en un nuevo «y si»", "Dar vueltas lleva más tiempo", "No se puede"),
                        H("Cómo aplazar la preocupación"),
                        List(
                            "Elige 15–20 minutos al día, no antes de dormir",
                            "Cuando aparezca una preocupación en otro momento, apunta el tema en una línea y dite: «pensaré en esto en mi tiempo para preocuparme»",
                            "En tu tiempo para preocuparte, repasa la lista: planifica un paso para lo que puedes hacer y suelta lo que no",
                            "A menudo, a la hora fijada, el tema ya no parece importante"),
                        Practice(TechniqueId.ThoughtDefusion, "Tomar distancia de un pensamiento"),
                        P("Si vuelves a abrir las noticias para sentir más seguridad, anota la pregunta concreta y decide si tienes que actuar ahora. Si no, elige cuándo volverás a consultarlas."),
                        See(ArticleIds.NewsLoop, "Cuando las noticias no te dejan desconectar")
                    ],
                    "Fíjate un tiempo para preocuparte y aplaza a él los pensamientos ansiosos.",
                    "¿Conseguiste aplazar la preocupación? ¿Qué pasó con los temas a la hora fijada?"),
                new(
                    "Muletas y evitación",
                    4,
                    [
                        P("Lo que más mantiene la ansiedad es la evitación. Puede ser abierta (no voy, no llamo) u oculta: muletas que ayudan a atravesar una situación."),
                        Check("¿Tengo muletas?", 2, "Tienes varias muletas. Mantienen el miedo: el cerebro cree que todo salió bien solo gracias a ellas. Intenta renunciar a una en una situación fácil.", "Tienes pocas muletas. Fíjate también en lo que evitas por completo.", "Llevo una pastilla, agua o el móvil cargado «por si acaso»", "Solo voy acompañado a los lugares difíciles", "Me siento cerca de la salida", "Me distraigo para no notar la ansiedad", "Compruebo o vuelvo a preguntar muchas veces"),
                        P("La salida es encontrarse poco a poco con lo que temes y prescindir de las muletas. Así el cerebro aprende por experiencia que lo temido no ocurre o se puede soportar.")
                    ],
                    "Haz una lista de tres a cinco situaciones que evitas, de la más fácil a la más difícil.",
                    "¿Qué situación de la lista estás dispuesto a probar primero?"),
                new(
                    "El primer paso y un plan",
                    4,
                    [
                        P("La forma más eficaz de debilitar la ansiedad es la exposición: encontrarse poco a poco con el miedo. No hace falta ir directamente a lo más aterrador: empieza con un paso fácil y comprueba una predicción."),
                        List(
                            "Antes del paso, apunta qué temes y cuánto crees que va a pasar",
                            "Da el paso sin muletas y quédate en la situación hasta haber comprobado la predicción",
                            "Después, apunta qué pasó en realidad"),
                        Ladder("Escalera del miedo"),
                        H("Qué seguir haciendo"),
                        List(
                            "La respiración lenta en el pico de la ansiedad",
                            "Comprobar los pensamientos y el tiempo para preocuparse",
                            "Pasos en la escalera del miedo cada pocos días"),
                        P("Vuelve a hacer la escala GAD-7 y compárala con el principio. Si la ansiedad es fuerte o afecta a tu vida, acude a un psicoterapeuta: la TCC de la ansiedad está bien estudiada."),
                        TestsTab("Escala GAD-7", "gad7")
                    ],
                    "Da el primer paso en tu escalera del miedo y apunta qué pasó.",
                    "¿Qué habías predicho y qué pasó en realidad?")
            ]),
        new(
            CourseIds.Mood,
            "Salir de la apatía",
            "Seis días de activación conductual: pequeños pasos para recuperar la energía y lo que da alegría",
            "Cloud",
            "phq9",
            "PHQ-9",
            [
                new(
                    "El ciclo de la inactividad",
                    4,
                    [
                        P("Cuando el ánimo está a cero, es natural hacer menos: no hay fuerzas, nada apetece. Pero cuanto menos hacemos, menos hay en la vida que dé alegría y la sensación de «lo he conseguido», y el ánimo baja todavía más."),
                        Cycle("El ciclo de la inactividad", "Sin fuerzas", "Hago menos", "Menos alegría y logros", "Aún menos fuerzas"),
                        P("La activación conductual rompe este ciclo por el otro lado: no esperar a tener ganas, sino dar pequeños pasos después de los cuales las fuerzas y las ganas vuelven poco a poco. Es uno de los métodos de ayuda mejor estudiados para la depresión."),
                        P("Haz la escala PHQ-9 al principio del curso: al final compararás el resultado."),
                        TestsTab("Escala PHQ-9", "phq9"),
                        Warning("Si aparecen pensamientos sobre la muerte"),
                        P("Si tienes pensamientos de que estaría mejor que no existieras, no te quedes solo con ellos: este curso no sustituye la ayuda de un especialista."),
                        Crisis("Necesito ayuda ahora")
                    ],
                    "Hoy y mañana, fíjate en lo que haces y valora tu ánimo de 0 a 10 varias veces al día.",
                    "¿Cómo van tus días ahora? ¿Qué has dejado de hacer últimamente?"),
                new(
                    "Qué te sube el ánimo",
                    4,
                    [
                        P("Mira tus observaciones: ¿en qué momentos el ánimo estuvo un poco más alto? A menudo es algo pequeño: una conversación, un paseo, una ducha, una tarea hecha."),
                        H("Dos tipos de actividades útiles"),
                        List(
                            "Las agradables: lo que da placer, aunque sea poco — música, comida rica, el sol",
                            "Las de «lo he conseguido»: lo que deja sensación de logro — fregar los platos, contestar un correo"),
                        P("En la depresión, el placer de las cosas agradables es más débil que antes. Es normal: lo que importa es hacerlo, no esperar la alegría de antes.")
                    ],
                    "Haz una lista de diez actividades: cinco agradables y cinco de «lo he conseguido». Cuanto más pequeñas y sencillas, mejor.",
                    "¿Qué incluiste en tu lista? ¿Hubo algo que te subiera un poco el ánimo?"),
                new(
                    "Pasos pequeños",
                    4,
                    [
                        P("Los grandes planes asustan en la apatía y no se llevan a cabo. Ayuda dividir las cosas: no «limpiar el piso», sino «quitar tres cosas de la mesa»."),
                        List(
                            "Elige una actividad de la lista para hoy",
                            "Divídela hasta un paso que lleve cinco minutos",
                            "Fija un momento y un lugar: «después del desayuno, en la cocina»",
                            "Después, apunta cómo cambió tu ánimo"),
                        Practice(TechniqueId.SmallStep, "Un pequeño paso"),
                        P("El objetivo no es que el ánimo suba de inmediato. Si sigue igual, fíjate en si la actividad era asumible y ajusta el siguiente paso."),
                        See(ArticleIds.SmallStepReview, "Si un pequeño paso no mejora el ánimo")
                    ],
                    "Cada día, haz una actividad agradable y una de «lo he conseguido» a la hora que fijaste.",
                    "¿Qué conseguiste hacer? ¿Cómo cambió tu ánimo después?"),
                new(
                    "«No me apetece»",
                    4,
                    [
                        P("El principal obstáculo es el pensamiento «no me apetece, lo haré cuando tenga fuerzas». En la apatía, las ganas llegan después de la acción, no antes."),
                        Quiz("No tienes fuerzas y hoy tenías planeado un paseo. ¿Qué es mejor?", 1, "En la apatía, las ganas vuelven después de la acción. Incluso cinco minutos le dan al cuerpo y al ánimo la señal «he hecho algo».", "Esperar a que me apetezca", "Salir al menos cinco minutos", "Dejarlo para el fin de semana"),
                        H("Otros pensamientos que frenan"),
                        List(
                            "«No sirve de nada»: compruébalo después — ¿ha cambiado algo, aunque sea un poco?",
                            "«Es demasiado poco»: precisamente de pasos pequeños está hecha la salida",
                            "«Antes hacía más»: compárate con ayer, no con quien eras antes"),
                        Practice(TechniqueId.SelfCompassion, "Palabras amables para ti")
                    ],
                    "Cuando no te apetezca, haz al menos una versión de cinco minutos de lo que planeaste.",
                    "¿Qué pensamiento te impide empezar con más frecuencia? ¿Qué te ayudó a sortearlo?"),
                new(
                    "La gente a tu alrededor",
                    4,
                    [
                        P("En la apatía apetece encerrarse y alejarse de todos. Pero el contacto con la gente es uno de los remedios más potentes contra el ánimo bajo, aunque ahora mismo no dé la alegría de antes."),
                        List(
                            "Escribe a una persona con la que hace tiempo que no hablas",
                            "Un encuentro corto o una llamada es mejor que nada",
                            "No tienes que explicarlo todo: «ahora mismo estoy pasando una mala racha, vamos solo a dar un paseo»",
                            "Si hay pocas fuerzas, elige a personas con las que estar sea fácil"),
                        Practice(TechniqueId.SmallStep, "Un pequeño paso"),
                        P("No tienes que contarlo todo: puedes pedir algo concreto, como que te escuchen, te acompañen o te ayuden con una tarea."),
                        See(ArticleIds.SupportRequest, "Cómo pedir apoyo")
                    ],
                    "Ponte en contacto con al menos una persona en los próximos dos días.",
                    "¿Con quién te pusiste en contacto? ¿Cómo fue?"),
                new(
                    "Lo que me importa",
                    4,
                    [
                        P("Para que los pasos no se conviertan en obligaciones, ayuda relacionarlos con lo que te importa: las personas cercanas, la salud, el trabajo, la creatividad, la naturaleza."),
                        List(
                            "Elige un ámbito que te importe",
                            "Piensa en quién quieres ser en él",
                            "Elige un pequeño paso en esa dirección para la semana"),
                        H("Qué seguir haciendo"),
                        List(
                            "Cada día, una actividad agradable y una de «lo he conseguido»",
                            "Pasos pequeños en lugar de grandes planes",
                            "El contacto con la gente"),
                        P("Vuelve a hacer la escala PHQ-9 y compárala con el principio. Si el resultado es alto o no cambia, acude a un médico o a un psicoterapeuta: la depresión se trata muy bien."),
                        TestsTab("Escala PHQ-9", "phq9"),
                        Crisis("Necesito ayuda ahora")
                    ],
                    "Esta semana, da un paso en un ámbito que te importe.",
                    "¿Qué te importa? ¿Qué paso elegiste?")
            ]),
        new(
            CourseIds.Trauma,
            "Después de un trauma",
            "Cinco días sobre lo que es seguro hacer por tu cuenta: entender tu reacción, manejar los flashbacks y las pesadillas, encontrar un especialista",
            "Healing",
            "pcl5",
            "PCL-5",
            [
                new(
                    "Una reacción normal ante un suceso anormal",
                    4,
                    [
                        P("Después de un suceso difícil, casi todo el mundo tiene recuerdos intrusivos, pesadillas, ansiedad, entumecimiento, irritabilidad. No es debilidad, sino la reacción de un cerebro que intenta protegerte de que vuelva a pasar."),
                        P("Este curso no procesará el trauma: eso requiere terapia con un especialista. Te ayudará a entender lo que te pasa, a manejar los momentos difíciles y a llegar preparado al especialista. En este curso no tienes que recordar ni describir el suceso en sí."),
                        P("Haz la escala PCL-5 al principio: al final compararás el resultado."),
                        TestsTab("Escala PCL-5", "pcl5"),
                        Warning("Si el peligro continúa"),
                        P("Si ahora mismo estás amenazado o han aparecido pensamientos de hacerte daño, la seguridad va primero."),
                        Crisis("Necesito ayuda ahora")
                    ],
                    "Fíjate en cuándo se hace más difícil durante el día, sin detalles del suceso: la hora, el lugar, lo que había alrededor.",
                    "¿Cuáles de estas reacciones reconoces en ti?"),
                new(
                    "Volver al presente",
                    4,
                    [
                        P("Un flashback es un recuerdo que se revive como si estuviera pasando ahora. El momento, el lugar, el apoyo del cuerpo y los sentidos ayudan a volver."),
                        Practice(TechniqueId.Flashback, "Un recuerdo me ha desbordado"),
                        Practice(TechniqueId.Grounding, "Anclaje 5-4-3-2-1"),
                        H("Tu propio kit de anclaje"),
                        List(
                            "Una frase: «Es un recuerdo. Ahora es otro momento, estoy a salvo»",
                            "Algo que llevar contigo: una piedrecita, un anillo, algo con olor",
                            "Una persona a la que puedas escribir",
                            "Algo frío: agua, hielo"),
                        Breathe("La exhalación más larga que la inhalación"),
                        P("Si centrarte en la respiración o el cuerpo aumenta el malestar, para. Abre los ojos, elige un objeto neutro a tu alrededor o sáltate el ejercicio."),
                        See(ArticleIds.TraumaGrounding, "Cuando el anclaje aumenta el malestar")
                    ],
                    "Prepara tu kit de anclaje y prueba la práctica «Un recuerdo me ha desbordado» en un momento tranquilo, para conocerla de antemano.",
                    "¿Qué incluiste en tu kit de anclaje?"),
                new(
                    "El sueño y las pesadillas",
                    4,
                    [
                        P("Después de un trauma, el sueño suele resentirse: cuesta dormirse, el sueño es ligero, llegan las pesadillas. La falta de sueño vuelve los días más ansiosos e irritables."),
                        List(
                            "Una misma hora de levantarse cada día",
                            "Luz por la mañana, una tarde tranquila sin noticias",
                            "Si una pesadilla te despierta: luz, dónde estoy y qué día es, agua, exhalaciones lentas",
                            "El alcohol aumenta las pesadillas en la segunda mitad de la noche"),
                        P("Una pesadilla que se repite se puede reescribir: el ensayo en imaginación hace que las pesadillas sean menos frecuentes y más débiles. Empieza por una más leve."),
                        Practice(TechniqueId.Nightmare, "Reescribir una pesadilla")
                    ],
                    "Mantén una misma hora de levantarte. Si tienes pesadillas que se repiten, prueba a reescribir una, empezando por una más leve.",
                    "¿Cómo duermes ahora? ¿Qué te ayuda después de una noche difícil?"),
                new(
                    "Apoyo y personas",
                    4,
                    [
                        P("El trauma suele alejar de los demás y de lo que antes importaba. El apoyo de las personas cercanas es uno de los factores más potentes de la recuperación."),
                        List(
                            "No tienes que hablar del suceso: podéis simplemente estar juntos",
                            "Diles a los tuyos cómo ayudarte en un momento difícil",
                            "Recupera poco a poco lo que te daba apoyo: paseos, movimiento, cosas que te gustaban",
                            "No anestesies las emociones con alcohol: entorpece la recuperación"),
                        P("Evitar lo que te recuerda el suceso es comprensible, pero con el tiempo estrecha la vida y mantiene el trauma «caliente». Es mejor trabajarlo con un especialista que obligarte en solitario."),
                        P("Lo que el suceso cambió en tu forma de pensar sobre ti —la culpa, «algo va mal en mí», «no se puede confiar en nadie»— se puede trabajar en el chat, sin volver a contar lo que pasó."),
                        TraumaChat("Trabajarlo en el chat"),
                        Practice(TechniqueId.SelfCompassion, "Palabras amables para ti")
                    ],
                    "Haz una cosa que antes te daba apoyo y pasa tiempo con alguien de confianza.",
                    "¿Quién y qué te da apoyo ahora?"),
                new(
                    "El camino hacia un especialista",
                    5,
                    [
                        P("Los síntomas postraumáticos responden bien a la psicoterapia centrada en el trauma: exposición prolongada, terapia cognitiva, EMDR, exposición escrita. Suele requerir 8–16 sesiones."),
                        See(ArticleIds.TraumaTreatment, "Cómo se trata el trauma y cómo elegir un especialista"),
                        H("Cómo prepararte"),
                        List(
                            "Vuelve a hacer la escala PCL-5 y compárala con el principio",
                            "Exporta un resumen de la aplicación para el especialista: «Perfil → Opciones → Datos y copia de seguridad»",
                            "Apunta tus preguntas: qué método, cuántas sesiones, cómo se medirá el progreso",
                            "No tienes que contarlo todo sobre el suceso en la primera cita"),
                        TestsTab("Escala PCL-5", "pcl5"),
                        Crisis("Necesito ayuda ahora")
                    ],
                    "Busca uno o dos especialistas que trabajen con trauma y pide una cita de consulta.",
                    "¿Qué fue lo más útil del curso? ¿De qué quieres hablar con el especialista?")
            ]),
        new(
            CourseIds.MoneyStress,
            "Preocupaciones económicas: 14 días de apoyo",
            "Catorce pasos breves para revisar la urgencia, distinguir hechos de predicciones y encontrar apoyo. GAD-7 mide ansiedad general de las últimas dos semanas, no las finanzas; un cambio no demuestra que el curso lo causó. No es asesoramiento financiero ni legal.",
            "AccountBalanceWallet",
            "gad7",
            "GAD-7",
            [
                new(
                    "Una preocupación",
                    4,
                    [P("GAD-7 mide síntomas generales de ansiedad de las últimas dos semanas, no preocupaciones económicas. Describe una preocupación sin cantidades, datos bancarios ni nombres."), TestsTab("Abrir GAD-7: ansiedad general de las últimas dos semanas", "gad7"), See(ArticleIds.MoneyStress, "Preocupaciones económicas: hechos y predicciones")],
                    "Anótala en términos generales o dilo en voz baja.",
                    "¿Qué suele devolverte la atención a ella?"),
                new(
                    "Revisar la urgencia",
                    4,
                    [P("Si están en riesgo la comida, la vivienda, medicamentos esenciales o la seguridad, busca ayuda práctica hoy; el curso puede esperar.")],
                    "Nombra una necesidad de hoy y a quién podrías contactar.",
                    "¿Qué necesita atención primero?"),
                new(
                    "Hechos y predicciones",
                    4,
                    [P("Separa hechos conocidos, lo que falta comprobar y un temor sobre el futuro. Puedes reconocer la incertidumbre sin llenarla con el peor pronóstico."), Practice(TechniqueId.MoneyWorryPlan, "Ordenar una preocupación por el dinero"), See(ArticleIds.MoneyStress, "Preocupaciones económicas: hechos y predicciones")],
                    "Prueba el ejercicio con notas generales.",
                    "¿Qué pudiste separar del temor?"),
                new(
                    "Una pregunta por comprobar",
                    4,
                    [P("Elige una pregunta cuya respuesta reduzca la incertidumbre. Para una factura o servicio, usa un canal oficial conocido.")],
                    "Escribe una pregunta y dónde comprobarla con seguridad.",
                    "¿Qué está más claro ahora?"),
                new(
                    "Proteger los datos",
                    4,
                    [P("No compartas contraseñas, PIN, códigos ni datos completos de cuentas. Comprueba por otra vía las peticiones inesperadas de enviar dinero.")],
                    "Elige una regla para hacer una pausa antes de compartir datos o dinero.",
                    "¿Qué límite te da seguridad?"),
                new(
                    "Pedir ayuda concreta",
                    4,
                    [P("El apoyo no tiene que ser dinero: compañía, llamar juntos o buscar un servicio local. La otra persona puede aceptar o decir que no."), See(ArticleIds.SupportRequest, "Cómo pedir apoyo")],
                    "Redacta una petición para una tarea y un momento, sin secretos financieros.",
                    "¿A quién podrías pedírselo?"),
                new(
                    "Un paso posible",
                    4,
                    [P("Elige una acción segura, revisable y dentro de tu control. Para cuestiones financieras o legales especializadas, consulta a un profesional local cualificado."), Practice(TechniqueId.MoneyWorryPlan, "Ordenar una preocupación por el dinero")],
                    "Elige un paso pequeño y reversible o pide apoyo.",
                    "¿Qué te ayuda a no asumirlo todo?"),
                new(
                    "Una alternativa",
                    4,
                    [P("El plan es más flexible si prevé otra opción ante una demora o una negativa. No tiene que resolverlo todo.")],
                    "Nombra una alternativa y un contacto de apoyo.",
                    "¿Qué alternativa parece realista?"),
                new(
                    "Un tiempo para revisar",
                    4,
                    [P("Si no hay urgencia, fija un rato breve para comprobar información y después vuelve a tu tarea. No retrases la ayuda necesaria.")],
                    "Elige un momento tranquilo para revisar el plan.",
                    "¿Qué puede esperar?"),
                new(
                    "Apoyo práctico",
                    4,
                    [P("En tu zona puede haber servicios sociales, comunitarios o de salud. Las opciones varían; la aplicación no recomienda decisiones financieras.")],
                    "Busca una fuente local conocida para preguntar qué apoyo existe.",
                    "¿Qué preguntarías?"),
                new(
                    "Hablar sin revelar secretos",
                    4,
                    [P("Puedes decir: estoy preocupado y me gustaría que me acompañaras un rato. No hace falta compartir cantidades ni datos bancarios.")],
                    "Decide qué contar en términos generales y a quién.",
                    "¿Qué tipo de ayuda deseas?"),
                new(
                    "Cuidarte",
                    4,
                    [P("Descansar, beber agua, comer o hacer algo que te calme no resuelve el problema económico, pero puede ayudarte a pasar el día.")],
                    "Elige un cuidado posible que no requiera gastar dinero.",
                    "¿Qué podría darte un poco de respiro?"),
                new(
                    "Revisar tus límites",
                    4,
                    [P("Observa qué está claro, qué sigue incierto y dónde necesitas ayuda. Puedes simplificar el plan.")],
                    "Conserva un paso siguiente y deja lo demás para otro día si es seguro.",
                    "¿Qué no hace falta resolver hoy?"),
                new(
                    "Elegir cómo continuar",
                    4,
                    [P("Tras unas dos semanas puedes repetir GAD-7. No evalúa las finanzas ni demuestra que el curso causara cambios. Si la ansiedad sigue afectando tu vida, consulta a un profesional."), TestsTab("Repetir GAD-7; no evalúa las finanzas ni explica un cambio", "gad7"), Crisis("Necesito ayuda ahora")],
                    "Elige un apoyo o paso para mantener después.",
                    "¿Qué conservarías o consultarías?")
            ]),

        new(CourseIds.ValuesAction, "Pequeños pasos hacia lo que importa", "Cinco días para elegir una dirección importante y probar acciones posibles.", "TrackChanges", "who5", "WHO-5",
            [
                new("Encuentra una dirección", 3, [P("Un valor describe cómo quieres ser en un ámbito de tu vida, no un resultado que tengas que completar de una vez para siempre."), See(ArticleIds.ValuesAction, "Los valores como guía: elegir un paso posible")], "Nombra un ámbito que te importe ahora.", "¿Qué hace que sea importante para ti?"),
                new("Haz el paso más pequeño", 3, [P("Elige una acción de pocos minutos. Debe ser lo bastante pequeña para probarla y lo bastante significativa para que sea una elección tuya.")], "Anota una acción que no lleve más de 5–10 minutos.", "¿Cómo podrías hacerla más fácil o más breve?"),
                new("Prepara un obstáculo", 3, [P("Piensa qué podría interponerse y elige una alternativa. Un plan puede cambiar; eso no es fracasar.")], "Completa: «Si … se interpone, puedo probar …».", "¿Qué alternativa sería más amable si tienes menos energía?"),
                new("Prueba sin esperar al ánimo adecuado", 3, [P("No necesitas sentir seguridad o motivación antes. Puedes probar un paso pequeño, observar qué aparece y parar o hacerlo más sencillo si así es más seguro.")], "Si es seguro, prueba tu paso o una versión más fácil.", "¿Qué notaste antes y después?"),
                new("Revisa el plan", 3, [P("Valora si la acción encajó en vez de juzgarte. Repítela, ajústala o elige otra dirección.")], "Anota qué quieres repetir o cambiar esta semana.", "¿Qué acción puede apoyar lo que te importa sin añadir presión?")
            ]),


        new(CourseIds.ProblemPlanning, "Un plan para tareas manejables", "Divide un problema en pasos y revisa el plan", "Checklist", "gad7", "GAD-7",
            [
                new("Elige un problema", 3, [P("Primero identifica un problema concreto. No todo depende de ti; elige aquello en lo que puedas influir."), See(ArticleIds.ProblemPlanning, "Un plan para tareas manejables")], "Escribe un problema y qué depende de ti.", "¿En qué parte de la situación puedes influir?"),
                new("Elige un paso", 3, [P("Escribe varias opciones, aunque ninguna parezca perfecta. Elige un paso pequeño y seguro."), See(ArticleIds.ProblemPlanning, "Un plan para tareas manejables")], "Escribe dos opciones y elige un paso manejable.", "¿Qué podría impedirlo y cuál sería una alternativa?"),
                new("Revisa el plan", 3, [P("Después observa qué ayudó y qué fue demasiado difícil. Puedes ajustar el plan o pedir apoyo."), See(ArticleIds.ProblemPlanning, "Un plan para tareas manejables")], "Prueba el paso si es seguro y anota qué ocurrió.", "¿Qué conservarías, cambiarías o hablarías con alguien?")
            ]),
        new(
            CourseIds.Overwhelm,
            "Menos agobio, un siguiente paso más claro",
            "Cinco días breves para ordenar lo urgente, reducir una tarea y encontrar apoyo. Sigue tu propio ritmo.",
            "Checklist",
            "pss10",
            "PSS-10",
            [
                new("Saca las tareas de tu cabeza", 4, [P("Una lista breve muestra qué cosas reclaman atención. Bastan unas palabras; no hacen falta datos privados."), H("Comprueba primero la urgencia"), Warning("Si están en riesgo la seguridad, la salud, la comida, la vivienda o los medicamentos necesarios, busca ayuda práctica primero."), See(ArticleIds.Overwhelm, "Cuando todo se acumula: elige el siguiente paso")], "Anota lo que reclama atención y marca solo lo que no puede esperar con seguridad.", "¿Qué quedó más claro al hacer la lista?"),
                new("Separa la urgencia de la preocupación", 4, [P("La preocupación intensa merece cuidado, pero no decide por sí sola el orden. Comprueba fechas límite, consecuencias y qué puedes influir."), Quiz("¿Qué puede ayudarte a elegir la primera tarea?", 1, "Las fechas y las consecuencias ayudan a valorar la urgencia; que una preocupación suene fuerte no la convierte por sí sola en la primera tarea.", "Elegir la preocupación más intensa", "Comprobar la fecha y las consecuencias", "Intentar resolverlo todo a la vez")], "Elige una tarea para hoy y otra que pueda esperar.", "¿Qué de verdad no se puede posponer?"),
                new("Reduce el siguiente paso", 4, [P("Describe una acción que lleve unos minutos. Si todavía parece demasiado grande, divídela otra vez."), See(ArticleIds.Overwhelm, "Cuando todo se acumula: elige el siguiente paso"), Practice(TechniqueId.ExternalOrientation, "Tres detalles neutros")], "Nombra cómo empezar: abrir, llamar, preguntar o reunir un dato.", "¿Cómo podrías hacer este paso más fácil?"),
                new("Pide una ayuda manejable", 4, [P("Pedir una acción concreta es más claro que pedir que alguien lo resuelva todo. La otra persona puede aceptar, proponer otra opción o decir que no; entonces puedes buscar otro apoyo."), List("Pedir que alguien te acompañe un momento", "Pedir ayuda para comprobar un dato", "Pedir compartir una tarea")], "Escribe una petición breve y piensa a quién podrías hacerla.", "¿Qué respuesta o alternativa te serviría?"),
                new("Revisa el plan", 4, [P("Revisa si el plan encaja con tus circunstancias actuales, no si has sido bastante estricto contigo. Puedes seguir, simplificarlo o pedir apoyo."), TestsTab("Si quieres, repite PSS-10. Evalúa el estrés percibido, no diagnostica; un cambio en la puntuación no demuestra que el curso lo haya causado.", "pss10")], "Elige un paso que quieras mantener durante los próximos días.", "¿Cómo evitar que el plan se convierta en otra presión?")
            ]),

        new(
            CourseIds.NewsBoundaries,
            "Noticias a tu ritmo",
            "Cinco días para consultar menos por hábito y conservar las alertas importantes.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Observa el hábito", 4, [P("Cuando abras la sección de noticias, pregúntate: ¿qué quiero saber y tengo que actuar ahora?"), See(ArticleIds.NewsLoop, "Cuando las noticias no te dejan desconectar"), TestsTab("El PSS-10 mide el estrés percibido durante el último mes. Es un instrumento de cribado, no un diagnóstico.", "pss10")], "Observa una vez qué provocó las ganas de consultar las noticias.", "¿Qué querías averiguar?"),
                new("Una pregunta, una fuente", 4, [P("Formula una pregunta y elige una fuente fiable que pueda responderla. Cuando tengas la respuesta, más actualizaciones quizá no aporten información útil."), Quiz("Ya encontraste la respuesta. ¿Qué puedes hacer si no hay que actuar con urgencia?", 1, "Decidir cuándo volver a consultar puede interrumpir la actualización automática.", "Seguir actualizando hasta sentir calma", "Elegir cuándo volver a consultar y retomar tu actividad", "Prohibirte leer noticias por completo")], "Elige una pregunta y una fuente para la próxima consulta.", "¿Cómo sabrás que tienes la información necesaria?"),
                new("Conserva las alertas importantes", 4, [P("Puedes desactivar las notificaciones opcionales y conservar las relacionadas con la seguridad, la familia o el trabajo."), List("Conservar alertas de servicios esenciales", "Desactivar notificaciones opcionales", "Pedir a personas cercanas que llamen si algo urge")], "Revisa los ajustes solo si te resulta útil.", "¿Qué alertas necesitas conservar?"),
                new("Prepara un plan para consultar", 4, [P("Elige un momento y una fuente adecuados. No hace falta fijar un límite estricto: cambia el plan si surge una noticia urgente o una circunstancia nueva."), Practice(TechniqueId.NewsCheckPlan, "Planifica una consulta de noticias")], "Completa el plan breve o simplemente piénsalo.", "¿Qué harás después de consultar?"),
                new("Revisa sin juzgarte", 4, [P("Observa si esta rutina te resulta más llevadera. Puedes mantenerla, cambiarla o dejarla. Un cambio en el PSS-10 no demuestra que el curso lo haya causado."), Quiz("¿Qué hacer si aparece información importante para la seguridad?", 1, "El plan no debe impedirte consultar información urgente ni seguir indicaciones oficiales.", "Esperar al horario elegido", "Consultar una fuente fiable y actuar según la situación", "Desactivar todas las alertas"), TestsTab("Si quieres, puedes repetir el PSS-10. Comparar puntuaciones no establece la causa de un cambio.", "pss10")], "Conserva un ajuste que te funcione.", "¿Qué ritmo te resultó posible?")
            ]),
        new(
            CourseIds.HabitMaintenance,
            "Un hábito al que puedes volver",
            "Cinco días para elegir una señal, facilitar el comienzo y retomar con amabilidad después de una pausa.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Elige una acción", 4, [P("Empieza con una acción pequeña que dependa de ti y apoye tu bienestar cotidiano. No elijas varios objetivos a la vez."), See(ArticleIds.HabitFormation, "Crear un hábito: una acción pequeña y una señal"), TestsTab("El WHO-5 es un breve instrumento de cribado del bienestar de las últimas dos semanas, no un diagnóstico ni una medida de fuerza de voluntad.", "who5")], "Nombra una acción que te gustaría repetir.", "¿Por qué encaja este paso en tu vida ahora?"),
                new("Únela a una señal", 4, [P("Elige un momento habitual que te recuerde empezar, por ejemplo, después del desayuno o al llegar a casa."), Practice(TechniqueId.ImplementationIntention, "Plan «si… entonces…»"), Quiz("¿Qué plan será más fácil de recordar en el momento adecuado?", 1, "Una señal concreta y una acción pequeña facilitan empezar sin esperar a tener ganas.", "Algún día dedicaré más tiempo a esto", "Después del desayuno escribiré una frase", "Empezaré cuando me sienta motivado")], "Completa: Después de …, haré …", "¿Qué señal habitual ya forma parte de tu día?"),
                new("Facilita el comienzo", 4, [P("Quita un obstáculo pequeño: deja preparado lo que necesitas, abre el archivo o elige un lugar. El primer paso puede durar solo un par de minutos."), List("Preparar lo necesario", "Reducir la duración o la cantidad", "Elegir un lugar o momento más cómodo")], "Haz que empezar sea un paso más sencillo.", "¿Qué te lo dificultaba y qué cambiaste?"),
                new("Planifica cómo volver", 4, [P("Un día sin hacerlo informa de lo que pasó; no demuestra que hayas fracasado. No hace falta duplicar el esfuerzo ni culparte: puedes volver en la próxima ocasión adecuada."), Practice(TechniqueId.HabitRestartPlan, "Volver con amabilidad"), Quiz("Te saltaste la acción habitual. ¿Qué puede ayudar a retomarla sin presión extra?", 1, "La próxima señal adecuada y un paso más pequeño permiten continuar sin castigos ni compensaciones.", "Hacer el doble mañana", "Volver con la próxima señal y empezar con poco", "Abandonar el plan para siempre")], "Elige una señal para volver y la versión más fácil de la acción.", "¿Cómo seguir sin intentar recuperar todo?"),
                new("Conserva lo que funciona", 4, [P("Toma el plan como un experimento: repítelo, reduce la acción, cambia la señal o haz una pausa. Si quieres, puedes repetir el WHO-5; un cambio en la puntuación no demuestra que el curso lo haya causado."), TestsTab("El WHO-5 es un instrumento de cribado del bienestar, no un diagnóstico. Comparar resultados no establece por qué cambiaron.", "who5")], "Conserva un ajuste que quieras probar después.", "¿Qué fue viable y qué te gustaría cambiar?")
            ]),
        new(
            CourseIds.FeedbackResponse,
            "Responder a los comentarios sin autocriticarte",
            "Cuatro lecciones breves: separar los hechos de las etiquetas, aclarar expectativas y elegir una respuesta que respete tus límites.",
            "Forum", "who5", "WHO-5",
            [
                new("Observa tu primera reacción", 4, [P("Las palabras pueden doler. No tienes que estar de acuerdo, discutir ni defenderte de inmediato. Primero observa qué escuchaste y cómo te sentó."), See(ArticleIds.Feedback, "Comentarios sin etiquetas"), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas; no es un diagnóstico ni mide cómo aceptaste los comentarios.", "who5")], "Elige una frase que te dé tiempo para pensar.", "¿Qué podrías decir para no responder en caliente?"),
                new("Pide detalles concretos", 4, [P("Pedir un ejemplo ayuda a entender qué se podría cambiar. Aclara el plazo, el criterio o la situación sin prometer que aceptarás todo lo dicho."), Practice(TechniqueId.FeedbackReview, "Ordenar los comentarios")], "Escribe una pregunta que aclare la expectativa.", "¿Qué sigue siendo demasiado general?"),
                new("Elige la parte útil", 4, [P("Puedes valorar un comentario concreto, aclarar lo dudoso y rechazar una etiqueta. La meta es elegir tu siguiente paso, no demostrar cuánto vales."), Warning("Las amenazas, la humillación, la discriminación o la presión requieren límites y apoyo, no autocriticarte.")], "Elige un punto que quieras comprobar o conversar.", "¿Qué puedo influir y qué no tengo que aceptar?"),
                new("Cierra con calma y un paso", 4, [P("Acuerda una acción o cuándo revisarla. Si no hay acuerdo, puedes anotar los hechos y consultar a alguien de confianza o las normas del trabajo o centro educativo."), Quiz("¿Qué respuesta aclara mejor qué hacer después?", 1, "Una pregunta concreta aclara las expectativas; una pausa te permite elegir cómo responder.", "Estar de acuerdo con todo para terminar la conversación.", "Pedir un ejemplo o criterio y responder más tarde.", "Decidir que un error describe quién eres por completo."), TestsTab("Una reacción intensa no demuestra que las palabras sean ciertas. WHO-5 es un cribado general del bienestar, no una prueba sobre comentarios; un cambio de puntuación no demuestra que el curso lo causara.", "who5")], "Prueba una pregunta o respuesta que respete tus límites.", "¿Qué pequeño paso eliges?")
            ]),
        new(
            CourseIds.ConnectionWithoutPressure,
            "Conectar a tu ritmo",
            "Cinco pasos pequeños para identificar qué tipo de conexión quieres, elegir un formato seguro e invitar sin presión.",
            "Group", "who5", "WHO-5",
            [
                new("Nombra el tipo de conexión que quieres", 4, [P("A veces apetece conversar; otras, compartir una actividad, estar en compañía tranquila o recibir ayuda práctica. No tienes que alcanzar un número determinado de contactos."), See(ArticleIds.Loneliness, "La soledad"), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas, no una medida de soledad ni un diagnóstico. Un cambio de puntuación por sí solo no demuestra el efecto del curso.", "who5")], "Elige un tipo de contacto que te vendría bien ahora.", "¿Qué significa para mí conectar con comodidad?"),
                new("Elige un formato seguro", 4, [P("Piensa con quién y cómo te sentirías más seguro: a solas, en grupo, en línea o con un mensaje breve. También puedes hacer una pausa; no contactes con alguien con quien no te sientes seguro.")], "Nombra una persona, grupo o formato que te parezca suficientemente seguro.", "¿Qué formato facilitaría empezar?"),
                new("Invita sin presionar", 4, [P("Una invitación breve y concreta es más fácil de aceptar o rechazar. Deja que la otra persona elija cuándo o diga que no."), See(ArticleIds.SupportRequest, "Cómo pedir apoyo"), Practice(TechniqueId.ConnectionStepPlan, "Planificar un contacto pequeño")], "Escribe una invitación a dar un paseo corto, conversar o hacer algo juntos.", "¿Cómo puedo dejar libertad para elegir?"),
                new("Deja margen para cambiar", 4, [P("Empieza en un momento cómodo y con una forma sencilla de terminar. Si tienes poca energía, reduce el plan o aplázalo. Que respondan o no respondan no define tu valor."), Practice(TechniqueId.ConnectionStepPlan, "Planificar un contacto pequeño")], "Elige un formato sencillo y decide cuándo podrías terminar o cambiar el plan.", "¿Cómo me apoyaré si cambian los planes?"),
                new("Reflexiona sin juzgarte", 4, [P("Observa si te sentiste seguro y a gusto y si repetirías o cambiarías el formato. No te valores por el número de mensajes ni por la reacción de otra persona."), Quiz("¿Qué conviene notar después de un contacto pequeño?", 0, "Es útil revisar el formato y tu propia experiencia. La respuesta de otra persona no mide tu valor.", "¿Me sentí seguro y a gusto, y qué podría ajustar?", "¿Cuántos mensajes recibí en una hora?", "¿La falta de respuesta demuestra que no quieren verme?"), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas, no una medida de soledad ni un diagnóstico. Un cambio de puntuación por sí solo no demuestra el efecto del curso.", "who5")], "Elige un formato que quieras probar o ajustar.", "¿Qué paso pequeño me encaja ahora?")
            ]),
        new(
            CourseIds.Boundaries,
            "Comunicar mis límites",
            "Cuatro pasos breves para reconocer tus límites, expresarlos con claridad y elegir una respuesta segura.",
            "Forum", "who5", "WHO-5",
            [
                new("Qué me importa", 4, [P("Comunicarse con asertividad es expresar lo que necesitas y respetar el derecho de la otra persona a responder. No garantiza que acepte ni es una obligación."), H("Tres formas de responder"), List("Callar aunque no estés de acuerdo", "Presionar o insultar a cambio", "Expresar con calma tu postura y petición"), Quiz("¿Qué respuesta es asertiva?", 2, "Una frase clara y tranquila expresa tu postura y deja que la otra persona responda libremente.", "Aceptar aunque no quieras", "Hablar más alto hasta que acepte", "Decir: «Hoy no puedo. ¿Lo hablamos otro día?»"), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas, no una medida de asertividad ni un diagnóstico.", "who5"), Crisis("Necesito ayuda ahora")], "Observa una situación segura en la que te gustaría poner un límite. No tienes que actuar todavía.", "¿Qué es importante para ti en esta situación?"),
                new("Decir que no con claridad", 4, [P("Una negativa puede ser breve y amable. No tienes que dar explicaciones largas. Si te viene bien, puedes proponer otra opción, pero no es obligatorio."), List("«Ahora no puedo»", "«No puedo hacerme cargo de esto»", "«Necesito pensarlo. Te contesto mañana»"), P("Si la persona insiste, repite con calma tu frase principal. No tienes que demostrar que tu motivo es suficientemente válido.")], "Prepara una frase para una situación cotidiana de poco riesgo.", "¿Qué palabras te suenan naturales?"),
                new("Hacer una petición concreta", 4, [P("Una petición concreta se entiende mejor que una indirecta o un reproche. Nombra la situación, qué te importa y una opción posible."), Quiz("¿Qué petición es más clara?", 1, "Una petición concreta describe una acción y un momento sin adivinar las intenciones de la otra persona.", "«Nunca me escuchas»", "«Cuando puedas, ¿me escuchas diez minutos?»", "No decir nada y esperar que lo adivine"), P("La otra persona puede aceptar, proponer un acuerdo o negarse. Aun así, tienes derecho a pedir y elegir tu siguiente paso.")], "Escribe o piensa una petición breve.", "¿Qué podrías concretar más?"),
                new("Elegir un siguiente paso seguro", 4, [P("Empieza por una situación de menor riesgo y piensa qué podrías hacer ante distintas respuestas. Puedes posponer o terminar la conversación, o tener apoyo contigo."), P("Si hablar con claridad podría provocar amenazas, violencia, castigos o más control, no lo practiques a solas. Prioriza tu seguridad y busca a una persona o servicio de confianza."), TestsTab("WHO-5 evalúa el bienestar general, no la habilidad para poner límites. Un cambio en la puntuación no demuestra el efecto del curso.", "who5")], "Elige un paso seguro: decir la frase, pedir apoyo o no cambiar nada por ahora.", "¿Qué siguiente paso sería cuidadoso contigo?"),
            ]),
        new(
            CourseIds.WorkRecovery,
            "Recuperarse después del trabajo",
            "Cuatro días para descubrir qué ayuda a desconectar, elegir un descanso posible y cuidar el tiempo fuera del trabajo.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Qué me ayuda a recuperarme", 4, [P("Cada persona descansa de forma distinta. La investigación estudia desconectar de los pensamientos laborales, relajarse, hacer algo que absorba y elegir el ritmo o el momento. Son opciones, no una lista obligatoria."), H("Ideas para probar"), List("Una pausa tranquila o descansar", "Una actividad interesante o que te enseñe algo", "Estar con otras personas o a solas", "Moverte suavemente, si te sienta bien"), TestsTab("PSS-10 mide el estrés percibido durante el último mes. No diagnostica agotamiento ni mide la recuperación laboral.", "pss10"), Crisis("Necesito ayuda ahora")], "Observa una forma de descansar que a veces te ayuda o parece posible.", "¿Qué te ayuda a desconectar, aunque sea un poco?"),
                new("Cerrar la jornada con suavidad", 4, [P("Las tareas pendientes pueden seguir ocupando la atención. Si puedes, elige una señal sencilla para terminar: cerrar las pestañas del trabajo, anotar el primer paso de mañana o cambiarte de ropa."), P("Adáptalo a turnos, guardias y tareas urgentes. Mantén las alertas necesarias para tu seguridad o trabajo.")], "Elige una señal breve para terminar de trabajar que encaje en tu horario.", "¿Qué podría marcar el paso a tu tiempo personal?"),
                new("Elegir descanso sin un plan perfecto", 4, [P("Descansar no tiene que convertirse en otra tarea. Pregúntate si ahora te vendría mejor tranquilidad, compañía, una actividad interesante o no hacer nada."), List("Hacer la actividad más corta", "Elegir algo que requiera poca preparación", "Permitirte cambiar de opinión"), P("La investigación encuentra asociaciones entre algunas experiencias de recuperación y el bienestar, pero no promete el mismo efecto para todos. Observa tu experiencia.")], "Prueba una pausa breve o decide cuándo podrías volver a ella.", "¿Qué te resultó agradable, neutro o poco adecuado?"),
                new("Proteger un tiempo personal posible", 4, [P("No todas las exigencias dependen de ti. Si el trabajo invade el descanso con frecuencia, puedes hablar de prioridades, plazos o apoyo con alguien responsable, un compañero o una persona de confianza."), P("Si las condiciones no pueden cambiar todavía, no es un fracaso personal. Elige solo lo que esté a tu alcance: una pausa, una actividad corta o cuándo volver a mirar el trabajo."), TestsTab("Repetir PSS-10 ofrece una referencia general del estrés. La diferencia de puntuación no explica por qué cambió ni mide el efecto del curso.", "pss10")], "Quédate con un pequeño ajuste que quieras probar esta semana.", "¿Qué quieres mantener o cambiar después?")
            ]),
        new(
            CourseIds.SelfCompassion,
            "Tratarse con amabilidad tras un error",
            "Cuatro pasos para notar la autocrítica, separar los hechos de las etiquetas y elegir una respuesta útil.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Notar la voz crítica", 4, [P("Después de un error, la autocrítica puede convertir una acción en una etiqueta sobre toda tu persona. No tienes que discutir con ella ni forzarte a pensar en positivo: primero separa lo ocurrido de tu juicio sobre ti."), H("Hecho y etiqueta"), List("Olvidé contestar — un hecho", "Soy una amistad terrible — una etiqueta", "¿Qué puede ayudar a reparar esto? — una pregunta"), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas. No mide la autocompasión ni demuestra el efecto del curso.", "who5"), Crisis("Necesito ayuda ahora")], "Nota una etiqueta autocrítica e intenta describir lo ocurrido sin juzgarte. No hace falta escribirlo.", "¿Qué ocurrió al quitar la etiqueta?"),
                new("Hablarte como hablarías a alguien querido", 4, [P("Imagina que alguien cercano cometió el mismo error. Apoyarte no significa justificarlo todo: puede ayudarte a ver la situación completa y elegir un siguiente paso."), Quiz("¿Qué respuesta es amable y sincera?", 2, "Reconoce el error sin atacar a la persona y ayuda a encontrar un paso concreto.", "Siempre lo estropeas todo", "No importa en absoluto", "Te equivocaste en algo; veamos qué se puede reparar")], "Dite una frase sincera sin menospreciarte.", "¿Cómo suena esa frase?"),
                new("Reparar lo posible sin castigarte", 4, [P("Ser amable contigo puede ir unido a la responsabilidad. Puedes reconocer el impacto y reparar lo que sea posible sin convertir un error en una condena sobre toda tu persona."), List("¿Qué ocurrió exactamente?", "¿A quién o a qué afectó?", "¿Qué pequeño paso podría ayudar ahora?"), P("No siempre se puede arreglar todo enseguida. Aun así, puedes aprender y pedir consejo a alguien de confianza.")], "Elige una acción posible para reparar o apoyar.", "¿Qué está en tu mano ahora?"),
                new("Preparar un siguiente paso amable", 4, [P("Haz un plan breve para la próxima vez: notar la autocrítica, parar un momento y elegir una acción útil. Cámbialo si no te sirve."), TestsTab("Repetir WHO-5 solo ofrece una referencia general del bienestar. La diferencia de puntuación no mide la autocompasión ni demuestra el efecto del curso.", "who5")], "Guarda una frase o acción a la que puedas volver.", "¿Qué te gustaría probar la próxima vez?")
            ]),
        new(
            CourseIds.SupportSomeone,
            "Acompañar a alguien sin presionar",
            "Cuatro pasos para preguntar, escuchar, ofrecer ayuda posible y buscar más apoyo si hace falta.",
            "Group", "pss10", "PSS-10",
            [
                new("Empezar con una pregunta sencilla", 4, [P("Elige un momento y un lugar tranquilos, si es seguro. Pregunta si la persona quiere hablar; no tienes que adivinar ni insistir."), List("¿Cómo estás ahora?", "¿Quieres hablar o prefieres que simplemente te acompañe?", "¿Hay algo que pueda hacer para ayudarte?"), TestsTab("PSS-10 evalúa el estrés percibido durante el último mes. No mide la habilidad para apoyar ni evalúa el estado de otra persona.", "pss10"), Crisis("Necesito ayuda ahora")], "Piensa en una pregunta abierta y sin presión. No tienes que hacerla enseguida.", "¿Cómo mostrar que la otra persona puede decir que no?"),
                new("Escuchar sin apresurarse a solucionar", 4, [P("Deja que termine y permite los silencios. Comprueba si has entendido en vez de aconsejar, comparar o diagnosticar enseguida."), Quiz("¿Qué respuesta deja más espacio a la otra persona?", 1, "Una pregunta abierta le permite elegir qué quiere contar.", "Solo tienes que distraerte", "¿Qué es lo más difícil ahora?", "A mí me pasó y sé lo que tienes que hacer")], "Resume con tus palabras lo que has oído y pregunta si lo entendiste bien.", "¿Qué cambia cuando no te apresuras a aconsejar?"),
                new("Ofrecer opciones de ayuda", 4, [P("El apoyo puede ser sencillo y concreto. Pregunta qué ayudaría más ahora: escuchar, echar una mano en una tarea o buscar información juntos. Ofrece solo lo que de verdad puedes hacer."), List("¿Quieres que te escuche?", "¿Te ayudo con algo concreto?", "¿Buscamos juntos a quién acudir?"), P("Si dice que no, respeta su respuesta. Puedes dejar abierta la posibilidad de hablar más adelante.")], "Con su permiso, ofrece una ayuda concreta o piensa en una opción para otro momento.", "¿Qué ayuda es posible para ambos?"),
                new("Buscar más apoyo y cuidar tus límites", 4, [P("Puedes estar presente sin resolverlo todo a solas ni ser el único apoyo. Explica cuándo estás disponible y sugiere contar con alguien de confianza o un profesional."), P("Si habla de un peligro inmediato o no puede mantenerse a salvo, no cargues con ello en solitario: si es posible, contacta con los servicios locales de emergencia o crisis. No prometas guardar en secreto un riesgo para la vida."), TestsTab("Repetir PSS-10 solo da una referencia general del estrés percibido; no evalúa tu apoyo ni demuestra el efecto del curso.", "pss10")], "Elige un límite o un apoyo adicional para no llevar esta carga a solas.", "¿Quién podría apoyarte?")
            ]),
        new(
            CourseIds.TaskStart,
            "Empezar una tarea que estoy posponiendo",
            "Tres pasos: hacer pequeño el comienzo, elegir un momento y continuar sin reproches.",
            "Checklist", "who5", "WHO-5",
            [
                new("Elegir una tarea", 3, [P("Posponer algo suele relacionarse con un comienzo poco claro o una sensación incómoda, no con la pereza. Nombra la tarea y el primer paso visible."), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas. No mide esta habilidad ni demuestra el efecto del curso.", "who5"), Crisis("Necesito ayuda ahora")], "Elige una tarea y un primer paso de hasta cinco minutos.", "¿Qué haría más claro el comienzo?"),
                new("Facilitar el inicio", 3, [P("Prepara lo necesario y elige un momento. Empieza durante cinco minutos y luego decide si continúas.")], "Anota cuándo, dónde y con qué empezarás.", "¿Qué podría interponerse y cómo simplificarlo?"),
                new("Apoyar el siguiente paso", 3, [P("Revisa sin reproches: qué ayudó, qué lo dificultó y qué es realista ahora. A veces conviene ajustar la tarea.")], "Guarda una forma de empezar que te haya servido.", "¿Qué aprendiste sobre cómo empiezas?")
            ]),
        new(
            CourseIds.FlexibleStandards,
            "Que lo bastante bueno sea suficiente",
            "Observa cuándo las exigencias altas ayudan y cuándo dificultan terminar.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Ver el coste de lo perfecto", 3, [P("Las exigencias ayudan mientras no quiten demasiado tiempo, descanso o posibilidad de terminar. Observa una regla que te impones."), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas. No mide esta habilidad ni demuestra el efecto del curso.", "who5"), Crisis("Necesito ayuda ahora")], "Elige un ejemplo en que una exigencia te frene.", "¿Qué te aporta y qué te cuesta esa regla?"),
                new("Definir qué es suficiente", 3, [P("Pregunta a quién sirve el resultado y qué necesita cumplir de verdad. Elige dos o tres criterios de calidad en vez de retocarlo sin fin.")], "Fija un límite realista para terminar una tarea.", "¿Qué podrías dejar de perfeccionar?"),
                new("Probar un pequeño cambio", 3, [P("Si te resulta seguro, deja una pequeña imperfección o termina al sonar el temporizador. Es un experimento, no una obligación de descuidar la calidad.")], "Elige un experimento amable o solo observa la regla.", "¿Qué esperabas y qué ocurrió?")
            ]),
        new(
            CourseIds.ThoughtLoops,
            "Cuando los pensamientos dan vueltas",
            "Observa los pensamientos repetidos y vuelve la atención a lo que eliges hacer.",
            "Psychology", "gad7", "GAD-7",
            [
                new("Detectar el bucle", 3, [P("Un pensamiento repetido puede parecer una búsqueda de soluciones, pero no siempre aporta una respuesta nueva. Observa cuándo vuelve y qué lo inicia."), TestsTab("GAD-7 mide la ansiedad general de las últimas dos semanas; no es un diagnóstico ni una prueba de esta habilidad.", "gad7"), Crisis("Necesito ayuda ahora")], "Nota un momento en que un pensamiento dé vueltas.", "¿Qué suele iniciar el bucle?"),
                new("Separar pensamiento y hecho", 3, [P("Nómbralo como pensamiento: «Me doy cuenta de que pienso que…». No niega el problema; evita tomar una predicción como un hecho.")], "Nombra un pensamiento con neutralidad, sin discutir con él.", "¿Qué cambia al llamarlo pensamiento?"),
                new("Volver a lo que elegiste", 3, [P("No hace falta expulsar el pensamiento. Obsérvalo y vuelve con suavidad a tu actividad; si necesitas un plan, elige un momento y un paso.")], "Elige una acción pequeña para los próximos diez minutos.", "¿A qué quieres devolver tu atención?")
            ]),
        new(
            CourseIds.UncertainDecisions,
            "Decidir sin tener plena seguridad",
            "Compara los hechos, lo que te importa y un siguiente paso posible.",
            "Checklist", "gad7", "GAD-7",
            [
                new("Separar hechos y suposiciones", 3, [P("En una decisión difícil puede faltar información. Anota lo que sabes, lo que supones y lo que todavía no puedes saber."), TestsTab("GAD-7 mide la ansiedad general de las últimas dos semanas; no es un diagnóstico ni una prueba de esta habilidad.", "gad7"), Crisis("Necesito ayuda ahora")], "Clasifica una pregunta en hechos y suposiciones.", "¿Qué hecho sería más útil aclarar?"),
                new("Nombrar tus prioridades", 3, [P("Compara las opciones según lo importante para ti: seguridad, tiempo, relaciones, recursos u otros valores. Puede que no exista una opción perfecta.")], "Elige dos criterios importantes y compara las opciones.", "¿Qué quieres proteger por encima de todo?"),
                new("Elegir el siguiente paso", 3, [P("Si es posible, elige un paso pequeño y reversible y una fecha para revisarlo. Así podrás tener en cuenta nueva información.")], "Fija un paso y cuándo revisar la decisión.", "¿Cómo podrías comprobarla más adelante?")
            ]),
        new(
            CourseIds.PauseBeforeReply,
            "Hacer una pausa antes de responder",
            "Nota la tensión, haz una pausa y decide si responder ahora.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Notar pronto la tensión", 3, [P("La irritación o la preocupación pueden notarse en el cuerpo o en la velocidad al hablar antes de pensar una respuesta. Busca tu señal temprana."), TestsTab("PSS-10 evalúa el estrés percibido durante el último mes. No mide esta habilidad ni demuestra el efecto del curso.", "pss10"), Crisis("Necesito ayuda ahora")], "Recuerda una señal corporal o de conducta.", "¿Cómo sabes que necesitas bajar el ritmo?"),
                new("Tomar una pausa breve", 3, [P("Si es seguro, retrasa la respuesta, siente los pies en el suelo y nombra lo que ocurre. No tienes que obligarte a calmarte enseguida.")], "Prepara una frase: «Necesito un poco de tiempo; respondo luego».", "¿Qué pausa sería realista para ti?"),
                new("Responder con intención", 3, [P("Elige tu objetivo: aclarar, pedir, poner un límite o terminar la conversación. Si no es seguro, aléjate y busca apoyo.")], "Prepara una frase que exprese tu objetivo.", "¿Qué quieres que entienda la otra persona?")
            ]),
        new(
            CourseIds.IrritationSignals,
            "Notar la irritación antes",
            "Reconoce las primeras señales, baja la tensión y elige una respuesta segura.",
            "Forum", "pss10", "PSS-10",
            [
                new("Encontrar una señal temprana", 3, [P("La irritación puede señalar tensión o una necesidad, pero no te obliga a actuar. Observa cambios en el cuerpo, los pensamientos o la conducta."), TestsTab("PSS-10 evalúa el estrés percibido durante el último mes. No mide esta habilidad ni demuestra el efecto del curso.", "pss10"), Crisis("Necesito ayuda ahora")], "Nombra una señal temprana.", "¿Qué suele ocurrir antes de que aumente la irritación?"),
                new("Bajar la tensión con seguridad", 3, [P("Si puedes, aléjate a un lugar seguro y ralentiza la respiración o mira a tu alrededor. No tienes que quedarte en una discusión.")], "Elige una forma segura de hacer una pausa.", "¿Cómo sabrás que necesitas parar?"),
                new("Elegir qué hacer después", 3, [P("Cuando baje la intensidad, nombra lo que necesitas: tiempo, claridad, ayuda o un límite. Puedes volver más tarde o no hacerlo si no es seguro.")], "Prepara una petición o acción para otra vez.", "¿Qué podría evitar que llegues al límite?")
            ]),
        new(
            CourseIds.ConflictRepair,
            "Reparar el vínculo tras una discusión",
            "Asume tu parte, discúlpate sin presionar y acuerda un siguiente paso.",
            "Forum", "who5", "WHO-5",
            [
                new("Describir una acción, no etiquetar", 3, [P("Tras una discusión, nombra una acción concreta en vez de definir a alguien como malo. Retomar el contacto solo es una opción si es seguro."), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas. No mide esta habilidad ni demuestra el efecto del curso.", "who5"), Crisis("Necesito ayuda ahora")], "Describe tu parte con un hecho.", "¿Qué te gustaría aclarar?"),
                new("Disculparte de forma concreta", 3, [P("Una disculpa nombra la acción y su posible efecto, sin excusas ni exigir perdón. Puedes decir qué intentarás hacer distinto.")], "Escribe una disculpa breve sin añadir «pero».", "¿De qué estás dispuesto a responsabilizarte?"),
                new("Dejar espacio para responder", 3, [P("Permite que la otra persona responda y marque sus límites. La reconciliación no está garantizada; a veces basta un acuerdo práctico.")], "Elige una petición o límite que quieras hablar.", "¿Qué resultado sería aceptable y seguro?")
            ]),
        new(
            CourseIds.LifeTransitions,
            "Adaptarse a los cambios a tu ritmo",
            "Conserva apoyos conocidos, nombra lo que cambió y elige un paso posible.",
            "TrackChanges", "pss10", "PSS-10",
            [
                new("Nombrar lo que cambió", 3, [P("Un trabajo nuevo, una mudanza, los estudios o un cambio familiar pueden afectar varias rutinas. No tienes que adaptarte deprisa."), TestsTab("PSS-10 evalúa el estrés percibido durante el último mes. No mide esta habilidad ni demuestra el efecto del curso.", "pss10"), Crisis("Necesito ayuda ahora")], "Nombra un cambio y cómo afecta tu día.", "¿Qué es más difícil o diferente ahora?"),
                new("Conservar un apoyo conocido", 3, [P("Mantén una rutina sencilla que sostenga tu ritmo: una comida, un paseo corto, una conversación o un ritual nocturno. Adáptala a las nuevas condiciones.")], "Elige un apoyo conocido para esta semana.", "¿Qué puedes conservar aunque todo cambie?"),
                new("Dar el siguiente paso", 3, [P("Divide la adaptación en preguntas pequeñas: qué aprender, a quién pedir ayuda y qué puede esperar. Tu ritmo puede variar.")], "Elige una pregunta o acción para estos días.", "¿Qué apoyo haría más fácil el cambio?")
            ]),
        new(
            CourseIds.GriefAtYourPace,
            "Vivir el duelo a tu ritmo",
            "Sin plazos ni etapas obligatorias: cuida necesidades básicas y busca apoyo.",
            "Healing", "who5", "WHO-5",
            [
                new("Dar espacio a lo que sientes", 3, [P("Tras una pérdida, cada persona siente cosas distintas. El duelo no tiene un calendario obligatorio ni una forma correcta de vivirlo."), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas. No mide esta habilidad ni demuestra el efecto del curso.", "who5"), Crisis("Necesito ayuda ahora")], "Nombra lo que más cuesta o lo que aún no quieres hacer.", "¿Qué te gustaría permitirte hoy?"),
                new("Hacer el día más llevadero", 3, [P("En un día difícil, elige una necesidad básica o una tarea pequeña. Puedes pedir a alguien cercano que te acompañe o ayude con algo práctico.")], "Reduce una tarea a un paso posible.", "¿Qué cuidado necesitas hoy?"),
                new("No llevarlo a solas", 3, [P("Si quieres, encuentra una forma de recordar o hablar de la pérdida. Si el duelo dificulta la vida diaria durante mucho tiempo, puedes buscar apoyo profesional.")], "Elige una persona o servicio al que acudir.", "¿Qué apoyo te vendría bien ahora?")
            ]),
        new(
            CourseIds.ReturnToFocus,
            "Volver al foco después de una interrupción",
            "Anota la distracción, elige la siguiente acción y retoma con suavidad.",
            "TipsAndUpdates", "who5", "WHO-5",
            [
                new("Notar la interrupción", 3, [P("Distraerse es normal al trabajar. Observa qué te apartó: una notificación, un pensamiento, el cansancio o un paso poco claro."), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas. No mide esta habilidad ni demuestra el efecto del curso.", "who5"), Crisis("Necesito ayuda ahora")], "Nombra una fuente habitual de interrupción.", "¿Qué suele romper más tu concentración?"),
                new("Anotar y volver", 3, [P("Anota brevemente la tarea que te distrae para no tenerla en la cabeza. Después, elige una acción para retomar la tarea actual.")], "Haz una nota y elige una acción de cinco minutos.", "¿Qué primer paso te devolvería a la tarea?"),
                new("Facilitar el entorno", 3, [P("Quita una interrupción opcional y decide qué hacer la próxima vez. Si tienes mucho cansancio, descansar puede ayudar más que insistir.")], "Cambia un ajuste del espacio o las notificaciones.", "¿Qué te ayuda a retomar sin reproches?")
            ]),
        new(
            CourseIds.StudyBlocks,
            "Estudiar en bloques cortos",
            "Elige una meta de aprendizaje, un rato breve de concentración y una pausa.",
            "Checklist", "pss10", "PSS-10",
            [
                new("Fijar una meta de estudio", 3, [P("Elige un resultado claro para una sesión: resolver un ejercicio, leer una sección breve o explicar un tema. La meta grande puede esperar."), TestsTab("PSS-10 evalúa el estrés percibido durante el último mes. No mide esta habilidad ni demuestra el efecto del curso.", "pss10"), Crisis("Necesito ayuda ahora")], "Anota un resultado para una sesión corta.", "¿Cómo sabrás que terminó?"),
                new("Encontrar tu ritmo", 3, [P("Elige una duración de concentración y pausa que te vaya bien. El temporizador estándar es opcional; adáptalo a tu atención y salud.")], "Prueba un bloque corto y luego descansa.", "¿Qué ritmo te resultó posible?"),
                new("Comprobar lo que recuerdas", 3, [P("Después de la pausa, intenta recordar lo principal sin mirar y luego comprueba el material. Un olvido indica qué repasar, no cuánto vales.")], "Nombra tres cosas que recuerdas.", "¿Qué podrías repasar después?")
            ]),
        new(
            CourseIds.BodyNeutrality,
            "Mirar la apariencia con más neutralidad",
            "Reduce comparaciones, observa sin juzgar y vuelve a actividades importantes.",
            "Healing", "who5", "WHO-5",
            [
                new("Notar la atención a la apariencia", 3, [P("A muchas personas les disgusta su apariencia a veces, pero comprobar y comparar repetidamente puede consumir energía. No tienes que amar cada rasgo."), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas. No mide esta habilidad ni demuestra el efecto del curso.", "who5"), Crisis("Necesito ayuda ahora")], "Observa cuándo esos pensamientos ocupan tu atención.", "¿Qué pospones por esos pensamientos?"),
                new("Probar una mirada neutral", 3, [P("En vez de juzgar, describe lo que notas o lo que tu cuerpo te permite hacer hoy. No tienes que sentir gratitud ni satisfacción.")], "Cambia un juicio por una observación neutral.", "¿Qué palabras son menos duras y más precisas?"),
                new("Volver a lo importante", 3, [P("Elige una actividad que importe por otros motivos: relacionarte, estudiar, descansar o disfrutar. Si las preocupaciones afectan la alimentación, la salud o la vida diaria, busca apoyo profesional.")], "Retoma una actividad pequeña que habías pospuesto.", "¿Qué te importa más allá de la apariencia?")
            ]),
        new(
            CourseIds.SelfWorth,
            "Vales más que tus logros",
            "Reconoce tus roles y cualidades fuera de los resultados y elige una acción significativa.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Mirar más allá de los resultados", 3, [P("El trabajo y el éxito son parte de la vida, no miden todo tu valor. Recuerda roles, vínculos y cualidades importantes aunque no seas productivo."), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas. No mide esta habilidad ni demuestra el efecto del curso.", "who5"), Crisis("Necesito ayuda ahora")], "Nombra un rol o cualidad importante para ti.", "¿Qué tiene valor en ti sin un resultado?"),
                new("Encontrar un ejemplo concreto", 3, [P("Recuerda un gesto pequeño de amabilidad, valentía, curiosidad o confianza. Un ejemplo basta; no tienes que demostrar que siempre eres así.")], "Encuentra un ejemplo reciente.", "¿Qué sueles pasar por alto de ti?"),
                new("Actuar según lo importante", 3, [P("Elige una acción que exprese una cualidad valiosa para ti, sin depender de logros ni elogios. Puede ser muy pequeña.")], "Haz o planea una acción así.", "¿Qué dice ese paso de tus prioridades?")
            ]),
        new(
            CourseIds.SocialSteps,
            "Dar pequeños pasos en situaciones sociales",
            "Elige un contacto seguro, revisa tus expectativas y avanza a tu ritmo.",
            "Group", "gad7", "GAD-7",
            [
                new("Elegir una situación posible", 3, [P("Si las situaciones sociales te preocupan, empieza por una que resulte algo difícil pero segura. Puedes rechazar un paso que no te convenga."), TestsTab("GAD-7 mide la ansiedad general de las últimas dos semanas; no es un diagnóstico ni una prueba de esta habilidad.", "gad7"), Crisis("Necesito ayuda ahora")], "Elige un contacto breve que te importe.", "¿Qué parece posible en vez de perfecto?"),
                new("Revisar una expectativa", 3, [P("Antes del contacto, anota qué temes y qué más podría pasar. No tienes que demostrar que el temor es falso; deja sitio a otros resultados.")], "Anota una predicción y una alternativa.", "¿Qué notaste durante el contacto?"),
                new("Aprender de la experiencia", 3, [P("Después, anota qué ayudó, qué costó y qué siguiente paso te conviene. Tú eliges el ritmo, la repetición y las pausas.")], "Elige repetir, reducir o pausar el paso.", "¿Qué te ayudó a sentirte más seguro?")
            ]),
        new(
            CourseIds.AppointmentPreparation,
            "Prepararte para una cita importante",
            "Reúne preguntas, define tu prioridad y aclara los siguientes pasos con un profesional.",
            "Forum", "pss10", "PSS-10",
            [
                new("Nombrar lo principal", 3, [P("Antes de la cita, decide qué pregunta importa más y qué quieres comentar. No tienes que diagnosticarte de antemano."), TestsTab("PSS-10 evalúa el estrés percibido durante el último mes. No mide esta habilidad ni demuestra el efecto del curso.", "pss10"), Crisis("Necesito ayuda ahora")], "Escribe el tema principal en una frase.", "¿Qué no quieres olvidar preguntar?"),
                new("Preparar notas breves", 3, [P("Si te sirve, anota cuándo empezó la preocupación, qué cambió y qué medicación o dudas importan. Puedes ir con alguien si así lo quieres.")], "Prepara hasta tres preguntas u observaciones.", "¿Qué nota te ayudaría a hablar?"),
                new("Aclarar el plan", 3, [P("Pide al profesional que explique palabras poco claras y el siguiente paso. Puedes volver a preguntar o decir que aún no quieres decidir.")], "Prepara una frase para pedir claridad o tiempo.", "¿Qué te ayudaría a entender el plan?")
            ]),
        new(
            CourseIds.WaitingForAnswer,
            "Llevar mejor la espera de una respuesta",
            "Limita las comprobaciones, conserva rutinas y elige lo que depende de ti.",
            "Psychology", "gad7", "GAD-7",
            [
                new("Separar espera y control", 3, [P("Esperar una respuesta puede ocupar mucha atención aunque no puedas acelerar la llegada. Separa lo que puedes hacer de lo que no controlas."), TestsTab("GAD-7 mide la ansiedad general de las últimas dos semanas; no es un diagnóstico ni una prueba de esta habilidad.", "gad7"), Crisis("Necesito ayuda ahora")], "Anota una cosa de cada grupo.", "¿Qué puedes hacer y qué toca esperar?"),
                new("Fijar cuándo volver a mirar", 3, [P("Elige una hora razonable para revisar mensajes o el estado. Entre tanto, vuelve a una tarea corriente o descansa.")], "Fija la próxima hora para comprobarlo.", "¿Qué te ayudaría a no revisar por impulso?"),
                new("Prepararte para ambas opciones", 3, [P("Elige un pequeño paso tanto si llega respuesta como si se retrasa. No es una predicción; te devuelve opciones mientras esperas.")], "Fija cuándo preguntarás de nuevo si hace falta.", "¿En qué quieres apoyarte mientras esperas?")
            ]),
        new(
            CourseIds.AskForHelp,
            "Pedir ayuda concreta",
            "Nombra lo que necesitas, a quién podrías pedirlo y qué petición sería posible.",
            "Group", "who5", "WHO-5",
            [
                new("Identificar lo que necesitas", 3, [P("Una petición concreta se entiende mejor: tiempo, conversación, información o ayuda en una tarea. No tienes que poder con todo a solas."), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas. No mide esta habilidad ni demuestra el efecto del curso.", "who5"), Crisis("Necesito ayuda ahora")], "Nombra una necesidad sin justificarla.", "¿Qué ayuda cambiaría algo, aunque sea poco?"),
                new("Elegir persona y palabras", 3, [P("Piensa quién podría ayudar con eso. Una petición breve, con acción y momento claros, facilita la respuesta.")], "Redacta una frase para pedir ayuda.", "¿A quién y cuándo podrías preguntarle?"),
                new("Dejar espacio a distintas respuestas", 3, [P("La persona puede aceptar, proponer otra cosa o decir que no. Tu necesidad sigue importando; puedes acudir a alguien más o a un servicio.")], "Elige una opción alternativa de apoyo.", "¿Cómo te cuidarás después de pedirlo?")
            ]),
        new(
            CourseIds.CaregiverLimits,
            "Cuidar a alguien sin olvidarte de ti",
            "Comparte tareas, nombra tus límites y busca apoyos adicionales.",
            "Group", "pss10", "PSS-10",
            [
                new("Ver todo el trabajo de cuidado", 3, [P("Apoyar a alguien puede implicar muchas tareas invisibles. Anota las principales y piensa cuáles requieren realmente tu participación."), TestsTab("PSS-10 evalúa el estrés percibido durante el último mes. No mide esta habilidad ni demuestra el efecto del curso.", "pss10"), Crisis("Necesito ayuda ahora")], "Nombra una tarea que se pueda hablar o compartir.", "¿Qué te agota más ahora?"),
                new("Nombrar un límite", 3, [P("Un límite no significa abandonar a alguien. Describe con sinceridad el tiempo, la energía o la ayuda que puedes ofrecer sin riesgo.")], "Formula un límite para tu apoyo.", "¿Cómo podrías decirlo con claridad y calma?"),
                new("Buscar más apoyos", 3, [P("Piensa en personas, servicios o soluciones prácticas que puedan compartir la carga. Si el cuidado no puede hacerse de forma segura, pide ayuda profesional o urgente.")], "Elige un apoyo adicional.", "¿A quién podrías contactar esta semana?")
            ]),
        new(
            CourseIds.LowEnergyRoutine,
            "Un plan amable para días con poca energía",
            "Conserva lo imprescindible, reduce el primer paso e incluye descanso.",
            "TipsAndUpdates", "who5", "WHO-5",
            [
                new("Elegir lo mínimo", 3, [P("En un día con poca energía no tienes que cumplir tu plan habitual. Elige una tarea necesaria y lo que puede esperar."), TestsTab("WHO-5 es un cribado general del bienestar de las últimas dos semanas. No mide esta habilidad ni demuestra el efecto del curso.", "who5"), Crisis("Necesito ayuda ahora")], "Reduce la lista a una cosa importante.", "¿Qué de verdad no puede esperar hoy?"),
                new("Reducir el primer paso", 3, [P("Divide la tarea en una acción de dos minutos y prepara lo necesario. Si sigue siendo demasiado, pide ayuda.")], "Elige el paso seguro más pequeño.", "¿Qué lo haría más fácil?"),
                new("Incluir recuperación", 3, [P("Planea una pausa breve sin tener que ganártela. Si el cansancio o el ánimo bajo dificultan la vida durante tiempo, puedes buscar apoyo profesional.")], "Elige una pausa sencilla o a alguien a quien contactar.", "¿Qué te ayudaría a no llevarlo a solas?")
            ]),
        new(
            CourseIds.AfterDifficultTalk,
            "Recuperarte tras una conversación difícil",
            "Vuelve al presente, separa hechos de suposiciones y elige un siguiente paso seguro.",
            "Psychology", "pss10", "PSS-10",
            [
                new("Bajar la tensión", 3, [P("Después de una conversación difícil, el cuerpo puede necesitar tiempo. Busca un apoyo, mira alrededor y nombra dónde estás. No tienes que decidir aún quién tenía razón."), TestsTab("PSS-10 evalúa el estrés percibido durante el último mes. No mide esta habilidad ni demuestra el efecto del curso.", "pss10"), Crisis("Necesito ayuda ahora")], "Haz una pausa breve y observa el entorno.", "¿Qué te ayuda a estar aquí y ahora?"),
                new("Separar palabras y conclusiones", 3, [P("Anota por separado lo que se dijo o hizo y lo que supones que significaba. No invalida tus emociones; ayuda a elegir qué hacer.")], "Separa un hecho de una interpretación.", "¿Qué sabes y qué estás suponiendo?"),
                new("Elegir si continuar", 3, [P("Puedes aclarar algo, pedir tiempo o no retomar el contacto. Si hubo amenazas o control, no vuelvas a esa conversación a solas.")], "Elige una opción segura para la próxima vez.", "¿Qué límite o apoyo necesitas?")
            ]),
    ];
}
