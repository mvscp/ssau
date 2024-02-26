CREATE TABLE teachers(
id INT PRIMARY KEY AUTO_INCREMENT,
`name` VARCHAR(45)
);

CREATE TABLE students(
id INT PRIMARY KEY AUTO_INCREMENT,
`name` VARCHAR(45),
birth_date DATE
);

CREATE TABLE disciplines(
id INT PRIMARY KEY AUTO_INCREMENT,
`name` VARCHAR(45),
semester INT,
teacher_id INT,
FOREIGN KEY (teacher_id) REFERENCES teachers(id)
);

CREATE TABLE marks(
id INT PRIMARY KEY AUTO_INCREMENT,
student_id INT,
discipline_id INT,
mark INT,
FOREIGN KEY (discipline_id) REFERENCES disciplines(id),
FOREIGN KEY (student_id) REFERENCES students(id)
);

INSERT INTO students(`name`, birth_date)
VALUES('Иванов Иван Иванович', '2004-03-27'),
	  ('Климов Никита Даниилович', '2003-07-02'),
      ('Прокофьев Марк Георгиевич', '2003-11-04'),
      ('Савина Екатерина Данииловна', '2004-12-23'),
      ('Попов Сергей Александрович', '2003-09-14'),
      ('Лаврентьев Дмитрий Даниилович', '2004-08-21'),
      ('Ильина Анна Григорьевна', '2003-04-12');

INSERT INTO teachers(`name`)
VALUES('Орлов Алексей Иванович'),
	  ('Гаврилова Виктория Денисовна'),
      ('Петров Иван Егорович'),
      ('Павлова Александра Романовна'),
      ('Королева Анастасия Романовна');

INSERT INTO disciplines(`name`, semester, teacher_id)
VALUES('Физика', 5, 5),
	  ('Мат. анализ', 3, 2),
      ('Мат. логика', 2, 1),
      ('Философия', 7, 3),
      ('ООП', 2, 4);

UPDATE disciplines
SET teacher_id = 1
WHERE teacher_id = 0;
 
UPDATE disciplines
SET teacher_id = 5
WHERE teacher_id = 1;

INSERT INTO marks(student_id, discipline_id, mark)
VALUES(1, 1, 4),
	  (2, 3, 5),
      (1, 2, 3),
      (1, 4, 4),
      (4, 1, 4),
      (5, 2, 5);

INSERT INTO marks(student_id, discipline_id, mark)
VALUES(4, 3, 5),
	  (4, 2, 5),
      (4, 5, 4);

DELETE FROM marks
WHERE student_id = 1 AND mark = 3 AND discipline_id = 2;