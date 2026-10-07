\# Especificación REST API - SISTESIS-UNI



\*\*Estudiante:\*\* Violet Gutiérrez  

\*\*Carnet:\*\* 2021-0906i  

\*\*Grupo:\*\* 5S3-SIS-S



\---



\## Base URL



http://localhost:5072/api/v1



\## Autenticación



Todos los endpoints (excepto /auth/login) requieren header:

Authorization: Bearer <JWT\_TOKEN>



\## Endpoints



\### POST /auth/login



\*\*Propósito:\*\* Autenticar usuario y obtener JWT.



\*\*Request:\*\*

{

&#x20; "username": "vguti",

&#x20; "password": "uni2026"

}



\*\*Response 200:\*\*

{

&#x20; "token": "eyJhbGciOiJIUzI1NiIs...",

&#x20; "username": "vguti",

&#x20; "expiresAt": "2026-10-07T02:26:22Z"

}



\---



\### GET /theses



\*\*Propósito:\*\* Listar todas las tesis registradas.



\*\*Response 200:\*\*

\[

&#x20; {

&#x20;   "id": "88922281-be01-4723-9dbb-574f931ea0a8",

&#x20;   "title": "Sistema de Gestion de Tesis",

&#x20;   "abstractText": "Propuesta de tesis para SISTESIS-UNI",

&#x20;   "studentId": "20190001",

&#x20;   "documentUrl": "https://blob.uni.edu.pe/tesis/20190001.pdf",

&#x20;   "status": "Submitted",

&#x20;   "createdAt": "2026-10-07T01:27:04.6691976"

&#x20; }

]



\---



\### GET /theses/{id}



\*\*Propósito:\*\* Obtener una tesis por su ID.



\*\*Parámetros:\*\*

\- id (path, GUID): ID de la tesis.



\*\*Response 200:\*\* Objeto tesis.

\*\*Response 404:\*\* Not Found si no existe.



\---



\### POST /theses



\*\*Propósito:\*\* Registrar una nueva tesis.



\*\*Request:\*\*

{

&#x20; "title": "Sistema de Gestion de Tesis",

&#x20; "abstractText": "Propuesta de tesis para SISTESIS-UNI",

&#x20; "studentId": "20190001",

&#x20; "documentUrl": "https://blob.uni.edu.pe/tesis/20190001.pdf"

}



\*\*Response 201:\*\* GUID de la tesis creada.

Con header Location: http://localhost:5072/api/v1/theses/{id}



\---



\### PATCH /theses/{id}/status



\*\*Propósito:\*\* Actualizar el estado de una tesis.



\*\*Parámetros:\*\*

\- id (path, GUID): ID de la tesis.



\*\*Request:\*\*

2



\*\*Estados posibles:\*\*



| Valor | Estado |

|-------|--------|

| 1 | Submitted |

| 2 | UnderReview |

| 3 | Approved |

| 4 | Rejected |



\*\*Response 204:\*\* No Content.



\## Códigos HTTP



| Código | Significado |

|--------|-------------|

| 200 | OK |

| 201 | Created |

| 204 | No Content |

| 400 | Bad Request |

| 401 | Unauthorized |

| 404 | Not Found |

| 413 | Payload Too Large |

| 500 | Internal Server Error |



\## Swagger UI



Disponible en: http://localhost:5072/swagger/index.html



Botón Authorize: permite pegar el JWT para autenticar todas las peticiones.

