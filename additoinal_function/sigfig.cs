using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Project.additoinal_function
{
    public static class sigfig
    {
        public static int countsigfig(string input) // 유효숫자 계산
        {
            input = input.Trim(); // 의미 없는 0 제거

            if (!double.TryParse(input, out double val) || val == 0)
                return 1;

            // 지수 표기 제거
            if (input.Contains("E") || input.Contains("e"))
                input = double.Parse(input).ToString("G17");

            input = input.TrimStart('-').TrimStart('0'); // 음수 부호와 앞쪽 0 제거

            if (input.Contains("."))
            {
                input = input.TrimEnd('0'); // 소수점 오른쪽 0은 제거
                input = input.Replace(".", ""); // 소수점 제거
            }
            else
            {
                input = input.TrimEnd('0'); // 정수의 끝 0 제거
            }

            return input.Length; // 남은 자릿수가 유효 숫자
        }
        public static string roundsigfig(double num, int n) // 유효숫자로 반올림
        {
            if (num == 0)
                return "0";

            int digits = (int)Math.Floor(Math.Log10(Math.Abs(num))) + 1; // 10의 제곱근으로 자릿수 계산
            double factor = Math.Pow(10, n - digits);
            double rounded = Math.Round(num * factor) / factor;

            return rounded.ToString("G" + n); // 자릿수만큼 출력, G: 표기 자동 선택
        }
        public static string adjustsigfig(string input1, string input2, double result) // 두 항의 유효숫자 중 작은 수로 반환
        {
            int sig1 = countsigfig(input1);
            int sig2 = countsigfig(input2);
            int minSig = Math.Min(sig1, sig2);

            return roundsigfig(result, minSig);
        }
    }
}
// 폼에서 x, y를 문자로 지정하고 계산 함수 PerformYourOwnCalculation(x, y)를 사용하여 result에 저장
// 해당 클래스를 끌어와 adjustsigfig(x,y,result) 실행

