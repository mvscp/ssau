SELECT * FROM artist
WHERE MATCH(REALNAME) AGAINST('Marc Trauner');

SELECT REALNAME FROM artist
WHERE NAME = 'Muse';

SELECT a.NAME, TITLE, RELEASED FROM artist a
JOIN release_artist ra ON ra.ARTIST_ID = a.ARTIST_ID
JOIN `release` r ON r.RELEASE_ID = ra.RELEASE_ID
WHERE a.NAME = 'The Persuader'
ORDER BY RELEASED;

SELECT TITLE, COUNTRY, RELEASED, NOTES, STYLE_NAME FROM `release` r
JOIN style s ON s.RELEASE_ID = r.RELEASE_ID
WHERE RELEASED BETWEEN '2001-01-01' AND '2002-01-01' AND r.IS_MAIN_RELEASE = 1;

SELECT * FROM artist
WHERE MATCH(`PROFILE`) AGAINST('Emo');

CREATE VIEW view_
AS SELECT * FROM artist;

CREATE PROCEDURE proc()
SELECT * FROM artist;