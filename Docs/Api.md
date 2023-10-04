# Dinner Booking API

- [Dinner Booking Api](#dinner-booking-api)
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
POST {{host}}/api/auth/register
```

### Register Request 

```json
{
    "firstName" : "Rahul",
    "lastName" : "Dey",
    "email" : "rahul@admin.com",
    "password" : "!Admin@123"
}
```

### Register Response

```js
200 OK
```

```json
{
  "data": {
    "id": "873d888c-058d-4f71-bb98-d6b24c2a244e",
    "firstName": "Rahul",
    "lastName": "Dey",
    "email": "rahul@admin.com",
    "token": "eyJhbGci....9dVpftZoMtU6_8"
  },
  "isSuccess": true,
  "errors": null,
  "message": "Register Successful"
}
```

### Login

```js
POST {{host}}/api/auth/login
```

### Login Request 

```json
{
    "email" : "rahul@admin.com",
    "password" : "!Admin@123"
}
```

### Login Response

```js
200 OK
```

```json
{
  "data": {
    "id": "d14729d9-2be0-41c5-8e76-d6796724c11e",
    "firstName": "first name",
    "lastName": "last name",
    "email": "rahul@admin.com",
    "token": "eyJhbGci....9dVpftZoMtU6_8"
  },
  "isSuccess": true,
  "errors": null,
  "message": "Login Successful"
}
```