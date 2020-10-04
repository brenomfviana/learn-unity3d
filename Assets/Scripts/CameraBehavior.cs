using UnityEngine;
using Cinemachine;

public class CameraBehavior : MonoBehaviour
{
    // Player position
    public Transform player;
    // Stop to follow the player at position `ystop`
    public float ystop;

    // Update is called once per frame
    void Update()
    {
        CinemachineVirtualCamera vcam = GetComponent<CinemachineVirtualCamera>();
        if (player.position.y < ystop)
        {
            vcam.Follow = null;
        }
    }
}
