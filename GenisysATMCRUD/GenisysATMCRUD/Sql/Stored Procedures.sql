USE GenisysATM_V2
GO

-- TABLA Cliente
CREATE PROCEDURE sp_insertarCliente(
	@nombre nvarchar(100),
	@apellido nvarchar(100),
	@identidad char(13),
	@direccion nvarchar(2000),
	@telefono char(9),
	@celular char(9)
)
AS
BEGIN
	INSERT INTO ATM.Cliente(nombres,apellidos,identidad,direccion,telefono,celular)
		VALUES (@nombre,@apellido,@identidad,@direccion,@telefono,@celular)
END
GO

CREATE PROCEDURE sp_ActualizarCliente(
	@nombre nvarchar(100),
	@apellido nvarchar(100),
	@identidad char(13),
	@direccion nvarchar(2000),
	@telefono char(9),
	@celular char(9)
)
AS
BEGIN
	UPDATE ATM.Cliente SET nombres=@nombre, apellidos=@apellido, direccion=@direccion, telefono=@telefono,celular= @celular
	WHERE identidad=@identidad; 
END
GO

CREATE PROCEDURE sp_EliminarCliente(
	@nombre NVARCHAR(100)
)
AS
BEGIN
	DECLARE @codigo int;
	SET @codigo = (SELECT id FROM ATM.Cliente WHERE nombres=@nombre);

	DELETE FROM ATM.Cliente WHERE id = @codigo;
END
GO


-- TABLA ServicioPublico
CREATE PROCEDURE sp_AgregarServicioPublico(
	@descripcion NVARCHAR(150)
)
AS
BEGIN
	INSERT INTO ATM.ServicioPublico(descripcion) VALUES (@descripcion);
END
GO

CREATE PROCEDURE sp_ActualizarServicioPublico(
	@descripcion NVARCHAR(150),
	@correccion NVARCHAR(150)
)
AS
BEGIN
 DECLARE @codigo INT
 SET @codigo = (SELECT id FROM ATM.ServicioPublico WHERE descripcion=@descripcion);
 UPDATE ATM.ServicioPublico SET descripcion = @correccion WHERE id = @codigo;
END
GO

CREATE PROCEDURE sp_EliminarServicioPublico(
	@descripcion NVARCHAR(150)
)
AS
BEGIN
 DECLARE @codigo INT
 SET @codigo = (SELECT id FROM ATM.ServicioPublico WHERE descripcion=@descripcion);
 DELETE FROM ATM.ServicioPublico WHERE descripcion = @descripcion;
END
GO

USE GenisysATM_V2
GO
--Procedimiento almacenado para insertar un servicio a un cliente.
CREATE PROCEDURE sp_AgregarServicioCliente(
@cliente NVARCHAR(100),
@servicio NVARCHAR(100),
@saldo DECIMAL(10,2)
)
AS 
BEGIN
	DECLARE @codigoCliente INT
	DECLARE @codigoServicio INT

	SET @codigoCliente = (SELECT id FROM ATM.Cliente WHERE nombres = @cliente);
	SET @codigoServicio = (SELECT id FROM ATM.ServicioPublico WHERE descripcion=@servicio);

	INSERT INTO ATM.ServicioCliente(idCliente,idServicio,saldo) VALUES(@codigoCliente,@codigoServicio,@saldo);
END
GO
--Procedimiento almacenado para actualizar un servicioCliente
CREATE PROCEDURE sp_ActualizarServicioCliente(
@cliente NVARCHAR(100),
@servicio NVARCHAR(100),
@saldo DECIMAL(10,2)
)
AS 
BEGIN
	DECLARE @codigoCliente INT
	DECLARE @codigoServicio INT
	DECLARE @codigo INT

	SET @codigoCliente = (SELECT id FROM ATM.Cliente WHERE nombres = @cliente);
	SET @codigoServicio = (SELECT id FROM ATM.ServicioPublico WHERE descripcion=@servicio);

	SET @codigo = (SELECT id FROM ATM.ServicioCliente WHERE idCliente=@codigoCliente and idServicio=@codigoServicio);

	UPDATE ATM.ServicioCliente SET idCliente=@codigoCliente,idServicio=@codigoServicio,saldo=@saldo WHERE id=@codigo;
END
GO

--Procedimiento almacenado para Eliminar un servicioCliente
CREATE PROCEDURE sp_EliminarServicioCliente(
@cliente NVARCHAR(100),
@servicio NVARCHAR(100)
)
AS 
BEGIN
	DECLARE @codigoCliente INT
	DECLARE @codigoServicio INT
	DECLARE @codigo INT

	SET @codigoCliente = (SELECT id FROM ATM.Cliente WHERE nombres = @cliente);
	SET @codigoServicio = (SELECT id FROM ATM.ServicioPublico WHERE descripcion=@servicio);

	SET @codigo = (SELECT id FROM ATM.ServicioCliente WHERE idCliente=@codigoCliente and idServicio=@codigoServicio);

	DELETE FROM ATM.ServicioCliente WHERE id=@codigo;
END
GO