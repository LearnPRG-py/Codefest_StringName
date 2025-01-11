import UnityEngine
import System
from System.Collections.Generic import List

maincamera = UnityEngine.GameObject.Find("Main Camera")
slider_behaviour = maincamera.GetComponent("sliderbehaviour")
SMA = 0
totalprice = 0
def calculate_SMA(totalprice, periodOfTime):
    SMA = totalprice / periodOfTime
    return SMA
slider_behaviour.SMA.Add(calculate_SMA(slider_behaviour.sum14, 14))

# Prices needs to be an array of all prices over period of time
# periodOfTime is the period of time
# i is the number of prices

# Output: SMA will be the Simple Moving Average
