Create Database QuiteAtticFilms;
-- Create client table
CREATE TABLE client (
    client_id INT PRIMARY KEY,
    client_name VARCHAR(60),
    phone_number VARCHAR(15),
    address VARCHAR(255)
);

-- Create location table
CREATE TABLE location (
    location_id INT PRIMARY KEY,
    area VARCHAR(255)
);

-- Create property table
CREATE TABLE property (
    property_id INT PRIMARY KEY,
    property_name VARCHAR(60),
    property_type VARCHAR(255)
);

-- Create staff table
CREATE TABLE staff (
    staff_id INT PRIMARY KEY,
    staff_type VARCHAR(60),
    fee DECIMAL(10, 2)
);

-- Create production table
CREATE TABLE production (
    production_id INT PRIMARY KEY,
    production_type VARCHAR(255),
    client_id INT,
    FOREIGN KEY (client_id) REFERENCES client(client_id)
);

-- Create staff_production table
CREATE TABLE staff_production (
    production_id INT,
    staff_id INT,
    number_of_members INT,
    PRIMARY KEY (production_id, staff_id),
    FOREIGN KEY (production_id) REFERENCES production(production_id),
    FOREIGN KEY (staff_id) REFERENCES staff(staff_id)
);

-- Create property_production table
CREATE TABLE property_production (
    production_id INT,
    property_id INT,
    number_of_days INT,
    location_id INT,
    PRIMARY KEY (production_id, property_id),
    FOREIGN KEY (production_id) REFERENCES production(production_id),
    FOREIGN KEY (property_id) REFERENCES property(property_id),
    FOREIGN KEY (location_id) REFERENCES location(location_id)
);



drop table property_production;
DROP TABLE staff_production;
DROP TABLE production;
DROP TABLE client;
DROP TABLE location;
DROP TABLE property;
DROP TABLE staff;
