using UnityEngine;

public class Effect_Controller : SingletonMonoBehaviour<Effect_Controller>
{
    [SerializeField] GameObject hitEffect = null;

    public void Play_Effect(Vector3 position)
    {
        Instantiate(hitEffect, position, Quaternion.identity);
    }
}
