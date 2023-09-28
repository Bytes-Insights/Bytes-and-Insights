
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    public ExplanationController explanation;

    private bool introExplained;
    private bool beamformingExplained;
    private bool sitesExplained;
    private bool FiveGExplained;
    private bool FourGExplained;
    private bool AIR6488Explained;
    private bool Radio4415Explained;

    public void ExplainIntro()
    {
        
        if (!introExplained) {

            explanation.ShowExplanation("Welcome to our city!", "The other codes represent 'sites' (antennas with radios) and an user (the laptop). Try placing them around the city and pointing at them with the camera to see what happens. Feel free to experiment and move them around.");

            introExplained = true;
            
        }

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

    public bool WasIntroExplained()
    {
        return introExplained;
    }
    public bool Was4GExplained()
    {
        return FourGExplained;
    }

    public void ExplainAIR6488()
    {
        AIR6488Explained = true;
        explanation.ShowExplanation("AIR6488", "This is an AIR unit, that is, an 'Antenna-integrated radio'. By integrating the radio unit with the antenna in a single device, this equipment allows service providers to deploy 5G networks without the need for extra physical space.\n" +
"It utilizes technologies such as 'Massive MIMO' (Multiple Input, Multiple Output) and 'beamforming', allowing for improved coverage, capacity and user experience (by supporting higher data rates and lower latencies).\n" +
"It has a compact design with average dimensions of about 80cm x 50cm x 25cm and 45 kg. The unit can work under a wide range of environmental operation conditions (such as temperatures from -40 to +55C and relative humidity from 2% to 100%).", 1);
    }

    public bool WasAIR6488Explained()
    {
        return AIR6488Explained;
    }

    public void ExplainRadio4415()
    {
        Radio4415Explained = true;
        explanation.ShowExplanation("Radio 4415", "This is a radio unit for 4G networks. Different from AIR models, this unit needs a separate antenna to operate.\n\n" +
"It supports MIMO (Multiple Input Multiple Output), a technology that helps in increasing the capacity and coverage of the network, thus enhancing user experiences.\n\n" +
"It has small dimensions and weighs only 17kg.", 1);
    }

    public bool WasRadio4415Explained()
    {
        return Radio4415Explained;
    }

}
