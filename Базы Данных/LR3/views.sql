CREATE OR REPLACE 
ALGORITHM = TEMPTABLE 
VIEW employees_v (`ID Сотрудника`, `Имя`, `Фамилия`, `Отчество`, `Адрес прописки`, `Подразделение`, `Должность`)
AS SELECT `ID Сотрудника`, `Имя`, `Фамилия`, `Отчество`, `Адрес прописки`, `Название`, `Название должности` FROM сотрудники
JOIN подразделения USING(`ID Подразделения`)
JOIN должности USING(`ID Должности`);

CREATE
ALGORITHM = MERGE
VIEW 