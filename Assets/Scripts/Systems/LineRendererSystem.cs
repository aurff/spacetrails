using UnityEngine;

public class LineRendererSystem : EgoSystem<EgoConstraint<Transform, LineRenderer, LineRendererComponent>>
{
	public override void Start()
	{
		constraint.ForEachGameObject ((egoComponent, transform, lineRenderer, lineRendererComponent) => {
			
		});

		EgoEvents<LineRendererDrawEvent>.AddHandler (Handle);
		EgoEvents<CountDownEvent>.AddHandler (Handle);
	}

	public override void Update()
	{
		
	}

	public override void FixedUpdate()
	{
		constraint.ForEachGameObject ((egoComponent, transform, lineRenderer, lineRendererComponent) => {
			lineRendererComponent.timeElapsed += Time.deltaTime;
			if (lineRendererComponent.lineRendererTimeThreshold <= lineRendererComponent.timeElapsed) {
				var e = new LineRendererDrawEvent();
				EgoEvents<LineRendererDrawEvent>.AddEvent(e);
				lineRendererComponent.timeElapsed -= lineRendererComponent.lineRendererTimeThreshold;
			}
		});
	}

	void Handle(LineRendererDrawEvent e) {
		constraint.ForEachGameObject((egoComponent, transform, lineRenderer, lineRendererComponent) => {

			//If lineRenderer reached lineLength, shift positions to delete first point in line
			if (lineRendererComponent.lineRendererPointCount >= lineRendererComponent.lineLength) {
				for (int i = 0; i < lineRendererComponent.lineLength - 1; i++) {
					lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
				}
			}
			else {
				lineRendererComponent.lineRendererPointCount++;
				lineRenderer.numPositions++;
			}

			//Add new point to LineRenderer
			lineRenderer.SetPosition(lineRendererComponent.lineRendererPointCount - 1, transform.position - (transform.up * 0.32f));
		});
	}

	void Handle(CountDownEvent e) {
		constraint.ForEachGameObject ((egoComponent, transform, lineRenderer, lineRendererComponent) => {
			lineRendererComponent.lineRendererPointCount = 0;
			lineRenderer.numPositions = 0;
			Debug.Log("LineRendererCountDown");
		});
	}
}