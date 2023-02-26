# Product Management
JobApplication - ASP.NET API WEB Service

Сервис предоставляет доступ ко внутренней БД посредством взаимодействия с API.

- Для тестирования используется localhost.

- При деплое брать строку подключения из конфигурационного файла/.ccv file, на данный момент строка указывается в качестве параметра EF optionsBuilder.

**Сервис реализует такие HTTP запросы как:**<br /> <br />
***api/Products/...***<br />
<br />
-HTTP GET - получить список всех имеющихся товаров<br />
<br />
-HTTP GET/{id} - получить доступ к товару по ID<br />
<br />
-HTTP DELETE{id} - удалить товар из БД<br />
<br />
***api/Orders/...***<br />
<br />
-HTTP POST {params} - создать заказ<br />
<br />
-HTTP DELETE {id} - удалить заказ 

