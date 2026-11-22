USE student_information_system_db;

ALTER TABLE Student
ADD First_Name VARCHAR(60) NULL,
ADD Last_Name VARCHAR(60) NULL;

-- turn off safe mode first
SET SQL_SAFE_UPDATES = 0;
UPDATE Student
SET
    Last_Name = SUBSTRING_INDEX(Full_Name, ' ', -1),
    First_Name = TRIM(
        SUBSTRING(
            Full_Name,
            1,
            LENGTH(Full_Name) - LENGTH(SUBSTRING_INDEX(Full_Name, ' ', -1))
        )
    );
SET SQL_SAFE_UPDATES = 1;

-- Review multi-word surnames here

ALTER TABLE Student
MODIFY First_Name VARCHAR(60) NOT NULL,
MODIFY Last_Name VARCHAR(60) NOT NULL;

ALTER TABLE Student
DROP COLUMN Full_Name;

ALTER TABLE Student
ADD Full_Name VARCHAR(121)
GENERATED ALWAYS AS (CONCAT(First_Name, ' ', Last_Name)) STORED;

-- check table
SELECT * FROM Student;