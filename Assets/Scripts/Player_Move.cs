using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Rigidbody thisRig = null;
    float forceMultiple = 40f;
    static bool inGame = false;

    private void Start()
    {
        thisRig = GetComponent<Rigidbody>();
    }



    void Update()
    {
        if (inGame)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            thisRig.AddForce(horizontal * forceMultiple, 0, vertical * forceMultiple);
        }


    }

    public static void StartGame()
    {
        inGame = true;
    }

    public static void EndGame()
    {
        inGame = false;
    }
}
