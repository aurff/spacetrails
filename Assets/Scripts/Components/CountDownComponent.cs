using UnityEngine;

[DisallowMultipleComponent]
public class CountDownComponent : MonoBehaviour
{
	public float timeElapsed;
	public enum CountDownStatus {active, inactive};
	public CountDownStatus myCountDownStatus = CountDownStatus.inactive;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)
