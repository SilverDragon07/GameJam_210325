using UnityEngine;

public class Camera_Chase : SingletonMonoBehaviour<Camera_Chase>
{
    [SerializeField] GameObject playerObject = null;
    bool in_chase = false;
    Vector3 offset = new Vector3(0, 15, 0);

    private void Update()
    {
        if (in_chase)
        {
            transform.position = Vector3.Lerp(transform.position, playerObject.transform.position + offset, 0.1f);
        }
    }

    public void Start_Chase()
    {
        this.in_chase = true;
    }
}
