# Описание
Сервис по обмену учебным материалам между студентами. Создано в рамках двухдневного хакатона Viribus Unitis. Сервис интегрирован в приложение [Твой ФФ](https://app.profcomff.com/)
с использованием [API авторизации](https://github.com/profcomff/auth-api) физфака.

Навигация:
- [Команда](#команда)
- [Документация к API](#документация-к-api)
- [Запуск и начало работы](#документация-и-начало-работы)
# Команда
- Ильин Артём (backend dev, team lead)
	- студент МАИ
	- Способы связи: [Телеграм](https://t.me/LightChimera)
- Романов Денис (frontend, DevOps)
	- студент МАИ
	- Способы связи: [Телеграм](https://t.me/y7o4ka)
- Меркурева София (UX/UI дизайнер)
	- судентка ВШЭ
	- Способы связи: [Телеграм](https://t.me/sofimerk)
- Чуклов Александр (​UX/UI дизайнер)
	- студент РГУ нефти и газа
	- Способы связи: [Телеграм](https://t.me/dyrtand)


# Документация к API 

## Основные сущности
- `Work` - представляет работу, которой поделился пользователь. Содержит в себе информацию о курсе, учебной дисциплине, типе работы, названии работы и файлах, котроые прикрепил пользователь.

## Works endpoints
### POST /api/v1/works
#### Описание
Endpoint для создания новой сущности Work.
Данные должны собиратьтся из формы
#### Тело запроса
form-data:
``` form-data
"Hierarchy.Course=int"
"Hierarchy.Subject=string"
"Hierarchy.WorkType=string"
"Name=string"
"Files=@filename.png;type=image/png"
```
#### Status codes
- 200 Ok
- 403 Forbidden

### GET /api/v1/works
#### Описание
Endpoint для получения массива сущностей Work.
#### Строка запроса
- `Course` - номер курса
- `Name` - название
- `WorkType` - тип выполняемой работы (дз, лекция, пз и т.д.)
- `Subject` - учебная дисциплина
- `Limit` - количество возвращаемых элементов в диапазоне [0; 30]

``` query
?Course=int&Name=string&WorkType=string&Subject=string&Limit=int
```
#### Схема возвращаемых данных
```
[
	{
	    "id": guid,
	    "hierarchy": [
			"course": int,
		    "subject": string,
		    "workType": string,
	    ],
	    "name": string,
	    "createdAt": string,
	    "files": [
	      string
	    ]
	}
]
```
#### Status codes
- 200 Ok


### GET /api/v1/works/{id}
#### Описание
Endpoint для получения конкретной сущности по ее guid.
#### Схема возвращаемых данных

```
{
	"id": guid,
	"hierarchy": [
		"course": int,
		"subject": string,
		"workType": string,
	],
	"name": string,
	"createdAt": string,
	"files": [
		string
	]
}
```
#### Status codes
- 200 Ok

### DELETE /api/v1/works/{id}
#### Описание
Endpoint для удаления конкретной сущности по ее guid.
#### Status codes
- 200 Ok
- 403 Forbidden

# Запуск и начало работы
распишу позже
