using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {

    // La liste des gains/pertes de ressources généré par la cellule
    public RessourcesGain ressources;

    public List<Conditions> cellConditions = new List<Conditions>();

}
