SELECT full_name as "ФИО" FROM employees
ORDER BY employee_id DESC;

SELECT firm FROM goods
GROUP BY firm
ORDER BY firm DESC;

SELECT DISTINCT name
FROM goods;

SELECT * FROM fullfiled_orders
WHERE repair_cost > 3500;

SELECT name, COUNT(name) as "Количество" FROM goods
GROUP BY name;

SELECT SUM(full_cost) as "Общая стоимость работ" FROM fullfiled_orders;

SELECT * FROM orders
WHERE date BETWEEN "2023-08-01" AND "2023-08-31"
HAVING warranty = "Да";

SELECT full_name, SUM(full_cost) as "Общая стоимость работ"
FROM employees, fullfiled_orders
WHERE employees.employee_id = fullfiled_orders.employee_id
GROUP BY full_name
ORDER BY SUM(full_cost), full_name;

SELECT g.name, o.order_id, o.client_name FROM fullfiled_orders fo
RIGHT JOIN orders o ON o.order_id = fo.orders_order_id
JOIN goods g ON o.good_id = g.good_id
WHERE fo.order_id IS NULL;

SELECT e.full_name, g.name, subquery.count
FROM employees e JOIN goods_has_employees ge ON e.employee_id = ge.employees_employee_id
JOIN goods g ON g.good_id = ge.goods_good_id
JOIN (
	SELECT e.employee_id, COUNT(*) as count
    FROM employees e JOIN goods_has_employees ge ON e.employee_id = ge.employees_employee_id
    JOIN goods g ON g.good_id = ge.goods_good_id
    GROUP BY e.employee_id
) as subquery ON subquery.employee_id = e.employee_id
ORDER BY 3, 1;

SELECT o.order_id, g.firm, g.name
FROM fullfiled_orders fo RIGHT JOIN orders o ON o.order_id = fo.orders_order_id
JOIN goods g ON o.good_id = g.good_id
WHERE fo.order_id IS NOT NULL AND g.firm = 'Philips'
UNION
SELECT o.order_id, g.firm, g.name
FROM fullfiled_orders fo RIGHT JOIN orders o ON o.order_id = fo.orders_order_id
JOIN goods g ON o.good_id = g.good_id
WHERE fo.order_id IS NULL AND g.firm = 'Bosch';

INSERT INTO goods
VALUES (15, 'Отпариватель', 'Braun', 'GWRYT', 'norm', '25.11.2026', '/img16.png');

-- Обновление
UPDATE fullfiled_orders
SET message_to_client = 'yes'
WHERE order_id = 13;

-- Удаление
DELETE FROM orders
WHERE order_id = 10;