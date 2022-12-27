# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
    - [Register Request](#register-request)
    - [Register Response](#register-response)
    - [Login](#login)
    - [Login Request](#login-request)
    - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

### Register Request

```json
{
    "firstName": "Amichai",
    "lastName": "Mantinband",
    "email": "test@test.com",
    "password": "Pa$$w0rd"
}
```

### Register Response

```js
200 OK
```

```json
{
    "id": "aa9e2780-220c-4a5f-9537-3335264fa10a",
    "firstName": "Amichai",
    "lastName": "Mantinband",
    "email": "test@test.com",
    "token": "eyJhb...s98gblsYHc"
}
```

<br />
<br />
### Login

```js
POST {{host}}/auth/login
```

### Login Request

```json
{
    "email": "test@test.com",
    "password": "Pa$$w0rd"
}
```

### Login Response

```js
200 OK
```

```json
{
    "id": "aa9e2780-220c-4a5f-9537-3335264fa10a",
    "firstName": "Amichai",
    "lastName": "Mantinband",
    "email": "test@test.com",
    "token": "eyJhb...s98gblsYHc"
}
```