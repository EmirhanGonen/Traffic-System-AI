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

        //triggerlarda lamba kendi alanındaki arabaları bilicek her lamba değiştiği zaman onlambchanged voidi cağırılacak
        //mesela kırmızıda hepsinin move statesi calıscak ve hepsine listindexi * distance vectorunu vericek ve herkes yerine gecicek

        if (!other.TryGetComponent(out CarBehaviour carBehaviour)) return;
        _trafficLamb.InRangeCars.Add(carBehaviour);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out CarBehaviour carBehaviour)) return;
        _trafficLamb.InRangeCars.Remove(carBehaviour);
    }
}