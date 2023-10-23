# Balta Challenge

This project was built during the week of Balta.io challenge that was to build an api to use ibge code , to create locales with the following properties:

- Id
- State
- City

Also was creating a user to be able to authenticate and use this api with the following properties:

- Name
- Email
- Password

#### Create a New User

```http
  POST /api/v1/accounts
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `name`    | `string` | **Required**. Name for the new user |
| `email`   | `string` | **Required**. Email for the new user |
| `password`| `string` | **Required**. Password for the new user |

#### Authenticate new user

```http
  POST /api/v1/authenticate
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `email`   | `string` | **Required**. Email of the user to authenticate |
| `password`| `string` | **Required**. Password of the user to authenticate |

#### Create new locale

```http
  POST /api/v1/locales
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`   | `string` | **Required**. Id (IBGE Code) |
| `state`| `string` | **Required**. State acronym |
| `city`| `string` | **Required**. Name of the city  |

#### Get a locale

```http
  POST /api/v1/locales
```

- 0 => código do IBGE
- 1 => Estado
- 2 => Cidade

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `expression`   | `string` | **Required**. String of the correspondent filter (ibge code, state, city) |
| `filter`   | `string` | **Required**. Code of the correspondent filter (0,1,2) |

#### Update  a locale

```http
  PUT /api/v1/locales
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`   | `string` | **Required**. Id (IBGE Code) |
| `state`| `string` | **Required**. State acronym |
| `city`| `string` | **Required**. Name of the city  |

#### Delete  a locale

```http
  DELETE /api/v1/locales
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`   | `string` | **Required**. Id (IBGE Code) |

## Authors

- Gabriel Moya
- Thallison Oliveira
- Henrique Aurelio