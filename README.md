# PharmacyManagment
Проект разделен на 4 основных слоя 
1. Presentation Console
  Представление данных в консоли
2. Persistance
   Работа с БД, и реализация репозиториев
3. Application
  Бизнес логина приложения
4. Domain
  Основные сущности приложения

Файлы localDb расположены по пути Pharmacy.Console/Database
Sql запросы для создания БД храняться в файле Pharmacy.Console/Configuration/Db.csl
Строка подключение храниться по пути Pharmacy.Console/Configuration/settings.json
Все литералы вынесены в файлы ресурсов по пути Pharmacy.Console/Resources

Применялись паттерны Репозиторий и Абстрактная фабрика для создания репозиториев и сервисов

Запросы храняться в виде литералов в каждом методе по пути Pharmacy.Persistance/Repositories
