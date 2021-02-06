CREATE TABLE PERSON
(
    id SERIAL UNIQUE,
    dni VARCHAR(100) UNIQUE NOT NULL,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    status VARCHAR(100) NOT NULL,
    created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deleted_date TIMESTAMP WITHOUT TIME ZONE,
    CONSTRAINT pk_person PRIMARY KEY(id),
    CONSTRAINT type_person_status CHECK(status IN('enabled','disabled'))
);

CREATE TABLE FACULTY
(
    id SERIAL UNIQUE,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(100) NOT NULL,
    status VARCHAR(100) NOT NULL,
    created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deleted_date TIMESTAMP WITHOUT TIME ZONE,
    CONSTRAINT pk_faculty PRIMARY KEY(id),
    CONSTRAINT type_faculty_status CHECK(status IN('enabled','disabled'))
);

CREATE TABLE SCHOOL
(
    id SERIAL UNIQUE,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(100) NOT NULL,
    status VARCHAR(100) NOT NULL,
    created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deleted_date TIMESTAMP WITHOUT TIME ZONE,
    fk_faculty INT,
    CONSTRAINT pk_school PRIMARY KEY(id),
    CONSTRAINT type_school_status CHECK(status IN('enabled','disabled')),
    CONSTRAINT fk_school_faculty FOREIGN KEY(fk_faculty) REFERENCES faculty (id)
);

CREATE TABLE SECTION
(
    id SERIAL UNIQUE,
    uc INT NOT NULL,
    semester INT NOT NULL,
    ht NUMERIC NOT NULL,
    hp NUMERIC NOT NULL,
    hl NUMERIC NOT NULL,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(100) NOT NULL,
    status VARCHAR(100) NOT NULL,
    type VARCHAR(100) NOT NULL,
    created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deleted_date TIMESTAMP WITHOUT TIME ZONE,
    fk_school INT,
    CONSTRAINT pk_section PRIMARY KEY(id),
    CONSTRAINT type_signature CHECK (type IN('mandatory','elective')),
    CONSTRAINT type_section_status CHECK(status IN('enabled','disabled')),
    CONSTRAINT fk_section_school FOREIGN KEY(fk_school) REFERENCES school (id)
);

CREATE TABLE ENROLLMENT
(
    id SERIAL UNIQUE,
    status VARCHAR(100) NOT NULL,
    type VARCHAR(100) NOT NULL,
    created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deleted_date TIMESTAMP WITHOUT TIME ZONE,
    fk_person INT,
    fk_section INT,
    CONSTRAINT pk_enrollment PRIMARY KEY(id),
    CONSTRAINT type_enrollment_status CHECK(status IN('enabled','disabled')),
    CONSTRAINT fk_enrollment_person FOREIGN KEY(fk_person) REFERENCES person (id),
    CONSTRAINT fk_enrollment_section FOREIGN KEY(fk_section) REFERENCES section (id),
    CONSTRAINT type_enrollment CHECK (type IN('student','teacher'))
);