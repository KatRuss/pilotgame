using UnityEngine;

public class BaloonBob : MonoBehaviour
{
    [SerializeField] float bobSpeed, bobDistance;
    Vector3 startPos;

    private void Start() {
        startPos = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        float sin = Mathf.Sin(Time.time * bobSpeed);
        float cos = Mathf.Cos(Time.time * bobSpeed/2);
        transform.position = new Vector3(
                            cos * bobDistance / 2 + startPos.x, 
                            sin * bobDistance     + startPos.y, 
                            cos * bobDistance / 3 + startPos.z
                            );
    }
}
