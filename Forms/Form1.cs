using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Calculate_Project.simplipy;
using Calculate_Project.CalMath;
using Calculate_Project.additoinal_function;

namespace Calculate_Project
{
        public partial class Form1 : Form
    {
        double x, y, result;
        char operation;

        private string Input1;
        private string Input2;

        public Form1()
        {
            InitializeComponent();
        }

        private void AppendToInput(int a)
        {
            textBox_result.Text += a.ToString();
        }

        
        private void button_add_Click(object sender, EventArgs e)
        {
            operation = '+';
            textBox_result.Text += "+";
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            operation = '-';
            textBox_result.Text += "-";
        }

        private void button_multiply_Click(object sender, EventArgs e)
        {
            operation = 'x';
            textBox_result.Text += "x";
        } 

        private void button_division_Click(object sender, EventArgs e)
        {

            operation = '/';
            textBox_result.Text += "/";
        }

        private void button_factorial_Click(object sender, EventArgs e)
        {
            string input = textBox_result.Text.Trim();

            if (int.TryParse(input, out int n))
            {
                if (n < 0)
                {
                    textBox_result.Text = "음수는 불가";
                    return;
                }

                long result = combi.Factorial(n);
                textBox_result.Text = result.ToString();
            }
            else
            {
                textBox_result.Text = "정수만 가능.";
            }

        }

        private void button_comb_Click(object sender, EventArgs e)
        {
            textBox_result.Text += "C";
        }

        private void button_perm_Click(object sender, EventArgs e)
        {
            textBox_result.Text += "P";
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            AppendToInput(0);
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            AppendToInput(1);
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            AppendToInput(2);
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            AppendToInput(3);
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            AppendToInput(4);
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            AppendToInput(5);
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            AppendToInput(6);
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            AppendToInput(7);
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            AppendToInput(8);
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            AppendToInput(9);
        }

        private void button_sin_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                TrigFunctions tri = new TrigFunctions();
                double result = tri.CalculateSin(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_cos_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                TrigFunctions tri = new TrigFunctions();
                double result = tri.CalculateCos(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_tan_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                TrigFunctions tri = new TrigFunctions();
                double result = tri.CalculateTan(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_asin_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                TrigFunctions tri = new TrigFunctions();
                double result = tri.CalculateArcSin(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_acos_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                TrigFunctions tri = new TrigFunctions();
                double result = tri.CalculateArcCos(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_atan_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                TrigFunctions tri = new TrigFunctions();
                double result = tri.CalculateArcTan(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_sqare_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                ScientificFunctions sci = new ScientificFunctions();
                double result = sci.Square(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_exp_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                ScientificFunctions sci = new ScientificFunctions();
                double result = sci.Exp(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_pow_Click(object sender, EventArgs e)
        {
            string input = textBox_result.Text;

            if (input.Contains("^"))
            {
                string[] parts = input.Split('^');

                if (parts.Length == 2 && double.TryParse(parts[0], out double basenum) && double.TryParse(parts[1], out double exponent))
                {
                    ScientificFunctions sci = new ScientificFunctions();
                    double result = sci.Pow(basenum, exponent);
                    textBox_result.Text = result.ToString("F4");
                }
                else
                {
                    textBox_result.Text = "입력 형식을 확인하세요";
                }
            }
        }

        private void button_sqrt_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                if (input < 0)
                {
                    textBox_result.Text = "음수는 불가";
                    return;
                }

                ScientificFunctions sci = new ScientificFunctions();
                double result = sci.Sqrt(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_log10_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                if (input <= 0)
                {
                    textBox_result.Text = "log는 0 이하 불가";
                    return;
                }

                ScientificFunctions sci = new ScientificFunctions();
                double result = sci.Log10(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_ln_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                if (input <= 0)
                {
                    textBox_result.Text = "log는 0 이하 불가";
                    return;
                }

                ScientificFunctions sci = new ScientificFunctions();
                double result = sci.Ln(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_result.Clear();
        }

        private void button_backspace_Click(object sender, EventArgs e)
        {
            if (textBox_result.Text.Length > 0)
            {
                textBox_result.Text = textBox_result.Text.Substring(0, textBox_result.Text.Length - 1);
            }
        }

        private void button_lbTog_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                UnitConverter converter = new UnitConverter();
                double result = converter.LbToG(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_gTolb_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                UnitConverter converter = new UnitConverter();
                double result = converter.GToLb(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_ozTog_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                UnitConverter converter = new UnitConverter();
                double result = converter.OzToG(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_gTooz_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                UnitConverter converter = new UnitConverter();
                double result = converter.GToLb(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_inchTom_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                UnitConverter converter = new UnitConverter();
                double result = converter.InchToM(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_mToinch_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                UnitConverter converter = new UnitConverter();
                double result = converter.MToInch(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_ftTom_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                UnitConverter converter = new UnitConverter();
                double result = converter.FtToM(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_mToft_Click(object sender, EventArgs e)
        {
            double input;
            if (double.TryParse(textBox_result.Text, out input))
            {
                UnitConverter converter = new UnitConverter();
                double result = converter.MToFt(input);
                textBox_result.Text = result.ToString("F4");
            }
            else
            {
                textBox_result.Text = "숫자를 입력해주세요.";
            }
        }

        private void button_spot_Click(object sender, EventArgs e)
        {
            textBox_result.Text += ".";
        }

        private void button_comma_Click(object sender, EventArgs e)
        {
            textBox_result.Text += ",";
        }

        private void button_equl_Click(object sender, EventArgs e)
        {
            // 텍스트 박스에서 x, y 값을 가져와 파싱
            string[] parts = textBox_result.Text.Split(new char[] { '+', '-', 'x', '/' });

            if (parts.Length != 2)
            {
                textBox_result.Text = "두 숫자를 입력하세요";
                return;
            }

            if (!double.TryParse(parts[0], out double x) || !double.TryParse(parts[1], out double y))
            {
                textBox_result.Text = "숫자 형식 오류";
                return;
            }

            // 연산자 추출
            char op = ' ';

            if (textBox_result.Text.Contains("+"))
                op = '+';
            else if (textBox_result.Text.Contains("-"))
                op = '-';
            else if (textBox_result.Text.Contains("x"))
                op = 'x';
            else if (textBox_result.Text.Contains("/"))
                op = '/';

            // FourBase 객체 생성 및 값 설정
            fourbase calc = new fourbase();
            calc.x = x;
            calc.y = y;
            calc.operation = op;

            // 계산 수행
            bool success = calc.Calculate();
            if (success)
            {
                textBox_result.Text = calc.result.ToString();
            }
            else
            {
                textBox_result.Text = "계산 오류";
            }

            // 계산 내역 저장
            Calculate_Project.additoinal_function.previousResult.LastAnswer = calc.result;

            // 타임스탬프 저장
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string resultText = textBox_result.Text;

            string timelog = $"{timestamp} 계산결과: {resultText} \r\n";
            textBox_timestamp.AppendText(timelog);

            // 유효 숫자 계산을 위한 저장
            Input1 = parts[0].Trim();
            Input2 = parts[1].Trim();
        }

        private void button_Ans_Click(object sender, EventArgs e)
        {
            double previousAnswer = Calculate_Project.additoinal_function.previousResult.LastAnswer;
            textBox_result.Text = previousAnswer.ToString();
        }

        private void button_sigfig_Click(object sender, EventArgs e)
        {
            string input1String = this.Input1;
            string input2String = this.Input2;
            string resultText = textBox_result.Text;
            if (!double.TryParse(resultText, out double currentResult))
            {
                MessageBox.Show("결과는 숫자이어야 합니다.");
                return;
            }

            string adjustedResult = sigfig.adjustsigfig(input1String, input2String, currentResult);
            textBox_result.Text = adjustedResult;
        }

        private void button_solve_Click(object sender, EventArgs e)
        {
            string input = textBox_result.Text.Trim();
            // 조합
            if (input.Contains("C"))
            {
                string[] part = input.Split(new char[] { 'C' });
                int n = int.Parse(part[0].Trim());
                int r = int.Parse(part[1].Trim());

                long result = combi.Combination(n, r);
                string outputText;
                if (result == -1)
                {
                    outputText = "조합 오류";
                }
                else
                {
                    outputText = $"{n}C{r} = {result}";
                }
                textBox_result.Text = outputText;
            }

            // 순열
            else if (input.Contains("P"))
            {
                string[] part2 = input.Split(new char[] { 'P' });
                int N = int.Parse(part2[0].Trim());
                int R = int.Parse(part2[1].Trim());
                long result2 = combi.Perm(N, R);
                string outputText2;
                if (result2 == -1)
                {
                    outputText2 = "순열 오류";
                }
                else
                {
                    outputText2 = $"{N}P{R} = {result2}";
                }
                textBox_result.Text = outputText2;
            }
        }

        private void button_pi_Click(object sender, EventArgs e)
        {
            Constants con = new Constants();
            textBox_result.Text = con.GetPi().ToString();
        }

        private void button_e_Click(object sender, EventArgs e)
        {
            Constants con = new Constants();
            textBox_result.Text = con.GetE().ToString("F6");
        }

        private void button_ABS_Click(object sender, EventArgs e)
        {
            double input = double.Parse(textBox_result.Text);
            double result = ABS.getvalue(input);
            textBox_result.Text = result.ToString();
        }

        private void button_round_Click(object sender, EventArgs e)
        {
            double input = double.Parse(textBox_result.Text);
            double result = Round.getvalue(input);
            textBox_result.Text = result.ToString();
        }
    }
}
