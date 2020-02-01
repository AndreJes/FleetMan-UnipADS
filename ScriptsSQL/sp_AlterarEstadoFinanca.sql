USE PimIV
GO

IF(OBJECT_ID('sp_AlterarEstadoFinanca', 'P') IS NOT NULL)
	DROP PROCEDURE sp_AlterarEstadoFinanca
GO

CREATE PROCEDURE sp_AlterarEstadoFinanca
AS
	BEGIN
		UPDATE Financa SET EstadoPagamento = 1
			WHERE EstadoPagamento = 2 AND DataVencimento < GETDATE()
	END
GO