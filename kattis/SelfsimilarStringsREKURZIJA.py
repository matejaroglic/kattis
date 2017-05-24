# Self-similar strings REKURZIJA

import sys

def podobnost(niz, stopnja):
    '''Funkcija dobi nek niz in njegovo največjo možno stopnjo samopodobnosti
    in vrne njegovo dejansko največjo stopnjo samopodobnosti'''
# ustavitveni pogoj
    if stopnja == 0:
        return 0
# v seznam damo vse podnize dolžine stopnja
    meja1 = 0
    meja2 = stopnja
    sezPodnizov = []
    for i in range(0,len(niz)-stopnja+1):
        sezPodnizov.append(niz[meja1+i:meja2+i])
# naredimo množico, da se znebimo podvojenih podnizov. Dovolj je da pogledamo
# samo najbolj začetni podniz in preverimo ali se pojavi v preostanku besede
    mnozica = set(sezPodnizov)
    for podniz in mnozica:
# metoda niz.find(podniz) nam pove prvi indeks na kateremu se v nizu pojavi
# podniz (indeks prve črke podniza v nizu)
        dalje = niz.find(podniz)
        if podniz not in niz[dalje+1:]:
# če se kakšen podniz ne pojavi še kje v nizu znova kličemo funkcijo
# podobnost s stopnjo ena manj
            return podobnost(niz, stopnja - 1)
    return stopnja


for niz in sys.stdin:
    beseda = niz.rstrip()
# največja možna stopnja podobnosti je lahko za ena manj od dolžine besede
    stopnja = len(beseda) - 1
    print(podobnost(beseda, stopnja))
