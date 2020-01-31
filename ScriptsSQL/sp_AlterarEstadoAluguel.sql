USE PimIV
GO

IF (OBJECT_ID('sp_AlterarEstadoAluguel', 'P') IS NOT NULL)
	DROP PROCEDURE sp_AlterarEstadoAluguel
GO

CREATE PROCEDURE sp_AlterarEstadoAluguel
AS
	BEGIN
		UPDATE dbo.Aluguel SET EstadoDoAluguel = 2 
			WHERE EstadoDoAluguel = 0 AND DataVencimento < GETDATE() OR EstadoDoPagamento = 2
	END
GO

