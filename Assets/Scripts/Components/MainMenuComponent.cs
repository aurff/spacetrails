using UnityEngine;

[DisallowMultipleComponent]
public class MainMenuComponent : MonoBehaviour
{
	public enum MenuStatus {active, inactive};
	public MenuStatus myMenuStatus = MenuStatus.active;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)
