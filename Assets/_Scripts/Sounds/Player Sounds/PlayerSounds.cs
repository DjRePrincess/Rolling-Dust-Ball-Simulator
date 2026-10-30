using UnityEngine;
using UnityEngine.Windows;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource rockSlidingSource;
    private MyInput myInput;

    private void Start()
    {
        rockSlidingSource = GetComponent<AudioSource>();
        rockSlidingSource.Play();
    }


    void Update()
    {
        bool playerLeftClickHold = myInput.Player.Move.IsPressed();

        if (playerLeftClickHold)
        {
            print("rock sound playing");
            if (rockSlidingSource.isPlaying)
            {
                return;
            }
            rockSlidingSource.Play();
        }
        else
        {
            rockSlidingSource.Stop();
        }
    }

    // ----------
    // Input instantiation 

    private void Awake()
    {
        myInput = new MyInput();
    }

    private void OnEnable()
    {
        myInput.Enable();
    }

    private void OnDisable()
    {
        myInput.Disable();
    }
}
