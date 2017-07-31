using UnityEngine;

[DisallowMultipleComponent]
public class MovementComponent : MonoBehaviour
{
	public float flySpeed = 2;
	//ublic Vector3 flySpeed = new Vector3(0, 0.05f, 0);
	public float curvspeed = 3;
	public enum FlyStatus {flying, notFlying};
	public FlyStatus myFlyStatus = FlyStatus.notFlying;
	public EKutiButton kutiInputLeft;
	public EKutiButton kutiInputRight;
	public KeyCode pcInputLeft;
	public KeyCode pcInputRight;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)
