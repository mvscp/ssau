CREATE OR REPLACE ALGORITHM = TEMPTABLE
VIEW avg_payment
AS SELECT c.name category, AVG(p.amount) average
FROM payment p
JOIN rental USING(rental_id)
JOIN inventory USING(inventory_id)
JOIN film USING(film_id)
JOIN film_category USING(film_id)
JOIN category c USING(category_id)
GROUP BY c.name
ORDER BY average DESC;

CREATE OR REPLACE ALGORITHM = MERGE
VIEW film_stats
AS SELECT f.film_id, f.title, f.description, f.rating,
	(SELECT name FROM category
		JOIN film_category fc USING(category_id)
		WHERE fc.film_id = f.film_id) category_name,
    (SELECT COUNT(*) FROM film_actor fa
		WHERE fa.film_id = f.film_id) num_actors,
	(SELECT COUNT(*) FROM inventory i
		WHERE i.film_id = f.film_id) inventory_cnt,
	(SELECT COUNT(*) FROM inventory i
		JOIN rental USING(inventory_id)
        WHERE i.film_id = f.film_id) num_rentals
FROM film f;

CREATE OR REPLACE
VIEW active_customer_v
	(customer_id, first_name, last_name, email)
AS SELECT customer_id, first_name, last_name, concat(substr(email, 1, 2), '*******', substr(email, -4)) email
FROM customer
WHERE active = 1;

CREATE OR REPLACE
VIEW customer_details
AS SELECT c.customer_id, c.store_id, c.first_name, c.last_name, c.create_date, c.address_id, a.address, ct.city, cn.country, a.postal_code
FROM customer c
JOIN address a USING(address_id)
JOIN city ct USING(city_id)
JOIN country cn USING(country_id);

UPDATE active_customer_v
SET last_name = 'Allen'
WHERE customer_id = 9998;

INSERT INTO customer_details
(customer_id, store_id, first_name, last_name, create_date, address_id)
VALUES (9999, 1, 'Harry', 'Mack', now(), 7);

CREATE OR REPLACE 
VIEW vw
AS SELECT * FROM active_customer_v
WHERE first_name LIKE 'A%'
WITH CHECK OPTION;

UPDATE vw
SET first_name = 'Harry'
WHERE customer_id = 9998;
