using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    public ExplanationController explanation;

    private bool beamformingExplained;
    private bool sitesExplained;
    private bool FiveGExplained;
    private bool FourGExplained;

    private void Start()
    {
        ExplainSites();
    }

    public void ExplainBeamforming()
    {
        beamformingExplained = true;
        explanation.ShowExplanation("Beamforming", "When a site and a device connect, they undergo a process called beamforming, which focuses the signal into a specific direction.");
    }

    public bool WasBeamformingExplained()
    {
        return beamformingExplained;
    }

    public void ExplainSites()
    {
        sitesExplained = true;
        explanation.ShowExplanation("Sites", "Places where technological equipment, such as antennas and radios, are located, are called 'sites'.");
    }

    public bool WereSitesExplained()
    {
        return sitesExplained;
    }

    public void Explain5G()
    {
        FiveGExplained = true;
        explanation.ShowExplanation("5G Connection", "5G is a super-fast and advanced wireless technology that lets us connect to the internet, stream videos, play games, and download stuff on our phones and devices much quicker than before.");
    }

    public bool Was5GExplained()
    {
        return FiveGExplained;
    }

    
    public void Explain4G()
    {
        FourGExplained = true;
        explanation.ShowExplanation("4G Connection", "4G is a fast wireless technology that allows us to use our phones and devices for internet, streaming, gaming, and downloading. It's not as fast as 5G, but it's still much faster than older networks like 3G.");
    }

    public bool Was4GExplained()
    {
        return FourGExplained;
    }
}
