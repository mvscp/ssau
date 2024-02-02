SELECT T.countryt, first_name, last_name FROM
(
	SELECT C.country AS countryt, address_id AS adr FROM
	(
		SELECT city.city_id AS cid, country FROM country JOIN city ON city.country_id = country.country_id
        WHERE country IN ("Bolivia", "Angola")  
	) AS C
	JOIN address ON address.city_id = C.cid
) AS T
JOIN customer ON customer.address_id = T.adr;

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
JOIN film ON film.film_id = C.filmid


