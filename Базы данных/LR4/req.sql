/*Вывести всех покупателей из указанного списка стран: отобразить имя,
фамилию, страну*/
SELECT first_name, last_name, country FROM customer 
JOIN address USING(address_id)
JOIN city USING(city_id)
JOIN country USING (country_id)
WHERE country IN ("Bolivia", "Angola");  

/*Вывести все фильмы, в которых снимался указанный актер: отобразить название
фильма, жанр.*/
SELECT title, C.genre FROM
(
	SELECT T.filid AS filmid, T.cat, name AS genre FROM
	(
		SELECT FILMM.fid AS filid, category_id AS cat FROM
		(
			SELECT film_id AS fid FROM film_actor JOIN actor ON actor.actor_id = film_actor.actor_id
			WHERE first_name = "Ed" AND last_name = "Chase"
		) AS FILMM
		JOIN film_category ON film_category.film_id = FILMM.fid
	) AS T
	JOIN category ON category.category_id = T.cat
) AS C
JOIN film ON film.film_id = C.filmid;

/*Вывести топ 10 жанров фильмов по величине дохода в указанном месяце:
отобразить жанр, доход.*/
SELECT SUM(amount), category.name FROM payment 
JOIN rental ON rental.rental_id = payment.rental_id
JOIN inventory ON inventory.inventory_id = rental.inventory_id
JOIN film_category ON film_category.film_id = inventory.film_id
JOIN category ON category.category_id = film_category.category_id
WHERE YEAR(payment_date) = "2005" AND MONTH(payment_date) = "07"
GROUP BY category.name 
ORDER BY SUM(amount) DESC LIMIT 10;

/*Вывести список из 5 клиентов, упорядоченный по количеству купленных
фильмов с указанным актером, начиная с 10-й позиции: отобразить имя,
фамилию, количество купленных фильмов. */
SELECT customer.first_name, customer.last_name, COUNT(film_id) FROM customer
JOIN payment USING(customer_id)
JOIN rental USING(rental_id)
JOIN inventory USING(inventory_id)
JOIN film_actor USING(film_id)
JOIN actor USING(actor_id)
WHERE actor.first_name = "Ed" AND actor.last_name = "Chase"
GROUP BY customer.customer_id 
ORDER BY COUNT(film_id) LIMIT 9, 5;

/*Вывести для каждого магазина его город, страну расположения и суммарный
доход за первую неделю продаж.*/
SELECT store_id, city, country, SUM(amount) FROM store
JOIN address USING(address_id)
JOIN city USING(city_id)
JOIN country USING(country_id)
JOIN inventory USING(store_id)
JOIN rental USING(inventory_id)
JOIN payment USING(rental_id)
WHERE payment_date BETWEEN (SELECT MIN(payment_date) FROM payment) AND (SELECT ADDDATE(MIN(payment_date), 7) FROM payment)
GROUP BY store_id;

/*Вывести всех актеров для фильма, принесшего наибольший доход: отобразить
фильм, имя актера, фамилия актера*/
SELECT T.title, first_name, last_name FROM
(
	SELECT SUM(amount), title, film_id FROM payment
	JOIN rental USING (rental_id)
	JOIN inventory USING (inventory_id)
	JOIN film USING(film_id)
	GROUP BY film_id
    ORDER BY SUM(amount) DESC LIMIT 1
)AS T
JOIN film_actor USING(film_id)
JOIN actor USING(actor_id);

/*Для всех покупателей вывести информацию о покупателях и актераходнофамильцах (используя LEFT JOIN, если однофамильцев нет – вывести
NULL).*/
SELECT customer.first_name AS cus_fname, customer.last_name AS cus_lname, actor.first_name AS act_fname, actor.last_name AS act_lname FROM customer
LEFT JOIN actor USING(last_name);

/*Для всех актеров вывести информацию о покупателях и актерах-однофамильцах
(используя RIGHT JOIN, если однофамильцев нет – вывести NULL).*/
SELECT customer.first_name AS cus_fname, customer.last_name AS cus_lname, actor.first_name AS act_fname, actor.last_name AS act_lname FROM customer
RIGHT JOIN actor USING(last_name);

/*В одном запросе вывести статистические данные о фильмах*/
(SELECT "Max length" AS statistics, length AS value, COUNT(film_id) AS count_film FROM film
GROUP BY length
ORDER BY length DESC LIMIT 1)
UNION 
(SELECT "Min length", length, COUNT(film_id) FROM film
GROUP BY length
ORDER BY length LIMIT 1)
UNION
(SELECT "Max actors", T.coun, COUNT(T.film_id) FROM 
(
	SELECT COUNT(actor_id) AS coun, film_id FROM film_actor 
	GROUP BY film_id
) AS T
GROUP BY T.coun
ORDER BY T.coun DESC LIMIT 1)
UNION
(SELECT "Min actors", T.coun, COUNT(T.film_id) FROM 
(
	SELECT COUNT(actor_id) AS coun, film_id FROM film_actor 
	GROUP BY film_id
) AS T
GROUP BY T.coun
ORDER BY T.coun LIMIT 1);