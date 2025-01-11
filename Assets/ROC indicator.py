import UnityEngine
import System
from System.Collections.Generic import List

maincamera = UnityEngine.GameObject.Find("Main Camera")
slider_behaviour = maincamera.GetComponent("sliderbehaviour")
def calculate_roc(Price, PriceNperiodsAgo):
    RoC = (Price - PriceNperiodsAgo)/(PriceNperiodsAgo) * 100
    return RoC
slider_behaviour.ROC.Add(calculate_roc(slider_behaviour.close[int(slider_behaviour.days-1)], slider_behaviour.close[int(slider_behaviour.days-14)]))
#Price = Most Recent closing price
#PriceNperiodsAgo = Closing price at N periods