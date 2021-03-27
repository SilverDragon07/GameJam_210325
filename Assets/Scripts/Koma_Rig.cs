using UnityEngine;

public class Koma_Rig : MonoBehaviour
{
    Rigidbody thisRig = null;
    float reflectionMultiple = 30f;

    private void Start()
    {
        thisRig = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Koma"))
        {
            Vector3 thisVel = thisRig.velocity;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(thisVel*reflectionMultiple);
            thisRig.AddForce(thisVel * reflectionMultiple / 2);
            SoundController.Instance.PlaySE("KomaHit");
            Effect_Controller.Instance.Play_Effect((collision.transform.position + transform.position) / 2);
        }
        
    }
}
