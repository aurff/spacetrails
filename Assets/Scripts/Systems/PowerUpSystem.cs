using UnityEngine;

public class PowerUpSystem : EgoSystem <EgoConstraint<Transform, PowerUpComponent, SpriteRenderer, CircleCollider2D>>
{
	public override void Start()
	{
		constraint.ForEachGameObject ((egoComponent, transfom, powerUpComponent, spriteRenderer, collider) => {
			powerUpComponent.powerUpTimerTimeElapsed = -1f;
			spriteRenderer.enabled = false;
			collider.enabled = false;
		});

		EgoEvents<GameStartEvent>.AddHandler (Handle);
		EgoEvents<OnActivatePowerUp>.AddHandler (Handle);
		EgoEvents<DamageEvent>.AddHandler (Handle);
	}

	public override void Update()
	{
		
	}

	public override void FixedUpdate()
	{
		constraint.ForEachGameObject ((egoComponent, transform, powerUpComponent, spriteRenderer, collider) => {
			if (powerUpComponent.powerUpTimerTimeElapsed != -1) {
				powerUpComponent.powerUpTimerTimeElapsed += Time.deltaTime;
			}

			if (powerUpComponent.powerUpTimerTimeElapsed >= powerUpComponent.powerUpTimer) 
			{
				spriteRenderer.enabled = true;
				collider.enabled = true;
				powerUpComponent.powerUpTimerTimeElapsed = -1;
			}
		});
	}

	void Handle (GameStartEvent e) {
		constraint.ForEachGameObject ((egoComponent, transform, powerUpComponent, spriteRenderer, collider) => {
			powerUpComponent.powerUpTimerTimeElapsed = 0;
		});
	}

	void Handle(OnActivatePowerUp e) {
		constraint.ForEachGameObject ((egoComponent, transform, powerUpComponent, spriteRenderer, collider) => {
			powerUpComponent.powerUpTimerTimeElapsed = 0f;
		});
	}

	void Handle(DamageEvent e) {
		constraint.ForEachGameObject ((egoComponent, transform, powerUpComponent, spriteRenderer, collider) => {
			powerUpComponent.powerUpTimerTimeElapsed = -1;
		});
	}

}