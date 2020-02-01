USE PimIV
GO

IF(OBJECT_ID('sp_AlterarEstadoMotorista', 'P') IS NOT NULL)
	DROP PROCEDURE sp_AlterarEstadoMotorista
GO

CREATE PROCEDURE sp_AlterarEstadoMotorista
AS
BEGIN
	/*Define o Estado do motorista para PONTOS ESTOURADOS caso exceda o limite de pontuação*/
	UPDATE Motorista SET Estado = 1
		WHERE Estado != 1 AND PontosCNH > 20;

	/*Define o Estado do motorista para EXAME VENCIDO caso exceda o limite de pontuação*/
	UPDATE Motorista SET Estado = 2
		WHERE Estado != 2 AND VencimentoExame < GETDATE()

	/*Define os Estados de volta ao normal caso os pontos ou exame voltem a ficar de acordo*/
	UPDATE Motorista SET Estado = 0
		WHERE Estado = 1 AND PontosCNH < 20

	UPDATE Motorista SET Estado = 0
		WHERE Estado = 2 AND VencimentoExame > GETDATE()
END