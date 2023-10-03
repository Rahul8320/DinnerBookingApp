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
  "firstName": "Rahul",
  "lastName": "Dey",
  "email": "rahul@admin.com",
  "password": "!Admin@123"
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
  "email": "rahul@admin.com",
  "password": "!Admin@123"
}
```