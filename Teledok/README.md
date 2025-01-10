# Teledok

## Тестовое задание «Теледоĸ»

Веб-сервис (тольĸо API бэĸенд) для работы с ĸлиентами.

1. С клонируйте проект на свой компьютер

```sh
    git clone https://github.com/thebrokenblow/Teledok.git
```

2. Для запуска необходимо скачать .NET 8 SDK под вашу операционную систему
   https://dotnet.microsoft.com/en-us/download/dotnet/8.0

3. Далее запустить solution проекта

4. Для миграции объектов в базу данных необходимо установить вашу строку подключения DbConnection в файле appsettings.json проекта Teledok.WebApi

![appsettings.json](https://github.com/thebrokenblow/Teledok/blob/master/Photos/appsettings.png?raw=true)

5. Далее необходимо зайти в раздел Tools -> NuGet Package Manager -> Package Manager Console

![Консоль диспетчера пакетов](https://github.com/thebrokenblow/Teledok/blob/master/Photos/Tools.png?raw=true)

6. В качестве запускаемого проекта надо выбрать Teledok.WebApi а проект по умолчанию (Default project) Teledok.Persistence

![OnlineShop.Persistence](https://github.com/thebrokenblow/Teledok/blob/master/Photos/console.png?raw=true)

7. Ввести две команды 
```sh
   Add-Migration <Название миграции>
   Update-Database
```

   ![Миграция](https://github.com/thebrokenblow/Teledok/blob/master/Photos/Migration.png?raw=true)

8. Если миграция прошла успешно, то можно запускать проект нажав на F5 или F5 + Fn

В приложении подключён Swagger для удобства тестирования.
