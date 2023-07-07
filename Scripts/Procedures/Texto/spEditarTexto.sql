CREATE PROCEDURE spEditarTexto
    @Id UNIQUEIDENTIFIER,
	@Titulo VARCHAR(150),
	@Texto text
AS
BEGIN
    UPDATE [Textos]
    SET
	[Titulo] = @Titulo,
	[Texto] = @Texto
    WHERE
    [Id] = @Id

END
