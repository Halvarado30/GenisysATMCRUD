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
--TABLA ServicioCliente
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

-- TABLA Configuracion
CREATE PROCEDURE sp_AgregarConfiguracion(
@nombre NCHAR(50),
@descripcion NCHAR(200),
@valor NCHAR(50)
)
AS
BEGIN
	INSERT INTO ATM.Configuracion(appKey,valor,descripcion) VALUES (@nombre,@valor,@descripcion);
END
GO

CREATE PROCEDURE sp_ActualizarConfiguracion(
@nombre NCHAR(50),
@nombrenuevo NCHAR(50),
@descripcion NCHAR(200),
@valor NCHAR(50)
)
AS
BEGIN
	DECLARE @codigo INT
	SET @codigo = (SELECT id FROM ATM.Configuracion WHERE appKey =@nombre); 
	UPDATE ATM.Configuracion SET appKey=@nombrenuevo,descripcion=@descripcion,valor=@valor WHERE id = @codigo;
END
GO

CREATE PROCEDURE sp_EliminarConfiguracion(
@nombre NCHAR(50)

)
AS
BEGIN
	DECLARE @codigo INT
	SET @codigo = (SELECT id FROM ATM.Configuracion WHERE appKey =@nombre); 
	DELETE FROM ATM.Configuracion WHERE id=@codigo;
END
GO

-- TABLA TarjetaCredito
CREATE PROCEDURE sp_AgregarTarjeta(
	@descripcion NVARCHAR(100),
	@monto DECIMAL(12,2),
	@limite DECIMAL(12,2),
	@cliente NVARCHAR(100)
)
AS
BEGIN
	DECLARE @codigoCliente INT
	SET @codigoCliente = (SELECT id FROM ATM.Cliente WHERE nombres=@cliente);

	INSERT INTO ATM.TarjetaCredito(descripcion,monto,limite,idCliente) VALUES (@descripcion,@monto,@limite,@codigoCliente);
END
GO

CREATE PROCEDURE sp_ActualizarTarjeta(
	@descripcion NVARCHAR(100),
	@nuevaDescripcion NVARCHAR(100),
	@monto DECIMAL(12,2),
	@limite DECIMAL(12,2),
	@cliente NVARCHAR(100)
)
AS
BEGIN
	DECLARE @codigoCliente INT
	SET @codigoCliente = (SELECT id FROM ATM.Cliente WHERE nombres=@cliente);
	DECLARE @codigoTarjeta INT
	SET @codigoTarjeta = (SELECT id FROM ATM.TarjetaCredito WHERE idCliente=@codigoCliente and descripcion=@descripcion);

	UPDATE ATM.TarjetaCredito SET descripcion=@nuevaDescripcion,monto=@monto,limite=@limite,idCliente=@codigoCliente WHERE id=@codigoTarjeta;
END
GO

CREATE PROCEDURE sp_EliminarTarjeta(
	@descripcion NVARCHAR(100),
	@cliente NVARCHAR(100)
)
AS
BEGIN
	DECLARE @codigoCliente INT
	SET @codigoCliente = (SELECT id FROM ATM.Cliente WHERE nombres=@cliente);
	DECLARE @codigoTarjeta INT
	SET @codigoTarjeta = (SELECT id FROM ATM.TarjetaCredito WHERE idCliente=@codigoCliente and descripcion=@descripcion);

	DELETE FROM ATM.TarjetaCredito WHERE id=@codigoTarjeta;
END
GO

-- TABLA CuentaCliente
CREATE PROCEDURE sp_AgregarCuenta(
	@numero CHAR(14),
	@cliente NVARCHAR(100),
	@saldo DECIMAL(10,2),
	@pin CHAR(4)
)
AS
BEGIN
	DECLARE @codigoCliente INT
	SET @codigoCliente =(SELECT id FROM ATM.Cliente WHERE nombres=@cliente);

	INSERT INTO ATM.CuentaCliente(numero,idCliente,saldo,pin) VALUES (@numero,@codigoCliente,@saldo,@pin);

END
GO

CREATE PROCEDURE sp_ActualizarCuentaCliente(
	@numero CHAR(14),
	@cliente NVARCHAR(100),
	@saldo DECIMAL(10,2),
	@pin CHAR(4),
	@nuevoNumero CHAR(14)
)
AS
BEGIN
	DECLARE @codigoCliente INT
	SET @codigoCliente =(SELECT id FROM ATM.Cliente WHERE nombres=@cliente);

	UPDATE ATM.CuentaCliente SET saldo=@saldo, pin=@pin, numero=@nuevoNumero WHERE numero=@numero;

END
GO

CREATE PROCEDURE sp_EliminarCuenta(
	@numero CHAR(14)
)
AS
BEGIN
	DELETE FROM ATM.CuentaCliente WHERE numero=@numero;
END
GO