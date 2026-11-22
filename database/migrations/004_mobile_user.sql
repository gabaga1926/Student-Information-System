CREATE USER IF NOT EXISTS 'sis_mobile'@'%' IDENTIFIED BY 'CHANGE_ME_LOCALLY';
GRANT SELECT ON student_information_system_db.v_Student_Active TO 'sis_mobile'@'%';