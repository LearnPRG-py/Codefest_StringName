def CCIcalc(n, HIGH, CLOSE, LOW, ):
    typicalPrice = 0
    sums =0
    for i in range(n):
        sum = HIGH[i] + CLOSE[i] + LOW[i]
    typicalPrice += sum/3
    moveingAverage = typicalPrice / n
    meanDeviation 