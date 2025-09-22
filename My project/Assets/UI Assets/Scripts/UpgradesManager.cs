using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public UpgradeSO currentUpgrade;
    public Upgradesystem upgradeApply;
    public GameObject upgrade1;
    public GameObject upgrade2;
    public GameObject upgrade3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upgradeApply = gameObject.GetComponent<Upgradesystem>();
        FindUpgradeUI(-524, -66);
        FindUpgradeUI(0, -66);
        FindUpgradeUI(524, -66);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameObject.FindWithTag(upgradeApply.GetRandomUpgrade().GetTag()));
        //Debug.Log(upgradeApply.GetRandomUpgrade().ToString());
    }
    private void FindUpgradeUI(float x, float y)
    { 
        currentUpgrade = upgradeApply.GetRandomUpgrade();
        GameObject.FindWithTag(currentUpgrade.GetTag()).SetActive(true);
        GameObject.FindWithTag(currentUpgrade.GetTag()).transform.position = new Vector2(x, y);
    }
}
