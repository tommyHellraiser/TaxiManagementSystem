create table cars (
	ID int identity primary key,
	brand varchar(30) not null,
	model varchar(30) not null,
	year int not null,
	license_plate varchar(10) unique not null,
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
	license_number int unique not null
);

create table car_assignments (
	ID int identity primary key,
	car_ID int unique,
	driver_ID int unique,
	foreign key (car_ID) references cars(ID),
	foreign key (driver_ID) references drivers(ID)
);

create table driving_sessions(
	ID int identity primary key,
	driver_ID int not null,
	car_ID int not null,
	session_key varchar(30) not null,
	start_time datetime not null default CURRENT_TIMESTAMP,
	end_time datetime default null,
	total_amount float default null,
	rent_status tinyint default 9,
	foreign key (driver_ID) references drivers(ID),
	foreign key (car_ID) references cars(ID)
);

create table repair_logs(
	ID int identity primary key,
	car_ID int,
	start_repair datetime not null default CURRENT_TIMESTAMP,
	end_repair datetime default null,
	foreign key (car_ID) references cars(ID)
);

create table driver_balances(
	ID int identity primary key,
	driver_ID int,
	balance float not null default 0,
	updated_at datetime not null default CURRENT_TIMESTAMP
);