CREATE PROCEDURE spEditarBloco
    @BlocoId UNIQUEIDENTIFIER,
	@Titulo VARCHAR(150)
AS
BEGIN
    UPDATE [Blocos]
    SET
	[Titulo] = @Titulo
    WHERE
    [Id] = @BlocoId
END
