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

