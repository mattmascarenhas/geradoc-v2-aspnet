CREATE PROCEDURE spNovoEndereco
	@Id UNIQUEIDENTIFIER ,
	@ClienteId UNIQUEIDENTIFIER,
	@Numero VARCHAR(10),
    @Rua VARCHAR(60),
	@Complemento VARCHAR(40),
	@Bairro VARCHAR(60),
	@Cidade VARCHAR(60),
	@Estado CHAR(2),
	@Cep CHAR(9)
AS
    INSERT INTO [Enderecos] (
	[Id],
	[ClienteId],
	[Numero],
    [Rua],
	[Complemento],
	[Bairro],
	[Cidade],
	[Estado],
	[Cep]
    ) VALUES (
	@Id,
	@ClienteId,
	@Numero,
    @Rua,
	@Complemento,
	@Bairro,
	@Cidade,
	@Estado,
	@Cep
    )

