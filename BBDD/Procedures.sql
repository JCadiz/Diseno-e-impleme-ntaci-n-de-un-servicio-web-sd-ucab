-- Delete Faculty
CREATE OR REPLACE PROCEDURE DeleteFaculty(id_faculty INTEGER)
LANGUAGE SQL
AS $$
    update faculty
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where id = id_faculty;
$$;

-- Delete School
CREATE OR REPLACE PROCEDURE DeleteSchool(id_school INTEGER)
LANGUAGE SQL
AS $$
    update school
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where id = id_school;
$$;

-- Delete Person
CREATE OR REPLACE PROCEDURE DeletePerson(id_person INTEGER)
LANGUAGE SQL
AS $$
    update person
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where id = id_person;
$$;

-- Delete Section
CREATE OR REPLACE PROCEDURE DeleteSection(id_section INTEGER)
LANGUAGE SQL
AS $$
    update section
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where id = id_section;
$$;

-- Delete Enrollment
CREATE OR REPLACE PROCEDURE DeleteEnrollment(id_enrollment INTEGER)
LANGUAGE SQL
AS $$
    update enrollment
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where id = id_enrollment;
$$;

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

