namespace TekmanPruebaTecnica.Application.Services;

public class AppSettings
{
    public decimal PercentageActivity { get; set; } = 0.2M;
    public decimal PercentatgeExercice { get; set; } = 0.2M;
    public decimal PercentatgeSelfEvaluation { get; set; } = 0.1M;
    public decimal PercentatgeTest { get; set; } = 0.5M;

    public decimal PercentageSocial { get; set; } = 0.2M;
    public decimal PercentatgeDigital { get; set; } = 0.2M;
    public decimal PercentatgeMaths { get; set; } = 0.6M;
}
