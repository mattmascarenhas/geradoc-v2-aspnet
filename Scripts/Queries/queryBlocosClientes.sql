--query para exibir os blocos e o cliente dono do bloco

    SELECT
    b.[Id] AS [BlocoId],
    CONCAT(c.[PrimeiroNome], ' ', c.[Sobrenome]) AS [Cliente],
    b.[Titulo] AS [TituloBloco]

FROM
    [ClientesBlocos] cb
    INNER JOIN [Clientes] c ON cb.[ClienteId] = c.[Id]
    INNER JOIN [Blocos] b ON cb.[BlocoId] = b.[Id];