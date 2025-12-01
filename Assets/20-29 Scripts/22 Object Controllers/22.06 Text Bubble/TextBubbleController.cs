using UnityEngine;

public class TextBubbleController : MonoBehaviour
{

    [SerializeField] LiveData liveData;
    [SerializeField] string textTitle;
    [SerializeField][TextArea(2, 2)] string message;

    void OnTriggerEnter(Collider other)
    {
        liveData.headerToShow = textTitle;
        liveData.messageToShow = message;

        Destroy(gameObject);
    }

}
