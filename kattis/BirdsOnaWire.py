# Birds on a wire

podatki = input()          
seznam = podatki.split()
#v seznamu stevila bo: [dolžina žice, razdalja med ptiči, število ptičev že na žici]
stevila = list(map(int,seznam))   #iz seznama nizov naredimo seznam števil
zasedeno = []
for i in range(stevila[2]):    #za vse nadaljne podatke (kolikor je že ptičev)
    vrstica = int(input())
    zasedeno.append(vrstica)
zasedeno.sort()                #razporedimo zasedena mesta po vrsti

    
def kolikoPticev(stevila, zasedeno):
    '''Funkcija dobi podatke o dolžini žice, razdalji med ptiči, številu
    ptičev na žici in njihov položaj in vrne število dodtnih ptičev, ki se
    lahko vsedejo na žico'''
    if stevila[0] < 12:
# če je dolžina žice < 12 in morajo ptiči sedeti 6 cm od drogov potem ni
# prostora za nobenega ptiča
        return 0
    if zasedeno == []:
# celotna žica je prosta - dolžino žice(odštejemo 12, ker 6cm od drogov
# ne morejo sedeti) delimo z razdaljo med ptiči (prištejemo 1, ker imajo
# ptiči širino 0 in prvi ptič že lahko sedi med šestim in sedmim centimetrom
        return (int((stevila[0] - 12)/stevila[1]) + 1)
    koliko = 0
    meja1 = zasedeno[0]
# posebaj pogledamo koliko ptičev lahko sedi od šestega cm do prvega ptiča
# ki že sedi na žici in od zadnjega ptiča do dolžine žice - 6
    koliko += int((zasedeno[0]  - 6)/stevila[1])
    koliko += int(((stevila[0] - 6) - (zasedeno[len(zasedeno)-1]))/ stevila[1])
# med vsakima dvema ptičema, ki sta že na žici preverimo, koliko jih še lahko
# pride vmes
    for mesto in range(1,len(zasedeno)):
        meja2 = zasedeno[mesto]
        pticiVmes = int(((meja2 - meja1)/stevila[1]) - 1)
        koliko += pticiVmes
        meja1 = meja2
    return koliko

print(kolikoPticev(stevila, zasedeno))
        
                        
        
        
