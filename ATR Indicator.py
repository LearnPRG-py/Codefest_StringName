def TRcalc(H, L, C, n, pATR):
    TR = [];
    for i in range(n):
        TR.append(max(H[i] - L[i], abs(H[i] - C[i]), abs(L[i] - C[i])))
    if(pATR == 0):
        totalTR = 0;
        for i in TR:
            totalTR += TR[i];
        pATR = (1/n)*(totalTR)
    ATR = (pATR * (n - 1) + TR) / n
    return ATR


# H is the array of the Highs of each day
# L is the array of the Lows of each day
# C is the array of the closing prices of each previous day
# n is the number of days
# pATR is the previous ATR, if not defined, leave as 0

