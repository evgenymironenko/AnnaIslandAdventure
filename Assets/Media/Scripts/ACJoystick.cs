using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACJoystick : MonoBehaviour
{

    public SimpleTouchController moveController;


	private float CustomGetAxis(string axisName)
	{
		if (axisName == "Horizontal")
		{
			return moveController.GetTouchPosition.x;
		}
		if (axisName == "Vertical")
		{
			return moveController.GetTouchPosition.y;
		}
		try
		{
			return Input.GetAxis(axisName);
		}
		catch
		{
			return 0f;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		AC.KickStarter.playerInput.InputGetAxisDelegate = CustomGetAxis;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
