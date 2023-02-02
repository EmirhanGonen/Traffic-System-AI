using UnityEngine;

public class LambCollisionDetect : MonoBehaviour
{
    private TrafficLamb _trafficLamb;

    private void Awake()
    {
        _trafficLamb = GetComponentInParent<TrafficLamb>();
    }

    private void OnTriggerEnter(Collider other)
    {

        //triggerlarda lamba kendi alan�ndaki arabalar� bilicek her lamba de�i�ti�i zaman onlambchanged voidi ca��r�lacak
        //mesela k�rm�z�da hepsinin move statesi cal�scak ve hepsine listindexi * distance vectorunu vericek ve herkes yerine gecicek

        if (!other.TryGetComponent(out CarBehaviour carBehaviour)) return;
        _trafficLamb.InRangeCars.Add(carBehaviour);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out CarBehaviour carBehaviour)) return;
        _trafficLamb.InRangeCars.Remove(carBehaviour);
    }
}