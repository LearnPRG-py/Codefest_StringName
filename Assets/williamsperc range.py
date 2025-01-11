def williamsper(High, LL, close):
    WPR = (High - close)/(High - LL)
    return WPR
# High is the Highest High
# LL is the Lowest Low
# close is the most recent closing price
