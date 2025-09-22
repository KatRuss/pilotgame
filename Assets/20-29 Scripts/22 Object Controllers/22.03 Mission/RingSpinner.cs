using UnityEngine;
using UnityEngine.UIElements;

public class RingSpinner : MonoBehaviour
{

    [SerializeField] float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.forward, rotateSpeed * Time.deltaTime);
    }
}
