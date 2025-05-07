using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Project.CalMath
{

    public class TrigFunctions
    {
        // 사인 함수
        public double CalculateSin(double degree)
        {
            double radian = degree * Math.PI / 180;
            double result = Math.Sin(radian);
            return result;
        }

        // 코사인 함수
        public double CalculateCos(double degree)
        {
            double radian = degree * Math.PI / 180;
            double result = Math.Cos(radian);
            return result;
        }

        // 탄젠트 함수
        public double CalculateTan(double degree)
        {
            double radian = degree * Math.PI / 180;
            double result = Math.Tan(radian);
            return result;
        }

        // 아크사인
        public double CalculateArcSin(double x)
        {
            double radian = Math.Asin(x);
            double degree = radian * 180 / Math.PI;
            return degree;
        }

        // 아크코사인
        public double CalculateArcCos(double x)
        {
            double radian = Math.Acos(x);
            double degree = radian * 180 / Math.PI;
            return degree;
        }

        // 아크탄젠트
        public double CalculateArcTan(double x)
        {
            double radian = Math.Atan(x);
            double degree = radian * 180 / Math.PI;
            return degree;
        }
    }
}

