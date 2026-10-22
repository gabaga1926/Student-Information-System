CREATE DATABASE IF NOT EXISTS student_information_system_db;

USE student_information_system_db;

CREATE TABLE Student (
    Student_ID VARCHAR(20) PRIMARY KEY,
    Full_Name VARCHAR(100) NOT NULL,
    Gender VARCHAR(20) NOT NULL,
    Year_Level INT NOT NULL CHECK (Year_Level BETWEEN 1 AND 4),
    Program VARCHAR(100) NOT NULL,
    Contact_Number VARCHAR(11) NOT NULL UNIQUE,

    CONSTRAINT chk_contact_number
        CHECK (Contact_Number REGEXP '^[0-9]{11}$')
);