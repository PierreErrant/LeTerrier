using UnityEngine;
using UnityEngine.Video;

public class PlayStopVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    private bool _playing = false;

    public void DoPlayStopVideo()
    {
        _playing = !_playing;
        if (_playing) _videoPlayer.Play();
        else _videoPlayer.Stop();
    }
}


