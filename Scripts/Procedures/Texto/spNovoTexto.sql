CREATE PROCEDURE spNovoTexto
    @Id UNIQUEIDENTIFIER,
	@Titulo VARCHAR(150),
	@Texto text,
    @DataCriacao DATETIME
    AS
    INSERT INTO [Textos] (
    [Id],
	[Titulo],
	[Texto],
    [DataCriacao]

    ) VALUES (
    @Id,
	@Titulo,
	@Texto,
    @DataCriacao
    )

