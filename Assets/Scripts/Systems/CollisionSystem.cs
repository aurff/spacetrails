using UnityEngine;

public class CollisionSystem : EgoSystem<EgoConstraint<SpriteRenderer, CollisionComponent, LineRendererComponent, MovementComponent, PlayerComponent>>
{
	public override void Start()
	{
		EgoEvents<CollisionEnter2DEvent>.AddHandler (Handle);
	}

	public override void Update()
	{
		
	}

	public override void FixedUpdate()
	{
		//CHeck for overlapping points with SpceTrail
		constraint.ForEachGameObject ((egoComponent, spriteRenderer, collisionComponent, lineRenderer, movement, player) => {
			
			if (movement.myFlyStatus == MovementComponent.FlyStatus.flying) {
				constraint.ForEachGameObject ((egoComponent2, spriteRenderer2, collisionComponent2, lineRenderer2, movement2, player2) => {
					if (player.playerID != player2.playerID) {
						Collider2D[] hits = new Collider2D[1];
						//check lineRenderer for overlapping points
						for (int i = 0; i < lineRenderer2.lineRendererPointCount; i++) {
							bool b = false;
							Physics2D.OverlapPointNonAlloc (lineRenderer2.gameObject.GetComponent<LineRenderer> ().GetPosition (i), hits, 1);
							foreach (Collider2D coll in hits) {
								if (coll != null && movement2.myFlyStatus == MovementComponent.FlyStatus.flying) {
									string collTag;
									if (player2.playerID == 1) {
										collTag = "Player2";
									} else if (player2.playerID == 2) {
										collTag = "Player";
									} else {
										collTag = "none";
									}

									if (coll.tag == collTag) {
										DamageEvent e = new DamageEvent (player.playerID, true);
										Debug.Log("Damage Event called cause line renderer overlap for player " + player.playerID);
										EgoEvents<DamageEvent>.AddEvent (e);
										EgoEvents<DamageEvent>.AddEvent (e); //cause hacking skills are true
										b = true;
										break;
									}
								}
							}
							if (b) {
								break;
							}
						}
					}
				});

			}
		});
	}

	void Handle(CollisionEnter2DEvent e) {
		Debug.Log ("Enter Collision Event");
		constraint.ForEachGameObject ((egoComponent, spriteRenderer, collisionComponent, lineRenderer, movement, player) => {
			SpriteRenderer shipSprite;
			PlayerComponent playerC;
			//Return if colliding Object has no SpriteRenderer
			if (!e.egoComponent1.TryGetComponents(out shipSprite)) {
				return;
			}
			//Else change Sprite to Explosion, if you collided with a spaceship
			else if (e.egoComponent2.TryGetComponents(out playerC) && e.egoComponent1.TryGetComponents(out playerC)) {
				//e.egoComponent1.GetComponent<SpriteRenderer>().sprite = collisionComponent.explodingSprite;
				if (e.egoComponent1.GetComponent<MovementComponent>().myFlyStatus == MovementComponent.FlyStatus.flying &&
					e.egoComponent2.GetComponent<MovementComponent>().myFlyStatus == MovementComponent.FlyStatus.flying) {
					var ev = new DamageEvent(player.playerID, false);
					Debug.Log("Damage Event called cause players collided");
					EgoEvents<DamageEvent>.AddEvent(ev);
				}

				//Unschön, vielleicht geht das ja auch aus dem DamageEvent heraus?
				/*MovementComponent movementComponent;
				if (!e.egoComponent1.TryGetComponents(out movementComponent)) {
					return;
				}
				else {
					movementComponent.myFlyStatus = MovementComponent.FlyStatus.notFlying;
				}*/
			}

			PowerUpComponent powerup;
			if (!e.egoComponent2.TryGetComponents(out powerup)) {
				return;
			}
			else if (e.egoComponent2.TryGetComponents(out powerup)) {
				Debug.Log("powerup collected");
				Ego.AddComponent<HasSpeedUpComponent>(e.egoComponent1);
				e.egoComponent1.GetComponent<PlayerPowerUpComponent>().playerPowerUpTimer = 0;
				//e.egoComponent2.gameObject.SetActive(false);
				e.egoComponent2.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				e.egoComponent2.gameObject.GetComponent<CircleCollider2D>().enabled = false;
				var ev = new OnSpeedUpPickUp(e.egoComponent1.GetComponent<PlayerComponent>().playerID);
				EgoEvents<OnSpeedUpPickUp>.AddEvent(ev);
			}
		});
	}
}