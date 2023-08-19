BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "types_of_room" (
	"id"	INTEGER UNIQUE,
	"type_title"	TEXT NOT NULL,
	"room_area"	INTEGER,
	"price_per_day"	INTEGER NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "tenants" (
	"id"	INTEGER UNIQUE,
	"full_name"	TEXT NOT NULL,
	"phon_number"	TEXT,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "types_of_services" (
	"id"	INTEGER UNIQUE,
	"title_of_service_type"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "employees" (
	"id"	INTEGER UNIQUE,
	"full_name"	TEXT NOT NULL,
	"phone_number"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "services" (
	"id"	INTEGER NOT NULL UNIQUE,
	"type_of_service_id"	INTEGER NOT NULL,
	"employee_id"	INTEGER NOT NULL,
	"title_of_service"	TEXT NOT NULL,
	"price_per_day"	NUMERIC NOT NULL,
	FOREIGN KEY("type_of_service_id") REFERENCES "types_of_services"("id"),
	FOREIGN KEY("employee_id") REFERENCES "employees"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "rooms" (
	"id"	INTEGER NOT NULL UNIQUE,
	"type_of_room_id"	INTEGER NOT NULL,
	"number_of_room"	INTEGER NOT NULL,
	FOREIGN KEY("type_of_room_id") REFERENCES "types_of_room"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "ordered_services" (
	"id"	INTEGER NOT NULL UNIQUE,
	"booking_id"	INTEGER NOT NULL,
	"service_id"	INTEGER NOT NULL,
	FOREIGN KEY("booking_id") REFERENCES "booking"("id"),
	FOREIGN KEY("service_id") REFERENCES "services"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "booking_addition_information" (
	"id"	INTEGER NOT NULL UNIQUE,
	"booking_id"	INTEGER NOT NULL,
	"breed_of_animal"	TEXT NOT NULL,
	"info_about_animals_health"	TEXT,
	"info_about_animals_needs"	TEXT,
	FOREIGN KEY("booking_id") REFERENCES "booking"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "booking" (
	"id"	INTEGER NOT NULL UNIQUE,
	"room_id"	INTEGER NOT NULL,
	"tenant_full_name"	TEXT NOT NULL,
	"tenant_phone_number"	TEXT NOT NULL,
	"price_of_booking"	REAL NOT NULL,
	"date_of_start"	TEXT NOT NULL,
	"date_of_end"	TEXT NOT NULL,
	FOREIGN KEY("room_id") REFERENCES "rooms"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
COMMIT;
