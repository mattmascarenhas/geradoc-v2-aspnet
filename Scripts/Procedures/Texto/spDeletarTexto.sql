CREATE PROCEDURE spDeletarTexto
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM [Textos]
    WHERE [Id] = @Id
END
