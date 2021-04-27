using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 50;
    public HealthBar healthBar;
    

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {        
    //For debug purposes.
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        DamagePlayer(10);
    //    }
    //
}
    void OnTriggerEnter2D(Collider2D col)
    {
        while (col.gameObject.CompareTag("Hazard"))
        {
            DamagePlayer(10);
            if (curHealth < 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public void DamagePlayer(int damage)
    {

        curHealth -= damage;
        healthBar.SetHealth(curHealth);
        //death
        if (curHealth < 1)
        {
            //Debug.Log("Switch scene");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
