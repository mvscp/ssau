INSERT INTO mountain (name, height, country, region) VALUES
('Everest', 8848, 'Nepal', 'Himalaya'),
('K2', 8614, 'Pakistan', 'Karakoram'),
('Kangchenjunga', 8586, 'Nepal', 'Himalaya'),
('Lhotse', 8516, 'Nepal', 'Himalaya'),
('Annapurna I', 8091, 'Nepal', 'Himalaya'),
('K5', 8080, 'Pakistan', 'Karakoram');

INSERT INTO `group` (name) VALUES
('Everest Expedition'),
('K2 Winter Ascent'),
('Annapurna First Ascent'),
('Mountain Madness'),
('Adventure Consultants'),
('Kangchenjunga Expedition');

INSERT INTO ascent (ascent_start, ascent_end, mountain_id, group_id) VALUES
('1953-03-05', '1953-06-01', 1, 1),
('2021-01-4', '2021-01-16', 2, 2),
('1950-05-13', '1950-06-17', 5, 3),
('1996-03-30', '1996-05-12', 1, 4),
('1996-03-30', '1996-05-12', 1, 5),
('1989-04-02', '1989-05-20', 3, 6);

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
('Lead'), ('Guide'), ('Sherpa'), ('Client'), ('Mountaineer');

INSERT INTO climber_group VALUES
(1, 1, 5), (2, 1, 3), (3, 2, 3), (4, 2, 3), (5, 2, 3), (6, 2, 3), (7, 2, 3),
(8, 3, 5), (9, 3, 5), (10, 4, 2), (11, 4, 1), (12, 5, 2), (13, 5, 2), (10, 6, 5), (10, 1, 5);
