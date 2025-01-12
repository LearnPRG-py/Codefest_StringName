import UnityEngine
import System
from System.Collections.Generic import List

maincamera = UnityEngine.GameObject.Find("Main Camera")
slider_behaviour = maincamera.GetComponent("sliderbehaviour")
SMA = 0
totalprice = 0

def calculate_SD(price, periodOfTime, n):
    n=14
    for i in range(n):
        ToBeSummed += (price - SMA)*(price - SMA)/n
    SD = (ToBeSummed / periodOfTime) ** (1/2)
    return SD

SD = calculate_SD

def calculate_ub(SMA, SD):
    ub = SMA + (SD * 2)
    return ub #red
    
UB = calculate_ub

def calculate_lb(SMA, SD):
    lb = SMA - (SD * 2)
    return lb #green

UB = calculate_ub(slider_behaviour.SMA[slider_behaviour.days-1], calculate_SD(slider_behaviour.close[slider_behaviour.days-14], 14, 14))
#LB and UB will be plotted. UB -> Red, LB -> Green