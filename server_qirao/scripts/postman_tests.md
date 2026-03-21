# Datos de prueba para Postman - server_qirao

## Pasos previos
1. Ejecuta `01_create_tables.sql` en tu base de datos Railway
2. Ejecuta `02_seed_quiz_data.sql` para cargar los 18 niveles con preguntas
3. Levanta el servidor: `dotnet run`
4. El servidor estará en `https://localhost:{puerto}/api`

---

## 1. POST /api/sync-user-data

**URL:** `https://localhost:{puerto}/api/sync-user-data`
**Method:** POST
**Headers:** `Content-Type: application/json`

### Body (raw JSON):

```json
{
  "user": {
    "id": "abc123-test-user-001",
    "name": "Erick",
    "lastName": "Soto",
    "age": "25",
    "keyAccessUser": "erick-key-001",
    "pais": "Peru",
    "language": "es",
    "gamificationEnabled": true,
    "lastSyncDate": "2026-03-20T10:00:00.000Z"
  },
  "quizProgress": [
    {
      "id": "1",
      "number": 1,
      "isLocked": false,
      "isCompleted": true,
      "stars": 3,
      "points": 150
    },
    {
      "id": "2",
      "number": 2,
      "isLocked": false,
      "isCompleted": true,
      "stars": 2,
      "points": 100
    },
    {
      "id": "3",
      "number": 3,
      "isLocked": false,
      "isCompleted": false,
      "stars": 0,
      "points": 0
    },
    {
      "id": "4",
      "number": 4,
      "isLocked": true,
      "isCompleted": false,
      "stars": 0,
      "points": 0
    }
  ]
}
```

### Respuesta esperada (200 OK):
```json
{
  "success": true,
  "message": "Datos sincronizados correctamente",
  "syncedAt": "2026-03-20T15:30:00.000000Z"
}
```

---

## 2. GET /api/quiz/levels

**URL:** `https://localhost:{puerto}/api/quiz/levels`
**Method:** GET
**Headers:** ninguno requerido

### Respuesta esperada (200 OK):
```json
[
  {
    "id": "1",
    "number": 1,
    "name": "Nivel 1",
    "mapa": "Mapa 1",
    "questions": [
      {
        "id": 1,
        "questionText": "¿Cómo se llama el lugar?",
        "options": ["Plaza hanan", "Plaza principal", "Sol de llamas"],
        "questionTextEn": "What is the name of this place?",
        "optionsEn": ["Hanan plaza", "Main plaza", "Sun of llamas"],
        "imageUrl": "assets/modules/quiz/questions/pregunta1.png",
        "corrrectNptionIndex": 1
      }
    ]
  }
]
```

---

## 3. POST /api/sync-user-data (segundo usuario - para probar múltiples)

### Body:
```json
{
  "user": {
    "id": "xyz789-test-user-002",
    "name": "Maria",
    "lastName": "Garcia",
    "age": "30",
    "keyAccessUser": "maria-key-002",
    "pais": "Peru",
    "language": "en",
    "gamificationEnabled": true,
    "lastSyncDate": "2026-03-20T12:00:00.000Z"
  },
  "quizProgress": [
    {
      "id": "1",
      "number": 1,
      "isLocked": false,
      "isCompleted": true,
      "stars": 3,
      "points": 200
    }
  ]
}
```

---

## 4. POST /api/sync-user-data (actualizar usuario existente)

Usa el mismo `id` del usuario 1 para probar el update:

```json
{
  "user": {
    "id": "abc123-test-user-001",
    "name": "Erick",
    "lastName": "Soto Pro",
    "age": "25",
    "keyAccessUser": "erick-key-001",
    "pais": "Peru",
    "language": "es",
    "gamificationEnabled": true,
    "lastSyncDate": "2026-03-20T18:00:00.000Z"
  },
  "quizProgress": [
    {
      "id": "1",
      "number": 1,
      "isLocked": false,
      "isCompleted": true,
      "stars": 3,
      "points": 150
    },
    {
      "id": "2",
      "number": 2,
      "isLocked": false,
      "isCompleted": true,
      "stars": 3,
      "points": 180
    },
    {
      "id": "3",
      "number": 3,
      "isLocked": false,
      "isCompleted": true,
      "stars": 2,
      "points": 120
    },
    {
      "id": "4",
      "number": 4,
      "isLocked": false,
      "isCompleted": false,
      "stars": 0,
      "points": 0
    },
    {
      "id": "5",
      "number": 5,
      "isLocked": true,
      "isCompleted": false,
      "stars": 0,
      "points": 0
    }
  ]
}
```

Este test verifica que:
- El usuario se **actualiza** (no se duplica)
- El progreso existente se **actualiza** (nivel 2 sube a 3 estrellas)
- Se **agrega** progreso nuevo (niveles 3, 4, 5)
