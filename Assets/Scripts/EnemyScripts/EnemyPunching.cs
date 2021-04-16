using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPunching : MonoBehaviour
{
    public int damadegModifier = 5;

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
        if(boxerGloves.activeInHierarchy == true)
        {
            punchingAnim.Play("ContinuosPunching");
        }
    }
}
