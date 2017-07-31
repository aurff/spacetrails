using UnityEngine;

[DisallowMultipleComponent]
public class PlayerPowerUpComponent : MonoBehaviour
{
	public int playerID;
	public float playerPowerUpTimer;
	public EKutiButton powerUpButton;
	public KeyCode powerUpButtonPC;
	public bool powerUpActivated;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)
