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

-- Delete School
CREATE OR REPLACE FUNCTION DeleteSchool(id_school INTEGER)  RETURNS INTEGER AS $$
BEGIN
    update school
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where school.id = id_school;

    return id_school;
END
$$ LANGUAGE plpgsql;

-- Delete Person
CREATE OR REPLACE FUNCTION DeletePerson(id_person INTEGER)  RETURNS INTEGER AS $$
BEGIN
    update person
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where person.id = id_person;

    return id_school;
END
$$ LANGUAGE plpgsql;


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

