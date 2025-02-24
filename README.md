# Samuel Gutierrez Muñoz

Se necesita desarrollar un sistema para gestionar los accesos de los clientes a un club
recreativo. Actualmente, el acceso al club no está automatizado, por lo que el personal será
responsable de registrar tanto las entradas como las salidas de los visitantes.
El personal autorizado deberá iniciar sesión en el sistema utilizando un nombre de usuario
y una contraseña. Se requerirá un usuario administrador con privilegios para realizar
tareas como consultas, registro, modificación y eliminación de usuarios registrados.
Cuando el personal acceda al sistema, deberá poder registrar a los clientes, los cuales se
clasifican en dos tipos:
● Visitantes: Clientes que realizan un pago por visita.
● Miembros: Clientes que cuentan con una membresía que incluye un número fijo de
visitas al mes y un pago mensual.
También se requiere enviar una notificación vía correo electrónico a los visitantes y
miembros con un mensaje de agradecimiento y la hora de entrada y salida registradas.
3
Algunos visitantes o miembros asistirán con vehículos, por lo que, junto con su registro,
también deberán registrarse los datos del vehículo (marca, modelo y placa), el nombre del
valet parking a cargo y el código de ubicación del estacionamiento. Este registro deberá
incluir la hora de entrada y salida del vehículo, independientemente del registro del
visitante.
A. Casos de uso:
1. Iniciar Sesión:
● Actor Principal: Personal autorizado.
● Descripción: El personal ingresa al sistema utilizando su nombre de usuario y
contraseña para acceder a las funcionalidades del sistema.
2. Administrar Usuarios:
● Actor Principal: Usuario administrador.
● Descripción: El administrador puede realizar tareas de consulta, registro,
modificación y eliminación de usuarios registrados en el sistema.
3. Registrar Cliente:
● Actor Principal: Personal autorizado.
● Descripción: El personal registra a un nuevo cliente en el sistema, proporcionando
los detalles relevantes como nombre, tipo de cliente (visitante, miembro),
información de contacto, etc.
4. Registrar Entrada:
● Actor Principal: Personal autorizado.
● Descripción: El personal registra la entrada de un cliente al club, asociando la
entrada con el cliente correspondiente y registrando la fecha y hora de ingreso.
● Consideraciones: El personal registra los datos del vehículo de un visitante o
miembro, así como su entrada.
5. Registrar Salida:
● Actor Principal: Personal autorizado.
● Descripción: El personal registra la salida de un cliente del club, asociando la salida
con el cliente correspondiente y registrando la fecha y hora de salida.
6. Consultar Registro de Accesos:
● Actor Principal: Personal autorizado.
4
● Descripción: El personal puede consultar el registro de accesos al club para un
cliente específico, mostrando las entradas y salidas registradas, junto con las fechas
y horas correspondientes.
7. Registrar Vehículo:
● Actor Principal: Personal autorizado.
● Descripción: El personal registra los datos del vehículo de un visitante o miembro,
incluyendo marca, modelo, placa, nombre del valet parking a cargo y código de
ubicación del estacionamiento. Este registro debe incluir la hora de entrada del
vehículo.
● Consideraciones: para este caso deberá usar una tabla con los datos de los valet
parking y con los códigos de ubicación y generar las relaciones de datos
correspondientes.
8. Registrar Salida de Vehículo:
● Actor Principal: Personal autorizado.
● Descripción: El personal registra la hora de salida de un vehículo previamente
registrado.
● Consideraciones: El vehículo podrá cerrarse de manera individual o se cerrar
automáticamente al registrar la salida del visitante.
9. Consultar Registro de Vehículos:
● Actor Principal: Personal autorizado.
● Descripción: El personal puede consultar los registros de vehículos, incluyendo
datos del vehículo, nombre del valet parking, código de ubicación del
estacionamiento, y horas de entrada y salida.
10. Enviar Notificación de Accesos por Correo Electrónico:
● Actor Principal: Sistema.
● Descripción: El sistema envía automáticamente una notificación por correo
electrónico a los visitantes y miembros con un mensaje de agradecimiento,
incluyendo la hora de entrada y salida de su última visita. Esta acción se ejecuta
automáticamente al registrar una salida.

# Documentación del Proyecto

🚀 Instrucciones de Instalación
🔧 1. Prerrequisitos
.NET 6.0 SDK o superior
Docker Desktop instalado y ejecutándose.
Postman (opcional para pruebas API).

🐳 2. Instalación de Docker
Verificar instalación de Docker: docker --version

📝 3. Configurar Docker Compose
Crea un archivo llamado docker-compose.yml en la raíz del proyecto: version: '3.1'
services:
  mysql:
    image: mysql:8.0
    restart: always
    environment:
      MYSQL_ROOT_PASSWORD: root1234
    ports:
      - "3306:3306"

🗄️ 4. Importar las tablas y los datos
Coloca los archivos init.sql y data.sql en la raíz del proyecto.

  Ejecuta el contenedor de Docker: docker-compose up -d
  Verifica que el contenedor esté en ejecución: docker ps
  Accede al contenedor y verifica la base de datos: docker exec -it clubrecreativo-mysql bash
                                                      mysql -u root -proot1234



