SELECT
    c.[Id],
    CONCAT(c.[PrimeiroNome], ' ', c.[Sobrenome]) AS [Nome],
    c.[Email],
    c.[CpfCnpj],
    c.[Telefone],
    e.[Cidade],
    e.[Estado]
FROM
    [Clientes] c
    INNER JOIN [Enderecos] e ON c.[Id] = e.[ClienteId]
WHERE
    c.[Id] = @id    

