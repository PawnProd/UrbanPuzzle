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
        var fwd = Camera.main.transform.forward;
        fwd.y = 0.0f;
        floatingFeedback.transform.rotation = Quaternion.LookRotation(fwd);

        if (floatingFeedback && floatingFeedback.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            floatingFeedback.SetActive(false);
        }
    }

}
