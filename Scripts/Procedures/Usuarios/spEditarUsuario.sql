CREATE PROCEDURE spEditarUsuario
    @Id UNIQUEIDENTIFIER,
	@PrimeiroNome VARCHAR(40),
	@Sobrenome VARCHAR(150),
	@CpfCnpj VARCHAR(18),
	@Email VARCHAR(160),
	@Telefone VARCHAR(14),
    @Senha VARCHAR(100)
AS
BEGIN
    UPDATE [Usuarios]
    SET
        [PrimeiroNome] = @PrimeiroNome,
        [Sobrenome] = @Sobrenome,
        [CpfCnpj] = @CpfCnpj,
        [Email] = @Email,
        [Telefone] = @Telefone,
        [Senha] = @Senha
    WHERE
        [Id] = @Id

END
