CREATE PROCEDURE spNovoCliente
    @Id UNIQUEIDENTIFIER,
	@PrimeiroNome VARCHAR(40),
	@Sobrenome VARCHAR(150),
	@CpfCnpj VARCHAR(18),
	@Rg INTEGER,
	@Nacionalidade VARCHAR(30),
	@EstadoCivil VARCHAR(20),
	@OrgaoEmissor VARCHAR(20),
	@Profissao VARCHAR(160),
	@Email VARCHAR(160),
	@Telefone VARCHAR(13)
AS
    INSERT INTO [Clientes] (
    [Id],
	[PrimeiroNome],
	[Sobrenome],
	[CpfCnpj],
	[Rg],
	[Nacionalidade],
	[EstadoCivil],
	[OrgaoEmissor],
	[Profissao],
	[Email],
	[Telefone] 
    ) VALUES (
    @Id,
	@PrimeiroNome,
	@Sobrenome,
	@CpfCnpj,
	@Rg,
	@Nacionalidade,
	@EstadoCivil,
	@OrgaoEmissor,
	@Profissao,
	@Email,
	@Telefone 
    )

