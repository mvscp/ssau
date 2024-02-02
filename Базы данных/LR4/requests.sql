SELECT first_name, last_name, country FROM customer
JOIN address USING(address_id)
JOIN city USING(city_id)
JOIN country USING(country_id)
WHERE country = 'Argentina';

SELECT DISTINCT(title) 'Название', name 'Жанр' FROM actor
JOIN film_actor USING(actor_id)
JOIN film USING(film_id)
JOIN film_category USING(film_id)
JOIN category USING(category_id)
WHERE last_name = 'GUINESS';

SELECT name 'Жанр', SUM(amount) 'Доход' FROM payment p
JOIN rental r ON p.rental_id = r.rental_id 
JOIN inventory i ON r.inventory_id = i.inventory_id
JOIN film_category fc ON i.film_id = fc.film_id
JOIN category c ON fc.category_id = c.category_id
WHERE payment_date BETWEEN '2005-05-01' AND '2005-06-01'
GROUP BY name
ORDER BY SUM(amount) DESC
LIMIT 10;

SELECT c.first_name, c.last_name, COUNT(f.film_id) 'Кол-во купленных фильмов' FROM payment p
JOIN rental r ON p.rental_id = r.rental_id
JOIN customer c ON r.customer_id = c.customer_id 
JOIN inventory i ON r.inventory_id = i.inventory_id
JOIN film f ON i.film_id = f.film_id
JOIN film_actor fa ON f.film_id = fa.film_id
JOIN actor a ON fa.actor_id = a.actor_id
WHERE a.last_name = 'MOSTEL'
GROUP BY c.customer_id
ORDER BY COUNT(f.film_id) DESC
LIMIT 5 OFFSET 9;

SELECT city, country, SUM(amount) FROM store
JOIN address USING(address_id)
JOIN city USING(city_id)
JOIN country USING(country_id)
JOIN staff ON store.manager_staff_id = staff.staff_id
JOIN payment USING(staff_id)
WHERE payment_date BETWEEN (SELECT MIN(payment_date) FROM payment) AND (SELECT ADDDATE(MIN(payment_date), 7) FROM payment)
GROUP BY store.store_id;

SELECT T.title, first_name, last_name FROM
(
	SELECT SUM(amount), title, film_id FROM payment
    JOIN rental USING(rental_id)
    JOIN inventory USING(inventory_id)
    JOIN film USING(film_id)
    GROUP BY film_id
    ORDER BY SUM(amount) DESC
    LIMIT 1
) AS T
JOIN film_actor USING(film_id)
JOIN actor USING(actor_id);

SELECT c.first_name AS cus_fname, c.last_name AS cus_lname, a.first_name AS act_fname, a.last_name AS act_lname FROM customer c
LEFT JOIN actor a USING(last_name);

SELECT c.first_name AS cus_fname, c.last_name AS cus_lname, a.first_name AS act_fname, a.last_name AS act_lname FROM customer c
RIGHT JOIN actor a USING(last_name);

(SELECT 'Наибольшая продолжительность' AS 'Статистика', length AS 'Значение', COUNT(*) AS 'Кол-во фильмов' FROM film
GROUP BY length
ORDER BY length DESC
LIMIT 1)
UNION
(SELECT 'Наименьшая продолжительность', length, COUNT(*) FROM film
GROUP BY length
ORDER BY length ASC
LIMIT 1)
UNION
(SELECT 'Максимальное кол-во актеров', T.`Максимальное кол-во актеров`, COUNT(T.title) FROM
(
	SELECT COUNT(actor_id) AS 'Максимальное кол-во актеров', title FROM actor
	JOIN film_actor USING(actor_id)
	JOIN film USING(film_id)
	GROUP BY title
) AS T
GROUP BY T.`Максимальное кол-во актеров`
ORDER BY T.`Максимальное кол-во актеров` DESC
LIMIT 1)
UNION
(SELECT 'Минимальное кол-во актеров', T.`Минимальное кол-во актеров`, COUNT(T.title) FROM
(
	SELECT COUNT(actor_id) AS 'Минимальное кол-во актеров', title FROM actor
	JOIN film_actor USING(actor_id)
	JOIN film USING(film_id)
	GROUP BY title
) AS T
GROUP BY T.`Минимальное кол-во актеров`
ORDER BY T.`Минимальное кол-во актеров` ASC
LIMIT 1);
