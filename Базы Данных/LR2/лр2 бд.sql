SELECT `name` FROM disciplines
ORDER BY `name` ASC;

SELECT COUNT(*) FROM students;

SELECT * FROM students
WHERE `name` LIKE 'Ива%';

SELECT * FROM students WHERE id IN
(SELECT student_id FROM marks
WHERE discipline_id = 2 AND mark = 5)
ORDER BY `name` DESC;

SELECT * FROM students WHERE id IN
(SELECT student_id FROM marks
WHERE discipline_id IN (2, 3, 5)
GROUP BY student_id
HAVING SUM(mark) > 12 AND COUNT(*) = 3);

SELECT students.name FROM students
JOIN marks ON students.id = marks.student_id AND marks.discipline_id IN (2, 3, 5)
GROUP BY students.name
HAVING SUM(mark) > 12 AND COUNT(*) = 3;