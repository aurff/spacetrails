using UnityEngine;

[DisallowMultipleComponent]
public class PlayerComponent : MonoBehaviour
{
	public int playerID;
	public Vector3 startPosition;
	public Vector3 startRotation;
	public float timeElapsed = 4;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)
