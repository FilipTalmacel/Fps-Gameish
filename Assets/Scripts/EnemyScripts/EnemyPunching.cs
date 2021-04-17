using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPunching : MonoBehaviour
{
    public int damadegModifier;
    float waitTime = 3f;
    int animationPercentage;

    public GameObject boxerGloves;

    public EnemyMovement enemyMovement;

    public Animation punchingAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if(waitTime <= 0)
        {
            animationPercentage = Random.Range(0, 6);
            waitTime = 3f;
        }
        
        if (animationPercentage <= 3 && boxerGloves.activeInHierarchy == true)
        {
            punchingAnim.CrossFade("ContinuosPunching");
            damadegModifier = 5;
        }
        else if (animationPercentage >= 4 && boxerGloves.activeInHierarchy == true)
        {
            punchingAnim.CrossFade("Smash");
            damadegModifier = 35;
        }
        Debug.Log(animationPercentage);
    }
}
