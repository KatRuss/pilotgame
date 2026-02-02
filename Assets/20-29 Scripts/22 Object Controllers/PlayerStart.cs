using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, new Vector3(transform.position.x,transform.position.y,transform.position.z + 10),Color.orange);       
    }
}
