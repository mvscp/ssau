SELECT * FROM mysql.user;

CREATE USER 'roma'@'%' IDENTIFIED BY '2C4B14';

GRANT SELECT ON view_ TO 'roma'@'%';
GRANT EXECUTE ON PROCEDURE proc TO 'roma'@'%';

SELECT * FROM view_;
CALL proc();

GRANT ALL ON * TO 'roma'@'%';

-- REVOKE ALL ON * FROM 'roma'@'%';
REVOKE SELECT ON view_ FROM 'roma'@'%';
REVOKE EXECUTE ON PROCEDURE proc FROM 'roma'@'%';