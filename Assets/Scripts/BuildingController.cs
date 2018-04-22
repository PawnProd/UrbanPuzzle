using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {

    // La liste des gains/pertes de ressources généré par la cellule
    public RessourcesGain ressources;

    public List<Conditions> cellConditions = new List<Conditions>();

    public GameObject floatingFeedback;

    private void Update()
    {
        if(floatingFeedback && floatingFeedback.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            floatingFeedback.SetActive(false);
        }
    }

}
