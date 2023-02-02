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

        //triggerlarda lamba kendi alanýndaki arabalarý bilicek her lamba deðiþtiði zaman onlambchanged voidi caðýrýlacak
        //mesela kýrmýzýda hepsinin move statesi calýscak ve hepsine listindexi * distance vectorunu vericek ve herkes yerine gecicek

        if (!other.TryGetComponent(out CarBehaviour carBehaviour)) return;
        _trafficLamb.InRangeCars.Add(carBehaviour);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out CarBehaviour carBehaviour)) return;
        _trafficLamb.InRangeCars.Remove(carBehaviour);
    }
}