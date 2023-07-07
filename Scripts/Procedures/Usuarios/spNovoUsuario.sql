CREATE PROCEDURE spNovoUsuario
    @Id UNIQUEIDENTIFIER,
	@PrimeiroNome VARCHAR(40),
	@Sobrenome VARCHAR(150),
	@CpfCnpj VARCHAR(18),
	@Email VARCHAR(160),
	@Telefone VARCHAR(14),
    @Senha VARCHAR(100)
AS
    INSERT INTO [Usuarios] (
    [Id],
	[PrimeiroNome],
	[Sobrenome],
	[CpfCnpj],
	[Email],
	[Telefone],
    [Senha] 
    ) VALUES (
    @Id,
	@PrimeiroNome,
	@Sobrenome,
	@CpfCnpj,
	@Email,
	@Telefone,
    @Senha
    )

