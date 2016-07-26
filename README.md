# ToplivoCodeFirst
Проект находится в процессе создания.

Проект MS Visual Studio 2015 содержит простой пример MVC 5 ASP .NET приложения. Может быть полезен для выполнения лабораторных работ и курсового проекта по дисциплине разработка приложений баз данных для информационных систем.
Проект содержит инициализаторы базы данных TOPLIVO СУБД MS SQL Server, к которой потом осуществляется обращение. 
Для работы с базой данных создан класс контекста ToplivoContext и классы объектов Fuel, Tank, Operation. Entity Framework на основе классов Fuel, Tank, Operation создает три таблицы:  Fuels (виды топлива), Tanks (список емкостей для хранения), Operations (факты совершения операций прихода, расхода топлива в емкостях).
Инициализаторы генерирует наборы тестовых записей в этих таблицах.
Типовые операции с данными (CRUD) описаны в интерфейсе IRepository. На основе IRepository реализованы классы FuelRepository, TankRepository, OperationRepository, которые содержат специфику реализации операций с данными в соответсвующих таблицах.

Для построения моделей, работающих с данными таблиц, использован Entity Framework 6.1.

