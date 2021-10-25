using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;
    public GameObject Coin;
    public GameObject Enemy;
    public TextMeshProUGUI LivesText;
    public GameObject loseText;
    private int livesValue = 3;
    private int scoreValue = 0;
    private bool facingRight = true;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        SetScoreText();
        SetLivesText();
        loseText.SetActive(false);
        winTextObject.SetActive(false); 
        anim = GetComponent<Animator>();
        musicSource.clip = musicClipOne;
        musicSource.Play();
        musicSource.loop = false;
    }
    
    void SetLivesText()
    {
        if(livesValue <= 0)
        {
            winTextObject.SetActive(false);
        }
        if (livesValue <=0)
        {
           loseText.SetActive(true);
        }
    }

    void SetScoreText()
    {
        if(scoreValue == 8)
        {
        winTextObject.SetActive(true);
        }
    }
    
    
    // Update is called once per frame
    
    
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            scoreText.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }
          if(scoreValue == 4)
        {
            livesValue = 3; 
            LivesText.text = "3";
        transform.position = new Vector3(59.0f, 2.25f, 0.0f);
        }

        if(scoreValue >=8)
        {
            winTextObject.SetActive(true);
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            rd2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        

         if(livesValue == 0)
        {
            gameObject.SetActive(false);
            winTextObject.SetActive(false);
            loseText.SetActive(true);
        }
    
        else if (collision.collider.tag == "Enemy")
        {
            livesValue -= 1;
            LivesText.text = livesValue.ToString();
            Destroy(collision.collider.gameObject);
        }

    }

private void OnCollisionStay2D(Collision2D collision)
     {
if (collision.collider.tag == "Ground")
{
if (Input.GetKey(KeyCode.W))
{
rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
}

}
}


    void Update()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {  
            anim.SetInteger("State", 2);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("State", 2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State", 2);
        }
    }

    void Flip()
    {
        facingRight =!facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
    
}

