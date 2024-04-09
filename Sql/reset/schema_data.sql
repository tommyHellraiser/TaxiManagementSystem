insert into cars(brand, model, year, license_plate, hourly_rate, is_replacement, is_in_fleet, is_in_garage)
values
('Toyota', 'Corolla', 2023, 'XQ456AV', 30.5, 0, 1, 1),
('Ford', 'Fiesta', 2020, 'CB137XC', 25.0, 0, 1, 1),
('Fiat', 'Cronos', 2021, 'AZ476AV', 27.4, 0, 1, 1),
('Toyota', 'Etios', 2019, 'MNJ951', 19.2, 1, 1, 1),
('Toyota', 'Hilux', 2015, 'TY452HX', 18, 0, 1, 1),
('Audi', 'R8', 2022, 'AD118RR', 30.6, 1, 1, 1),
('Nissan', 'Sentra', 2020, 'NS456ST', 26, 0, 1, 1),
('Ford', 'Eco Sport', 2011, 'FD312ES', 13.1, 0, 1, 1);

insert into drivers(name, last_name, document, date_of_birth, license_number)
values
('Tomas', 'Ponce', '38416584', '1994-11-25', 420),
('Anibal', 'Monta', '17123423', '1960-01-30', 32);

insert into driver_balances(driver_ID, balance)
values
(1, 0),
(2, 0);

insert into car_assignments(car_ID, driver_ID)
values
(2, 1),
(1, 2);