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
    public screenmanager manager;
    private bool collide = true;

    void Start()
    {
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

            swipe();
        }
    }
    void swipe()
    {
        Time.timeScale = 1f;
        Vector2 Swipe = endswipe - startswipe;
        rb.AddForce(Swipe * force, ForceMode.Impulse);
        rb.AddTorque(0f, 0f, torque, ForceMode.Impulse);
    }
    IEnumerator OnTriggerEnter(Collider other)
    {
        collide = true;
        yield return new WaitForSeconds(1f);
        if (collide && other.tag != "Untagged")
        {
            if (other.tag == "+1") { score.Scr++; Debug.Log("+1"); }
            if (other.tag == "+2") { score.Scr = score.Scr + 2; Debug.Log("+2"); }
            if (other.tag == "+3") { score.Scr = score.Scr + 3; Debug.Log("+3"); }
            Debug.Log(score.Scr.ToString());
            Time.timeScale = 0f;
            this.gameObject.SetActive(true);
            respawn(hat);
        }

    }
    IEnumerator OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.tag == "floor")
        {
            Debug.Log("floor hit");
            yield return new WaitForSeconds(1f);
            manager.scoreboard.SetActive(false);
            manager.Gameover.SetActive(true);
            score.Scr = 0;
            this.gameObject.SetActive(false);

        }

    }
    private void OnTriggerExit()
    {
        collide = false;
    }
    public static void respawn(Transform hat)
    {
        hat.position = new Vector3(-1.5f, 3.97f, -3.87f);
        hat.eulerAngles = new Vector3(-120f, 90f, 0f);
    }
}
