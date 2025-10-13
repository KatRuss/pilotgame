using UnityEngine;
using UnityEngine.UIElements;

public class IslandSpinner : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 5 * Time.deltaTime, 0);
    }
}
