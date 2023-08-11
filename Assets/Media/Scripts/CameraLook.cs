using UnityEngine;
using Cinemachine;
using AC;


[RequireComponent(typeof(CinemachineFreeLook))]

public class CameraLook : MonoBehaviour
{

    [SerializeField]
    private float lookSpeed = 1;

    private CinemachineFreeLook cinemachine;

    public SimpleTouchCameraController rotationControl;

    //private Controls playerInput;




    private void Awake()
    {
      //  playerInput = new Controls();

        cinemachine = GetComponent<CinemachineFreeLook>();
        //rotationControl = rotationControl.movementVector ;
    }


    

    void Update()
    {


        Vector2 delta = rotationControl.joysticValues;
        cinemachine.m_XAxis.Value += delta.x * 200 * lookSpeed * Time.deltaTime;
		cinemachine.m_YAxis.Value += delta.y * lookSpeed * Time.deltaTime;
    }

    
}
