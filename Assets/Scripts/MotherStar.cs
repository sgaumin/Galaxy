using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherStar : MonoBehaviour
{
    public int maxHealth;
    public float moveSpeed;
    public float TimeToRespawn;
    public Transform followTarget;

    private Vector3 targetPos;
    private int currentHealth;
    private bool isKilled = false;

    // Use this for initialization
    public void Start()
    {
        currentHealth = maxHealth;
        StartCoroutine(CheckStatus());
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

    }

    private IEnumerator CheckStatus() {

        while (true)
        {
            if (currentHealth <= 0f)
            {
                if (!isKilled)
                {
                    gameObject.SetActive(false);
                    isKilled = true;
                    yield return new WaitForSeconds(TimeToRespawn);
                }
                else
                {
                    currentHealth = maxHealth;
                    gameObject.SetActive(true);
                    isKilled = false;
                    yield return new WaitForSeconds(1f);
                }
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void AddDamage(int damageToGive)
    {
        currentHealth -= damageToGive;
    }
}
