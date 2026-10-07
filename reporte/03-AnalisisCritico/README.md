\# Análisis Crítico: UWE vs C4 Model + API-First



\*\*Estudiante:\*\* Violet Gutiérrez  

\*\*Carnet:\*\* 2021-0906i  

\*\*Grupo:\*\* 5S3-SIS-S



\---



\## 3.1 Limitantes Operativas de UWE en SPA



UWE (UML Web Engineering) fue diseñado para modelar aplicaciones web tradicionales donde el servidor renderiza las vistas y la navegación está acoplada a la lógica de negocio. En el contexto actual de Single Page Applications (SPA), UWE presenta las siguientes limitaciones:



1\. \*\*Acoplamiento vista-lógica:\*\* Los modelos navegacionales entrelazan vistas con lógica de negocio, dificultando la separación de responsabilidades.

2\. \*\*Baja modularidad:\*\* Los cambios en la interfaz requieren actualizar múltiples diagramas, elevando la curva de mantenimiento.

3\. \*\*Orientación a SSR:\*\* UWE asume renderizado en servidor (SSR), incompatible con arquitecturas SPA donde el cliente consume APIs RESTful.

4\. \*\*Falta de contratos API:\*\* No existe un mecanismo nativo para especificar contratos DTO o endpoints RESTful.

5\. \*\*Escalabilidad limitada:\*\* No contempla microservicios, colas de mensajes ni arquitecturas orientadas a eventos.



\## 3.2 Ventajas del C4 Model + API-First



El enfoque adoptado supera estas limitaciones:



| Criterio | UWE | C4 Model + API-First |

|----------|-----|----------------------|

| Enfoque Principal | Modelado navegacional y de interfaz | Abstracción multinivel + contratos API |

| Modularidad | Baja | Alta |

| Grado de Detalle | Navegación (Space, Node, Anchor) | Nivel 1-4 (Contexto a Código) |

| Compatibilidad | Monolitos SSR | SPA, Microservicios, APIs RESTful/gRPC |

| Mantenibilidad | Curva alta | Curva baja, documentación clara |

| Contratos API | No nativo | OpenAPI / Swagger |



\## 3.3 Justificación Técnica del Rediseño



El rediseño de SISTESIS-UNI se justifica por:



1\. \*\*Necesidad de desacoplamiento:\*\* El frontend (Angular/Flutter) debe consumir APIs RESTful independientes.

2\. \*\*Escalabilidad:\*\* La arquitectura debe soportar microservicios futuros (anti-plagio, notificaciones).

3\. \*\*Mantenibilidad:\*\* Clean Architecture facilita la evolución del código sin romper dependencias.

4\. \*\*Documentación viva:\*\* Swagger UI genera documentación siempre actualizada.

5\. \*\*Estándares modernos:\*\* JWT, OpenAPI, REST son estándares de la industria.



\## 3.4 Conclusiones del Análisis



UWE cumplió su propósito en la era de las aplicaciones web tradicionales. Sin embargo, la arquitectura moderna de software académico exige un enfoque multinivel (C4) combinado con contratos API explícitos (API-First). SISTESIS-UNI adopta este enfoque, posicionándose como un sistema preparado para los próximos 10 años.

