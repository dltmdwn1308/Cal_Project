## 단위 변환
### 1. 구현한 기능 소개
### 2. 설계 방법 및 사용한 기술 설명
### 3. 코드의 주요 부분 설명 (핵심 로직)
## 순열/조합
### 1. 구현한 기능 소개
### 2. 설계 방법 및 사용한 기술 설명
### 3. 코드의 주요 부분 설명 (핵심 로직)
## 지수/로그 (지수)
### 1. 구현한 기능 소개
기본적인 단일 지수 계산을 처리할 수 있는 기능
- 단일 지수 계산
  - Math.Pow()를 이용하여 실수형 밑과 지수를 입력받아 계산
  - ex) 2^3 = 8, 2.5^4 = 39.0625
- 에외 처리
  - 잘못된 입력 형식에 대한 오류 메시지 출력
  - ex) "2^", "^3", "2^^3"
### 2. 설계 방법 및 사용한 기술 설명
- 초기 시도 : 문자열을 뒤에서부터 읽는 반복문 접근
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
