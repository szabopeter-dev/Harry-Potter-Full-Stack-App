
# Hogwarts Potions API

This is a solo project from the Advanced C# Asp.net module of codecool .(10th month of the 12 month long curriculum)
With this project I learned about the following topics:
- Entity Framework Core
- Code-first approach
- SQL Server database connection
- Asynchronous programming

# Description

Its a Harry Potter themed project, you can manage potions with requests,
 to use CRUD operations on the entity framework core database.


## API Reference

#### Get all potions

```http
  GET /potions
```

#### Add new potion

```http
  POST /potions/${id}
```

Request body example:

{
        "name": "TestPotion",
        "ingredients": [
            {
                "name": "Ingredien1"
            },
            {
                "name": "Ingredien2"
            }
        ],
        "status": 0,
        "recipe": {
            "name": "TestRecipe",
            "brewer": null,
            "ingredients": null
        }
}


| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | Id of the brewing student |


#### Add new empty potion

```http
  POST /potions/${id}
```


| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | Id of the brewing student |


#### Get all potions brewed by student based on student id

```http
  GET /potions/${id}
```


| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | Id of the brewing student |


#### Add ingredient to potion

```http
  POST /potions/${id}/add
```

Request body example:

{
        "name": "TestIngredient",
}


| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | Id of the potion |


#### Get all recipes based on ingredients of the potion

If there is any recipe in the database you will get back all which contains any of the ingredients what the potion already has.

```http
  POST /potions/${id}/help
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | Id of the potion |

## Run Locally

Open terminal, 
Clone the project

```bash
  git clone https://github.com/CodecoolGlobal/hogwarts-potions-csharp-vmarcell96
```

Go to the project directory

```bash
  cd .\hogwarts-potions-csharp-vmarcell96
```

Start the application

```bash
  dotnet run
```


## Roadmap

- Adding frontend to the application

