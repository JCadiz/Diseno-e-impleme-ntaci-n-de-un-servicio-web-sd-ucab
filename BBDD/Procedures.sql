CREATE OR REPLACE FUNCTION DeleteFaculty(id_faculty INTEGER) RETURNS 
    table (id integer, nombre varchar, descripcion varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP)AS $BODY$
BEGIN
    update faculty
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where faculty.id = id_faculty;

    RETURN QUERY
        select * from faculty f WHERE f.id = id_faculty;
END
$BODY$ LANGUAGE plpgsql;

-- delete school
CREATE OR REPLACE FUNCTION DeleteSchool(id_school INTEGER) RETURNS 
    table (id integer, nombre varchar, descripcion varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP, facultad INTEGER)AS $BODY$
BEGIN
    update school
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where school.id = id_school;

    RETURN QUERY
        select * from school s WHERE s.id = id_school;
END
$BODY$ LANGUAGE plpgsql;

-- Delete Person
CREATE OR REPLACE FUNCTION DeletePerson(id_person INTEGER) 
RETURNS table (id integer, cedu varchar, nombre varchar, apellido varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP)AS $BODY$
BEGIN
    update person
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where person.id = id_person;

    RETURN QUERY
        select * from person p WHERE p.id = id_person;
END
$BODY$ LANGUAGE plpgsql;

-- select DeletePerson(3);


-- Delete Section
CREATE OR REPLACE FUNCTION DeleteSection(id_section INTEGER)  RETURNS INTEGER AS $$
BEGIN
    update section
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where section.id = id_section;

    return id_school;
END
$$ LANGUAGE plpgsql;

-- Delete Enrollment
CREATE OR REPLACE FUNCTION DeleteEnrollment(id_enrollment INTEGER)  RETURNS INTEGER AS $$
BEGIN
    update enrollment
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where enrollment.id = id_enrollment;

    return id_school;
END
$$ LANGUAGE plpgsql;


-- obtengo las operaciones de un usuario por un rango de fecha
CREATE OR REPLACE FUNCTION GetAllFaculties( ) 
RETURNS table (id integer, nombre varchar, descripcion varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP)
AS $BODY$
BEGIN
	RETURN QUERY
        select * from faculty f where f.status = 'enabled';
END;
$BODY$ LANGUAGE plpgsql;

-- select GetAllFaculties();

-- INSERT MANUAL
CREATE OR REPLACE FUNCTION RegisterFaculty(nomb varchar, descri varchar) 
    RETURNS table (id integer, nombre varchar, descripcion varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP)AS $BODY$
BEGIN
	
	INSERT INTO FACULTY (name, description, status ) VALUES (nomb, descri, 'enabled');

	RETURN QUERY
          select * from faculty f WHERE f.name = nomb;
END
$BODY$ LANGUAGE plpgsql;

-- select RegisterFaculty('Facultad de Humanidades', 'Humanidades');

-- update manual faculty
CREATE OR REPLACE FUNCTION UpdateFaculty(id_facult int, nomb varchar, descri varchar) 
    RETURNS table (id integer, nombre varchar, descripcion varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP)AS $BODY$
BEGIN
	
	update faculty set name = nomb, description = descri
    where faculty.id = id_facult;

	RETURN QUERY
          select * from faculty f WHERE f.id = id_facult;
END
$BODY$ LANGUAGE plpgsql;

-- select UpdateFaculty(4,'Facultad de ciencias', 'ciencias');

-- obtengo las operaciones de un persons por un rango de fecha
CREATE OR REPLACE FUNCTION GetAllPersons( ) 
RETURNS table (id integer, dni varchar, nombre varchar, apellido varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP)
AS $BODY$
BEGIN
	RETURN QUERY
        select * from person p where p.status = 'enabled';
END;
$BODY$ LANGUAGE plpgsql;

-- select GetAllPersons();

-- INSERT MANUAL
CREATE OR REPLACE FUNCTION RegisterPerson(dnii varchar, nomb varchar, ape varchar) 
    RETURNS table (id integer, cedu varchar, nombre varchar, apellido varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP)AS $BODY$
BEGIN
	
	INSERT INTO PERSON (dni, first_name, last_name, status ) VALUES (dnii, nomb, ape, 'enabled');

	RETURN QUERY
          select * from person p WHERE p.dni = dnii;
END
$BODY$ LANGUAGE plpgsql;

-- update manual person
CREATE OR REPLACE FUNCTION UpdatePerson(id_person int, dnii varchar, nomb varchar, ape varchar) 
    RETURNS table (id integer, cedu varchar, nombre varchar, apellido varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP)AS $BODY$
BEGIN
	
	update person set dni = dnii, first_name = nomb, last_name = ape 
    where person.id = id_person;

	RETURN QUERY
          select * from person p WHERE p.id = id_person;
END
$BODY$ LANGUAGE plpgsql;

-- select UpdatePerson(2,'4268117', 'nely', 'barragan');


-- Obtenere todas las escuelas
CREATE OR REPLACE FUNCTION GetAllSchools( ) 
RETURNS table (id INTEGER, nombre VARCHAR, descripcion VARCHAR, estatus VARCHAR,
		creado TIMESTAMP, eliminado TIMESTAMP, facultad INTEGER)
AS $BODY$
BEGIN
	RETURN QUERY
        select * from school f where f.status = 'enabled';
END;
$BODY$ LANGUAGE plpgsql;

-- select GetAllSchools();

-- INSERT escuela
CREATE OR REPLACE FUNCTION RegisterSchool(nomb varchar, descri varchar, facultad INTEGER) 
    RETURNS table (id integer, nombre varchar, descripcion varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP, fk_facultad INTEGER)AS $BODY$
BEGIN
	
	INSERT INTO SCHOOL (name, description, status, fk_faculty ) VALUES (nomb, descri, 'enabled', facultad);

	RETURN QUERY
          select * from school f WHERE f.name = nomb;
END
$BODY$ LANGUAGE plpgsql;

-- select RegisterSchool('Escuela de Derecho', 'Derecho');

-- obtengo las operaciones de un sections 
CREATE OR REPLACE FUNCTION GetAllSections( ) 
RETURNS table (id integer, ucc integer, semes integer, htt numeric, hpp numeric, hll numeric, nombre varchar, 
        descripcion varchar, estatus varchar, tipo varchar, creado TIMESTAMP, eliminado TIMESTAMP, fk_s integer)
AS $BODY$
BEGIN
	RETURN QUERY
        select * from section s where s.status = 'enabled';
END;
$BODY$ LANGUAGE plpgsql;

-- select GetAllSections();
-- UPDATE escuela
CREATE OR REPLACE FUNCTION UpdateSchool(id_school INTEGER, nomb varchar, descri varchar, facultad INTEGER) 
    RETURNS table (id_s integer, nombre varchar, descripcion varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP, fk_facultad INTEGER)AS $BODY$
BEGIN
	
	UPDATE school s set name = nomb, description = descri, fk_faculty = Facultad WHERE s.id = id_school;

	RETURN QUERY
          select * from school s WHERE s.id = id_school;
END
$BODY$ LANGUAGE plpgsql;

-- Obtener todos los profesores de una seccion
CREATE OR REPLACE FUNCTION GetAllTeachersFromSection( id_section INTEGER ) 
RETURNS table (id integer, dni varchar, nombre varchar, apellido varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP)
AS $BODY$
BEGIN
	RETURN QUERY
        SELECT PE.* FROM person AS PE, enrollment AS EN WHERE PE.id = EN.fk_person AND EN.fk_section = id_section AND EN.type = 'teacher' AND EN.status = 'enabled';
END;
$BODY$ LANGUAGE plpgsql;

-- Obtener todos los estudiantes de una seccion
CREATE OR REPLACE FUNCTION GetAllStudentsFromSection( id_section INTEGER ) 
RETURNS table (id integer, dni varchar, nombre varchar, apellido varchar, estatus varchar,
		creado TIMESTAMP, eliminado TIMESTAMP)
AS $BODY$
BEGIN
	RETURN QUERY
        SELECT PE.* FROM person AS PE, enrollment AS EN WHERE PE.id = EN.fk_person AND EN.fk_section = id_section AND EN.type = 'student' AND EN.status = 'enabled';
END;
$BODY$ LANGUAGE plpgsql;