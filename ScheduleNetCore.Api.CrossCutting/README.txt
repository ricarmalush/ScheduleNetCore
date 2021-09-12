Para crear la migración en la carpeta Persistence
	Add-Migration InitialCreate01 -OutputDir Persistence\Migrations => Cuando se quiere meter en carpeta la migración

Para crear la base de datos en el motor que estamos trabjando.
	Update-database

La carpeta DrapperConnection es por si desea trabajar con el Framework Dapper para consultas desde la propia
base de datos, con procedimientos almacenados.

CONCEPTOS SOBRE IDENTITY

La clase UserManager nos permite realizar funciones comunes con identity en nuestra aplicación, funciones como
crear un usuario, agregar un usuario un rol, agregarle un claim a un usuario etc.

La clase RolManager en cambio lo que hacemos es principalmente trabajar el crud de los roles, por ejemplo 
crear roles, borrar roles, actualizar roles.

Claims: Son informaciones acerca del usuario en las cuales podemos confiar, esta información tipicamente la emite
alguna entidad en la cual confiamos ya sea nosotros mismos o un tercero, como facebook, microsoft etc.

TESTING DE SOFTWARE

	El testin de software es el arte de medir y mantener la calidad de software para asegurar que las expectativas
	y requerimientos del usuario, el valor de negocio, los requisitos no funcionales como la seguridad, 
	confidencialidad y tolerancia a fallos y la politica operacionales se cumplan. El testing es un esfuerzo del
	equipo para conseguir un minimo de calidad y tener una "definición de hecho" entendida y aceptada por todo.
	Definición de hecho: Se puede asignar a un módulo una tarea, por eso es entendida y aceptada por todos.
	Una prueba esta resuelta cuando se han pasado todos los test se ha ido a la aplicación y se ha comprobado que
	funciona cuando el equipo de QUA va validado se ha documentado esa funcionalidad. Cuando se cierra una tarea 
	es por que se ha cerrado un check list, que son 5 o 6 puntos.
		1- He comprobado que tal cosa funciona....
		2- La he resuelto en mi local.
		3- Lo he subido en el servidor lo he probado en el servidor o en el entorno que sea.
		4- Se han pasado todos los test en verde.
		5- Documentar la Tarea.
	Esto nos da una calidad de código y se tienen que implementar desde el minuto cero.

	Caracteristicas y convenciones
		1- Convención de nombres descriptivos.
		2- Documenta los test.
		3- Errores y aserciones descriptivas.
		4- Adopta el desarrollo contra interfaces.
		5- Mantenlo simple.
		6- Mantenlo centrado: Minimo código posible.
		7- Tiene una sola aserción lógica: Nombre descriptivo
		8- Organiza y mantén los test.
		9- Testea los casos buenos, malos y los limites.

		TDD(Test-driven development): Primero se escribe el test y luego el código.

		Algunas propiedades para hacer test

		Stubs: Proporcionan respuestas predefinidas  a las llamadas realizadas durante la prueba, por lo general
		no responden en absoluto a nada fuera de lo programado para la prueba.
		Spy: Estos objetos guardan las acciones que se hacen sobre ellos. Hace una especie de seguimiento sobre
		que métodos se han llamado y con que parámetros.
		
		Mocks: Son objetos preprogramados con expectativas que forman una especificación de las llamadas que se
		espera recibir. muy similar a un spy pero no solo guardan las acciones que se hacen en ellos, también es
		necesario configurar qué comportamiento esperas cuando alguién llane a algunos de los métodos.
		
		Fake: Es un objeto que implementa complementa y que funciona, como un objeto normal sin ser simulado, pero
		se diferencia en que está falseando algo para hacer alguna cosa más fácil de probar. Un ejemplo de esto 
		podría ser un objeto que utiliza una base de datos en memoria en lugar de acceder a consultar la base de 
		datos en producción.

TEST
	Nos sirven para probar nuestro código y hay dos tipos de test los test de integración y test unitarios.

	Test de integración: Prueba de integración entre dos o más elementos, que puedan ser clases, módulos
	paquetes, subsistemas, etc... incluso la interacción dels sistema con el entorno de producción.
	ASP.NET Core admite pruebas de integración que usan marcos de pruebas unitarias y un host de web de prueba
	integrando que puede usarse para controlar las solicitudes sin sobrecargar la red.

	Las pruebas de integración suelen incluir problemas de infraestructura de la aplicación, como base de datos
	sistemas de archivos, recursos de red o solicitud de web y las respuestas.

	Se basan en los elementos de infraestructura, tienden  ser órdenes de magnitud más lentas que las pruebas 
	unitarias, por lo tanto es conveniente limitar este tipo de pruebas.

	¿Por que escribir Test?
		1- Asegurar qu el código Funciona.
		2- Mejorar la calidad del software.
		3- Detecter y controlar errores.

	En visual studio tenemos tres opciones:
		1- MsTest
		2- UNnit
		3- XUnit

	Conclusiones 
		Los test de integración dan una información global que no puede ser ignorada :
			1- Pruebas de aceptación.
			2- Pruebas de regresión.
			3- Pruebas funcionales.
			4- Menor número de test para probar la aplicación.
			5- Mantenibilidad más sencilla.

	Gran cobertura de código.

	Configuración Fuertemente Tipeada:

		En el archivo de configuración crear los valores y solo los
	llamaremos en el metodo que los vamos a utilizar. Y cuando la aplicacíon esta en funcionamiento 
	solamente cambiamos los valores en el archivo en este caso Appsettings y sigue funcionando sin 
	tener que cambiarla en toda la aplicación y sin tener que recompilar y publicar. Otra ventaja de
	Inyección de dependencia.

	Polly: 
		Es una herramienta muy importante, cuando queremos acceder a una api que esta caída, 
	y no saturarla de reintentos.En nuestro ejemplo lo configuramos en el archivo AppConfig y IAppConfig

	Git y GitHub:

	GitHub es una plataforma de alojamiento, propiedad de Microsoft, que ofrece a los desarrolladores
	la posibilidad de crear repositorios de código y guardarlos en la nube de forma segura, usando un 
	sistema de control de versiones, llamado Git.

    Facilita la organización de proyectos y permite la colaboración de varios desarrolladores en tiempo real. 
	Es decir, nos permite centralizar el contenido del repositorio para poder colaborar con los otros 
	miembros de nuestra organización.

	Commit: Es comno aceptar los cambios.
	Push: Significa enviar de mi ordenador al servidor.
	Pull: Cogera todo lo que necesitamos del servidor y lo pondrá en mi máquina.


https://www.youtube.com/watch?v=VHwCMi8kc_M
https://www.youtube.com/watch?v=pgCMTsVlHrginve
https://www.youtube.com/watch?v=fLy-R_QTjb0&t=23s
https://www.netmentor.es/entrada/inyeccion-dependencias-scoped-transient-singleton

https://www.youtube.com/watch?v=pgCMTsVlHrg      este video es pruebas unitarias inyeccion de dependencias

https://www.youtube.com/watch?v=eXiuVkRn7Ac
