## Temas a tratar
## Que es AWS?
## Como interactuamos?
## Servicios?

### SQS
==Idea demo:== Publicar mensaje a traves de codigo a una cola de mensajes y consumir el mismo.
Como es la primer demo aca hay que mencionar el tema de auth de la maquina que esta autenticada siempre pero que no es buena practica y es muy peligroso hacer eso en un ambiente de produccion.

Config con DLQ
### SNS
==Idea demo==: Publicar mensaje a traves de codigo a un topic y ver que efectivamente se esta publicando en varias colas de mensaje. 

Recordar la politica para permitir SNS publicar en SQS. 

Configurar el filtro de suscripcion:
``` json
{
"MessageType": ["UrudatoCreated"]
}
```
### DynamoDB
[[DynamoDb]]

Aca menciona los componentes principales y también el partition y sort keys.
==Idea demo:== Ver codigo de API para hacer el post y el  get de un archivo con el SDK, ver formato que usa dynamoDb desde el front de AWS

### S3
==Idea demo:== 
- Generar un bucket desde AWS
- Subir un archivo y ver que se encuentra hosteado en AWS utilizando c#
- Obtener archivos y procesarlos
- Ver API para post.

- Files -> Objects
- Contenedores -> Buckets
- Eventos after file upload
- Es enorme, tiene miles de cosas
- 
### Secrets Manager
==Idea demo:== Ver como configurar un secret y ver como hacer para que se obtenga automaticamente la configuracion del mismo en nuestra solucion c#. 
### Lambda [[Lambda]]
==Idea demo==: Publicar una lambda que al subir un archivo a S3 automaticamente se procese el mismo y se suba a S3 en distintos tamaños.

Mencionar que hay templates para facilitar todo, comandos para instalarlos y algun comando mas para la cli de lambda

## Como seguir con AWS?
- Otros servicios populares
- Armarse una cuenta para tener el año de prueba y meter mano
- Certificación AWS
## Fin
:) 
