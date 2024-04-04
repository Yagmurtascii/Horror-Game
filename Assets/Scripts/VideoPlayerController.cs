using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] private CrossHairController crossHairController;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private AudioSource audio;
    private bool isRemoteOpen = false;
    private float dif;
    public void Update()
    {
        dif = Vector3.Distance(gameObject.transform.position, crossHairController.transform.position);

        if (Mathf.Abs(dif) < 80f && Mathf.Abs(dif) > 10)
        {
            if (crossHairController.isRemoteController && Input.GetKeyDown(KeyCode.Mouse1) && !isRemoteOpen)
            {
                videoPlayer.enabled = true;
                isRemoteOpen = true;
                audio.Play();
            }
            else if (isRemoteOpen && Input.GetKeyDown(KeyCode.Mouse1))
            {
                videoPlayer.enabled = false;
                isRemoteOpen = false;
                audio.Stop();
            }
        }
    }
}