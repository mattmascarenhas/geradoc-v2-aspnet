CREATE PROCEDURE spNovoBloco
    @Id UNIQUEIDENTIFIER,
	@Titulo VARCHAR(150),
    @DataCriacao DATETIME
    AS
    INSERT INTO [Blocos] (
    [Id],
	[Titulo],
    [DataCriacao]

    ) VALUES (
    @Id,
	@Titulo,
    @DataCriacao
    )

