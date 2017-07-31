using UnityEngine;


public class MovementSystem : EgoSystem<EgoConstraint<Transform, Rigidbody2D, MovementComponent, PlayerComponent>>
{
	public override void Start()
	{
		constraint.ForEachGameObject ((egoComponent, transform, rigidbody, movement, player) => {
			movement.myFlyStatus = MovementComponent.FlyStatus.notFlying;
		});

		EgoEvents<GameStartEvent>.AddHandler (Handle);
		EgoEvents<DamageEvent>.AddHandler (Handle);
		EgoEvents<CountDownEvent>.AddHandler (Handle);
	}

	public override void FixedUpdate()
	{
		constraint.ForEachGameObject ((egoComponent, transform, rigidbody, movement, player) => {
			if (movement.myFlyStatus == MovementComponent.FlyStatus.flying) {
				//Forward Movement
				rigidbody.MovePosition(transform.position + transform.up * Time.deltaTime * movement.flySpeed);

				//Rotate Left
				if (KutiInput.Instance.GetButtonDown(movement.kutiInputLeft) || Input.GetKey(movement.pcInputLeft)) {
					transform.Rotate((Vector3.back * -1) * movement.curvspeed, Space.Self);
				}

				//Rotate Right
				if (KutiInput.Instance.GetButtonDown(movement.kutiInputRight) || Input.GetKey(movement.pcInputRight)) {
					transform.Rotate(Vector3.back * movement.curvspeed, Space.Self);
				} 

			}
		});
	}

	void Handle(GameStartEvent e) {
		constraint.ForEachGameObject ((egoComponent, transform, rigidbody, movement, player) => {
			movement.myFlyStatus = MovementComponent.FlyStatus.flying;
		});
	}

	void Handle(DamageEvent e) {
		constraint.ForEachGameObject ((egoComponent, transform, rigidbody, movement, player) => {
			if (e.playerID == player.playerID) {
				movement.myFlyStatus = MovementComponent.FlyStatus.notFlying;
			}
		});
	}

	void Handle(CountDownEvent e) {
		constraint.ForEachGameObject ((egoComponent, transform, rigidbdy, movement, player) => {
			movement.myFlyStatus = MovementComponent.FlyStatus.notFlying;
		});
	}
}	