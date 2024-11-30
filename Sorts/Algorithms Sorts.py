#Monrreal Pool Ricardo
#Tecnícas Algorítmicas

import time
import random


print("Algoritmos de ordenamiento")
print("1. Insertion Sort")
print("2. Bubble Sort")
print("3. Quick Sort")
print("4. Heap Sort")

def tiempo(sort, data):
    inicio = time.time()
    sorted_data = sort(data.copy())
    fin = time.time()
    tiempo_ejecucion = fin - inicio
    return sorted_data, tiempo_ejecucion

def insertion_sort(data):
    for i in range(1, len(data)):
        aux = data[i]
        j = i - 1
        while j >= 0 and aux < data[j]:
            data [j + 1] = data [j]
            j -= 1
        data [j + 1] = aux
    return data

def quick_sort(data):
    if len(data) == 0:
        return []
    
    menor = []
    mayor = []
    igual = []
    n = len(data)
    suma = sum(data)
    pivoteaux = suma / n
    if len(data) > 1:
        for i in data:
            if (pivoteaux > i):
                menor.append(i)
            elif (pivoteaux < i):
                mayor.append(i)
            else:
                igual.append(i)

        return quick_sort(menor)+igual+quick_sort(mayor)
    else:
        return data

def bubble_sort(data):
    for i in range(len(data)):
        for j in range(len(data)):
            if data[i] < data[j]:
                aux = data[i]
                data[i] = data[j]
                data[j] = aux
    return data

def heapify(data, n, i):
    mayor = i
    izq = 2 * i + 1
    der = 2 * i + 2

    if izq < n and data[izq] > data[mayor]: #mayor izq
        mayor = izq

    if der < n and data[der] > data[mayor]: #mayor der
        mayor = der

    if mayor != i:
        temp = data[i]
        data[i] = data[mayor]
        data[mayor] = temp        
        heapify(data, n, mayor)

def heap_sort(data):
    sorted_list = []
    if len(data) == 0:
        return []
    sorted_list = []

    n = len(data)
    h = 0
    while (2 ** h) - 1 < n:
        h += 1
    root = (2 ** (h - 2)) - 1

    for i in range(root, -1, -1): #decrementar hasta 0.
        heapify(data, n, i)

    while len(data) > 1:
        max_val = data[0]
        sorted_list.append(max_val)
        data[0] = data.pop()
        heapify(data, len(data), 0)
        print(data)

    sorted_list.append(data.pop())

    return sorted_list

data = []
for i in range(10):
    data.append(random.randint(1,100))

print("Lista desordenada", data,"\n")

sorted_data, tiempo_ejecucion = tiempo(insertion_sort, data)
print("Tiempo total (insertion):", tiempo_ejecucion, "\n")

sorted_data, tiempo_ejecucion = tiempo(bubble_sort, data)
print("Tiempo total (bubble):", tiempo_ejecucion, "\n")

sorted_data, tiempo_ejecucion = tiempo(quick_sort, data)
print("Tiempo total (quick):", tiempo_ejecucion, "\n")

sorted_data, tiempo_ejecucion = tiempo(heap_sort, data)
print("Tiempo total (heap):", tiempo_ejecucion, "\n")