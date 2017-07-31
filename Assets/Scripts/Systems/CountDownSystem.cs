using UnityEngine;

public class CountDownSystem : EgoSystem<EgoConstraint<CountDownComponent>>
{
	public override void Start()
	{
		constraint.ForEachGameObject ((egoComponent, countDownComponent) => {
			Debug.Log("Countdown Start");
			countDownComponent.myCountDownStatus = CountDownComponent.CountDownStatus.inactive;
			egoComponent.gameObject.SetActive(false);
		});
		EgoEvents<CountDownEvent>.AddHandler (Handle);
	}

	public override void Update()
	{
		
	}

	public override void FixedUpdate()
	{
		constraint.ForEachGameObject ((egoComponent, countDownComponent) => {
			if (countDownComponent.myCountDownStatus == CountDownComponent.CountDownStatus.active) {
				egoComponent.gameObject.SetActive(true);
				countDownComponent.timeElapsed += Time.deltaTime;
				if (countDownComponent.timeElapsed >= 3) {
					countDownComponent.myCountDownStatus = CountDownComponent.CountDownStatus.inactive;
					egoComponent.gameObject.SetActive(false);
					var e = new GameStartEvent();
					EgoEvents<GameStartEvent>.AddEvent(e);
				}
			}
		});
	}

	void Handle(CountDownEvent e) {
		constraint.ForEachGameObject ((egoComponent, countDownComponent) => {
			countDownComponent.myCountDownStatus = CountDownComponent.CountDownStatus.active;
			countDownComponent.timeElapsed = 0;
			Time.timeScale = 1;
			egoComponent.gameObject.SetActive(true);
			Debug.Log("Countdown");
		});
	}
}