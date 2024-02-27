INSERT INTO mountain (name, height, country, region) VALUES
('Everest', 8848, 'Nepal', 'Himalaya'),
('K2', 8614, 'Pakistan', 'Karakoram'),
('Kangchenjunga', 8586, 'Nepal', 'Himalaya'),
('Lhotse', 8516, 'Nepal', 'Himalaya'),
('Annapurna I', 8091, 'Nepal', 'Himalaya'),
('K5', 8080, 'Pakistan', 'Karakoram');

INSERT INTO ascent (ascent_start, ascent_end, mountain_id, group_id) VALUES
('1953-03-05', '1953-06-01', 1, 1),
('2021-01-4', '2021-01-16', 2, 2),
('1950-05-13', '1950-06-17', 5, 3),
('1996-03-30', '1996-05-12', 1, 4),
('1996-03-30', '1996-05-12', 1, 5),
('1989-04-02', '1989-05-20', 3, 6);

INSERT INTO `group` (name) VALUES
('Everest Expedition'),
('K2 Winter Ascent'),
('Annapurna First Ascent'),
('Mountain Madness'),
('Adventure Consultants'),
('Kangchenjunga Expedition');

INSERT INTO climber (name, address) VALUES
('Edmund Hillary', 'Auckland, New Zealand'),
('Tenzing Norgay', 'Tengboche, Sagarmatha Zone, Nepal'),
('Nirmal Purja', 'Myagdi, Gandaki Province, Nepal'),
('Mingma David Sherpa', 'Taplejung, Nepal'),
('Mingma Tenzi Sherpa', 'Taplejung, Nepal'),
('Geljen Sherpa', 'Myagdi, Gandaki Province, Nepal'),
('Pem Chiri Sherpa', 'Taplejung, Nepal'),
('Maurice Herzog', 'Lyon, France'),
('Louis Lachenal', 'Annecy, France'),
('Anatoli Boukreev', 'Korkino, Russian SFSR, USSR'),
('Scott Fischer', 'Muskegon, Michigan, United States'),
('Rob Hall', 'Christchurch, New Zealand'),
('Andy Harris', 'Salisbury, Wiltshire, England');

INSERT INTO role (name) VALUES
('Guide');

INSERT INTO climber_group VALUES
(1, 1), (2, 1), (3, 2), (4, 2), (5, 2), (6, 2), (7, 2),
(8, 3), (9, 3), (10, 4), (11, 4), (12, 5), (13, 5), (10, 6), (10, 1);
