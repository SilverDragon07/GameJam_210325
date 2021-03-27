using UnityEngine;

public class Obi_Controller : MonoBehaviour
{
    bool inMoving = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            inMoving = true;
        }

        if (inMoving)
        {
            transform.Translate(-1, 0, 0);
        }
    }
}
