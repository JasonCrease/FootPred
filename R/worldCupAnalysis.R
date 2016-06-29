setwd("f:/github/FootPred/FootPredWeb/files/")
dfRaw = read.csv("./worldcup.csv", )

df = dfRaw[dfRaw$A_FT1 != '#N/A' & dfRaw$B_FT1 != '#N/A',]

df = as.data.frame(df)
df$MatchDiff  = df$S1 - df$S2
df$TotalGoals = df$S1 + df$S2

lmDiff = lm(MatchDiff ~  A_Perc + B_Perc + A_GD + B_GD, data = df)
summary(lmDiff)

lmTotalGoals = lm(TotalGoals ~  A_Perc + B_Perc, data = df)
summary(lmTotalGoals)

