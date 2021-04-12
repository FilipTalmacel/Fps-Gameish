using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowQuiver : MonoBehaviour
{
    public Text arrowNumber;

    public float maxArrows = 20f;
    public float currentArrows;

    public ReloadShooting reloadShooting;

    public Image isReloadeImage;
    

    // Start is called before the first frame update
    void Start()
    {
        currentArrows = maxArrows;
    }

    // Update is called once per frame
    void Update()
    {
        currentArrows = maxArrows - reloadShooting.arrowsShot;
        arrowNumber.text = (currentArrows).ToString();
        if (currentArrows <= 0 && !reloadShooting.isReloaded) reloadShooting.enabled = false;
        else reloadShooting.enabled = true;

        if (reloadShooting.isReloaded) isReloadeImage.enabled = true;
        else isReloadeImage.enabled = false;
    }
}
