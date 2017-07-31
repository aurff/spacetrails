using UnityEngine;

public class AnimationSystem : EgoSystem<EgoConstraint<AnimationComponent, PlayerComponent, SpriteRenderer, CapsuleCollider2D, Rigidbody2D>>
{
	public override void Start()
	{
		EgoEvents<DamageEvent>.AddHandler (Handle);	
		EgoEvents<CountDownEvent>.AddHandler (Handle);
		EgoEvents<GameStartEvent>.AddHandler (Handle);
	}

	void Handle(DamageEvent e) {
		constraint.ForEachGameObject ((egoComponent, animation, player, spriteRenderer, collider, rb) => {
			if (e.playerID == player.playerID) {
				spriteRenderer.sprite = animation.explodingSprite;
				collider.enabled = false;
				rb.Sleep();
			}
		});
	}

	void Handle(CountDownEvent e) {
		constraint.ForEachGameObject ((egoComponent, animation, player, spriteRenderer, collider, rb) => {
			spriteRenderer.sprite = animation.normalSprite;
		});
	}

	void Handle(GameStartEvent e) {
		constraint.ForEachGameObject ((egoComponent, animation, player, spriteRenderer, collider, rb) => {
			collider.enabled = true;
			rb.IsAwake();
		});
	}
}