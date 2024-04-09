/* Table definitions */
drop table if exists driving_sessions;
drop table if exists repair_logs;
drop table if exists rent_logs;
drop table if exists driver_balances;
drop table if exists drivers;
drop table if exists cars;

create table cars (
	ID int identity primary key,
	brand varchar(30) not null,
	model varchar(30) not null,
	year int not null,
	license_plate varchar(10) not null,
	hourly_rate float not null,
	is_replacement bit not null,
	is_in_fleet bit not null default 1,
	is_in_garage bit not null default 1
);

create table drivers(
	ID int identity primary key,
	name varchar(30) not null,
	last_name varchar(30) not null,
	document varchar(15) unique not null,
	date_of_birth date not null,
	license_number int unique not null,
	preferred_car_id int default null,
	foreign key (preferred_car_id) references cars(ID)
);

create table driving_sessions(
	ID int identity primary key,
	driver_ID int not null,
	car_ID int not null,
	session_key varchar(30) not null,
	start_time datetime not null default CURRENT_TIMESTAMP,
	end_time datetime default null,
	foreign key (driver_ID) references drivers(ID),
	foreign key (car_ID) references cars(ID)
);

create table repair_logs(
	ID int identity primary key,
	car_ID int,
	exit_for_repair datetime not null default CURRENT_TIMESTAMP,
	return_from_repair datetime default null,
	foreign key (car_ID) references cars(ID)
);

create table rent_logs(
	ID int identity primary key,
	driver_ID int,
	car_ID int,
	shift_start datetime not null default CURRENT_TIMESTAMP,
	shift_end datetime default null,
	total_amount float default null,
	status tinyint default 0,
	foreign key (driver_ID) references drivers(ID),
	foreign key (car_ID) references cars(ID)
);

create table driver_balances(
	ID int identity primary key,
	driver_ID int,
	balance float not null default 0,
	updated_at datetime not null default CURRENT_TIMESTAMP
);