DELIMITER //
CREATE PROCEDURE add_salary(IN var INT)
BEGIN
UPDATE climber_group
SET salary = salary + var
WHERE role_id IN (SELECT DISTINCT(id) FROM role
				WHERE name IN ('Guide', 'Sherpa', 'Lead'));
END //

CREATE PROCEDURE get_climbers_roles()
BEGIN
SELECT c.name, g.name, r.name FROM climber c
JOIN climber_group cg ON c.id = cg.climber_id
JOIN role r ON cg.role_id = r.id
JOIN `group` g ON g.id = cg.group_id;
END //

CREATE PROCEDURE get_ascents_counts()
BEGIN
SELECT c.name climber, m.name mountain, COUNT(c.id) 'ascents count' FROM `group` g
JOIN ascent a ON g.id = a.group_id
JOIN mountain m ON a.mountain_id = m.id
JOIN climber_group cg ON g.id = cg.group_id 
JOIN climber c ON cg.climber_id = c.id
GROUP BY c.id, m.id
ORDER BY COUNT(c.id) DESC;
END //

CREATE FUNCTION func(salary INT) RETURNS VARCHAR(20) DETERMINISTIC
BEGIN
	DECLARE status VARCHAR(20);
	SET status = CASE 
		WHEN salary > 0 THEN 'Работник экспедиции'
		ELSE 'Турист'
	END;
	RETURN status;
END //

CREATE PROCEDURE cursor_proc()
BEGIN
	DECLARE climber VARCHAR(45); 
    DECLARE mountain VARCHAR(45);
    DECLARE start DATE;
    DECLARE end DATE;
    DECLARE done INTEGER DEFAULT 0;
	DECLARE ascents_cursor CURSOR FOR
		SELECT c.name climber, m.name mountain, a.ascent_start, a.ascent_end FROM `group` g
		JOIN ascent a ON g.id = a.group_id
		JOIN mountain m ON a.mountain_id = m.id
		JOIN climber_group cg ON g.id = cg.group_id 
		JOIN climber c ON cg.climber_id = c.id;
		-- WHERE DATEDIFF(a.ascent_end, a.ascent_start) < 40
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
	OPEN ascents_cursor;
	FETCH ascents_cursor INTO climber, mountain, start, end;
	WHILE done = 0 DO 
		BEGIN
			IF DATEDIFF(end, start) < 40 THEN SELECT climber, mountain, start, end;
            END IF;
			FETCH NEXT FROM ascents_cursor INTO climber, mountain, start, end;
		END;
	END WHILE;
	CLOSE ascents_cursor;
END //

DROP TABLE IF EXISTS temp_table;
CREATE TABLE IF NOT EXISTS temp_table (
	id INTEGER PRIMARY KEY NOT NULL AUTO_INCREMENT,
    name VARCHAR(45) NOT NULL,
    height INTEGER NOT NULL,
    country VARCHAR(45) NOT NULL,
    region VARCHAR(45) DEFAULT NULL
)//

CREATE PROCEDURE insert_into_temp()
BEGIN
	DECLARE id INTEGER; 
    DECLARE mountain VARCHAR(45);
    DECLARE height INTEGER;
    DECLARE country VARCHAR(45);
    DECLARE region VARCHAR(45);
    DECLARE done INTEGER DEFAULT 0;
	DECLARE ascents_cursor CURSOR FOR
		SELECT * FROM mountain m;
		-- WHERE height > 8000
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
	OPEN ascents_cursor;
	FETCH ascents_cursor INTO id, mountain, height, country, region;
	WHILE done = 0 DO 
		BEGIN
			IF height > 8100 THEN INSERT INTO temp_table (name, height, country, region) VALUE (mountain, height, country, region);
            END IF;
			FETCH NEXT FROM ascents_cursor INTO id, mountain, height, country, region;
		END;
	END WHILE;
	CLOSE ascents_cursor;
END // 
DELIMITER ;

CALL add_salary(20000);

CALL get_climbers_roles();

CALL get_ascents_counts();

SELECT g.name expedition, c.name climber, func(cg.salary) Статус FROM `group` g
JOIN ascent a ON g.id = a.group_id
JOIN climber_group cg ON g.id = cg.group_id 
JOIN climber c ON cg.climber_id = c.id;

CALL cursor_proc();

CALL insert_into_temp();
