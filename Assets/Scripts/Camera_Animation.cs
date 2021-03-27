using UnityEngine;

public class Camera_Animation : SingletonMonoBehaviour<Camera_Animation>
{
    int cameraState = -1;
    [SerializeField] GameObject playerObject = null;
    [SerializeField] Vector3 moveVec;
    [SerializeField] Vector3 rotateVec;
    int frameCount = 0;


    private void FixedUpdate()
    {
        switch (cameraState)
        {
            case 0:
                transform.Translate(moveVec / 50, Space.World);
                transform.Rotate(rotateVec / 50, Space.World);
                frameCount += 1;
                if(frameCount >= 50)
                {
                    cameraState = -1;
                }
                break;
            case 1:
                transform.Translate(moveVec / 30, Space.World);
                transform.Rotate(rotateVec / 30, Space.World);
                frameCount += 1;
                if (frameCount >= 30)
                {
                    cameraState = -1;
                    GameManager.Instance.StartGame();
                    Camera_Chase.Instance.Start_Chase();
                }
                break;

        }
    }


    public void SetCameraState(int stateNum)
    {
        frameCount = 0;
        cameraState = stateNum;
        Vector3 diff = playerObject.transform.position - transform.position;
        Vector3 targetAngle;
        Vector3 nowAngle;
        switch (stateNum)
        {
            case 0:
                diff.z -= 2;
                diff.y += 1;
                moveVec = diff;
                targetAngle = new Vector3(0, 0, 0);
                nowAngle = transform.eulerAngles;
                rotateVec = targetAngle - nowAngle;
                break;
            case 1:
                diff.y += 15;
                moveVec = diff;
                targetAngle = new Vector3(90, 0, 0);
                nowAngle = transform.eulerAngles;
                rotateVec = targetAngle - nowAngle;
                break;
                

        }
    }
}
