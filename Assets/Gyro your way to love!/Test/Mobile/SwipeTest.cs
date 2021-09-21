using Gyro_your_way_to_love_.Mobile.Input;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SwipeTest : MonoBehaviour
{
	private LineRenderer lineRenderer;
	[SerializeField] private new Camera camera;

	// Start is called before the first frame update
	private void Start() => lineRenderer = gameObject.GetComponent<LineRenderer>();

	// Update is called once per frame
	private void Update()
	{
		if(MobileInputManager.Instance.swiping.SwipeCount > 0)
		{
			SwipeInputHandler.Swipe swipe = MobileInputManager.Instance.swiping.GetSwipe(0);
			lineRenderer.positionCount = swipe.positions.Count;

			int i = 0;
			foreach(Vector2 position in swipe.positions.ToArray())
			{
				lineRenderer.SetPosition(i++, camera.ScreenToWorldPoint(new Vector3(position.x, position.y, camera.nearClipPlane)));
			}
		}
		else
		{
			lineRenderer.positionCount = 0;
		}
	}
}