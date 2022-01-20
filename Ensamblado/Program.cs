/*
 * Un trozo de código (precompilado) que puede ser ejecutado por el entorno de tiempo de ejecución .NET
 * Un programa .NET consta de uno o más ensamblados.
 * El ensamblaje es la unidad más pequeña de implementación de una aplicación .net. Puede ser un dll o un exe .
 * Hay principalmente dos tipos:
* ENSAMBLADO PRIVADO: el dll o exe que es propiedad exclusiva de una sola aplicación.
* Generalmente se almacena en la carpeta raíz de la aplicación
*
* ENSAMBLADO PUBLICO / compartido: es un archivo dll que puede ser utilizado por múltiples aplicaciones a la vez.
* Un ensamblado compartido se almacena en GAC, es decir , la caché de ensamblados global .
*
* ¿Suena dificil? Naa ....
* GAC es simplemente C: \ Windows \ Assembly carpeta donde puede encontrar los ensamblados / dlls públicos de todos los softwares instalados en su PC.
* También hay un tercer tipo y menos conocido de ensamblaje: el ensamblaje satelital .
* Un conjunto de satélites contiene solo objetos estáticos como imágenes y otros archivos no ejecutables requeridos por la aplicación.
* [El Global Assembly Cache (GAC) es una carpeta en el directorio de Windows para almacenar los ensamblados]
* CLR: Common Language Runtime permite 2 tipo de ensambado
* FIRMADO,
* REGULAR
 */
Console.WriteLine("Hellow wolrd");