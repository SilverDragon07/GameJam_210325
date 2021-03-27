using UnityEngine;

public class Startbutton : MonoBehaviour
{
    [SerializeField] GameObject[] inactiveObjects = null;


    public void OnClick()
    {
        Camera_Animation.Instance.SetCameraState(0);

        foreach (GameObject obj in this.inactiveObjects)
        {
            obj.SetActive(false);
        }
    }
}
