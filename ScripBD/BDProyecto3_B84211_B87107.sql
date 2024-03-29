CREATE DATABASE Proyecto3_B84211_B87107
USE Proyecto3_B84211_B87107
CREATE TABLE tb_USUARIO (
CEDULA INT PRIMARY KEY NOT NULL
,CONTRASENA VARCHAR(20) NOT NULL
)
 ALTER TABLE [TB_USUARIO] ADD REGISTRADO INT

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
,DECRIPCION VARCHAR(100) NOT NULL
)


CREATE TABLE tb_VACUNA (
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL
,NOMBRE VARCHAR(20) NOT NULL
,DECRIPCION VARCHAR(100) NOT NULL
)

CREATE TABLE tb_CITA(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL
,CEDULA INT NOT NULL
,CENTRO_SALUD VARCHAR(100) NOT NULL
,FECHA DATETIME NOT NULL
,ESPECIALIDAD VARCHAR(50) NOT NULL
,DECRIPCION VARCHAR(100) 
,CODIGO VARCHAR(20)
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

ALTER TABLE  tb_ALERGIA_PACIENTE ADD DESCRIPCION varchar(100);

CREATE TABLE tb_VACUNA_PACIENTE(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL
,CEDULA INT NOT NULL
,ID_VACUNA INT NOT NULL
,FECHA_APLICACION DATE NOT NULL
,FECHA_PROX_DOS DATE NOT NULL
,FOREIGN KEY (ID_VACUNA) REFERENCES tb_VACUNA(ID)
,FOREIGN KEY (CEDULA) REFERENCES tb_USUARIO(CEDULA)
)

ALTER TABLE tb_VACUNA_PACIENTE ADD DESCRIPCION varchar(100);

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


INSERT INTO [dbo].[tb_PACIENTE]
           ([CEDULA]
           ,[NOMBRE]
           ,[EDAD]
           ,[TPSANGRE]
           ,[ESTADOCIVIL]
           ,[TELEFONO]
           ,[DOMICILIO])
     VALUES
           (305240689
           ,'Maria Perez'
           ,22
           ,'O+'
           ,'Soltera'
           ,89632548
           ,'Cartago,Turrialba,Turrialba')

INSERT INTO [dbo].[tb_VACUNA]
           ([NOMBRE]
           ,[DECRIPCION])
     VALUES
           ('BCG','Protege contra Tuberculosis')
		   ,
		   ('Hepatitis B','Protege contra Hepatitis B')
		    ,		    
		   ('Hib tipo b','Protege contra Meningitis,Aaemophilus influenzoe')
		    ,
		   ('D.P.T.','Protege contra Difteria,Tosferina,T�tanos')
		    ,
		   ('V.O.P.','Protege contra Poliomielitis')
		    ,
		   ('S.R.P.','Protege contra Sarampe�n,Rub�ola,Paperas')
		    ,
		   ('D.T.','Protege contra Difteria,T�tanos')
		   ,
		   ('Rotavirus','Protege contra Rotavirus')
		   ,
		   ('Covid','Protege contra Covid')


INSERT INTO [dbo].[tb_ALERGIA]
           ([NOMBRE]
           ,[DECRIPCION])
     VALUES
           ('Alergia a Alimentos','Picor en boca y paladar, vomito y diarrea')
		   ,
		   ('Alergia a Farmacos','Urticaria,Sarpullido,Hinchazon, Picor Piel y Ojos')
		   ,
		   ('Asma Al�rgico','Dificultad Respiratoria,Opresi�n Tor�cica,Tos Seca')
		   ,
		   ('Dermatitis at�pica','Pico,Rinitis,Engrosamiento de Piel y Piel Seca')
		   ,
		   ('Poliposis Nasal','Alteraci�n del Olfato, Aummento de Mucosidad, Dificulta para Rapirar y Ronquidos')
		   ,
		   ('Rinitis Al�rgica','Picor Nasal, Estornudos, Mucosidad y Congesti�n Nasal')
		   ,
		   ('Urticaria','Picor Intenso, Ronchas, Inflamacion de labios, parpados y lengua')

---Procedimientos almacenados Vacunas


CREATE PROCEDURE sp_LOGIN2
@param_CEDULA int
,@param_CONTRASENA varchar(20)
AS 
BEGIN
	IF EXISTS(
	SELECT * FROM  [dbo].[TB_USUARIO]
	WHERE [CEDULA] = @param_CEDULA 
	AND [CONTRASENA] = @param_CONTRASENA
	)
	BEGIN
		SELECT 1 AS EXISTE
	END
	ELSE
	BEGIN
	 SELECT 0 AS EXISTE
	END

END

EXEC sp_LOGIN2  305240689 ,'13' 


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

--Select vacunas

CREATE PROCEDURE sp_SELECT_VACUNAS
AS 
BEGIN
SELECT [ID]
      ,[NOMBRE]
      ,[DECRIPCION]
  FROM [dbo].[tb_VACUNA]

END

exec sp_SELECT_VACUNAS



CREATE PROCEDURE sp_SELECT_VACUNA_ID
@param_ID int
AS 
BEGIN
SELECT 
      [DECRIPCION]
  FROM [dbo].[tb_VACUNA]
  WHERE [ID] = @param_ID

END

exec sp_SELECT_VACUNA_ID 1

--Select CEDULAS

CREATE PROCEDURE sp_SELECT_CEDULAS
AS 
BEGIN
SELECT [CEDULA]
      ,[NOMBRE]
  FROM [dbo].[tb_PACIENTE]

END

exec sp_SELECT_CEDULAS


ALTER PROCEDURE sp_INSERT_VACUNA_PACIENTE
@param_CEDULA int
,@param_ID_VACUNA int
,@param_FECHA_APLICACION date
,@param_FECHA_PROX_DOS date
,@param_DESCRIPCION varchar(100)
AS 
BEGIN
INSERT INTO [dbo].[tb_VACUNA_PACIENTE]
           ([CEDULA]
           ,[ID_VACUNA]
           ,[FECHA_APLICACION]
           ,[FECHA_PROX_DOS]
           ,[DESCRIPCION])
     VALUES
           (@param_CEDULA
           ,@param_ID_VACUNA
           ,@param_FECHA_APLICACION
           ,@param_FECHA_PROX_DOS
           ,@param_DESCRIPCION)
END

EXECUTE [dbo].[sp_INSERT_VACUNA_PACIENTE] 
   305240689
  ,2
  ,'2021-07-14'
  ,'2031-07-14'
  ,'Protege contra Hepatitis B'


CREATE PROCEDURE sp_SELECT_VACUNA_PACIENTE
@param_CEDULA int
AS 
BEGIN

SELECT VP.[ID]
      ,VP.[CEDULA]
      ,VP.[ID_VACUNA]
	  ,V.NOMBRE
      ,VP.[FECHA_APLICACION]
      ,VP.[FECHA_PROX_DOS]
      ,VP.[DESCRIPCION]
	  
  FROM [dbo].[tb_VACUNA_PACIENTE] VP
  LEFT JOIN [dbo].[tb_VACUNA] V
	ON VP.ID_VACUNA = V.ID
	WHERE VP.CEDULA = @param_CEDULA
END

  
EXEC sp_SELECT_VACUNA_PACIENTE 305240689

CREATE PROCEDURE sp_DELETE_VACUNA_PACIENTE
@param_ID int
AS 
BEGIN
DELETE FROM [tb_VACUNA_PACIENTE]
		  WHERE [ID]=@param_ID
END

EXEC sp_DELETE_VACUNA_PACIENTE 1
  

ALTER PROCEDURE sp_UPDATE_VACUNA_PACIENTE
@param_ID int
,@param_CEDULA int
,@param_ID_VACUNA int
,@param_FECHA_APLICACION date
,@param_FECHA_PROX_DOS date
,@param_DESCRIPCION varchar(100)
AS 
BEGIN

IF EXISTS(
	SELECT * FROM  [tb_VACUNA_PACIENTE]
	WHERE [CEDULA] = @param_CEDULA 
	AND  ID = @param_ID 
	)
	BEGIN
		UPDATE [tb_VACUNA_PACIENTE]
		   SET [ID_VACUNA] = @param_ID_VACUNA
			  ,[FECHA_APLICACION] = @param_FECHA_APLICACION
			  ,[FECHA_PROX_DOS] = @param_FECHA_PROX_DOS
			  ,[DESCRIPCION] = @param_DESCRIPCION
		 WHERE ID = @param_ID 
			AND CEDULA = @param_CEDULA
	SELECT 'Actualizado' AS RESULTADO
  END
  ELSE
  BEGIN
	SELECT 'Datos incorrectos, no actualizado' AS RESULTADO
  END
END


--Procedimientos almacenados de alergias

CREATE PROCEDURE sp_SELECT_ALERGIAS
AS 
BEGIN
SELECT [ID]
      ,[NOMBRE]
      ,[DECRIPCION]
  FROM [dbo].[tb_ALERGIA]

END

exec sp_SELECT_ALERGIAS


CREATE PROCEDURE sp_SELECT_ALERGIA_ID
@param_ID int
AS 
BEGIN
SELECT
      [DECRIPCION]
  FROM [dbo].[tb_ALERGIA]
  WHERE [ID] = @param_ID

END

exec sp_SELECT_ALERGIA_ID 2


CREATE PROCEDURE sp_INSERT_ALERGIA_PACIENTE
@param_CEDULA int
,@param_ID_ALERGIA int
,@param_FECHA date
,@param_MADICAMENTOS varchar(100)
,@param_DESCRIPCION varchar(100)
AS 
BEGIN
INSERT INTO [dbo].[tb_ALERGIA_PACIENTE]
           ([CEDULA]
           ,[ID_ALERGIA]
           ,[FECHA]
           ,[MEDICAMENTOS]
           ,[DESCRIPCION])
     VALUES
           (@param_CEDULA
           ,@param_ID_ALERGIA
           ,@param_FECHA
           ,@param_MADICAMENTOS
           ,@param_DESCRIPCION)
END


alter PROCEDURE sp_SELECT_ALERGIA_PACIENTE
@param_CEDULA int
AS 
BEGIN

SELECT AP.ID
	  ,AP.CEDULA
	  ,AP.ID_ALERGIA
	  ,A.NOMBRE
	  ,AP.DESCRIPCION
	  ,AP.FECHA
	  ,AP.MEDICAMENTOS	  
  FROM [dbo].[tb_ALERGIA_PACIENTE] AP
  LEFT JOIN [dbo].[tb_ALERGIA] A
	ON AP.ID_ALERGIA = A.ID
	WHERE AP.CEDULA= @param_CEDULA
END
exec sp_SELECT_ALERGIA_PACIENTE 305240689


CREATE PROCEDURE sp_DELETE_ALERGIA_PACIENTE
@param_ID int
AS 
BEGIN
DELETE FROM [tb_ALERGIA_PACIENTE]
		  WHERE [ID]=@param_ID
END

EXEC sp_DELETE_ALERGIA_PACIENTE 1


CREATE PROCEDURE sp_UPDATE_ALERGIA_PACIENTE
@param_ID int
,@param_CEDULA int
,@param_ID_ALERGIA int
,@param_FECHA date
,@param_MEDICAMENTOS varchar(100)
,@param_DESCRIPCION varchar(100)
AS 
BEGIN

IF EXISTS(
	SELECT * FROM  [tb_ALERGIA_PACIENTE]
	WHERE [CEDULA] = @param_CEDULA 
	AND  ID = @param_ID 
	)
	BEGIN
		UPDATE [dbo].[tb_ALERGIA_PACIENTE]
		   SET [ID_ALERGIA] = @param_ID_ALERGIA
			  ,[FECHA] = @param_FECHA
			  ,[MEDICAMENTOS] = @param_MEDICAMENTOS
			  ,[DESCRIPCION] = @param_DESCRIPCION
		 WHERE [CEDULA] = @param_CEDULA 
		AND  ID = @param_ID 
	SELECT 'Actualizado' AS RESULTADO
  END
  ELSE
  BEGIN
	SELECT 'Datos incorrectos, no actualizado' AS RESULTADO
  END
END



--Procedimientos Citas

Alter PROCEDURE sp_INSERT_CITA_PACIENTE
@param_CEDULA int
,@param_CENTRO_SALUD varchar(100)
,@param_FECHA datetime
,@param_ESPECIALIDAD varchar(50)
,@param_CODIGO varchar(20)
AS 
BEGIN
INSERT INTO [dbo].[tb_CITA]
           ([CEDULA]
           ,[CENTRO_SALUD]
           ,[FECHA]
           ,[ESPECIALIDAD]
           ,[CODIGO])
     VALUES
           (@param_CEDULA
           ,@param_CENTRO_SALUD
           ,@param_FECHA
           ,@param_ESPECIALIDAD
		   ,@param_CODIGO)
END

EXECUTE [dbo].[sp_INSERT_CITA_PACIENTE] 
   305240689
  ,'Ebais 1'
  ,'2021-07-18T23:14:15'
  ,'Alergias'
  



  EXECUTE [dbo].[sp_INSERT_CITA_PACIENTE] 
   305240689
  ,'Ebais Paraiso Santiago'
  ,'2021-07-19T02:14:15'
  ,'Consulta General'
  ,'Medico1'
  

alter PROCEDURE sp_SELECT_CITAS_PACIENTE
@param_CEDULA int
AS 
BEGIN


SELECT [ID]
      ,[CEDULA]
      ,[CENTRO_SALUD]
      ,[FECHA]
      ,[ESPECIALIDAD]
      ,[DECRIPCION]
	  ,[CODIGO]
  FROM [dbo].[tb_CITA]
	WHERE CEDULA = @param_CEDULA
END


EXEC[dbo].[sp_SELECT_CITAS_PACIENTE] 305240689



CREATE PROCEDURE sp_DELETE_CITA_PACIENTE
@param_ID int
AS 
BEGIN
DELETE FROM [dbo].[tb_CITA]
		  WHERE [ID]=@param_ID
END



ALTER PROCEDURE sp_UPDATE_CITA_PACIENTE
@param_ID int
,@param_CEDULA int
,@param_CENTRO_SALUD varchar(100)
,@param_FECHA datetime
,@param_ESPECIALIDAD varchar(50)
,@param_DESCRIPCION varchar(100) = NULL
AS 
BEGIN

IF EXISTS(
	SELECT * FROM  [tb_CITA]
	WHERE [CEDULA] = @param_CEDULA 
	AND  ID = @param_ID 
	)
	BEGIN
		UPDATE [dbo].[tb_CITA]
		   SET [CEDULA] = @param_CEDULA
			  ,[CENTRO_SALUD] = @param_CENTRO_SALUD
			  ,[FECHA] = @param_FECHA
			  ,[ESPECIALIDAD] = @param_ESPECIALIDAD 
			  ,[DECRIPCION] = @param_DESCRIPCION
		 WHERE [CEDULA] = @param_CEDULA
		 AND  ID = @param_ID 
	SELECT 'Actualizado' AS RESULTADO
  END
  ELSE
  BEGIN
	SELECT 'Datos incorrectos, no actualizado' AS RESULTADO
  END
END


--pacientes

ALTER PROCEDURE sp_REGISTRAR
@param_CEDULA int
,@param_CONTRASENA varchar(20)
AS
BEGIN
	IF NOT EXISTS(
		SELECT * FROM  [TB_USUARIO]
		WHERE [CEDULA] = @param_CEDULA 
		)
	BEGIN
	  SELECT 'SU CEDULA NO EXISTE EN EL REGISTRO' AS RESULTADO
	END
	ELSE
	BEGIN
		IF EXISTS(
				SELECT * FROM  [TB_USUARIO]
				WHERE [CEDULA] = @param_CEDULA
				AND [REGISTRADO] = 1
		)
		BEGIN
			SELECT 'EL USUARIO YA HA SIDO REGISTRADO' AS RESULTADO
		END
		ELSE
		BEGIN
						UPDATE [dbo].[TB_USUARIO]
						   SET [CONTRASENA] = @param_CONTRASENA
							  ,[REGISTRADO] = 1
						WHERE [CEDULA] = @param_CEDULA 
					  SELECT 'REGISTRO EXITOSO' AS RESULTADO
	 END

	END

END


CREATE PROCEDURE sp_SELECT_PACIENTE
@param_CEDULA int
AS
BEGIN
SELECT [CEDULA]
      ,[NOMBRE]
      ,[EDAD]
      ,[TPSANGRE]
      ,[ESTADOCIVIL]
      ,[TELEFONO]
      ,[DOMICILIO]
  FROM [dbo].[tb_PACIENTE]
  WHERE [CEDULA]=@param_CEDULA
 END


CREATE PROCEDURE sp_UPDATE_PACIENTE
@param_CEDULA int
,@param_ESTADOCIVIL varchar(20)
,@param_TELEFONO int
,@param_DOMICILIO varchar(300)

AS
BEGIN
UPDATE [dbo].[tb_PACIENTE]
   SET [ESTADOCIVIL] = @param_ESTADOCIVIL
      ,[TELEFONO] = @param_TELEFONO
      ,[DOMICILIO] = @param_DOMICILIO
   WHERE [CEDULA]=@param_CEDULA
 END


 
INSERT INTO [dbo].[TB_USUARIO]
           ([CEDULA]
           ,[CONTRASENA]
           ,[REGISTRADO])
     VALUES
           (305250075
           ,''
           ,0)