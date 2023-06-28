CREATE PROCEDURE spEditarCliente
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
BEGIN
    UPDATE [Clientes]
    SET
        [PrimeiroNome] = @PrimeiroNome,
        [Sobrenome] = @Sobrenome,
        [CpfCnpj] = @CpfCnpj,
        [Rg] = @Rg,
        [Nacionalidade] = @Nacionalidade,
        [EstadoCivil] = @EstadoCivil,
        [OrgaoEmissor] = @OrgaoEmissor,
        [Profissao] = @Profissao,
        [Email] = @Email,
        [Telefone] = @Telefone 
    WHERE
        [Id] = @Id

END
