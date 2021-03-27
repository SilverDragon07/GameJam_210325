using UnityEngine;

public class Koma_Rotate : MonoBehaviour
{
    static bool inRotate = false;
    void Update()
    {
        if (inRotate)
            transform.Rotate(0, 44, 0);
    }


    public static void StartRotate()
    {
        inRotate = true;
    }

    public static void EndRotate()
    {
        inRotate = false;
    }
}
