CREATE DATABASE Proyecto3_B84211_B87107
USE Proyecto3_B84211_B87107
CREATE TABLE tb_USUARIO (
CEDULA INT PRIMARY KEY NOT NULL
,CONTRASENA VARCHAR(20) NOT NULL
)

CREATE TABLE tb_PACIENTE (
CEDULA INT NOT NULL
,NOMBRE VARCHAR(100) NOT NULL
,EDAD INT NOT NULL
,TPSANGRE VARCHAR(10) NOT NULL
,ESTADOCIVIL VARCHAR(20) NOT NULL
,TELEFONO INT NOT NULL
,DOMICILIO VARCHAR(300) NOT NULL
,FOREIGN KEY (CEDULA) REFERENCES tb_USUARIO(CEDULA)
)

CREATE TABLE tb_MEDICO (
CEDULA INT PRIMARY KEY NOT NULL
,CODIGO VARCHAR(20) NOT NULL
,CONTRASENA VARCHAR(20) NOT NULL
)

CREATE TABLE tb_ALERGIA (
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL
,NOMBRE VARCHAR(20) NOT NULL
,DECRIPCION VARCHAR(20) NOT NULL
)


CREATE TABLE tb_VACUNA (
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL
,NOMBRE VARCHAR(20) NOT NULL
,DECRIPCION VARCHAR(20) NOT NULL
)

CREATE TABLE tb_CITA(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL
,CEDULA INT NOT NULL
,CENTRO_SALUD VARCHAR(100) NOT NULL
,FECHA DATETIME NOT NULL
,ESPECIALIDAD VARCHAR(20) NOT NULL
,DECRIPCION VARCHAR(20) NOT NULL
,FOREIGN KEY (CEDULA) REFERENCES tb_USUARIO(CEDULA)
)

CREATE TABLE tb_ALERGIA_PACIENTE(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL
,CEDULA INT NOT NULL
,ID_ALERGIA INT NOT NULL
,FECHA DATETIME NOT NULL
,MEDICAMENTOS VARCHAR(200) NOT NULL
,FOREIGN KEY (ID_ALERGIA) REFERENCES tb_ALERGIA(ID)
,FOREIGN KEY (CEDULA) REFERENCES tb_USUARIO(CEDULA)
)

CREATE TABLE tb_VACUNA_PACIENTE(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL
,CEDULA INT NOT NULL
,ID_VACUNA INT NOT NULL
,FECHA_APLICACION DATETIME NOT NULL
,FECHA_PROX_DOS DATETIME NOT NULL
,FOREIGN KEY (ID_VACUNA) REFERENCES tb_VACUNA(ID)
,FOREIGN KEY (CEDULA) REFERENCES tb_USUARIO(CEDULA)
)

--INSERT

INSERT INTO [dbo].[tb_USUARIO]
           ([CEDULA]
           ,[CONTRASENA])
     VALUES
           (305240689
           ,'123')


INSERT INTO [dbo].[tb_MEDICO]
           ([CEDULA]
           ,[CODIGO]
           ,[CONTRASENA])
     VALUES
           (305000500
           ,'Medico1'
           ,'123')

---Procedimientos almacenados



CREATE PROCEDURE sp_LOGIN
@param_CEDULA int
,@param_CODIGO varchar(20)
,@param_CONTRASENA varchar(20)

AS 
BEGIN
	IF EXISTS(
	SELECT * FROM  [dbo].[tb_MEDICO]
	WHERE [CEDULA] = @param_CEDULA 
	AND  [CODIGO] = @param_CODIGO
	AND [CONTRASENA] = @param_CONTRASENA
	)
	BEGIN
		SELECT 
		1 AS EXISTE
		,[CEDULA]
		,[CODIGO]
		,[CONTRASENA]
		FROM [dbo].[tb_MEDICO]
		WHERE [CEDULA] = @param_CEDULA
	END
	ELSE
	BEGIN
	 SELECT 0 AS EXISTE,' ' AS CEDULA,' ' AS CODIGO,' ' AS CONTRASENA
	END

END

EXEC sp_LOGIN  305000500 ,'Medico1' ,'123'