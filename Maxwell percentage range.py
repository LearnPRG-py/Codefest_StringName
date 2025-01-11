def williamsper(HH, LL, close):
    WPR = (HH -close)/(HH-LL)
    return WPR
# HH is the Highest High
# LL is the Lowest Low
# close is the most recent closing price
