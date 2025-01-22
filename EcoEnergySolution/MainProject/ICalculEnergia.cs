using System;
namespace MainProject
{
    public interface ICalculEnergia
    {
        void ConfigurarParametres();
        float CalcularEnergia();
        void MostrarInforme(string configParName, float configPar);
    }
}
