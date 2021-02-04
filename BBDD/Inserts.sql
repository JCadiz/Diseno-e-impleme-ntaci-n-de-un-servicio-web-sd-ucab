INSERT INTO FACULTY (name, description, status ) VALUES ('Ingeniería','Facultad de Ingeniería', 'enabled');
INSERT INTO FACULTY (name, description, status ) VALUES ('Medicina','Facultad Medicina', 'enabled');

INSERT INTO SCHOOL (name, description, status, fk_faculty) VALUES ('Informática','Escuela de Informática', 'enabled', 1);
INSERT INTO SCHOOL (name, description, status, fk_faculty) VALUES ('Odontología','Escuela de Odontología', 'enabled', 2);

INSERT INTO PERSON (dni, first_name, last_name, status) VALUES ('24663592','Jesus', 'Cádiz', 'enabled');
INSERT INTO PERSON (dni, first_name, last_name, status) VALUES ('24663591','Julio', 'Díaz', 'enabled');
INSERT INTO PERSON (dni, first_name, last_name, status) VALUES ('24663590','Franco', 'Marino', 'enabled');

INSERT INTO SECTION (uc, semester, ht, hp, hl, name, description, status, type, fk_school) VALUES (5, 4, 2, 2, 1, 'Sistemas Distribuidos', 'Sección de Sistemas Distribuidos', 'enabled', 'mandatory', 1);
INSERT INTO SECTION (uc, semester, ht, hp, hl, name, description, status, type, fk_school) VALUES (8, 7, 3, 3, 2, 'Materiales dentales', 'Sección de Materiales dentales', 'enabled', 'elective', 2);

INSERT INTO ENROLLMENT (status, type, fk_person, fk_section) VALUES ('enabled','student', 1, 1);
INSERT INTO ENROLLMENT (status, type, fk_person, fk_section) VALUES ('enabled','teacher', 2, 1);