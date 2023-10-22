
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


## Authors

- Gabriel Moya
- Thallison Oliveira
- Henrique Aurelio