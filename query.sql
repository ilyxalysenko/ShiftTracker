-- Скрипт для создания таблицы "Контейнеры"
CREATE TABLE Контейнеры (
   ИД UNIQUEIDENTIFIER PRIMARY KEY,
   Номер INT,
   Тип NVARCHAR(255),
   Длина INT,
   Ширина INT,
   Высота INT,
   Вес INT,
   [Пустой/не пустой] BIT,
   [Дата поступления] DATETIME
);

-- Скрипт для создания таблицы "Операции"
CREATE TABLE Операции (
   ИД INT PRIMARY KEY,
   [ИД Контейнера] INT,
   [Дата начала операции] DATETIME,
   [Дата окончания операции] DATETIME,
   [Тип операции] NVARCHAR(255),
   [ФИО оператора] NVARCHAR(255),
   [Место инспекции] NVARCHAR(255)
);

--Запрос для выборки данных по контейнерам в формате JSON
DECLARE @JSON NVARCHAR(MAX)

SELECT @JSON = (
   SELECT ИД, Номер, Тип, Длина, Ширина, Высота, Вес, [Пустой/не пустой], [Дата поступления]
   FROM Контейнеры
   FOR JSON PATH, INCLUDE_NULL_VALUES
)

SELECT @JSON AS Контейнеры_JSON

--Запрос для выборки данных по операциям для определенного контейнера в формате JSON
DECLARE @JSON NVARCHAR(MAX)
DECLARE @Контейнер_ИД INT 

SELECT @JSON = (
   SELECT ИД, [ИД Контейнера], [Дата начала операции], [Дата окончания операции], [Тип операции], [ФИО оператора], [Место инспекции]
   FROM Операции
   WHERE [ИД Контейнера] = @Контейнер_ИД
   FOR JSON PATH, INCLUDE_NULL_VALUES
)

SELECT @JSON AS Операции_JSON
