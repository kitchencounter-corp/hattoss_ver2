using System.Collections;

using UnityEngine;

public class toss : MonoBehaviour
{
    public static Rigidbody rb;
    private Transform hat;
    private Vector2 startswipe;
    private Vector2 endswipe;
    public float force = 5f;
    public float torque = 5f;
    private float magnitude;
    public screenmanager manager;
    private bool collidecheck = true;
    private float airtime;
    private bool swiped = true;
    private bool deadzone = false;

    void Start()
    {
        // Application.targetFrameRate = 60;
      //  ScreenCapture.CaptureScreenshot("test.png");
        rb = GetComponent<Rigidbody>();
        hat = GetComponent<Transform>();
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startswipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        }

        if (Input.GetMouseButtonUp(0))
        {
            endswipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            magnitude = (endswipe - startswipe).magnitude;
            Debug.Log(magnitude);
            if (magnitude > 0.01f && swiped)
            {
                deadzone = true;
                swiped = false;
                airtime = Time.time;
                swipe();
            }
        }
      
            if (Time.time - airtime > 2.5f && deadzone)
            {
                airtime = Time.time;
                Restart();
            }
        
    }
    void swipe()
    {
        Time.timeScale = 1f;
        Vector2 Swipe = endswipe - startswipe;
        rb.AddForce(Swipe * force, ForceMode.Impulse);
        rb.AddTorque(0f, 0f, 1f, ForceMode.Impulse);
      //  Debug.Log(torque * magnitude * 100);
    }
    IEnumerator OnTriggerEnter(Collider other)
    {
      //  Debug.Log("dính");
        collidecheck = true;
        Debug.Log(other.gameObject.tag);
        Debug.Log(collidecheck);
        if (other.tag == "+1") { rb.velocity = Vector3.zero; }
        if (other.tag == "+2") { rb.velocity = Vector3.zero; }
        if (other.tag == "+3") { rb.velocity = Vector3.zero; }
        rb.velocity = Vector3.zero;
        deadzone = false;
        yield return new WaitForSeconds(1f);
        if (collidecheck && other.tag != "Untagged")
        {
            if (other.tag == "+1") { score.Scr++; Debug.Log("cong1"); }
            if (other.tag == "+2") { score.Scr = score.Scr + 2; Debug.Log("cong2"); }
            if (other.tag == "+3") { score.Scr = score.Scr + 3; Debug.Log("cong3"); }
            //rb.velocity = Vector3.zero;
            Debug.Log(score.Scr.ToString());
            Time.timeScale = 0f;
            this.gameObject.SetActive(false);
           this.gameObject.SetActive(true);
            respawn(hat);
            swiped = true;
            rb.velocity = Vector3.zero;
        }

    }
    
    IEnumerator OnCollisionEnter(Collision collide)
    {
       // Vector3 vec = new Vector3(1, 1);
      
        if (collide.gameObject.tag == "floor")
        {
            
           yield return new WaitForSeconds(1f);
            Restart();
           
           
        } else
        {

            rb.velocity = Vector3.zero;
        }
       
    }
    void Restart()
    {
        manager.Gameover.SetActive(true);
        score.Scr = 0;
        this.gameObject.SetActive(false);
        swiped = true;
        deadzone = false;
        rb.velocity = Vector3.zero;
    }
    private void OnTriggerExit()
    {
        collidecheck = false;
        
    }
    public static void respawn(Transform hat)
    {
        hat.position = new Vector3(-1.5f, 3.3f, -4.29f);
        hat.eulerAngles = new Vector3(-120f, 90f, 0f);
        
    }
}
