USE PimIV
GO

IF (OBJECT_ID('sp_AlterarEstadoMulta', 'P') IS NOT NULL)
	DROP PROCEDURE sp_AlterarEstadoMulta
GO

CREATE PROCEDURE sp_AlterarEstadoMulta
AS
	BEGIN
		UPDATE Multa SET EstadoDoPagamento = 1
			WHERE EstadoDoPagamento = 2 AND DataVencimento < GETDATE()
	END
GO