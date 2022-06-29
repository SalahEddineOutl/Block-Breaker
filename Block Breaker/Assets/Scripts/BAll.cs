
using UnityEngine;

public class BAll : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    Vector2 PaddleToBall;
    [SerializeField] float VelocityX = 1f;[SerializeField] float VelocityY = 2f;
    bool HasStarted = false;
    [SerializeField] AudioClip[] ballsounds;
    [SerializeField] float randomFactor = 0.5f;

    AudioSource MyAudio;
    Rigidbody2D Myrigidbody2D;

    void Start()
    {
        PaddleToBall = transform.position - paddle1.transform.position;
        MyAudio = GetComponent<AudioSource>();
        Myrigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (HasStarted == false) 
        {
            LockPaddleToBall();
            LunchOnclick();
        }
        

    }

    private void LunchOnclick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HasStarted = true;
            Myrigidbody2D.velocity = new Vector2(VelocityX, VelocityY);
        }
    }

    private void LockPaddleToBall()
    {
        Vector2 PaddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = PaddlePos + PaddleToBall;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityWeek = new Vector2(UnityEngine.Random.Range(0, randomFactor), UnityEngine.Random.Range(0, randomFactor));
        if (HasStarted)
        {
            AudioClip clip = ballsounds[UnityEngine.Random.Range(0, ballsounds.Length)];
            MyAudio.PlayOneShot(clip);
            Myrigidbody2D.velocity += velocityWeek;
        }
    }
}
