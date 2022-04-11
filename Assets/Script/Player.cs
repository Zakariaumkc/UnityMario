using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool JumpKeyWasPressed;
    private float horizontalInput;
    private float VerticalInput;
    private Rigidbody rigidbodyComponent;
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    public static Player PlayerInstance { get; private set; }
    private bool BeginGame;
    public AudioSource hitSound;

    //private bool isGrounded;
    // Start is called before the first frame update
    public bool BeginGameSet
    {
        get { return BeginGame; }
        set
        {
            BeginGame = value;
        }
    }
    void Start()
    {
        PlayerInstance = this;
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BeginGame)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                JumpKeyWasPressed = true;
            }
            horizontalInput = Input.GetAxis("Horizontal");
            VerticalInput = Input.GetAxis("Vertical");
        }
    }
    private void FixedUpdate()
    {
        //if(!isGrounded)
        //{
        //    return;
        //}
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
        if (JumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            JumpKeyWasPressed = false;
        }
        if (rigidbodyComponent.velocity.y < -15)
        {
            Destroy(gameObject);
            // GameManager.Instance.SwitchState(GameManager.State.GameOver);
        }

        }
        //private void OnCollisionEnter()
        //{
        //    isGrounded = true;
        //}
        //private void OnCollisionExit()
        //{
        //    isGrounded = false;
        //}
        private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            GameManager.Instance.Score += 1;
            //hitSound = other.GetComponent<AudioSource>();
            //hitSound.Play();
            //SoundPlay sp = new SoundPlay();
            //sp.PlaySound(other);
            //hitSound = GameManager.Instance.ballPrefab.GetComponent<AudioSource>();
            //hitSound.Play();
            Destroy(other.gameObject);

        }
        if (other.gameObject.layer == 10)
        {
            GameManager.Instance.ExtraLifes += 1;
            //hitSound = other.GetComponent<AudioSource>();
            //hitSound.Play();
            //SoundPlay sp = new SoundPlay();
            //sp.PlaySound(other);
            //hitSound = GameManager.Instance.ballPrefab.GetComponent<AudioSource>();
            //hitSound.Play();
            Destroy(other.gameObject);

        }
        if(GameManager.Instance.Score == 10)
        {
            GameManager.Instance.SwitchState(GameManager.State.LevelCompleted);
            GameManager.Instance.Level += 1;
        }
    }
    //future implementation-->  count the score
}