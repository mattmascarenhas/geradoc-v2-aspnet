CREATE PROCEDURE spChecarDocumento
	@Documento VARCHAR(18)
AS
	SELECT CASE WHEN EXISTS (
		SELECT [Id]
		FROM [Clientes]
		WHERE [CpfCnpj] = @Documento
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END