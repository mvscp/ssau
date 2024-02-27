SELECT m.name mountain, a.ascent_end, g.name expedition FROM `group` g
JOIN ascent a ON g.id = a.group_id
JOIN mountain m ON a.mountain_id = m.id
WHERE ascent_end BETWEEN '1950-01-01' AND '2000-01-01'
ORDER BY m.name, a.ascent_end;

SELECT c.name climber, g.name expedition, m.name mountain, a.ascent_end FROM `group` g
JOIN ascent a ON g.id = a.group_id
JOIN mountain m ON a.mountain_id = m.id
JOIN climber_group cg ON g.id = cg.group_id 
JOIN climber c ON cg.climber_id = c.id
WHERE ascent_end BETWEEN '1950-01-01' AND '2000-01-01'
ORDER BY c.name;

SELECT c.name climber, m.name mountain, COUNT(c.id) 'ascents count' FROM `group` g
JOIN ascent a ON g.id = a.group_id
JOIN mountain m ON a.mountain_id = m.id
JOIN climber_group cg ON g.id = cg.group_id 
JOIN climber c ON cg.climber_id = c.id
GROUP BY c.id, m.id
ORDER BY COUNT(c.id) DESC;

SELECT g.name expedition, c.name climber FROM `group` g
JOIN ascent a ON g.id = a.group_id
JOIN climber_group cg ON g.id = cg.group_id 
JOIN climber c ON cg.climber_id = c.id
WHERE ascent_end BETWEEN '1950-01-01' AND '2000-01-01';

SELECT m.name mountain, COUNT(DISTINCT(c.id)) 'ascended climbers' FROM `group` g
JOIN ascent a ON g.id = a.group_id
JOIN mountain m ON a.mountain_id = m.id
JOIN climber_group cg ON g.id = cg.group_id 
JOIN climber c ON cg.climber_id = c.id
GROUP BY m.name
ORDER BY m.name;
