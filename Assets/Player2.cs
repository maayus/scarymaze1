using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 10;
    public SpriteRenderer sprite;


    void Update()
    {
        float inputx = Input.GetAxis("Horizontal");
        float inputy = Input.GetAxis("Vertical");

        if (inputx != 0 || inputy != 0)
        {
            transform.position += new Vector3(speed * inputx * Time.deltaTime, speed * inputy * Time.deltaTime, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {

            sprite.enabled = true;
            GetComponent<AudioSource>().Play();
            StartCoroutine(SomeCoroutine());
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    private IEnumerator SomeCoroutine()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
