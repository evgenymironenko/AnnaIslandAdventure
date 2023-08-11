using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Cinemachine;


public class SimpleTouchCameraController : MonoBehaviour {

	// PUBLIC
	public delegate void TouchDelegate(Vector2 value);
	public event TouchDelegate TouchEvent;

	public delegate void TouchStateDelegate(bool touchPresent);
	public event TouchStateDelegate TouchStateEvent;

	// PRIVATE
	[SerializeField]
	private RectTransform joystickArea;
	private bool touchPresent = false;
	public Vector2 movementVector;
	public Vector2 joysticValues;



	public Vector2 GetTouchPosition
	{
		get { return movementVector;}
	}


	public void BeginDrag()
	{
		touchPresent = true;
		if(TouchStateEvent != null)
			TouchStateEvent(touchPresent);
	}

	public void EndDrag()
	{
		touchPresent = false;
		movementVector = joystickArea.anchoredPosition = Vector2.zero;
		joysticValues = movementVector;

		if (TouchStateEvent != null)
			TouchStateEvent(touchPresent);
			

	}

	public void OnValueChanged(Vector2 value)
	{
		if(touchPresent)
		{
			// convert the value between 1 0 to -1 +1
			movementVector.x = ((1 - value.x) - 0.5f) * 2f;
			movementVector.y = ((1 - value.y) - 0.5f) * 2f;

			joysticValues.x = movementVector.x;
			joysticValues.y = movementVector.y;

			if (TouchEvent != null)
			{
				TouchEvent(movementVector);
				joysticValues = movementVector;

			}
		}

	}

	


}
