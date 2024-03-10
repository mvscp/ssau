DELIMITER //
CREATE TRIGGER mountain_trigger BEFORE INSERT ON mountain
FOR EACH ROW
BEGIN
	DECLARE count_rows INT;
    
    -- Проверяем, существует ли уже в таблице запись с такими же данными
    SELECT COUNT(*) INTO count_rows
    FROM mountain m
    WHERE m.name = NEW.name;
    
    -- Если найдено хотя бы одно совпадение, отменяем вставку
    IF count_rows > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Дублирующиеся данные запрещены';
    END IF;
    IF NEW.height > 9000 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Вставка строки с запрещенным значением запрещена';
    END IF;
END //
DELIMITER ;

INSERT INTO mountain (name, height) VALUE ('Everest', 9001);

DELIMITER //
CREATE TRIGGER climber_trigger BEFORE INSERT ON climber
FOR EACH ROW
BEGIN
	DECLARE count_rows INT;
    
    -- Проверяем, существует ли уже в таблице запись с такими же данными
    SELECT COUNT(*) INTO count_rows
    FROM climber c
    WHERE c.name = NEW.name;
    
    -- Если найдено хотя бы одно совпадение, отменяем вставку
    IF count_rows > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Дублирующиеся данные запрещены';
    END IF;
    IF NEW.address IS NULL THEN
        SET NEW.address = 'Не указан';
    END IF;
END //
DELIMITER ;

INSERT INTO climber (name) VALUE ('Tenzing Norgay1'); 

DELIMITER //
CREATE TRIGGER audit_trigger
AFTER UPDATE ON `group`
FOR EACH ROW
BEGIN
	INSERT INTO audit_group (operation_type, changed_record, `time`)
	VALUES ('UPDATE', CONCAT('ID: ', NEW.id), NOW());
END //
DELIMITER ;

UPDATE `group` g
SET g.name = 'Everest Expedition'
WHERE g.id = 1;

UPDATE climber_group
SET equipment = JSON_OBJECT(
        'harness', JSON_OBJECT(
            'brand', 'Petzl',
            'model', 'Aspic',
            'size', 'Medium'
        ),
        'ropes', JSON_ARRAY(
            JSON_OBJECT(
                'brand', 'Edelrid',
                'diameter', 9.8,
                'length', 60
            ),
            JSON_OBJECT(
                'brand', 'Black Diamond',
                'diameter', 8.5,
                'length', 70
            )
        ),
        'carabiners', JSON_ARRAY(
            'locking carabiner',
            'non-locking carabiner'
        )
    )
WHERE group_id IN (1, 3);

UPDATE climber_group
SET equipment = JSON_OBJECT(
        'harness', JSON_OBJECT(
            'brand', 'CAMP',
            'model', 'Claw',
            'size', 'Small'
        ),
        'ropes', JSON_ARRAY(
            JSON_OBJECT(
                'brand', 'Edelrid',
                'diameter', 9.8,
                'length', 60
            ),
            JSON_OBJECT(
                'brand', 'Black Diamond',
                'diameter', 8.5,
                'length', 70
            )
        ),
        'carabiners', JSON_ARRAY(
            'locking carabiner',
            'non-locking carabiner'
        )
    )
WHERE group_id IN (2, 4);

SELECT * FROM climber_group
WHERE equipment->'$.harness.size' = 'Medium';

UPDATE climber_group
SET equipment = JSON_REPLACE(equipment, '$.harness.size', 'Large')
WHERE climber_id = 3 AND group_id = 2;