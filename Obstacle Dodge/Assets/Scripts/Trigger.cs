using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] GameObject projectileOne;
    [SerializeField] GameObject projectileTwo;
    [SerializeField] GameObject projectileThree;
    [SerializeField] GameObject projectileFour;
    [SerializeField] GameObject projectileFive;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            projectileOne.SetActive(true);
            projectileTwo.SetActive(true);
            projectileThree.SetActive(true);
            projectileFour.SetActive(true);
            projectileFive.SetActive(true);
            Destroy(gameObject);
        }
    }
}
