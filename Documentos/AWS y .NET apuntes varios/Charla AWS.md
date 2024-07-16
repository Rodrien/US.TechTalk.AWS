# Ideas
Basado en el siguiente curso de Nick Chapsas:
https://dometrain.com/course/cloud-fundamentals-aws-services-for-c-developers/

slide de ejemplo encontrado: 
https://www.slideshare.net/slideshow/aws-pptpptx-255161828/255161828


## Idea general de porque esta tech talk
Con la industria en el momento en el que se encuentra teniendo un pie tan fuerte en todo lo que es cloud, es de valor que los desarrolladores tengan la capacidad al menos básica para poder llevar a cabo proyectos en el proveedor de servicios cloud que el cliente requiera, dicho esto, esta charla busca darle al desarrollador un acercamiento a lo que es AWS con .NET.

En cuanto a los desarrolladores la idea es poder brindarles los conocimientos generales para que cuando quieran o necesiten realizar un proyecto con AWS y .NET tengan el conocimiento básico necesario para empezar.

## Componentes 
- AWS SQS (Simple Queue Service) [[SQS]]
- AWS SNS (Simple Notification Service) [[SNS]]
	- Topics instead of queues
	- pub sub
	- filtering
- DynamoDB
	- attributes
	- partirion key
	- sort key
	- Indixes
		- GSI
		- LSI
	- Streams
	- auto scale
	- pricing
		- puede ser muy muy barato y muy muy barato
		- No sirve para guardar archvis!! Ni base64, poder se puede pero para eso se usa s3 por tema precios
		- No se usan SCANS!! Horror!
		- Buen modelado de informacion hace que no necesites GSI y LSI, lo que ahorra dinero.
		- 
- AWS S3 (NO es S3 Glacier)
	- stored objects
	- buckets
		- que es un bucket?
	- huge service
	- bucket locked feature
	- Basic features
	- Reacting to changes 
	- Comprimir contenido de manera asincrona MUY UTIL con lambda! 
	- versionado de objects
		- version id
		- tiene rollback
- AWS Secrets Manager
	- Pagos
		- Se paga por request! 
		- prueba gratuita por 30 dias
		- puede llegar a ser muy costoso en caso no armar una solucion correcta. 
	- Que es importante cuando se manejan claves? 
		- Minimizar riesgo
		- Automatic Rotation!
	- secret type
	- encryptado automatico
		- at rest 
		- in transit
	- versionado de secrets
	- elegant secret loading in aspnet application
		- paquete de un comunity member, MUY BUENO y recomendado antes del oficial
	- update running services when key rotaded
		- polling interval
			- 10 min o 30 min o 1 hora, depende
- AWS Lambda (Serverless)
	- Cobran por segundos de computo
	- Glue of AWS
	- Que es? -> Serverless 
	- buen scaling 
	- aws lambda puede ser un container image
	- Se puede ejecutar los lambda desde la consola directamente
		- .net lambda core CLI tool (mejor que el de AWS)
		- lambda templates para proyectos .net
	- Trigger
		- configuracion de un trigger de forma sencilla
		- 
	- Destinations
	- Invokar lambda con http request
	- debugging lambdas localmente!
		- lambda test tool
			- se puede instalar como una herramienta de linea de comando
	- lambda con SQS queue!!
	- Se podria hacer con SNS pero no es recomendable.
		- mejor con SQS
	- Se puede consumir cambios de DynamoDb tambien! -> muy util
		- actualizacion de password por ejemplo del usuario almacenado.
	- Se puede consumir evento de S3
		- Por ejemplo para comprimir archivos que se subieron! 
		- O dado una imagen poder hacer otras versiones de lo mismo.
		- OJO Con los loops infinitos!! 
			- No se recomienda subir objects al mismo lugar que hace el trigger porque genera un loop infinito!! 
			- Se puede hacer el trigger por carpeta dentro del bucket para que no se genere el loop
			- O se puede filtrar con un metadato con una condicional en el codigo. 
	- Se puede correr una API como una lambda D:
		- como poder podes, ojo con los cold starts porque ahi puede ser mas lento
	- Custom runtimes
		- 

	- Normalmente tenemos roles para cada lambda limitando los accesos para cada una.
	- 

Ver que es cada componente, para que sirven.

 
 ## Demo
- solución armada con cada componente anterior.
- Ver arquitectura de la solución, grafo con cada componente y el flujo de datos. 
- Un vistazo al sitio de AWS, como crear alguno de los componentes anteriores. 

# Ideas
- Podria ante cada parte poner una pregunta para hacer la intro de la funcionalidad o de la seccion
- Hacer parte de cuidados! Possibles problemas como los mencionados mas arriba! 

# Interacciones con AWS
![[Pasted image 20240706185441.png]]



# Todo
- [x] Terminar de ver curso nick chappas
- [ ] Armar PPT / Canva
- [ ] Probar cositas AWS
- [ ] Armar solucion
- [ ] 

