using System;


namespace Eq_2_grau
{
    class Bhaskara
    {
        public double A; //criando variáveis A, B e C

        public double B;

        public double C;

        public double Delta()
        {
            return (B * B) - 4 * A * C; //calculando Delta
        }
        public double X1()
        {
            return (-B - Math.Sqrt(Delta())) / (2 * A); //calculando X'
        }
        public double X2()
        {
            return (-B + Math.Sqrt(Delta())) / (2 * A); // calculando x''
        }
    }
}
