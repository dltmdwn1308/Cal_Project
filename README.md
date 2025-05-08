## 단위 변환
### 1. 구현한 기능 소개
- 질량 변환
  - 파운드(lb) ➔ 그램(g)
  - 그램(g) ➔ 파운드(lb)
  - 온스(oz) ➔ 그램(g)
  - 그램(g) ➔ 온스(oz)
- 길이 변환
  - 인치(inch) ➔ 미터(m)
  - 미터(m) ➔ 인치(inch)
  - 피트(ft) ➔ 미터(m)
  - 미터(m) ➔ 피트(ft)
### 2. 설계 방법 및 사용한 기술 설명
- 초기 설계 구상
  - 단위 변환 계산기를 설계할 때, 처음에는 리스트(List) 또는 열거형(Enum)을 활용하여 단위 변환 계수를 저장하고, 사용자가 입력한 단위에 따라 적절한 환산 계수를 불러오는 방식을 고려했습니다.
  - 사용자가 입력한 단위를 인식하여 해당 단위에 맞는 환산 계수를 자동으로 매핑하는 구조를 설계했습니다.
- 문제점
  - 단위가 **"/"**로 나뉘거나 지수가 포함된 경우 단순 문자열 파싱으로는 구조를 제대로 인식하기 어려움
  - EX) "m/s"와 "ms"의 혼동
  - 
- 사용한 기술
  - 복잡한 매핑 구조 대신, 직관적으로 변환 로직을 단순화하여 단위별로 독립적인 함수 생성

### 3. 코드의 주요 부분 설명 (핵심 로직)
- 단위 변환은 단위 환산 계수를 곱하거나 나누는 간단한 수학 연산으로 구현
```
public double LbToG(double lb)
{
    return lb * 453.592;
}

public double GToLb(double g)
{
    return g / 453.592;
}
```
## 순열/조합
### 1. 구현한 기능 소개
- 조합 (Combination, nCr)
  - 주어진 n개의 원소 중 r개의 원소를 선택하는 경우의 수를 계산
  - 예시: 10C3 = 120
- 순열 (Permutation, nPr)
  - 주어진 n개의 원소에서 r개의 원소를 선택하고 순서를 고려하여 배열하는 경우의 수를 계산
  - 예시: 10P3 = 720
### 2. 설계 방법 및 사용한 기술 설명
- 재귀적 팩토리얼 계산 (Recursive Factorial Calculation)
  - 순열과 조합의 기본이 되는 팩토리얼 (Factorial) 함수를 구현
  - 팩토리얼 (Factorial) 함수를 통한 재귀 알고리즘으로 구현하였습니다.

### 3. 코드의 주요 부분 설명 (핵심 로직)
- 팩토리얼(Factorial)
```
public static long Factorial(int X)
        {
            if (X <= 1)
            {
                return 1;
            }
            return X * Factorial(X - 1);
        }
```
- 조합(Combination)
```
public static long Combination(int n, int r)
{
    if (r < 0 || r > n)
    {
        return -1;
    }
    return Factorial(n) / (Factorial(r) * Factorial(n - r));
}
```
- 순열(Permutation)
```
public static long Perm(int N, int R)
{
    if (R < 0 || R > N)
    {
        return -1;
    }
    return Factorial(N) / Factorial(N - R);
}
```
  
## 지수/로그 (지수)
### 1. 구현한 기능 소개
기본적인 단일 지수 계산을 처리할 수 있는 기능
- 단일 지수 계산
  - Math.Pow()를 이용하여 실수형 밑과 지수를 입력받아 계산
  - ex) 2^3 = 8, 2.5^4 = 39.0625
- 예외 처리
  - 잘못된 입력 형식에 대한 오류 메시지 출력
  - EX) "2^", "^3", "2^^3"
### 2. 설계 방법 및 사용한 기술 설명
- 초기 설계 구상
  - 다중 지수 (예:2^3^2)를 처리할 수 있는 구조로 설계
  -  2^3^2를 제대로 계산하려면 일반적인 왼쪽에서 오른쪽의 좌결합이 아닌, 오른쪽에서 왼쪽으로 결합하는 로직이 필요
    - 2^3^2는 **2^(3^2)**로 해석
  - 입력 문자열에서 가장 **오른쪽에 있는 "^"**를 찾아, 그 오른쪽 부분은 지수로, 왼쪽 부분은 밑으로 처리하는 방식 설계
- 문제점
  - 입력의 복잡성이 높을수록, 부분 문자열이 잘못 분리됨
  - ex)
    - 예상해야 하는 결과: 3^(2^(2^2)) = 3^16 = 43046721
    - 잘못된 결과: (3^2)^(2^2) = 9^4 = 6561
```
public static double ParseExponentIterative(string input)
{
    input = input.Trim();
    string[] parts = input.Split('^');
    double result = double.Parse(parts[^1]);

    for (int i = parts.Length - 2; i >= 0; i--)
    {
        result = Math.Pow(double.Parse(parts[i].Trim()), result);
    }

    return result;

}
```
- 의도한 동작
  - "2^3^2"의 경우, 3^2를 먼저 계산하고 그 결과를 2^9로 처리하려는 구조였습니다.
- 문제점
  - 제곱 연산은 오른쪽부터 결합하여 계산을 해야 하지만 반복문으로 이를 표현하기 어려움
- 재귀적 접근으로 전환
  - 문자열을 오른쪽에서 왼쪽으로 읽어가며 가장 깊은 지수부터 계산하는 재귀적 접근을 시도
```
public static double ParseExponentRecursive(string input)
{
    input = input.Trim();

    // 지수가 없는 경우
    if (!input.Contains("^"))
        return double.Parse(input);

    // 가장 오른쪽의 '^'를 기준으로 분리
    int lastIndex = input.LastIndexOf('^');
    string basePart = input.Substring(0, lastIndex).Trim();
    string exponentPart = input.Substring(lastIndex + 1).Trim();

    // 재귀적으로 오른쪽부터 계산
    double baseNum = ParseExponentRecursive(basePart);
    double exponent = double.Parse(exponentPart);

    return Math.Pow(baseNum, exponent);
}
```

### 3. 코드의 주요 부분 설명 (핵심 로직)
```
public double Pow(double x, double y)
{
    return Math.Pow(x, y);
}
```
## 타임스탬프
### 1. 구현한 기능 소개
- 계산을 실행할 때마다 현재 시간을 포함한 계산 결과를 기록하여 저장
- 각 계산 결과는 [{현재시간} 계산결과: {답}] 형식으로 출력
### 2. 설계 방법 및 사용한 기술 설명
- 설계 목표
  - 계산 결과가 도출될 때마다 현재 시간을 함께 기록하여, 결과를 나중에 다시 확인할 수 있도록 저장하는 기능 구현
- 구현 방법
  - 등호(equal) 버튼을 클릭할 때마다, 현재 시간을 DateTime.Now.ToString("HH:mm:ss") 형식으로 가져옵니다.
  - 문자열을 구성하여 textBox_timestamp에 누적해서 출력합니다.
- 사용 기술
  - DateTime.Now.ToString("HH:mm:ss"): 현재 시간 가져오기
  - AppendText(): 텍스트를 줄바꿈하여 누적 저장
### 3. 코드의 주요 부분 설명 (핵심 로직)
1. 현재 시간을 가져옴
```
string timestamp = DateTime.Now.ToString("HH:mm:ss");
```
2. 계산 결과를 저장
```
string resultText = textBox_result.Text;
```
3. 타임스탬프와 결과를 합쳐 문자열로 구성
```
string timelog = $"{timestamp} 계산결과: {resultText} \r\n";
```
4. textBox_timestamp에 문자열을 추가
```
textBox_timestamp.AppendText(timelog);
```
## 유효 숫자 계산 기능
### 1. 구현한 기능 소개
- 계산 결과의 신뢰할 수 있는 숫자 개수를 자동으로 계산하여 표시
- 계산 과정에서 0을 제외한 유효 숫자를 계산하여, 공학적 정확성을 보장
### 2. 설계 방법 및 사용한 기술 설명
- 설계 목표
  - 계산 결과의 신뢰성을 높이기 위해 유효 숫자를 계산하여 출력합니다.
  - 실수 계산 시 발생하는 부동소수점 오류를 방지하고, 공학 계산의 정확성을 보장하기 위해 설계했습니다.
- 구현 방법
  - 입력값에서 의미 없는 0과 소수점 뒤의 불필요한 0을 제거하여 유효 숫자를 계산합니다.
  - 입력값을 파싱하여 숫자 부분만 추출하고, Trim(), Replace() 등을 사용하여 최종 유효 숫자를 계산합니다.
- 사용 기술
  - Trim(), TrimStart(), TrimEnd(): 공백과 불필요한 문자 제거
  - Math.Min(): 두 입력값의 유효 숫자 중 최소값 선택
  - TryParse(): 숫자 여부 확인
### 3. 코드의 주요 부분 설명 (핵심 로직)
1. 입력값 파싱
```
Input1 = parts[0].Trim();
Input2 = parts[1].Trim();
```
2. 숫자 여부 확인
```
if (!double.TryParse(resultText, out double currentResult))
    return;
```
3. 유효 숫자 계산
```
input = input.TrimStart('-').TrimStart('0');
input = input.TrimEnd('0');
if (input.Contains("."))
    input = input.Replace(".", "");
return input.Length;
```
4. 결과 조정 후 출력
```
string adjustedResult = sigfig.adjustsigfig(input1String, input2String, currentResult);
textBox_result.Text = adjustedResult;
```
## 이전 계산 결과 기능
### 1. 구현한 기능 소개
- 계산을 연속해서 수행할 때, 이전 계산의 결과값을 활용
- 이전 결과를 저장하여 버튼 클릭 시 바로 출력할 수 있도록 구현
### 2. 설계 방법 및 사용한 기술 설명
- 설계 목표
  - 이전 계산 결과를 저장하여, 다음 계산 시 간단히 사용할 수 있도록 구현했습니다.
  - 사용자가 "ANS" 버튼을 클릭하면 마지막 계산 결과를 불러옵니다.
- 구현 방법
  - 계산 완료 시 LastAnswer라는 정적 변수를 통해 값을 저장합니다.
  - 이후 버튼 클릭 시 해당 변수를 불러와 textBox_result에 표시합니다.
- 사용 기술
  - get; set;: 프로퍼티를 사용하여 전역 상태로 관리
  - Static 변수: 어디서든 접근할 수 있도록 설정
### 3. 코드의 주요 부분 설명 (핵심 로직)
1. 계산 완료 시 결과 저장
```
Calculate_Project.additoinal_function.previousResult.LastAnswer = calc.result;
```
2. 이전 결과 호출
```
double previousAnswer = Calculate_Project.additoinal_function.previousResult.LastAnswer;
textBox_result.Text = previousAnswer.ToString();
```
3. LastAnswer를 전역 변수로 관리
```
public static class previousResult
{
    public static double LastAnswer { get; set; } = 0;
}
```

