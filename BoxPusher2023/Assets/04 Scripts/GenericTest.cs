using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTest<T> : MonoBehaviour
{
    //public T Add<T>(T a, T b)
    //{
    //    dynamic x = a;
    //    dynamic y = b;
    //    return x + y ;
    //}
    //public T Subtract<T>(T a, T b)
    //{
    //    dynamic x = a;
    //    dynamic y = b;
    //    return x - y;
    //}
    // 클래스 이름 옆에 <T>가 있어서 아래 함수는 오류가 나지 않는다.
    // 클래스 이름 옆에 <T>를 두는 것은 클래스가 제네릭 클래스임을 나타내는 표시입니다.
    // 제네릭 클래스는 여러 다른 데이터 타입에 대해 작동할 수 있는 일반화된 클래스를 정의하는 데 사용됩니다. 
    //public T Divide(T a, T b) 
    //{
    //    dynamic x = a;
    //    dynamic y = b;
    //    return x / y;
    //}

    // dynamic은 C#에서 변수의 데이터 타입을 런타임 시에 동적으로 결정하는 키워드입니다.
    // 정적인 데이터 타입 대신 동적으로 타입이 결정되기 때문에 런타임에 유연한 타입 변환이 가능해집니다.
    // 위의 예제 코드에서 dynamic 키워드는 제네릭 함수 내에서 연산을 수행할 때 사용됩니다.
    // 이렇게 하면 제네릭 함수를 호출할 때마다 사용되는 데이터 타입에 따라 적절한 연산이 수행될 수 있습니다.
    // dynamic을 사용하면 컴파일러가 타입 체크를 하지 않고 런타임에 타입 체크를 수행하게 됩니다.
    // 따라서 잘못된 타입의 연산을 수행할 경우 런타임 에러가 발생할 수 있으므로 주의가 필요합니다.
}
