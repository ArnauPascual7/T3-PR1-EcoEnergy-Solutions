using System;
namespace MainProject
{
    public interface ICalculEnergia
    {
        void ConfigurateParameter(double par);
        double CalculateEnergy();
        void ShowReport();
    }
}
