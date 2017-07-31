using UnityEngine;

public class PlayerSystem : EgoSystem<EgoConstraint<Transform, PlayerComponent>>
{
	public override void Start()
	{
		EgoEvents<CountDownEvent>.AddHandler (Handle);
		EgoEvents<DamageEvent>.AddHandler (Handle);
		EgoEvents<GameOverEvent>.AddHandler (Handle);
		EgoEvents<GoToMenuEvent>.AddHandler (Handle);
	}

	public override void Update()
	{
		
	}

	public override void FixedUpdate()
	{
		constraint.ForEachGameObject ((egoComponent, transform, playerComponent) => {
			if (playerComponent.timeElapsed == -1) {

			}
			else if (playerComponent.timeElapsed >= 3) {
				var e = new CountDownEvent ();
				EgoEvents<CountDownEvent>.AddEvent(e);
				playerComponent.timeElapsed = -1;
			} else {
				playerComponent.timeElapsed += Time.deltaTime;
			}
		});
	}

	void Handle(CountDownEvent e) {
		constraint.ForEachGameObject((egoComponent, transform, playerComponent) => {
			transform.position = playerComponent.startPosition;
			transform.eulerAngles = playerComponent.startRotation;
		});
	}

	void Handle(DamageEvent e) {
		constraint.ForEachGameObject ((egoComponent, transform, playerComponent) => {
			if (playerComponent.playerID == 1) {
				playerComponent.timeElapsed = 0;
				Debug.Log("yes");
			}
		});
	}

	void Handle(GameOverEvent e) {
		constraint.ForEachGameObject ((egoComponent, transform, playerComponent) => {
			egoComponent.gameObject.SetActive (false);
		});
	}

	void Handle(GoToMenuEvent e) {
		constraint.ForEachGameObject ((egoComponent, transfor, playerComponent) => {
			egoComponent.gameObject.SetActive(true);
			playerComponent.timeElapsed = -1;
		});
	}
}