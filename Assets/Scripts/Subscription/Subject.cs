using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public abstract class Subject : MonoBehaviour
{

    private List<Observer> _observers = new List<Observer>();
    protected string subject_name;

    protected void AddObserver(Observer observer){
        _observers.Add(observer);
    }

    protected void RemoveObserver(Observer observer){
        _observers.Remove(observer);
    }

    protected void AddObserver(GameObject gameObject){
        if (gameObject.GetComponent<Observer>() != null)
            _observers.Add(gameObject.GetComponent<Observer>());
    }

    protected void RemoveObserver(GameObject gameObject){
        if (gameObject.GetComponent<Observer>() != null)
            _observers.Remove(gameObject.GetComponent<Observer>());
    }

    protected void RemoveObservers(){
        foreach(Observer observer in _observers)
            _observers.Remove(observer);
    }
    
    protected void NotifyObserver(bool isActive)
    {
        _observers.ForEach(_observer => {
            _observer.OnNotify(isActive, subject_name);
        });
    }

    protected void NotifySingleObserver(Observer observer, bool isActive)
    {
        observer.OnNotify(isActive, subject_name);
    }

    protected void NotifySingleObserver(GameObject gameObject, bool isActive)
    {
        if (gameObject.GetComponent<Observer>() != null)
            gameObject.GetComponent<Observer>().OnNotify(isActive, subject_name);
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

    protected void setSubjectName(string name){
        subject_name = name;
    }
}
