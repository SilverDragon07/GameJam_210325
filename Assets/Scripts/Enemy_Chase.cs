using System.Threading.Tasks;
using UnityEngine;

public class Enemy_Chase : MonoBehaviour
{
    static GameObject targetPlayer = null;
    static Vector3 targetPlayerPosition = new Vector3();
    Rigidbody thisRig = null;
    float moveVecMultiple = 3f;
    float moveVecLimit = 4f;

    private void Start()
    {
        thisRig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 thisPosition = transform.position;
        Vector3 moveVector = targetPlayerPosition - thisPosition;
        moveVector = new Vector3(moveVector.x*moveVecMultiple, 0, moveVector.z*moveVecMultiple);

        thisRig.AddForce(moveVector);
        //MoveVecLimitCheck();
    }


    private void MoveVecLimitCheck()
    {
        Vector3 mag = thisRig.velocity;
        if (mag.x > moveVecLimit)
            mag.x = moveVecLimit;
        else if (mag.x < -moveVecLimit)
            mag.x = -moveVecLimit;
        if (mag.z > moveVecLimit)
            mag.z = moveVecLimit;
        else if (mag.z < -moveVecLimit)
            mag.z = -moveVecLimit;
        thisRig.velocity = mag;
    }


    public static void SetTargetPlayer(GameObject obj)
    {
        targetPlayer = obj;
        Enemy_Chase.PlayerPositionUpdate();
    }

    async static void PlayerPositionUpdate()
    {
        while (Application.isPlaying)
        {
            targetPlayerPosition = targetPlayer.transform.position;
            await Task.Delay(16);
        }
    }
}
