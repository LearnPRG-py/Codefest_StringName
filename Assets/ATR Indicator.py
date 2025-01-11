import UnityEngine
import System
from System.Collections.Generic import List

maincamera = UnityEngine.GameObject.Find("Main Camera")
slider_behaviour = maincamera.GetComponent("sliderbehaviour")

def TRcalc(H, L, C, n, pATR):
    TR = []
    for i in range(n):
        TR.append(max(H[i] - L[i], abs(H[i] - C[i]), abs(L[i] - C[i])))
    if pATR == 0:
        totalTR = sum(TR)
        pATR = totalTR / n
    ATR = (pATR * (n - 1) + TR[-1]) / n
    return ATR
if hasattr(slider_behaviour, 'days') and slider_behaviour.days >= 14:
    highs = list(slider_behaviour.high)
    lows = list(slider_behaviour.low)
    closes = list(slider_behaviour.close)
    days = slider_behaviour.days
    H_range = highs[int(days-14):int(days)]
    L_range = lows[int(days-14):int(days)]
    C_range = closes[int(days-14):int(days)]
    atr_value = TRcalc(H_range, L_range, C_range, 14, slider_behaviour.ATR[int(days-1)])
    slider_behaviour.ATR.add(atr_value)
else:
    print("Not enough data to calculate ATR or 'days' attribute is missing.")