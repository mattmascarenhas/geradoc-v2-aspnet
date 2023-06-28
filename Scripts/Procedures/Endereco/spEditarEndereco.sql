CREATE PROCEDURE spEditarEndereco
	@Id UNIQUEIDENTIFIER ,
	@Numero VARCHAR(10),
    @Rua VARCHAR(60),
	@Complemento VARCHAR(40),
	@Bairro VARCHAR(60),
	@Cidade VARCHAR(60),
	@Estado CHAR(2),
	@Cep CHAR(9)
AS
BEGIN
    UPDATE [Enderecos] 
    SET
        [Numero] = @Numero,
        [Rua] = @Rua,
        [Complemento] = @Complemento,
        [Bairro] = @Bairro,
        [Cidade] = @Cidade,
        [Estado] = @Estado,
        [Cep] = @Cep
    WHERE
        [Id] = @Id
END



    

