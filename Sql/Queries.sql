select * from cars;
select * from drivers;
SELECT * FROM driver_balances;

delete from cars;

insert into cars(brand, model, year, license_plate, is_replacement, hourly_rate)
values('Toyota', 'Corolla', 2023, 'AX456ZA', 0, 20.15);

INSERT INTO cars(brand, model, year, license_plate, hourly_rate, is_replacement)
VALUES ('Ford', 'Ecosport', 1993, 'ASD123', 15.30, 0);
SELECT NewID = SCOPE_IDENTITY();

select top 1 ID from cars order by ID desc;

select * from drivers where document = '38416584';

SELECT * FROM cars WHERE license_plate = 'AZ476AV';

update cars set is_in_fleet = 1 WHERE ID = 5;

select * from car_assignments;

select ca.ID, ca.car_ID, c.brand, c.model, c.license_plate, ca.driver_ID, d.name, d.last_name, d.document
from car_assignments as ca
left join cars as c
on ca.car_ID = c.ID
left join drivers as d
on ca.driver_ID = d.ID;

SELECT c.ID
FROM car_assignments as ca
LEFT JOIN cars as c
ON ca.car_ID = c.ID
WHERE c.license_plate = 'CB137XC';
select * from cars;

SELECT ID FROM cars WHERE license_plate = 'CB137XC';

SELECT c.*
FROM car_assignments as ca
LEFT JOIN cars as c
ON ca.car_ID = c.ID
LEFT JOIN drivers as d
ON ca.driver_ID = d.ID
WHERE d.document = '38581036';

select * from repair_logs WHERE car_ID = 1 AND end_repair IS null;

select * from repair_logs;

update cars set is_in_garage = 1;
delete from repair_logs;

SELECT TOP 1 * FROM cars WHERE is_replacement = 1;

SELECT d.name, d.last_name, d.document, db.balance
FROM driver_balances as db
JOIN drivers as d
ON db.driver_ID = d.ID;

SELECT d.name, d.last_name, d.document, db.balance 
FROM driver_balances as db 
JOIN drivers as d 
ON db.driver_ID = d.ID;

select * from driver_balances;
select * from driving_sessions;
select * from drivers;

update driver_balances set balance = -150 where driver_ID = 1;
update cars set is_in_garage = 1 where ID = 4;

update driving_sessions set rent_status = 3 where ID = 1;

SELECT d.name, d.last_name, d.document, c.brand, c.model, c.license_plate, c.hourly_rate, ds.session_key, ds.start_time
FROM driving_sessions as ds
LEFT JOIN drivers AS d
ON ds.driver_ID = d.ID
LEFT JOIN cars AS c
ON ds.car_ID = c.ID
WHERE end_time IS NULL;

insert into driver_balances(driver_ID, balance) values(3, 0);
update cars set is_in_garage = 1;