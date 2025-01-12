import UnityEngine
import System
from System.Collections.Generic import List

maincamera = UnityEngine.GameObject.Find("Main Camera")
slider_behaviour = maincamera.GetComponent("sliderbehaviour")
SMA = 0
ToBeSummed=0
totalprice = 0

def calculate_ub(SMA, SD):
    ub = SMA + (SD * 2)
    return ub #red
    
UB = calculate_ub

def calculate_lb(SMA, SD):
    lb = SMA - (SD * 2)
    return lb #green

slider_behaviour.UBlist.Add(calculate_ub(slider_behaviour.SMA[int(slider_behaviour.days)-62], slider_behaviour.sd14))
#LB and UB will be plotted. UB -> Red, LB -> Green
slider_behaviour.LBlist.Add(calculate_lb(slider_behaviour.SMA[int(slider_behaviour.days)-62], slider_behaviour.sd14))