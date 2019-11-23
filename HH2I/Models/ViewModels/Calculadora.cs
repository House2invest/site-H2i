namespace House2Invest.Models.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class Calculadora
    {

        public string ChaveId
        { get; set; }

        public string Titulo
        { get; set; }

        public bool ExibTitulo
        { get; set; }

        public string Valor
        { get; set; }

        public string Lance
        { get; set; }

        public string ValorMinimoDocs
        { get; set; }

        public double Reservado
        { get; set; }

        public int Id
        { get; set; }

        public int Contador_DataFinal_Ano
        { get; set; }
        public int Contador_DataFinal_Mes
        { get; set; }

        public int Contador_DataFinal_Dia
        { get; set; }

        public int Contador_DataFinal_Hor
        { get; set; }

        public int Contador_DataFinal_Min
        { get; set; }

        public int Contador_DataFinal_Seg
        { get; set; }
    }
}

