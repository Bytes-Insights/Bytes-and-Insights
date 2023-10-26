using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{

    private List<Observer> _observers = new List<Observer>();

    protected void AddObserver(Observer observer){
        _observers.Add(observer);
    }

    protected void RemoveObserver(Observer observer){
        _observers.Remove(observer);
    }
    
    protected void NotifyObserver(bool isActive)
    {
        _observers.ForEach(_observer => {
            _observer.OnNotify(isActive);
        });
    }

    protected void StoreObserversWithTag(string Tag)
    {
        GameObject[] observers = GameObject.FindGameObjectsWithTag(Tag);
        
        foreach (var observer in observers)
        {
            // Check if the GameObject has a component of type 'Observer'
            if (observer.GetComponent<Observer>() != null)
            {
                AddObserver(observer.GetComponent<Observer>());
            }
        }

        Debug.Log(_observers.Count);

    }
}
