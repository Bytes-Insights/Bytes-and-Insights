using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    public ExplanationController explanation;

    private bool beamformingExplained;
    private bool sitesExplained;

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
}
