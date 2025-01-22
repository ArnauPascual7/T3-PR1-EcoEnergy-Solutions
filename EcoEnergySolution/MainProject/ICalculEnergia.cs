using System;
namespace MainProject
{
    public interface ICalculEnergia
    {
        void ConfigurateParameter(float par);
        float CalculateEnergy();
        void ShowReport(string configParName, float configPar);
    }
}
