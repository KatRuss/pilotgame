using UnityEngine;

public class RingSpinner : MonoBehaviour
{

    [SerializeField] float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed*Time.deltaTime);
    }
}
