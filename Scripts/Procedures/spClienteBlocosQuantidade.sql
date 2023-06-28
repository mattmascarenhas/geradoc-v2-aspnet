CREATE PROCEDURE spClienteBlocosQuantidade
    @Cpf UNIQUEIDENTIFIER
AS
BEGIN
    SELECT
        c.[Id],
        CONCAT(c.[PrimeiroNome], ' ', c.[Sobrenome]) AS [Nome],
        c.[Email],
        c.[CpfCnpj],
        c.[Telefone],
        COUNT(cb.[BlocoId]) AS [QuantidadeBlocos]
    FROM
        [Clientes] c
        LEFT JOIN [ClientesBlocos] cb ON c.[Id] = cb.[ClienteId]
    WHERE
        c.[CpfCnpj] = @Cpf
    GROUP BY
        c.[Id],
        c.[PrimeiroNome],
        c.[Sobrenome],
        c.[Email],
        c.[CpfCnpj],
        c.[Telefone];
END;