-- Tablas de Administradores
CREATE TABLE IF NOT EXISTS ADMINISTRATORS(
	USER_ID UUID,
	USER_NAME VARCHAR,
	PASSWORD VARCHAR,
	CREATED_AT TIMESTAMP,
	PRIMARY KEY (USER_ID)
);
DROP TABLE IF EXISTS ADMINISTRATORS;

CREATE TABLE IF NOT EXISTS ADMINISTRATORS_LOGIN(
	USER_NAME VARCHAR,
	PASSWORD VARCHAR,
	PRIMARY KEY (USER_NAME)
);
CREATE INDEX ON ADMINISTRATORS_LOGIN(PASSWORD);
DROP TABLE IF EXISTS ADMINISTRATORS_LOGIN;



-- Tablas de Empleados
CREATE TABLE IF NOT EXISTS EMPLOYEES(
	USER_ID UUID,
	USER_NAME VARCHAR,
	PASSWORD VARCHAR,
	CREATED_AT TIMESTAMP,
	MODIFICATE_AT LIST<TIMESTAMP>,
	FIRST_NAME VARCHAR,
	FATHER_LAST_NAME VARCHAR,
	MOTHER_LAST_NAME VARCHAR,
	DATE_OF_BIRTH DATE,
	RFC VARCHAR,
	CURP VARCHAR,
	PRIMARY KEY (USER_ID)
);
DROP TABLE IF EXISTS EMPLOYEES;

CREATE TABLE IF NOT EXISTS EMPLOYEES_LOGIN(
	USER_NAME VARCHAR,
	PASSWORD VARCHAR,
	ENABLED BOOLEAN,
	PRIMARY KEY (USER_NAME)
);
CREATE INDEX ON EMPLOYEES_LOGIN(PASSWORD);
DROP TABLE IF EXISTS EMPLOYEES_LOGIN;

CREATE TABLE IF NOT EXISTS EMPLOYEES_ENABLED(
	USER_NAME VARCHAR,
	ENABLED BOOLEAN,
	PRIMARY KEY (ENABLED, USER_NAME)
);
DROP TABLE IF EXISTS EMPLOYEES_ENABLED;



-- Tablas de Clientes
CREATE TABLE IF NOT EXISTS CLIENTS(
	USER_ID UUID,
	USER_NAME VARCHAR,
	PASSWORD VARCHAR,
	CREATED_AT TIMESTAMP,
	MODIFICATE_AT LIST<TIMESTAMP>,
	FIRST_NAME VARCHAR,
	FATHER_LAST_NAME VARCHAR,
	MOTHER_LAST_NAME VARCHAR,
	DATE_OF_BIRTH DATE,
	EMAILS SET<TEXT>,
	CURP TEXT,
	GENDER VARCHAR,
	PRIMARY KEY (USER_ID)
);
DROP TABLE IF EXISTS CLIENTS;

CREATE TABLE IF NOT EXISTS CLIENTS_LOGIN(
	USER_NAME VARCHAR,
	PASSWORD VARCHAR,
	ENABLED BOOLEAN,
	PRIMARY KEY (USER_NAME)
);
CREATE INDEX ON CLIENTS_LOGIN(PASSWORD);
DROP TABLE IF EXISTS CLIENTS_LOGIN;

CREATE TABLE IF NOT EXISTS CLIENTS_ENABLED(
	USER_NAME VARCHAR,
	ENABLED BOOLEAN,
	PRIMARY KEY (ENABLED, USER_NAME)
);
DROP TABLE IF EXISTS CLIENTS_ENABLED;



-- Tabla de recordar usuario
CREATE TABLE IF NOT EXISTS USERS_REMEMBER(
	POSITION VARCHAR,
	USER_NAME VARCHAR,
	PASSWORD VARCHAR,
	PRIMARY KEY (POSITION, USER_NAME)
);
DROP TABLE IF EXISTS USERS_REMEMBER;



-- Tablas de contratos
CREATE TABLE IF NOT EXISTS CONTRACTS(
	CONTRACT_ID UUID,
	METER_SERIAL_NUMBER VARCHAR,
	SERVICE_NUMBER BIGINT,
	STATE VARCHAR,
	CITY VARCHAR,
	SUBURB VARCHAR,
	STREET VARCHAR,
	NUMBER VARCHAR,
	POSTAL_CODE VARCHAR,
	SERVICE VARCHAR,
	CLIENT_ID UUID,
	FIRST_NAME VARCHAR,
	FATHER_LAST_NAME VARCHAR,
	MOTHER_LAST_NAME VARCHAR,
	START_PERIOD_DATE DATE,
	CREATED_AT TIMESTAMP,
	PRIMARY KEY (CONTRACT_ID)
);
DROP TABLE IF EXISTS CONTRACTS;

CREATE TABLE IF NOT EXISTS CONTRACTS_BY_METER_SERIAL_NUMBER(
	CONTRACT_ID UUID,
	METER_SERIAL_NUMBER VARCHAR,
	SERVICE_NUMBER BIGINT,
	STATE VARCHAR,
	CITY VARCHAR,
	SUBURB VARCHAR,
	STREET VARCHAR,
	NUMBER VARCHAR,
	POSTAL_CODE VARCHAR,
	SERVICE VARCHAR,
	CLIENT_ID UUID,
	FIRST_NAME VARCHAR,
	FATHER_LAST_NAME VARCHAR,
	MOTHER_LAST_NAME VARCHAR,
	START_PERIOD_DATE DATE,
	CREATED_AT TIMESTAMP,
	PRIMARY KEY (METER_SERIAL_NUMBER)
);
CREATE INDEX ON CONTRACTS_BY_METER_SERIAL_NUMBER(SERVICE_NUMBER);
DROP TABLE IF EXISTS CONTRACTS_BY_METER_SERIAL_NUMBER;
                
CREATE TABLE IF NOT EXISTS CONTRACTS_BY_SERVICE(
	CONTRACT_ID UUID,
	METER_SERIAL_NUMBER VARCHAR,
	SERVICE_NUMBER BIGINT,
	STATE VARCHAR,
	CITY VARCHAR,
	SUBURB VARCHAR,
	STREET VARCHAR,
	NUMBER VARCHAR,
	POSTAL_CODE VARCHAR,
	SERVICE VARCHAR,
	CLIENT_ID UUID,
	FIRST_NAME VARCHAR,
	FATHER_LAST_NAME VARCHAR,
	MOTHER_LAST_NAME VARCHAR,
	START_PERIOD_DATE DATE,
	CREATED_AT TIMESTAMP,
	PRIMARY KEY (SERVICE, METER_SERIAL_NUMBER)
) WITH CLUSTERING ORDER BY (METER_SERIAL_NUMBER ASC);
DROP TABLE IF EXISTS CONTRACTS_BY_SERVICE;

CREATE TABLE IF NOT EXISTS CLIENT_CONTRACTS(
	CONTRACT_ID UUID,
	METER_SERIAL_NUMBER VARCHAR,
	SERVICE_NUMBER BIGINT,
	STATE VARCHAR,
	CITY VARCHAR,
	SUBURB VARCHAR,
	STREET VARCHAR,
	NUMBER VARCHAR,
	POSTAL_CODE VARCHAR,
	SERVICE VARCHAR,
	CLIENT_ID UUID,
	FIRST_NAME VARCHAR,
	FATHER_LAST_NAME VARCHAR,
	MOTHER_LAST_NAME VARCHAR,
	START_PERIOD_DATE DATE,
	CREATED_AT TIMESTAMP,
	PRIMARY KEY (CLIENT_ID, START_PERIOD_DATE, CONTRACT_ID)
) WITH CLUSTERING ORDER BY (START_PERIOD_DATE DESC, CONTRACT_ID ASC);
DROP TABLE IF EXISTS CLIENT_CONTRACTS;



-- Tablas de tarifas
CREATE TABLE IF NOT EXISTS RATES(
	RATE_ID UUID,
	BASIC_LEVEL DECIMAL,
	INTERMEDIATE_LEVEL DECIMAL,
	SURPLUS_LEVEL DECIMAL,
	SERVICE VARCHAR,
	YEAR INT,
	MONTH INT,
	PRIMARY KEY (RATE_ID)
);
DROP TABLE IF EXISTS RATES;

CREATE TABLE IF NOT EXISTS RATES_BY_YEAR(
	RATE_ID UUID,
	BASIC_LEVEL DECIMAL,
	INTERMEDIATE_LEVEL DECIMAL,
	SURPLUS_LEVEL DECIMAL,
	SERVICE VARCHAR,
	YEAR INT,
	MONTH INT,
	PRIMARY KEY (YEAR, MONTH, SERVICE, RATE_ID)
) WITH CLUSTERING ORDER BY (MONTH ASC, SERVICE ASC, RATE_ID ASC);
DROP TABLE IF EXISTS RATES_BY_YEAR;

CREATE TABLE IF NOT EXISTS RATES_ACTIVE(
	BASIC_LEVEL DECIMAL,
	INTERMEDIATE_LEVEL DECIMAL,
	SURPLUS_LEVEL DECIMAL,
	SERVICE VARCHAR,
	YEAR INT,
	MONTH INT,
	PRIMARY KEY ((YEAR, MONTH, SERVICE))
);
DROP TABLE IF EXISTS RATES_ACTIVE;



-- Tablas de consumos
CREATE TABLE IF NOT EXISTS CONSUMPTIONS(
	CONSUMPTION_ID UUID,
	CONTRACT_ID UUID,
	METER_SERIAL_NUMBER VARCHAR,
	SERVICE_NUMBER BIGINT,
	BASIC_KW DECIMAL,
	INTERMEDIATE_KW DECIMAL,
	SURPLUS_KW DECIMAL,
	TOTAL_KW DECIMAL,
	YEAR INT,
	MONTH INT,
	DAY INT,
	PRIMARY KEY (CONSUMPTION_ID)
);
DROP TABLE IF EXISTS CONSUMPTIONS;

CREATE TABLE IF NOT EXISTS CONSUMPTIONS_BY_YEAR(
	CONSUMPTION_ID UUID,
	CONTRACT_ID UUID,
	METER_SERIAL_NUMBER VARCHAR,
	SERVICE_NUMBER BIGINT,
	BASIC_KW DECIMAL,
	INTERMEDIATE_KW DECIMAL,
	SURPLUS_KW DECIMAL,
	TOTAL_KW DECIMAL,
	YEAR INT,
	MONTH INT,
	DAY INT,
	PRIMARY KEY (YEAR, MONTH, METER_SERIAL_NUMBER)
) WITH CLUSTERING ORDER BY (MONTH ASC, METER_SERIAL_NUMBER ASC);
DROP TABLE IF EXISTS CONSUMPTIONS_BY_YEAR;


CREATE TABLE IF NOT EXISTS CONSUMPTIONS_BY_METER_SERIAL_NUMBER(
	CONSUMPTION_ID UUID,
	CONTRACT_ID UUID,
	METER_SERIAL_NUMBER VARCHAR,
	SERVICE_NUMBER BIGINT,
	BASIC_KW DECIMAL,
	INTERMEDIATE_KW DECIMAL,
	SURPLUS_KW DECIMAL,
	TOTAL_KW DECIMAL,
	YEAR INT,
	MONTH INT,
	DAY INT,
	PRIMARY KEY (METER_SERIAL_NUMBER, YEAR, MONTH)
) WITH CLUSTERING ORDER BY (YEAR ASC, MONTH ASC);
DROP TABLE IF EXISTS CONSUMPTIONS_BY_METER_SERIAL_NUMBER;

CREATE TABLE IF NOT EXISTS CONSUMPTIONS_BY_SERVICE_NUMBER(
	CONSUMPTION_ID UUID,
	CONTRACT_ID UUID,
	METER_SERIAL_NUMBER VARCHAR,
	SERVICE_NUMBER BIGINT,
	BASIC_KW DECIMAL,
	INTERMEDIATE_KW DECIMAL,
	SURPLUS_KW DECIMAL,
	TOTAL_KW DECIMAL,
	YEAR INT,
	MONTH INT,
	DAY INT,
	PRIMARY KEY (SERVICE_NUMBER, YEAR, MONTH)
) WITH CLUSTERING ORDER BY (YEAR ASC, MONTH ASC);
DROP TABLE IF EXISTS CONSUMPTIONS_BY_SERVICE_NUMBER;



-- Tablas de recibos
CREATE TABLE IF NOT EXISTS RECEIPT(
	RECEIPT_ID UUID,
	CONTRACT_ID UUID,
	FIRST_NAME VARCHAR,
	FATHER_LAST_NAME VARCHAR,
	MOTHER_LAST_NAME VARCHAR,
	STATE VARCHAR,
	CITY VARCHAR,
	SUBURB VARCHAR,
	STREET VARCHAR,
	NUMBER VARCHAR,
	POSTAL_CODE VARCHAR,
	SERVICE VARCHAR,
	METER_SERIAL_NUMBER VARCHAR,
	SERVICE_NUMBER BIGINT,
	YEAR INT,
	MONTH INT,
	DAY INT,
	BASIC_LEVEL DECIMAL,
	INTERMEDIATE_LEVEL DECIMAL,
	SURPLUS_LEVEL DECIMAL,
	BASIC_KW DECIMAL,
	INTERMEDIATE_KW DECIMAL,
	SURPLUS_KW DECIMAL,
	TOTAL_KW DECIMAL,
	BASIC_PRICE DECIMAL,
	INTERMEDIATE_PRICE DECIMAL,
	SURPLUS_PRICE DECIMAL,
	SUBTOTAL_PRICE DECIMAL,
	TAX DECIMAL,
	PREV_AMOUNT DECIMAL,
	PREV_PRICE DECIMAL,
	TOTAL_PRICE DECIMAL,
	AMOUNT_PAID DECIMAL,
	PENDING_AMOUNT DECIMAL,
	PAYMENT_HISTORY MAP<TIMESTAMP, DECIMAL>,
	PAYMENT_TYPE_HISTORY LIST<VARCHAR>,
	IS_PAID BOOLEAN,
	PRIMARY KEY (RECEIPT_ID)
);
DROP TABLE IF EXISTS RECEIPT;

CREATE TABLE IF NOT EXISTS RECEIPT_BY_METER_SERIAL_NUMBER(
	RECEIPT_ID UUID,
	CONTRACT_ID UUID,
	FIRST_NAME VARCHAR,
	FATHER_LAST_NAME VARCHAR,
	MOTHER_LAST_NAME VARCHAR,
	STATE VARCHAR,
	CITY VARCHAR,
	SUBURB VARCHAR,
	STREET VARCHAR,
	NUMBER VARCHAR,
	POSTAL_CODE VARCHAR,
	SERVICE VARCHAR,
	METER_SERIAL_NUMBER VARCHAR,
	SERVICE_NUMBER BIGINT,
	YEAR INT,
	MONTH INT,
	DAY INT,
	BASIC_LEVEL DECIMAL,
	INTERMEDIATE_LEVEL DECIMAL,
	SURPLUS_LEVEL DECIMAL,
	BASIC_KW DECIMAL,
	INTERMEDIATE_KW DECIMAL,
	SURPLUS_KW DECIMAL,
	TOTAL_KW DECIMAL,
	BASIC_PRICE DECIMAL,
	INTERMEDIATE_PRICE DECIMAL,
	SURPLUS_PRICE DECIMAL,
	SUBTOTAL_PRICE DECIMAL,
	TAX DECIMAL,
	PREV_AMOUNT DECIMAL,
	PREV_PRICE DECIMAL,
	TOTAL_PRICE DECIMAL,
	AMOUNT_PAID DECIMAL,
	PENDING_AMOUNT DECIMAL,
	PAYMENT_HISTORY MAP<TIMESTAMP, DECIMAL>,
	PAYMENT_TYPE_HISTORY LIST<VARCHAR>,
	IS_PAID BOOLEAN,
	PRIMARY KEY (METER_SERIAL_NUMBER, YEAR, MONTH)
) WITH CLUSTERING ORDER BY (YEAR ASC, MONTH ASC);
DROP TABLE IF EXISTS RECEIPT_BY_METER_SERIAL_NUMBER;

CREATE TABLE IF NOT EXISTS RECEIPT_BY_SERVICE_NUMBER(
	RECEIPT_ID UUID,
	CONTRACT_ID UUID,
	FIRST_NAME VARCHAR,
	FATHER_LAST_NAME VARCHAR,
	MOTHER_LAST_NAME VARCHAR,
	STATE VARCHAR,
	CITY VARCHAR,
	SUBURB VARCHAR,
	STREET VARCHAR,
	NUMBER VARCHAR,
	POSTAL_CODE VARCHAR,
	SERVICE VARCHAR,
	METER_SERIAL_NUMBER VARCHAR,
	SERVICE_NUMBER BIGINT,
	YEAR INT,
	MONTH INT,
	DAY INT,
	BASIC_LEVEL DECIMAL,
	INTERMEDIATE_LEVEL DECIMAL,
	SURPLUS_LEVEL DECIMAL,
	BASIC_KW DECIMAL,
	INTERMEDIATE_KW DECIMAL,
	SURPLUS_KW DECIMAL,
	TOTAL_KW DECIMAL,
	BASIC_PRICE DECIMAL,
	INTERMEDIATE_PRICE DECIMAL,
	SURPLUS_PRICE DECIMAL,
	SUBTOTAL_PRICE DECIMAL,
	TAX DECIMAL,
	PREV_AMOUNT DECIMAL,
	PREV_PRICE DECIMAL,
	TOTAL_PRICE DECIMAL,
	AMOUNT_PAID DECIMAL,
	PENDING_AMOUNT DECIMAL,
	PAYMENT_HISTORY MAP<TIMESTAMP, DECIMAL>,
	PAYMENT_TYPE_HISTORY LIST<VARCHAR>,
	IS_PAID BOOLEAN,
	PRIMARY KEY (SERVICE_NUMBER, YEAR, MONTH)
) WITH CLUSTERING ORDER BY (YEAR ASC, MONTH ASC);
DROP TABLE IF EXISTS RECEIPT_BY_SERVICE_NUMBER;

CREATE TABLE IF NOT EXISTS RECEIPT_BY_YEAR(
	RECEIPT_ID UUID,
	CONTRACT_ID UUID,
	FIRST_NAME VARCHAR,
	FATHER_LAST_NAME VARCHAR,
	MOTHER_LAST_NAME VARCHAR,
	STATE VARCHAR,
	CITY VARCHAR,
	SUBURB VARCHAR,
	STREET VARCHAR,
	NUMBER VARCHAR,
	POSTAL_CODE VARCHAR,
	SERVICE VARCHAR,
	METER_SERIAL_NUMBER VARCHAR,
	SERVICE_NUMBER BIGINT,
	YEAR INT,
	MONTH INT,
	DAY INT,
	BASIC_LEVEL DECIMAL,
	INTERMEDIATE_LEVEL DECIMAL,
	SURPLUS_LEVEL DECIMAL,
	BASIC_KW DECIMAL,
	INTERMEDIATE_KW DECIMAL,
	SURPLUS_KW DECIMAL,
	TOTAL_KW DECIMAL,
	BASIC_PRICE DECIMAL,
	INTERMEDIATE_PRICE DECIMAL,
	SURPLUS_PRICE DECIMAL,
	SUBTOTAL_PRICE DECIMAL,
	TAX DECIMAL,
	PREV_AMOUNT DECIMAL,
	PREV_PRICE DECIMAL,
	TOTAL_PRICE DECIMAL,
	AMOUNT_PAID DECIMAL,
	PENDING_AMOUNT DECIMAL,
	PAYMENT_HISTORY MAP<TIMESTAMP, DECIMAL>,
	PAYMENT_TYPE_HISTORY LIST<VARCHAR>,
	IS_PAID BOOLEAN,
	PRIMARY KEY (YEAR, MONTH, SERVICE, RECEIPT_ID)
) WITH CLUSTERING ORDER BY (MONTH ASC, SERVICE ASC, RECEIPT_ID ASC);
DROP TABLE IF EXISTS RECEIPT_BY_YEAR;

CREATE TABLE IF NOT EXISTS EMIT_RECEIPT(
	YEAR INT,
	MONTH INT,
	SERVICE VARCHAR,
	PRIMARY KEY ((YEAR, MONTH, SERVICE))
);
DROP TABLE IF EXISTS EMIT_RECEIPT;



-- Tabla de fecha
CREATE TABLE IF NOT EXISTS DATES(
	ID INT,
	ACTUAL_DATE DATE,
	INITIAL BOOLEAN,
	PRIMARY KEY (ID)
);
DROP TABLE IF EXISTS DATES;



-- Tabla de actividad
CREATE TABLE IF NOT EXISTS ACTIVITY(
	ACTIVITY_ID UUID,
	USER_ID UUID,
	ACTION VARCHAR,
	OFFSET TIMESTAMP,
	PRIMARY KEY (ACTIVITY_ID, OFFSET)
) WITH CLUSTERING ORDER BY (OFFSET DESC);
DROP TABLE IF EXISTS ACTIVITY;