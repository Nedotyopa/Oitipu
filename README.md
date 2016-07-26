# ToplivoCodeFirst
Проект находится в процессе создания.

Проект MS Visual Studio 2015 содержит пример MVC 5 ASP .NET относительно простого приложения. Может быть полезен для выполнения лабораторных работ и курсового проекта по дисциплине "Разработка приложений баз данных для информационных систем".

Для работы с реляционной базой данных TOPLIVO СУБД MS SQL Server создан класс контекста ToplivoContext и классы объектов Fuel, Tank, Operation. Entity Framework на основе классов Fuel, Tank, Operation создает в базе данных три таблицы:  Fuels (виды топлива), Tanks (список емкостей для хранения), Operations (факты совершения операций прихода, расхода топлива в емкостях). 

Проект содержит два разных инициализатора базы данных, которые генерирует наборы тестовых записей в таблицах Fuels, Tanks и Operations.

Типовые операции с данными (CRUD) описаны в интерфейсе IRepository. На основе интерфейса IRepository реализованы классы FuelRepository, TankRepository, OperationRepository, которые определяют специфику реализации операций с данными применительно к соответствующим  объектам (таблицам).

Для упрощения работы с различными репозиториями реализован паттерн Unit of Work (класс UnitOfWork). Это позволяет гарантировать, что все репозитории будут использовать один и тот же контекст данных. Доступ к конкретному репозитарию в котроллерах осуществляется как вызов саойства экземпляра UnitOfWork. 

Для работы с данными таблиц использован ОRM фреймворк Entity Framework 6.1.

