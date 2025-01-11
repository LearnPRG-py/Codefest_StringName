def calculate_roc(Price, PriceNperiodsAgo):
    RoC = (Price - PriceNperiodsAgo)/(PriceNperiodsAgo) * 100

#Price = Most Recent closing price
#PriceNperiodsAgo = Closing price at N periods