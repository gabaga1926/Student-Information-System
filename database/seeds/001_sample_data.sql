USE student_information_system_db;

INSERT INTO Student (
    Student_ID,
    Full_Name,
    Gender,
    Year_Level,
    Program,
    Contact_Number
)
VALUES 
    ('2024-001', 'Juan Dela Cruz', 'Male', 2, 'BS Computer Science', '09935382981'),
    ('2024-002', 'Maria Clara Santos', 'Female', 2, 'BS Information Technology', '09662143078')
ON DUPLICATE KEY UPDATE
    Full_Name = VALUES(Full_Name);