using UnityEngine;

[DisallowMultipleComponent]
public class PowerUpComponent : MonoBehaviour
{
	public float powerUpTimer;
	public float powerUpTimerTimeElapsed;
	public Vector3 powerUpPosition;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)
