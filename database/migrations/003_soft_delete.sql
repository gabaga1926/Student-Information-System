USE student_information_system_db;

ALTER TABLE Student
    ADD COLUMN Is_Active TINYINT(1) NOT NULL DEFAULT 1,
    ADD COLUMN Deleted_At DATETIME NULL,
    ADD INDEX idx_student_active (Is_Active);

CREATE OR REPLACE VIEW v_Student_Active AS
SELECT
    Student_ID,
    First_Name,
    Last_Name,
    Full_Name,
    Gender,
    Year_Level,
    Program,
    Contact_Number
FROM Student
WHERE Is_Active = 1;