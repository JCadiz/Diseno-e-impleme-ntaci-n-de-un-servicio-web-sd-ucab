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
CREATE OR REPLACE FUNCTION DeleteSection(id_section INTEGER) 
RETURNS table (id integer, ucc integer, semes integer, htt numeric, hpp numeric, hll numeric, nombre varchar, 
        descripcion varchar, estatus varchar, tipo varchar, creado TIMESTAMP, eliminado TIMESTAMP, fk_school integer)
AS $BODY$
BEGIN
    update section
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where section.id = id_section;

    RETURN QUERY
        select * from section s WHERE s.id = id_section;
END
$BODY$ LANGUAGE plpgsql;


-- Delete Inscription
CREATE OR REPLACE FUNCTION Uninscription(id_section integer, id_person integer) 
    RETURNS table (id integer, estatus varchar, tipo varchar, creado TIMESTAMP, eliminado TIMESTAMP, persona integer, seccion integer)
    AS $BODY$
BEGIN
    update ENROLLMENT AS E
    set status = 'disabled', deleted_date = CURRENT_TIMESTAMP
    where E.fk_section = id_section AND fk_person = id_person;

    RETURN QUERY
        select * from ENROLLMENT E where E.fk_section = id_section AND fk_person = id_person;

END
$BODY$ LANGUAGE plpgsql;


-- INSERT Inscription
CREATE OR REPLACE FUNCTION Inscription(id_section integer, id_person integer, type2 varchar) 
    RETURNS boolean AS $$
    DECLARE 
        result boolean;
        cont integer;
BEGIN

    SELECT COUNT(*) INTO cont FROM ENROLLMENT AS E WHERE e.fk_person = id_person AND e.fk_section = id_section;

    IF(cont = 0) THEN
        INSERT INTO ENROLLMENT (status, type, fk_person, fk_section) VALUES ('enabled', type2, id_person, id_section);
        result := TRUE;
    ELSE
        result := FALSE;
    END IF;
	RETURN result;
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

-- INSERT MANUAL
CREATE OR REPLACE FUNCTION RegisterSection(u integer, semes integer , htt float, hpp float, hll float, nomb varchar, descri varchar, ty varchar, fk integer) 
    RETURNS table (id integer, ucc integer, semest integer, htt2 numeric, hpp2 numeric, hll2 numeric, nombre varchar, 
        descripcion varchar, estatus varchar, tipo varchar, creado TIMESTAMP, eliminado TIMESTAMP, fk_s integer)AS $BODY$
BEGIN
	
	INSERT INTO section (uc, semester, ht, hp, hl, name, description, status, type, fk_school) 
        VALUES (u, semes, htt, hpp, hll, nomb, descri,'enabled', ty, fk);

	RETURN QUERY
          select * from section s order by id desc limit 1;
END
$BODY$ LANGUAGE plpgsql;

-- select RegisterSection(7, 6, 5.00, 4.00, 3.00, 'Redes 3', 'Redes de Computadoras', 'mandatory', 1);

-- Actualizar los campos de una section 
CREATE OR REPLACE FUNCTION UpdateSection(id_section integer, uc2 integer, semest2 integer, htt2 float, hpp2 float, hll2 float, nombre2 varchar, descripcion2 varchar, tipo2 varchar, fk2 integer) 
RETURNS table (id integer, ucc integer, semes integer, htt numeric, hpp numeric, hll numeric, nombre varchar, 
        descripcion varchar, estatus varchar, tipo varchar, creado TIMESTAMP, eliminado TIMESTAMP, fk_school integer)
AS $BODY$
BEGIN
    UPDATE section s set uc = uc2, semester = semest2 , ht = htt2 , hp = hpp2 , hl = hll2 , name = nombre2 , description = descripcion2, type = tipo2, fk_school = fk2 WHERE s.id = id_section;

    RETURN QUERY
        select * 
        from section s 
        where s.status = 'enabled' 
        AND s.id = id_section;
END;
$BODY$ LANGUAGE plpgsql;
-- select UpdateSection(1,5,5,4,2,2,'Sist. Dist.', 'Materia sistemas distribuidos', 'mandatory',1);