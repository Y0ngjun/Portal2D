// 트리거들의 다형성을 위한 부모 클래스
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    public abstract bool IsActive { get; }
}
