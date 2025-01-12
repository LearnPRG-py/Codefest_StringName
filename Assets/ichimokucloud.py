import UnityEngine
import System
from System.Collections.Generic import List

maincamera = UnityEngine.GameObject.Find("Main Camera")
slider_behaviour = maincamera.GetComponent("sliderbehaviour")

def tenkasen(highest_high9, lowest_low9):
    return (highest_high9+lowest_low9)/2 # blue
def kijunsen(highest_high26, lowest_low26):
    return (highest_high26+lowest_low26)/2 # red
def senkounspanA(highest_high9, lowest_low9, highest_high26, lowest_low26):
    return (tenkasen(highest_high9, lowest_low9)+kijunsen(highest_high26, lowest_low26))/2 #green
def senkounspanB(highest_high52, lowest_low52):
    return (highest_high52+lowest_low52)/2 # red
def chikouspan(closingprice26):
    return closingprice26 #green

slider_behaviour.tks.Add(tenkasen(slider_behaviour.HH9, slider_behaviour.LL9))
slider_behaviour.kjs.Add(kijunsen(slider_behaviour.HH26, slider_behaviour.LL26))
slider_behaviour.senA.Add(senkounspanA(slider_behaviour.HH9, slider_behaviour.LL9, slider_behaviour.HH26, slider_behaviour.LL26))
slider_behaviour.senB.Add(senkounspanB(slider_behaviour.HH52, slider_behaviour.LL52))
slider_behaviour.chikou.Add(chikouspan(slider_behaviour.close[int(slider_behaviour.days-26)]))