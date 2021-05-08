using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public InputHandler inputHandler;

    public GameObject attackGFX;

    public Transform attackPos;
    public float attackSize = 0.5f;

    public LayerMask enemiesLayer;

    bool check;

    void Update()
    {      
        if(inputHandler.clicked)
        {
            inputHandler.clicked = false;
            Attack();
        }
    }

    void Attack()
    {
        StartCoroutine(ShowHideGameObject(attackGFX, 0.2f));
        Debug.Log("Attack");

        Collider[] colliders = Physics.OverlapSphere(attackPos.position, attackSize, enemiesLayer);
        foreach (Collider col in colliders)
        {
            //Deal damage
        }
    }

    IEnumerator ShowHideGameObject(GameObject gameObject, float time)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    


}
