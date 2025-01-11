P = 14

def calculate_typical_price(High, Low, Price, n):
    for i in range(n):
        typical_price += ((High[i] + Low[i] + Price[i]) / 3)
    return typical_price

TP = calculate_typical_price

def calculate_moving_average(n):
    for i in range(n):
        MovingAvg += (TP) / P
    return MovingAvg

MA = calculate_moving_average

def calculate_mean_deviation(n):
    for i in range(n):
        MeanDeviation += (abs(TP - MA) / P)
    return MeanDeviation

MD = calculate_mean_deviation

def calculate_CCI():
    CCI = (TP-MA)/(0.015*MD)
    return CCI

Commodity_Channel_Index = calculate_CCI